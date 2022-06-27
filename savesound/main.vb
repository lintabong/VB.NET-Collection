Imports System
Imports System.Runtime.InteropServices

Module program

    Public Declare Sub Sleep Lib "Kernel32" (ByVal dwMilliseconds As Long)
    Public Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstyCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLenght As Integer, ByVal hwndCallback As Integer) As Integer

    Sub Main()
        Dim port As String
        Dim com As String
        Dim returnStr As String
        Dim conn As IO.Ports.SerialPort
        Dim availablePorts() As String
        Dim rotFolder As String = "D:\\OutputAudio\"
        Dim fileCounter As Integer = 0
        Dim startRecord As Integer
        Dim statusRecord As Boolean = True
        Dim statusModule As String = "waiting"

        availablePorts = IO.Ports.SerialPort.GetPortNames()
        Console.Write("Port tersedia: ")
        Dim prt As String
        For Each prt In availablePorts
            Console.Write(" " + prt + " ")
        Next prt
        Console.WriteLine(" ")

        Dim di As New IO.DirectoryInfo(rotFolder)
        Debug.Print("di:" + di.ToString)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dia As IO.FileInfo

        For Each dia In diar1
            fileCounter += 1
        Next

        Console.WriteLine("Jumlah file: " + fileCounter.ToString())
        Console.WriteLine("Masukkan Port yang akan digunakan:")
        port = Console.ReadLine()
        com = "COM" + port

        Console.WriteLine(com)

        conn = New IO.Ports.SerialPort()
        conn.PortName = com
        conn.BaudRate = 9600
        conn.DataBits = 8
        conn.Parity = IO.Ports.Parity.None

        conn.Close()
        conn.Open()

        While True
            returnStr = conn.ReadLine()
            Try
                startRecord = CInt(returnStr)
            Catch ex As Exception

            End Try

            If startRecord = 0 And statusRecord = True Then
                mciSendString("open new Type waveaudio Alias recsound", "", 0, 0)
                mciSendString("record recsound", "", 0, 0)
                statusRecord = False
                statusModule = "Start Recording"
            ElseIf startRecord = 1 And statusRecord = False Then
                statusRecord = True
                mciSendString("save recsound " + rotFolder + "aud" + fileCounter.ToString() + ".wav", "", 0, 0)
                mciSendString("close recsound ", "", 0, 0)
                fileCounter += 1
                statusModule = "Saving . . ."
            ElseIf startRecord = 1 And statusRecord = True Then
                statusModule = "Waiting Controller"
            ElseIf startRecord = 0 And statusRecord = False Then
                statusModule = "Recording"
            End If

            Console.Write(Now())
            Console.Write("  ")
            Console.Write(startRecord)
            Console.Write("  ")
            Console.WriteLine(statusModule)
            Sleep(1000)
        End While
    End Sub
End Module
