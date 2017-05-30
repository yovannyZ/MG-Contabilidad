<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CONSULTA_REG_VENTAS
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkNroDocumento = New System.Windows.Forms.CheckBox
        Me.btnLimpiar = New System.Windows.Forms.Button
        Me.txtRuc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dptHasta = New System.Windows.Forms.DateTimePicker
        Me.dtpDe = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboComprobante = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.txtCodCliente = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.txtNroComprobante = New System.Windows.Forms.TextBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.txt_debe_dolares = New System.Windows.Forms.TextBox
        Me.txt_haber_dolares = New System.Windows.Forms.TextBox
        Me.txt_haber_soles = New System.Windows.Forms.TextBox
        Me.txt_debe_soles = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.dgw_per = New System.Windows.Forms.DataGridView
        Me.Panel_PER = New System.Windows.Forms.Panel
        Me.dgw2 = New System.Windows.Forms.DataGridView
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.Label27 = New System.Windows.Forms.Label
        Me.NroFile = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgw_per, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_PER.SuspendLayout()
        CType(Me.dgw2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkNroDocumento)
        Me.GroupBox2.Controls.Add(Me.btnLimpiar)
        Me.GroupBox2.Controls.Add(Me.txtRuc)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.dptHasta)
        Me.GroupBox2.Controls.Add(Me.dtpDe)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cboComprobante)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtDescripcion)
        Me.GroupBox2.Controls.Add(Me.txtCodCliente)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.txtNroComprobante)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(14, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(619, 132)
        Me.GroupBox2.TabIndex = 155
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Consulta"
        '
        'chkNroDocumento
        '
        Me.chkNroDocumento.AutoSize = True
        Me.chkNroDocumento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNroDocumento.Location = New System.Drawing.Point(29, 50)
        Me.chkNroDocumento.Name = "chkNroDocumento"
        Me.chkNroDocumento.Size = New System.Drawing.Size(71, 18)
        Me.chkNroDocumento.TabIndex = 47
        Me.chkNroDocumento.Text = "Nro. Doc."
        Me.chkNroDocumento.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.Location = New System.Drawing.Point(524, 26)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(77, 28)
        Me.btnLimpiar.TabIndex = 46
        Me.btnLimpiar.Text = "&Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'txtRuc
        '
        Me.txtRuc.Location = New System.Drawing.Point(413, 74)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.Size = New System.Drawing.Size(92, 20)
        Me.txtRuc.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(204, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 14)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Hasta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 14)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "De:"
        '
        'dptHasta
        '
        Me.dptHasta.CalendarForeColor = System.Drawing.SystemColors.Desktop
        Me.dptHasta.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaptionText
        Me.dptHasta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dptHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dptHasta.Location = New System.Drawing.Point(251, 100)
        Me.dptHasta.Name = "dptHasta"
        Me.dptHasta.Size = New System.Drawing.Size(77, 20)
        Me.dptHasta.TabIndex = 6
        '
        'dtpDe
        '
        Me.dtpDe.CalendarForeColor = System.Drawing.SystemColors.Desktop
        Me.dtpDe.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaptionText
        Me.dtpDe.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDe.Location = New System.Drawing.Point(111, 100)
        Me.dtpDe.Name = "dtpDe"
        Me.dtpDe.Size = New System.Drawing.Size(77, 20)
        Me.dtpDe.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 14)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Tipo Doc."
        '
        'cboComprobante
        '
        Me.cboComprobante.BackColor = System.Drawing.Color.White
        Me.cboComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComprobante.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboComprobante.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboComprobante.FormattingEnabled = True
        Me.cboComprobante.Location = New System.Drawing.Point(111, 22)
        Me.cboComprobante.MaxDropDownItems = 10
        Me.cboComprobante.Name = "cboComprobante"
        Me.cboComprobante.Size = New System.Drawing.Size(176, 22)
        Me.cboComprobante.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 14)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Cliente"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(167, 74)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(240, 20)
        Me.txtDescripcion.TabIndex = 3
        '
        'txtCodCliente
        '
        Me.txtCodCliente.Location = New System.Drawing.Point(111, 74)
        Me.txtCodCliente.Name = "txtCodCliente"
        Me.txtCodCliente.Size = New System.Drawing.Size(51, 20)
        Me.txtCodCliente.TabIndex = 2
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Search_1
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.Location = New System.Drawing.Point(524, 55)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(77, 28)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "&Consultar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtNroComprobante
        '
        Me.txtNroComprobante.Enabled = False
        Me.txtNroComprobante.Location = New System.Drawing.Point(111, 48)
        Me.txtNroComprobante.Name = "txtNroComprobante"
        Me.txtNroComprobante.Size = New System.Drawing.Size(100, 20)
        Me.txtNroComprobante.TabIndex = 1
        '
        'btn_cancelar
        '
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.Location = New System.Drawing.Point(524, 84)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(77, 28)
        Me.btn_cancelar.TabIndex = 25
        Me.btn_cancelar.Text = "&Salir"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'txt_debe_dolares
        '
        Me.txt_debe_dolares.BackColor = System.Drawing.SystemColors.Window
        Me.txt_debe_dolares.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_debe_dolares.Location = New System.Drawing.Point(145, 533)
        Me.txt_debe_dolares.Name = "txt_debe_dolares"
        Me.txt_debe_dolares.ReadOnly = True
        Me.txt_debe_dolares.Size = New System.Drawing.Size(80, 20)
        Me.txt_debe_dolares.TabIndex = 165
        Me.txt_debe_dolares.TabStop = False
        Me.txt_debe_dolares.Text = "0.00"
        Me.txt_debe_dolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_haber_dolares
        '
        Me.txt_haber_dolares.BackColor = System.Drawing.SystemColors.Window
        Me.txt_haber_dolares.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_haber_dolares.Location = New System.Drawing.Point(145, 555)
        Me.txt_haber_dolares.Name = "txt_haber_dolares"
        Me.txt_haber_dolares.ReadOnly = True
        Me.txt_haber_dolares.Size = New System.Drawing.Size(80, 20)
        Me.txt_haber_dolares.TabIndex = 166
        Me.txt_haber_dolares.TabStop = False
        Me.txt_haber_dolares.Text = "0.00"
        Me.txt_haber_dolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_haber_soles
        '
        Me.txt_haber_soles.BackColor = System.Drawing.SystemColors.Window
        Me.txt_haber_soles.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_haber_soles.Location = New System.Drawing.Point(56, 555)
        Me.txt_haber_soles.Name = "txt_haber_soles"
        Me.txt_haber_soles.ReadOnly = True
        Me.txt_haber_soles.Size = New System.Drawing.Size(83, 20)
        Me.txt_haber_soles.TabIndex = 164
        Me.txt_haber_soles.TabStop = False
        Me.txt_haber_soles.Text = "0.00"
        Me.txt_haber_soles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_debe_soles
        '
        Me.txt_debe_soles.BackColor = System.Drawing.SystemColors.Window
        Me.txt_debe_soles.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_debe_soles.Location = New System.Drawing.Point(56, 533)
        Me.txt_debe_soles.Name = "txt_debe_soles"
        Me.txt_debe_soles.ReadOnly = True
        Me.txt_debe_soles.Size = New System.Drawing.Size(83, 20)
        Me.txt_debe_soles.TabIndex = 163
        Me.txt_debe_soles.TabStop = False
        Me.txt_debe_soles.Text = "0.00"
        Me.txt_debe_soles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(15, 557)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 14)
        Me.Label14.TabIndex = 162
        Me.Label14.Text = "Haber"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(15, 536)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(35, 14)
        Me.Label25.TabIndex = 161
        Me.Label25.Text = "Debe"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(187, 519)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(14, 15)
        Me.Label28.TabIndex = 160
        Me.Label28.Text = "$"
        '
        'dgw_per
        '
        Me.dgw_per.AllowUserToAddRows = False
        Me.dgw_per.AllowUserToDeleteRows = False
        Me.dgw_per.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_per.BackgroundColor = System.Drawing.Color.White
        Me.dgw_per.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_per.Location = New System.Drawing.Point(2, 5)
        Me.dgw_per.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgw_per.MultiSelect = False
        Me.dgw_per.Name = "dgw_per"
        Me.dgw_per.ReadOnly = True
        Me.dgw_per.RowHeadersWidth = 25
        Me.dgw_per.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_per.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_per.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_per.Size = New System.Drawing.Size(518, 119)
        Me.dgw_per.TabIndex = 10
        '
        'Panel_PER
        '
        Me.Panel_PER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_PER.Controls.Add(Me.dgw_per)
        Me.Panel_PER.Location = New System.Drawing.Point(88, 134)
        Me.Panel_PER.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel_PER.Name = "Panel_PER"
        Me.Panel_PER.Size = New System.Drawing.Size(524, 130)
        Me.Panel_PER.TabIndex = 158
        Me.Panel_PER.Visible = False
        '
        'dgw2
        '
        Me.dgw2.AllowUserToAddRows = False
        Me.dgw2.AllowUserToDeleteRows = False
        Me.dgw2.AllowUserToOrderColumns = True
        Me.dgw2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgw2.BackgroundColor = System.Drawing.Color.White
        Me.dgw2.Location = New System.Drawing.Point(12, 324)
        Me.dgw2.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw2.MultiSelect = False
        Me.dgw2.Name = "dgw2"
        Me.dgw2.ReadOnly = True
        Me.dgw2.RowHeadersWidth = 25
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw2.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgw2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw2.Size = New System.Drawing.Size(622, 195)
        Me.dgw2.TabIndex = 157
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AllowUserToOrderColumns = True
        Me.dgw1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroFile, Me.Column1, Me.Column2, Me.Column15, Me.Column16, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14})
        Me.dgw1.Location = New System.Drawing.Point(10, 150)
        Me.dgw1.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.ReadOnly = True
        Me.dgw1.RowHeadersWidth = 25
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw1.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(623, 161)
        Me.dgw1.TabIndex = 156
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(99, 520)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(20, 14)
        Me.Label27.TabIndex = 159
        Me.Label27.Text = "S/."
        '
        'NroFile
        '
        Me.NroFile.HeaderText = "Nro. File"
        Me.NroFile.Name = "NroFile"
        Me.NroFile.ReadOnly = True
        Me.NroFile.Width = 60
        '
        'Column1
        '
        Me.Column1.HeaderText = "Año"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.HeaderText = "Mes"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 50
        '
        'Column15
        '
        Me.Column15.HeaderText = "Doc."
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column16
        '
        Me.Column16.HeaderText = "Nro. Doc."
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Aux."
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 60
        '
        'Column4
        '
        Me.Column4.HeaderText = "Comprob."
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 70
        '
        'Column5
        '
        Me.Column5.HeaderText = "Nro. Comp."
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 70
        '
        'Column6
        '
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column6.HeaderText = "Importe"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 70
        '
        'Column7
        '
        Me.Column7.HeaderText = "Fecha Doc."
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Fecha Comprob."
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Moneda"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 50
        '
        'Column10
        '
        DataGridViewCellStyle3.Format = "N4"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column10.HeaderText = "Tip. Cambio"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 70
        '
        'Column11
        '
        Me.Column11.HeaderText = "Ref."
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 70
        '
        'Column12
        '
        Me.Column12.HeaderText = "Nro. Ref"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 70
        '
        'Column13
        '
        Me.Column13.HeaderText = "Fecha Ref."
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "Tipo"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.Width = 70
        '
        'CONSULTA_REG_VENTAS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(645, 586)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel_PER)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txt_debe_dolares)
        Me.Controls.Add(Me.txt_haber_dolares)
        Me.Controls.Add(Me.txt_haber_soles)
        Me.Controls.Add(Me.txt_debe_soles)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.dgw2)
        Me.Controls.Add(Me.dgw1)
        Me.Controls.Add(Me.Label27)
        Me.KeyPreview = True
        Me.Name = "CONSULTA_REG_VENTAS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta documentos Cta. x Cobrar"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgw_per, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_PER.ResumeLayout(False)
        CType(Me.dgw2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRuc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dptHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDe As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCliente As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtNroComprobante As System.Windows.Forms.TextBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents txt_debe_dolares As System.Windows.Forms.TextBox
    Friend WithEvents txt_haber_dolares As System.Windows.Forms.TextBox
    Friend WithEvents txt_haber_soles As System.Windows.Forms.TextBox
    Friend WithEvents txt_debe_soles As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents dgw_per As System.Windows.Forms.DataGridView
    Friend WithEvents Panel_PER As System.Windows.Forms.Panel
    Friend WithEvents dgw2 As System.Windows.Forms.DataGridView
    Friend WithEvents dgw1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents chkNroDocumento As System.Windows.Forms.CheckBox
    Friend WithEvents NroFile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
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
End Class
