Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_CXP2_CANC
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
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BTN_SALIR = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtp02 = New System.Windows.Forms.DateTimePicker
        Me.dtp01 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.ch_per1 = New System.Windows.Forms.CheckBox
        Me.txt_doc_per1 = New System.Windows.Forms.TextBox
        Me.TXT_DESC1 = New System.Windows.Forms.TextBox
        Me.TXT_COD1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBO_SUCURSAL1 = New System.Windows.Forms.ComboBox
        Me.ch_si1 = New System.Windows.Forms.CheckBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Panel_per2 = New System.Windows.Forms.Panel
        Me.dgw_per2 = New System.Windows.Forms.DataGridView
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_archivo2 = New System.Windows.Forms.Button
        Me.btn_imprimir2 = New System.Windows.Forms.Button
        Me.btn_pantalla2 = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_salir2 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtp04 = New System.Windows.Forms.DateTimePicker
        Me.dtp03 = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.ch_per2 = New System.Windows.Forms.CheckBox
        Me.txt_doc_per2 = New System.Windows.Forms.TextBox
        Me.txt_desc2 = New System.Windows.Forms.TextBox
        Me.txt_cod2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbo_sucursal2 = New System.Windows.Forms.ComboBox
        Me.ch_si2 = New System.Windows.Forms.CheckBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.panel_bancos = New System.Windows.Forms.Panel
        Me.dgw_ban = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.ch_ban = New System.Windows.Forms.CheckBox
        Me.txt_desc_ban = New System.Windows.Forms.TextBox
        Me.txt_cod_ban = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtp06 = New System.Windows.Forms.DateTimePicker
        Me.dtp05 = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cbo_sucursal3 = New System.Windows.Forms.ComboBox
        Me.ch_si3 = New System.Windows.Forms.CheckBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel_PER1.SuspendLayout()
        CType(Me.dgw_per1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel_per2.SuspendLayout()
        CType(Me.dgw_per2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.panel_bancos.SuspendLayout()
        CType(Me.dgw_ban, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(45, 3)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(592, 273)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel_PER1)
        Me.TabPage1.Controls.Add(Me.gb1)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(584, 246)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cobranza General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel_PER1
        '
        Me.Panel_PER1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_PER1.Controls.Add(Me.dgw_per1)
        Me.Panel_PER1.Location = New System.Drawing.Point(66, 80)
        Me.Panel_PER1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel_PER1.Name = "Panel_PER1"
        Me.Panel_PER1.Size = New System.Drawing.Size(507, 129)
        Me.Panel_PER1.TabIndex = 30
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
        Me.dgw_per1.Location = New System.Drawing.Point(8, 3)
        Me.dgw_per1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgw_per1.MultiSelect = False
        Me.dgw_per1.Name = "dgw_per1"
        Me.dgw_per1.ReadOnly = True
        Me.dgw_per1.RowHeadersWidth = 25
        Me.dgw_per1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_per1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_per1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_per1.Size = New System.Drawing.Size(495, 121)
        Me.dgw_per1.TabIndex = 10
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(128, 184)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(261, 54)
        Me.gb1.TabIndex = 29
        Me.gb1.TabStop = False
        '
        'btn_archivo1
        '
        Me.btn_archivo1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo1.Location = New System.Drawing.Point(172, 15)
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
        Me.btn_imprimir1.Location = New System.Drawing.Point(91, 15)
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
        Me.btn_pantalla1.Location = New System.Drawing.Point(10, 15)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(77, 27)
        Me.btn_pantalla1.TabIndex = 0
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTN_SALIR)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtp02)
        Me.GroupBox1.Controls.Add(Me.dtp01)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ch_per1)
        Me.GroupBox1.Controls.Add(Me.txt_doc_per1)
        Me.GroupBox1.Controls.Add(Me.TXT_DESC1)
        Me.GroupBox1.Controls.Add(Me.TXT_COD1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CBO_SUCURSAL1)
        Me.GroupBox1.Controls.Add(Me.ch_si1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(570, 142)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_SALIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_SALIR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.Location = New System.Drawing.Point(486, 97)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(77, 27)
        Me.BTN_SALIR.TabIndex = 9
        Me.BTN_SALIR.TabStop = False
        Me.BTN_SALIR.Text = "&Salir"
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(265, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 14)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Al "
        '
        'dtp02
        '
        Me.dtp02.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp02.Location = New System.Drawing.Point(349, 94)
        Me.dtp02.Name = "dtp02"
        Me.dtp02.Size = New System.Drawing.Size(86, 20)
        Me.dtp02.TabIndex = 8
        '
        'dtp01
        '
        Me.dtp01.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp01.Location = New System.Drawing.Point(120, 94)
        Me.dtp01.Name = "dtp01"
        Me.dtp01.Size = New System.Drawing.Size(86, 20)
        Me.dtp01.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 14)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Rango Del "
        '
        'ch_per1
        '
        Me.ch_per1.AutoSize = True
        Me.ch_per1.Checked = True
        Me.ch_per1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_per1.Location = New System.Drawing.Point(96, 54)
        Me.ch_per1.Name = "ch_per1"
        Me.ch_per1.Size = New System.Drawing.Size(15, 14)
        Me.ch_per1.TabIndex = 2
        Me.ch_per1.UseVisualStyleBackColor = True
        '
        'txt_doc_per1
        '
        Me.txt_doc_per1.Location = New System.Drawing.Point(463, 52)
        Me.txt_doc_per1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_doc_per1.MaxLength = 20
        Me.txt_doc_per1.Name = "txt_doc_per1"
        Me.txt_doc_per1.Size = New System.Drawing.Size(100, 20)
        Me.txt_doc_per1.TabIndex = 5
        '
        'TXT_DESC1
        '
        Me.TXT_DESC1.Location = New System.Drawing.Point(175, 52)
        Me.TXT_DESC1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TXT_DESC1.Name = "TXT_DESC1"
        Me.TXT_DESC1.Size = New System.Drawing.Size(284, 20)
        Me.TXT_DESC1.TabIndex = 4
        '
        'TXT_COD1
        '
        Me.TXT_COD1.Location = New System.Drawing.Point(120, 52)
        Me.TXT_COD1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TXT_COD1.Name = "TXT_COD1"
        Me.TXT_COD1.Size = New System.Drawing.Size(51, 20)
        Me.TXT_COD1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 14)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Proveedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 24)
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
        Me.CBO_SUCURSAL1.Location = New System.Drawing.Point(120, 21)
        Me.CBO_SUCURSAL1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CBO_SUCURSAL1.Name = "CBO_SUCURSAL1"
        Me.CBO_SUCURSAL1.Size = New System.Drawing.Size(339, 22)
        Me.CBO_SUCURSAL1.TabIndex = 1
        '
        'ch_si1
        '
        Me.ch_si1.AutoSize = True
        Me.ch_si1.Checked = True
        Me.ch_si1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_si1.Location = New System.Drawing.Point(96, 23)
        Me.ch_si1.Name = "ch_si1"
        Me.ch_si1.Size = New System.Drawing.Size(15, 14)
        Me.ch_si1.TabIndex = 0
        Me.ch_si1.UseVisualStyleBackColor = True
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
        Me.TabPage2.Size = New System.Drawing.Size(584, 246)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Por Medio de Pago"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel_per2
        '
        Me.Panel_per2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_per2.Controls.Add(Me.dgw_per2)
        Me.Panel_per2.Location = New System.Drawing.Point(68, 76)
        Me.Panel_per2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel_per2.Name = "Panel_per2"
        Me.Panel_per2.Size = New System.Drawing.Size(516, 115)
        Me.Panel_per2.TabIndex = 31
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
        Me.dgw_per2.Size = New System.Drawing.Size(507, 107)
        Me.dgw_per2.TabIndex = 10
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.btn_archivo2)
        Me.GroupBox4.Controls.Add(Me.btn_imprimir2)
        Me.GroupBox4.Controls.Add(Me.btn_pantalla2)
        Me.GroupBox4.Location = New System.Drawing.Point(129, 184)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(261, 54)
        Me.GroupBox4.TabIndex = 32
        Me.GroupBox4.TabStop = False
        '
        'btn_archivo2
        '
        Me.btn_archivo2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo2.Location = New System.Drawing.Point(172, 15)
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
        Me.btn_imprimir2.Location = New System.Drawing.Point(91, 15)
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
        Me.btn_pantalla2.Location = New System.Drawing.Point(10, 15)
        Me.btn_pantalla2.Name = "btn_pantalla2"
        Me.btn_pantalla2.Size = New System.Drawing.Size(77, 27)
        Me.btn_pantalla2.TabIndex = 0
        Me.btn_pantalla2.Text = "&Pantalla"
        Me.btn_pantalla2.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_salir2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.dtp04)
        Me.GroupBox2.Controls.Add(Me.dtp03)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.ch_per2)
        Me.GroupBox2.Controls.Add(Me.txt_doc_per2)
        Me.GroupBox2.Controls.Add(Me.txt_desc2)
        Me.GroupBox2.Controls.Add(Me.txt_cod2)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cbo_sucursal2)
        Me.GroupBox2.Controls.Add(Me.ch_si2)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(570, 139)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        '
        'btn_salir2
        '
        Me.btn_salir2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salir2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir2.Location = New System.Drawing.Point(486, 96)
        Me.btn_salir2.Name = "btn_salir2"
        Me.btn_salir2.Size = New System.Drawing.Size(77, 27)
        Me.btn_salir2.TabIndex = 9
        Me.btn_salir2.TabStop = False
        Me.btn_salir2.Text = "&Salir"
        Me.btn_salir2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(290, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 14)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Al "
        '
        'dtp04
        '
        Me.dtp04.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp04.Location = New System.Drawing.Point(373, 93)
        Me.dtp04.Name = "dtp04"
        Me.dtp04.Size = New System.Drawing.Size(86, 20)
        Me.dtp04.TabIndex = 8
        '
        'dtp03
        '
        Me.dtp03.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp03.Location = New System.Drawing.Point(121, 93)
        Me.dtp03.Name = "dtp03"
        Me.dtp03.Size = New System.Drawing.Size(86, 20)
        Me.dtp03.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 14)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Rango Del"
        '
        'ch_per2
        '
        Me.ch_per2.AutoSize = True
        Me.ch_per2.Checked = True
        Me.ch_per2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_per2.Location = New System.Drawing.Point(98, 52)
        Me.ch_per2.Name = "ch_per2"
        Me.ch_per2.Size = New System.Drawing.Size(15, 14)
        Me.ch_per2.TabIndex = 2
        Me.ch_per2.UseVisualStyleBackColor = True
        '
        'txt_doc_per2
        '
        Me.txt_doc_per2.Location = New System.Drawing.Point(463, 50)
        Me.txt_doc_per2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_doc_per2.MaxLength = 20
        Me.txt_doc_per2.Name = "txt_doc_per2"
        Me.txt_doc_per2.Size = New System.Drawing.Size(100, 20)
        Me.txt_doc_per2.TabIndex = 5
        '
        'txt_desc2
        '
        Me.txt_desc2.Location = New System.Drawing.Point(176, 50)
        Me.txt_desc2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_desc2.Name = "txt_desc2"
        Me.txt_desc2.Size = New System.Drawing.Size(283, 20)
        Me.txt_desc2.TabIndex = 4
        '
        'txt_cod2
        '
        Me.txt_cod2.Location = New System.Drawing.Point(121, 50)
        Me.txt_cod2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_cod2.MaxLength = 5
        Me.txt_cod2.Name = "txt_cod2"
        Me.txt_cod2.Size = New System.Drawing.Size(51, 20)
        Me.txt_cod2.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(41, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 14)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Proveedor"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(41, 22)
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
        Me.cbo_sucursal2.Location = New System.Drawing.Point(121, 19)
        Me.cbo_sucursal2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbo_sucursal2.Name = "cbo_sucursal2"
        Me.cbo_sucursal2.Size = New System.Drawing.Size(338, 22)
        Me.cbo_sucursal2.TabIndex = 1
        '
        'ch_si2
        '
        Me.ch_si2.AutoSize = True
        Me.ch_si2.Checked = True
        Me.ch_si2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_si2.Location = New System.Drawing.Point(98, 21)
        Me.ch_si2.Name = "ch_si2"
        Me.ch_si2.Size = New System.Drawing.Size(15, 14)
        Me.ch_si2.TabIndex = 0
        Me.ch_si2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.panel_bancos)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(584, 246)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cobranza por Bancos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'panel_bancos
        '
        Me.panel_bancos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_bancos.Controls.Add(Me.dgw_ban)
        Me.panel_bancos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_bancos.Location = New System.Drawing.Point(3, 72)
        Me.panel_bancos.Name = "panel_bancos"
        Me.panel_bancos.Size = New System.Drawing.Size(533, 136)
        Me.panel_bancos.TabIndex = 134
        Me.panel_bancos.Visible = False
        '
        'dgw_ban
        '
        Me.dgw_ban.AllowUserToAddRows = False
        Me.dgw_ban.AllowUserToDeleteRows = False
        Me.dgw_ban.AllowUserToOrderColumns = True
        Me.dgw_ban.AllowUserToResizeRows = False
        Me.dgw_ban.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_ban.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_ban.BackgroundColor = System.Drawing.Color.White
        Me.dgw_ban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_ban.Location = New System.Drawing.Point(114, 2)
        Me.dgw_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_ban.MultiSelect = False
        Me.dgw_ban.Name = "dgw_ban"
        Me.dgw_ban.ReadOnly = True
        Me.dgw_ban.RowHeadersWidth = 25
        Me.dgw_ban.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_ban.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_ban.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_ban.Size = New System.Drawing.Size(396, 122)
        Me.dgw_ban.TabIndex = 0
        Me.dgw_ban.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Location = New System.Drawing.Point(126, 185)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(261, 54)
        Me.GroupBox3.TabIndex = 35
        Me.GroupBox3.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(172, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 27)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "&Archivo"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(91, 15)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(77, 27)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "&Imprimir"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.Location = New System.Drawing.Point(10, 15)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(77, 27)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "&Pantalla"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ch_ban)
        Me.GroupBox5.Controls.Add(Me.txt_desc_ban)
        Me.GroupBox5.Controls.Add(Me.txt_cod_ban)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Button4)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.dtp06)
        Me.GroupBox5.Controls.Add(Me.dtp05)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.cbo_sucursal3)
        Me.GroupBox5.Controls.Add(Me.ch_si3)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 7)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(570, 139)
        Me.GroupBox5.TabIndex = 33
        Me.GroupBox5.TabStop = False
        '
        'ch_ban
        '
        Me.ch_ban.AutoSize = True
        Me.ch_ban.Checked = True
        Me.ch_ban.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_ban.Location = New System.Drawing.Point(98, 55)
        Me.ch_ban.Name = "ch_ban"
        Me.ch_ban.Size = New System.Drawing.Size(15, 14)
        Me.ch_ban.TabIndex = 138
        Me.ch_ban.UseVisualStyleBackColor = True
        '
        'txt_desc_ban
        '
        Me.txt_desc_ban.BackColor = System.Drawing.Color.White
        Me.txt_desc_ban.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_desc_ban.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_ban.Location = New System.Drawing.Point(168, 51)
        Me.txt_desc_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_ban.MaxLength = 40
        Me.txt_desc_ban.Name = "txt_desc_ban"
        Me.txt_desc_ban.Size = New System.Drawing.Size(347, 20)
        Me.txt_desc_ban.TabIndex = 136
        '
        'txt_cod_ban
        '
        Me.txt_cod_ban.BackColor = System.Drawing.Color.White
        Me.txt_cod_ban.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_ban.Location = New System.Drawing.Point(121, 51)
        Me.txt_cod_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_ban.MaxLength = 4
        Me.txt_cod_ban.Name = "txt_cod_ban"
        Me.txt_cod_ban.Size = New System.Drawing.Size(45, 20)
        Me.txt_cod_ban.TabIndex = 135
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(41, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 14)
        Me.Label11.TabIndex = 137
        Me.Label11.Text = "Banco"
        '
        'Button4
        '
        Me.Button4.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.Location = New System.Drawing.Point(486, 96)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(77, 27)
        Me.Button4.TabIndex = 9
        Me.Button4.TabStop = False
        Me.Button4.Text = "&Salir"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(290, 87)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 14)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Al "
        '
        'dtp06
        '
        Me.dtp06.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp06.Location = New System.Drawing.Point(373, 84)
        Me.dtp06.Name = "dtp06"
        Me.dtp06.Size = New System.Drawing.Size(86, 20)
        Me.dtp06.TabIndex = 8
        '
        'dtp05
        '
        Me.dtp05.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp05.Location = New System.Drawing.Point(121, 84)
        Me.dtp05.Name = "dtp05"
        Me.dtp05.Size = New System.Drawing.Size(86, 20)
        Me.dtp05.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(41, 87)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 14)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Rango Del"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(41, 22)
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
        Me.cbo_sucursal3.Location = New System.Drawing.Point(121, 19)
        Me.cbo_sucursal3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbo_sucursal3.Name = "cbo_sucursal3"
        Me.cbo_sucursal3.Size = New System.Drawing.Size(338, 22)
        Me.cbo_sucursal3.TabIndex = 1
        '
        'ch_si3
        '
        Me.ch_si3.AutoSize = True
        Me.ch_si3.Checked = True
        Me.ch_si3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_si3.Location = New System.Drawing.Point(98, 21)
        Me.ch_si3.Name = "ch_si3"
        Me.ch_si3.Size = New System.Drawing.Size(15, 14)
        Me.ch_si3.TabIndex = 0
        Me.ch_si3.UseVisualStyleBackColor = True
        '
        'REPORTE_CXP2_CANC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 273)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_CXP2_CANC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Canceladas"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel_PER1.ResumeLayout(False)
        CType(Me.dgw_per1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel_per2.ResumeLayout(False)
        CType(Me.dgw_per2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.panel_bancos.ResumeLayout(False)
        CType(Me.dgw_ban, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_archivo1 As Button
    Friend WithEvents btn_archivo2 As Button
    Friend WithEvents btn_imprimir1 As Button
    Friend WithEvents btn_imprimir2 As Button
    Friend WithEvents btn_pantalla1 As Button
    Friend WithEvents btn_pantalla2 As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents btn_salir2 As Button
    Friend WithEvents CBO_SUCURSAL1 As ComboBox
    Friend WithEvents cbo_sucursal2 As ComboBox
    Friend WithEvents ch_per1 As CheckBox
    Friend WithEvents ch_per2 As CheckBox
    Friend WithEvents ch_si1 As CheckBox
    Friend WithEvents ch_si2 As CheckBox
    Friend WithEvents dgw_per1 As DataGridView
    Friend WithEvents dgw_per2 As DataGridView
    Friend WithEvents dtp01 As DateTimePicker
    Friend WithEvents dtp02 As DateTimePicker
    Friend WithEvents dtp03 As DateTimePicker
    Friend WithEvents dtp04 As DateTimePicker
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel_PER1 As Panel
    Friend WithEvents Panel_per2 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TXT_COD1 As TextBox
    Friend WithEvents txt_cod2 As TextBox
    Friend WithEvents TXT_DESC1 As TextBox
    Friend WithEvents txt_desc2 As TextBox
    Friend WithEvents txt_doc_per1 As TextBox
    Friend WithEvents txt_doc_per2 As TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtp06 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp05 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbo_sucursal3 As System.Windows.Forms.ComboBox
    Friend WithEvents ch_si3 As System.Windows.Forms.CheckBox
    Friend WithEvents panel_bancos As System.Windows.Forms.Panel
    Friend WithEvents dgw_ban As System.Windows.Forms.DataGridView
    Friend WithEvents txt_desc_ban As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_ban As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ch_ban As System.Windows.Forms.CheckBox

End Class
