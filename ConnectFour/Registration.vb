Public Class Registration

    ''''''
    ''
    ''  Yes I know this is all storing in plaintext, but security was completely irrelevant to this project for many reasons.
    ''  I do not plan on working on this project any more, and quite frankly will be surprised if anyone reads this.
    ''
    ''''''

    Private Sub Registration_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated

        '' Always position the form in the middle of the screen.
        Dim location As New Point

        location.X = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        location.Y = (My.Computer.Screen.Bounds.Height - Me.Height) / 2

        Me.SetDesktopLocation(location.X, location.Y)

        ''Import the username from the logon screen that the user will be creating a username for.
        tbUsername.Text = Logon.tbUsername.Text
        tbPassword.Text = Logon.tbPassword.Text

    End Sub

    Private Sub Registration_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Logon.Close()
    End Sub

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Logon.Show()
        Me.Hide()
    End Sub

    Private Sub btnRegister_Click(sender As System.Object, e As System.EventArgs) Handles btnRegister.Click

        Dim strPass As String = tbPassword.Text
        Dim strPassConfirm As String = tbConfirmPassword.Text

        '' Force the user to set a password longer than 4 characters.
        If strPass.Length <= 4 Then
            MsgBox("Your password must be longer than 4 characters.")
            Exit Sub
        End If

        '' Deny registration if the two passwords do not match each other.
        If Not strPass = strPassConfirm Then
            MsgBox("Your passwords do not match!")
            Exit Sub
        End If

        '' Append the username and password to logonDetails.txt
        Try
            Dim strPath As String = IO.Path.GetFullPath(My.Resources.ResourceManager.BaseName)
            strPath = Split(strPath, "bin")(0) + "Resources\logonDetails.txt"
            Dim StringWriter As New System.IO.StreamWriter(strPath, True)
            StringWriter.WriteLine(Logon.tbUsername.Text & ";" & strPass)
            StringWriter.Dispose()
            StringWriter.Close()
        Catch
            MsgBox("An error occurred when trying to create the account. Please try again.")
            Exit Sub
        End Try

        MsgBox("Account created. Logging you on now...")
        GameMenu.strUsername = Logon.tbUsername.Text
        GameMenu.Show()
        Me.Hide()

    End Sub
End Class