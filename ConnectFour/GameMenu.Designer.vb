<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameMenu
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
        Me.lblConnectFour = New System.Windows.Forms.Label()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.btnNewGame = New System.Windows.Forms.Button()
        Me.btnHowToPlay = New System.Windows.Forms.Button()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblConnectFour
        '
        Me.lblConnectFour.AutoSize = True
        Me.lblConnectFour.Font = New System.Drawing.Font("Consolas", 28.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConnectFour.Location = New System.Drawing.Point(90, 50)
        Me.lblConnectFour.Name = "lblConnectFour"
        Me.lblConnectFour.Size = New System.Drawing.Size(272, 45)
        Me.lblConnectFour.TabIndex = 5
        Me.lblConnectFour.Text = "Connect Four"
        '
        'btnQuit
        '
        Me.btnQuit.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnQuit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Magenta
        Me.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuit.Font = New System.Drawing.Font("Consolas", 14.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuit.Location = New System.Drawing.Point(157, 240)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(130, 50)
        Me.btnQuit.TabIndex = 4
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = False
        '
        'btnNewGame
        '
        Me.btnNewGame.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnNewGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnNewGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Magenta
        Me.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewGame.Font = New System.Drawing.Font("Consolas", 14.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewGame.Location = New System.Drawing.Point(157, 128)
        Me.btnNewGame.Name = "btnNewGame"
        Me.btnNewGame.Size = New System.Drawing.Size(130, 50)
        Me.btnNewGame.TabIndex = 3
        Me.btnNewGame.Text = "New Game"
        Me.btnNewGame.UseVisualStyleBackColor = False
        '
        'btnHowToPlay
        '
        Me.btnHowToPlay.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnHowToPlay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnHowToPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Magenta
        Me.btnHowToPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHowToPlay.Font = New System.Drawing.Font("Consolas", 14.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHowToPlay.Location = New System.Drawing.Point(157, 184)
        Me.btnHowToPlay.Name = "btnHowToPlay"
        Me.btnHowToPlay.Size = New System.Drawing.Size(130, 50)
        Me.btnHowToPlay.TabIndex = 6
        Me.btnHowToPlay.Text = "How To Play"
        Me.btnHowToPlay.UseVisualStyleBackColor = False
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.CausesValidation = False
        Me.lblUsername.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.lblUsername.Location = New System.Drawing.Point(12, 9)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(127, 13)
        Me.lblUsername.TabIndex = 68
        Me.lblUsername.Text = "Welcome, <username>!"
        '
        'GameMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(454, 312)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.btnHowToPlay)
        Me.Controls.Add(Me.lblConnectFour)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnNewGame)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GameMenu"
        Me.Text = "Connect Four"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblConnectFour As System.Windows.Forms.Label
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents btnNewGame As System.Windows.Forms.Button
    Friend WithEvents btnHowToPlay As System.Windows.Forms.Button
    Friend WithEvents lblUsername As System.Windows.Forms.Label

End Class
