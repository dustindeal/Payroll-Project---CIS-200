<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDeal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.lstEmployee = New System.Windows.Forms.ListBox()
        Me.lstEmployer = New System.Windows.Forms.ListBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnEnter
        '
        Me.btnEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnter.Location = New System.Drawing.Point(710, 21)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(462, 61)
        Me.btnEnter.TabIndex = 0
        Me.btnEnter.Text = "Enter Employee Data"
        Me.btnEnter.UseVisualStyleBackColor = True
        '
        'lstEmployee
        '
        Me.lstEmployee.Font = New System.Drawing.Font("Courier New", 10.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstEmployee.FormattingEnabled = True
        Me.lstEmployee.HorizontalScrollbar = True
        Me.lstEmployee.ItemHeight = 30
        Me.lstEmployee.Location = New System.Drawing.Point(12, 98)
        Me.lstEmployee.Name = "lstEmployee"
        Me.lstEmployee.Size = New System.Drawing.Size(1820, 424)
        Me.lstEmployee.TabIndex = 1
        '
        'lstEmployer
        '
        Me.lstEmployer.Font = New System.Drawing.Font("Courier New", 10.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstEmployer.FormattingEnabled = True
        Me.lstEmployer.HorizontalScrollbar = True
        Me.lstEmployer.ItemHeight = 30
        Me.lstEmployer.Location = New System.Drawing.Point(12, 528)
        Me.lstEmployer.Name = "lstEmployer"
        Me.lstEmployer.Size = New System.Drawing.Size(1820, 394)
        Me.lstEmployer.TabIndex = 2
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(886, 941)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(112, 48)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "&EXIT"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'FrmDeal
        '
        Me.AcceptButton = Me.btnEnter
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1878, 1001)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lstEmployer)
        Me.Controls.Add(Me.lstEmployee)
        Me.Controls.Add(Me.btnEnter)
        Me.Name = "FrmDeal"
        Me.Text = "Dustin Deal - CIS200 Payroll Expense Calculator"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnEnter As Button
    Friend WithEvents lstEmployee As ListBox
    Friend WithEvents lstEmployer As ListBox
    Friend WithEvents btnExit As Button
End Class
