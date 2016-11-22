<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.okBT = New System.Windows.Forms.Button()
        Me.scanBT = New System.Windows.Forms.Button()
        Me.chooseBT = New System.Windows.Forms.Button()
        Me.scannedPB = New System.Windows.Forms.PictureBox()
        CType(Me.scannedPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'okBT
        '
        Me.okBT.Location = New System.Drawing.Point(74, 262)
        Me.okBT.Name = "okBT"
        Me.okBT.Size = New System.Drawing.Size(158, 23)
        Me.okBT.TabIndex = 7
        Me.okBT.Text = "Ok"
        Me.okBT.UseVisualStyleBackColor = True
        '
        'scanBT
        '
        Me.scanBT.Location = New System.Drawing.Point(74, 182)
        Me.scanBT.Name = "scanBT"
        Me.scanBT.Size = New System.Drawing.Size(158, 23)
        Me.scanBT.TabIndex = 6
        Me.scanBT.Text = "Scan"
        Me.scanBT.UseVisualStyleBackColor = True
        '
        'chooseBT
        '
        Me.chooseBT.Location = New System.Drawing.Point(74, 102)
        Me.chooseBT.Name = "chooseBT"
        Me.chooseBT.Size = New System.Drawing.Size(158, 23)
        Me.chooseBT.TabIndex = 5
        Me.chooseBT.Text = "اختيار"
        Me.chooseBT.UseVisualStyleBackColor = True
        '
        'scannedPB
        '
        Me.scannedPB.Location = New System.Drawing.Point(265, 33)
        Me.scannedPB.Name = "scannedPB"
        Me.scannedPB.Size = New System.Drawing.Size(273, 376)
        Me.scannedPB.TabIndex = 4
        Me.scannedPB.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 446)
        Me.Controls.Add(Me.okBT)
        Me.Controls.Add(Me.scanBT)
        Me.Controls.Add(Me.chooseBT)
        Me.Controls.Add(Me.scannedPB)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.scannedPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents okBT As System.Windows.Forms.Button
    Friend WithEvents scanBT As System.Windows.Forms.Button
    Friend WithEvents chooseBT As System.Windows.Forms.Button
    Friend WithEvents scannedPB As System.Windows.Forms.PictureBox
End Class
