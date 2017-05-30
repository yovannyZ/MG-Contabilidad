<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetraccion
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
        Me.lblValorDetraccion = New System.Windows.Forms.Label
        Me.txtValorDetraccion = New System.Windows.Forms.TextBox
        Me.txtTasaDetraccion = New System.Windows.Forms.TextBox
        Me.lblPorDetraccion = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.txtNumeroDetraccion = New System.Windows.Forms.TextBox
        Me.lblNumeroDetraccion = New System.Windows.Forms.Label
        Me.txtPorcentajeDetraccion = New System.Windows.Forms.TextBox
        Me.lblPorcentajeDetraccion = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblValorDetraccion
        '
        Me.lblValorDetraccion.AutoSize = True
        Me.lblValorDetraccion.Location = New System.Drawing.Point(35, 35)
        Me.lblValorDetraccion.Name = "lblValorDetraccion"
        Me.lblValorDetraccion.Size = New System.Drawing.Size(86, 13)
        Me.lblValorDetraccion.TabIndex = 1
        Me.lblValorDetraccion.Text = "Valor Detracción"
        '
        'txtValorDetraccion
        '
        Me.txtValorDetraccion.Location = New System.Drawing.Point(133, 31)
        Me.txtValorDetraccion.Name = "txtValorDetraccion"
        Me.txtValorDetraccion.Size = New System.Drawing.Size(169, 20)
        Me.txtValorDetraccion.TabIndex = 1
        '
        'txtTasaDetraccion
        '
        Me.txtTasaDetraccion.Location = New System.Drawing.Point(133, 80)
        Me.txtTasaDetraccion.MaxLength = 5
        Me.txtTasaDetraccion.Name = "txtTasaDetraccion"
        Me.txtTasaDetraccion.Size = New System.Drawing.Size(79, 20)
        Me.txtTasaDetraccion.TabIndex = 3
        '
        'lblPorDetraccion
        '
        Me.lblPorDetraccion.AutoSize = True
        Me.lblPorDetraccion.Location = New System.Drawing.Point(57, 84)
        Me.lblPorDetraccion.Name = "lblPorDetraccion"
        Me.lblPorDetraccion.Size = New System.Drawing.Size(64, 13)
        Me.lblPorDetraccion.TabIndex = 3
        Me.lblPorDetraccion.Text = "CódigoTasa"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.Location = New System.Drawing.Point(211, 107)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(86, 23)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.Location = New System.Drawing.Point(118, 107)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(87, 23)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtNumeroDetraccion
        '
        Me.txtNumeroDetraccion.Location = New System.Drawing.Point(133, 6)
        Me.txtNumeroDetraccion.Name = "txtNumeroDetraccion"
        Me.txtNumeroDetraccion.Size = New System.Drawing.Size(169, 20)
        Me.txtNumeroDetraccion.TabIndex = 0
        '
        'lblNumeroDetraccion
        '
        Me.lblNumeroDetraccion.AutoSize = True
        Me.lblNumeroDetraccion.Location = New System.Drawing.Point(22, 10)
        Me.lblNumeroDetraccion.Name = "lblNumeroDetraccion"
        Me.lblNumeroDetraccion.Size = New System.Drawing.Size(99, 13)
        Me.lblNumeroDetraccion.TabIndex = 0
        Me.lblNumeroDetraccion.Text = "Número Detracción"
        '
        'txtPorcentajeDetraccion
        '
        Me.txtPorcentajeDetraccion.Location = New System.Drawing.Point(133, 56)
        Me.txtPorcentajeDetraccion.MaxLength = 4
        Me.txtPorcentajeDetraccion.Name = "txtPorcentajeDetraccion"
        Me.txtPorcentajeDetraccion.Size = New System.Drawing.Size(65, 20)
        Me.txtPorcentajeDetraccion.TabIndex = 2
        '
        'lblPorcentajeDetraccion
        '
        Me.lblPorcentajeDetraccion.AutoSize = True
        Me.lblPorcentajeDetraccion.Location = New System.Drawing.Point(83, 60)
        Me.lblPorcentajeDetraccion.Name = "lblPorcentajeDetraccion"
        Me.lblPorcentajeDetraccion.Size = New System.Drawing.Size(38, 13)
        Me.lblPorcentajeDetraccion.TabIndex = 2
        Me.lblPorcentajeDetraccion.Text = "% Det."
        '
        'frmDetraccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 143)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtPorcentajeDetraccion)
        Me.Controls.Add(Me.lblPorcentajeDetraccion)
        Me.Controls.Add(Me.txtNumeroDetraccion)
        Me.Controls.Add(Me.lblNumeroDetraccion)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtTasaDetraccion)
        Me.Controls.Add(Me.lblPorDetraccion)
        Me.Controls.Add(Me.txtValorDetraccion)
        Me.Controls.Add(Me.lblValorDetraccion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frmDetraccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detracciones"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblValorDetraccion As System.Windows.Forms.Label
    Friend WithEvents txtValorDetraccion As System.Windows.Forms.TextBox
    Friend WithEvents txtTasaDetraccion As System.Windows.Forms.TextBox
    Friend WithEvents lblPorDetraccion As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtNumeroDetraccion As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroDetraccion As System.Windows.Forms.Label
    Friend WithEvents txtPorcentajeDetraccion As System.Windows.Forms.TextBox
    Friend WithEvents lblPorcentajeDetraccion As System.Windows.Forms.Label
End Class
