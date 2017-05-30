Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OTROS_DIF_CAMBIO
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ch1 = New System.Windows.Forms.CheckBox
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Elegir = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.g_com = New System.Windows.Forms.Panel
        Me.txt_cta_haber2 = New System.Windows.Forms.TextBox
        Me.txt_cta_debe2 = New System.Windows.Forms.TextBox
        Me.kl2 = New System.Windows.Forms.TextBox
        Me.kl1 = New System.Windows.Forms.TextBox
        Me.txt_cta_haber = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.txt_cta_debe = New System.Windows.Forms.TextBox
        Me.txt_nro_comp = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbo_aux = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbo_com = New System.Windows.Forms.ComboBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Panel_cta01 = New System.Windows.Forms.Panel
        Me.dgw_cta01 = New System.Windows.Forms.DataGridView
        Me.Panel_cta02 = New System.Windows.Forms.Panel
        Me.dgw_cta02 = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgw_cuenta001 = New System.Windows.Forms.DataGridView
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.dgw_cuenta002 = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbVenta = New System.Windows.Forms.RadioButton
        Me.rbCompra = New System.Windows.Forms.RadioButton
        Me.cbo_mes2 = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ch2 = New System.Windows.Forms.CheckBox
        Me.dgw2 = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txt_cta_haber202 = New System.Windows.Forms.TextBox
        Me.txt_cta_debe022 = New System.Windows.Forms.TextBox
        Me.kl20 = New System.Windows.Forms.TextBox
        Me.kl10 = New System.Windows.Forms.TextBox
        Me.txt_cta_haber20 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_cta_debe02 = New System.Windows.Forms.TextBox
        Me.txt_nro_comp2 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbo_aux2 = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbo_com2 = New System.Windows.Forms.ComboBox
        Me.btn_salir2 = New System.Windows.Forms.Button
        Me.btn_aceptar2 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.g_com.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel_cta01.SuspendLayout()
        CType(Me.dgw_cta01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_cta02.SuspendLayout()
        CType(Me.dgw_cta02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgw_cuenta001, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.dgw_cuenta002, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgw2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cbo_mes)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ch1)
        Me.GroupBox1.Controls.Add(Me.dgw1)
        Me.GroupBox1.Controls.Add(Me.g_com)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.btn_aceptar)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(526, 548)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(61, 280)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(90, 22)
        Me.cbo_mes.TabIndex = 155
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label13.Location = New System.Drawing.Point(19, 283)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 14)
        Me.Label13.TabIndex = 156
        Me.Label13.Text = "Mes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Elegir las Cuentas:"
        '
        'ch1
        '
        Me.ch1.AutoSize = True
        Me.ch1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ch1.Location = New System.Drawing.Point(371, 284)
        Me.ch1.Name = "ch1"
        Me.ch1.Size = New System.Drawing.Size(109, 18)
        Me.ch1.TabIndex = 51
        Me.ch1.Text = "Seleccionar Todo"
        Me.ch1.UseVisualStyleBackColor = True
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AllowUserToOrderColumns = True
        Me.dgw1.AllowUserToResizeRows = False
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cuenta, Me.desc, Me.Elegir, Me.Column1})
        Me.dgw1.Location = New System.Drawing.Point(15, 25)
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.RowHeadersWidth = 25
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(476, 249)
        Me.dgw1.TabIndex = 0
        '
        'Cuenta
        '
        Me.Cuenta.FillWeight = 86.90952!
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.Width = 98
        '
        'desc
        '
        Me.desc.FillWeight = 152.2843!
        Me.desc.HeaderText = "Descripción"
        Me.desc.Name = "desc"
        Me.desc.Width = 190
        '
        'Elegir
        '
        Me.Elegir.FillWeight = 60.80621!
        Me.Elegir.HeaderText = "Elegir"
        Me.Elegir.Name = "Elegir"
        Me.Elegir.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Elegir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Elegir.Width = 68
        '
        'Column1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column1.HeaderText = "Importe"
        Me.Column1.Name = "Column1"
        '
        'g_com
        '
        Me.g_com.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.g_com.Controls.Add(Me.txt_cta_haber2)
        Me.g_com.Controls.Add(Me.txt_cta_debe2)
        Me.g_com.Controls.Add(Me.kl2)
        Me.g_com.Controls.Add(Me.kl1)
        Me.g_com.Controls.Add(Me.txt_cta_haber)
        Me.g_com.Controls.Add(Me.Label10)
        Me.g_com.Controls.Add(Me.Label30)
        Me.g_com.Controls.Add(Me.txt_cta_debe)
        Me.g_com.Controls.Add(Me.txt_nro_comp)
        Me.g_com.Controls.Add(Me.Label26)
        Me.g_com.Controls.Add(Me.Label2)
        Me.g_com.Controls.Add(Me.cbo_aux)
        Me.g_com.Controls.Add(Me.Label3)
        Me.g_com.Controls.Add(Me.Label5)
        Me.g_com.Controls.Add(Me.cbo_com)
        Me.g_com.Location = New System.Drawing.Point(15, 308)
        Me.g_com.Name = "g_com"
        Me.g_com.Size = New System.Drawing.Size(476, 167)
        Me.g_com.TabIndex = 50
        '
        'txt_cta_haber2
        '
        Me.txt_cta_haber2.Location = New System.Drawing.Point(81, 100)
        Me.txt_cta_haber2.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cta_haber2.Name = "txt_cta_haber2"
        Me.txt_cta_haber2.Size = New System.Drawing.Size(344, 20)
        Me.txt_cta_haber2.TabIndex = 7
        '
        'txt_cta_debe2
        '
        Me.txt_cta_debe2.Location = New System.Drawing.Point(81, 66)
        Me.txt_cta_debe2.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cta_debe2.Name = "txt_cta_debe2"
        Me.txt_cta_debe2.Size = New System.Drawing.Size(344, 20)
        Me.txt_cta_debe2.TabIndex = 4
        '
        'kl2
        '
        Me.kl2.Location = New System.Drawing.Point(415, 100)
        Me.kl2.Margin = New System.Windows.Forms.Padding(0)
        Me.kl2.Name = "kl2"
        Me.kl2.Size = New System.Drawing.Size(10, 20)
        Me.kl2.TabIndex = 8
        '
        'kl1
        '
        Me.kl1.Location = New System.Drawing.Point(415, 66)
        Me.kl1.Margin = New System.Windows.Forms.Padding(0)
        Me.kl1.Name = "kl1"
        Me.kl1.Size = New System.Drawing.Size(10, 20)
        Me.kl1.TabIndex = 5
        '
        'txt_cta_haber
        '
        Me.txt_cta_haber.Location = New System.Drawing.Point(8, 100)
        Me.txt_cta_haber.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cta_haber.MaxLength = 8
        Me.txt_cta_haber.Name = "txt_cta_haber"
        Me.txt_cta_haber.Size = New System.Drawing.Size(66, 20)
        Me.txt_cta_haber.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 14)
        Me.Label10.TabIndex = 84
        Me.Label10.Text = "Cuenta Debe"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(5, 86)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(73, 14)
        Me.Label30.TabIndex = 83
        Me.Label30.Text = "Cuenta Haber"
        '
        'txt_cta_debe
        '
        Me.txt_cta_debe.Location = New System.Drawing.Point(8, 66)
        Me.txt_cta_debe.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cta_debe.MaxLength = 8
        Me.txt_cta_debe.Name = "txt_cta_debe"
        Me.txt_cta_debe.Size = New System.Drawing.Size(66, 20)
        Me.txt_cta_debe.TabIndex = 3
        '
        'txt_nro_comp
        '
        Me.txt_nro_comp.BackColor = System.Drawing.Color.White
        Me.txt_nro_comp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_comp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_nro_comp.Location = New System.Drawing.Point(372, 30)
        Me.txt_nro_comp.MaxLength = 4
        Me.txt_nro_comp.Name = "txt_nro_comp"
        Me.txt_nro_comp.ReadOnly = True
        Me.txt_nro_comp.Size = New System.Drawing.Size(47, 20)
        Me.txt_nro_comp.TabIndex = 2
        Me.txt_nro_comp.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(3, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(124, 14)
        Me.Label26.TabIndex = 33
        Me.Label26.Text = "Diferencia de Cambio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Auxiliar"
        '
        'cbo_aux
        '
        Me.cbo_aux.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_aux.FormattingEnabled = True
        Me.cbo_aux.Location = New System.Drawing.Point(6, 30)
        Me.cbo_aux.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_aux.Name = "cbo_aux"
        Me.cbo_aux.Size = New System.Drawing.Size(154, 22)
        Me.cbo_aux.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(369, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 14)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nº "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(172, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 14)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Comprobante"
        '
        'cbo_com
        '
        Me.cbo_com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_com.FormattingEnabled = True
        Me.cbo_com.Location = New System.Drawing.Point(175, 30)
        Me.cbo_com.Name = "cbo_com"
        Me.cbo_com.Size = New System.Drawing.Size(174, 22)
        Me.cbo_com.TabIndex = 1
        Me.cbo_com.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.SystemColors.Control
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(400, 494)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(81, 31)
        Me.btn_salir.TabIndex = 2
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_aceptar
        '
        Me.btn_aceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aceptar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar.Location = New System.Drawing.Point(313, 494)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(81, 31)
        Me.btn_aceptar.TabIndex = 1
        Me.btn_aceptar.Text = "&Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(557, 618)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel_cta01)
        Me.TabPage1.Controls.Add(Me.Panel_cta02)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(549, 591)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Conciliadas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel_cta01
        '
        Me.Panel_cta01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_cta01.Controls.Add(Me.dgw_cta01)
        Me.Panel_cta01.Location = New System.Drawing.Point(4, 412)
        Me.Panel_cta01.Name = "Panel_cta01"
        Me.Panel_cta01.Size = New System.Drawing.Size(465, 117)
        Me.Panel_cta01.TabIndex = 78
        Me.Panel_cta01.Visible = False
        '
        'dgw_cta01
        '
        Me.dgw_cta01.AllowUserToAddRows = False
        Me.dgw_cta01.AllowUserToDeleteRows = False
        Me.dgw_cta01.AllowUserToOrderColumns = True
        Me.dgw_cta01.AllowUserToResizeRows = False
        Me.dgw_cta01.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_cta01.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cta01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgw_cta01.Location = New System.Drawing.Point(36, -1)
        Me.dgw_cta01.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta01.MultiSelect = False
        Me.dgw_cta01.Name = "dgw_cta01"
        Me.dgw_cta01.ReadOnly = True
        Me.dgw_cta01.RowHeadersWidth = 25
        Me.dgw_cta01.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta01.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta01.Size = New System.Drawing.Size(417, 107)
        Me.dgw_cta01.TabIndex = 30
        '
        'Panel_cta02
        '
        Me.Panel_cta02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_cta02.Controls.Add(Me.dgw_cta02)
        Me.Panel_cta02.Location = New System.Drawing.Point(8, 446)
        Me.Panel_cta02.Name = "Panel_cta02"
        Me.Panel_cta02.Size = New System.Drawing.Size(461, 112)
        Me.Panel_cta02.TabIndex = 79
        Me.Panel_cta02.Visible = False
        '
        'dgw_cta02
        '
        Me.dgw_cta02.AllowUserToAddRows = False
        Me.dgw_cta02.AllowUserToDeleteRows = False
        Me.dgw_cta02.AllowUserToOrderColumns = True
        Me.dgw_cta02.AllowUserToResizeRows = False
        Me.dgw_cta02.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_cta02.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cta02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgw_cta02.Location = New System.Drawing.Point(32, -1)
        Me.dgw_cta02.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta02.MultiSelect = False
        Me.dgw_cta02.Name = "dgw_cta02"
        Me.dgw_cta02.ReadOnly = True
        Me.dgw_cta02.RowHeadersWidth = 25
        Me.dgw_cta02.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta02.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta02.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta02.Size = New System.Drawing.Size(417, 107)
        Me.dgw_cta02.TabIndex = 30
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(549, 591)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Pendientes"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dgw_cuenta001)
        Me.Panel2.Location = New System.Drawing.Point(0, 416)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(472, 117)
        Me.Panel2.TabIndex = 80
        Me.Panel2.Visible = False
        '
        'dgw_cuenta001
        '
        Me.dgw_cuenta001.AllowUserToAddRows = False
        Me.dgw_cuenta001.AllowUserToDeleteRows = False
        Me.dgw_cuenta001.AllowUserToOrderColumns = True
        Me.dgw_cuenta001.AllowUserToResizeRows = False
        Me.dgw_cuenta001.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_cuenta001.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cuenta001.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgw_cuenta001.Location = New System.Drawing.Point(34, -1)
        Me.dgw_cuenta001.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cuenta001.MultiSelect = False
        Me.dgw_cuenta001.Name = "dgw_cuenta001"
        Me.dgw_cuenta001.ReadOnly = True
        Me.dgw_cuenta001.RowHeadersWidth = 25
        Me.dgw_cuenta001.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cuenta001.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cuenta001.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cuenta001.Size = New System.Drawing.Size(417, 107)
        Me.dgw_cuenta001.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.dgw_cuenta002)
        Me.Panel3.Location = New System.Drawing.Point(7, 450)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(465, 112)
        Me.Panel3.TabIndex = 81
        Me.Panel3.Visible = False
        '
        'dgw_cuenta002
        '
        Me.dgw_cuenta002.AllowUserToAddRows = False
        Me.dgw_cuenta002.AllowUserToDeleteRows = False
        Me.dgw_cuenta002.AllowUserToOrderColumns = True
        Me.dgw_cuenta002.AllowUserToResizeRows = False
        Me.dgw_cuenta002.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_cuenta002.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cuenta002.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgw_cuenta002.Location = New System.Drawing.Point(27, -1)
        Me.dgw_cuenta002.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cuenta002.MultiSelect = False
        Me.dgw_cuenta002.Name = "dgw_cuenta002"
        Me.dgw_cuenta002.ReadOnly = True
        Me.dgw_cuenta002.RowHeadersWidth = 25
        Me.dgw_cuenta002.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cuenta002.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cuenta002.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cuenta002.Size = New System.Drawing.Size(412, 107)
        Me.dgw_cuenta002.TabIndex = 30
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.rbVenta)
        Me.GroupBox2.Controls.Add(Me.rbCompra)
        Me.GroupBox2.Controls.Add(Me.cbo_mes2)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.ch2)
        Me.GroupBox2.Controls.Add(Me.dgw2)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.btn_salir2)
        Me.GroupBox2.Controls.Add(Me.btn_aceptar2)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(526, 549)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'rbVenta
        '
        Me.rbVenta.AutoSize = True
        Me.rbVenta.Location = New System.Drawing.Point(15, 518)
        Me.rbVenta.Name = "rbVenta"
        Me.rbVenta.Size = New System.Drawing.Size(114, 18)
        Me.rbVenta.TabIndex = 161
        Me.rbVenta.Text = "Tipo Cambio Venta"
        Me.rbVenta.UseVisualStyleBackColor = True
        '
        'rbCompra
        '
        Me.rbCompra.AutoSize = True
        Me.rbCompra.Checked = True
        Me.rbCompra.Location = New System.Drawing.Point(15, 494)
        Me.rbCompra.Name = "rbCompra"
        Me.rbCompra.Size = New System.Drawing.Size(123, 18)
        Me.rbCompra.TabIndex = 160
        Me.rbCompra.TabStop = True
        Me.rbCompra.Text = "Tipo Cambio Compra"
        Me.rbCompra.UseVisualStyleBackColor = True
        '
        'cbo_mes2
        '
        Me.cbo_mes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes2.FormattingEnabled = True
        Me.cbo_mes2.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbo_mes2.Location = New System.Drawing.Point(62, 280)
        Me.cbo_mes2.Name = "cbo_mes2"
        Me.cbo_mes2.Size = New System.Drawing.Size(90, 22)
        Me.cbo_mes2.TabIndex = 157
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label14.Location = New System.Drawing.Point(20, 283)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(27, 14)
        Me.Label14.TabIndex = 158
        Me.Label14.Text = "Mes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 14)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Elegir las Cuentas:"
        '
        'ch2
        '
        Me.ch2.AutoSize = True
        Me.ch2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ch2.Location = New System.Drawing.Point(371, 284)
        Me.ch2.Name = "ch2"
        Me.ch2.Size = New System.Drawing.Size(109, 18)
        Me.ch2.TabIndex = 51
        Me.ch2.Text = "Seleccionar Todo"
        Me.ch2.UseVisualStyleBackColor = True
        '
        'dgw2
        '
        Me.dgw2.AllowUserToAddRows = False
        Me.dgw2.AllowUserToDeleteRows = False
        Me.dgw2.AllowUserToOrderColumns = True
        Me.dgw2.AllowUserToResizeRows = False
        Me.dgw2.BackgroundColor = System.Drawing.Color.White
        Me.dgw2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn3})
        Me.dgw2.Location = New System.Drawing.Point(15, 25)
        Me.dgw2.MultiSelect = False
        Me.dgw2.Name = "dgw2"
        Me.dgw2.RowHeadersWidth = 25
        Me.dgw2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw2.Size = New System.Drawing.Size(476, 249)
        Me.dgw2.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 57.05735!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Cuenta"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 95
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 99.97683!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 190
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.FillWeight = 39.92015!
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Elegir"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckBoxColumn1.Width = 65
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn3.FillWeight = 203.0457!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Importe"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txt_cta_haber202)
        Me.Panel1.Controls.Add(Me.txt_cta_debe022)
        Me.Panel1.Controls.Add(Me.kl20)
        Me.Panel1.Controls.Add(Me.kl10)
        Me.Panel1.Controls.Add(Me.txt_cta_haber20)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txt_cta_debe02)
        Me.Panel1.Controls.Add(Me.txt_nro_comp2)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cbo_aux2)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.cbo_com2)
        Me.Panel1.Location = New System.Drawing.Point(15, 308)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(476, 168)
        Me.Panel1.TabIndex = 50
        '
        'txt_cta_haber202
        '
        Me.txt_cta_haber202.Location = New System.Drawing.Point(81, 109)
        Me.txt_cta_haber202.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cta_haber202.Name = "txt_cta_haber202"
        Me.txt_cta_haber202.Size = New System.Drawing.Size(338, 20)
        Me.txt_cta_haber202.TabIndex = 7
        '
        'txt_cta_debe022
        '
        Me.txt_cta_debe022.Location = New System.Drawing.Point(81, 75)
        Me.txt_cta_debe022.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cta_debe022.Name = "txt_cta_debe022"
        Me.txt_cta_debe022.Size = New System.Drawing.Size(338, 20)
        Me.txt_cta_debe022.TabIndex = 4
        '
        'kl20
        '
        Me.kl20.Location = New System.Drawing.Point(393, 109)
        Me.kl20.Margin = New System.Windows.Forms.Padding(0)
        Me.kl20.Name = "kl20"
        Me.kl20.Size = New System.Drawing.Size(10, 20)
        Me.kl20.TabIndex = 8
        '
        'kl10
        '
        Me.kl10.Location = New System.Drawing.Point(393, 75)
        Me.kl10.Margin = New System.Windows.Forms.Padding(0)
        Me.kl10.Name = "kl10"
        Me.kl10.Size = New System.Drawing.Size(10, 20)
        Me.kl10.TabIndex = 5
        '
        'txt_cta_haber20
        '
        Me.txt_cta_haber20.Location = New System.Drawing.Point(6, 109)
        Me.txt_cta_haber20.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cta_haber20.MaxLength = 8
        Me.txt_cta_haber20.Name = "txt_cta_haber20"
        Me.txt_cta_haber20.Size = New System.Drawing.Size(70, 20)
        Me.txt_cta_haber20.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 14)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Cuenta Debe"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 95)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 14)
        Me.Label12.TabIndex = 89
        Me.Label12.Text = "Cuenta Haber"
        '
        'txt_cta_debe02
        '
        Me.txt_cta_debe02.Location = New System.Drawing.Point(8, 75)
        Me.txt_cta_debe02.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cta_debe02.MaxLength = 8
        Me.txt_cta_debe02.Name = "txt_cta_debe02"
        Me.txt_cta_debe02.Size = New System.Drawing.Size(70, 20)
        Me.txt_cta_debe02.TabIndex = 3
        '
        'txt_nro_comp2
        '
        Me.txt_nro_comp2.BackColor = System.Drawing.Color.White
        Me.txt_nro_comp2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_comp2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_nro_comp2.Location = New System.Drawing.Point(372, 30)
        Me.txt_nro_comp2.MaxLength = 4
        Me.txt_nro_comp2.Name = "txt_nro_comp2"
        Me.txt_nro_comp2.ReadOnly = True
        Me.txt_nro_comp2.Size = New System.Drawing.Size(47, 20)
        Me.txt_nro_comp2.TabIndex = 2
        Me.txt_nro_comp2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 14)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Diferencia de Cambio"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 16)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 14)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Auxiliar"
        '
        'cbo_aux2
        '
        Me.cbo_aux2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_aux2.FormattingEnabled = True
        Me.cbo_aux2.Location = New System.Drawing.Point(6, 30)
        Me.cbo_aux2.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_aux2.Name = "cbo_aux2"
        Me.cbo_aux2.Size = New System.Drawing.Size(154, 22)
        Me.cbo_aux2.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(369, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 14)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Nº "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(172, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 14)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Comprobante"
        '
        'cbo_com2
        '
        Me.cbo_com2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_com2.FormattingEnabled = True
        Me.cbo_com2.Location = New System.Drawing.Point(175, 30)
        Me.cbo_com2.Name = "cbo_com2"
        Me.cbo_com2.Size = New System.Drawing.Size(174, 22)
        Me.cbo_com2.TabIndex = 1
        Me.cbo_com2.TabStop = False
        '
        'btn_salir2
        '
        Me.btn_salir2.BackColor = System.Drawing.SystemColors.Control
        Me.btn_salir2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir2.Location = New System.Drawing.Point(400, 500)
        Me.btn_salir2.Name = "btn_salir2"
        Me.btn_salir2.Size = New System.Drawing.Size(81, 31)
        Me.btn_salir2.TabIndex = 2
        Me.btn_salir2.Text = "&Salir"
        Me.btn_salir2.UseVisualStyleBackColor = False
        '
        'btn_aceptar2
        '
        Me.btn_aceptar2.BackColor = System.Drawing.SystemColors.Control
        Me.btn_aceptar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aceptar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_aceptar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar2.Location = New System.Drawing.Point(313, 500)
        Me.btn_aceptar2.Name = "btn_aceptar2"
        Me.btn_aceptar2.Size = New System.Drawing.Size(81, 31)
        Me.btn_aceptar2.TabIndex = 1
        Me.btn_aceptar2.Text = "&Aceptar"
        Me.btn_aceptar2.UseVisualStyleBackColor = False
        '
        'OTROS_DIF_CAMBIO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 618)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "OTROS_DIF_CAMBIO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Diferencia de Cambio de Otras Cuentas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.g_com.ResumeLayout(False)
        Me.g_com.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel_cta01.ResumeLayout(False)
        CType(Me.dgw_cta01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_cta02.ResumeLayout(False)
        CType(Me.dgw_cta02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgw_cuenta001, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgw_cuenta002, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgw2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_aceptar As Button
    Friend WithEvents btn_aceptar2 As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents btn_salir2 As Button
    Friend WithEvents cbo_aux As ComboBox
    Friend WithEvents cbo_aux2 As ComboBox
    Friend WithEvents cbo_com As ComboBox
    Friend WithEvents cbo_com2 As ComboBox
    Friend WithEvents ch1 As CheckBox
    Friend WithEvents ch2 As CheckBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents desc As DataGridViewTextBoxColumn
    Friend WithEvents dgw1 As DataGridView
    Friend WithEvents dgw2 As DataGridView
    Friend WithEvents Elegir As DataGridViewCheckBoxColumn
    Friend WithEvents g_com As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txt_nro_comp As TextBox
    Friend WithEvents txt_nro_comp2 As TextBox
    Friend WithEvents txt_cta_haber2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_cta_debe2 As System.Windows.Forms.TextBox
    Friend WithEvents kl2 As System.Windows.Forms.TextBox
    Friend WithEvents kl1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_cta_haber As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txt_cta_debe As System.Windows.Forms.TextBox
    Friend WithEvents Panel_cta01 As System.Windows.Forms.Panel
    Friend WithEvents dgw_cta01 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel_cta02 As System.Windows.Forms.Panel
    Friend WithEvents dgw_cta02 As System.Windows.Forms.DataGridView
    Friend WithEvents txt_cta_debe022 As System.Windows.Forms.TextBox
    Friend WithEvents txt_cta_haber202 As System.Windows.Forms.TextBox
    Friend WithEvents txt_cta_haber20 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_cta_debe02 As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgw_cuenta001 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dgw_cuenta002 As System.Windows.Forms.DataGridView
    Friend WithEvents kl20 As System.Windows.Forms.TextBox
    Friend WithEvents kl10 As System.Windows.Forms.TextBox
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbo_mes2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents rbVenta As System.Windows.Forms.RadioButton
    Friend WithEvents rbCompra As System.Windows.Forms.RadioButton

End Class
