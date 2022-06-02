Imports System
Imports System.Runtime.InteropServices

Module program


    Sub Main()
        Dim filepath As String = "C:\Users\Lintang Bongkar IRIS\source\repos\ConsoleApp1\ConsoleApp1\data\user.txt"
        Dim line(99) As String
        Dim username(99) As String
        Dim password(99) As String
        Dim target_username As String
        Dim target_password As String
        Dim status_login As Boolean
        Dim counter As Integer = 0

        For Each ln As String In IO.File.ReadAllLines(filepath)
            line(counter) = ln
            username(counter) = line(counter).Split(".")(0)
            password(counter) = line(counter).Split(".")(1)
            Console.Write(username(counter))
            Console.Write("      ")
            Console.WriteLine(password(counter))
            counter += 1
        Next

        Console.WriteLine("  ")
        Console.WriteLine("================================")
        Console.WriteLine("  ")
        Console.Write("username: ")
        target_username = Console.ReadLine()
        Console.Write("password: ")
        target_password = Console.ReadLine()

        status_login = False
        counter = 0
        For Each ln As String In IO.File.ReadAllLines(filepath)

            If target_username.Equals(username(counter)) Then
                If target_password.Equals(password(counter)) Then
                    status_login = True
                End If
            End If
            counter += 1
        Next

        If status_login = True Then
            Console.WriteLine("login berhasil")
        Else
            Console.WriteLine("gagal login")
        End If

    End Sub
End Module
