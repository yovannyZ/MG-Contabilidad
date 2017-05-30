Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REFERENCIA_RETENCION
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DGW_CAB = New System.Windows.Forms.DataGridView
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
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button
        Me.BTN_CANCELAR = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblNroPago = New System.Windows.Forms.Label
        Me.txt_NroPago = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbo_moneda = New System.Windows.Forms.ComboBox
        Me.txt_ret = New System.Windows.Forms.TextBox
        Me.txt_conv = New System.Windows.Forms.TextBox
        Me.btn_canc = New System.Windows.Forms.Button
        Me.txt_ini = New System.Windows.Forms.TextBox
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.dtp_ref = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgw_doc = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TXT_PDTE = New System.Windows.Forms.TextBox
        Me.TXT_INI_2DO = New System.Windows.Forms.TextBox
        Me.txt_nro_ref = New System.Windows.Forms.TextBox
        Me.btn_fec = New System.Windows.Forms.Button
        Me.cbo_tipo_ref = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BTN_AGREGAR = New System.Windows.Forms.Button
        Me.BTN_ELIMINAR = New System.Windows.Forms.Button
        Me.txt_total = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_doc_total = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_total2 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_doc_total2 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        CType(Me.DGW_CAB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgw_doc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGW_CAB
        '
        Me.DGW_CAB.AllowUserToAddRows = False
        Me.DGW_CAB.AllowUserToDeleteRows = False
        Me.DGW_CAB.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.DGW_CAB.BackgroundColor = System.Drawing.Color.White
        Me.DGW_CAB.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11})
        Me.DGW_CAB.Location = New System.Drawing.Point(12, 32)
        Me.DGW_CAB.Name = "DGW_CAB"
        Me.DGW_CAB.RowHeadersWidth = 25
        Me.DGW_CAB.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DGW_CAB.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DGW_CAB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGW_CAB.Size = New System.Drawing.Size(546, 183)
        Me.DGW_CAB.TabIndex = 25
        '
        'Column1
        '
        Me.Column1.HeaderText = "Ref."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 35
        '
        'Column2
        '
        Me.Column2.HeaderText = "Nº"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 85
        '
        'Column3
        '
        DataGridViewCellStyle1.Format = "d"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.HeaderText = "Fecha"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 75
        '
        'Column4
        '
        Me.Column4.HeaderText = "Mon"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 30
        '
        'Column5
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.Format = "N2"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column5.HeaderText = "Importe"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 90
        '
        'Column6
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "N2"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column6.HeaderText = "Conv."
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N2"
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column7.HeaderText = "Retención"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column8.HeaderText = "D/H"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 25
        '
        'Column9
        '
        Me.Column9.HeaderText = "ini_2do"
        Me.Column9.Name = "Column9"
        '
        'Column10
        '
        Me.Column10.HeaderText = "pdte"
        Me.Column10.Name = "Column10"
        '
        'Column11
        '
        Me.Column11.HeaderText = "Nro Pago"
        Me.Column11.Name = "Column11"
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BTN_ACEPTAR.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BTN_ACEPTAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_ACEPTAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Ok_1
        Me.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(435, 237)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(90, 28)
        Me.BTN_ACEPTAR.TabIndex = 26
        Me.BTN_ACEPTAR.Text = "&Aceptar"
        '
        'BTN_CANCELAR
        '
        Me.BTN_CANCELAR.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BTN_CANCELAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_CANCELAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CANCELAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.BTN_CANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_CANCELAR.Location = New System.Drawing.Point(531, 237)
        Me.BTN_CANCELAR.Name = "BTN_CANCELAR"
        Me.BTN_CANCELAR.Size = New System.Drawing.Size(90, 28)
        Me.BTN_CANCELAR.TabIndex = 27
        Me.BTN_CANCELAR.Text = "&Cancelar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.dgw_doc)
        Me.GroupBox1.Controls.Add(Me.TXT_PDTE)
        Me.GroupBox1.Controls.Add(Me.TXT_INI_2DO)
        Me.GroupBox1.Controls.Add(Me.txt_nro_ref)
        Me.GroupBox1.Controls.Add(Me.btn_fec)
        Me.GroupBox1.Controls.Add(Me.cbo_tipo_ref)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Location = New System.Drawing.Point(36, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(609, 299)
        Me.GroupBox1.TabIndex = 155
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblNroPago)
        Me.GroupBox2.Controls.Add(Me.txt_NroPago)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cbo_moneda)
        Me.GroupBox2.Controls.Add(Me.txt_ret)
        Me.GroupBox2.Controls.Add(Me.txt_conv)
        Me.GroupBox2.Controls.Add(Me.btn_canc)
        Me.GroupBox2.Controls.Add(Me.txt_ini)
        Me.GroupBox2.Controls.Add(Me.btn_guardar)
        Me.GroupBox2.Controls.Add(Me.dtp_ref)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(255, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(259, 224)
        Me.GroupBox2.TabIndex = 120
        Me.GroupBox2.TabStop = False
        '
        'lblNroPago
        '
        Me.lblNroPago.AutoSize = True
        Me.lblNroPago.Location = New System.Drawing.Point(7, 146)
        Me.lblNroPago.Name = "lblNroPago"
        Me.lblNroPago.Size = New System.Drawing.Size(51, 14)
        Me.lblNroPago.TabIndex = 128
        Me.lblNroPago.Text = "Nro Pago"
        '
        'txt_NroPago
        '
        Me.txt_NroPago.BackColor = System.Drawing.Color.White
        Me.txt_NroPago.Location = New System.Drawing.Point(103, 143)
        Me.txt_NroPago.MaxLength = 60
        Me.txt_NroPago.Name = "txt_NroPago"
        Me.txt_NroPago.Size = New System.Drawing.Size(25, 20)
        Me.txt_NroPago.TabIndex = 127
        Me.txt_NroPago.TabStop = False
        Me.txt_NroPago.Text = "1"
        Me.txt_NroPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Importe"
        '
        'cbo_moneda
        '
        Me.cbo_moneda.BackColor = System.Drawing.Color.White
        Me.cbo_moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_moneda.FormattingEnabled = True
        Me.cbo_moneda.Location = New System.Drawing.Point(103, 50)
        Me.cbo_moneda.Name = "cbo_moneda"
        Me.cbo_moneda.Size = New System.Drawing.Size(134, 22)
        Me.cbo_moneda.TabIndex = 118
        Me.cbo_moneda.TabStop = False
        '
        'txt_ret
        '
        Me.txt_ret.BackColor = System.Drawing.Color.White
        Me.txt_ret.Enabled = False
        Me.txt_ret.Location = New System.Drawing.Point(103, 118)
        Me.txt_ret.MaxLength = 60
        Me.txt_ret.Name = "txt_ret"
        Me.txt_ret.Size = New System.Drawing.Size(92, 20)
        Me.txt_ret.TabIndex = 125
        Me.txt_ret.TabStop = False
        Me.txt_ret.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_conv
        '
        Me.txt_conv.BackColor = System.Drawing.Color.White
        Me.txt_conv.Enabled = False
        Me.txt_conv.Location = New System.Drawing.Point(103, 96)
        Me.txt_conv.MaxLength = 60
        Me.txt_conv.Name = "txt_conv"
        Me.txt_conv.Size = New System.Drawing.Size(92, 20)
        Me.txt_conv.TabIndex = 126
        Me.txt_conv.TabStop = False
        Me.txt_conv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_canc
        '
        Me.btn_canc.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_canc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_canc.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_canc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_canc.Location = New System.Drawing.Point(112, 176)
        Me.btn_canc.Name = "btn_canc"
        Me.btn_canc.Size = New System.Drawing.Size(83, 25)
        Me.btn_canc.TabIndex = 8
        Me.btn_canc.Text = "&Cancelar"
        '
        'txt_ini
        '
        Me.txt_ini.BackColor = System.Drawing.Color.White
        Me.txt_ini.Location = New System.Drawing.Point(103, 74)
        Me.txt_ini.MaxLength = 60
        Me.txt_ini.Name = "txt_ini"
        Me.txt_ini.Size = New System.Drawing.Size(92, 20)
        Me.txt_ini.TabIndex = 119
        Me.txt_ini.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.Location = New System.Drawing.Point(16, 176)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(83, 25)
        Me.btn_guardar.TabIndex = 7
        Me.btn_guardar.Text = "&Guardar"
        '
        'dtp_ref
        '
        Me.dtp_ref.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ref.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_ref.Location = New System.Drawing.Point(103, 28)
        Me.dtp_ref.Name = "dtp_ref"
        Me.dtp_ref.Size = New System.Drawing.Size(82, 20)
        Me.dtp_ref.TabIndex = 117
        Me.dtp_ref.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 14)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "Moneda"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 14)
        Me.Label4.TabIndex = 121
        Me.Label4.Text = "Retención"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 14)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "Conv."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 14)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Fecha"
        '
        'dgw_doc
        '
        Me.dgw_doc.AllowUserToAddRows = False
        Me.dgw_doc.AllowUserToDeleteRows = False
        Me.dgw_doc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_doc.BackgroundColor = System.Drawing.Color.White
        Me.dgw_doc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.dgw_doc.Location = New System.Drawing.Point(10, 70)
        Me.dgw_doc.Name = "dgw_doc"
        Me.dgw_doc.RowHeadersWidth = 25
        Me.dgw_doc.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_doc.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_doc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_doc.Size = New System.Drawing.Size(221, 217)
        Me.dgw_doc.TabIndex = 119
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nº"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 85
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle6.Format = "d"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn3.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 75
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Mon"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 30
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle7.Format = "N2"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn5.HeaderText = "Importe"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 90
        '
        'TXT_PDTE
        '
        Me.TXT_PDTE.Location = New System.Drawing.Point(352, 268)
        Me.TXT_PDTE.Name = "TXT_PDTE"
        Me.TXT_PDTE.Size = New System.Drawing.Size(88, 20)
        Me.TXT_PDTE.TabIndex = 118
        Me.TXT_PDTE.Visible = False
        '
        'TXT_INI_2DO
        '
        Me.TXT_INI_2DO.Location = New System.Drawing.Point(255, 268)
        Me.TXT_INI_2DO.Name = "TXT_INI_2DO"
        Me.TXT_INI_2DO.Size = New System.Drawing.Size(88, 20)
        Me.TXT_INI_2DO.TabIndex = 117
        Me.TXT_INI_2DO.Visible = False
        '
        'txt_nro_ref
        '
        Me.txt_nro_ref.BackColor = System.Drawing.Color.White
        Me.txt_nro_ref.Location = New System.Drawing.Point(91, 44)
        Me.txt_nro_ref.MaxLength = 20
        Me.txt_nro_ref.Name = "txt_nro_ref"
        Me.txt_nro_ref.Size = New System.Drawing.Size(134, 20)
        Me.txt_nro_ref.TabIndex = 2
        '
        'btn_fec
        '
        Me.btn_fec.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_fec.Location = New System.Drawing.Point(446, 254)
        Me.btn_fec.Name = "btn_fec"
        Me.btn_fec.Size = New System.Drawing.Size(85, 33)
        Me.btn_fec.TabIndex = 6
        Me.btn_fec.Text = "&Datos"
        Me.btn_fec.UseVisualStyleBackColor = True
        Me.btn_fec.Visible = False
        '
        'cbo_tipo_ref
        '
        Me.cbo_tipo_ref.BackColor = System.Drawing.Color.White
        Me.cbo_tipo_ref.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo_ref.FormattingEnabled = True
        Me.cbo_tipo_ref.Location = New System.Drawing.Point(91, 19)
        Me.cbo_tipo_ref.Name = "cbo_tipo_ref"
        Me.cbo_tipo_ref.Size = New System.Drawing.Size(134, 22)
        Me.cbo_tipo_ref.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(25, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(19, 14)
        Me.Label12.TabIndex = 111
        Me.Label12.Text = "Nº"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(25, 22)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 14)
        Me.Label30.TabIndex = 113
        Me.Label30.Text = "Referencia"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(663, 303)
        Me.Panel1.TabIndex = 156
        Me.Panel1.Visible = False
        '
        'BTN_AGREGAR
        '
        Me.BTN_AGREGAR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_AGREGAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_AGREGAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.BTN_AGREGAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_AGREGAR.Location = New System.Drawing.Point(574, 49)
        Me.BTN_AGREGAR.Name = "BTN_AGREGAR"
        Me.BTN_AGREGAR.Size = New System.Drawing.Size(72, 25)
        Me.BTN_AGREGAR.TabIndex = 157
        Me.BTN_AGREGAR.Text = "&Agregar"
        '
        'BTN_ELIMINAR
        '
        Me.BTN_ELIMINAR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_ELIMINAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_ELIMINAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.BTN_ELIMINAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ELIMINAR.Location = New System.Drawing.Point(574, 80)
        Me.BTN_ELIMINAR.Name = "BTN_ELIMINAR"
        Me.BTN_ELIMINAR.Size = New System.Drawing.Size(72, 25)
        Me.BTN_ELIMINAR.TabIndex = 158
        Me.BTN_ELIMINAR.Text = "&Eliminar"
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.Color.White
        Me.txt_total.Location = New System.Drawing.Point(87, 230)
        Me.txt_total.MaxLength = 60
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(92, 20)
        Me.txt_total.TabIndex = 160
        Me.txt_total.TabStop = False
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 233)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 14)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "Total"
        '
        'txt_doc_total
        '
        Me.txt_doc_total.BackColor = System.Drawing.Color.White
        Me.txt_doc_total.Location = New System.Drawing.Point(308, 230)
        Me.txt_doc_total.MaxLength = 60
        Me.txt_doc_total.Name = "txt_doc_total"
        Me.txt_doc_total.ReadOnly = True
        Me.txt_doc_total.Size = New System.Drawing.Size(92, 20)
        Me.txt_doc_total.TabIndex = 162
        Me.txt_doc_total.TabStop = False
        Me.txt_doc_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(202, 233)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 14)
        Me.Label7.TabIndex = 161
        Me.Label7.Text = "Total Doc. a Retener"
        '
        'txt_total2
        '
        Me.txt_total2.BackColor = System.Drawing.Color.White
        Me.txt_total2.Location = New System.Drawing.Point(87, 258)
        Me.txt_total2.MaxLength = 60
        Me.txt_total2.Name = "txt_total2"
        Me.txt_total2.ReadOnly = True
        Me.txt_total2.Size = New System.Drawing.Size(92, 20)
        Me.txt_total2.TabIndex = 164
        Me.txt_total2.TabStop = False
        Me.txt_total2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(44, 261)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 14)
        Me.Label8.TabIndex = 163
        Me.Label8.Text = "Total"
        '
        'txt_doc_total2
        '
        Me.txt_doc_total2.BackColor = System.Drawing.Color.White
        Me.txt_doc_total2.Location = New System.Drawing.Point(308, 258)
        Me.txt_doc_total2.MaxLength = 60
        Me.txt_doc_total2.Name = "txt_doc_total2"
        Me.txt_doc_total2.ReadOnly = True
        Me.txt_doc_total2.Size = New System.Drawing.Size(92, 20)
        Me.txt_doc_total2.TabIndex = 166
        Me.txt_doc_total2.TabStop = False
        Me.txt_doc_total2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(202, 261)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 14)
        Me.Label9.TabIndex = 165
        Me.Label9.Text = "Total Retención"
        '
        'REFERENCIA_RETENCION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(662, 304)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BTN_ELIMINAR)
        Me.Controls.Add(Me.BTN_AGREGAR)
        Me.Controls.Add(Me.DGW_CAB)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.BTN_CANCELAR)
        Me.Controls.Add(Me.txt_doc_total)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_total2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_doc_total2)
        Me.Controls.Add(Me.Label9)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REFERENCIA_RETENCION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Comprobantes"
        CType(Me.DGW_CAB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgw_doc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents BTN_CANCELAR As Button
    Friend WithEvents DGW_CAB As DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_nro_ref As System.Windows.Forms.TextBox
    Friend WithEvents btn_fec As System.Windows.Forms.Button
    Friend WithEvents cbo_tipo_ref As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BTN_AGREGAR As System.Windows.Forms.Button
    Friend WithEvents BTN_ELIMINAR As System.Windows.Forms.Button
    Friend WithEvents btn_canc As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_doc_total As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_total2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_doc_total2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXT_PDTE As System.Windows.Forms.TextBox
    Friend WithEvents TXT_INI_2DO As System.Windows.Forms.TextBox
    Friend WithEvents dgw_doc As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_moneda As System.Windows.Forms.ComboBox
    Friend WithEvents txt_ret As System.Windows.Forms.TextBox
    Friend WithEvents txt_conv As System.Windows.Forms.TextBox
    Friend WithEvents txt_ini As System.Windows.Forms.TextBox
    Friend WithEvents dtp_ref As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_NroPago As System.Windows.Forms.TextBox
    Friend WithEvents lblNroPago As System.Windows.Forms.Label
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
End Class
