Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_CTA_CC
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ch_cc = New System.Windows.Forms.CheckBox
        Me.KL = New System.Windows.Forms.TextBox
        Me.LBL_CPTO = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel_cpto = New System.Windows.Forms.Panel
        Me.dgw_cuenta = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ch_cta = New System.Windows.Forms.CheckBox
        Me.cbo_moneda = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbo_cc = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn_salir = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbo_mes2 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbo_mes1 = New System.Windows.Forms.ComboBox
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.Panel_cpto.SuspendLayout()
        CType(Me.dgw_cuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ch_cc)
        Me.GroupBox1.Controls.Add(Me.LBL_CPTO)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Panel_cpto)
        Me.GroupBox1.Controls.Add(Me.ch_cta)
        Me.GroupBox1.Controls.Add(Me.cbo_moneda)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbo_cc)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbo_mes2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbo_mes1)
        Me.GroupBox1.Controls.Add(Me.KL)
        Me.GroupBox1.Location = New System.Drawing.Point(40, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(494, 258)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'ch_cc
        '
        Me.ch_cc.AutoSize = True
        Me.ch_cc.Checked = True
        Me.ch_cc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_cc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch_cc.Location = New System.Drawing.Point(108, 25)
        Me.ch_cc.Name = "ch_cc"
        Me.ch_cc.Size = New System.Drawing.Size(15, 14)
        Me.ch_cc.TabIndex = 111
        Me.ch_cc.UseVisualStyleBackColor = True
        '
        'KL
        '
        Me.KL.Location = New System.Drawing.Point(347, 22)
        Me.KL.Name = "KL"
        Me.KL.Size = New System.Drawing.Size(11, 20)
        Me.KL.TabIndex = 109
        '
        'LBL_CPTO
        '
        Me.LBL_CPTO.AutoSize = True
        Me.LBL_CPTO.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.LBL_CPTO.Location = New System.Drawing.Point(167, 51)
        Me.LBL_CPTO.Name = "LBL_CPTO"
        Me.LBL_CPTO.Size = New System.Drawing.Size(55, 14)
        Me.LBL_CPTO.TabIndex = 106
        Me.LBL_CPTO.Text = "CUENTAS"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 14)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Cuentas"
        '
        'Panel_cpto
        '
        Me.Panel_cpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_cpto.Controls.Add(Me.dgw_cuenta)
        Me.Panel_cpto.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Panel_cpto.Location = New System.Drawing.Point(83, 69)
        Me.Panel_cpto.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel_cpto.Name = "Panel_cpto"
        Me.Panel_cpto.Size = New System.Drawing.Size(406, 183)
        Me.Panel_cpto.TabIndex = 108
        Me.Panel_cpto.Visible = False
        '
        'dgw_cuenta
        '
        Me.dgw_cuenta.AllowUserToAddRows = False
        Me.dgw_cuenta.AllowUserToDeleteRows = False
        Me.dgw_cuenta.AllowUserToOrderColumns = True
        Me.dgw_cuenta.AllowUserToResizeRows = False
        Me.dgw_cuenta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgw_cuenta.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cuenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgw_cuenta.Location = New System.Drawing.Point(17, 0)
        Me.dgw_cuenta.MultiSelect = False
        Me.dgw_cuenta.Name = "dgw_cuenta"
        Me.dgw_cuenta.ReadOnly = True
        Me.dgw_cuenta.RowHeadersWidth = 25
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw_cuenta.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgw_cuenta.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgw_cuenta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cuenta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cuenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cuenta.Size = New System.Drawing.Size(382, 178)
        Me.dgw_cuenta.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.FillWeight = 6.041746!
        Me.Column1.HeaderText = "Cod"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 65
        '
        'Column2
        '
        Me.Column2.FillWeight = 279.0622!
        Me.Column2.HeaderText = "Cuentas"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 240
        '
        'Column3
        '
        Me.Column3.FillWeight = 61.59653!
        Me.Column3.HeaderText = "OK"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 33
        '
        'ch_cta
        '
        Me.ch_cta.AutoSize = True
        Me.ch_cta.Checked = True
        Me.ch_cta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_cta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch_cta.Location = New System.Drawing.Point(108, 50)
        Me.ch_cta.Name = "ch_cta"
        Me.ch_cta.Size = New System.Drawing.Size(56, 18)
        Me.ch_cta.TabIndex = 105
        Me.ch_cta.Text = "Todos"
        Me.ch_cta.UseVisualStyleBackColor = True
        '
        'cbo_moneda
        '
        Me.cbo_moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_moneda.FormattingEnabled = True
        Me.cbo_moneda.Items.AddRange(New Object() {"Nuevos Soles", "Dólares Americanos"})
        Me.cbo_moneda.Location = New System.Drawing.Point(70, 121)
        Me.cbo_moneda.Name = "cbo_moneda"
        Me.cbo_moneda.Size = New System.Drawing.Size(135, 22)
        Me.cbo_moneda.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 14)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Moneda"
        '
        'cbo_cc
        '
        Me.cbo_cc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_cc.FormattingEnabled = True
        Me.cbo_cc.Items.AddRange(New Object() {"2", "3", "8"})
        Me.cbo_cc.Location = New System.Drawing.Point(130, 20)
        Me.cbo_cc.Name = "cbo_cc"
        Me.cbo_cc.Size = New System.Drawing.Size(246, 22)
        Me.cbo_cc.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 14)
        Me.Label5.TabIndex = 34
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
        Me.btn_salir.TabIndex = 5
        Me.btn_salir.TabStop = False
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(211, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 14)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Al mes "
        '
        'cbo_mes2
        '
        Me.cbo_mes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes2.FormattingEnabled = True
        Me.cbo_mes2.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbo_mes2.Location = New System.Drawing.Point(258, 84)
        Me.cbo_mes2.Name = "cbo_mes2"
        Me.cbo_mes2.Size = New System.Drawing.Size(135, 22)
        Me.cbo_mes2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Del mes"
        '
        'cbo_mes1
        '
        Me.cbo_mes1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes1.FormattingEnabled = True
        Me.cbo_mes1.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbo_mes1.Location = New System.Drawing.Point(70, 84)
        Me.cbo_mes1.Name = "cbo_mes1"
        Me.cbo_mes1.Size = New System.Drawing.Size(135, 22)
        Me.cbo_mes1.TabIndex = 2
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(148, 314)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(276, 67)
        Me.gb1.TabIndex = 2
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
        'REPORTE_CTA_CC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 404)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gb1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_CTA_CC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Cuenta - Centro de Costos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel_cpto.ResumeLayout(False)
        CType(Me.dgw_cuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_archivo1 As Button
    Friend WithEvents btn_imprimir1 As Button
    Friend WithEvents btn_pantalla1 As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents cbo_cc As ComboBox
    Friend WithEvents cbo_mes1 As ComboBox
    Friend WithEvents cbo_mes2 As ComboBox
    Friend WithEvents cbo_moneda As ComboBox
    Friend WithEvents ch_cc As CheckBox
    Friend WithEvents ch_cta As CheckBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewCheckBoxColumn
    Friend WithEvents dgw_cuenta As DataGridView
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents KL As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LBL_CPTO As Label
    Friend WithEvents Panel_cpto As Panel


End Class
