<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtInput = New TextBox()
        cmbOptions = New ComboBox()
        btnSave = New Button()
        lstData = New ListBox()
        btnDelete = New Button()
        chkActive = New CheckBox()
        Label1 = New Label()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' txtInput
        ' 
        txtInput.Location = New Point(138, 76)
        txtInput.Name = "txtInput"
        txtInput.Size = New Size(160, 27)
        txtInput.TabIndex = 0
        ' 
        ' cmbOptions
        ' 
        cmbOptions.FormattingEnabled = True
        cmbOptions.Location = New Point(138, 129)
        cmbOptions.Name = "cmbOptions"
        cmbOptions.Size = New Size(160, 28)
        cmbOptions.TabIndex = 1
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(353, 109)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(139, 29)
        btnSave.TabIndex = 3
        btnSave.Text = "Save/Add"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' lstData
        ' 
        lstData.FormattingEnabled = True
        lstData.Location = New Point(32, 242)
        lstData.Name = "lstData"
        lstData.Size = New Size(731, 124)
        lstData.TabIndex = 4
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(32, 372)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(179, 29)
        btnDelete.TabIndex = 5
        btnDelete.Text = "Delete Selected"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' chkActive
        ' 
        chkActive.AutoSize = True
        chkActive.Location = New Point(353, 79)
        chkActive.Name = "chkActive"
        chkActive.Size = New Size(72, 24)
        chkActive.TabIndex = 6
        chkActive.Text = "Active"
        chkActive.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(52, 83)
        Label1.Name = "Label1"
        Label1.Size = New Size(76, 20)
        Label1.TabIndex = 7
        Label1.Text = "Full Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(42, 137)
        Label2.Name = "Label2"
        Label2.Size = New Size(86, 20)
        Label2.TabIndex = 8
        Label2.Text = "Assign Role"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(chkActive)
        Controls.Add(btnDelete)
        Controls.Add(lstData)
        Controls.Add(btnSave)
        Controls.Add(cmbOptions)
        Controls.Add(txtInput)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtInput As TextBox
    Friend WithEvents cmbOptions As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents lstData As ListBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label

End Class
