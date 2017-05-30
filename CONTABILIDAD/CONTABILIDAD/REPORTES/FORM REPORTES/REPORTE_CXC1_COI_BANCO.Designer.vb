<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_CXC1_COI_BANCO
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel_PER1 = New System.Windows.Forms.Panel
        Me.dgw_per1 = New System.Windows.Forms.DataGridView
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_doc_per1 = New System.Windows.Forms.TextBox
        Me.TXT_DESC1 = New System.Windows.Forms.TextBox
        Me.k1 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cbo_tipo_doc1 = New System.Windows.Forms.ComboBox
        Me.CH_DOC1 = New System.Windows.Forms.CheckBox
        Me.BTN_SALIR = New System.Windows.Forms.Button
        Me.ch_per1 = New System.Windows.Forms.CheckBox
        Me.TXT_COD1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBO_SUCURSAL1 = New System.Windows.Forms.ComboBox
        Me.ch_si1 = New System.Windows.Forms.CheckBox
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ssInfo = New System.Windows.Forms.StatusStrip
        Me.tspbExportar = New System.Windows.Forms.ToolStripProgressBar
        Me.tslMensaje = New System.Windows.Forms.ToolStripStatusLabel
        Me.DGW2 = New System.Windows.Forms.DataGridView
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel_PER1.SuspendLayout()
        CType(Me.dgw_per1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssInfo.SuspendLayout()
        CType(Me.DGW2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_PER1
        '
        Me.Panel_PER1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_PER1.Controls.Add(Me.dgw_per1)
        Me.Panel_PER1.Location = New System.Drawing.Point(128, 91)
        Me.Panel_PER1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel_PER1.Name = "Panel_PER1"
        Me.Panel_PER1.Size = New System.Drawing.Size(485, 107)
        Me.Panel_PER1.TabIndex = 66
        Me.Panel_PER1.Visible = False
        '
        'dgw_per1
        '
        Me.dgw_per1.AllowUserToAddRows = False
        Me.dgw_per1.AllowUserToDeleteRows = False
        Me.dgw_per1.AllowUserToOrderColumns = True
        Me.dgw_per1.AllowUserToResizeRows = False
        Me.dgw_per1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_per1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_per1.BackgroundColor = System.Drawing.Color.White
        Me.dgw_per1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_per1.Location = New System.Drawing.Point(2, 1)
        Me.dgw_per1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgw_per1.MultiSelect = False
        Me.dgw_per1.Name = "dgw_per1"
        Me.dgw_per1.ReadOnly = True
        Me.dgw_per1.RowHeadersWidth = 25
        Me.dgw_per1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_per1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_per1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_per1.Size = New System.Drawing.Size(475, 103)
        Me.dgw_per1.TabIndex = 0
        Me.dgw_per1.TabStop = False
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(197, 267)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(261, 56)
        Me.gb1.TabIndex = 68
        Me.gb1.TabStop = False
        '
        'btn_archivo1
        '
        Me.btn_archivo1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo1.Location = New System.Drawing.Point(172, 16)
        Me.btn_archivo1.Name = "btn_archivo1"
        Me.btn_archivo1.Size = New System.Drawing.Size(77, 27)
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
        Me.btn_imprimir1.Location = New System.Drawing.Point(91, 16)
        Me.btn_imprimir1.Name = "btn_imprimir1"
        Me.btn_imprimir1.Size = New System.Drawing.Size(77, 27)
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
        Me.btn_pantalla1.Size = New System.Drawing.Size(77, 27)
        Me.btn_pantalla1.TabIndex = 0
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel_PER1)
        Me.GroupBox1.Controls.Add(Me.cbo_año)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbo_mes)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_doc_per1)
        Me.GroupBox1.Controls.Add(Me.TXT_DESC1)
        Me.GroupBox1.Controls.Add(Me.k1)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cbo_tipo_doc1)
        Me.GroupBox1.Controls.Add(Me.CH_DOC1)
        Me.GroupBox1.Controls.Add(Me.BTN_SALIR)
        Me.GroupBox1.Controls.Add(Me.ch_per1)
        Me.GroupBox1.Controls.Add(Me.TXT_COD1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CBO_SUCURSAL1)
        Me.GroupBox1.Controls.Add(Me.ch_si1)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(618, 203)
        Me.GroupBox1.TabIndex = 67
        Me.GroupBox1.TabStop = False
        '
        'cbo_año
        '
        Me.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año.FormattingEnabled = True
        Me.cbo_año.Location = New System.Drawing.Point(361, 121)
        Me.cbo_año.Name = "cbo_año"
        Me.cbo_año.Size = New System.Drawing.Size(79, 22)
        Me.cbo_año.TabIndex = 132
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(41, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 14)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "Al Mes"
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"INICIO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(134, 119)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(121, 22)
        Me.cbo_mes.TabIndex = 135
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(309, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 14)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "Año"
        '
        'txt_doc_per1
        '
        Me.txt_doc_per1.BackColor = System.Drawing.Color.White
        Me.txt_doc_per1.Location = New System.Drawing.Point(520, 71)
        Me.txt_doc_per1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_doc_per1.MaxLength = 20
        Me.txt_doc_per1.Name = "txt_doc_per1"
        Me.txt_doc_per1.Size = New System.Drawing.Size(89, 20)
        Me.txt_doc_per1.TabIndex = 3
        '
        'TXT_DESC1
        '
        Me.TXT_DESC1.BackColor = System.Drawing.Color.White
        Me.TXT_DESC1.Location = New System.Drawing.Point(189, 71)
        Me.TXT_DESC1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TXT_DESC1.Name = "TXT_DESC1"
        Me.TXT_DESC1.Size = New System.Drawing.Size(329, 20)
        Me.TXT_DESC1.TabIndex = 2
        '
        'k1
        '
        Me.k1.Location = New System.Drawing.Point(535, 71)
        Me.k1.Name = "k1"
        Me.k1.Size = New System.Drawing.Size(10, 20)
        Me.k1.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(41, 94)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 14)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Documento"
        '
        'cbo_tipo_doc1
        '
        Me.cbo_tipo_doc1.BackColor = System.Drawing.Color.White
        Me.cbo_tipo_doc1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo_doc1.FormattingEnabled = True
        Me.cbo_tipo_doc1.Location = New System.Drawing.Point(134, 91)
        Me.cbo_tipo_doc1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbo_tipo_doc1.Name = "cbo_tipo_doc1"
        Me.cbo_tipo_doc1.Size = New System.Drawing.Size(180, 22)
        Me.cbo_tipo_doc1.TabIndex = 5
        '
        'CH_DOC1
        '
        Me.CH_DOC1.AutoSize = True
        Me.CH_DOC1.Checked = True
        Me.CH_DOC1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CH_DOC1.Location = New System.Drawing.Point(114, 95)
        Me.CH_DOC1.Name = "CH_DOC1"
        Me.CH_DOC1.Size = New System.Drawing.Size(15, 14)
        Me.CH_DOC1.TabIndex = 8
        Me.CH_DOC1.UseVisualStyleBackColor = True
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_SALIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_SALIR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.Location = New System.Drawing.Point(532, 155)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(77, 27)
        Me.BTN_SALIR.TabIndex = 12
        Me.BTN_SALIR.TabStop = False
        Me.BTN_SALIR.Text = "&Salir"
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'ch_per1
        '
        Me.ch_per1.AutoSize = True
        Me.ch_per1.Checked = True
        Me.ch_per1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_per1.Location = New System.Drawing.Point(114, 75)
        Me.ch_per1.Name = "ch_per1"
        Me.ch_per1.Size = New System.Drawing.Size(15, 14)
        Me.ch_per1.TabIndex = 3
        Me.ch_per1.UseVisualStyleBackColor = True
        '
        'TXT_COD1
        '
        Me.TXT_COD1.BackColor = System.Drawing.Color.White
        Me.TXT_COD1.Location = New System.Drawing.Point(134, 71)
        Me.TXT_COD1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TXT_COD1.MaxLength = 5
        Me.TXT_COD1.Name = "TXT_COD1"
        Me.TXT_COD1.Size = New System.Drawing.Size(51, 20)
        Me.TXT_COD1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 14)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 52)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 14)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Sucursal"
        '
        'CBO_SUCURSAL1
        '
        Me.CBO_SUCURSAL1.BackColor = System.Drawing.Color.White
        Me.CBO_SUCURSAL1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_SUCURSAL1.FormattingEnabled = True
        Me.CBO_SUCURSAL1.Location = New System.Drawing.Point(134, 49)
        Me.CBO_SUCURSAL1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CBO_SUCURSAL1.Name = "CBO_SUCURSAL1"
        Me.CBO_SUCURSAL1.Size = New System.Drawing.Size(337, 22)
        Me.CBO_SUCURSAL1.TabIndex = 0
        '
        'ch_si1
        '
        Me.ch_si1.AutoSize = True
        Me.ch_si1.Checked = True
        Me.ch_si1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_si1.Location = New System.Drawing.Point(114, 53)
        Me.ch_si1.Name = "ch_si1"
        Me.ch_si1.Size = New System.Drawing.Size(15, 14)
        Me.ch_si1.TabIndex = 1
        Me.ch_si1.UseVisualStyleBackColor = True
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AllowUserToOrderColumns = True
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgw1.Location = New System.Drawing.Point(29, 267)
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.RowHeadersWidth = 25
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(162, 113)
        Me.dgw1.TabIndex = 134
        Me.dgw1.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "TIPO_CTA"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 70
        '
        'Column2
        '
        Me.Column2.HeaderText = "TIPO_MOD"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 70
        '
        'Column3
        '
        Me.Column3.HeaderText = "DOC"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 30
        '
        'ssInfo
        '
        Me.ssInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspbExportar, Me.tslMensaje})
        Me.ssInfo.Location = New System.Drawing.Point(0, 358)
        Me.ssInfo.Name = "ssInfo"
        Me.ssInfo.Size = New System.Drawing.Size(677, 22)
        Me.ssInfo.TabIndex = 135
        Me.ssInfo.Text = "StatusStrip1"
        '
        'tspbExportar
        '
        Me.tspbExportar.Name = "tspbExportar"
        Me.tspbExportar.Size = New System.Drawing.Size(100, 16)
        Me.tspbExportar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.tspbExportar.Visible = False
        '
        'tslMensaje
        '
        Me.tslMensaje.Name = "tslMensaje"
        Me.tslMensaje.Size = New System.Drawing.Size(136, 17)
        Me.tslMensaje.Text = "Generando archivo Excel"
        Me.tslMensaje.Visible = False
        '
        'DGW2
        '
        Me.DGW2.AllowUserToAddRows = False
        Me.DGW2.AllowUserToDeleteRows = False
        Me.DGW2.AllowUserToOrderColumns = True
        Me.DGW2.BackgroundColor = System.Drawing.Color.White
        Me.DGW2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGW2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column9, Me.Column10, Me.Column11, Me.Column15, Me.Column6, Me.Column7, Me.Column8, Me.Column12, Me.Column13, Me.Column22, Me.Column14, Me.Column4, Me.Column19, Me.Column20, Me.Column21})
        Me.DGW2.Location = New System.Drawing.Point(12, 0)
        Me.DGW2.MultiSelect = False
        Me.DGW2.Name = "DGW2"
        Me.DGW2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGW2.Size = New System.Drawing.Size(635, 85)
        Me.DGW2.TabIndex = 138
        Me.DGW2.Visible = False
        '
        'Column9
        '
        Me.Column9.HeaderText = "COD_PER"
        Me.Column9.Name = "Column9"
        '
        'Column10
        '
        Me.Column10.HeaderText = "DESC_PER"
        Me.Column10.Name = "Column10"
        '
        'Column11
        '
        Me.Column11.HeaderText = "[RUC]"
        Me.Column11.Name = "Column11"
        '
        'Column15
        '
        Me.Column15.HeaderText = "MON"
        Me.Column15.Name = "Column15"
        '
        'Column6
        '
        Me.Column6.HeaderText = "COD_DOC"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "DOC"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = "NRO_DOC"
        Me.Column8.Name = "Column8"
        '
        'Column12
        '
        Me.Column12.HeaderText = "FE_DOC"
        Me.Column12.Name = "Column12"
        '
        'Column13
        '
        Me.Column13.HeaderText = "FE_VEN"
        Me.Column13.Name = "Column13"
        '
        'Column22
        '
        Me.Column22.HeaderText = "Dias"
        Me.Column22.Name = "Column22"
        Me.Column22.Width = 60
        '
        'Column14
        '
        Me.Column14.HeaderText = "IMP_DOC"
        Me.Column14.Name = "Column14"
        '
        'Column4
        '
        Me.Column4.HeaderText = "AUX."
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 70
        '
        'Column19
        '
        Me.Column19.HeaderText = "COD_COMP"
        Me.Column19.Name = "Column19"
        '
        'Column20
        '
        Me.Column20.HeaderText = "NRO_COMP"
        Me.Column20.Name = "Column20"
        '
        'Column21
        '
        Me.Column21.HeaderText = "COD_CUENTA"
        Me.Column21.Name = "Column21"
        '
        'REPORTE_CXC1_COI_BANCO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 380)
        Me.ControlBox = False
        Me.Controls.Add(Me.DGW2)
        Me.Controls.Add(Me.ssInfo)
        Me.Controls.Add(Me.dgw1)
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_CXC1_COI_BANCO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE CUENTAS POR COBRAR BANCO"
        Me.Panel_PER1.ResumeLayout(False)
        CType(Me.dgw_per1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssInfo.ResumeLayout(False)
        Me.ssInfo.PerformLayout()
        CType(Me.DGW2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel_PER1 As System.Windows.Forms.Panel
    Friend WithEvents dgw_per1 As System.Windows.Forms.DataGridView
    Friend WithEvents gb1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_archivo1 As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir1 As System.Windows.Forms.Button
    Friend WithEvents btn_pantalla1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_año As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_doc_per1 As System.Windows.Forms.TextBox
    Friend WithEvents TXT_DESC1 As System.Windows.Forms.TextBox
    Friend WithEvents k1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbo_tipo_doc1 As System.Windows.Forms.ComboBox
    Friend WithEvents CH_DOC1 As System.Windows.Forms.CheckBox
    Friend WithEvents BTN_SALIR As System.Windows.Forms.Button
    Friend WithEvents ch_per1 As System.Windows.Forms.CheckBox
    Friend WithEvents TXT_COD1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBO_SUCURSAL1 As System.Windows.Forms.ComboBox
    Friend WithEvents ch_si1 As System.Windows.Forms.CheckBox
    Friend WithEvents dgw1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ssInfo As System.Windows.Forms.StatusStrip
    Friend WithEvents tspbExportar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tslMensaje As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DGW2 As System.Windows.Forms.DataGridView
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
