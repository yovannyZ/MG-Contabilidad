<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEstadisticaUN
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkcuenta = New System.Windows.Forms.CheckBox
        Me.cboUnidadNegocio = New System.Windows.Forms.ComboBox
        Me.chkUnidadNegocio = New System.Windows.Forms.CheckBox
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.btn_cancelar1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkcuenta)
        Me.GroupBox1.Controls.Add(Me.cboUnidadNegocio)
        Me.GroupBox1.Controls.Add(Me.chkUnidadNegocio)
        Me.GroupBox1.Controls.Add(Me.cbo_año)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbo_mes)
        Me.GroupBox1.Controls.Add(Me.btn_cancelar1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(453, 129)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'chkcuenta
        '
        Me.chkcuenta.AutoSize = True
        Me.chkcuenta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.chkcuenta.Location = New System.Drawing.Point(141, 103)
        Me.chkcuenta.Name = "chkcuenta"
        Me.chkcuenta.Size = New System.Drawing.Size(85, 18)
        Me.chkcuenta.TabIndex = 108
        Me.chkcuenta.Text = "Por cuenta"
        Me.chkcuenta.UseVisualStyleBackColor = True
        '
        'cboUnidadNegocio
        '
        Me.cboUnidadNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidadNegocio.Enabled = False
        Me.cboUnidadNegocio.FormattingEnabled = True
        Me.cboUnidadNegocio.Location = New System.Drawing.Point(141, 75)
        Me.cboUnidadNegocio.Name = "cboUnidadNegocio"
        Me.cboUnidadNegocio.Size = New System.Drawing.Size(190, 22)
        Me.cboUnidadNegocio.TabIndex = 107
        '
        'chkUnidadNegocio
        '
        Me.chkUnidadNegocio.AutoSize = True
        Me.chkUnidadNegocio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.chkUnidadNegocio.Location = New System.Drawing.Point(25, 77)
        Me.chkUnidadNegocio.Name = "chkUnidadNegocio"
        Me.chkUnidadNegocio.Size = New System.Drawing.Size(110, 18)
        Me.chkUnidadNegocio.TabIndex = 106
        Me.chkUnidadNegocio.Text = "Unidad Negocio"
        Me.chkUnidadNegocio.UseVisualStyleBackColor = True
        '
        'cbo_año
        '
        Me.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año.FormattingEnabled = True
        Me.cbo_año.Location = New System.Drawing.Point(141, 19)
        Me.cbo_año.Name = "cbo_año"
        Me.cbo_año.Size = New System.Drawing.Size(79, 22)
        Me.cbo_año.TabIndex = 101
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(22, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 14)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Año"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(22, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 14)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Al Mes"
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(141, 47)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(135, 22)
        Me.cbo_mes.TabIndex = 100
        '
        'btn_cancelar1
        '
        Me.btn_cancelar1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_cancelar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btn_cancelar1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar1.Location = New System.Drawing.Point(337, 80)
        Me.btn_cancelar1.Name = "btn_cancelar1"
        Me.btn_cancelar1.Size = New System.Drawing.Size(77, 31)
        Me.btn_cancelar1.TabIndex = 80
        Me.btn_cancelar1.TabStop = False
        Me.btn_cancelar1.Text = "&Salir"
        Me.btn_cancelar1.UseVisualStyleBackColor = False
        '
        'btn_pantalla1
        '
        Me.btn_pantalla1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pantalla1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pantalla1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla1.Location = New System.Drawing.Point(186, 147)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(77, 31)
        Me.btn_pantalla1.TabIndex = 6
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'FrmEstadisticaUN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 220)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_pantalla1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmEstadisticaUN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Estadistica Unidad Negocio"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_año As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents btn_cancelar1 As System.Windows.Forms.Button
    Friend WithEvents btn_pantalla1 As System.Windows.Forms.Button
    Friend WithEvents chkUnidadNegocio As System.Windows.Forms.CheckBox
    Friend WithEvents cboUnidadNegocio As System.Windows.Forms.ComboBox
    Friend WithEvents chkcuenta As System.Windows.Forms.CheckBox
End Class
