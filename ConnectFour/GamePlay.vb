Public Class GamePlay

    Public arrField(6, 5) As Integer
    Public intCurrentPlayer As Integer = 1
    Public intMainPlayer As Integer = 1
    Public booAgainstComputer As Boolean = True
    Public booEnabled As Boolean = True

    Public listPlayerMoves As New List(Of Integer)
    Public listComputerMoves As New List(Of Integer)

    Public intScores(1) As Integer

    Private Sub GamePlay_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        '' Always position the form in the middle of the screen.
        Dim location As New Point

        location.X = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        location.Y = (My.Computer.Screen.Bounds.Height - Me.Height) / 2

        Me.SetDesktopLocation(location.X, location.Y)

    End Sub

    Private Sub GamePlay_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Logon.Close()
    End Sub


    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        GameMenu.Show()
        Connect4_Reset()
        Me.Hide()
    End Sub

    Public Sub Connect4_Enable()
        Connect4_Reset()

        booEnabled = True

        '' Hide the replay button
        btnReplay.Visible = False

        '' Write in the player's names.
        lblP1Name.Text = GameConfig.tbP1Name.Text
        lblP2Name.Text = GameConfig.tbP2Name.Text

        '' Determine whether you are versing a computer or not.
        If GameConfig.rbPlayer1.Enabled = True Then
            booAgainstComputer = True

            '' Get which player you are when versing a computer
            If GameConfig.rbPlayer1.Checked = True Then
                intMainPlayer = 1
            Else
                intMainPlayer = 2
                Connect4_ComputerPlay()
            End If

        Else
            booAgainstComputer = False
        End If

        '' Clear the list of moves in case it was written to.
        listPlayerMoves.Clear()
        listComputerMoves.Clear()

        Me.Invalidate() '' Redraws the screen
    End Sub

    Private Sub Connect4_Reset()

        '' Clear the array containing where the pieces are.
        Dim arrEmptyField(6, 5) As Integer
        arrField = arrEmptyField

        intCurrentPlayer = 1

        listPlayerMoves.Clear()
        listComputerMoves.Clear()

        Connect4_ButtonsEnabled(True)
        Me.Invalidate() '' Redraws the screen

    End Sub

    Private Sub Connect4_Disable()
        Connect4_ButtonsEnabled(False)
        booEnabled = False
        btnReplay.Visible = True
        Me.Invalidate()
    End Sub

    Private Sub Connect4_Play(ByVal intColumn As Integer)

        If booEnabled = False Then
            Exit Sub
        End If

        If booAgainstComputer = True And Not intMainPlayer = intCurrentPlayer Then
            MsgBox("It is not your turn!")
            Exit Sub
        End If

        Dim booDone As Boolean = False

        For intRow = 0 To 5

            If booDone = False Then
                If arrField(intColumn, intRow) = Nothing Then

                    booDone = True
                    arrField(intColumn, intRow) = intCurrentPlayer
                    appendLastMove("Player", intColumn)

                    Connect4_CheckColumnFull(intColumn, intRow)
                    Me.Invalidate() '' Redraws the screen

                    Connect4_CheckWin(intCurrentPlayer)
                    intCurrentPlayer = (intCurrentPlayer Mod 2) + 1 '' 1 becomes 2, 2 becomes 1

                    Connect4_Stalemate()
                    Connect4_ComputerPlay()

                ElseIf intRow = 5 Then
                    MsgBox("Column full")
                    Exit Sub
                End If
            End If

        Next

    End Sub

    Private Sub Connect4_ComputerPlay()

        '' Do not run if it is not the Computer's turn.
        If booAgainstComputer = False Or booEnabled = False Or intMainPlayer = intCurrentPlayer Then
            Exit Sub
        End If

        Dim intRandom As Integer
        intRandom = ComputerLogic.Logic(intRandom)

        '' Check for full columns
        For i As Integer = 0 To 6
            If arrField((intRandom + i) Mod 7, 5) = Nothing Then
                intRandom = (intRandom + i) Mod 7
                Exit For
            End If
        Next

        '' Get the top-most position in the column.
        Dim intRow As Integer = 0
        For i As Integer = 0 To 5
            If arrField(intRandom, i) = Nothing Then
                intRow = i
                Exit For
            End If
        Next

        arrField(intRandom, intRow) = intCurrentPlayer
        appendLastMove("Computer", intRandom)

        Me.Invalidate() '' Redraws the screen

        Connect4_CheckWin(intCurrentPlayer)

        Connect4_CheckColumnFull(intRandom, intRow)
        Connect4_Stalemate()

        intCurrentPlayer = (intCurrentPlayer Mod 2) + 1 '' 1 becomes 2, 2 becomes 1

    End Sub

    Private Sub Connect4_CheckColumnFull(ByVal intColumn As Integer, ByVal intRow As Integer)

        If Not intRow = 5 Then
            Exit Sub
        End If

        Select Case intColumn
            Case 0
                btnPlayA.Visible = False
            Case 1
                btnPlayB.Visible = False
            Case 2
                btnPlayC.Visible = False
            Case 3
                btnPlayD.Visible = False
            Case 4
                btnPlayE.Visible = False
            Case 5
                btnPlayF.Visible = False
            Case 6
                btnPlayG.Visible = False
        End Select

    End Sub

    Private Sub Connect4_Stalemate()
        '' Check if all columns are full.
        If Not arrField(0, 5) = Nothing And _
            Not arrField(1, 5) = Nothing And _
            Not arrField(2, 5) = Nothing And _
            Not arrField(3, 5) = Nothing And _
            Not arrField(4, 5) = Nothing And _
            Not arrField(5, 5) = Nothing And _
            Not arrField(6, 5) = Nothing Then

            Connect4_Disable()
            MsgBox("Stalemate: No one wins.")

        End If
    End Sub

    Private Sub Connect4_CheckWin(ByVal intPlayer As Integer)

        '' Loop across every piece in the field.
        For intColumn As Integer = 0 To 6
            For intRow As Integer = 0 To 5

                If arrField(intColumn, intRow) = intPlayer And booEnabled = True Then

                    '' Check for a win in all directions.
                    If Connect4_CheckLine(intColumn, intRow, "N", intPlayer) = True Or _
                       Connect4_CheckLine(intColumn, intRow, "E", intPlayer) = True Or _
                       Connect4_CheckLine(intColumn, intRow, "NW", intPlayer) = True Or _
                       Connect4_CheckLine(intColumn, intRow, "NE", intPlayer) = True Then

                        '' Retrieve the winners name from the GameConfig form,
                        '' and increment their score by 1.
                        Dim strPlayerName As String
                        If intPlayer = 1 Then
                            strPlayerName = GameConfig.tbP1Name.Text
                            intScores(0) += 1
                        Else
                            strPlayerName = GameConfig.tbP2Name.Text
                            intScores(1) += 1
                        End If

                        Connect4_Disable()
                        MsgBox(strPlayerName & " has won!")

                    End If

                End If

            Next
        Next

    End Sub

    Private Function Connect4_CheckLine(ByVal intColumn As Integer, ByVal intRow As Integer, _
                                        ByVal strDirection As String, ByVal intPlayer As Integer)

        Dim intInARow As Integer = 1
        Dim booEnd As Boolean = False
        Dim intCount As Integer = 1

        Dim intY As Integer
        Dim intX As Integer

        While booEnd = False

            Select Case strDirection
                Case "N"

                    If intRow > 2 Then '' Useless looping otherwise.
                        Exit While
                    End If

                    intX = intColumn + 0
                    intY = intRow + intCount
                Case "E"

                    If intColumn > 3 Then '' Useless looping otherwise.
                        Exit While
                    End If

                    intX = intColumn + intCount
                    intY = intRow + 0
                Case "NW"

                    If intRow > 2 Or intColumn < 3 Then '' Useless looping otherwise.
                        Exit While
                    End If

                    intX = intColumn - intCount
                    intY = intRow + intCount
                Case "NE"

                    If intRow > 2 Or intColumn > 3 Then '' Useless looping otherwise.
                        Exit While
                    End If

                    intX = intColumn + intCount
                    intY = intRow + intCount
            End Select

            If intX < 0 Or intY < 0 Or intX > 6 Or intY > 5 Then
                Return False
            End If

            If arrField(intX, intY) = intPlayer Then
                intInARow += 1

                If intInARow > 3 Then
                    Return True
                End If

            Else
                Return False
            End If

            intCount += 1
        End While

        Return False
    End Function

    Private Sub appendLastMove(ByVal strPlayer As String, ByVal intColumn As Integer)

        Select Case strPlayer
            Case "Player"
                listPlayerMoves.Add(intColumn)
            Case "Computer"
                listComputerMoves.Add(intColumn)
            Case Else
                MsgBox("Something went wrong, you made a typo in your code.")
        End Select

    End Sub

    Private Sub Connect4_ButtonsEnabled(ByVal booToggle As Boolean)
        btnPlayA.Visible = booToggle
        btnPlayB.Visible = booToggle
        btnPlayC.Visible = booToggle
        btnPlayD.Visible = booToggle
        btnPlayE.Visible = booToggle
        btnPlayF.Visible = booToggle
        btnPlayG.Visible = booToggle
    End Sub

    Private Sub btnPlayA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlayA.Click
        Connect4_Play(0)
    End Sub

    Private Sub btnPlayB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlayB.Click
        Connect4_Play(1)
    End Sub

    Private Sub btnPlayC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlayC.Click
        Connect4_Play(2)
    End Sub

    Private Sub btnPlayD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlayD.Click
        Connect4_Play(3)
    End Sub

    Private Sub btnPlayE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlayE.Click
        Connect4_Play(4)
    End Sub

    Private Sub btnPlayF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlayF.Click
        Connect4_Play(5)
    End Sub

    Private Sub btnPlayG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlayG.Click
        Connect4_Play(6)
    End Sub

    Private Sub GamePlay_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        ColourButtons()
        lblScoreP1.Text = intScores(0)
        lblScoreP2.Text = intScores(1)

        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(0, 0, 0)), _
                                 pbA6.Location.X - 6, pbA6.Location.Y - 6, 56 * 7 + 6, 56 * 6 + 6)

        '' Redraw the field
        For intColumn As Integer = 0 To 6
            For intRow As Integer = 0 To 5

                Dim brush As Brush = Brushes.White

                '' Set the colour for each piece on the field.
                Select Case arrField(intColumn, intRow)
                    Case 1
                        brush = New SolidBrush(Color.FromArgb(200, 50, 200)) ''Purple
                    Case 2
                        brush = New SolidBrush(Color.FromArgb(240, 200, 0)) ''Orange
                End Select

                '' Find the top-left corner of the circle to draw
                Dim corner As Point
                corner.X = pbA6.Location.X + 56 * intColumn
                corner.Y = pbA6.Location.Y + 56 * (5 - intRow)

                '' Draw the circle
                Dim g As Graphics = Me.CreateGraphics()
                g.FillEllipse(brush, corner.X, corner.Y, 50, 50)

                '' Highlight the last move with a circle.
                If Not arrField(intColumn, intRow) = Nothing Then
                    If intRow = 5 Then

                        Highlight(intColumn, intRow, corner)

                    ElseIf arrField(intColumn, intRow + 1) = Nothing Then

                        Highlight(intColumn, intRow, corner)

                    End If
                End If

                g.Dispose()

            Next
        Next

    End Sub

    Private Sub Highlight(ByVal intColumn As Integer, ByVal intRow As Integer, ByVal corner As Point)

        '' Do not try to highlight if no moves have occurred.
        If listPlayerMoves.Count = 0 And listComputerMoves.Count = 0 Then
            Exit Sub
        End If

        Dim g As Graphics = Me.CreateGraphics()
        Dim pen As New Pen(Brushes.Green)
        pen.Width = 3.0F

        '' Determine which list to get the last move from, and draw the highlighting circle.
        If booAgainstComputer = True Then

            If Not intCurrentPlayer = intMainPlayer Then
                If intColumn = listPlayerMoves.Last Then
                    g.DrawEllipse(pen, corner.X, corner.Y, 50, 50)
                End If
            Else
                If intColumn = listComputerMoves.Last Then
                    g.DrawEllipse(pen, corner.X, corner.Y, 50, 50)
                End If
            End If

        ElseIf intColumn = listPlayerMoves.Last Then
            g.DrawEllipse(pen, corner.X, corner.Y, 50, 50)
        End If

        g.Dispose()

    End Sub

    Private Sub btnReplay_Click(sender As System.Object, e As System.EventArgs) Handles btnReplay.Click

        '' Swap the first player around.
        If GameConfig.rbPlayer1.Checked Then
            GameConfig.rbPlayer2.Checked = True
        Else
            GameConfig.rbPlayer1.Checked = True
        End If

        '' Swap the scores around, too.
        Dim intTemp As Integer = intScores(0)
        intScores(0) = intScores(1)
        intScores(1) = intTemp

        Connect4_Enable()
    End Sub

    Private Sub ColourButtons()

        Dim BackColor, MouseOverBackColor As New Color

        '' Determine the colour of the buttons.
        If intCurrentPlayer = 1 Then
            BackColor = Color.FromArgb(150, 0, 150)
            MouseOverBackColor = Color.Magenta
        Else
            BackColor = Color.Goldenrod
            MouseOverBackColor = Color.FromArgb(230, 220, 0)
        End If

        ''Error Trapping 2
        Try
            btnPlayA.BackColor = BackColor
            btnPlayB.BackColor = BackColor
            btnPlayC.BackColor = BackColor
            btnPlayD.BackColor = BackColor
            btnPlayE.BackColor = BackColor
            btnPlayF.BackColor = BackColor
            btnPlayG.BackColor = BackColor

            btnPlayA.FlatAppearance.BorderColor = BackColor
            btnPlayB.FlatAppearance.BorderColor = BackColor
            btnPlayC.FlatAppearance.BorderColor = BackColor
            btnPlayD.FlatAppearance.BorderColor = BackColor
            btnPlayE.FlatAppearance.BorderColor = BackColor
            btnPlayF.FlatAppearance.BorderColor = BackColor
            btnPlayG.FlatAppearance.BorderColor = BackColor

            btnPlayA.FlatAppearance.MouseOverBackColor = MouseOverBackColor
            btnPlayB.FlatAppearance.MouseOverBackColor = MouseOverBackColor
            btnPlayC.FlatAppearance.MouseOverBackColor = MouseOverBackColor
            btnPlayD.FlatAppearance.MouseOverBackColor = MouseOverBackColor
            btnPlayE.FlatAppearance.MouseOverBackColor = MouseOverBackColor
            btnPlayF.FlatAppearance.MouseOverBackColor = MouseOverBackColor
            btnPlayG.FlatAppearance.MouseOverBackColor = MouseOverBackColor
        Catch
        End Try

    End Sub

    Public Sub GamePlay_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Dim key As String = e.KeyData.ToString

        Try
            Select Case key
                Case "A"
                    Connect4_Play(0)
                Case "B"
                    Connect4_Play(1)
                Case "C"
                    Connect4_Play(2)
                Case "D"
                    Connect4_Play(3)
                Case "E"
                    Connect4_Play(4)
                Case "F"
                    Connect4_Play(5)
                Case "G"
                    Connect4_Play(6)
            End Select
        Catch
        End Try

    End Sub

End Class