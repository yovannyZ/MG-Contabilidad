Imports System.ComponentModel
Imports System.Drawing.Point



<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CONSULTA_TCON_ACTUALIZA
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
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbo_año2 = New System.Windows.Forms.ComboBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.ch_com2 = New System.Windows.Forms.CheckBox
        Me.cbo_comprobante2 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.CH_AUX2 = New System.Windows.Forms.CheckBox
        Me.txt_desc_cta = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_cta = New System.Windows.Forms.TextBox
        Me.btn_consulta2 = New System.Windows.Forms.Button
        Me.cbo_auxiliar2 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbo_mes2 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.KL1 = New System.Windows.Forms.TextBox
        Me.Panel_cta = New System.Windows.Forms.Panel
        Me.dgw_cta = New System.Windows.Forms.DataGridView
        Me.BTN_LIMP2 = New System.Windows.Forms.Button
        Me.btn_cancelar2 = New System.Windows.Forms.Button
        Me.dgw2 = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column26 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column27 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column28 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column29 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column30 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column31 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column32 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column33 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel_cta02 = New System.Windows.Forms.Panel
        Me.btn_sgt_cta2 = New System.Windows.Forms.Button
        Me.btn_cad_cta2 = New System.Windows.Forms.Button
        Me.dgw_cta02 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.NRO_DOC2 = New System.Windows.Forms.TextBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.PANEL_PER2 = New System.Windows.Forms.Panel
        Me.DGW_PER2 = New System.Windows.Forms.DataGridView
        Me.TXT_DESC2 = New System.Windows.Forms.TextBox
        Me.txt_doc_per2 = New System.Windows.Forms.TextBox
        Me.TXT_COD2 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txt_importe22 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_importe12 = New System.Windows.Forms.TextBox
        Me.ch_ana2 = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.txt_destino2 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_enlace2 = New System.Windows.Forms.TextBox
        Me.ch_auto2 = New System.Windows.Forms.CheckBox
        Me.dtp_ref2 = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbo_tipo_ref2 = New System.Windows.Forms.ComboBox
        Me.txt_nro_ref2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ch_rep2 = New System.Windows.Forms.CheckBox
        Me.Label76 = New System.Windows.Forms.Label
        Me.btn_req2 = New System.Windows.Forms.Button
        Me.cbo_act02 = New System.Windows.Forms.ComboBox
        Me.txt_nro_req2 = New System.Windows.Forms.TextBox
        Me.Label77 = New System.Windows.Forms.Label
        Me.btn_lim2 = New System.Windows.Forms.Button
        Me.ch_cta2 = New System.Windows.Forms.CheckBox
        Me.txt_desc_cta02 = New System.Windows.Forms.TextBox
        Me.btn_mod22 = New System.Windows.Forms.Button
        Me.Button22 = New System.Windows.Forms.Button
        Me.TXT_GLOSA2 = New System.Windows.Forms.TextBox
        Me.KL01 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.CBO_PROYECTO02 = New System.Windows.Forms.ComboBox
        Me.CBO_CC02 = New System.Windows.Forms.ComboBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.txt_cta02 = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.BTN_MOD21 = New System.Windows.Forms.Button
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.btn_buscar2 = New System.Windows.Forms.Button
        Me.txt_letra2 = New System.Windows.Forms.TextBox
        Me.GroupBox2.SuspendLayout()
        Me.Panel_cta.SuspendLayout()
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgw2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel_cta02.SuspendLayout()
        CType(Me.dgw_cta02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.PANEL_PER2.SuspendLayout()
        CType(Me.DGW_PER2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbo_año2)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.ch_com2)
        Me.GroupBox2.Controls.Add(Me.cbo_comprobante2)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.CH_AUX2)
        Me.GroupBox2.Controls.Add(Me.txt_desc_cta)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txt_cta)
        Me.GroupBox2.Controls.Add(Me.btn_consulta2)
        Me.GroupBox2.Controls.Add(Me.cbo_auxiliar2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cbo_mes2)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.KL1)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(663, 98)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Consulta"
        '
        'cbo_año2
        '
        Me.cbo_año2.BackColor = System.Drawing.Color.White
        Me.cbo_año2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_año2.FormattingEnabled = True
        Me.cbo_año2.Location = New System.Drawing.Point(384, 23)
        Me.cbo_año2.Name = "cbo_año2"
        Me.cbo_año2.Size = New System.Drawing.Size(108, 22)
        Me.cbo_año2.TabIndex = 154
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(351, 27)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(27, 14)
        Me.Label28.TabIndex = 155
        Me.Label28.Text = "Año"
        '
        'ch_com2
        '
        Me.ch_com2.AutoSize = True
        Me.ch_com2.BackColor = System.Drawing.SystemColors.Control
        Me.ch_com2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch_com2.Location = New System.Drawing.Point(94, 51)
        Me.ch_com2.Name = "ch_com2"
        Me.ch_com2.Size = New System.Drawing.Size(15, 14)
        Me.ch_com2.TabIndex = 149
        Me.ch_com2.UseVisualStyleBackColor = False
        '
        'cbo_comprobante2
        '
        Me.cbo_comprobante2.BackColor = System.Drawing.Color.White
        Me.cbo_comprobante2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_comprobante2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_comprobante2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_comprobante2.FormattingEnabled = True
        Me.cbo_comprobante2.Location = New System.Drawing.Point(115, 47)
        Me.cbo_comprobante2.MaxDropDownItems = 10
        Me.cbo_comprobante2.Name = "cbo_comprobante2"
        Me.cbo_comprobante2.Size = New System.Drawing.Size(230, 22)
        Me.cbo_comprobante2.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 14)
        Me.Label7.TabIndex = 147
        Me.Label7.Text = "Comprobante"
        '
        'CH_AUX2
        '
        Me.CH_AUX2.AutoSize = True
        Me.CH_AUX2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CH_AUX2.Location = New System.Drawing.Point(94, 27)
        Me.CH_AUX2.Name = "CH_AUX2"
        Me.CH_AUX2.Size = New System.Drawing.Size(15, 14)
        Me.CH_AUX2.TabIndex = 138
        Me.CH_AUX2.UseVisualStyleBackColor = True
        '
        'txt_desc_cta
        '
        Me.txt_desc_cta.BackColor = System.Drawing.Color.White
        Me.txt_desc_cta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_cta.Location = New System.Drawing.Point(176, 72)
        Me.txt_desc_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_cta.Name = "txt_desc_cta"
        Me.txt_desc_cta.Size = New System.Drawing.Size(316, 20)
        Me.txt_desc_cta.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(18, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 14)
        Me.Label10.TabIndex = 67
        Me.Label10.Text = "Cuenta"
        '
        'txt_cta
        '
        Me.txt_cta.BackColor = System.Drawing.Color.White
        Me.txt_cta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cta.Location = New System.Drawing.Point(115, 72)
        Me.txt_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cta.MaxLength = 8
        Me.txt_cta.Name = "txt_cta"
        Me.txt_cta.Size = New System.Drawing.Size(61, 20)
        Me.txt_cta.TabIndex = 4
        '
        'btn_consulta2
        '
        Me.btn_consulta2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_consulta2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_consulta2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Search_1
        Me.btn_consulta2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consulta2.Location = New System.Drawing.Point(532, 39)
        Me.btn_consulta2.Name = "btn_consulta2"
        Me.btn_consulta2.Size = New System.Drawing.Size(77, 26)
        Me.btn_consulta2.TabIndex = 7
        Me.btn_consulta2.Text = "&Consulta"
        Me.btn_consulta2.UseVisualStyleBackColor = True
        '
        'cbo_auxiliar2
        '
        Me.cbo_auxiliar2.BackColor = System.Drawing.Color.White
        Me.cbo_auxiliar2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_auxiliar2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_auxiliar2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_auxiliar2.FormattingEnabled = True
        Me.cbo_auxiliar2.Location = New System.Drawing.Point(115, 23)
        Me.cbo_auxiliar2.MaxDropDownItems = 9
        Me.cbo_auxiliar2.Name = "cbo_auxiliar2"
        Me.cbo_auxiliar2.Size = New System.Drawing.Size(230, 22)
        Me.cbo_auxiliar2.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 14)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Auxiliar"
        '
        'cbo_mes2
        '
        Me.cbo_mes2.BackColor = System.Drawing.Color.White
        Me.cbo_mes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_mes2.FormattingEnabled = True
        Me.cbo_mes2.Items.AddRange(New Object() {"INICIO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.cbo_mes2.Location = New System.Drawing.Point(384, 47)
        Me.cbo_mes2.Name = "cbo_mes2"
        Me.cbo_mes2.Size = New System.Drawing.Size(108, 22)
        Me.cbo_mes2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(351, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 14)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Mes"
        '
        'KL1
        '
        Me.KL1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KL1.Location = New System.Drawing.Point(455, 72)
        Me.KL1.Margin = New System.Windows.Forms.Padding(0)
        Me.KL1.MaxLength = 8
        Me.KL1.Name = "KL1"
        Me.KL1.Size = New System.Drawing.Size(10, 20)
        Me.KL1.TabIndex = 6
        '
        'Panel_cta
        '
        Me.Panel_cta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_cta.Controls.Add(Me.dgw_cta)
        Me.Panel_cta.Location = New System.Drawing.Point(12, 101)
        Me.Panel_cta.Name = "Panel_cta"
        Me.Panel_cta.Size = New System.Drawing.Size(518, 121)
        Me.Panel_cta.TabIndex = 68
        Me.Panel_cta.Visible = False
        '
        'dgw_cta
        '
        Me.dgw_cta.AllowUserToAddRows = False
        Me.dgw_cta.AllowUserToDeleteRows = False
        Me.dgw_cta.AllowUserToOrderColumns = True
        Me.dgw_cta.AllowUserToResizeRows = False
        Me.dgw_cta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_cta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_cta.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cta.Location = New System.Drawing.Point(114, 0)
        Me.dgw_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta.MultiSelect = False
        Me.dgw_cta.Name = "dgw_cta"
        Me.dgw_cta.ReadOnly = True
        Me.dgw_cta.RowHeadersWidth = 25
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta.Size = New System.Drawing.Size(377, 116)
        Me.dgw_cta.TabIndex = 55
        '
        'BTN_LIMP2
        '
        Me.BTN_LIMP2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_LIMP2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_LIMP2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.BTN_LIMP2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_LIMP2.Location = New System.Drawing.Point(509, 121)
        Me.BTN_LIMP2.Name = "BTN_LIMP2"
        Me.BTN_LIMP2.Size = New System.Drawing.Size(77, 26)
        Me.BTN_LIMP2.TabIndex = 150
        Me.BTN_LIMP2.Text = "&Limpiar"
        Me.BTN_LIMP2.UseVisualStyleBackColor = True
        '
        'btn_cancelar2
        '
        Me.btn_cancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar2.Location = New System.Drawing.Point(592, 121)
        Me.btn_cancelar2.Name = "btn_cancelar2"
        Me.btn_cancelar2.Size = New System.Drawing.Size(77, 26)
        Me.btn_cancelar2.TabIndex = 8
        Me.btn_cancelar2.TabStop = False
        Me.btn_cancelar2.Text = "&Salir"
        Me.btn_cancelar2.UseVisualStyleBackColor = True
        '
        'dgw2
        '
        Me.dgw2.AllowUserToAddRows = False
        Me.dgw2.AllowUserToDeleteRows = False
        Me.dgw2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.dgw2.BackgroundColor = System.Drawing.Color.White
        Me.dgw2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column25, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column22, Me.Column23, Me.Column17, Me.Column18, Me.Column19, Me.Column20, Me.Column24, Me.Column21, Me.Column26, Me.Column27, Me.Column28, Me.Column29, Me.Column30, Me.Column31, Me.Column32, Me.Column33})
        Me.dgw2.Location = New System.Drawing.Point(0, 170)
        Me.dgw2.Name = "dgw2"
        Me.dgw2.RowHeadersWidth = 25
        DataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw2.RowsDefaultCellStyle = DataGridViewCellStyle39
        Me.dgw2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw2.Size = New System.Drawing.Size(686, 308)
        Me.dgw2.TabIndex = 21
        '
        'Column1
        '
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle27
        Me.Column1.HeaderText = "Doc"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 30
        '
        'Column2
        '
        Me.Column2.HeaderText = "Nº Doc."
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 75
        '
        'Column3
        '
        Me.Column3.HeaderText = "Glosa"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 172
        '
        'Column4
        '
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle28.Format = "n2"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle28
        Me.Column4.HeaderText = "S/.Debe"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 70
        '
        'Column5
        '
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle29.Format = "n2"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle29
        Me.Column5.HeaderText = "S/.Haber"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 70
        '
        'Column6
        '
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle30.Format = "n2"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle30
        Me.Column6.HeaderText = "$/.Debe"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 70
        '
        'Column7
        '
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle31.Format = "n2"
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle31
        Me.Column7.HeaderText = "$/.Haber"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 70
        '
        'Column8
        '
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle32
        Me.Column8.HeaderText = "Mo."
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 30
        '
        'Column9
        '
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle33.Format = "d"
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle33
        Me.Column9.HeaderText = "Fecha"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 70
        '
        'Column10
        '
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle34
        Me.Column10.HeaderText = "T.C."
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 70
        '
        'Column11
        '
        Me.Column11.HeaderText = "Cta.Cte."
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 50
        '
        'Column25
        '
        Me.Column25.HeaderText = "Razon Social"
        Me.Column25.Name = "Column25"
        Me.Column25.ReadOnly = True
        Me.Column25.Width = 180
        '
        'Column12
        '
        Me.Column12.HeaderText = "Ruc."
        Me.Column12.Name = "Column12"
        '
        'Column13
        '
        Me.Column13.HeaderText = "Ref."
        Me.Column13.Name = "Column13"
        Me.Column13.Width = 30
        '
        'Column14
        '
        Me.Column14.HeaderText = "Nº Ref."
        Me.Column14.Name = "Column14"
        '
        'Column15
        '
        Me.Column15.HeaderText = "CC."
        Me.Column15.Name = "Column15"
        Me.Column15.Width = 45
        '
        'Column16
        '
        Me.Column16.HeaderText = "Control"
        Me.Column16.Name = "Column16"
        '
        'Column22
        '
        Me.Column22.HeaderText = "Proyecto"
        Me.Column22.Name = "Column22"
        Me.Column22.ReadOnly = True
        '
        'Column23
        '
        Me.Column23.HeaderText = "Act."
        Me.Column23.Name = "Column23"
        Me.Column23.ReadOnly = True
        '
        'Column17
        '
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column17.DefaultCellStyle = DataGridViewCellStyle35
        Me.Column17.HeaderText = "Aux."
        Me.Column17.Name = "Column17"
        Me.Column17.Width = 30
        '
        'Column18
        '
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column18.DefaultCellStyle = DataGridViewCellStyle36
        Me.Column18.HeaderText = "Comp."
        Me.Column18.Name = "Column18"
        Me.Column18.Width = 45
        '
        'Column19
        '
        Me.Column19.HeaderText = "NºComp."
        Me.Column19.Name = "Column19"
        Me.Column19.Width = 45
        '
        'Column20
        '
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle37.Format = "d"
        Me.Column20.DefaultCellStyle = DataGridViewCellStyle37
        Me.Column20.HeaderText = "Fec. Com."
        Me.Column20.Name = "Column20"
        Me.Column20.Width = 70
        '
        'Column24
        '
        Me.Column24.HeaderText = "Item"
        Me.Column24.Name = "Column24"
        Me.Column24.ReadOnly = True
        Me.Column24.Width = 40
        '
        'Column21
        '
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column21.DefaultCellStyle = DataGridViewCellStyle38
        Me.Column21.HeaderText = "Trans."
        Me.Column21.Name = "Column21"
        Me.Column21.Width = 40
        '
        'Column26
        '
        Me.Column26.HeaderText = "Rep"
        Me.Column26.Name = "Column26"
        Me.Column26.ReadOnly = True
        Me.Column26.Width = 30
        '
        'Column27
        '
        Me.Column27.HeaderText = "COD REF"
        Me.Column27.Name = "Column27"
        Me.Column27.Visible = False
        '
        'Column28
        '
        Me.Column28.HeaderText = "Nº REF"
        Me.Column28.Name = "Column28"
        Me.Column28.Visible = False
        '
        'Column29
        '
        Me.Column29.HeaderText = "FECHA REF"
        Me.Column29.Name = "Column29"
        Me.Column29.Visible = False
        '
        'Column30
        '
        Me.Column30.HeaderText = "Auto"
        Me.Column30.Name = "Column30"
        Me.Column30.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column30.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column30.Width = 35
        '
        'Column31
        '
        Me.Column31.HeaderText = "Enlace"
        Me.Column31.Name = "Column31"
        '
        'Column32
        '
        Me.Column32.HeaderText = "Destino"
        Me.Column32.Name = "Column32"
        '
        'Column33
        '
        Me.Column33.HeaderText = "Ana"
        Me.Column33.Name = "Column33"
        Me.Column33.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column33.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column33.Width = 35
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel_cta02)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Location = New System.Drawing.Point(0, 170)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(686, 377)
        Me.Panel2.TabIndex = 69
        Me.Panel2.Visible = False
        '
        'Panel_cta02
        '
        Me.Panel_cta02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_cta02.Controls.Add(Me.btn_sgt_cta2)
        Me.Panel_cta02.Controls.Add(Me.btn_cad_cta2)
        Me.Panel_cta02.Controls.Add(Me.dgw_cta02)
        Me.Panel_cta02.Location = New System.Drawing.Point(18, 50)
        Me.Panel_cta02.Name = "Panel_cta02"
        Me.Panel_cta02.Size = New System.Drawing.Size(523, 138)
        Me.Panel_cta02.TabIndex = 92
        Me.Panel_cta02.Visible = False
        '
        'btn_sgt_cta2
        '
        Me.btn_sgt_cta2.Enabled = False
        Me.btn_sgt_cta2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_sgt_cta2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Next_set_2_1
        Me.btn_sgt_cta2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_sgt_cta2.Location = New System.Drawing.Point(3, 29)
        Me.btn_sgt_cta2.Name = "btn_sgt_cta2"
        Me.btn_sgt_cta2.Size = New System.Drawing.Size(64, 24)
        Me.btn_sgt_cta2.TabIndex = 63
        Me.btn_sgt_cta2.Text = "&Sgte."
        Me.btn_sgt_cta2.UseVisualStyleBackColor = True
        '
        'btn_cad_cta2
        '
        Me.btn_cad_cta2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cad_cta2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cad_cta2.Location = New System.Drawing.Point(3, 4)
        Me.btn_cad_cta2.Name = "btn_cad_cta2"
        Me.btn_cad_cta2.Size = New System.Drawing.Size(64, 24)
        Me.btn_cad_cta2.TabIndex = 62
        Me.btn_cad_cta2.Text = "&Cadena"
        Me.btn_cad_cta2.UseVisualStyleBackColor = True
        '
        'dgw_cta02
        '
        Me.dgw_cta02.AllowUserToAddRows = False
        Me.dgw_cta02.AllowUserToDeleteRows = False
        Me.dgw_cta02.AllowUserToOrderColumns = True
        Me.dgw_cta02.AllowUserToResizeRows = False
        Me.dgw_cta02.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_cta02.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_cta02.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cta02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cta02.Location = New System.Drawing.Point(78, 1)
        Me.dgw_cta02.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta02.MultiSelect = False
        Me.dgw_cta02.Name = "dgw_cta02"
        Me.dgw_cta02.ReadOnly = True
        Me.dgw_cta02.RowHeadersWidth = 25
        Me.dgw_cta02.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta02.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta02.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta02.Size = New System.Drawing.Size(424, 128)
        Me.dgw_cta02.TabIndex = 30
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NRO_DOC2)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.PANEL_PER2)
        Me.GroupBox1.Controls.Add(Me.TXT_DESC2)
        Me.GroupBox1.Controls.Add(Me.txt_doc_per2)
        Me.GroupBox1.Controls.Add(Me.TXT_COD2)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.ch_ana2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.txt_destino2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_enlace2)
        Me.GroupBox1.Controls.Add(Me.ch_auto2)
        Me.GroupBox1.Controls.Add(Me.dtp_ref2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbo_tipo_ref2)
        Me.GroupBox1.Controls.Add(Me.txt_nro_ref2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ch_rep2)
        Me.GroupBox1.Controls.Add(Me.Label76)
        Me.GroupBox1.Controls.Add(Me.btn_req2)
        Me.GroupBox1.Controls.Add(Me.cbo_act02)
        Me.GroupBox1.Controls.Add(Me.txt_nro_req2)
        Me.GroupBox1.Controls.Add(Me.Label77)
        Me.GroupBox1.Controls.Add(Me.btn_lim2)
        Me.GroupBox1.Controls.Add(Me.ch_cta2)
        Me.GroupBox1.Controls.Add(Me.txt_desc_cta02)
        Me.GroupBox1.Controls.Add(Me.btn_mod22)
        Me.GroupBox1.Controls.Add(Me.Button22)
        Me.GroupBox1.Controls.Add(Me.TXT_GLOSA2)
        Me.GroupBox1.Controls.Add(Me.KL01)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.CBO_PROYECTO02)
        Me.GroupBox1.Controls.Add(Me.CBO_CC02)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.txt_cta02)
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(638, 339)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'NRO_DOC2
        '
        Me.NRO_DOC2.BackColor = System.Drawing.Color.White
        Me.NRO_DOC2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.NRO_DOC2.Location = New System.Drawing.Point(370, 220)
        Me.NRO_DOC2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.NRO_DOC2.MaxLength = 7
        Me.NRO_DOC2.Name = "NRO_DOC2"
        Me.NRO_DOC2.ReadOnly = True
        Me.NRO_DOC2.Size = New System.Drawing.Size(64, 20)
        Me.NRO_DOC2.TabIndex = 271
        Me.NRO_DOC2.Visible = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(523, 47)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(70, 18)
        Me.CheckBox2.TabIndex = 260
        Me.CheckBox2.Text = "Modificar"
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'PANEL_PER2
        '
        Me.PANEL_PER2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PANEL_PER2.Controls.Add(Me.DGW_PER2)
        Me.PANEL_PER2.Location = New System.Drawing.Point(52, 67)
        Me.PANEL_PER2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PANEL_PER2.Name = "PANEL_PER2"
        Me.PANEL_PER2.Size = New System.Drawing.Size(521, 147)
        Me.PANEL_PER2.TabIndex = 258
        Me.PANEL_PER2.Visible = False
        '
        'DGW_PER2
        '
        Me.DGW_PER2.AllowUserToAddRows = False
        Me.DGW_PER2.AllowUserToDeleteRows = False
        Me.DGW_PER2.AllowUserToOrderColumns = True
        Me.DGW_PER2.AllowUserToResizeRows = False
        Me.DGW_PER2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGW_PER2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.DGW_PER2.BackgroundColor = System.Drawing.Color.White
        Me.DGW_PER2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGW_PER2.Location = New System.Drawing.Point(16, 3)
        Me.DGW_PER2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DGW_PER2.MultiSelect = False
        Me.DGW_PER2.Name = "DGW_PER2"
        Me.DGW_PER2.ReadOnly = True
        Me.DGW_PER2.RowHeadersWidth = 25
        Me.DGW_PER2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DGW_PER2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DGW_PER2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGW_PER2.Size = New System.Drawing.Size(487, 140)
        Me.DGW_PER2.TabIndex = 50
        Me.DGW_PER2.TabStop = False
        '
        'TXT_DESC2
        '
        Me.TXT_DESC2.Location = New System.Drawing.Point(113, 46)
        Me.TXT_DESC2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TXT_DESC2.Name = "TXT_DESC2"
        Me.TXT_DESC2.Size = New System.Drawing.Size(288, 20)
        Me.TXT_DESC2.TabIndex = 256
        '
        'txt_doc_per2
        '
        Me.txt_doc_per2.Location = New System.Drawing.Point(401, 46)
        Me.txt_doc_per2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_doc_per2.MaxLength = 20
        Me.txt_doc_per2.Name = "txt_doc_per2"
        Me.txt_doc_per2.Size = New System.Drawing.Size(100, 20)
        Me.txt_doc_per2.TabIndex = 257
        '
        'TXT_COD2
        '
        Me.TXT_COD2.Location = New System.Drawing.Point(73, 46)
        Me.TXT_COD2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TXT_COD2.MaxLength = 5
        Me.TXT_COD2.Name = "TXT_COD2"
        Me.TXT_COD2.Size = New System.Drawing.Size(40, 20)
        Me.TXT_COD2.TabIndex = 255
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 14)
        Me.Label12.TabIndex = 259
        Me.Label12.Text = "Cliente"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_importe22)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txt_importe12)
        Me.GroupBox3.Location = New System.Drawing.Point(60, 223)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(298, 64)
        Me.GroupBox3.TabIndex = 254
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Visible = False
        '
        'txt_importe22
        '
        Me.txt_importe22.BackColor = System.Drawing.Color.White
        Me.txt_importe22.Location = New System.Drawing.Point(179, 23)
        Me.txt_importe22.MaxLength = 15
        Me.txt_importe22.Name = "txt_importe22"
        Me.txt_importe22.Size = New System.Drawing.Size(102, 20)
        Me.txt_importe22.TabIndex = 256
        Me.txt_importe22.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(17, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 14)
        Me.Label11.TabIndex = 255
        Me.Label11.Text = "Importes"
        '
        'txt_importe12
        '
        Me.txt_importe12.BackColor = System.Drawing.Color.White
        Me.txt_importe12.Location = New System.Drawing.Point(71, 23)
        Me.txt_importe12.MaxLength = 15
        Me.txt_importe12.Name = "txt_importe12"
        Me.txt_importe12.ReadOnly = True
        Me.txt_importe12.Size = New System.Drawing.Size(102, 20)
        Me.txt_importe12.TabIndex = 254
        Me.txt_importe12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ch_ana2
        '
        Me.ch_ana2.AutoSize = True
        Me.ch_ana2.BackColor = System.Drawing.SystemColors.Control
        Me.ch_ana2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch_ana2.Location = New System.Drawing.Point(443, 179)
        Me.ch_ana2.Name = "ch_ana2"
        Me.ch_ana2.Size = New System.Drawing.Size(64, 18)
        Me.ch_ana2.TabIndex = 252
        Me.ch_ana2.Text = "Análisis"
        Me.ch_ana2.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 183)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 14)
        Me.Label9.TabIndex = 251
        Me.Label9.Text = "Destino"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(74, 206)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(114, 18)
        Me.CheckBox1.TabIndex = 253
        Me.CheckBox1.Text = "Modificar Importes"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'txt_destino2
        '
        Me.txt_destino2.BackColor = System.Drawing.Color.White
        Me.txt_destino2.Location = New System.Drawing.Point(74, 180)
        Me.txt_destino2.Name = "txt_destino2"
        Me.txt_destino2.Size = New System.Drawing.Size(102, 20)
        Me.txt_destino2.TabIndex = 250
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(180, 184)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 14)
        Me.Label6.TabIndex = 249
        Me.Label6.Text = "Enlace"
        '
        'txt_enlace2
        '
        Me.txt_enlace2.BackColor = System.Drawing.Color.White
        Me.txt_enlace2.Location = New System.Drawing.Point(220, 180)
        Me.txt_enlace2.Name = "txt_enlace2"
        Me.txt_enlace2.Size = New System.Drawing.Size(102, 20)
        Me.txt_enlace2.TabIndex = 248
        '
        'ch_auto2
        '
        Me.ch_auto2.AutoSize = True
        Me.ch_auto2.BackColor = System.Drawing.SystemColors.Control
        Me.ch_auto2.Enabled = False
        Me.ch_auto2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch_auto2.Location = New System.Drawing.Point(521, 156)
        Me.ch_auto2.Name = "ch_auto2"
        Me.ch_auto2.Size = New System.Drawing.Size(80, 18)
        Me.ch_auto2.TabIndex = 247
        Me.ch_auto2.Text = "Automática"
        Me.ch_auto2.UseVisualStyleBackColor = False
        '
        'dtp_ref2
        '
        Me.dtp_ref2.CalendarForeColor = System.Drawing.SystemColors.Desktop
        Me.dtp_ref2.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaptionText
        Me.dtp_ref2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ref2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_ref2.Location = New System.Drawing.Point(360, 154)
        Me.dtp_ref2.Name = "dtp_ref2"
        Me.dtp_ref2.Size = New System.Drawing.Size(77, 20)
        Me.dtp_ref2.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(313, 158)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 14)
        Me.Label8.TabIndex = 246
        Me.Label8.Text = "Fec.Ref."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(189, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 14)
        Me.Label3.TabIndex = 244
        Me.Label3.Text = "Nº"
        '
        'cbo_tipo_ref2
        '
        Me.cbo_tipo_ref2.BackColor = System.Drawing.Color.White
        Me.cbo_tipo_ref2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo_ref2.DropDownWidth = 150
        Me.cbo_tipo_ref2.FormattingEnabled = True
        Me.cbo_tipo_ref2.Location = New System.Drawing.Point(74, 152)
        Me.cbo_tipo_ref2.Name = "cbo_tipo_ref2"
        Me.cbo_tipo_ref2.Size = New System.Drawing.Size(112, 22)
        Me.cbo_tipo_ref2.TabIndex = 8
        '
        'txt_nro_ref2
        '
        Me.txt_nro_ref2.BackColor = System.Drawing.Color.White
        Me.txt_nro_ref2.Location = New System.Drawing.Point(208, 154)
        Me.txt_nro_ref2.Name = "txt_nro_ref2"
        Me.txt_nro_ref2.Size = New System.Drawing.Size(102, 20)
        Me.txt_nro_ref2.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 14)
        Me.Label5.TabIndex = 243
        Me.Label5.Text = "Referencia"
        '
        'ch_rep2
        '
        Me.ch_rep2.AutoSize = True
        Me.ch_rep2.BackColor = System.Drawing.SystemColors.Control
        Me.ch_rep2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch_rep2.Location = New System.Drawing.Point(443, 156)
        Me.ch_rep2.Name = "ch_rep2"
        Me.ch_rep2.Size = New System.Drawing.Size(75, 18)
        Me.ch_rep2.TabIndex = 240
        Me.ch_rep2.Text = "Reparable"
        Me.ch_rep2.UseVisualStyleBackColor = False
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(306, 107)
        Me.Label76.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(52, 14)
        Me.Label76.TabIndex = 239
        Me.Label76.Text = "Actividad"
        '
        'btn_req2
        '
        Me.btn_req2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_req2.Location = New System.Drawing.Point(165, 101)
        Me.btn_req2.Name = "btn_req2"
        Me.btn_req2.Size = New System.Drawing.Size(34, 22)
        Me.btn_req2.TabIndex = 238
        Me.btn_req2.TabStop = False
        Me.btn_req2.Text = "..."
        Me.btn_req2.UseVisualStyleBackColor = True
        '
        'cbo_act02
        '
        Me.cbo_act02.BackColor = System.Drawing.Color.White
        Me.cbo_act02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_act02.FormattingEnabled = True
        Me.cbo_act02.Location = New System.Drawing.Point(368, 104)
        Me.cbo_act02.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbo_act02.Name = "cbo_act02"
        Me.cbo_act02.Size = New System.Drawing.Size(226, 22)
        Me.cbo_act02.TabIndex = 5
        '
        'txt_nro_req2
        '
        Me.txt_nro_req2.BackColor = System.Drawing.Color.White
        Me.txt_nro_req2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nro_req2.Location = New System.Drawing.Point(74, 102)
        Me.txt_nro_req2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_nro_req2.MaxLength = 7
        Me.txt_nro_req2.Name = "txt_nro_req2"
        Me.txt_nro_req2.ReadOnly = True
        Me.txt_nro_req2.Size = New System.Drawing.Size(64, 20)
        Me.txt_nro_req2.TabIndex = 236
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(12, 108)
        Me.Label77.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(56, 14)
        Me.Label77.TabIndex = 235
        Me.Label77.Text = "Ord. Prod."
        '
        'btn_lim2
        '
        Me.btn_lim2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_lim2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_lim2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_lim2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_lim2.Location = New System.Drawing.Point(373, 276)
        Me.btn_lim2.Name = "btn_lim2"
        Me.btn_lim2.Size = New System.Drawing.Size(77, 26)
        Me.btn_lim2.TabIndex = 151
        Me.btn_lim2.TabStop = False
        Me.btn_lim2.Text = "&Limpiar"
        Me.btn_lim2.UseVisualStyleBackColor = True
        '
        'ch_cta2
        '
        Me.ch_cta2.AutoSize = True
        Me.ch_cta2.BackColor = System.Drawing.SystemColors.Control
        Me.ch_cta2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch_cta2.Location = New System.Drawing.Point(523, 21)
        Me.ch_cta2.Name = "ch_cta2"
        Me.ch_cta2.Size = New System.Drawing.Size(70, 18)
        Me.ch_cta2.TabIndex = 150
        Me.ch_cta2.Text = "Modificar"
        Me.ch_cta2.UseVisualStyleBackColor = False
        '
        'txt_desc_cta02
        '
        Me.txt_desc_cta02.Location = New System.Drawing.Point(137, 19)
        Me.txt_desc_cta02.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_cta02.Name = "txt_desc_cta02"
        Me.txt_desc_cta02.Size = New System.Drawing.Size(361, 20)
        Me.txt_desc_cta02.TabIndex = 1
        '
        'btn_mod22
        '
        Me.btn_mod22.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_mod22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mod22.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_mod22.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_mod22.Location = New System.Drawing.Point(456, 276)
        Me.btn_mod22.Name = "btn_mod22"
        Me.btn_mod22.Size = New System.Drawing.Size(77, 26)
        Me.btn_mod22.TabIndex = 11
        Me.btn_mod22.Text = "&Aceptar"
        Me.btn_mod22.UseVisualStyleBackColor = True
        '
        'Button22
        '
        Me.Button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button22.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.Button22.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button22.Location = New System.Drawing.Point(539, 276)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(77, 26)
        Me.Button22.TabIndex = 12
        Me.Button22.Text = "&Cancelar"
        Me.Button22.UseVisualStyleBackColor = True
        '
        'TXT_GLOSA2
        '
        Me.TXT_GLOSA2.Location = New System.Drawing.Point(74, 129)
        Me.TXT_GLOSA2.Margin = New System.Windows.Forms.Padding(0)
        Me.TXT_GLOSA2.MaxLength = 60
        Me.TXT_GLOSA2.Name = "TXT_GLOSA2"
        Me.TXT_GLOSA2.Size = New System.Drawing.Size(519, 20)
        Me.TXT_GLOSA2.TabIndex = 7
        '
        'KL01
        '
        Me.KL01.Location = New System.Drawing.Point(374, 19)
        Me.KL01.Margin = New System.Windows.Forms.Padding(0)
        Me.KL01.Name = "KL01"
        Me.KL01.Size = New System.Drawing.Size(61, 20)
        Me.KL01.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 14)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Glosa"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(306, 81)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(50, 14)
        Me.Label31.TabIndex = 91
        Me.Label31.Text = "Proyecto"
        '
        'CBO_PROYECTO02
        '
        Me.CBO_PROYECTO02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_PROYECTO02.DropDownWidth = 250
        Me.CBO_PROYECTO02.FormattingEnabled = True
        Me.CBO_PROYECTO02.Location = New System.Drawing.Point(367, 78)
        Me.CBO_PROYECTO02.Name = "CBO_PROYECTO02"
        Me.CBO_PROYECTO02.Size = New System.Drawing.Size(226, 22)
        Me.CBO_PROYECTO02.TabIndex = 4
        '
        'CBO_CC02
        '
        Me.CBO_CC02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_CC02.DropDownWidth = 250
        Me.CBO_CC02.FormattingEnabled = True
        Me.CBO_CC02.Location = New System.Drawing.Point(74, 78)
        Me.CBO_CC02.Name = "CBO_CC02"
        Me.CBO_CC02.Size = New System.Drawing.Size(226, 22)
        Me.CBO_CC02.TabIndex = 3
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(12, 22)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(41, 14)
        Me.Label30.TabIndex = 88
        Me.Label30.Text = "Cuenta"
        '
        'txt_cta02
        '
        Me.txt_cta02.Location = New System.Drawing.Point(74, 19)
        Me.txt_cta02.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cta02.MaxLength = 8
        Me.txt_cta02.Name = "txt_cta02"
        Me.txt_cta02.Size = New System.Drawing.Size(61, 20)
        Me.txt_cta02.TabIndex = 0
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(12, 83)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(51, 14)
        Me.Label39.TabIndex = 89
        Me.Label39.Text = "C.Costos"
        '
        'BTN_MOD21
        '
        Me.BTN_MOD21.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_MOD21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_MOD21.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.BTN_MOD21.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_MOD21.Location = New System.Drawing.Point(426, 121)
        Me.BTN_MOD21.Name = "BTN_MOD21"
        Me.BTN_MOD21.Size = New System.Drawing.Size(77, 26)
        Me.BTN_MOD21.TabIndex = 151
        Me.BTN_MOD21.Text = "&Modificar"
        Me.BTN_MOD21.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btn_buscar2)
        Me.GroupBox8.Controls.Add(Me.txt_letra2)
        Me.GroupBox8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(22, 484)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(251, 51)
        Me.GroupBox8.TabIndex = 152
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Búsqueda por Documento:"
        '
        'btn_buscar2
        '
        Me.btn_buscar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_buscar2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btn_buscar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Binoculars_2_1
        Me.btn_buscar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar2.Location = New System.Drawing.Point(166, 13)
        Me.btn_buscar2.Name = "btn_buscar2"
        Me.btn_buscar2.Size = New System.Drawing.Size(74, 26)
        Me.btn_buscar2.TabIndex = 2
        Me.btn_buscar2.Text = "&Buscar"
        Me.btn_buscar2.UseVisualStyleBackColor = True
        '
        'txt_letra2
        '
        Me.txt_letra2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_letra2.Location = New System.Drawing.Point(11, 19)
        Me.txt_letra2.Name = "txt_letra2"
        Me.txt_letra2.Size = New System.Drawing.Size(146, 20)
        Me.txt_letra2.TabIndex = 0
        Me.txt_letra2.TabStop = False
        '
        'CONSULTA_TCON_ACTUALIZA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 547)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel_cta)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.BTN_LIMP2)
        Me.Controls.Add(Me.BTN_MOD21)
        Me.Controls.Add(Me.dgw2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btn_cancelar2)
        Me.Controls.Add(Me.GroupBox8)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CONSULTA_TCON_ACTUALIZA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Cuentas"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel_cta.ResumeLayout(False)
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgw2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel_cta02.ResumeLayout(False)
        CType(Me.dgw_cta02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PANEL_PER2.ResumeLayout(False)
        CType(Me.DGW_PER2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_cad_cta2 As Button
    Friend WithEvents btn_cancelar2 As Button
    Friend WithEvents btn_consulta2 As Button
    Friend WithEvents btn_lim2 As Button
    Friend WithEvents BTN_LIMP2 As Button
    Friend WithEvents BTN_MOD21 As Button
    Friend WithEvents btn_mod22 As Button
    Friend WithEvents btn_req2 As Button
    Friend WithEvents btn_sgt_cta2 As Button
    Friend WithEvents Button22 As Button
    Friend WithEvents cbo_act02 As ComboBox
    Friend WithEvents cbo_auxiliar2 As ComboBox
    Friend WithEvents CBO_CC02 As ComboBox
    Friend WithEvents cbo_comprobante2 As ComboBox
    Friend WithEvents cbo_mes2 As ComboBox
    Friend WithEvents CBO_PROYECTO02 As ComboBox
    Friend WithEvents CH_AUX2 As CheckBox
    Friend WithEvents ch_com2 As CheckBox
    Friend WithEvents ch_cta2 As CheckBox
    Friend WithEvents dgw_cta As DataGridView
    Friend WithEvents dgw_cta02 As DataGridView
    Friend WithEvents dgw2 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents KL01 As TextBox
    Friend WithEvents KL1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label76 As Label
    Friend WithEvents Label77 As Label
    Friend WithEvents Panel_cta As Panel
    Friend WithEvents Panel_cta02 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txt_cta As TextBox
    Friend WithEvents txt_cta02 As TextBox
    Friend WithEvents txt_desc_cta As TextBox
    Friend WithEvents txt_desc_cta02 As TextBox
    Friend WithEvents TXT_GLOSA2 As TextBox
    Friend WithEvents txt_nro_req2 As TextBox
    Friend WithEvents ch_rep2 As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_tipo_ref2 As System.Windows.Forms.ComboBox
    Friend WithEvents txt_nro_ref2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_ref2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_letra2 As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar2 As System.Windows.Forms.Button
    Friend WithEvents ch_auto2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_destino2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_enlace2 As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column26 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column30 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column33 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ch_ana2 As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_año2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_importe22 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_importe12 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents PANEL_PER2 As System.Windows.Forms.Panel
    Friend WithEvents DGW_PER2 As System.Windows.Forms.DataGridView
    Friend WithEvents TXT_DESC2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_doc_per2 As System.Windows.Forms.TextBox
    Friend WithEvents TXT_COD2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents NRO_DOC2 As System.Windows.Forms.TextBox
End Class
