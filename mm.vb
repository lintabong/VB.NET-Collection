            Dim se As Integer = Now().Second
            Dim mi As Integer = Now().Minute
            Dim ho As Integer = Now().Hour.ToString()
            Dim da As String = Now().Day.ToString()
            Dim mo As Integer = Now().Month.ToString()
            Dim ye As String = Now().Year.ToString()

            Dim Sse As String
            Dim Smi As String
            Dim Sho As String

            If se < 10 Then
                Sse = "0" + se.ToString()
            Else
                Sse = se.ToString()
            End If

            If mi < 10 Then
                Smi = "0" + mi.ToString()
            Else
                Smi = mi.ToString()
            End If

            If ho < 10 Then
                Sho = "0" + ho.ToString()
            Else
                Sho = ho.ToString()
            End If

            Dim month() As String = {"Januari", "Pebruari", "Maret", "April", "Mei", "Juni",
                                 "Juli", "Agustus", "September", "Oktober", "Nopember",
                                 "Desember"}

            Dim folder As String = "D:\vb_database\" + Form2.username.Text.ToString() + "\" + ye + "\" + month(mo - 1) + "\" + da + "\"
            Dim datename As String = Sho + "-" + Smi + "-" + Sse

            Try
                returnStr = conn.ReadLine()
                startRecord = CInt(returnStr)
            Catch ex As Exception

            End Try

            If startRecord = 0 And statusRecord = True Then
                mciSendString("open new Type waveaudio Alias recsound", "", 0, 0)
                mciSendString("record recsound", "", 0, 0)
                statusRecord = False
            ElseIf startRecord = 1 And statusRecord = False Then
                statusRecord = True
                mciSendString("save recsound " + folder + datename + ".wav", "", 0, 0)
                mciSendString("close recsound ", "", 0, 0)
            ElseIf startRecord = 1 And statusRecord = True Then
            ElseIf startRecord = 0 And statusRecord = False Then
            Else
            End If

            If i = max - 1 Then
                mciSendString("save recsound " + folder + datename + ".wav", "", 0, 0)
                mciSendString("close recsound ", "", 0, 0)
                Me.Hide()
            End If

            Sleep(1000)
