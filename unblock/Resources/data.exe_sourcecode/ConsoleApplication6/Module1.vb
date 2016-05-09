Imports System.IO
Imports Ionic.Zip
Module Module1

    Sub Main(ByVal sArgs() As String)
        Dim zipFileStream As MemoryStream = New MemoryStream(My.Resources.data)
        Try
            If sArgs.Length = 0 Then
                Console.WriteLine("error.no.args")
            ElseIf Directory.Exists(sArgs(0)) Then
                Using zip As ZipFile = ZipFile.Read(zipFileStream)
                    Dim entry As ZipEntry
                    For Each entry In zip
                        entry.Extract(sArgs(0), ExtractExistingFileAction.OverwriteSilently)
                    Next
                End Using
                Console.WriteLine("ok")
            Else
                Console.WriteLine("error.wrong.args" & sArgs(0))
            End If
        Catch ex As Exception
            Console.WriteLine("error.unknown.err")
        End Try
    End Sub

End Module
