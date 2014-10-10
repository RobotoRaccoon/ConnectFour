Public Class GameMenu

    Public strUsername As String

    Private Sub GameMenu_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Logon.Close()
    End Sub

    Private Sub GameMenu_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        '' Always position the form in the middle of the screen.
        Dim location As New Point

        location.X = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        location.Y = (My.Computer.Screen.Bounds.Height - Me.Height) / 2

        Me.SetDesktopLocation(location.X, location.Y)
        lblUsername.Text = "Welcome, " + strUsername + "!"

    End Sub

    Private Sub btnNewGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewGame.Click
        GameConfig.Show()
        Me.Hide()
    End Sub

    Private Sub btnHowToPlay_Click(sender As System.Object, e As System.EventArgs) Handles btnHowToPlay.Click
        GameInstructions.Show()
        Me.Hide()
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Logon.Close()
    End Sub

End Class
