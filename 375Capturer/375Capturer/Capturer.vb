
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Reflection
Public Class Capturer

    Private Function CaptureScreen() As Bitmap
        Dim screenSize As Rectangle = Screen.PrimaryScreen.Bounds
        Dim target As New Bitmap(screenSize.Width, screenSize.Height)
        Using g As Graphics = Graphics.FromImage(target)
            g.CopyFromScreen(0, 0, 0, 0, New Size(screenSize.Width, screenSize.Height))
        End Using
        Return target
    End Function
End Class
#If False Then
Public Class AviWriter
    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Private Structure AVISTREAMINFOW
        Public fccType As UInt32, fccHandler As UInt32, dwFlags As UInt32, dwCaps As UInt32

        Public wPriority As UInt16, wLanguage As UInt16

        Public dwScale As UInt32, dwRate As UInt32, dwStart As UInt32, dwLength As UInt32, dwInitialFrames As UInt32, dwSuggestedBufferSize As UInt32,
            dwQuality As UInt32, dwSampleSize As UInt32, rect_left As UInt32, rect_top As UInt32, rect_right As UInt32, rect_bottom As UInt32,
            dwEditCount As UInt32, dwFormatChangeCount As UInt32

        Public szName0 As UInt16, szName1 As UInt16, szName2 As UInt16, szName3 As UInt16, szName4 As UInt16, szName5 As UInt16,
            szName6 As UInt16, szName7 As UInt16, szName8 As UInt16, szName9 As UInt16, szName10 As UInt16, szName11 As UInt16,
            szName12 As UInt16, szName13 As UInt16, szName14 As UInt16, szName15 As UInt16, szName16 As UInt16, szName17 As UInt16,
            szName18 As UInt16, szName19 As UInt16, szName20 As UInt16, szName21 As UInt16, szName22 As UInt16, szName23 As UInt16,
            szName24 As UInt16, szName25 As UInt16, szName26 As UInt16, szName27 As UInt16, szName28 As UInt16, szName29 As UInt16,
            szName30 As UInt16, szName31 As UInt16, szName32 As UInt16, szName33 As UInt16, szName34 As UInt16, szName35 As UInt16,
            szName36 As UInt16, szName37 As UInt16, szName38 As UInt16, szName39 As UInt16, szName40 As UInt16, szName41 As UInt16,
            szName42 As UInt16, szName43 As UInt16, szName44 As UInt16, szName45 As UInt16, szName46 As UInt16, szName47 As UInt16,
            szName48 As UInt16, szName49 As UInt16, szName50 As UInt16, szName51 As UInt16, szName52 As UInt16, szName53 As UInt16,
            szName54 As UInt16, szName55 As UInt16, szName56 As UInt16, szName57 As UInt16, szName58 As UInt16, szName59 As UInt16,
            szName60 As UInt16, szName61 As UInt16, szName62 As UInt16, szName63 As UInt16
    End Structure
    ' vfw.h
    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Private Structure AVICOMPRESSOPTIONS
        Public fccType As UInt32
        Public fccHandler As UInt32
        Public dwKeyFrameEvery As UInt32
        ' only used with AVICOMRPESSF_KEYFRAMES
        Public dwQuality As UInt32
        Public dwBytesPerSecond As UInt32
        ' only used with AVICOMPRESSF_DATARATE
        Public dwFlags As UInt32
        Public lpFormat As IntPtr
        Public cbFormat As UInt32
        Public lpParms As IntPtr
        Public cbParms As UInt32
        Public dwInterleaveEvery As UInt32
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Public Structure BITMAPINFOHEADER
        Public biSize As UInt32
        Public biWidth As Int32
        Public biHeight As Int32
        Public biPlanes As Int16
        Public biBitCount As Int16
        Public biCompression As UInt32
        Public biSizeImage As UInt32
        Public biXPelsPerMeter As Int32
        Public biYPelsPerMeter As Int32
        Public biClrUsed As UInt32
        Public biClrImportant As UInt32
    End Structure

    Public Class AviException
        Inherits ApplicationException
        Public Sub New(s As String)
            MyBase.New(s)
        End Sub
        Public Sub New(s As String, hr As Int32)
            MyBase.New(s)

            If hr = AVIERR_BADPARAM Then
                err_msg = "AVIERR_BADPARAM"
            Else
                err_msg = "unknown"
            End If
        End Sub

        Public Function ErrMsg() As String
            Return err_msg
        End Function
        Private Const AVIERR_BADPARAM As Int32 = -2147205018
        Private err_msg As String
    End Class

    Public Function Open(fileName As String, frameRate As UInt32, width As Integer, height As Integer) As Bitmap
        frameRate_ = frameRate
        width_ = DirectCast(width, UInt32)
        height_ = DirectCast(height, UInt32)
        bmp_ = New Bitmap(width, height, PixelFormat.Format24bppRgb)
        Dim bmpDat As BitmapData = bmp_.LockBits(New Rectangle(0, 0, width, height), ImageLockMode.[ReadOnly], PixelFormat.Format24bppRgb)
        stride_ = DirectCast(bmpDat.Stride, UInt32)
        bmp_.UnlockBits(bmpDat)
        AVIFileInit()
        ' OF_WRITE | OF_CREATE (winbase.h) 
        Dim hr As Integer = AVIFileOpenW(pfile_, fileName, 4097, 0)
        If hr <> 0 Then
            Throw New AviException("error for AVIFileOpenW")
        End If

        CreateStream()
        SetOptions()

        Return bmp_
    End Function

    Public Sub AddFrame()

        Dim bmpDat As BitmapData = bmp_.LockBits(New Rectangle(0, 0, CInt(width_), CInt(height_)), ImageLockMode.[ReadOnly], PixelFormat.Format24bppRgb)

        ' pointer to data
        ' 16 = AVIIF_KEYFRAMe
        Dim hr As Integer = AVIStreamWrite(psCompressed_, count_, 1, bmpDat.Scan0, DirectCast(stride_ * height_, Int32), 0,
            0, 0)

        If hr <> 0 Then
            Throw New AviException("AVIStreamWrite")
        End If

        bmp_.UnlockBits(bmpDat)

        count_ += 1
    End Sub

    Public Sub Close()
        AVIStreamRelease(ps_)
        AVIStreamRelease(psCompressed_)

        AVIFileRelease(pfile_)
        AVIFileExit()
    End Sub

    Private Sub CreateStream()
        Dim strhdr As New AVISTREAMINFOW()
        strhdr.fccType = fccType_
        strhdr.fccHandler = fccHandler_
        strhdr.dwFlags = 0
        strhdr.dwCaps = 0
        strhdr.wPriority = 0
        strhdr.wLanguage = 0
        strhdr.dwScale = 1
        strhdr.dwRate = frameRate_
        ' Frames per Second
        strhdr.dwStart = 0
        strhdr.dwLength = 0
        strhdr.dwInitialFrames = 0
        strhdr.dwSuggestedBufferSize = height_ * stride_
        strhdr.dwQuality = &HFFFFFFFFUI
        '-1;         // Use default
        strhdr.dwSampleSize = 0
        strhdr.rect_top = 0
        strhdr.rect_left = 0
        strhdr.rect_bottom = height_
        strhdr.rect_right = width_
        strhdr.dwEditCount = 0
        strhdr.dwFormatChangeCount = 0
        strhdr.szName0 = 0
        strhdr.szName1 = 0

        Dim hr As Integer = AVIFileCreateStream(pfile_, ps_, strhdr)

        If hr <> 0 Then
            Throw New AviException("AVIFileCreateStream")
        End If
    End Sub

    Private Sub SetOptions()
        Dim opts As New AVICOMPRESSOPTIONS()
        opts.fccType = 0
        'fccType_;
        opts.fccHandler = 0
        'fccHandler_;
        opts.dwKeyFrameEvery = 0
        opts.dwQuality = 0
        ' 0 .. 10000
        opts.dwFlags = 0
        ' AVICOMRPESSF_KEYFRAMES = 4
        opts.dwBytesPerSecond = 0
        opts.lpFormat = 0
        'new IntPtr(0);
        opts.cbFormat = 0
        opts.lpParms = 0
        'new IntPtr(0);
        opts.cbParms = 0
        opts.dwInterleaveEvery = 0

        Dim p As Pointer(Of AVICOMPRESSOPTIONS) = New Pointer(Of AviWriter.AVICOMPRESSOPTIONS)(opts)
        Dim pp As Pointer(Of Pointer(Of AVICOMPRESSOPTIONS)) = New Pointer(Of AviWriter.AVICOMPRESSOPTIONS*)(p)

        Dim x As IntPtr = ps_
        Dim ptr_ps As Pointer(Of IntPtr) = AddressOf x

        AVISaveOptions(0, 0, 1, ptr_ps, pp)



        ' TODO: AVISaveOptionsFree(...)

        Dim hr As Integer = AVIMakeCompressedStream(psCompressed_, ps_, opts, 0)
        If hr <> 0 Then
            Throw New AviException("AVIMakeCompressedStream")
        End If

        Dim bi As New BITMAPINFOHEADER()
        bi.biSize = 40
        bi.biWidth = DirectCast(width_, Int32)
        bi.biHeight = DirectCast(height_, Int32)
        bi.biPlanes = 1
        bi.biBitCount = 24
        bi.biCompression = 0
        ' 0 = BI_RGB
        bi.biSizeImage = stride_ * height_
        bi.biXPelsPerMeter = 0
        bi.biYPelsPerMeter = 0
        bi.biClrUsed = 0
        bi.biClrImportant = 0

        hr = AVIStreamSetFormat(psCompressed_, 0, bi, 40)
        If hr <> 0 Then
            Throw New AviException("AVIStreamSetFormat", hr)
        End If
    End Sub

    <DllImport("avifil32.dll")>
    Private Shared Sub AVIFileInit()
    End Sub

    <DllImport("avifil32.dll")>
    Private Shared Function AVIFileOpenW(ByRef ptr_pfile As Integer, <MarshalAs(UnmanagedType.LPWStr)> fileName As String, flags As Integer, dummy As Integer) As Integer
    End Function

    <DllImport("avifil32.dll")>
    Private Shared Function AVIFileCreateStream(ptr_pfile As Integer, ByRef ptr_ptr_avi As IntPtr, ByRef ptr_streaminfo As AVISTREAMINFOW) As Integer
    End Function

    <DllImport("avifil32.dll")>
    Private Shared Function AVIMakeCompressedStream(ByRef ppsCompressed As IntPtr, aviStream As IntPtr, ByRef ao As AVICOMPRESSOPTIONS, dummy As Integer) As Integer
    End Function

    <DllImport("avifil32.dll")>
    Private Shared Function AVIStreamSetFormat(aviStream As IntPtr, lPos As Int32, ByRef lpFormat As BITMAPINFOHEADER, cbFormat As Int32) As Integer
    End Function

    <DllImport("avifil32.dll")>
    Private Shared Function AVISaveOptions(hwnd As Integer, flags As UInt32, nStreams As Integer, ptr_ptr_avi As Pointer(Of IntPtr), ao As Pointer(Of Pointer(Of AVICOMPRESSOPTIONS))) As Integer
    End Function

    <DllImport("avifil32.dll")>
    Private Shared Function AVIStreamWrite(aviStream As IntPtr, lStart As Int32, lSamples As Int32, lpBuffer As IntPtr, cbBuffer As Int32, dwFlags As Int32,
        dummy1 As Int32, dummy2 As Int32) As Integer
    End Function

    <DllImport("avifil32.dll")>
    Private Shared Function AVIStreamRelease(aviStream As IntPtr) As Integer
    End Function

    <DllImport("avifil32.dll")>
    Private Shared Function AVIFileRelease(pfile As Integer) As Integer
    End Function

    <DllImport("avifil32.dll")>
    Private Shared Sub AVIFileExit()
    End Sub

    Private pfile_ As Integer = 0
    Private ps_ As New IntPtr(0)
    Private psCompressed_ As New IntPtr(0)
    Private frameRate_ As UInt32 = 0
    Private count_ As Integer = 0
    Private width_ As UInt32 = 0
    Private stride_ As UInt32 = 0
    Private height_ As UInt32 = 0
    Private fccType_ As UInt32 = 1935960438
    ' vids
    Private fccHandler_ As UInt32 = 808810089
    ' IV50
    '1145656899;  // CVID
    Private bmp_ As Bitmap
End Class

#End If