Imports System.ComponentModel
Imports System.Drawing.Point



<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CONSULTA_TBANCO_ACTUALIZA
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_cod_ban = New System.Windows.Forms.TextBox
        Me.txt_desc_ban = New System.Windows.Forms.TextBox
        Me.cbo_año1 = New System.Windows.Forms.ComboBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.ch_com = New System.Windows.Forms.CheckBox
        Me.cbo_comprobante = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.CH_AUX = New System.Windows.Forms.CheckBox
        Me.btn_consulta1 = New System.Windows.Forms.Button
        Me.cbo_auxiliar = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.KL1 = New System.Windows.Forms.TextBox
        Me.BTN_LIMP = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column31 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column32 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Panel_ban2 = New System.Windows.Forms.Panel
        Me.dgw_ban2 = New System.Windows.Forms.DataGridView
        Me.panel_cta = New System.Windows.Forms.Panel
        Me.dgw_cta = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_desc_ban2 = New System.Windows.Forms.TextBox
        Me.txt_cod_ban2 = New System.Windows.Forms.TextBox
        Me.PANEL_PER1 = New System.Windows.Forms.Panel
        Me.DGW_PER1 = New System.Windows.Forms.DataGridView
        Me.TXT_DESC1 = New System.Windows.Forms.TextBox
        Me.txt_doc_per1 = New System.Windows.Forms.TextBox
        Me.TXT_COD1 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label76 = New System.Windows.Forms.Label
        Me.btn_req = New System.Windows.Forms.Button
        Me.cbo_act01 = New System.Windows.Forms.ComboBox
        Me.txt_nro_req = New System.Windows.Forms.TextBox
        Me.Label77 = New System.Windows.Forms.Label
        Me.btn_lim = New System.Windows.Forms.Button
        Me.btn_mod2 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.TXT_GLOSA = New System.Windows.Forms.TextBox
        Me.KL01 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.CBO_PROYECTO01 = New System.Windows.Forms.ComboBox
        Me.CBO_CC01 = New System.Windows.Forms.ComboBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.ch_cpto = New System.Windows.Forms.CheckBox
        Me.txt_desc_cta = New System.Windows.Forms.TextBox
        Me.txt_cod_cta = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.ch_per = New System.Windows.Forms.CheckBox
        Me.NRO_DOC = New System.Windows.Forms.TextBox
        Me.BTN_MOD = New System.Windows.Forms.Button
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.txt_letra = New System.Windows.Forms.TextBox
        Me.Panel_ban1 = New System.Windows.Forms.Panel
        Me.dgw_ban = New System.Windows.Forms.DataGridView
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel_ban2.SuspendLayout()
        CType(Me.dgw_ban2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_cta.SuspendLayout()
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PANEL_PER1.SuspendLayout()
        CType(Me.DGW_PER1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.Panel_ban1.SuspendLayout()
        CType(Me.dgw_ban, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txt_cod_ban)
        Me.GroupBox2.Controls.Add(Me.txt_desc_ban)
        Me.GroupBox2.Controls.Add(Me.cbo_año1)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.ch_com)
        Me.GroupBox2.Controls.Add(Me.cbo_comprobante)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.CH_AUX)
        Me.GroupBox2.Controls.Add(Me.btn_consulta1)
        Me.GroupBox2.Controls.Add(Me.cbo_auxiliar)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cbo_mes)
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 14)
        Me.Label3.TabIndex = 158
        Me.Label3.Text = "Bancos"
        '
        'txt_cod_ban
        '
        Me.txt_cod_ban.BackColor = System.Drawing.Color.White
        Me.txt_cod_ban.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_ban.Location = New System.Drawing.Point(115, 71)
        Me.txt_cod_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_ban.MaxLength = 4
        Me.txt_cod_ban.Name = "txt_cod_ban"
        Me.txt_cod_ban.Size = New System.Drawing.Size(58, 20)
        Me.txt_cod_ban.TabIndex = 156
        '
        'txt_desc_ban
        '
        Me.txt_desc_ban.BackColor = System.Drawing.Color.White
        Me.txt_desc_ban.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_ban.Location = New System.Drawing.Point(176, 71)
        Me.txt_desc_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_ban.MaxLength = 40
        Me.txt_desc_ban.Name = "txt_desc_ban"
        Me.txt_desc_ban.Size = New System.Drawing.Size(316, 20)
        Me.txt_desc_ban.TabIndex = 157
        '
        'cbo_año1
        '
        Me.cbo_año1.BackColor = System.Drawing.Color.White
        Me.cbo_año1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_año1.FormattingEnabled = True
        Me.cbo_año1.Location = New System.Drawing.Point(384, 23)
        Me.cbo_año1.Name = "cbo_año1"
        Me.cbo_año1.Size = New System.Drawing.Size(108, 22)
        Me.cbo_año1.TabIndex = 154
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
        'ch_com
        '
        Me.ch_com.AutoSize = True
        Me.ch_com.BackColor = System.Drawing.SystemColors.Control
        Me.ch_com.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch_com.Location = New System.Drawing.Point(94, 51)
        Me.ch_com.Name = "ch_com"
        Me.ch_com.Size = New System.Drawing.Size(15, 14)
        Me.ch_com.TabIndex = 149
        Me.ch_com.UseVisualStyleBackColor = False
        '
        'cbo_comprobante
        '
        Me.cbo_comprobante.BackColor = System.Drawing.Color.White
        Me.cbo_comprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_comprobante.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_comprobante.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_comprobante.FormattingEnabled = True
        Me.cbo_comprobante.Location = New System.Drawing.Point(115, 47)
        Me.cbo_comprobante.MaxDropDownItems = 10
        Me.cbo_comprobante.Name = "cbo_comprobante"
        Me.cbo_comprobante.Size = New System.Drawing.Size(230, 22)
        Me.cbo_comprobante.TabIndex = 2
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
        'CH_AUX
        '
        Me.CH_AUX.AutoSize = True
        Me.CH_AUX.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CH_AUX.Location = New System.Drawing.Point(94, 27)
        Me.CH_AUX.Name = "CH_AUX"
        Me.CH_AUX.Size = New System.Drawing.Size(15, 14)
        Me.CH_AUX.TabIndex = 138
        Me.CH_AUX.UseVisualStyleBackColor = True
        '
        'btn_consulta1
        '
        Me.btn_consulta1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_consulta1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_consulta1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Search_1
        Me.btn_consulta1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consulta1.Location = New System.Drawing.Point(532, 39)
        Me.btn_consulta1.Name = "btn_consulta1"
        Me.btn_consulta1.Size = New System.Drawing.Size(77, 26)
        Me.btn_consulta1.TabIndex = 7
        Me.btn_consulta1.Text = "&Consulta"
        Me.btn_consulta1.UseVisualStyleBackColor = True
        '
        'cbo_auxiliar
        '
        Me.cbo_auxiliar.BackColor = System.Drawing.Color.White
        Me.cbo_auxiliar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_auxiliar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_auxiliar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_auxiliar.FormattingEnabled = True
        Me.cbo_auxiliar.Location = New System.Drawing.Point(115, 23)
        Me.cbo_auxiliar.MaxDropDownItems = 9
        Me.cbo_auxiliar.Name = "cbo_auxiliar"
        Me.cbo_auxiliar.Size = New System.Drawing.Size(230, 22)
        Me.cbo_auxiliar.TabIndex = 1
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
        'cbo_mes
        '
        Me.cbo_mes.BackColor = System.Drawing.Color.White
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"INICIO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(384, 47)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(108, 22)
        Me.cbo_mes.TabIndex = 3
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
        Me.KL1.Location = New System.Drawing.Point(412, 71)
        Me.KL1.Margin = New System.Windows.Forms.Padding(0)
        Me.KL1.MaxLength = 8
        Me.KL1.Name = "KL1"
        Me.KL1.Size = New System.Drawing.Size(10, 20)
        Me.KL1.TabIndex = 6
        '
        'BTN_LIMP
        '
        Me.BTN_LIMP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_LIMP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_LIMP.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.BTN_LIMP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_LIMP.Location = New System.Drawing.Point(509, 121)
        Me.BTN_LIMP.Name = "BTN_LIMP"
        Me.BTN_LIMP.Size = New System.Drawing.Size(77, 26)
        Me.BTN_LIMP.TabIndex = 150
        Me.BTN_LIMP.Text = "&Limpiar"
        Me.BTN_LIMP.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.Location = New System.Drawing.Point(592, 121)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(77, 26)
        Me.btn_cancelar.TabIndex = 8
        Me.btn_cancelar.TabStop = False
        Me.btn_cancelar.Text = "&Salir"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column25, Me.Column12, Me.Column15, Me.Column16, Me.Column22, Me.Column17, Me.Column18, Me.Column19, Me.Column24, Me.Column21, Me.Column31, Me.Column32, Me.Column6, Me.Column7, Me.Column13})
        Me.dgw1.Location = New System.Drawing.Point(0, 170)
        Me.dgw1.Name = "dgw1"
        Me.dgw1.RowHeadersWidth = 25
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw1.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(686, 308)
        Me.dgw1.TabIndex = 21
        '
        'Column1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "n2"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.HeaderText = "Imp. Debe"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 90
        '
        'Column5
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "n2"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "Imp. Haber"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 90
        '
        'Column8
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column8.HeaderText = "Mo."
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 30
        '
        'Column9
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "d"
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column9.HeaderText = "Fecha"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 70
        '
        'Column10
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle6
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
        Me.Column16.Visible = False
        '
        'Column22
        '
        Me.Column22.HeaderText = "Proyecto"
        Me.Column22.Name = "Column22"
        Me.Column22.ReadOnly = True
        Me.Column22.Visible = False
        '
        'Column17
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column17.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column17.HeaderText = "Aux."
        Me.Column17.Name = "Column17"
        Me.Column17.Width = 30
        '
        'Column18
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column18.DefaultCellStyle = DataGridViewCellStyle8
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
        'Column24
        '
        Me.Column24.HeaderText = "Item"
        Me.Column24.Name = "Column24"
        Me.Column24.ReadOnly = True
        Me.Column24.Width = 40
        '
        'Column21
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column21.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column21.HeaderText = "Trans."
        Me.Column21.Name = "Column21"
        Me.Column21.Width = 40
        '
        'Column31
        '
        Me.Column31.HeaderText = "COD MP"
        Me.Column31.Name = "Column31"
        Me.Column31.Visible = False
        '
        'Column32
        '
        Me.Column32.HeaderText = "N° MP"
        Me.Column32.Name = "Column32"
        Me.Column32.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "Act."
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "Cpto"
        Me.Column7.Name = "Column7"
        '
        'Column13
        '
        Me.Column13.HeaderText = "Desc Cpto"
        Me.Column13.Name = "Column13"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 170)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(686, 377)
        Me.Panel1.TabIndex = 69
        Me.Panel1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel_ban2)
        Me.GroupBox1.Controls.Add(Me.panel_cta)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_desc_ban2)
        Me.GroupBox1.Controls.Add(Me.txt_cod_ban2)
        Me.GroupBox1.Controls.Add(Me.PANEL_PER1)
        Me.GroupBox1.Controls.Add(Me.TXT_DESC1)
        Me.GroupBox1.Controls.Add(Me.txt_doc_per1)
        Me.GroupBox1.Controls.Add(Me.TXT_COD1)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label76)
        Me.GroupBox1.Controls.Add(Me.btn_req)
        Me.GroupBox1.Controls.Add(Me.cbo_act01)
        Me.GroupBox1.Controls.Add(Me.txt_nro_req)
        Me.GroupBox1.Controls.Add(Me.Label77)
        Me.GroupBox1.Controls.Add(Me.btn_lim)
        Me.GroupBox1.Controls.Add(Me.btn_mod2)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.TXT_GLOSA)
        Me.GroupBox1.Controls.Add(Me.KL01)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.CBO_PROYECTO01)
        Me.GroupBox1.Controls.Add(Me.CBO_CC01)
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Controls.Add(Me.ch_cpto)
        Me.GroupBox1.Controls.Add(Me.txt_desc_cta)
        Me.GroupBox1.Controls.Add(Me.txt_cod_cta)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.ch_per)
        Me.GroupBox1.Controls.Add(Me.NRO_DOC)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(638, 339)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Panel_ban2
        '
        Me.Panel_ban2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_ban2.Controls.Add(Me.dgw_ban2)
        Me.Panel_ban2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel_ban2.Location = New System.Drawing.Point(10, 37)
        Me.Panel_ban2.Name = "Panel_ban2"
        Me.Panel_ban2.Size = New System.Drawing.Size(505, 100)
        Me.Panel_ban2.TabIndex = 264
        Me.Panel_ban2.Visible = False
        '
        'dgw_ban2
        '
        Me.dgw_ban2.AllowUserToAddRows = False
        Me.dgw_ban2.AllowUserToDeleteRows = False
        Me.dgw_ban2.AllowUserToOrderColumns = True
        Me.dgw_ban2.AllowUserToResizeRows = False
        Me.dgw_ban2.BackgroundColor = System.Drawing.Color.White
        Me.dgw_ban2.Location = New System.Drawing.Point(63, -1)
        Me.dgw_ban2.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_ban2.MultiSelect = False
        Me.dgw_ban2.Name = "dgw_ban2"
        Me.dgw_ban2.ReadOnly = True
        Me.dgw_ban2.RowHeadersWidth = 25
        Me.dgw_ban2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_ban2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_ban2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_ban2.Size = New System.Drawing.Size(427, 95)
        Me.dgw_ban2.TabIndex = 62
        '
        'panel_cta
        '
        Me.panel_cta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_cta.Controls.Add(Me.dgw_cta)
        Me.panel_cta.Location = New System.Drawing.Point(12, 93)
        Me.panel_cta.Name = "panel_cta"
        Me.panel_cta.Size = New System.Drawing.Size(512, 114)
        Me.panel_cta.TabIndex = 267
        Me.panel_cta.Visible = False
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
        Me.dgw_cta.Location = New System.Drawing.Point(57, 0)
        Me.dgw_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta.MultiSelect = False
        Me.dgw_cta.Name = "dgw_cta"
        Me.dgw_cta.ReadOnly = True
        Me.dgw_cta.RowHeadersWidth = 25
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta.Size = New System.Drawing.Size(431, 101)
        Me.dgw_cta.TabIndex = 90
        Me.dgw_cta.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 14)
        Me.Label5.TabIndex = 263
        Me.Label5.Text = "Bancos"
        '
        'txt_desc_ban2
        '
        Me.txt_desc_ban2.BackColor = System.Drawing.Color.White
        Me.txt_desc_ban2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_ban2.Location = New System.Drawing.Point(132, 19)
        Me.txt_desc_ban2.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_ban2.MaxLength = 40
        Me.txt_desc_ban2.Name = "txt_desc_ban2"
        Me.txt_desc_ban2.Size = New System.Drawing.Size(369, 20)
        Me.txt_desc_ban2.TabIndex = 262
        '
        'txt_cod_ban2
        '
        Me.txt_cod_ban2.BackColor = System.Drawing.Color.White
        Me.txt_cod_ban2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_ban2.Location = New System.Drawing.Point(74, 19)
        Me.txt_cod_ban2.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_ban2.MaxLength = 4
        Me.txt_cod_ban2.Name = "txt_cod_ban2"
        Me.txt_cod_ban2.Size = New System.Drawing.Size(58, 20)
        Me.txt_cod_ban2.TabIndex = 261
        '
        'PANEL_PER1
        '
        Me.PANEL_PER1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PANEL_PER1.Controls.Add(Me.DGW_PER1)
        Me.PANEL_PER1.Location = New System.Drawing.Point(52, 64)
        Me.PANEL_PER1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PANEL_PER1.Name = "PANEL_PER1"
        Me.PANEL_PER1.Size = New System.Drawing.Size(528, 147)
        Me.PANEL_PER1.TabIndex = 258
        Me.PANEL_PER1.Visible = False
        '
        'DGW_PER1
        '
        Me.DGW_PER1.AllowUserToAddRows = False
        Me.DGW_PER1.AllowUserToDeleteRows = False
        Me.DGW_PER1.AllowUserToOrderColumns = True
        Me.DGW_PER1.AllowUserToResizeRows = False
        Me.DGW_PER1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGW_PER1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.DGW_PER1.BackgroundColor = System.Drawing.Color.White
        Me.DGW_PER1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGW_PER1.Location = New System.Drawing.Point(16, 3)
        Me.DGW_PER1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DGW_PER1.MultiSelect = False
        Me.DGW_PER1.Name = "DGW_PER1"
        Me.DGW_PER1.ReadOnly = True
        Me.DGW_PER1.RowHeadersWidth = 25
        Me.DGW_PER1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DGW_PER1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DGW_PER1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGW_PER1.Size = New System.Drawing.Size(487, 140)
        Me.DGW_PER1.TabIndex = 50
        Me.DGW_PER1.TabStop = False
        '
        'TXT_DESC1
        '
        Me.TXT_DESC1.Location = New System.Drawing.Point(113, 46)
        Me.TXT_DESC1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TXT_DESC1.Name = "TXT_DESC1"
        Me.TXT_DESC1.Size = New System.Drawing.Size(288, 20)
        Me.TXT_DESC1.TabIndex = 256
        '
        'txt_doc_per1
        '
        Me.txt_doc_per1.Location = New System.Drawing.Point(401, 46)
        Me.txt_doc_per1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_doc_per1.MaxLength = 20
        Me.txt_doc_per1.Name = "txt_doc_per1"
        Me.txt_doc_per1.Size = New System.Drawing.Size(100, 20)
        Me.txt_doc_per1.TabIndex = 257
        '
        'TXT_COD1
        '
        Me.TXT_COD1.Location = New System.Drawing.Point(73, 46)
        Me.TXT_COD1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TXT_COD1.MaxLength = 5
        Me.TXT_COD1.Name = "TXT_COD1"
        Me.TXT_COD1.Size = New System.Drawing.Size(40, 20)
        Me.TXT_COD1.TabIndex = 255
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
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(306, 140)
        Me.Label76.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(52, 14)
        Me.Label76.TabIndex = 239
        Me.Label76.Text = "Actividad"
        '
        'btn_req
        '
        Me.btn_req.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_req.Location = New System.Drawing.Point(165, 134)
        Me.btn_req.Name = "btn_req"
        Me.btn_req.Size = New System.Drawing.Size(34, 22)
        Me.btn_req.TabIndex = 238
        Me.btn_req.TabStop = False
        Me.btn_req.Text = "..."
        Me.btn_req.UseVisualStyleBackColor = True
        '
        'cbo_act01
        '
        Me.cbo_act01.BackColor = System.Drawing.Color.White
        Me.cbo_act01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_act01.FormattingEnabled = True
        Me.cbo_act01.Location = New System.Drawing.Point(368, 137)
        Me.cbo_act01.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbo_act01.Name = "cbo_act01"
        Me.cbo_act01.Size = New System.Drawing.Size(226, 22)
        Me.cbo_act01.TabIndex = 5
        '
        'txt_nro_req
        '
        Me.txt_nro_req.BackColor = System.Drawing.Color.White
        Me.txt_nro_req.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nro_req.Location = New System.Drawing.Point(74, 135)
        Me.txt_nro_req.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_nro_req.MaxLength = 7
        Me.txt_nro_req.Name = "txt_nro_req"
        Me.txt_nro_req.ReadOnly = True
        Me.txt_nro_req.Size = New System.Drawing.Size(64, 20)
        Me.txt_nro_req.TabIndex = 236
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(12, 141)
        Me.Label77.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(56, 14)
        Me.Label77.TabIndex = 235
        Me.Label77.Text = "Ord. Prod."
        '
        'btn_lim
        '
        Me.btn_lim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_lim.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_lim.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_lim.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_lim.Location = New System.Drawing.Point(373, 276)
        Me.btn_lim.Name = "btn_lim"
        Me.btn_lim.Size = New System.Drawing.Size(77, 26)
        Me.btn_lim.TabIndex = 151
        Me.btn_lim.TabStop = False
        Me.btn_lim.Text = "&Limpiar"
        Me.btn_lim.UseVisualStyleBackColor = True
        '
        'btn_mod2
        '
        Me.btn_mod2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_mod2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mod2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_mod2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_mod2.Location = New System.Drawing.Point(456, 276)
        Me.btn_mod2.Name = "btn_mod2"
        Me.btn_mod2.Size = New System.Drawing.Size(77, 26)
        Me.btn_mod2.TabIndex = 11
        Me.btn_mod2.Text = "&Aceptar"
        Me.btn_mod2.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(539, 276)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(77, 26)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "&Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TXT_GLOSA
        '
        Me.TXT_GLOSA.Location = New System.Drawing.Point(74, 162)
        Me.TXT_GLOSA.Margin = New System.Windows.Forms.Padding(0)
        Me.TXT_GLOSA.MaxLength = 60
        Me.TXT_GLOSA.Name = "TXT_GLOSA"
        Me.TXT_GLOSA.Size = New System.Drawing.Size(519, 20)
        Me.TXT_GLOSA.TabIndex = 7
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
        Me.Label1.Location = New System.Drawing.Point(12, 166)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 14)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Glosa"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(306, 114)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(50, 14)
        Me.Label31.TabIndex = 91
        Me.Label31.Text = "Proyecto"
        '
        'CBO_PROYECTO01
        '
        Me.CBO_PROYECTO01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_PROYECTO01.DropDownWidth = 250
        Me.CBO_PROYECTO01.FormattingEnabled = True
        Me.CBO_PROYECTO01.Location = New System.Drawing.Point(367, 111)
        Me.CBO_PROYECTO01.Name = "CBO_PROYECTO01"
        Me.CBO_PROYECTO01.Size = New System.Drawing.Size(226, 22)
        Me.CBO_PROYECTO01.TabIndex = 4
        '
        'CBO_CC01
        '
        Me.CBO_CC01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_CC01.DropDownWidth = 250
        Me.CBO_CC01.FormattingEnabled = True
        Me.CBO_CC01.Location = New System.Drawing.Point(74, 111)
        Me.CBO_CC01.Name = "CBO_CC01"
        Me.CBO_CC01.Size = New System.Drawing.Size(226, 22)
        Me.CBO_CC01.TabIndex = 3
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(12, 116)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(51, 14)
        Me.Label39.TabIndex = 89
        Me.Label39.Text = "C.Costos"
        '
        'ch_cpto
        '
        Me.ch_cpto.AutoSize = True
        Me.ch_cpto.BackColor = System.Drawing.SystemColors.Control
        Me.ch_cpto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch_cpto.Location = New System.Drawing.Point(521, 75)
        Me.ch_cpto.Name = "ch_cpto"
        Me.ch_cpto.Size = New System.Drawing.Size(70, 18)
        Me.ch_cpto.TabIndex = 269
        Me.ch_cpto.Text = "Modificar"
        Me.ch_cpto.UseVisualStyleBackColor = False
        '
        'txt_desc_cta
        '
        Me.txt_desc_cta.BackColor = System.Drawing.Color.White
        Me.txt_desc_cta.Location = New System.Drawing.Point(121, 73)
        Me.txt_desc_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_cta.MaxLength = 40
        Me.txt_desc_cta.Name = "txt_desc_cta"
        Me.txt_desc_cta.Size = New System.Drawing.Size(380, 20)
        Me.txt_desc_cta.TabIndex = 266
        '
        'txt_cod_cta
        '
        Me.txt_cod_cta.BackColor = System.Drawing.Color.White
        Me.txt_cod_cta.Location = New System.Drawing.Point(72, 73)
        Me.txt_cod_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_cta.MaxLength = 5
        Me.txt_cod_cta.Name = "txt_cod_cta"
        Me.txt_cod_cta.Size = New System.Drawing.Size(45, 20)
        Me.txt_cod_cta.TabIndex = 265
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(14, 76)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 14)
        Me.Label16.TabIndex = 268
        Me.Label16.Text = "Concepto"
        '
        'ch_per
        '
        Me.ch_per.AutoSize = True
        Me.ch_per.BackColor = System.Drawing.SystemColors.Control
        Me.ch_per.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch_per.Location = New System.Drawing.Point(523, 47)
        Me.ch_per.Name = "ch_per"
        Me.ch_per.Size = New System.Drawing.Size(70, 18)
        Me.ch_per.TabIndex = 260
        Me.ch_per.Text = "Modificar"
        Me.ch_per.UseVisualStyleBackColor = False
        '
        'NRO_DOC
        '
        Me.NRO_DOC.BackColor = System.Drawing.Color.White
        Me.NRO_DOC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.NRO_DOC.Location = New System.Drawing.Point(529, 191)
        Me.NRO_DOC.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.NRO_DOC.MaxLength = 7
        Me.NRO_DOC.Name = "NRO_DOC"
        Me.NRO_DOC.ReadOnly = True
        Me.NRO_DOC.Size = New System.Drawing.Size(64, 20)
        Me.NRO_DOC.TabIndex = 270
        Me.NRO_DOC.Visible = False
        '
        'BTN_MOD
        '
        Me.BTN_MOD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_MOD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_MOD.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.BTN_MOD.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_MOD.Location = New System.Drawing.Point(426, 121)
        Me.BTN_MOD.Name = "BTN_MOD"
        Me.BTN_MOD.Size = New System.Drawing.Size(77, 26)
        Me.BTN_MOD.TabIndex = 151
        Me.BTN_MOD.Text = "&Modificar"
        Me.BTN_MOD.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btn_buscar)
        Me.GroupBox8.Controls.Add(Me.txt_letra)
        Me.GroupBox8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(22, 484)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(251, 51)
        Me.GroupBox8.TabIndex = 152
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Búsqueda por Documento:"
        '
        'btn_buscar
        '
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_buscar.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btn_buscar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Binoculars_2_1
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.Location = New System.Drawing.Point(166, 13)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(74, 26)
        Me.btn_buscar.TabIndex = 2
        Me.btn_buscar.Text = "&Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'txt_letra
        '
        Me.txt_letra.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_letra.Location = New System.Drawing.Point(11, 19)
        Me.txt_letra.Name = "txt_letra"
        Me.txt_letra.Size = New System.Drawing.Size(146, 20)
        Me.txt_letra.TabIndex = 0
        Me.txt_letra.TabStop = False
        '
        'Panel_ban1
        '
        Me.Panel_ban1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_ban1.Controls.Add(Me.dgw_ban)
        Me.Panel_ban1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel_ban1.Location = New System.Drawing.Point(106, 104)
        Me.Panel_ban1.Name = "Panel_ban1"
        Me.Panel_ban1.Size = New System.Drawing.Size(418, 120)
        Me.Panel_ban1.TabIndex = 159
        Me.Panel_ban1.Visible = False
        '
        'dgw_ban
        '
        Me.dgw_ban.AllowUserToAddRows = False
        Me.dgw_ban.AllowUserToDeleteRows = False
        Me.dgw_ban.AllowUserToOrderColumns = True
        Me.dgw_ban.AllowUserToResizeRows = False
        Me.dgw_ban.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_ban.BackgroundColor = System.Drawing.Color.White
        Me.dgw_ban.Location = New System.Drawing.Point(17, 2)
        Me.dgw_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_ban.MultiSelect = False
        Me.dgw_ban.Name = "dgw_ban"
        Me.dgw_ban.ReadOnly = True
        Me.dgw_ban.RowHeadersWidth = 25
        Me.dgw_ban.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_ban.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_ban.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_ban.Size = New System.Drawing.Size(378, 110)
        Me.dgw_ban.TabIndex = 61
        '
        'CONSULTA_TBANCO_ACTUALIZA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 547)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel_ban1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BTN_LIMP)
        Me.Controls.Add(Me.BTN_MOD)
        Me.Controls.Add(Me.dgw1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.GroupBox8)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CONSULTA_TBANCO_ACTUALIZA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Bancos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel_ban2.ResumeLayout(False)
        CType(Me.dgw_ban2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_cta.ResumeLayout(False)
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PANEL_PER1.ResumeLayout(False)
        CType(Me.DGW_PER1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.Panel_ban1.ResumeLayout(False)
        CType(Me.dgw_ban, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_cancelar As Button
    Friend WithEvents btn_consulta1 As Button
    Friend WithEvents btn_lim As Button
    Friend WithEvents BTN_LIMP As Button
    Friend WithEvents BTN_MOD As Button
    Friend WithEvents btn_mod2 As Button
    Friend WithEvents btn_req As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents cbo_act01 As ComboBox
    Friend WithEvents cbo_auxiliar As ComboBox
    Friend WithEvents CBO_CC01 As ComboBox
    Friend WithEvents cbo_comprobante As ComboBox
    Friend WithEvents cbo_mes As ComboBox
    Friend WithEvents CBO_PROYECTO01 As ComboBox
    Friend WithEvents CH_AUX As CheckBox
    Friend WithEvents ch_com As CheckBox
    Friend WithEvents dgw1 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents KL01 As TextBox
    Friend WithEvents KL1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label76 As Label
    Friend WithEvents Label77 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TXT_GLOSA As TextBox
    Friend WithEvents txt_nro_req As TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_letra As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents cbo_año1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents ch_per As System.Windows.Forms.CheckBox
    Friend WithEvents PANEL_PER1 As System.Windows.Forms.Panel
    Friend WithEvents DGW_PER1 As System.Windows.Forms.DataGridView
    Friend WithEvents TXT_DESC1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_doc_per1 As System.Windows.Forms.TextBox
    Friend WithEvents TXT_COD1 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_cod_ban As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc_ban As System.Windows.Forms.TextBox
    Friend WithEvents Panel_ban1 As System.Windows.Forms.Panel
    Friend WithEvents dgw_ban As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel_ban2 As System.Windows.Forms.Panel
    Friend WithEvents dgw_ban2 As System.Windows.Forms.DataGridView
    Friend WithEvents txt_desc_ban2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_ban2 As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ch_cpto As System.Windows.Forms.CheckBox
    Friend WithEvents panel_cta As System.Windows.Forms.Panel
    Friend WithEvents dgw_cta As System.Windows.Forms.DataGridView
    Friend WithEvents txt_desc_cta As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_cta As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents NRO_DOC As System.Windows.Forms.TextBox
End Class
