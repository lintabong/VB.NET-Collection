Imports System
Imports System.Runtime.InteropServices

Module program

    Public Declare Sub Sleep Lib "Kernel32" (ByVal dwMilliseconds As Long)
    Public Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstyCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLenght As Integer, ByVal hwndCallback As Integer) As Integer

    Sub Main()

        Dim datename As String
        Dim name As String
        Dim se As String
        Dim mi As String
        Dim ho As String
        Dim da As String
        Dim mo As String
        Dim ye As String
        Dim folder As String = "D:\PROJECT\3VBNET\01-\savedsound\"
        Dim count As Integer
        Dim search As String


        Dim namesrc(10000) As String
        Dim index(10000) As Integer

        se = Now().Second.ToString()
        mi = Now().Minute.ToString()
        ho = Now().Hour.ToString()
        da = Now().Day.ToString()
        mo = Now().Month.ToString()
        ye = Now().Year.ToString()

        Dim di As New IO.DirectoryInfo(folder)
        Debug.Print("di:" + di.ToString)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dia As IO.FileInfo

        For Each dia In diar1
            count += 1
        Next

        Console.WriteLine("==================================")
        Console.WriteLine("==================================")
        Console.WriteLine("==================================")
        Console.WriteLine("  ")
        Console.WriteLine("  ")
        Console.WriteLine("Jumlah file: " + count.ToString())

        'datename = ye + "-" + mo + "-" + da + "=" + se + "-" + mi + "-" + ho + "=mp_" + count.ToString()
        'Console.WriteLine(datename)

        'mciSendString("open new Type waveaudio Alias recsound", "", 0, 0)
        'mciSendString("record recsound", "", 0, 0)

        'Sleep(1000)
        'mciSendString("save recsound " + folder + datename + ".wav", "", 0, 0)
        'mciSendString("close recsound ", "", 0, 0)

        Console.WriteLine("  ")
        Console.WriteLine("Masukkan nama")
        Console.WriteLine("format:")
        Console.Write("yyyy-m-d")
        Console.Write("     Contoh: ")
        Console.WriteLine("2022-6-3")

        search = Console.ReadLine()

        Dim rrs As String
        rrs = IO.Path.GetDirectoryName(folder).ToString() + "\"

        Console.WriteLine(rrs)
        count = 0
        For Each dia In diar1
            namesrc(count) = dia.ToString().Split("\")(rrs.Split("\").Length - 1)
            namesrc(count) = namesrc(count).Split("=")(0)

            If search.Equals(namesrc(count)) Then
                Console.Write(count)
                Console.Write("   ")
                Console.WriteLine(dia.ToString().Split("\")(rrs.Split("\").Length - 1))

            End If


            count += 1
        Next

    End Sub
End Module
