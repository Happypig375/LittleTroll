using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unsafe
{
    public static class EntryPoint { static void Entry() { var A = new Pointer(8); } }
    public unsafe struct Pointer
    {
        public Pointer(byte Object) { Inner = &Object; }
        public Pointer(sbyte Object) { Inner = &Object; }
        public Pointer(short Object) { Inner = &Object; }
        public Pointer(ushort Object) { Inner = &Object; }
        public Pointer(int Object) { Inner = &Object; }
        public Pointer(uint Object) { Inner = &Object; }
        public Pointer(long Object) { Inner = &Object; }
        public Pointer(ulong Object) { Inner = &Object; }
        public Pointer(float Object) { Inner = &Object; }
        public Pointer(double Object) { Inner = &Object; }
        public Pointer(decimal Object) { Inner = &Object; }
        public Pointer(DateTime Object) { Inner = &Object; }
        public Pointer(DateTimeOffset Object) { Inner = &Object; }
        public Pointer(TimeSpan Object) { Inner = &Object; }
        public Pointer(IntPtr Object) { Inner = &Object; }
        public Pointer(UIntPtr Object) { Inner = &Object; }
        public Pointer(void* Pointer) { Inner = Pointer; }

        void* Inner;

        public byte* AsBytePtr() { return (byte*)Inner; }
        public sbyte* AsSbytePtr() { return (sbyte*)Inner; }
        public short* AsShortPtr() { return (short*)Inner; }
        public ushort* AsUShortPtr() { return (ushort*)Inner; }
        public int* AsIntPtr() { return (int*)Inner; }
        public uint* AsUIntPtr() { return (uint*)Inner; }
        public long* AsLongPtr() { return (long*)Inner; }
        public ulong* AsUlongPtr() { return (ulong*)Inner; }
        public float* AsFloatPtr() { return (float*)Inner; }
        public double* AsDoublePtr() { return (double*)Inner; }
        public decimal* AsDecimalPtr() { return (decimal*)Inner; }
        public DateTime* AsDateTimePtr() { return (DateTime*)Inner; }
        public DateTimeOffset* AsDateTimeOffsetPtr() { return (DateTimeOffset*)Inner; }
        public TimeSpan* AsTimeSpanPtr() { return (TimeSpan*)Inner; }
        public IntPtr* AsIntPtrPtr() { return (IntPtr*)Inner; }
        public UIntPtr* AsUIntPtrPtr() { return (UIntPtr*)Inner; }
        public byte Asbyte() { return (byte)Inner; }
        public sbyte Assbyte() { return (sbyte)Inner; }
        public short Asshort() { return (short)Inner; }
        public ushort Asushort() { return (ushort)Inner; }
        public int Asint() { return (int)Inner; }
        public uint Asuint() { return (uint)Inner; }
        public long Aslong() { return (long)Inner; }
        public ulong Asulong() { return (ulong)Inner; }
        public float Asfloat() { return (float)Inner; }
        public double Asdouble() { return (double)Inner; }
        public decimal Asdecimal() { return (decimal)Inner; }
        public DateTime AsDateTime() { return (DateTime)Inner; }
        public DateTimeOffset AsDateTimeOffset() { return (DateTimeOffset)Inner; }
        public TimeSpan AsTimeSpan() { return (TimeSpan)Inner; }
        public IntPtr AsIntPtr() { return (IntPtr)Inner; }
        public UIntPtr AsUIntPtr() { return (UIntPtr)Inner; }
        public void* AsPtr() { return Inner; }
    }
}
