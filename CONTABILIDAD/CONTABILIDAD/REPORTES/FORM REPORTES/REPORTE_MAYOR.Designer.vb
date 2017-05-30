Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_MAYOR
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ch_gral = New System.Windows.Forms.CheckBox
        Me.ch_saldo = New System.Windows.Forms.CheckBox
        Me.ch_ana = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbo_hoja = New System.Windows.Forms.ComboBox
        Me.txt_desc_cta0 = New System.Windows.Forms.TextBox
        Me.txt_desc_cuenta2 = New System.Windows.Forms.TextBox
        Me.kl2 = New System.Windows.Forms.TextBox
        Me.kl1 = New System.Windows.Forms.TextBox
        Me.cbo_nivel = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn_salir = New System.Windows.Forms.Button
        Me.dtp01 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.CBO_MES_1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_cod_cuenta2 = New System.Windows.Forms.TextBox
        Me.txt_cod_cta0 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgw_cuenta = New System.Windows.Forms.DataGridView
        Me.dgw_cuenta2 = New System.Windows.Forms.DataGridView
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.Panel_cuenta2 = New System.Windows.Forms.Panel
        Me.Panel_cuenta = New System.Windows.Forms.Panel
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgw_cuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgw_cuenta2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb1.SuspendLayout()
        Me.Panel_cuenta2.SuspendLayout()
        Me.Panel_cuenta.SuspendLayout()
        Me.SuspendLayout()
        '
        'ch_gral
        '
        Me.ch_gral.AutoSize = True
        Me.ch_gral.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ch_gral.Location = New System.Drawing.Point(26, 18)
        Me.ch_gral.Name = "ch_gral"
        Me.ch_gral.Size = New System.Drawing.Size(64, 18)
        Me.ch_gral.TabIndex = 0
        Me.ch_gral.Text = "General"
        Me.ch_gral.UseVisualStyleBackColor = True
        '
        'ch_saldo
        '
        Me.ch_saldo.AutoSize = True
        Me.ch_saldo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ch_saldo.Location = New System.Drawing.Point(126, 18)
        Me.ch_saldo.Name = "ch_saldo"
        Me.ch_saldo.Size = New System.Drawing.Size(59, 18)
        Me.ch_saldo.TabIndex = 0
        Me.ch_saldo.Text = "Saldos"
        Me.ch_saldo.UseVisualStyleBackColor = True
        '
        'ch_ana
        '
        Me.ch_ana.AutoSize = True
        Me.ch_ana.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ch_ana.Location = New System.Drawing.Point(231, 18)
        Me.ch_ana.Name = "ch_ana"
        Me.ch_ana.Size = New System.Drawing.Size(67, 18)
        Me.ch_ana.TabIndex = 0
        Me.ch_ana.Text = "Analítico"
        Me.ch_ana.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbo_hoja)
        Me.GroupBox1.Controls.Add(Me.txt_desc_cta0)
        Me.GroupBox1.Controls.Add(Me.txt_desc_cuenta2)
        Me.GroupBox1.Controls.Add(Me.kl2)
        Me.GroupBox1.Controls.Add(Me.kl1)
        Me.GroupBox1.Controls.Add(Me.cbo_nivel)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.dtp01)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CBO_MES_1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_cod_cuenta2)
        Me.GroupBox1.Controls.Add(Me.txt_cod_cta0)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(60, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(574, 189)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(221, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 14)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Hoja"
        '
        'cbo_hoja
        '
        Me.cbo_hoja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_hoja.FormattingEnabled = True
        Me.cbo_hoja.Items.AddRange(New Object() {"A4 ", "CONTINUO"})
        Me.cbo_hoja.Location = New System.Drawing.Point(268, 130)
        Me.cbo_hoja.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_hoja.Name = "cbo_hoja"
        Me.cbo_hoja.Size = New System.Drawing.Size(121, 22)
        Me.cbo_hoja.TabIndex = 35
        '
        'txt_desc_cta0
        '
        Me.txt_desc_cta0.Location = New System.Drawing.Point(212, 80)
        Me.txt_desc_cta0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_cta0.MaxLength = 40
        Me.txt_desc_cta0.Name = "txt_desc_cta0"
        Me.txt_desc_cta0.Size = New System.Drawing.Size(335, 20)
        Me.txt_desc_cta0.TabIndex = 1
        '
        'txt_desc_cuenta2
        '
        Me.txt_desc_cuenta2.Location = New System.Drawing.Point(212, 105)
        Me.txt_desc_cuenta2.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_cuenta2.MaxLength = 40
        Me.txt_desc_cuenta2.Name = "txt_desc_cuenta2"
        Me.txt_desc_cuenta2.Size = New System.Drawing.Size(334, 20)
        Me.txt_desc_cuenta2.TabIndex = 4
        '
        'kl2
        '
        Me.kl2.Location = New System.Drawing.Point(400, 105)
        Me.kl2.Margin = New System.Windows.Forms.Padding(0)
        Me.kl2.MaxLength = 8
        Me.kl2.Name = "kl2"
        Me.kl2.Size = New System.Drawing.Size(78, 20)
        Me.kl2.TabIndex = 5
        '
        'kl1
        '
        Me.kl1.Location = New System.Drawing.Point(400, 80)
        Me.kl1.Margin = New System.Windows.Forms.Padding(0)
        Me.kl1.MaxLength = 8
        Me.kl1.Name = "kl1"
        Me.kl1.Size = New System.Drawing.Size(78, 20)
        Me.kl1.TabIndex = 2
        '
        'cbo_nivel
        '
        Me.cbo_nivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_nivel.FormattingEnabled = True
        Me.cbo_nivel.Items.AddRange(New Object() {"2", "3", "8"})
        Me.cbo_nivel.Location = New System.Drawing.Point(268, 155)
        Me.cbo_nivel.Name = "cbo_nivel"
        Me.cbo_nivel.Size = New System.Drawing.Size(39, 22)
        Me.cbo_nivel.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(220, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 14)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Nivel"
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.SystemColors.Control
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(465, 150)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(82, 31)
        Me.btn_salir.TabIndex = 31
        Me.btn_salir.TabStop = False
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'dtp01
        '
        Me.dtp01.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp01.Location = New System.Drawing.Point(134, 155)
        Me.dtp01.Name = "dtp01"
        Me.dtp01.Size = New System.Drawing.Size(80, 20)
        Me.dtp01.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(43, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 14)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Emisión"
        '
        'CBO_MES_1
        '
        Me.CBO_MES_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_MES_1.FormattingEnabled = True
        Me.CBO_MES_1.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13"})
        Me.CBO_MES_1.Location = New System.Drawing.Point(134, 130)
        Me.CBO_MES_1.Name = "CBO_MES_1"
        Me.CBO_MES_1.Size = New System.Drawing.Size(52, 22)
        Me.CBO_MES_1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(43, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 14)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Del Mes"
        '
        'txt_cod_cuenta2
        '
        Me.txt_cod_cuenta2.Location = New System.Drawing.Point(134, 105)
        Me.txt_cod_cuenta2.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_cuenta2.MaxLength = 8
        Me.txt_cod_cuenta2.Name = "txt_cod_cuenta2"
        Me.txt_cod_cuenta2.Size = New System.Drawing.Size(78, 20)
        Me.txt_cod_cuenta2.TabIndex = 3
        '
        'txt_cod_cta0
        '
        Me.txt_cod_cta0.Location = New System.Drawing.Point(134, 80)
        Me.txt_cod_cta0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_cta0.MaxLength = 8
        Me.txt_cod_cta0.Name = "txt_cod_cta0"
        Me.txt_cod_cta0.Size = New System.Drawing.Size(78, 20)
        Me.txt_cod_cta0.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Cuenta al"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cuenta del"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ch_gral)
        Me.GroupBox2.Controls.Add(Me.ch_saldo)
        Me.GroupBox2.Controls.Add(Me.ch_ana)
        Me.GroupBox2.Location = New System.Drawing.Point(134, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(328, 42)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        '
        'dgw_cuenta
        '
        Me.dgw_cuenta.AllowUserToAddRows = False
        Me.dgw_cuenta.AllowUserToDeleteRows = False
        Me.dgw_cuenta.AllowUserToOrderColumns = True
        Me.dgw_cuenta.AllowUserToResizeRows = False
        Me.dgw_cuenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_cuenta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_cuenta.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cuenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgw_cuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cuenta.Location = New System.Drawing.Point(145, 0)
        Me.dgw_cuenta.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cuenta.MultiSelect = False
        Me.dgw_cuenta.Name = "dgw_cuenta"
        Me.dgw_cuenta.ReadOnly = True
        Me.dgw_cuenta.RowHeadersWidth = 25
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw_cuenta.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgw_cuenta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cuenta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cuenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cuenta.Size = New System.Drawing.Size(412, 102)
        Me.dgw_cuenta.TabIndex = 21
        '
        'dgw_cuenta2
        '
        Me.dgw_cuenta2.AllowUserToAddRows = False
        Me.dgw_cuenta2.AllowUserToDeleteRows = False
        Me.dgw_cuenta2.AllowUserToOrderColumns = True
        Me.dgw_cuenta2.AllowUserToResizeRows = False
        Me.dgw_cuenta2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_cuenta2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_cuenta2.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cuenta2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgw_cuenta2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cuenta2.Location = New System.Drawing.Point(145, 0)
        Me.dgw_cuenta2.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cuenta2.MultiSelect = False
        Me.dgw_cuenta2.Name = "dgw_cuenta2"
        Me.dgw_cuenta2.ReadOnly = True
        Me.dgw_cuenta2.RowHeadersWidth = 25
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw_cuenta2.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgw_cuenta2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cuenta2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cuenta2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cuenta2.Size = New System.Drawing.Size(412, 101)
        Me.dgw_cuenta2.TabIndex = 30
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(203, 232)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(289, 67)
        Me.gb1.TabIndex = 1
        Me.gb1.TabStop = False
        '
        'btn_archivo1
        '
        Me.btn_archivo1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo1.Location = New System.Drawing.Point(186, 16)
        Me.btn_archivo1.Name = "btn_archivo1"
        Me.btn_archivo1.Size = New System.Drawing.Size(82, 31)
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
        Me.btn_imprimir1.Location = New System.Drawing.Point(98, 16)
        Me.btn_imprimir1.Name = "btn_imprimir1"
        Me.btn_imprimir1.Size = New System.Drawing.Size(82, 31)
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
        Me.btn_pantalla1.Location = New System.Drawing.Point(10, 16)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(82, 31)
        Me.btn_pantalla1.TabIndex = 0
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'Panel_cuenta2
        '
        Me.Panel_cuenta2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_cuenta2.Controls.Add(Me.dgw_cuenta2)
        Me.Panel_cuenta2.Location = New System.Drawing.Point(48, 152)
        Me.Panel_cuenta2.Name = "Panel_cuenta2"
        Me.Panel_cuenta2.Size = New System.Drawing.Size(580, 103)
        Me.Panel_cuenta2.TabIndex = 31
        Me.Panel_cuenta2.Visible = False
        '
        'Panel_cuenta
        '
        Me.Panel_cuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_cuenta.Controls.Add(Me.dgw_cuenta)
        Me.Panel_cuenta.Location = New System.Drawing.Point(48, 126)
        Me.Panel_cuenta.Name = "Panel_cuenta"
        Me.Panel_cuenta.Size = New System.Drawing.Size(580, 100)
        Me.Panel_cuenta.TabIndex = 32
        Me.Panel_cuenta.Visible = False
        '
        'REPORTE_MAYOR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 322)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel_cuenta)
        Me.Controls.Add(Me.Panel_cuenta2)
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_MAYOR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Mayor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgw_cuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgw_cuenta2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb1.ResumeLayout(False)
        Me.Panel_cuenta2.ResumeLayout(False)
        Me.Panel_cuenta.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_archivo1 As Button
    Friend WithEvents btn_imprimir1 As Button
    Friend WithEvents btn_pantalla1 As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents CBO_MES_1 As ComboBox
    Friend WithEvents cbo_nivel As ComboBox
    Friend WithEvents ch_ana As CheckBox
    Friend WithEvents ch_gral As CheckBox
    Friend WithEvents ch_saldo As CheckBox
    Friend WithEvents dgw_cuenta As DataGridView
    Friend WithEvents dgw_cuenta2 As DataGridView
    Friend WithEvents dtp01 As DateTimePicker
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents kl1 As TextBox
    Friend WithEvents kl2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel_cuenta As Panel
    Friend WithEvents Panel_cuenta2 As Panel
    Friend WithEvents txt_cod_cta0 As TextBox
    Friend WithEvents txt_cod_cuenta2 As TextBox
    Friend WithEvents txt_desc_cta0 As TextBox
    Friend WithEvents txt_desc_cuenta2 As TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbo_hoja As System.Windows.Forms.ComboBox
End Class
