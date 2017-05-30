<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HONORARIOS_TRANS
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.GCAB00 = New System.Windows.Forms.GroupBox
        Me.cboOrden = New System.Windows.Forms.ComboBox
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Panel8.SuspendLayout()
        Me.GCAB00.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.btnSalir)
        Me.Panel8.Controls.Add(Me.btnGrabar)
        Me.Panel8.Location = New System.Drawing.Point(9, 71)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(264, 45)
        Me.Panel8.TabIndex = 6
        Me.Panel8.TabStop = True
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.Location = New System.Drawing.Point(174, 9)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(77, 25)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrabar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrabar.Location = New System.Drawing.Point(92, 9)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(78, 25)
        Me.btnGrabar.TabIndex = 0
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'GCAB00
        '
        Me.GCAB00.Controls.Add(Me.cboOrden)
        Me.GCAB00.Controls.Add(Me.Label50)
        Me.GCAB00.Controls.Add(Me.Label52)
        Me.GCAB00.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GCAB00.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GCAB00.Location = New System.Drawing.Point(9, 9)
        Me.GCAB00.Margin = New System.Windows.Forms.Padding(0)
        Me.GCAB00.Name = "GCAB00"
        Me.GCAB00.Padding = New System.Windows.Forms.Padding(0)
        Me.GCAB00.Size = New System.Drawing.Size(264, 56)
        Me.GCAB00.TabIndex = 5
        Me.GCAB00.TabStop = False
        Me.GCAB00.Text = "Honorarios"
        '
        'cboOrden
        '
        Me.cboOrden.BackColor = System.Drawing.Color.White
        Me.cboOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrden.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOrden.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboOrden.FormattingEnabled = True
        Me.cboOrden.Location = New System.Drawing.Point(59, 22)
        Me.cboOrden.MaxDropDownItems = 9
        Me.cboOrden.Name = "cboOrden"
        Me.cboOrden.Size = New System.Drawing.Size(171, 22)
        Me.cboOrden.TabIndex = 0
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(13, 30)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(40, 14)
        Me.Label50.TabIndex = 22
        Me.Label50.Text = "Orden:"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(10, 62)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(0, 14)
        Me.Label52.TabIndex = 0
        '
        'HONORARIOS_TRANS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(285, 132)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.GCAB00)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HONORARIOS_TRANS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transferencia de Honorarios"
        Me.Panel8.ResumeLayout(False)
        Me.GCAB00.ResumeLayout(False)
        Me.GCAB00.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents GCAB00 As System.Windows.Forms.GroupBox
    Friend WithEvents cboOrden As System.Windows.Forms.ComboBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
End Class
