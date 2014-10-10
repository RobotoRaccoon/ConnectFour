Public Class Logon

    '' Array of strings for usernames and password (Added to during form load)
    Public listAccountInfo As New List(Of String)

    Private Sub Logon_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated

        '' Always position the form in the middle of the screen.
        Dim location As New Point

        location.X = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        location.Y = (My.Computer.Screen.Bounds.Height - Me.Height) / 2

        Me.SetDesktopLocation(location.X, location.Y)

    End Sub

    Private Sub btnRegister_Click(sender As System.Object, e As System.EventArgs) Handles btnRegister.Click

        '' Ask for a username if not supplied to go into the Registration form.
        If tbUsername.Text = "" Then
            tbUsername.Text = InputBox("Enter a username", "Username input")
        End If

        Registration.Show()
        Me.Hide()
    End Sub

    Private Sub btnLogon_Click(sender As System.Object, e As System.EventArgs) Handles btnLogon.Click

        Dim strUsername As String = tbUsername.Text
        Dim strPass As String = tbPassword.Text
        Dim booMatchFound As Boolean = False

        '' Require a username input
        '' Binary Selection
        If strUsername = "" Then
            MsgBox("Please supply a username")
            Exit Sub
        End If

        '' Manual access
        If strUsername = "root" And strPass = "password" Then
            GameMenu.strUsername = strUsername
            GameMenu.Show()
            Me.Hide()
            Exit Sub
        End If

        '' Disallow semi-colons in the username as they are used to in logonDetails.txt
        If strUsername.Contains(";") Then
            MsgBox("You may not use semi-colons in your username")
            Exit Sub
        End If

        For Each strCurrentRow In listAccountInfo

            '' A case insensitive check to see if the usernames match.
            '' Using the Extract string function.
            Dim intDelimiterLocation = strCurrentRow.IndexOf(";")
            Dim strStoredUsername = Utilities.Extract(0, intDelimiterLocation - 1, strCurrentRow)
            If strStoredUsername.ToLower = strUsername.ToLower Then

                booMatchFound = True

                If Split(strCurrentRow, ";", 2)(1) = strPass Then
                    GameMenu.strUsername = strUsername
                    GameMenu.Show()
                    Me.Hide()
                    Exit Sub
                Else
                    MsgBox("Password incorrect.")
                End If

            End If

        Next

        '' If the user does not have an account on the system
        If booMatchFound = False Then
            MsgBox("This account has not been detected on the system. Redirecting you to a registration form.")
            Registration.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub Logon_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        '' Extract all user information out of the file and store it
        '' in an array for easy access when the program first loads.
        ''
        '' Sequential text file, used below.
        Dim strCurrentRow As String
        Dim fileStringReader As New System.IO.StringReader(My.Resources.logonDetails)

        '' www.msdn.microsoft.com/en-us/library/microsoft.visualbasic.fileio.textfieldparser.aspx
        '' Code sourced from link above and modified to suit the current situation.
        Using MyReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser(fileStringReader)

            '' Removes anything that is not a line of text.
            MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            MyReader.Delimiters = New String() {vbTab}

            '' Pre-test loop to the end of the file.
            While Not MyReader.EndOfData
                strCurrentRow = MyReader.ReadLine
                listAccountInfo.Add(strCurrentRow)
            End While

        End Using

    End Sub

    Private Sub tbPassword_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbPassword.KeyPress

        '' If keypress is an enter key
        If e.KeyChar.GetHashCode = 851981 Then
            '' Call Logon script
            btnLogon_Click(sender, e)
        End If

    End Sub
End Class