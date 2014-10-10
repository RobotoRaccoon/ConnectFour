Public Class GameInstructions

    Private Sub GameInstructions_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated

        '' Always position the form in the middle of the screen.
        Dim location As New Point

        location.X = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        location.Y = (My.Computer.Screen.Bounds.Height - Me.Height) / 2

        Me.SetDesktopLocation(location.X, location.Y)

    End Sub

    Private Sub GameInstructions_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Logon.Close()
    End Sub

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Me.Hide()
        GameMenu.Show()
    End Sub

    Private Sub btnLeft_Click(sender As System.Object, e As System.EventArgs) Handles btnLeft.Click

        Dim currentPage As Integer = PageWindow.SelectedIndex
        If Not currentPage = 0 Then
            PageWindow.SelectedIndex = currentPage - 1
        End If

    End Sub

    Private Sub btnRight_Click(sender As System.Object, e As System.EventArgs) Handles btnRight.Click

        Dim currentPage As Integer = PageWindow.SelectedIndex
        If Not currentPage > PageWindow.TabCount Then
            PageWindow.SelectedIndex = currentPage + 1
        End If

    End Sub

End Class