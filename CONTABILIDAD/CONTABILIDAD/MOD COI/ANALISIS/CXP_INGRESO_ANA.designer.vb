Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CXP_INGRESO_ANA
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label16 = New System.Windows.Forms.Label
        Me.cbo_mes1 = New System.Windows.Forms.ComboBox
        Me.btn_consultar = New System.Windows.Forms.Button
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_modificar = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Panel_doc = New System.Windows.Forms.Panel
        Me.Panel_CXP = New System.Windows.Forms.Panel
        Me.dgw_per = New System.Windows.Forms.DataGridView
        Me.Panel_cta = New System.Windows.Forms.Panel
        Me.dgw_cuenta = New System.Windows.Forms.DataGridView
        Me.item = New System.Windows.Forms.TextBox
        Me.g_doc = New System.Windows.Forms.GroupBox
        Me.txt_desc_per0 = New System.Windows.Forms.TextBox
        Me.txt_desc_cta0 = New System.Windows.Forms.TextBox
        Me.txt_nro_doc_per0 = New System.Windows.Forms.TextBox
        Me.kl2 = New System.Windows.Forms.TextBox
        Me.kl1 = New System.Windows.Forms.TextBox
        Me.cbo_tipo_ref0 = New System.Windows.Forms.ComboBox
        Me.cbo_moneda1 = New System.Windows.Forms.ComboBox
        Me.cbo_tipo_doc0 = New System.Windows.Forms.ComboBox
        Me.txt_nro_doc0 = New System.Windows.Forms.TextBox
        Me.dtp_doc0 = New System.Windows.Forms.DateTimePicker
        Me.txt_glosa0 = New System.Windows.Forms.TextBox
        Me.txt_cambio0 = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.cbo_d_h = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_cod_cta0 = New System.Windows.Forms.TextBox
        Me.txt_imp_soles0 = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.txt_cod_per0 = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_nro_ref0 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.gb_doc2 = New System.Windows.Forms.Panel
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.btn_modificar2 = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.btn_nuevo_comp = New System.Windows.Forms.Button
        Me.btn_grabar_com2 = New System.Windows.Forms.Button
        Me.Label67 = New System.Windows.Forms.Label
        Me.btn_grabar_com = New System.Windows.Forms.Button
        Me.btn_cancelar_com = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txt_debe = New System.Windows.Forms.TextBox
        Me.txt_haber = New System.Windows.Forms.TextBox
        Me.txt_debe2 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_haber2 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Panel_doc2 = New System.Windows.Forms.Panel
        Me.btn_mod = New System.Windows.Forms.Button
        Me.btn_nuevo_det = New System.Windows.Forms.Button
        Me.btn_eliminar2 = New System.Windows.Forms.Button
        Me.g_cab = New System.Windows.Forms.GroupBox
        Me.cbo_aux = New System.Windows.Forms.ComboBox
        Me.dtp_com = New System.Windows.Forms.DateTimePicker
        Me.cbo_com = New System.Windows.Forms.ComboBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.txt_nro_comp = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.dgw_mov1 = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnImportarExcel = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.dtpFechaVen = New System.Windows.Forms.DateTimePicker
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel_doc.SuspendLayout()
        Me.Panel_CXP.SuspendLayout()
        CType(Me.dgw_per, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_cta.SuspendLayout()
        CType(Me.dgw_cuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.g_doc.SuspendLayout()
        Me.gb_doc2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel_doc2.SuspendLayout()
        Me.g_cab.SuspendLayout()
        CType(Me.dgw_mov1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.Size = New System.Drawing.Size(705, 425)
        Me.TabControl1.TabIndex = 102
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.cbo_mes1)
        Me.TabPage1.Controls.Add(Me.btn_consultar)
        Me.TabPage1.Controls.Add(Me.btn_eliminar)
        Me.TabPage1.Controls.Add(Me.btn_salir)
        Me.TabPage1.Controls.Add(Me.btn_modificar)
        Me.TabPage1.Controls.Add(Me.btn_nuevo)
        Me.TabPage1.Controls.Add(Me.dgw1)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(697, 398)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Lista de Documentos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(78, 26)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(27, 14)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Mes"
        '
        'cbo_mes1
        '
        Me.cbo_mes1.BackColor = System.Drawing.Color.White
        Me.cbo_mes1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_mes1.FormattingEnabled = True
        Me.cbo_mes1.Items.AddRange(New Object() {"INICIO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.cbo_mes1.Location = New System.Drawing.Point(111, 18)
        Me.cbo_mes1.Name = "cbo_mes1"
        Me.cbo_mes1.Size = New System.Drawing.Size(138, 22)
        Me.cbo_mes1.TabIndex = 25
        '
        'btn_consultar
        '
        Me.btn_consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_consultar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Search_1
        Me.btn_consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consultar.Location = New System.Drawing.Point(471, 359)
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(79, 29)
        Me.btn_consultar.TabIndex = 9
        Me.btn_consultar.Text = "&Detalles"
        Me.btn_consultar.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar.Location = New System.Drawing.Point(556, 324)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(80, 29)
        Me.btn_eliminar.TabIndex = 8
        Me.btn_eliminar.Text = "&Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(556, 359)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(80, 29)
        Me.btn_salir.TabIndex = 10
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_modificar
        '
        Me.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar.Location = New System.Drawing.Point(471, 324)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(79, 29)
        Me.btn_modificar.TabIndex = 7
        Me.btn_modificar.Text = "&Modificar"
        Me.btn_modificar.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.Location = New System.Drawing.Point(385, 324)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(80, 29)
        Me.btn_nuevo.TabIndex = 6
        Me.btn_nuevo.Text = "&Nuevo"
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AllowUserToOrderColumns = True
        Me.dgw1.AllowUserToResizeRows = False
        Me.dgw1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.Location = New System.Drawing.Point(75, 52)
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.ReadOnly = True
        Me.dgw1.RowHeadersWidth = 25
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(561, 266)
        Me.dgw1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel_doc)
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Panel_doc2)
        Me.TabPage2.Controls.Add(Me.g_cab)
        Me.TabPage2.Controls.Add(Me.dgw_mov1)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.btnImportarExcel)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(697, 398)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalles"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel_doc
        '
        Me.Panel_doc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_doc.Controls.Add(Me.Panel_CXP)
        Me.Panel_doc.Controls.Add(Me.Panel_cta)
        Me.Panel_doc.Controls.Add(Me.item)
        Me.Panel_doc.Controls.Add(Me.g_doc)
        Me.Panel_doc.Controls.Add(Me.gb_doc2)
        Me.Panel_doc.Location = New System.Drawing.Point(2, 203)
        Me.Panel_doc.Name = "Panel_doc"
        Me.Panel_doc.Size = New System.Drawing.Size(692, 195)
        Me.Panel_doc.TabIndex = 2
        '
        'Panel_CXP
        '
        Me.Panel_CXP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_CXP.Controls.Add(Me.dgw_per)
        Me.Panel_CXP.Location = New System.Drawing.Point(2, 65)
        Me.Panel_CXP.Name = "Panel_CXP"
        Me.Panel_CXP.Size = New System.Drawing.Size(590, 114)
        Me.Panel_CXP.TabIndex = 118
        Me.Panel_CXP.Visible = False
        '
        'dgw_per
        '
        Me.dgw_per.AllowUserToAddRows = False
        Me.dgw_per.AllowUserToDeleteRows = False
        Me.dgw_per.AllowUserToOrderColumns = True
        Me.dgw_per.AllowUserToResizeRows = False
        Me.dgw_per.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_per.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_per.BackgroundColor = System.Drawing.Color.White
        Me.dgw_per.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgw_per.Location = New System.Drawing.Point(66, 2)
        Me.dgw_per.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_per.MultiSelect = False
        Me.dgw_per.Name = "dgw_per"
        Me.dgw_per.ReadOnly = True
        Me.dgw_per.RowHeadersWidth = 25
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw_per.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgw_per.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_per.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_per.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_per.Size = New System.Drawing.Size(508, 110)
        Me.dgw_per.TabIndex = 89
        Me.dgw_per.TabStop = False
        '
        'Panel_cta
        '
        Me.Panel_cta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_cta.Controls.Add(Me.dgw_cuenta)
        Me.Panel_cta.Location = New System.Drawing.Point(0, 83)
        Me.Panel_cta.Name = "Panel_cta"
        Me.Panel_cta.Size = New System.Drawing.Size(344, 100)
        Me.Panel_cta.TabIndex = 119
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
        Me.dgw_cuenta.Location = New System.Drawing.Point(66, 1)
        Me.dgw_cuenta.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cuenta.MultiSelect = False
        Me.dgw_cuenta.Name = "dgw_cuenta"
        Me.dgw_cuenta.ReadOnly = True
        Me.dgw_cuenta.RowHeadersWidth = 25
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw_cuenta.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgw_cuenta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cuenta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cuenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cuenta.Size = New System.Drawing.Size(260, 94)
        Me.dgw_cuenta.TabIndex = 3
        '
        'item
        '
        Me.item.Location = New System.Drawing.Point(568, 184)
        Me.item.Name = "item"
        Me.item.Size = New System.Drawing.Size(24, 20)
        Me.item.TabIndex = 105
        Me.item.Visible = False
        '
        'g_doc
        '
        Me.g_doc.Controls.Add(Me.dtpFechaVen)
        Me.g_doc.Controls.Add(Me.Label17)
        Me.g_doc.Controls.Add(Me.txt_desc_per0)
        Me.g_doc.Controls.Add(Me.txt_desc_cta0)
        Me.g_doc.Controls.Add(Me.txt_nro_doc_per0)
        Me.g_doc.Controls.Add(Me.kl2)
        Me.g_doc.Controls.Add(Me.kl1)
        Me.g_doc.Controls.Add(Me.cbo_tipo_ref0)
        Me.g_doc.Controls.Add(Me.cbo_moneda1)
        Me.g_doc.Controls.Add(Me.cbo_tipo_doc0)
        Me.g_doc.Controls.Add(Me.txt_nro_doc0)
        Me.g_doc.Controls.Add(Me.dtp_doc0)
        Me.g_doc.Controls.Add(Me.txt_glosa0)
        Me.g_doc.Controls.Add(Me.txt_cambio0)
        Me.g_doc.Controls.Add(Me.Label34)
        Me.g_doc.Controls.Add(Me.cbo_d_h)
        Me.g_doc.Controls.Add(Me.Label11)
        Me.g_doc.Controls.Add(Me.Label33)
        Me.g_doc.Controls.Add(Me.Label10)
        Me.g_doc.Controls.Add(Me.Label3)
        Me.g_doc.Controls.Add(Me.txt_cod_cta0)
        Me.g_doc.Controls.Add(Me.txt_imp_soles0)
        Me.g_doc.Controls.Add(Me.Label38)
        Me.g_doc.Controls.Add(Me.txt_cod_per0)
        Me.g_doc.Controls.Add(Me.Label36)
        Me.g_doc.Controls.Add(Me.Label1)
        Me.g_doc.Controls.Add(Me.Label40)
        Me.g_doc.Controls.Add(Me.Label12)
        Me.g_doc.Controls.Add(Me.txt_nro_ref0)
        Me.g_doc.Controls.Add(Me.Label4)
        Me.g_doc.Controls.Add(Me.Label5)
        Me.g_doc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.g_doc.Location = New System.Drawing.Point(5, 14)
        Me.g_doc.Name = "g_doc"
        Me.g_doc.Size = New System.Drawing.Size(579, 153)
        Me.g_doc.TabIndex = 1
        Me.g_doc.TabStop = False
        '
        'txt_desc_per0
        '
        Me.txt_desc_per0.BackColor = System.Drawing.Color.White
        Me.txt_desc_per0.Location = New System.Drawing.Point(107, 28)
        Me.txt_desc_per0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_per0.MaxLength = 60
        Me.txt_desc_per0.Name = "txt_desc_per0"
        Me.txt_desc_per0.Size = New System.Drawing.Size(360, 20)
        Me.txt_desc_per0.TabIndex = 1
        '
        'txt_desc_cta0
        '
        Me.txt_desc_cta0.BackColor = System.Drawing.Color.White
        Me.txt_desc_cta0.Location = New System.Drawing.Point(126, 51)
        Me.txt_desc_cta0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_cta0.MaxLength = 40
        Me.txt_desc_cta0.Name = "txt_desc_cta0"
        Me.txt_desc_cta0.Size = New System.Drawing.Size(200, 20)
        Me.txt_desc_cta0.TabIndex = 5
        '
        'txt_nro_doc_per0
        '
        Me.txt_nro_doc_per0.Location = New System.Drawing.Point(470, 28)
        Me.txt_nro_doc_per0.MaxLength = 20
        Me.txt_nro_doc_per0.Name = "txt_nro_doc_per0"
        Me.txt_nro_doc_per0.Size = New System.Drawing.Size(102, 20)
        Me.txt_nro_doc_per0.TabIndex = 2
        '
        'kl2
        '
        Me.kl2.Location = New System.Drawing.Point(396, 28)
        Me.kl2.Name = "kl2"
        Me.kl2.Size = New System.Drawing.Size(32, 20)
        Me.kl2.TabIndex = 3
        '
        'kl1
        '
        Me.kl1.Location = New System.Drawing.Point(279, 51)
        Me.kl1.Name = "kl1"
        Me.kl1.Size = New System.Drawing.Size(30, 20)
        Me.kl1.TabIndex = 6
        '
        'cbo_tipo_ref0
        '
        Me.cbo_tipo_ref0.BackColor = System.Drawing.Color.White
        Me.cbo_tipo_ref0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo_ref0.DropDownWidth = 150
        Me.cbo_tipo_ref0.FormattingEnabled = True
        Me.cbo_tipo_ref0.Location = New System.Drawing.Point(66, 120)
        Me.cbo_tipo_ref0.Name = "cbo_tipo_ref0"
        Me.cbo_tipo_ref0.Size = New System.Drawing.Size(100, 22)
        Me.cbo_tipo_ref0.TabIndex = 15
        Me.cbo_tipo_ref0.TabStop = False
        '
        'cbo_moneda1
        '
        Me.cbo_moneda1.BackColor = System.Drawing.Color.White
        Me.cbo_moneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_moneda1.DropDownWidth = 85
        Me.cbo_moneda1.FormattingEnabled = True
        Me.cbo_moneda1.Location = New System.Drawing.Point(209, 73)
        Me.cbo_moneda1.Name = "cbo_moneda1"
        Me.cbo_moneda1.Size = New System.Drawing.Size(70, 22)
        Me.cbo_moneda1.TabIndex = 10
        '
        'cbo_tipo_doc0
        '
        Me.cbo_tipo_doc0.BackColor = System.Drawing.Color.White
        Me.cbo_tipo_doc0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo_doc0.DropDownWidth = 150
        Me.cbo_tipo_doc0.FormattingEnabled = True
        Me.cbo_tipo_doc0.Location = New System.Drawing.Point(396, 51)
        Me.cbo_tipo_doc0.Name = "cbo_tipo_doc0"
        Me.cbo_tipo_doc0.Size = New System.Drawing.Size(100, 22)
        Me.cbo_tipo_doc0.TabIndex = 7
        '
        'txt_nro_doc0
        '
        Me.txt_nro_doc0.BackColor = System.Drawing.Color.White
        Me.txt_nro_doc0.Location = New System.Drawing.Point(66, 74)
        Me.txt_nro_doc0.MaxLength = 15
        Me.txt_nro_doc0.Name = "txt_nro_doc0"
        Me.txt_nro_doc0.Size = New System.Drawing.Size(100, 20)
        Me.txt_nro_doc0.TabIndex = 9
        '
        'dtp_doc0
        '
        Me.dtp_doc0.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_doc0.Location = New System.Drawing.Point(496, 51)
        Me.dtp_doc0.Name = "dtp_doc0"
        Me.dtp_doc0.Size = New System.Drawing.Size(76, 20)
        Me.dtp_doc0.TabIndex = 8
        '
        'txt_glosa0
        '
        Me.txt_glosa0.BackColor = System.Drawing.Color.White
        Me.txt_glosa0.Location = New System.Drawing.Point(65, 97)
        Me.txt_glosa0.MaxLength = 60
        Me.txt_glosa0.Name = "txt_glosa0"
        Me.txt_glosa0.Size = New System.Drawing.Size(506, 20)
        Me.txt_glosa0.TabIndex = 14
        '
        'txt_cambio0
        '
        Me.txt_cambio0.BackColor = System.Drawing.Color.White
        Me.txt_cambio0.Location = New System.Drawing.Point(302, 74)
        Me.txt_cambio0.Name = "txt_cambio0"
        Me.txt_cambio0.Size = New System.Drawing.Size(56, 20)
        Me.txt_cambio0.TabIndex = 11
        Me.txt_cambio0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(283, 76)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(25, 14)
        Me.Label34.TabIndex = 84
        Me.Label34.Text = "T.C:"
        '
        'cbo_d_h
        '
        Me.cbo_d_h.BackColor = System.Drawing.Color.White
        Me.cbo_d_h.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_d_h.FormattingEnabled = True
        Me.cbo_d_h.Items.AddRange(New Object() {"D", "H"})
        Me.cbo_d_h.Location = New System.Drawing.Point(539, 74)
        Me.cbo_d_h.Name = "cbo_d_h"
        Me.cbo_d_h.Size = New System.Drawing.Size(33, 22)
        Me.cbo_d_h.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 14)
        Me.Label11.TabIndex = 94
        Me.Label11.Text = "Cuenta"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(167, 76)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(45, 14)
        Me.Label33.TabIndex = 100
        Me.Label33.Text = "Moneda"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(364, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 14)
        Me.Label10.TabIndex = 112
        Me.Label10.Text = "Importe"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(509, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 14)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "D/H"
        '
        'txt_cod_cta0
        '
        Me.txt_cod_cta0.BackColor = System.Drawing.Color.White
        Me.txt_cod_cta0.Location = New System.Drawing.Point(66, 51)
        Me.txt_cod_cta0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_cta0.MaxLength = 8
        Me.txt_cod_cta0.Name = "txt_cod_cta0"
        Me.txt_cod_cta0.Size = New System.Drawing.Size(60, 20)
        Me.txt_cod_cta0.TabIndex = 4
        '
        'txt_imp_soles0
        '
        Me.txt_imp_soles0.BackColor = System.Drawing.Color.White
        Me.txt_imp_soles0.Location = New System.Drawing.Point(423, 76)
        Me.txt_imp_soles0.Name = "txt_imp_soles0"
        Me.txt_imp_soles0.Size = New System.Drawing.Size(83, 20)
        Me.txt_imp_soles0.TabIndex = 12
        Me.txt_imp_soles0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(6, 76)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(49, 14)
        Me.Label38.TabIndex = 92
        Me.Label38.Text = "Nro. Doc"
        '
        'txt_cod_per0
        '
        Me.txt_cod_per0.BackColor = System.Drawing.Color.White
        Me.txt_cod_per0.Location = New System.Drawing.Point(66, 28)
        Me.txt_cod_per0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_per0.MaxLength = 5
        Me.txt_cod_per0.Name = "txt_cod_per0"
        Me.txt_cod_per0.Size = New System.Drawing.Size(41, 20)
        Me.txt_cod_per0.TabIndex = 0
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(6, 100)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(35, 14)
        Me.Label36.TabIndex = 97
        Me.Label36.Text = "Glosa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 14)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Registros"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(329, 57)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(61, 14)
        Me.Label40.TabIndex = 6
        Me.Label40.Text = "Documento"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 14)
        Me.Label12.TabIndex = 85
        Me.Label12.Text = "Persona"
        '
        'txt_nro_ref0
        '
        Me.txt_nro_ref0.BackColor = System.Drawing.Color.White
        Me.txt_nro_ref0.Location = New System.Drawing.Point(237, 120)
        Me.txt_nro_ref0.Name = "txt_nro_ref0"
        Me.txt_nro_ref0.Size = New System.Drawing.Size(121, 20)
        Me.txt_nro_ref0.TabIndex = 16
        Me.txt_nro_ref0.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(173, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 14)
        Me.Label4.TabIndex = 118
        Me.Label4.Text = "Nro. Ref"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 14)
        Me.Label5.TabIndex = 116
        Me.Label5.Text = "Referencia"
        '
        'gb_doc2
        '
        Me.gb_doc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gb_doc2.Controls.Add(Me.btn_guardar)
        Me.gb_doc2.Controls.Add(Me.Button2)
        Me.gb_doc2.Controls.Add(Me.btn_modificar2)
        Me.gb_doc2.Location = New System.Drawing.Point(596, 55)
        Me.gb_doc2.Name = "gb_doc2"
        Me.gb_doc2.Size = New System.Drawing.Size(89, 73)
        Me.gb_doc2.TabIndex = 2
        Me.gb_doc2.TabStop = True
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.Location = New System.Drawing.Point(4, 4)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(78, 27)
        Me.btn_guardar.TabIndex = 4
        Me.btn_guardar.Text = "&Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(4, 37)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(78, 27)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "&Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btn_modificar2
        '
        Me.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar2.Location = New System.Drawing.Point(4, 4)
        Me.btn_modificar2.Name = "btn_modificar2"
        Me.btn_modificar2.Size = New System.Drawing.Size(78, 27)
        Me.btn_modificar2.TabIndex = 4
        Me.btn_modificar2.Text = "&Aceptar"
        Me.btn_modificar2.UseVisualStyleBackColor = True
        Me.btn_modificar2.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btn_imprimir)
        Me.Panel3.Controls.Add(Me.btn_nuevo_comp)
        Me.Panel3.Controls.Add(Me.btn_grabar_com2)
        Me.Panel3.Controls.Add(Me.Label67)
        Me.Panel3.Controls.Add(Me.btn_grabar_com)
        Me.Panel3.Controls.Add(Me.btn_cancelar_com)
        Me.Panel3.Location = New System.Drawing.Point(332, 338)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(354, 53)
        Me.Panel3.TabIndex = 131
        Me.Panel3.TabStop = True
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Enabled = False
        Me.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir.Location = New System.Drawing.Point(171, 14)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(80, 27)
        Me.btn_imprimir.TabIndex = 2
        Me.btn_imprimir.Text = "&Imprimir"
        Me.btn_imprimir.UseVisualStyleBackColor = True
        '
        'btn_nuevo_comp
        '
        Me.btn_nuevo_comp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo_comp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo_comp.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo_comp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo_comp.Location = New System.Drawing.Point(89, 14)
        Me.btn_nuevo_comp.Name = "btn_nuevo_comp"
        Me.btn_nuevo_comp.Size = New System.Drawing.Size(80, 27)
        Me.btn_nuevo_comp.TabIndex = 1
        Me.btn_nuevo_comp.Text = "&Nuevo"
        Me.btn_nuevo_comp.UseVisualStyleBackColor = True
        '
        'btn_grabar_com2
        '
        Me.btn_grabar_com2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_grabar_com2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_grabar_com2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_grabar_com2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_grabar_com2.Location = New System.Drawing.Point(5, 13)
        Me.btn_grabar_com2.Name = "btn_grabar_com2"
        Me.btn_grabar_com2.Size = New System.Drawing.Size(80, 27)
        Me.btn_grabar_com2.TabIndex = 0
        Me.btn_grabar_com2.Text = "&Grabar"
        Me.btn_grabar_com2.UseVisualStyleBackColor = True
        Me.btn_grabar_com2.Visible = False
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(153, 0)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(83, 14)
        Me.Label67.TabIndex = 68
        Me.Label67.Text = "Comprobante"
        '
        'btn_grabar_com
        '
        Me.btn_grabar_com.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_grabar_com.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_grabar_com.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_grabar_com.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_grabar_com.Location = New System.Drawing.Point(5, 14)
        Me.btn_grabar_com.Name = "btn_grabar_com"
        Me.btn_grabar_com.Size = New System.Drawing.Size(80, 27)
        Me.btn_grabar_com.TabIndex = 50
        Me.btn_grabar_com.Text = "&Grabar"
        Me.btn_grabar_com.UseVisualStyleBackColor = True
        '
        'btn_cancelar_com
        '
        Me.btn_cancelar_com.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar_com.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar_com.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar_com.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar_com.Location = New System.Drawing.Point(257, 14)
        Me.btn_cancelar_com.Name = "btn_cancelar_com"
        Me.btn_cancelar_com.Size = New System.Drawing.Size(80, 27)
        Me.btn_cancelar_com.TabIndex = 3
        Me.btn_cancelar_com.Text = "&Cancelar"
        Me.btn_cancelar_com.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txt_debe)
        Me.GroupBox1.Controls.Add(Me.txt_haber)
        Me.GroupBox1.Controls.Add(Me.txt_debe2)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txt_haber2)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 310)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(221, 82)
        Me.GroupBox1.TabIndex = 130
        Me.GroupBox1.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(159, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 14)
        Me.Label15.TabIndex = 124
        Me.Label15.Text = "Haber"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 14)
        Me.Label9.TabIndex = 119
        Me.Label9.Text = "Soles"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(7, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 14)
        Me.Label13.TabIndex = 120
        Me.Label13.Text = "Dólares"
        '
        'txt_debe
        '
        Me.txt_debe.BackColor = System.Drawing.SystemColors.Window
        Me.txt_debe.Location = New System.Drawing.Point(64, 27)
        Me.txt_debe.Name = "txt_debe"
        Me.txt_debe.ReadOnly = True
        Me.txt_debe.Size = New System.Drawing.Size(72, 20)
        Me.txt_debe.TabIndex = 121
        Me.txt_debe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_haber
        '
        Me.txt_haber.BackColor = System.Drawing.SystemColors.Window
        Me.txt_haber.Location = New System.Drawing.Point(138, 27)
        Me.txt_haber.Name = "txt_haber"
        Me.txt_haber.ReadOnly = True
        Me.txt_haber.Size = New System.Drawing.Size(75, 20)
        Me.txt_haber.TabIndex = 122
        Me.txt_haber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_debe2
        '
        Me.txt_debe2.BackColor = System.Drawing.SystemColors.Window
        Me.txt_debe2.Location = New System.Drawing.Point(64, 52)
        Me.txt_debe2.Name = "txt_debe2"
        Me.txt_debe2.ReadOnly = True
        Me.txt_debe2.Size = New System.Drawing.Size(72, 20)
        Me.txt_debe2.TabIndex = 126
        Me.txt_debe2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(85, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 14)
        Me.Label14.TabIndex = 123
        Me.Label14.Text = "Debe"
        '
        'txt_haber2
        '
        Me.txt_haber2.BackColor = System.Drawing.SystemColors.Window
        Me.txt_haber2.Location = New System.Drawing.Point(138, 52)
        Me.txt_haber2.Name = "txt_haber2"
        Me.txt_haber2.ReadOnly = True
        Me.txt_haber2.Size = New System.Drawing.Size(75, 20)
        Me.txt_haber2.TabIndex = 125
        Me.txt_haber2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(614, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 14)
        Me.Label6.TabIndex = 129
        Me.Label6.Text = "Registros"
        '
        'Panel_doc2
        '
        Me.Panel_doc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_doc2.Controls.Add(Me.btn_mod)
        Me.Panel_doc2.Controls.Add(Me.btn_nuevo_det)
        Me.Panel_doc2.Controls.Add(Me.btn_eliminar2)
        Me.Panel_doc2.Location = New System.Drawing.Point(600, 84)
        Me.Panel_doc2.Name = "Panel_doc2"
        Me.Panel_doc2.Size = New System.Drawing.Size(88, 102)
        Me.Panel_doc2.TabIndex = 1
        Me.Panel_doc2.TabStop = True
        '
        'btn_mod
        '
        Me.btn_mod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_mod.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mod.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_mod.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_mod.Location = New System.Drawing.Point(3, 36)
        Me.btn_mod.Name = "btn_mod"
        Me.btn_mod.Size = New System.Drawing.Size(78, 27)
        Me.btn_mod.TabIndex = 1
        Me.btn_mod.Text = "&Modificar"
        Me.btn_mod.UseVisualStyleBackColor = True
        '
        'btn_nuevo_det
        '
        Me.btn_nuevo_det.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo_det.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo_det.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo_det.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo_det.Location = New System.Drawing.Point(3, 3)
        Me.btn_nuevo_det.Name = "btn_nuevo_det"
        Me.btn_nuevo_det.Size = New System.Drawing.Size(78, 27)
        Me.btn_nuevo_det.TabIndex = 0
        Me.btn_nuevo_det.Text = "&Nuevo"
        Me.btn_nuevo_det.UseVisualStyleBackColor = True
        '
        'btn_eliminar2
        '
        Me.btn_eliminar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_eliminar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar2.Location = New System.Drawing.Point(3, 69)
        Me.btn_eliminar2.Name = "btn_eliminar2"
        Me.btn_eliminar2.Size = New System.Drawing.Size(78, 27)
        Me.btn_eliminar2.TabIndex = 2
        Me.btn_eliminar2.Text = "&Eliminar"
        Me.btn_eliminar2.UseVisualStyleBackColor = True
        '
        'g_cab
        '
        Me.g_cab.Controls.Add(Me.cbo_aux)
        Me.g_cab.Controls.Add(Me.dtp_com)
        Me.g_cab.Controls.Add(Me.cbo_com)
        Me.g_cab.Controls.Add(Me.Label35)
        Me.g_cab.Controls.Add(Me.txt_nro_comp)
        Me.g_cab.Controls.Add(Me.Label29)
        Me.g_cab.Controls.Add(Me.Label2)
        Me.g_cab.Controls.Add(Me.Label7)
        Me.g_cab.Controls.Add(Me.Label8)
        Me.g_cab.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.g_cab.ForeColor = System.Drawing.SystemColors.ControlText
        Me.g_cab.Location = New System.Drawing.Point(5, 3)
        Me.g_cab.Margin = New System.Windows.Forms.Padding(0)
        Me.g_cab.Name = "g_cab"
        Me.g_cab.Padding = New System.Windows.Forms.Padding(0)
        Me.g_cab.Size = New System.Drawing.Size(683, 49)
        Me.g_cab.TabIndex = 0
        Me.g_cab.TabStop = False
        Me.g_cab.Text = "Comprobante"
        '
        'cbo_aux
        '
        Me.cbo_aux.BackColor = System.Drawing.Color.White
        Me.cbo_aux.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_aux.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_aux.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_aux.FormattingEnabled = True
        Me.cbo_aux.Location = New System.Drawing.Point(50, 19)
        Me.cbo_aux.MaxDropDownItems = 9
        Me.cbo_aux.Name = "cbo_aux"
        Me.cbo_aux.Size = New System.Drawing.Size(171, 22)
        Me.cbo_aux.TabIndex = 0
        '
        'dtp_com
        '
        Me.dtp_com.CalendarForeColor = System.Drawing.SystemColors.Desktop
        Me.dtp_com.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaptionText
        Me.dtp_com.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_com.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_com.Location = New System.Drawing.Point(594, 22)
        Me.dtp_com.Name = "dtp_com"
        Me.dtp_com.Size = New System.Drawing.Size(77, 20)
        Me.dtp_com.TabIndex = 3
        '
        'cbo_com
        '
        Me.cbo_com.BackColor = System.Drawing.Color.White
        Me.cbo_com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_com.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_com.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_com.FormattingEnabled = True
        Me.cbo_com.Location = New System.Drawing.Point(296, 19)
        Me.cbo_com.MaxDropDownItems = 10
        Me.cbo_com.Name = "cbo_com"
        Me.cbo_com.Size = New System.Drawing.Size(183, 22)
        Me.cbo_com.TabIndex = 1
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(10, 22)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(43, 14)
        Me.Label35.TabIndex = 22
        Me.Label35.Text = "Auxiliar"
        '
        'txt_nro_comp
        '
        Me.txt_nro_comp.BackColor = System.Drawing.Color.White
        Me.txt_nro_comp.Enabled = False
        Me.txt_nro_comp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_comp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_nro_comp.Location = New System.Drawing.Point(500, 22)
        Me.txt_nro_comp.MaxLength = 4
        Me.txt_nro_comp.Name = "txt_nro_comp"
        Me.txt_nro_comp.Size = New System.Drawing.Size(47, 20)
        Me.txt_nro_comp.TabIndex = 2
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(482, 25)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(19, 14)
        Me.Label29.TabIndex = 20
        Me.Label29.Text = "Nº"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(224, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 14)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Comprobante"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(553, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 14)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Fecha "
        '
        'dgw_mov1
        '
        Me.dgw_mov1.AllowUserToAddRows = False
        Me.dgw_mov1.AllowUserToDeleteRows = False
        Me.dgw_mov1.AllowUserToOrderColumns = True
        Me.dgw_mov1.AllowUserToResizeRows = False
        Me.dgw_mov1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_mov1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgw_mov1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_mov1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column22, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16})
        Me.dgw_mov1.Location = New System.Drawing.Point(2, 65)
        Me.dgw_mov1.MultiSelect = False
        Me.dgw_mov1.Name = "dgw_mov1"
        Me.dgw_mov1.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgw_mov1.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgw_mov1.RowHeadersWidth = 25
        Me.dgw_mov1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_mov1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_mov1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_mov1.Size = New System.Drawing.Size(593, 240)
        Me.dgw_mov1.TabIndex = 0
        Me.dgw_mov1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(8, 594)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(25, 54)
        Me.GroupBox3.TabIndex = 104
        Me.GroupBox3.TabStop = False
        '
        'btnImportarExcel
        '
        Me.btnImportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportarExcel.Location = New System.Drawing.Point(607, 203)
        Me.btnImportarExcel.Name = "btnImportarExcel"
        Me.btnImportarExcel.Size = New System.Drawing.Size(75, 39)
        Me.btnImportarExcel.TabIndex = 133
        Me.btnImportarExcel.Text = "Importar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Excel"
        Me.btnImportarExcel.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(368, 121)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 28)
        Me.Label17.TabIndex = 119
        Me.Label17.Text = "Fecha" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Vencimiento"
        '
        'dtpFechaVen
        '
        Me.dtpFechaVen.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaVen.Location = New System.Drawing.Point(445, 125)
        Me.dtpFechaVen.Name = "dtpFechaVen"
        Me.dtpFechaVen.Size = New System.Drawing.Size(75, 20)
        Me.dtpFechaVen.TabIndex = 120
        '
        'Column1
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.FillWeight = 80.0!
        Me.Column1.HeaderText = "Cuenta"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 70
        '
        'Column2
        '
        Me.Column2.HeaderText = "Glosa"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 190
        '
        'Column3
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column3.HeaderText = "Soles"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 90
        '
        'Column22
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Column22.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column22.HeaderText = "Dolares"
        Me.Column22.Name = "Column22"
        Me.Column22.ReadOnly = True
        Me.Column22.Width = 90
        '
        'Column4
        '
        Me.Column4.HeaderText = "D/H"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 35
        '
        'Column5
        '
        Me.Column5.HeaderText = "Mon"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 35
        '
        'Column6
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N4"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column6.HeaderText = "T.C."
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 60
        '
        'Column7
        '
        Me.Column7.HeaderText = "Doc"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 35
        '
        'Column8
        '
        Me.Column8.HeaderText = "Nro Doc"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 90
        '
        'Column9
        '
        DataGridViewCellStyle7.Format = "d"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column9.HeaderText = "Fecha"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 75
        '
        'Column10
        '
        Me.Column10.HeaderText = "Cod"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 55
        '
        'Column11
        '
        Me.Column11.HeaderText = "Nombre"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 250
        '
        'Column12
        '
        Me.Column12.HeaderText = "Ruc/Dni"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 90
        '
        'Column13
        '
        Me.Column13.HeaderText = "Ref"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Width = 35
        '
        'Column14
        '
        Me.Column14.HeaderText = "Nro Ref"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.Width = 85
        '
        'Column15
        '
        Me.Column15.HeaderText = "Impdoc"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Visible = False
        '
        'Column16
        '
        DataGridViewCellStyle8.Format = "d"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Column16.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column16.HeaderText = "Fecha Ven."
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'CXP_INGRESO_ANA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 425)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CXP_INGRESO_ANA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de Documentos (Cuentas por Pagar)"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel_doc.ResumeLayout(False)
        Me.Panel_doc.PerformLayout()
        Me.Panel_CXP.ResumeLayout(False)
        CType(Me.dgw_per, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_cta.ResumeLayout(False)
        CType(Me.dgw_cuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.g_doc.ResumeLayout(False)
        Me.g_doc.PerformLayout()
        Me.gb_doc2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel_doc2.ResumeLayout(False)
        Me.g_cab.ResumeLayout(False)
        Me.g_cab.PerformLayout()
        CType(Me.dgw_mov1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_cancelar_com As Button
    Friend WithEvents btn_consultar As Button
    Friend WithEvents btn_eliminar As Button
    Friend WithEvents btn_eliminar2 As Button
    Friend WithEvents btn_grabar_com As Button
    Friend WithEvents btn_grabar_com2 As Button
    Friend WithEvents btn_guardar As Button
    Friend WithEvents btn_imprimir As Button
    Friend WithEvents btn_mod As Button
    Friend WithEvents btn_modificar As Button
    Friend WithEvents btn_modificar2 As Button
    Friend WithEvents btn_nuevo As Button
    Friend WithEvents btn_nuevo_comp As Button
    Friend WithEvents btn_nuevo_det As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents cbo_aux As ComboBox
    Friend WithEvents cbo_com As ComboBox
    Friend WithEvents cbo_d_h As ComboBox
    Friend WithEvents cbo_moneda1 As ComboBox
    Friend WithEvents cbo_tipo_doc0 As ComboBox
    Friend WithEvents cbo_tipo_ref0 As ComboBox
    Friend WithEvents dgw_cuenta As DataGridView
    Friend WithEvents dgw_mov1 As DataGridView
    Friend WithEvents dgw_per As DataGridView
    Friend WithEvents dgw1 As DataGridView
    Friend WithEvents dtp_com As DateTimePicker
    Friend WithEvents dtp_doc0 As DateTimePicker
    Friend WithEvents g_cab As GroupBox
    Friend WithEvents g_doc As GroupBox
    Friend WithEvents gb_doc2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents item As TextBox
    Friend WithEvents kl1 As TextBox
    Friend WithEvents kl2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label67 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel_cta As Panel
    Friend WithEvents Panel_CXP As Panel
    Friend WithEvents Panel_doc As Panel
    Friend WithEvents Panel_doc2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txt_cambio0 As TextBox
    Friend WithEvents txt_cod_cta0 As TextBox
    Friend WithEvents txt_cod_per0 As TextBox
    Friend WithEvents txt_debe As TextBox
    Friend WithEvents txt_debe2 As TextBox
    Friend WithEvents txt_desc_cta0 As TextBox
    Friend WithEvents txt_desc_per0 As TextBox
    Friend WithEvents txt_glosa0 As TextBox
    Friend WithEvents txt_haber As TextBox
    Friend WithEvents txt_haber2 As TextBox
    Friend WithEvents txt_imp_soles0 As TextBox
    Friend WithEvents txt_nro_comp As TextBox
    Friend WithEvents txt_nro_doc_per0 As TextBox
    Friend WithEvents txt_nro_doc0 As TextBox
    Friend WithEvents txt_nro_ref0 As TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbo_mes1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnImportarExcel As System.Windows.Forms.Button
    Friend WithEvents dtpFechaVen As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
