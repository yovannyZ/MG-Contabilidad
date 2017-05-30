<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_CC_SALDO
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
        Me.ch_cc = New System.Windows.Forms.CheckBox
        Me.cbo_moneda = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbo_cc = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn_salir = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbo_mes2 = New System.Windows.Forms.ComboBox
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.stEstado = New System.Windows.Forms.StatusStrip
        Me.tspbExportar = New System.Windows.Forms.ToolStripProgressBar
        Me.tslblMensaje = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox1.SuspendLayout()
        Me.gb1.SuspendLayout()
        Me.stEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ch_cc)
        Me.GroupBox1.Controls.Add(Me.cbo_moneda)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbo_cc)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbo_mes2)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(425, 217)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'ch_cc
        '
        Me.ch_cc.AutoSize = True
        Me.ch_cc.Checked = True
        Me.ch_cc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_cc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch_cc.Location = New System.Drawing.Point(108, 51)
        Me.ch_cc.Name = "ch_cc"
        Me.ch_cc.Size = New System.Drawing.Size(15, 14)
        Me.ch_cc.TabIndex = 1
        Me.ch_cc.UseVisualStyleBackColor = True
        '
        'cbo_moneda
        '
        Me.cbo_moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_moneda.FormattingEnabled = True
        Me.cbo_moneda.Items.AddRange(New Object() {"NUEVOS SOLES", "DÓLARES AMERICANOS"})
        Me.cbo_moneda.Location = New System.Drawing.Point(130, 116)
        Me.cbo_moneda.Name = "cbo_moneda"
        Me.cbo_moneda.Size = New System.Drawing.Size(135, 21)
        Me.cbo_moneda.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Moneda"
        '
        'cbo_cc
        '
        Me.cbo_cc.BackColor = System.Drawing.Color.White
        Me.cbo_cc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_cc.FormattingEnabled = True
        Me.cbo_cc.Items.AddRange(New Object() {"2", "3", "8"})
        Me.cbo_cc.Location = New System.Drawing.Point(130, 46)
        Me.cbo_cc.Name = "cbo_cc"
        Me.cbo_cc.Size = New System.Drawing.Size(246, 21)
        Me.cbo_cc.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 14)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Centro de Costos"
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.SystemColors.Control
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(311, 121)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(82, 33)
        Me.btn_salir.TabIndex = 7
        Me.btn_salir.TabStop = False
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Al mes de"
        '
        'cbo_mes2
        '
        Me.cbo_mes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes2.FormattingEnabled = True
        Me.cbo_mes2.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbo_mes2.Location = New System.Drawing.Point(130, 81)
        Me.cbo_mes2.Name = "cbo_mes2"
        Me.cbo_mes2.Size = New System.Drawing.Size(135, 21)
        Me.cbo_mes2.TabIndex = 4
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(95, 266)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(276, 67)
        Me.gb1.TabIndex = 1
        Me.gb1.TabStop = False
        '
        'btn_archivo1
        '
        Me.btn_archivo1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo1.Location = New System.Drawing.Point(186, 17)
        Me.btn_archivo1.Name = "btn_archivo1"
        Me.btn_archivo1.Size = New System.Drawing.Size(82, 33)
        Me.btn_archivo1.TabIndex = 2
        Me.btn_archivo1.Text = "&Archivo"
        Me.btn_archivo1.UseVisualStyleBackColor = False
        '
        'btn_imprimir1
        '
        Me.btn_imprimir1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_imprimir1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprimir1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.btn_imprimir1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir1.Location = New System.Drawing.Point(98, 17)
        Me.btn_imprimir1.Name = "btn_imprimir1"
        Me.btn_imprimir1.Size = New System.Drawing.Size(82, 33)
        Me.btn_imprimir1.TabIndex = 1
        Me.btn_imprimir1.Text = "&Imprimir"
        Me.btn_imprimir1.UseVisualStyleBackColor = False
        '
        'btn_pantalla1
        '
        Me.btn_pantalla1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pantalla1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla1.Location = New System.Drawing.Point(10, 17)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(82, 33)
        Me.btn_pantalla1.TabIndex = 0
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'stEstado
        '
        Me.stEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspbExportar, Me.tslblMensaje})
        Me.stEstado.Location = New System.Drawing.Point(0, 339)
        Me.stEstado.Name = "stEstado"
        Me.stEstado.Size = New System.Drawing.Size(473, 22)
        Me.stEstado.TabIndex = 156
        Me.stEstado.Text = "StatusStrip1"
        Me.stEstado.Visible = False
        '
        'tspbExportar
        '
        Me.tspbExportar.Name = "tspbExportar"
        Me.tspbExportar.Size = New System.Drawing.Size(100, 16)
        Me.tspbExportar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        '
        'tslblMensaje
        '
        Me.tslblMensaje.Name = "tslblMensaje"
        Me.tslblMensaje.Size = New System.Drawing.Size(109, 17)
        Me.tslblMensaje.Text = "Generando Archivo"
        '
        'REPORTE_CC_SALDO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 361)
        Me.ControlBox = False
        Me.Controls.Add(Me.stEstado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gb1)
        Me.Name = "REPORTE_CC_SALDO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Saldos Centro Costos / Cuenta"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gb1.ResumeLayout(False)
        Me.stEstado.ResumeLayout(False)
        Me.stEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ch_cc As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_moneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_cc As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_mes2 As System.Windows.Forms.ComboBox
    Friend WithEvents gb1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_archivo1 As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir1 As System.Windows.Forms.Button
    Friend WithEvents btn_pantalla1 As System.Windows.Forms.Button
    Friend WithEvents stEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tspbExportar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tslblMensaje As System.Windows.Forms.ToolStripStatusLabel
End Class
