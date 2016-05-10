Module Module1

    Sub Main()
        For Each param In My.Application.CommandLineArgs
            Console.WriteLine(param)
            Console.ReadKey()
        Next
    End Sub

End Module
