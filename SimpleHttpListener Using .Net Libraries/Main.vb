Imports System.Net
Imports System.Threading.Tasks

Module Main

    Sub Main()

        Dim l As New HttpListener()
        l.Prefixes.Add("http://*:8888/")
        l.Start()

        Task.Factory.StartNew(
            Sub()
                Do
                    Dim ctx = l.GetContext()

                    Task.Factory.StartNew(
                        Sub()
                            Dim SRet As String = Now
                            Dim BRet = System.Text.Encoding.UTF8.GetBytes(SRet)
                            ctx.Response.ContentLength64 = BRet.Length
                            ctx.Response.OutputStream.Write(BRet, 0, BRet.Length)
                        End Sub)
                Loop
            End Sub)

        Console.WriteLine("Listening connection on port 8888")
        Console.WriteLine("Press any key to exit")
        Console.ReadKey()
    End Sub

End Module
