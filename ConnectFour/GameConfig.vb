Public Class GameConfig

    Private Sub GameConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbGameType.SelectedIndex = 0
        cbDifficulty.SelectedIndex = 9
    End Sub

    Private Sub GameConfig_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        '' Always position the form in the middle of the screen.
        Dim location As New Point

        location.X = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        location.Y = (My.Computer.Screen.Bounds.Height - Me.Height) / 2

        Me.SetDesktopLocation(location.X, location.Y)

    End Sub

    Private Sub GameConfig_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Logon.Close()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        GameMenu.Show()
        Me.Hide()
    End Sub

    Private Sub btnStartGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartGame.Click

        '' Disallow a player to start a game without choosing a name.
        If tbP1Name.Text = "Player 1" Or tbP1Name.Text = "Player 2" Or _
            tbP2Name.Text = "Player 1" Or tbP2Name.Text = "Player 2" Then

            MsgBox("You must pick a name!")
            Exit Sub

        Else

            GamePlay.Show()
            Me.Hide()
            GamePlay.Connect4_Enable()

            '' Reset the scores if any are there.
            GamePlay.intScores = {0, 0}

        End If

    End Sub

    Private Sub cbGameType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbGameType.SelectedIndexChanged
        GreyPlayerName()
    End Sub

    Private Sub rbPlayer1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPlayer1.CheckedChanged
        GreyPlayerName()

        '' Swap the usernames when two people are playing.
        ''(This is used only when hitting the 'Again' button in the Next form)
        If cbGameType.SelectedIndex = 1 Then
            Dim strTemp As String = tbP1Name.Text
            tbP1Name.Text = tbP2Name.Text
            tbP2Name.Text = strTemp
        End If

    End Sub

    Private Sub GreyPlayerName()

        If rbPlayer1.Checked = True Then
            GreyComputerName()
            tbP1Name.ReadOnly = True
        Else
            GreyComputerName()
            tbP2Name.ReadOnly = True
        End If

    End Sub

    Private Sub GreyComputerName()

        tbP1Name.ReadOnly = False
        tbP2Name.ReadOnly = False

        '' Check for vs Computer
        If cbGameType.SelectedIndex = 0 Then

            If rbPlayer1.Checked Then
                '' If you are player 1
                tbP1Name.Text = GameMenu.strUsername
                tbP2Name.Text = "Computer"
                tbP2Name.ReadOnly = True

            Else
                '' If you are player 2
                tbP1Name.Text = "Computer"
                tbP1Name.ReadOnly = True
                tbP2Name.Text = GameMenu.strUsername

            End If

            cbDifficulty.Enabled = True

        Else
            '' When versing a human

            If tbP1Name.Text = "Computer" Then
                tbP1Name.Text = "Player 1"
            ElseIf tbP2Name.Text = "Computer" Then
                tbP2Name.Text = "Player 2"
            End If

            cbDifficulty.Enabled = False

        End If

    End Sub

End Class