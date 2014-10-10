<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameConfig
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tbP1Name = New System.Windows.Forms.TextBox()
        Me.lblP1Name = New System.Windows.Forms.Label()
        Me.lblP2Name = New System.Windows.Forms.Label()
        Me.lblGameType = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnStartGame = New System.Windows.Forms.Button()
        Me.lblConfig = New System.Windows.Forms.Label()
        Me.tbP2Name = New System.Windows.Forms.TextBox()
        Me.cbGameType = New System.Windows.Forms.ComboBox()
        Me.rbPlayer1 = New System.Windows.Forms.RadioButton()
        Me.rbPlayer2 = New System.Windows.Forms.RadioButton()
        Me.lblPlayAs = New System.Windows.Forms.Label()
        Me.lblDifficulty = New System.Windows.Forms.Label()
        Me.cbDifficulty = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'tbP1Name
        '
        Me.tbP1Name.Location = New System.Drawing.Point(20, 255)
        Me.tbP1Name.Name = "tbP1Name"
        Me.tbP1Name.Size = New System.Drawing.Size(120, 20)
        Me.tbP1Name.TabIndex = 20
        Me.tbP1Name.Text = "Player 1"
        '
        'lblP1Name
        '
        Me.lblP1Name.AutoSize = True
        Me.lblP1Name.Font = New System.Drawing.Font("Script MT Bold", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblP1Name.Location = New System.Drawing.Point(20, 229)
        Me.lblP1Name.Name = "lblP1Name"
        Me.lblP1Name.Size = New System.Drawing.Size(89, 23)
        Me.lblP1Name.TabIndex = 17
        Me.lblP1Name.Text = "P1 Name:"
        '
        'lblP2Name
        '
        Me.lblP2Name.AutoSize = True
        Me.lblP2Name.Font = New System.Drawing.Font("Script MT Bold", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblP2Name.Location = New System.Drawing.Point(245, 229)
        Me.lblP2Name.Name = "lblP2Name"
        Me.lblP2Name.Size = New System.Drawing.Size(91, 23)
        Me.lblP2Name.TabIndex = 16
        Me.lblP2Name.Text = "P2 Name:"
        '
        'lblGameType
        '
        Me.lblGameType.AutoSize = True
        Me.lblGameType.Font = New System.Drawing.Font("Script MT Bold", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGameType.Location = New System.Drawing.Point(71, 80)
        Me.lblGameType.Name = "lblGameType"
        Me.lblGameType.Size = New System.Drawing.Size(104, 23)
        Me.lblGameType.TabIndex = 15
        Me.lblGameType.Text = "Game Type:"
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Magenta
        Me.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Magenta
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Consolas", 14.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(44, 303)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(120, 50)
        Me.btnBack.TabIndex = 14
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnStartGame
        '
        Me.btnStartGame.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnStartGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnStartGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Magenta
        Me.btnStartGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Magenta
        Me.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartGame.Font = New System.Drawing.Font("Consolas", 14.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartGame.Location = New System.Drawing.Point(221, 303)
        Me.btnStartGame.Name = "btnStartGame"
        Me.btnStartGame.Size = New System.Drawing.Size(120, 50)
        Me.btnStartGame.TabIndex = 13
        Me.btnStartGame.Text = "Start Game"
        Me.btnStartGame.UseVisualStyleBackColor = False
        '
        'lblConfig
        '
        Me.lblConfig.AutoSize = True
        Me.lblConfig.Font = New System.Drawing.Font("Consolas", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfig.Location = New System.Drawing.Point(70, 20)
        Me.lblConfig.Name = "lblConfig"
        Me.lblConfig.Size = New System.Drawing.Size(246, 28)
        Me.lblConfig.TabIndex = 12
        Me.lblConfig.Text = "Game Configuration"
        '
        'tbP2Name
        '
        Me.tbP2Name.Location = New System.Drawing.Point(245, 255)
        Me.tbP2Name.Name = "tbP2Name"
        Me.tbP2Name.Size = New System.Drawing.Size(120, 20)
        Me.tbP2Name.TabIndex = 21
        Me.tbP2Name.Text = "Player 2"
        '
        'cbGameType
        '
        Me.cbGameType.FormattingEnabled = True
        Me.cbGameType.Items.AddRange(New Object() {"Verse Computer", "Verse Human"})
        Me.cbGameType.Location = New System.Drawing.Point(196, 80)
        Me.cbGameType.MaxDropDownItems = 4
        Me.cbGameType.Name = "cbGameType"
        Me.cbGameType.Size = New System.Drawing.Size(120, 21)
        Me.cbGameType.TabIndex = 11
        '
        'rbPlayer1
        '
        Me.rbPlayer1.AutoSize = True
        Me.rbPlayer1.Checked = True
        Me.rbPlayer1.Location = New System.Drawing.Point(221, 159)
        Me.rbPlayer1.Name = "rbPlayer1"
        Me.rbPlayer1.Size = New System.Drawing.Size(63, 17)
        Me.rbPlayer1.TabIndex = 22
        Me.rbPlayer1.TabStop = True
        Me.rbPlayer1.Text = "Player 1"
        Me.rbPlayer1.UseVisualStyleBackColor = True
        '
        'rbPlayer2
        '
        Me.rbPlayer2.AutoSize = True
        Me.rbPlayer2.Location = New System.Drawing.Point(221, 182)
        Me.rbPlayer2.Name = "rbPlayer2"
        Me.rbPlayer2.Size = New System.Drawing.Size(63, 17)
        Me.rbPlayer2.TabIndex = 23
        Me.rbPlayer2.Text = "Player 2"
        Me.rbPlayer2.UseVisualStyleBackColor = True
        '
        'lblPlayAs
        '
        Me.lblPlayAs.AutoSize = True
        Me.lblPlayAs.Font = New System.Drawing.Font("Script MT Bold", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayAs.Location = New System.Drawing.Point(87, 169)
        Me.lblPlayAs.Name = "lblPlayAs"
        Me.lblPlayAs.Size = New System.Drawing.Size(77, 23)
        Me.lblPlayAs.TabIndex = 24
        Me.lblPlayAs.Text = "Play as:"
        '
        'lblDifficulty
        '
        Me.lblDifficulty.AutoSize = True
        Me.lblDifficulty.Font = New System.Drawing.Font("Script MT Bold", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDifficulty.Location = New System.Drawing.Point(71, 115)
        Me.lblDifficulty.Name = "lblDifficulty"
        Me.lblDifficulty.Size = New System.Drawing.Size(93, 23)
        Me.lblDifficulty.TabIndex = 26
        Me.lblDifficulty.Text = "Difficulty:"
        '
        'cbDifficulty
        '
        Me.cbDifficulty.FormattingEnabled = True
        Me.cbDifficulty.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cbDifficulty.Location = New System.Drawing.Point(196, 115)
        Me.cbDifficulty.MaxDropDownItems = 4
        Me.cbDifficulty.Name = "cbDifficulty"
        Me.cbDifficulty.Size = New System.Drawing.Size(120, 21)
        Me.cbDifficulty.TabIndex = 25
        '
        'GameConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(384, 362)
        Me.Controls.Add(Me.lblDifficulty)
        Me.Controls.Add(Me.cbDifficulty)
        Me.Controls.Add(Me.lblPlayAs)
        Me.Controls.Add(Me.rbPlayer2)
        Me.Controls.Add(Me.rbPlayer1)
        Me.Controls.Add(Me.tbP1Name)
        Me.Controls.Add(Me.tbP2Name)
        Me.Controls.Add(Me.lblP1Name)
        Me.Controls.Add(Me.lblP2Name)
        Me.Controls.Add(Me.lblGameType)
        Me.Controls.Add(Me.cbGameType)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnStartGame)
        Me.Controls.Add(Me.lblConfig)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GameConfig"
        Me.Text = "GameConfig"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbP1Name As System.Windows.Forms.TextBox
    Friend WithEvents lblP1Name As System.Windows.Forms.Label
    Friend WithEvents lblP2Name As System.Windows.Forms.Label
    Friend WithEvents lblGameType As System.Windows.Forms.Label
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnStartGame As System.Windows.Forms.Button
    Friend WithEvents lblConfig As System.Windows.Forms.Label
    Friend WithEvents tbP2Name As System.Windows.Forms.TextBox
    Friend WithEvents cbGameType As System.Windows.Forms.ComboBox
    Friend WithEvents rbPlayer1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbPlayer2 As System.Windows.Forms.RadioButton
    Friend WithEvents lblPlayAs As System.Windows.Forms.Label
    Friend WithEvents lblDifficulty As System.Windows.Forms.Label
    Friend WithEvents cbDifficulty As System.Windows.Forms.ComboBox
End Class
