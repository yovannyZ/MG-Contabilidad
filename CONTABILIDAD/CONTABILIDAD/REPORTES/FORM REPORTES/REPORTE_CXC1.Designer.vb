Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_CXC1
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Panel_PER1 = New System.Windows.Forms.Panel
        Me.dgw_per1 = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TXT_DESC1 = New System.Windows.Forms.TextBox
        Me.k1 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cbo_tipo_doc1 = New System.Windows.Forms.ComboBox
        Me.CH_DOC1 = New System.Windows.Forms.CheckBox
        Me.BTN_SALIR = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtp02 = New System.Windows.Forms.DateTimePicker
        Me.ch_per1 = New System.Windows.Forms.CheckBox
        Me.txt_doc_per1 = New System.Windows.Forms.TextBox
        Me.TXT_COD1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBO_SUCURSAL1 = New System.Windows.Forms.ComboBox
        Me.ch_si1 = New System.Windows.Forms.CheckBox
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.btn_archivo02 = New System.Windows.Forms.Button
        Me.btn_imprimir02 = New System.Windows.Forms.Button
        Me.btn_pantalla02 = New System.Windows.Forms.Button
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cbo_tipo_doc02 = New System.Windows.Forms.ComboBox
        Me.ch_doc02 = New System.Windows.Forms.CheckBox
        Me.btn_salir02 = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.dtp_doc022 = New System.Windows.Forms.DateTimePicker
        Me.dtp_02 = New System.Windows.Forms.DateTimePicker
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.cbo_suc02 = New System.Windows.Forms.ComboBox
        Me.ch_suc02 = New System.Windows.Forms.CheckBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Panel_per2 = New System.Windows.Forms.Panel
        Me.dgw_per2 = New System.Windows.Forms.DataGridView
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_archivo2 = New System.Windows.Forms.Button
        Me.btn_imprimir2 = New System.Windows.Forms.Button
        Me.btn_pantalla2 = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_desc2 = New System.Windows.Forms.TextBox
        Me.k2 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cbo_tipo_doc2 = New System.Windows.Forms.ComboBox
        Me.CH_DOC2 = New System.Windows.Forms.CheckBox
        Me.btn_salir2 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtp04 = New System.Windows.Forms.DateTimePicker
        Me.dtp03 = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.ch_per2 = New System.Windows.Forms.CheckBox
        Me.txt_doc_per2 = New System.Windows.Forms.TextBox
        Me.txt_cod2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbo_sucursal2 = New System.Windows.Forms.ComboBox
        Me.ch_si2 = New System.Windows.Forms.CheckBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.panel_per3 = New System.Windows.Forms.Panel
        Me.dgw_per3 = New System.Windows.Forms.DataGridView
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.btn_archivo3 = New System.Windows.Forms.Button
        Me.btn_imprimir3 = New System.Windows.Forms.Button
        Me.btn_pantalla3 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txt_desc3 = New System.Windows.Forms.TextBox
        Me.k3 = New System.Windows.Forms.TextBox
        Me.txt_dia = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cbo_tipo_doc3 = New System.Windows.Forms.ComboBox
        Me.ch_doc3 = New System.Windows.Forms.CheckBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtp06 = New System.Windows.Forms.DateTimePicker
        Me.dtp05 = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.ch_per3 = New System.Windows.Forms.CheckBox
        Me.txt_doc_per3 = New System.Windows.Forms.TextBox
        Me.txt_cod3 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cbo_sucursal3 = New System.Windows.Forms.ComboBox
        Me.ch_suc3 = New System.Windows.Forms.CheckBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel_PER1.SuspendLayout()
        CType(Me.dgw_per1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel_per2.SuspendLayout()
        CType(Me.dgw_per2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.panel_per3.SuspendLayout()
        CType(Me.dgw_per3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(603, 274)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel_PER1)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.gb1)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(595, 247)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel_PER1
        '
        Me.Panel_PER1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_PER1.Controls.Add(Me.dgw_per1)
        Me.Panel_PER1.Location = New System.Drawing.Point(94, 75)
        Me.Panel_PER1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel_PER1.Name = "Panel_PER1"
        Me.Panel_PER1.Size = New System.Drawing.Size(482, 111)
        Me.Panel_PER1.TabIndex = 0
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Location = New System.Drawing.Point(538, 217)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(21, 10)
        Me.Panel1.TabIndex = 30
        Me.Panel1.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(136, 3)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(181, 95)
        Me.DataGridView1.TabIndex = 7
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(140, 176)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(261, 56)
        Me.gb1.TabIndex = 29
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
        Me.GroupBox1.Controls.Add(Me.TXT_DESC1)
        Me.GroupBox1.Controls.Add(Me.k1)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cbo_tipo_doc1)
        Me.GroupBox1.Controls.Add(Me.CH_DOC1)
        Me.GroupBox1.Controls.Add(Me.BTN_SALIR)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtp02)
        Me.GroupBox1.Controls.Add(Me.ch_per1)
        Me.GroupBox1.Controls.Add(Me.txt_doc_per1)
        Me.GroupBox1.Controls.Add(Me.TXT_COD1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CBO_SUCURSAL1)
        Me.GroupBox1.Controls.Add(Me.ch_si1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(568, 145)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        '
        'TXT_DESC1
        '
        Me.TXT_DESC1.BackColor = System.Drawing.Color.White
        Me.TXT_DESC1.Location = New System.Drawing.Point(183, 47)
        Me.TXT_DESC1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TXT_DESC1.Name = "TXT_DESC1"
        Me.TXT_DESC1.Size = New System.Drawing.Size(282, 20)
        Me.TXT_DESC1.TabIndex = 5
        '
        'k1
        '
        Me.k1.Location = New System.Drawing.Point(342, 47)
        Me.k1.Name = "k1"
        Me.k1.Size = New System.Drawing.Size(10, 20)
        Me.k1.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(39, 78)
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
        Me.cbo_tipo_doc1.Location = New System.Drawing.Point(132, 75)
        Me.cbo_tipo_doc1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbo_tipo_doc1.Name = "cbo_tipo_doc1"
        Me.cbo_tipo_doc1.Size = New System.Drawing.Size(180, 22)
        Me.cbo_tipo_doc1.TabIndex = 9
        '
        'CH_DOC1
        '
        Me.CH_DOC1.AutoSize = True
        Me.CH_DOC1.Checked = True
        Me.CH_DOC1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CH_DOC1.Location = New System.Drawing.Point(105, 77)
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
        Me.BTN_SALIR.Location = New System.Drawing.Point(485, 78)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(77, 27)
        Me.BTN_SALIR.TabIndex = 12
        Me.BTN_SALIR.TabStop = False
        Me.BTN_SALIR.Text = "&Salir"
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 14)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Al "
        '
        'dtp02
        '
        Me.dtp02.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp02.Location = New System.Drawing.Point(132, 110)
        Me.dtp02.Name = "dtp02"
        Me.dtp02.Size = New System.Drawing.Size(86, 20)
        Me.dtp02.TabIndex = 11
        '
        'ch_per1
        '
        Me.ch_per1.AutoSize = True
        Me.ch_per1.Checked = True
        Me.ch_per1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_per1.Location = New System.Drawing.Point(105, 49)
        Me.ch_per1.Name = "ch_per1"
        Me.ch_per1.Size = New System.Drawing.Size(15, 14)
        Me.ch_per1.TabIndex = 3
        Me.ch_per1.UseVisualStyleBackColor = True
        '
        'txt_doc_per1
        '
        Me.txt_doc_per1.BackColor = System.Drawing.Color.White
        Me.txt_doc_per1.Location = New System.Drawing.Point(465, 47)
        Me.txt_doc_per1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_doc_per1.MaxLength = 20
        Me.txt_doc_per1.Name = "txt_doc_per1"
        Me.txt_doc_per1.Size = New System.Drawing.Size(89, 20)
        Me.txt_doc_per1.TabIndex = 6
        '
        'TXT_COD1
        '
        Me.TXT_COD1.BackColor = System.Drawing.Color.White
        Me.TXT_COD1.Location = New System.Drawing.Point(132, 47)
        Me.TXT_COD1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TXT_COD1.MaxLength = 5
        Me.TXT_COD1.Name = "TXT_COD1"
        Me.TXT_COD1.Size = New System.Drawing.Size(51, 20)
        Me.TXT_COD1.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 14)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 22)
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
        Me.CBO_SUCURSAL1.Location = New System.Drawing.Point(132, 19)
        Me.CBO_SUCURSAL1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CBO_SUCURSAL1.Name = "CBO_SUCURSAL1"
        Me.CBO_SUCURSAL1.Size = New System.Drawing.Size(337, 22)
        Me.CBO_SUCURSAL1.TabIndex = 2
        '
        'ch_si1
        '
        Me.ch_si1.AutoSize = True
        Me.ch_si1.Checked = True
        Me.ch_si1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_si1.Location = New System.Drawing.Point(105, 21)
        Me.ch_si1.Name = "ch_si1"
        Me.ch_si1.Size = New System.Drawing.Size(15, 14)
        Me.ch_si1.TabIndex = 1
        Me.ch_si1.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox6)
        Me.TabPage4.Controls.Add(Me.GroupBox7)
        Me.TabPage4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(595, 247)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Vencimiento x Fecha"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.White
        Me.GroupBox6.Controls.Add(Me.btn_archivo02)
        Me.GroupBox6.Controls.Add(Me.btn_imprimir02)
        Me.GroupBox6.Controls.Add(Me.btn_pantalla02)
        Me.GroupBox6.Location = New System.Drawing.Point(140, 168)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(261, 57)
        Me.GroupBox6.TabIndex = 35
        Me.GroupBox6.TabStop = False
        '
        'btn_archivo02
        '
        Me.btn_archivo02.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo02.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo02.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo02.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo02.Location = New System.Drawing.Point(172, 16)
        Me.btn_archivo02.Name = "btn_archivo02"
        Me.btn_archivo02.Size = New System.Drawing.Size(77, 27)
        Me.btn_archivo02.TabIndex = 2
        Me.btn_archivo02.Text = "&Archivo"
        Me.btn_archivo02.UseVisualStyleBackColor = False
        '
        'btn_imprimir02
        '
        Me.btn_imprimir02.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_imprimir02.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprimir02.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.btn_imprimir02.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir02.Location = New System.Drawing.Point(91, 16)
        Me.btn_imprimir02.Name = "btn_imprimir02"
        Me.btn_imprimir02.Size = New System.Drawing.Size(77, 27)
        Me.btn_imprimir02.TabIndex = 1
        Me.btn_imprimir02.Text = "&Imprimir"
        Me.btn_imprimir02.UseVisualStyleBackColor = False
        '
        'btn_pantalla02
        '
        Me.btn_pantalla02.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pantalla02.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla02.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla02.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla02.Location = New System.Drawing.Point(10, 16)
        Me.btn_pantalla02.Name = "btn_pantalla02"
        Me.btn_pantalla02.Size = New System.Drawing.Size(77, 27)
        Me.btn_pantalla02.TabIndex = 0
        Me.btn_pantalla02.Text = "&Pantalla"
        Me.btn_pantalla02.UseVisualStyleBackColor = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label17)
        Me.GroupBox7.Controls.Add(Me.cbo_tipo_doc02)
        Me.GroupBox7.Controls.Add(Me.ch_doc02)
        Me.GroupBox7.Controls.Add(Me.btn_salir02)
        Me.GroupBox7.Controls.Add(Me.Label18)
        Me.GroupBox7.Controls.Add(Me.dtp_doc022)
        Me.GroupBox7.Controls.Add(Me.dtp_02)
        Me.GroupBox7.Controls.Add(Me.Label19)
        Me.GroupBox7.Controls.Add(Me.Label21)
        Me.GroupBox7.Controls.Add(Me.cbo_suc02)
        Me.GroupBox7.Controls.Add(Me.ch_suc02)
        Me.GroupBox7.Location = New System.Drawing.Point(8, 20)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(570, 142)
        Me.GroupBox7.TabIndex = 34
        Me.GroupBox7.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(40, 63)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 14)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "Documento"
        '
        'cbo_tipo_doc02
        '
        Me.cbo_tipo_doc02.BackColor = System.Drawing.Color.White
        Me.cbo_tipo_doc02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo_doc02.FormattingEnabled = True
        Me.cbo_tipo_doc02.Location = New System.Drawing.Point(132, 60)
        Me.cbo_tipo_doc02.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbo_tipo_doc02.Name = "cbo_tipo_doc02"
        Me.cbo_tipo_doc02.Size = New System.Drawing.Size(202, 22)
        Me.cbo_tipo_doc02.TabIndex = 9
        '
        'ch_doc02
        '
        Me.ch_doc02.AutoSize = True
        Me.ch_doc02.Checked = True
        Me.ch_doc02.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_doc02.Location = New System.Drawing.Point(106, 64)
        Me.ch_doc02.Name = "ch_doc02"
        Me.ch_doc02.Size = New System.Drawing.Size(15, 14)
        Me.ch_doc02.TabIndex = 8
        Me.ch_doc02.UseVisualStyleBackColor = True
        '
        'btn_salir02
        '
        Me.btn_salir02.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salir02.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir02.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir02.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir02.Location = New System.Drawing.Point(454, 93)
        Me.btn_salir02.Name = "btn_salir02"
        Me.btn_salir02.Size = New System.Drawing.Size(77, 27)
        Me.btn_salir02.TabIndex = 12
        Me.btn_salir02.TabStop = False
        Me.btn_salir02.Text = "&Salir"
        Me.btn_salir02.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(224, 93)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(20, 14)
        Me.Label18.TabIndex = 33
        Me.Label18.Text = "Al "
        '
        'dtp_doc022
        '
        Me.dtp_doc022.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_doc022.Location = New System.Drawing.Point(248, 90)
        Me.dtp_doc022.Name = "dtp_doc022"
        Me.dtp_doc022.Size = New System.Drawing.Size(86, 20)
        Me.dtp_doc022.TabIndex = 11
        '
        'dtp_02
        '
        Me.dtp_02.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_02.Location = New System.Drawing.Point(132, 90)
        Me.dtp_02.Name = "dtp_02"
        Me.dtp_02.Size = New System.Drawing.Size(86, 20)
        Me.dtp_02.TabIndex = 10
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(40, 93)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(59, 14)
        Me.Label19.TabIndex = 30
        Me.Label19.Text = "Rango Del "
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(40, 35)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(50, 14)
        Me.Label21.TabIndex = 24
        Me.Label21.Text = "Sucursal"
        '
        'cbo_suc02
        '
        Me.cbo_suc02.BackColor = System.Drawing.Color.White
        Me.cbo_suc02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_suc02.FormattingEnabled = True
        Me.cbo_suc02.Location = New System.Drawing.Point(132, 32)
        Me.cbo_suc02.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbo_suc02.Name = "cbo_suc02"
        Me.cbo_suc02.Size = New System.Drawing.Size(399, 22)
        Me.cbo_suc02.TabIndex = 2
        '
        'ch_suc02
        '
        Me.ch_suc02.Checked = True
        Me.ch_suc02.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_suc02.Location = New System.Drawing.Point(106, 34)
        Me.ch_suc02.Name = "ch_suc02"
        Me.ch_suc02.Size = New System.Drawing.Size(15, 14)
        Me.ch_suc02.TabIndex = 1
        Me.ch_suc02.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel_per2)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(595, 247)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Por Vencimiento x Persona"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel_per2
        '
        Me.Panel_per2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_per2.Controls.Add(Me.dgw_per2)
        Me.Panel_per2.Location = New System.Drawing.Point(74, 75)
        Me.Panel_per2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel_per2.Name = "Panel_per2"
        Me.Panel_per2.Size = New System.Drawing.Size(499, 116)
        Me.Panel_per2.TabIndex = 0
        Me.Panel_per2.Visible = False
        '
        'dgw_per2
        '
        Me.dgw_per2.AllowUserToAddRows = False
        Me.dgw_per2.AllowUserToDeleteRows = False
        Me.dgw_per2.AllowUserToOrderColumns = True
        Me.dgw_per2.AllowUserToResizeRows = False
        Me.dgw_per2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_per2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_per2.BackgroundColor = System.Drawing.Color.White
        Me.dgw_per2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_per2.Location = New System.Drawing.Point(2, 3)
        Me.dgw_per2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgw_per2.MultiSelect = False
        Me.dgw_per2.Name = "dgw_per2"
        Me.dgw_per2.ReadOnly = True
        Me.dgw_per2.RowHeadersWidth = 25
        Me.dgw_per2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_per2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_per2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_per2.Size = New System.Drawing.Size(493, 108)
        Me.dgw_per2.TabIndex = 0
        Me.dgw_per2.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.btn_archivo2)
        Me.GroupBox4.Controls.Add(Me.btn_imprimir2)
        Me.GroupBox4.Controls.Add(Me.btn_pantalla2)
        Me.GroupBox4.Location = New System.Drawing.Point(140, 181)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(261, 57)
        Me.GroupBox4.TabIndex = 32
        Me.GroupBox4.TabStop = False
        '
        'btn_archivo2
        '
        Me.btn_archivo2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo2.Location = New System.Drawing.Point(172, 16)
        Me.btn_archivo2.Name = "btn_archivo2"
        Me.btn_archivo2.Size = New System.Drawing.Size(77, 27)
        Me.btn_archivo2.TabIndex = 2
        Me.btn_archivo2.Text = "&Archivo"
        Me.btn_archivo2.UseVisualStyleBackColor = False
        '
        'btn_imprimir2
        '
        Me.btn_imprimir2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_imprimir2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprimir2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.btn_imprimir2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir2.Location = New System.Drawing.Point(91, 16)
        Me.btn_imprimir2.Name = "btn_imprimir2"
        Me.btn_imprimir2.Size = New System.Drawing.Size(77, 27)
        Me.btn_imprimir2.TabIndex = 1
        Me.btn_imprimir2.Text = "&Imprimir"
        Me.btn_imprimir2.UseVisualStyleBackColor = False
        '
        'btn_pantalla2
        '
        Me.btn_pantalla2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pantalla2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla2.Location = New System.Drawing.Point(10, 16)
        Me.btn_pantalla2.Name = "btn_pantalla2"
        Me.btn_pantalla2.Size = New System.Drawing.Size(77, 27)
        Me.btn_pantalla2.TabIndex = 0
        Me.btn_pantalla2.Text = "&Pantalla"
        Me.btn_pantalla2.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_desc2)
        Me.GroupBox2.Controls.Add(Me.k2)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.cbo_tipo_doc2)
        Me.GroupBox2.Controls.Add(Me.CH_DOC2)
        Me.GroupBox2.Controls.Add(Me.btn_salir2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.dtp04)
        Me.GroupBox2.Controls.Add(Me.dtp03)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.ch_per2)
        Me.GroupBox2.Controls.Add(Me.txt_doc_per2)
        Me.GroupBox2.Controls.Add(Me.txt_cod2)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cbo_sucursal2)
        Me.GroupBox2.Controls.Add(Me.ch_si2)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(570, 149)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        '
        'txt_desc2
        '
        Me.txt_desc2.BackColor = System.Drawing.Color.White
        Me.txt_desc2.Location = New System.Drawing.Point(187, 47)
        Me.txt_desc2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_desc2.Name = "txt_desc2"
        Me.txt_desc2.Size = New System.Drawing.Size(285, 20)
        Me.txt_desc2.TabIndex = 5
        '
        'k2
        '
        Me.k2.Location = New System.Drawing.Point(372, 47)
        Me.k2.Name = "k2"
        Me.k2.Size = New System.Drawing.Size(10, 20)
        Me.k2.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(40, 77)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 14)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "Documento"
        '
        'cbo_tipo_doc2
        '
        Me.cbo_tipo_doc2.BackColor = System.Drawing.Color.White
        Me.cbo_tipo_doc2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo_doc2.FormattingEnabled = True
        Me.cbo_tipo_doc2.Location = New System.Drawing.Point(132, 74)
        Me.cbo_tipo_doc2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbo_tipo_doc2.Name = "cbo_tipo_doc2"
        Me.cbo_tipo_doc2.Size = New System.Drawing.Size(180, 22)
        Me.cbo_tipo_doc2.TabIndex = 9
        '
        'CH_DOC2
        '
        Me.CH_DOC2.AutoSize = True
        Me.CH_DOC2.Checked = True
        Me.CH_DOC2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CH_DOC2.Location = New System.Drawing.Point(106, 76)
        Me.CH_DOC2.Name = "CH_DOC2"
        Me.CH_DOC2.Size = New System.Drawing.Size(15, 14)
        Me.CH_DOC2.TabIndex = 8
        Me.CH_DOC2.UseVisualStyleBackColor = True
        '
        'btn_salir2
        '
        Me.btn_salir2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salir2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir2.Location = New System.Drawing.Point(488, 77)
        Me.btn_salir2.Name = "btn_salir2"
        Me.btn_salir2.Size = New System.Drawing.Size(77, 27)
        Me.btn_salir2.TabIndex = 12
        Me.btn_salir2.TabStop = False
        Me.btn_salir2.Text = "&Salir"
        Me.btn_salir2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(292, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 14)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Al "
        '
        'dtp04
        '
        Me.dtp04.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp04.Location = New System.Drawing.Point(386, 114)
        Me.dtp04.Name = "dtp04"
        Me.dtp04.Size = New System.Drawing.Size(86, 20)
        Me.dtp04.TabIndex = 11
        '
        'dtp03
        '
        Me.dtp03.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp03.Location = New System.Drawing.Point(132, 114)
        Me.dtp03.Name = "dtp03"
        Me.dtp03.Size = New System.Drawing.Size(86, 20)
        Me.dtp03.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(42, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 14)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Rango Del "
        '
        'ch_per2
        '
        Me.ch_per2.AutoSize = True
        Me.ch_per2.Checked = True
        Me.ch_per2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_per2.Location = New System.Drawing.Point(106, 49)
        Me.ch_per2.Name = "ch_per2"
        Me.ch_per2.Size = New System.Drawing.Size(15, 14)
        Me.ch_per2.TabIndex = 3
        Me.ch_per2.UseVisualStyleBackColor = True
        '
        'txt_doc_per2
        '
        Me.txt_doc_per2.BackColor = System.Drawing.Color.White
        Me.txt_doc_per2.Location = New System.Drawing.Point(476, 47)
        Me.txt_doc_per2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_doc_per2.MaxLength = 20
        Me.txt_doc_per2.Name = "txt_doc_per2"
        Me.txt_doc_per2.Size = New System.Drawing.Size(89, 20)
        Me.txt_doc_per2.TabIndex = 6
        '
        'txt_cod2
        '
        Me.txt_cod2.BackColor = System.Drawing.Color.White
        Me.txt_cod2.Location = New System.Drawing.Point(132, 47)
        Me.txt_cod2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_cod2.MaxLength = 5
        Me.txt_cod2.Name = "txt_cod2"
        Me.txt_cod2.Size = New System.Drawing.Size(51, 20)
        Me.txt_cod2.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(41, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 14)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Cliente"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(40, 22)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 14)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Sucursal"
        '
        'cbo_sucursal2
        '
        Me.cbo_sucursal2.BackColor = System.Drawing.Color.White
        Me.cbo_sucursal2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_sucursal2.FormattingEnabled = True
        Me.cbo_sucursal2.Location = New System.Drawing.Point(132, 19)
        Me.cbo_sucursal2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbo_sucursal2.Name = "cbo_sucursal2"
        Me.cbo_sucursal2.Size = New System.Drawing.Size(340, 22)
        Me.cbo_sucursal2.TabIndex = 2
        '
        'ch_si2
        '
        Me.ch_si2.AutoSize = True
        Me.ch_si2.Checked = True
        Me.ch_si2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_si2.Location = New System.Drawing.Point(106, 21)
        Me.ch_si2.Name = "ch_si2"
        Me.ch_si2.Size = New System.Drawing.Size(15, 14)
        Me.ch_si2.TabIndex = 1
        Me.ch_si2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.panel_per3)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(595, 247)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cronograma"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'panel_per3
        '
        Me.panel_per3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_per3.Controls.Add(Me.dgw_per3)
        Me.panel_per3.Location = New System.Drawing.Point(77, 76)
        Me.panel_per3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.panel_per3.Name = "panel_per3"
        Me.panel_per3.Size = New System.Drawing.Size(501, 117)
        Me.panel_per3.TabIndex = 32
        Me.panel_per3.Visible = False
        '
        'dgw_per3
        '
        Me.dgw_per3.AllowUserToAddRows = False
        Me.dgw_per3.AllowUserToDeleteRows = False
        Me.dgw_per3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_per3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_per3.BackgroundColor = System.Drawing.Color.White
        Me.dgw_per3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_per3.Location = New System.Drawing.Point(2, 3)
        Me.dgw_per3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgw_per3.MultiSelect = False
        Me.dgw_per3.Name = "dgw_per3"
        Me.dgw_per3.ReadOnly = True
        Me.dgw_per3.RowHeadersWidth = 25
        Me.dgw_per3.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_per3.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_per3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_per3.Size = New System.Drawing.Size(490, 109)
        Me.dgw_per3.TabIndex = 10
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.White
        Me.GroupBox5.Controls.Add(Me.btn_archivo3)
        Me.GroupBox5.Controls.Add(Me.btn_imprimir3)
        Me.GroupBox5.Controls.Add(Me.btn_pantalla3)
        Me.GroupBox5.Location = New System.Drawing.Point(140, 183)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(261, 55)
        Me.GroupBox5.TabIndex = 30
        Me.GroupBox5.TabStop = False
        '
        'btn_archivo3
        '
        Me.btn_archivo3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo3.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo3.Location = New System.Drawing.Point(172, 16)
        Me.btn_archivo3.Name = "btn_archivo3"
        Me.btn_archivo3.Size = New System.Drawing.Size(77, 27)
        Me.btn_archivo3.TabIndex = 2
        Me.btn_archivo3.Text = "&Archivo"
        Me.btn_archivo3.UseVisualStyleBackColor = False
        '
        'btn_imprimir3
        '
        Me.btn_imprimir3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_imprimir3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprimir3.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.btn_imprimir3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir3.Location = New System.Drawing.Point(91, 16)
        Me.btn_imprimir3.Name = "btn_imprimir3"
        Me.btn_imprimir3.Size = New System.Drawing.Size(77, 27)
        Me.btn_imprimir3.TabIndex = 1
        Me.btn_imprimir3.Text = "&Imprimir"
        Me.btn_imprimir3.UseVisualStyleBackColor = False
        '
        'btn_pantalla3
        '
        Me.btn_pantalla3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pantalla3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla3.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla3.Location = New System.Drawing.Point(10, 16)
        Me.btn_pantalla3.Name = "btn_pantalla3"
        Me.btn_pantalla3.Size = New System.Drawing.Size(77, 27)
        Me.btn_pantalla3.TabIndex = 0
        Me.btn_pantalla3.Text = "&Pantalla"
        Me.btn_pantalla3.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_desc3)
        Me.GroupBox3.Controls.Add(Me.k3)
        Me.GroupBox3.Controls.Add(Me.txt_dia)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.cbo_tipo_doc3)
        Me.GroupBox3.Controls.Add(Me.ch_doc3)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.dtp06)
        Me.GroupBox3.Controls.Add(Me.dtp05)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.ch_per3)
        Me.GroupBox3.Controls.Add(Me.txt_doc_per3)
        Me.GroupBox3.Controls.Add(Me.txt_cod3)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.cbo_sucursal3)
        Me.GroupBox3.Controls.Add(Me.ch_suc3)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(570, 149)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        '
        'txt_desc3
        '
        Me.txt_desc3.BackColor = System.Drawing.Color.White
        Me.txt_desc3.Location = New System.Drawing.Point(184, 48)
        Me.txt_desc3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_desc3.Name = "txt_desc3"
        Me.txt_desc3.Size = New System.Drawing.Size(278, 20)
        Me.txt_desc3.TabIndex = 4
        '
        'k3
        '
        Me.k3.Location = New System.Drawing.Point(421, 48)
        Me.k3.Name = "k3"
        Me.k3.Size = New System.Drawing.Size(10, 20)
        Me.k3.TabIndex = 6
        '
        'txt_dia
        '
        Me.txt_dia.BackColor = System.Drawing.Color.White
        Me.txt_dia.Location = New System.Drawing.Point(418, 74)
        Me.txt_dia.MaxLength = 3
        Me.txt_dia.Name = "txt_dia"
        Me.txt_dia.Size = New System.Drawing.Size(44, 20)
        Me.txt_dia.TabIndex = 9
        Me.txt_dia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(336, 77)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 14)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "Nº de Días"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(40, 77)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 14)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Documento"
        '
        'cbo_tipo_doc3
        '
        Me.cbo_tipo_doc3.BackColor = System.Drawing.Color.White
        Me.cbo_tipo_doc3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo_doc3.FormattingEnabled = True
        Me.cbo_tipo_doc3.Location = New System.Drawing.Point(132, 74)
        Me.cbo_tipo_doc3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbo_tipo_doc3.Name = "cbo_tipo_doc3"
        Me.cbo_tipo_doc3.Size = New System.Drawing.Size(180, 22)
        Me.cbo_tipo_doc3.TabIndex = 8
        '
        'ch_doc3
        '
        Me.ch_doc3.AutoSize = True
        Me.ch_doc3.Checked = True
        Me.ch_doc3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_doc3.Location = New System.Drawing.Point(106, 76)
        Me.ch_doc3.Name = "ch_doc3"
        Me.ch_doc3.Size = New System.Drawing.Size(15, 14)
        Me.ch_doc3.TabIndex = 7
        Me.ch_doc3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(487, 77)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(77, 27)
        Me.Button2.TabIndex = 12
        Me.Button2.TabStop = False
        Me.Button2.Text = "&Salir"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(301, 119)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 14)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Al "
        '
        'dtp06
        '
        Me.dtp06.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp06.Location = New System.Drawing.Point(376, 116)
        Me.dtp06.Name = "dtp06"
        Me.dtp06.Size = New System.Drawing.Size(86, 20)
        Me.dtp06.TabIndex = 11
        '
        'dtp05
        '
        Me.dtp05.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp05.Location = New System.Drawing.Point(132, 116)
        Me.dtp05.Name = "dtp05"
        Me.dtp05.Size = New System.Drawing.Size(86, 20)
        Me.dtp05.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(41, 119)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 14)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Rango Del"
        '
        'ch_per3
        '
        Me.ch_per3.AutoSize = True
        Me.ch_per3.Checked = True
        Me.ch_per3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_per3.Location = New System.Drawing.Point(106, 50)
        Me.ch_per3.Name = "ch_per3"
        Me.ch_per3.Size = New System.Drawing.Size(15, 14)
        Me.ch_per3.TabIndex = 2
        Me.ch_per3.UseVisualStyleBackColor = True
        '
        'txt_doc_per3
        '
        Me.txt_doc_per3.BackColor = System.Drawing.Color.White
        Me.txt_doc_per3.Location = New System.Drawing.Point(466, 48)
        Me.txt_doc_per3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_doc_per3.MaxLength = 20
        Me.txt_doc_per3.Name = "txt_doc_per3"
        Me.txt_doc_per3.Size = New System.Drawing.Size(98, 20)
        Me.txt_doc_per3.TabIndex = 5
        '
        'txt_cod3
        '
        Me.txt_cod3.BackColor = System.Drawing.Color.White
        Me.txt_cod3.Location = New System.Drawing.Point(132, 48)
        Me.txt_cod3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_cod3.Name = "txt_cod3"
        Me.txt_cod3.Size = New System.Drawing.Size(51, 20)
        Me.txt_cod3.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(40, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 14)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Cliente"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(40, 22)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 14)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Sucursal"
        '
        'cbo_sucursal3
        '
        Me.cbo_sucursal3.BackColor = System.Drawing.Color.White
        Me.cbo_sucursal3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_sucursal3.FormattingEnabled = True
        Me.cbo_sucursal3.Location = New System.Drawing.Point(132, 19)
        Me.cbo_sucursal3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbo_sucursal3.Name = "cbo_sucursal3"
        Me.cbo_sucursal3.Size = New System.Drawing.Size(330, 22)
        Me.cbo_sucursal3.TabIndex = 1
        '
        'ch_suc3
        '
        Me.ch_suc3.AutoSize = True
        Me.ch_suc3.Checked = True
        Me.ch_suc3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_suc3.Location = New System.Drawing.Point(106, 21)
        Me.ch_suc3.Name = "ch_suc3"
        Me.ch_suc3.Size = New System.Drawing.Size(15, 14)
        Me.ch_suc3.TabIndex = 0
        Me.ch_suc3.UseVisualStyleBackColor = True
        '
        'REPORTE_CXC1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(603, 274)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_CXC1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Pendientes x Cobrar"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel_PER1.ResumeLayout(False)
        CType(Me.dgw_per1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel_per2.ResumeLayout(False)
        CType(Me.dgw_per2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.panel_per3.ResumeLayout(False)
        CType(Me.dgw_per3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_archivo02 As Button
    Friend WithEvents btn_archivo1 As Button
    Friend WithEvents btn_archivo2 As Button
    Friend WithEvents btn_archivo3 As Button
    Friend WithEvents btn_imprimir02 As Button
    Friend WithEvents btn_imprimir1 As Button
    Friend WithEvents btn_imprimir2 As Button
    Friend WithEvents btn_imprimir3 As Button
    Friend WithEvents btn_pantalla02 As Button
    Friend WithEvents btn_pantalla1 As Button
    Friend WithEvents btn_pantalla2 As Button
    Friend WithEvents btn_pantalla3 As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents btn_salir02 As Button
    Friend WithEvents btn_salir2 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents cbo_suc02 As ComboBox
    Friend WithEvents CBO_SUCURSAL1 As ComboBox
    Friend WithEvents cbo_sucursal2 As ComboBox
    Friend WithEvents cbo_sucursal3 As ComboBox
    Friend WithEvents cbo_tipo_doc02 As ComboBox
    Friend WithEvents cbo_tipo_doc1 As ComboBox
    Friend WithEvents cbo_tipo_doc2 As ComboBox
    Friend WithEvents cbo_tipo_doc3 As ComboBox
    Friend WithEvents ch_doc02 As CheckBox
    Friend WithEvents CH_DOC1 As CheckBox
    Friend WithEvents CH_DOC2 As CheckBox
    Friend WithEvents ch_doc3 As CheckBox
    Friend WithEvents ch_per1 As CheckBox
    Friend WithEvents ch_per2 As CheckBox
    Friend WithEvents ch_per3 As CheckBox
    Friend WithEvents ch_si1 As CheckBox
    Friend WithEvents ch_si2 As CheckBox
    Friend WithEvents ch_suc02 As CheckBox
    Friend WithEvents ch_suc3 As CheckBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents dgw_per1 As DataGridView
    Friend WithEvents dgw_per2 As DataGridView
    Friend WithEvents dgw_per3 As DataGridView
    Friend WithEvents dtp_02 As DateTimePicker
    Friend WithEvents dtp_doc022 As DateTimePicker
    Friend WithEvents dtp02 As DateTimePicker
    Friend WithEvents dtp03 As DateTimePicker
    Friend WithEvents dtp04 As DateTimePicker
    Friend WithEvents dtp05 As DateTimePicker
    Friend WithEvents dtp06 As DateTimePicker
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents k1 As TextBox
    Friend WithEvents k2 As TextBox
    Friend WithEvents k3 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel_PER1 As Panel
    Friend WithEvents Panel_per2 As Panel
    Friend WithEvents panel_per3 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TXT_COD1 As TextBox
    Friend WithEvents txt_cod2 As TextBox
    Friend WithEvents txt_cod3 As TextBox
    Friend WithEvents TXT_DESC1 As TextBox
    Friend WithEvents txt_desc2 As TextBox
    Friend WithEvents txt_desc3 As TextBox
    Friend WithEvents txt_dia As TextBox
    Friend WithEvents txt_doc_per1 As TextBox
    Friend WithEvents txt_doc_per2 As TextBox
    Friend WithEvents txt_doc_per3 As TextBox

End Class
