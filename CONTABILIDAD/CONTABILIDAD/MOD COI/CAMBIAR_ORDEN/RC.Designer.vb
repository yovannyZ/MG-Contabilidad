<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RC))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.btn_sgt = New System.Windows.Forms.Button
        Me.ch_nro_doc = New System.Windows.Forms.RadioButton
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.ch_ca = New System.Windows.Forms.RadioButton
        Me.ch_cod_aux = New System.Windows.Forms.RadioButton
        Me.txt_letra = New System.Windows.Forms.TextBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.btn_modificar = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboCodigoBienes = New System.Windows.Forms.ComboBox
        Me.lblCodigoBienes = New System.Windows.Forms.Label
        Me.TabControl2 = New System.Windows.Forms.TabControl
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtp_det = New System.Windows.Forms.DateTimePicker
        Me.txt_tasa_det = New System.Windows.Forms.TextBox
        Me.txt_nro_det = New System.Windows.Forms.TextBox
        Me.Label68 = New System.Windows.Forms.Label
        Me.Label69 = New System.Windows.Forms.Label
        Me.Label70 = New System.Windows.Forms.Label
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.dtp_ref = New System.Windows.Forms.DateTimePicker
        Me.txt_nro_ref = New System.Windows.Forms.TextBox
        Me.cbo_ref = New System.Windows.Forms.ComboBox
        Me.Label71 = New System.Windows.Forms.Label
        Me.Label72 = New System.Windows.Forms.Label
        Me.Label73 = New System.Windows.Forms.Label
        Me.TabPage10 = New System.Windows.Forms.TabPage
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.dtp_pago = New System.Windows.Forms.DateTimePicker
        Me.Label74 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboTipoRenta = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboConvenios = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboMonedaOrigen = New System.Windows.Forms.ComboBox
        Me.ch_gasto = New System.Windows.Forms.CheckBox
        Me.Panel0 = New System.Windows.Forms.Panel
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.BTN_CANCELAR = New System.Windows.Forms.Button
        Me.dgw_detalle = New System.Windows.Forms.DataGridView
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gb_cabecera = New System.Windows.Forms.GroupBox
        Me.txt_desc_doc = New System.Windows.Forms.TextBox
        Me.des_per = New System.Windows.Forms.TextBox
        Me.nro_doc_per = New System.Windows.Forms.TextBox
        Me.txt_importe = New System.Windows.Forms.TextBox
        Me.cod_per = New System.Windows.Forms.TextBox
        Me.txt_cod_doc = New System.Windows.Forms.TextBox
        Me.Label59 = New System.Windows.Forms.Label
        Me.txt_nro_doc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_nro_comp = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txt_comp = New System.Windows.Forms.TextBox
        Me.txt_auxiliar = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPage10.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel0.SuspendLayout()
        CType(Me.dgw_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_cabecera.SuspendLayout()
        Me.SuspendLayout()
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
        Me.TabControl1.Size = New System.Drawing.Size(673, 579)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox8)
        Me.TabPage1.Controls.Add(Me.btn_salir)
        Me.TabPage1.Controls.Add(Me.dgw1)
        Me.TabPage1.Controls.Add(Me.btn_modificar)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(665, 552)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Registro Compras"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btn_sgt)
        Me.GroupBox8.Controls.Add(Me.ch_nro_doc)
        Me.GroupBox8.Controls.Add(Me.btn_buscar)
        Me.GroupBox8.Controls.Add(Me.ch_ca)
        Me.GroupBox8.Controls.Add(Me.ch_cod_aux)
        Me.GroupBox8.Controls.Add(Me.txt_letra)
        Me.GroupBox8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(8, 433)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(370, 70)
        Me.GroupBox8.TabIndex = 32
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Buscado por:"
        '
        'btn_sgt
        '
        Me.btn_sgt.Enabled = False
        Me.btn_sgt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_sgt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sgt.Image = CType(resources.GetObject("btn_sgt.Image"), System.Drawing.Image)
        Me.btn_sgt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_sgt.Location = New System.Drawing.Point(300, 16)
        Me.btn_sgt.Name = "btn_sgt"
        Me.btn_sgt.Size = New System.Drawing.Size(64, 26)
        Me.btn_sgt.TabIndex = 2
        Me.btn_sgt.Text = "&Sgte."
        Me.btn_sgt.UseVisualStyleBackColor = True
        '
        'ch_nro_doc
        '
        Me.ch_nro_doc.AutoSize = True
        Me.ch_nro_doc.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_nro_doc.Location = New System.Drawing.Point(87, 45)
        Me.ch_nro_doc.Name = "ch_nro_doc"
        Me.ch_nro_doc.Size = New System.Drawing.Size(87, 18)
        Me.ch_nro_doc.TabIndex = 32
        Me.ch_nro_doc.Text = "Número Doc."
        Me.ch_nro_doc.UseVisualStyleBackColor = True
        '
        'btn_buscar
        '
        Me.btn_buscar.Enabled = False
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_buscar.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.Location = New System.Drawing.Point(220, 16)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(74, 26)
        Me.btn_buscar.TabIndex = 1
        Me.btn_buscar.Text = "&Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'ch_ca
        '
        Me.ch_ca.AutoSize = True
        Me.ch_ca.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_ca.Location = New System.Drawing.Point(197, 45)
        Me.ch_ca.Name = "ch_ca"
        Me.ch_ca.Size = New System.Drawing.Size(62, 18)
        Me.ch_ca.TabIndex = 5
        Me.ch_ca.Text = "Cadena"
        Me.ch_ca.UseVisualStyleBackColor = True
        '
        'ch_cod_aux
        '
        Me.ch_cod_aux.AutoSize = True
        Me.ch_cod_aux.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_cod_aux.Location = New System.Drawing.Point(6, 45)
        Me.ch_cod_aux.Name = "ch_cod_aux"
        Me.ch_cod_aux.Size = New System.Drawing.Size(61, 18)
        Me.ch_cod_aux.TabIndex = 3
        Me.ch_cod_aux.Text = "Auxiliar"
        Me.ch_cod_aux.UseVisualStyleBackColor = True
        '
        'txt_letra
        '
        Me.txt_letra.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_letra.Location = New System.Drawing.Point(6, 19)
        Me.txt_letra.Name = "txt_letra"
        Me.txt_letra.Size = New System.Drawing.Size(208, 20)
        Me.txt_letra.TabIndex = 0
        '
        'btn_salir
        '
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(573, 475)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(84, 30)
        Me.btn_salir.TabIndex = 5
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgw1.Location = New System.Drawing.Point(3, 3)
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.ReadOnly = True
        Me.dgw1.RowHeadersWidth = 25
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(659, 424)
        Me.dgw1.TabIndex = 0
        '
        'btn_modificar
        '
        Me.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar.Location = New System.Drawing.Point(573, 442)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(84, 30)
        Me.btn_modificar.TabIndex = 2
        Me.btn_modificar.Text = "&Modificar"
        Me.btn_modificar.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel7)
        Me.TabPage2.Controls.Add(Me.gb_cabecera)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(665, 552)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "Detalles"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.GroupBox1)
        Me.Panel7.Controls.Add(Me.Panel0)
        Me.Panel7.Controls.Add(Me.dgw_detalle)
        Me.Panel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel7.Location = New System.Drawing.Point(6, 118)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(656, 428)
        Me.Panel7.TabIndex = 64
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCodigoBienes)
        Me.GroupBox1.Controls.Add(Me.lblCodigoBienes)
        Me.GroupBox1.Controls.Add(Me.TabControl2)
        Me.GroupBox1.Controls.Add(Me.ch_gasto)
        Me.GroupBox1.Location = New System.Drawing.Point(62, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(447, 156)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'cboCodigoBienes
        '
        Me.cboCodigoBienes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCodigoBienes.FormattingEnabled = True
        Me.cboCodigoBienes.Items.AddRange(New Object() {"MERCADERIA,MAT. PRIMA,SUMINISTRO,ENVASES Y EMBALAJES", "ACTIVO FIJO", "OTROS ACTIVOS NO CONSIDERADOS EN LOS NUMERALES 1 Y 2", "GASTOS DE EDUCACIÓN, RECREACIÓN, SALUD, ETC", "OTROS GASTOS NO INCLUIDOS"})
        Me.cboCodigoBienes.Location = New System.Drawing.Point(80, 128)
        Me.cboCodigoBienes.Name = "cboCodigoBienes"
        Me.cboCodigoBienes.Size = New System.Drawing.Size(316, 22)
        Me.cboCodigoBienes.TabIndex = 70
        '
        'lblCodigoBienes
        '
        Me.lblCodigoBienes.AutoSize = True
        Me.lblCodigoBienes.Location = New System.Drawing.Point(4, 132)
        Me.lblCodigoBienes.Name = "lblCodigoBienes"
        Me.lblCodigoBienes.Size = New System.Drawing.Size(76, 14)
        Me.lblCodigoBienes.TabIndex = 69
        Me.lblCodigoBienes.Text = "Codigo Bienes"
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Controls.Add(Me.TabPage10)
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl2.Location = New System.Drawing.Point(67, 10)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(374, 114)
        Me.TabControl2.TabIndex = 68
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox2)
        Me.TabPage4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(366, 87)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.Text = "Detracciones"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtp_det)
        Me.GroupBox2.Controls.Add(Me.txt_tasa_det)
        Me.GroupBox2.Controls.Add(Me.txt_nro_det)
        Me.GroupBox2.Controls.Add(Me.Label68)
        Me.GroupBox2.Controls.Add(Me.Label69)
        Me.GroupBox2.Controls.Add(Me.Label70)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(267, 75)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'dtp_det
        '
        Me.dtp_det.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_det.Location = New System.Drawing.Point(101, 50)
        Me.dtp_det.Name = "dtp_det"
        Me.dtp_det.Size = New System.Drawing.Size(82, 20)
        Me.dtp_det.TabIndex = 2
        '
        'txt_tasa_det
        '
        Me.txt_tasa_det.Location = New System.Drawing.Point(101, 30)
        Me.txt_tasa_det.MaxLength = 5
        Me.txt_tasa_det.Name = "txt_tasa_det"
        Me.txt_tasa_det.Size = New System.Drawing.Size(100, 20)
        Me.txt_tasa_det.TabIndex = 1
        Me.txt_tasa_det.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_nro_det
        '
        Me.txt_nro_det.Location = New System.Drawing.Point(101, 10)
        Me.txt_nro_det.MaxLength = 15
        Me.txt_nro_det.Name = "txt_nro_det"
        Me.txt_nro_det.Size = New System.Drawing.Size(100, 20)
        Me.txt_nro_det.TabIndex = 0
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(6, 56)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(37, 14)
        Me.Label68.TabIndex = 2
        Me.Label68.Text = "Fecha"
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(6, 36)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(66, 14)
        Me.Label69.TabIndex = 1
        Me.Label69.Text = "Código Tasa"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(6, 16)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(89, 14)
        Me.Label70.TabIndex = 0
        Me.Label70.Text = "Nº de Detracción"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.GroupBox5)
        Me.TabPage5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage5.Location = New System.Drawing.Point(4, 23)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(366, 87)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "Referencia"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dtp_ref)
        Me.GroupBox5.Controls.Add(Me.txt_nro_ref)
        Me.GroupBox5.Controls.Add(Me.cbo_ref)
        Me.GroupBox5.Controls.Add(Me.Label71)
        Me.GroupBox5.Controls.Add(Me.Label72)
        Me.GroupBox5.Controls.Add(Me.Label73)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(267, 75)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        '
        'dtp_ref
        '
        Me.dtp_ref.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_ref.Location = New System.Drawing.Point(72, 50)
        Me.dtp_ref.Name = "dtp_ref"
        Me.dtp_ref.Size = New System.Drawing.Size(83, 20)
        Me.dtp_ref.TabIndex = 2
        '
        'txt_nro_ref
        '
        Me.txt_nro_ref.Location = New System.Drawing.Point(72, 30)
        Me.txt_nro_ref.MaxLength = 15
        Me.txt_nro_ref.Name = "txt_nro_ref"
        Me.txt_nro_ref.Size = New System.Drawing.Size(151, 20)
        Me.txt_nro_ref.TabIndex = 1
        '
        'cbo_ref
        '
        Me.cbo_ref.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_ref.FormattingEnabled = True
        Me.cbo_ref.Location = New System.Drawing.Point(72, 8)
        Me.cbo_ref.Name = "cbo_ref"
        Me.cbo_ref.Size = New System.Drawing.Size(151, 22)
        Me.cbo_ref.TabIndex = 0
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(6, 56)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(37, 14)
        Me.Label71.TabIndex = 2
        Me.Label71.Text = "Fecha"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(6, 36)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(24, 14)
        Me.Label72.TabIndex = 1
        Me.Label72.Text = "Nro"
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(6, 16)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(60, 14)
        Me.Label73.TabIndex = 0
        Me.Label73.Text = "Referencia"
        '
        'TabPage10
        '
        Me.TabPage10.Controls.Add(Me.GroupBox10)
        Me.TabPage10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage10.Location = New System.Drawing.Point(4, 23)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage10.Size = New System.Drawing.Size(366, 87)
        Me.TabPage10.TabIndex = 2
        Me.TabPage10.Text = "Fecha de Pago"
        Me.TabPage10.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.dtp_pago)
        Me.GroupBox10.Controls.Add(Me.Label74)
        Me.GroupBox10.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(267, 75)
        Me.GroupBox10.TabIndex = 0
        Me.GroupBox10.TabStop = False
        '
        'dtp_pago
        '
        Me.dtp_pago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_pago.Location = New System.Drawing.Point(91, 10)
        Me.dtp_pago.Name = "dtp_pago"
        Me.dtp_pago.Size = New System.Drawing.Size(86, 20)
        Me.dtp_pago.TabIndex = 0
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(6, 16)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(79, 14)
        Me.Label74.TabIndex = 0
        Me.Label74.Text = "Fecha de Pago"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.cboTipoRenta)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.cboConvenios)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Controls.Add(Me.cboMonedaOrigen)
        Me.TabPage3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(366, 87)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "No Domiciliados"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(154, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 14)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Tipo Renta"
        '
        'cboTipoRenta
        '
        Me.cboTipoRenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRenta.FormattingEnabled = True
        Me.cboTipoRenta.Items.AddRange(New Object() {"BIENES", "ARRENDAMIENTOS PREDIOS", "OPERACIONES FINANCIERAS", "DISTRIBUCION DE UTILIDADES", "ACTIVIDADES NACIONALES", "TRABAJOS DE PERSONAL NACIONALES", "SERVICIOS DIGITALES", "ASISTENCIA TECNICA", "INGRESO BRUTO TRANS. AEREO", "INGRESO BRUTO FLETE O TRANS. MARITIMO", "EXCESOS ESTADIA CONTENEDORES"})
        Me.cboTipoRenta.Location = New System.Drawing.Point(154, 19)
        Me.cboTipoRenta.Name = "cboTipoRenta"
        Me.cboTipoRenta.Size = New System.Drawing.Size(209, 22)
        Me.cboTipoRenta.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 14)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Convenios"
        '
        'cboConvenios
        '
        Me.cboConvenios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConvenios.FormattingEnabled = True
        Me.cboConvenios.Items.AddRange(New Object() {"NINGUNO", "CANADA", "CHILE", "COMUNIDAD ANDINA DE NACIONES", "BRASIL", "ESTADOS UNIDOS MEXICANOS", "REPUBLICA DE COREA", "CONFEDERACION SUIZA", "PORTUGAL", "OTROS"})
        Me.cboConvenios.Location = New System.Drawing.Point(19, 62)
        Me.cboConvenios.Name = "cboConvenios"
        Me.cboConvenios.Size = New System.Drawing.Size(203, 22)
        Me.cboConvenios.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 14)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Moneda Origen"
        '
        'cboMonedaOrigen
        '
        Me.cboMonedaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonedaOrigen.FormattingEnabled = True
        Me.cboMonedaOrigen.Location = New System.Drawing.Point(15, 20)
        Me.cboMonedaOrigen.Name = "cboMonedaOrigen"
        Me.cboMonedaOrigen.Size = New System.Drawing.Size(133, 22)
        Me.cboMonedaOrigen.TabIndex = 6
        '
        'ch_gasto
        '
        Me.ch_gasto.AutoSize = True
        Me.ch_gasto.Location = New System.Drawing.Point(17, 19)
        Me.ch_gasto.Name = "ch_gasto"
        Me.ch_gasto.Size = New System.Drawing.Size(55, 18)
        Me.ch_gasto.TabIndex = 0
        Me.ch_gasto.Text = "Gasto"
        Me.ch_gasto.UseVisualStyleBackColor = True
        '
        'Panel0
        '
        Me.Panel0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel0.Controls.Add(Me.btn_guardar)
        Me.Panel0.Controls.Add(Me.BTN_CANCELAR)
        Me.Panel0.Location = New System.Drawing.Point(514, 79)
        Me.Panel0.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel0.Name = "Panel0"
        Me.Panel0.Size = New System.Drawing.Size(84, 68)
        Me.Panel0.TabIndex = 3
        Me.Panel0.TabStop = True
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.Location = New System.Drawing.Point(3, 3)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(77, 27)
        Me.btn_guardar.TabIndex = 0
        Me.btn_guardar.Text = "&Grabar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'BTN_CANCELAR
        '
        Me.BTN_CANCELAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CANCELAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.BTN_CANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_CANCELAR.Location = New System.Drawing.Point(3, 36)
        Me.BTN_CANCELAR.Name = "BTN_CANCELAR"
        Me.BTN_CANCELAR.Size = New System.Drawing.Size(77, 27)
        Me.BTN_CANCELAR.TabIndex = 1
        Me.BTN_CANCELAR.Text = "&Cancelar"
        Me.BTN_CANCELAR.UseVisualStyleBackColor = True
        '
        'dgw_detalle
        '
        Me.dgw_detalle.AllowUserToAddRows = False
        Me.dgw_detalle.AllowUserToDeleteRows = False
        Me.dgw_detalle.AllowUserToOrderColumns = True
        Me.dgw_detalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgw_detalle.BackgroundColor = System.Drawing.Color.White
        Me.dgw_detalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column1, Me.Column2})
        Me.dgw_detalle.Location = New System.Drawing.Point(62, 162)
        Me.dgw_detalle.MultiSelect = False
        Me.dgw_detalle.Name = "dgw_detalle"
        Me.dgw_detalle.RowHeadersWidth = 25
        Me.dgw_detalle.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_detalle.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_detalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_detalle.Size = New System.Drawing.Size(402, 254)
        Me.dgw_detalle.TabIndex = 58
        '
        'Column3
        '
        Me.Column3.FillWeight = 45.68528!
        Me.Column3.HeaderText = "Cod"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 30
        '
        'Column1
        '
        Me.Column1.FillWeight = 189.7679!
        Me.Column1.HeaderText = "Orden"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 230
        '
        'Column2
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column2.FillWeight = 64.54689!
        Me.Column2.HeaderText = "Importe"
        Me.Column2.Name = "Column2"
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'gb_cabecera
        '
        Me.gb_cabecera.Controls.Add(Me.txt_desc_doc)
        Me.gb_cabecera.Controls.Add(Me.des_per)
        Me.gb_cabecera.Controls.Add(Me.nro_doc_per)
        Me.gb_cabecera.Controls.Add(Me.txt_importe)
        Me.gb_cabecera.Controls.Add(Me.cod_per)
        Me.gb_cabecera.Controls.Add(Me.txt_cod_doc)
        Me.gb_cabecera.Controls.Add(Me.Label59)
        Me.gb_cabecera.Controls.Add(Me.txt_nro_doc)
        Me.gb_cabecera.Controls.Add(Me.Label4)
        Me.gb_cabecera.Controls.Add(Me.Label61)
        Me.gb_cabecera.Controls.Add(Me.Label5)
        Me.gb_cabecera.Controls.Add(Me.txt_nro_comp)
        Me.gb_cabecera.Controls.Add(Me.Label21)
        Me.gb_cabecera.Controls.Add(Me.txt_comp)
        Me.gb_cabecera.Controls.Add(Me.txt_auxiliar)
        Me.gb_cabecera.Controls.Add(Me.Label13)
        Me.gb_cabecera.Controls.Add(Me.Label23)
        Me.gb_cabecera.Controls.Add(Me.Label25)
        Me.gb_cabecera.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_cabecera.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gb_cabecera.Location = New System.Drawing.Point(6, 3)
        Me.gb_cabecera.Margin = New System.Windows.Forms.Padding(0)
        Me.gb_cabecera.Name = "gb_cabecera"
        Me.gb_cabecera.Padding = New System.Windows.Forms.Padding(0)
        Me.gb_cabecera.Size = New System.Drawing.Size(625, 109)
        Me.gb_cabecera.TabIndex = 1
        Me.gb_cabecera.TabStop = False
        '
        'txt_desc_doc
        '
        Me.txt_desc_doc.BackColor = System.Drawing.Color.White
        Me.txt_desc_doc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_doc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_desc_doc.Location = New System.Drawing.Point(79, 46)
        Me.txt_desc_doc.MaxLength = 100
        Me.txt_desc_doc.Name = "txt_desc_doc"
        Me.txt_desc_doc.Size = New System.Drawing.Size(161, 20)
        Me.txt_desc_doc.TabIndex = 55
        '
        'des_per
        '
        Me.des_per.BackColor = System.Drawing.Color.White
        Me.des_per.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.des_per.ForeColor = System.Drawing.SystemColors.ControlText
        Me.des_per.Location = New System.Drawing.Point(125, 69)
        Me.des_per.MaxLength = 60
        Me.des_per.Name = "des_per"
        Me.des_per.Size = New System.Drawing.Size(339, 20)
        Me.des_per.TabIndex = 53
        '
        'nro_doc_per
        '
        Me.nro_doc_per.BackColor = System.Drawing.Color.White
        Me.nro_doc_per.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nro_doc_per.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nro_doc_per.Location = New System.Drawing.Point(467, 69)
        Me.nro_doc_per.MaxLength = 20
        Me.nro_doc_per.Name = "nro_doc_per"
        Me.nro_doc_per.Size = New System.Drawing.Size(128, 20)
        Me.nro_doc_per.TabIndex = 54
        '
        'txt_importe
        '
        Me.txt_importe.BackColor = System.Drawing.Color.White
        Me.txt_importe.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_importe.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_importe.Location = New System.Drawing.Point(519, 46)
        Me.txt_importe.MaxLength = 100
        Me.txt_importe.Name = "txt_importe"
        Me.txt_importe.Size = New System.Drawing.Size(76, 20)
        Me.txt_importe.TabIndex = 52
        Me.txt_importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cod_per
        '
        Me.cod_per.BackColor = System.Drawing.Color.White
        Me.cod_per.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cod_per.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cod_per.Location = New System.Drawing.Point(79, 69)
        Me.cod_per.MaxLength = 5
        Me.cod_per.Name = "cod_per"
        Me.cod_per.Size = New System.Drawing.Size(46, 20)
        Me.cod_per.TabIndex = 51
        '
        'txt_cod_doc
        '
        Me.txt_cod_doc.BackColor = System.Drawing.Color.White
        Me.txt_cod_doc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_doc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_cod_doc.Location = New System.Drawing.Point(79, 46)
        Me.txt_cod_doc.MaxLength = 100
        Me.txt_cod_doc.Name = "txt_cod_doc"
        Me.txt_cod_doc.Size = New System.Drawing.Size(134, 20)
        Me.txt_cod_doc.TabIndex = 50
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(10, 49)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(61, 14)
        Me.Label59.TabIndex = 49
        Me.Label59.Text = "Documento"
        '
        'txt_nro_doc
        '
        Me.txt_nro_doc.BackColor = System.Drawing.Color.White
        Me.txt_nro_doc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_doc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_nro_doc.Location = New System.Drawing.Point(323, 46)
        Me.txt_nro_doc.MaxLength = 15
        Me.txt_nro_doc.Name = "txt_nro_doc"
        Me.txt_nro_doc.Size = New System.Drawing.Size(138, 20)
        Me.txt_nro_doc.TabIndex = 47
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 14)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Proveedor"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(255, 49)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(44, 14)
        Me.Label61.TabIndex = 48
        Me.Label61.Text = "Número"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(471, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 14)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Importe"
        '
        'txt_nro_comp
        '
        Me.txt_nro_comp.BackColor = System.Drawing.Color.White
        Me.txt_nro_comp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_comp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_nro_comp.Location = New System.Drawing.Point(543, 23)
        Me.txt_nro_comp.MaxLength = 4
        Me.txt_nro_comp.Name = "txt_nro_comp"
        Me.txt_nro_comp.Size = New System.Drawing.Size(52, 20)
        Me.txt_nro_comp.TabIndex = 31
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(516, 26)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(19, 14)
        Me.Label21.TabIndex = 32
        Me.Label21.Text = "Nº"
        '
        'txt_comp
        '
        Me.txt_comp.BackColor = System.Drawing.Color.White
        Me.txt_comp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_comp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_comp.Location = New System.Drawing.Point(323, 23)
        Me.txt_comp.MaxLength = 100
        Me.txt_comp.Name = "txt_comp"
        Me.txt_comp.Size = New System.Drawing.Size(161, 20)
        Me.txt_comp.TabIndex = 30
        '
        'txt_auxiliar
        '
        Me.txt_auxiliar.BackColor = System.Drawing.Color.White
        Me.txt_auxiliar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_auxiliar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_auxiliar.Location = New System.Drawing.Point(79, 23)
        Me.txt_auxiliar.MaxLength = 100
        Me.txt_auxiliar.Name = "txt_auxiliar"
        Me.txt_auxiliar.Size = New System.Drawing.Size(174, 20)
        Me.txt_auxiliar.TabIndex = 29
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 14)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Auxiliar"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(10, 115)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(0, 13)
        Me.Label23.TabIndex = 0
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(255, 26)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(71, 14)
        Me.Label25.TabIndex = 1
        Me.Label25.Text = "Comprobante"
        '
        'RC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 579)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "RC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importes de Registro Compras"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabPage10.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Panel0.ResumeLayout(False)
        CType(Me.dgw_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_cabecera.ResumeLayout(False)
        Me.gb_cabecera.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents dgw1 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents gb_cabecera As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents dgw_detalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents Panel0 As System.Windows.Forms.Panel
    Friend WithEvents BTN_CANCELAR As System.Windows.Forms.Button
    Friend WithEvents txt_comp As System.Windows.Forms.TextBox
    Friend WithEvents txt_auxiliar As System.Windows.Forms.TextBox
    Friend WithEvents txt_nro_comp As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_cod_doc As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents txt_nro_doc As System.Windows.Forms.TextBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents nro_doc_per As System.Windows.Forms.TextBox
    Friend WithEvents des_per As System.Windows.Forms.TextBox
    Friend WithEvents txt_importe As System.Windows.Forms.TextBox
    Friend WithEvents cod_per As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_sgt As System.Windows.Forms.Button
    Friend WithEvents ch_nro_doc As System.Windows.Forms.RadioButton
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents ch_ca As System.Windows.Forms.RadioButton
    Friend WithEvents ch_cod_aux As System.Windows.Forms.RadioButton
    Friend WithEvents txt_letra As System.Windows.Forms.TextBox
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_desc_doc As System.Windows.Forms.TextBox
    Friend WithEvents ch_gasto As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_det As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_tasa_det As System.Windows.Forms.TextBox
    Friend WithEvents txt_nro_det As System.Windows.Forms.TextBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_ref As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_nro_ref As System.Windows.Forms.TextBox
    Friend WithEvents cbo_ref As System.Windows.Forms.ComboBox
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents TabPage10 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_pago As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents cboCodigoBienes As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigoBienes As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTipoRenta As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboConvenios As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMonedaOrigen As System.Windows.Forms.ComboBox
End Class
