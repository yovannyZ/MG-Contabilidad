Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_ESTADISTICA
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_digitos = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_desc_cta1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_cod_cta1 = New System.Windows.Forms.TextBox
        Me.cbo_nivel = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_desc_cta0 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_cod_cta0 = New System.Windows.Forms.TextBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.KL = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.PaneL_CTA = New System.Windows.Forms.Panel
        Me.dgw_cta = New System.Windows.Forms.DataGridView
        Me.PaneL_CTA1 = New System.Windows.Forms.Panel
        Me.dgw_cta1 = New System.Windows.Forms.DataGridView
        Me.stEstado = New System.Windows.Forms.StatusStrip
        Me.tspbExportar = New System.Windows.Forms.ToolStripProgressBar
        Me.tslblMensaje = New System.Windows.Forms.ToolStripStatusLabel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.PaneL_CTA12 = New System.Windows.Forms.Panel
        Me.dgw_cta12 = New System.Windows.Forms.DataGridView
        Me.PaneL_CTA2 = New System.Windows.Forms.Panel
        Me.dgw_cta2 = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_archivo2 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.btn_pantalla2 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txt_digitos2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_desc_cta12 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_cod_cta12 = New System.Windows.Forms.TextBox
        Me.cbo_nivel2 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbo_mes2 = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_desc_cta02 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_cod_cta02 = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.KL2 = New System.Windows.Forms.TextBox
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.gb1.SuspendLayout()
        Me.PaneL_CTA.SuspendLayout()
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PaneL_CTA1.SuspendLayout()
        CType(Me.dgw_cta1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stEstado.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.PaneL_CTA12.SuspendLayout()
        CType(Me.dgw_cta12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PaneL_CTA2.SuspendLayout()
        CType(Me.dgw_cta2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_digitos)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_desc_cta1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_cod_cta1)
        Me.GroupBox1.Controls.Add(Me.cbo_nivel)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cbo_mes)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_desc_cta0)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_cod_cta0)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.KL)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(18, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(528, 152)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'txt_digitos
        '
        Me.txt_digitos.BackColor = System.Drawing.Color.White
        Me.txt_digitos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_digitos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_digitos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_digitos.Location = New System.Drawing.Point(364, 20)
        Me.txt_digitos.MaxLength = 8
        Me.txt_digitos.Name = "txt_digitos"
        Me.txt_digitos.Size = New System.Drawing.Size(59, 20)
        Me.txt_digitos.TabIndex = 154
        Me.txt_digitos.TabStop = False
        Me.txt_digitos.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(318, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 14)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "Código"
        Me.Label1.Visible = False
        '
        'txt_desc_cta1
        '
        Me.txt_desc_cta1.Location = New System.Drawing.Point(157, 76)
        Me.txt_desc_cta1.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_cta1.MaxLength = 40
        Me.txt_desc_cta1.Name = "txt_desc_cta1"
        Me.txt_desc_cta1.Size = New System.Drawing.Size(347, 20)
        Me.txt_desc_cta1.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 14)
        Me.Label3.TabIndex = 152
        Me.Label3.Text = "Cuenta al"
        '
        'txt_cod_cta1
        '
        Me.txt_cod_cta1.Location = New System.Drawing.Point(96, 76)
        Me.txt_cod_cta1.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_cta1.MaxLength = 8
        Me.txt_cod_cta1.Name = "txt_cod_cta1"
        Me.txt_cod_cta1.Size = New System.Drawing.Size(60, 20)
        Me.txt_cod_cta1.TabIndex = 5
        '
        'cbo_nivel
        '
        Me.cbo_nivel.BackColor = System.Drawing.Color.White
        Me.cbo_nivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_nivel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_nivel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_nivel.FormattingEnabled = True
        Me.cbo_nivel.Location = New System.Drawing.Point(96, 20)
        Me.cbo_nivel.Name = "cbo_nivel"
        Me.cbo_nivel.Size = New System.Drawing.Size(213, 22)
        Me.cbo_nivel.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 14)
        Me.Label9.TabIndex = 148
        Me.Label9.Text = "Nivel"
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"INICIO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(96, 101)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(90, 22)
        Me.cbo_mes.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.Location = New System.Drawing.Point(17, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 14)
        Me.Label5.TabIndex = 146
        Me.Label5.Text = "Mes"
        '
        'txt_desc_cta0
        '
        Me.txt_desc_cta0.Location = New System.Drawing.Point(157, 50)
        Me.txt_desc_cta0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_cta0.MaxLength = 40
        Me.txt_desc_cta0.Name = "txt_desc_cta0"
        Me.txt_desc_cta0.Size = New System.Drawing.Size(347, 20)
        Me.txt_desc_cta0.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 14)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Cuenta del"
        '
        'txt_cod_cta0
        '
        Me.txt_cod_cta0.Location = New System.Drawing.Point(96, 50)
        Me.txt_cod_cta0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_cta0.MaxLength = 8
        Me.txt_cod_cta0.Name = "txt_cod_cta0"
        Me.txt_cod_cta0.Size = New System.Drawing.Size(60, 20)
        Me.txt_cod_cta0.TabIndex = 2
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.SystemColors.Control
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(422, 104)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(82, 33)
        Me.btn_salir.TabIndex = 30
        Me.btn_salir.TabStop = False
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'KL
        '
        Me.KL.Location = New System.Drawing.Point(444, 50)
        Me.KL.Margin = New System.Windows.Forms.Padding(0)
        Me.KL.MaxLength = 8
        Me.KL.Name = "KL"
        Me.KL.Size = New System.Drawing.Size(10, 20)
        Me.KL.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(413, 76)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBox1.MaxLength = 8
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(10, 20)
        Me.TextBox1.TabIndex = 6
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb1.Location = New System.Drawing.Point(163, 184)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(278, 61)
        Me.gb1.TabIndex = 2
        Me.gb1.TabStop = False
        '
        'btn_archivo1
        '
        Me.btn_archivo1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo1.Location = New System.Drawing.Point(186, 17)
        Me.btn_archivo1.Name = "btn_archivo1"
        Me.btn_archivo1.Size = New System.Drawing.Size(82, 33)
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
        Me.btn_imprimir1.Location = New System.Drawing.Point(98, 17)
        Me.btn_imprimir1.Name = "btn_imprimir1"
        Me.btn_imprimir1.Size = New System.Drawing.Size(82, 33)
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
        Me.btn_pantalla1.Location = New System.Drawing.Point(10, 17)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(82, 33)
        Me.btn_pantalla1.TabIndex = 0
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'PaneL_CTA
        '
        Me.PaneL_CTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PaneL_CTA.Controls.Add(Me.dgw_cta)
        Me.PaneL_CTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaneL_CTA.Location = New System.Drawing.Point(99, 81)
        Me.PaneL_CTA.Name = "PaneL_CTA"
        Me.PaneL_CTA.Size = New System.Drawing.Size(447, 143)
        Me.PaneL_CTA.TabIndex = 153
        Me.PaneL_CTA.Visible = False
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
        Me.dgw_cta.Location = New System.Drawing.Point(14, -1)
        Me.dgw_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta.MultiSelect = False
        Me.dgw_cta.Name = "dgw_cta"
        Me.dgw_cta.ReadOnly = True
        Me.dgw_cta.RowHeadersWidth = 25
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw_cta.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta.Size = New System.Drawing.Size(418, 134)
        Me.dgw_cta.TabIndex = 17
        '
        'PaneL_CTA1
        '
        Me.PaneL_CTA1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PaneL_CTA1.Controls.Add(Me.dgw_cta1)
        Me.PaneL_CTA1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaneL_CTA1.Location = New System.Drawing.Point(99, 111)
        Me.PaneL_CTA1.Name = "PaneL_CTA1"
        Me.PaneL_CTA1.Size = New System.Drawing.Size(443, 143)
        Me.PaneL_CTA1.TabIndex = 146
        Me.PaneL_CTA1.Visible = False
        '
        'dgw_cta1
        '
        Me.dgw_cta1.AllowUserToAddRows = False
        Me.dgw_cta1.AllowUserToDeleteRows = False
        Me.dgw_cta1.AllowUserToOrderColumns = True
        Me.dgw_cta1.AllowUserToResizeRows = False
        Me.dgw_cta1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_cta1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_cta1.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cta1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cta1.Location = New System.Drawing.Point(5, -1)
        Me.dgw_cta1.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta1.MultiSelect = False
        Me.dgw_cta1.Name = "dgw_cta1"
        Me.dgw_cta1.ReadOnly = True
        Me.dgw_cta1.RowHeadersWidth = 25
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw_cta1.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgw_cta1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta1.Size = New System.Drawing.Size(427, 134)
        Me.dgw_cta1.TabIndex = 17
        '
        'stEstado
        '
        Me.stEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspbExportar, Me.tslblMensaje})
        Me.stEstado.Location = New System.Drawing.Point(0, 271)
        Me.stEstado.Name = "stEstado"
        Me.stEstado.Size = New System.Drawing.Size(576, 22)
        Me.stEstado.TabIndex = 154
        Me.stEstado.Text = "StatusStrip1"
        Me.stEstado.Visible = False
        '
        'tspbExportar
        '
        Me.tspbExportar.Name = "tspbExportar"
        Me.tspbExportar.Size = New System.Drawing.Size(100, 16)
        Me.tspbExportar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        '
        'tslblMensaje
        '
        Me.tslblMensaje.Name = "tslblMensaje"
        Me.tslblMensaje.Size = New System.Drawing.Size(109, 17)
        Me.tslblMensaje.Text = "Generando Archivo"
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
        Me.TabControl1.Size = New System.Drawing.Size(576, 293)
        Me.TabControl1.TabIndex = 155
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PaneL_CTA1)
        Me.TabPage1.Controls.Add(Me.PaneL_CTA)
        Me.TabPage1.Controls.Add(Me.gb1)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(568, 266)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Mensual"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PaneL_CTA12)
        Me.TabPage2.Controls.Add(Me.PaneL_CTA2)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(568, 266)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Acumulativo"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'PaneL_CTA12
        '
        Me.PaneL_CTA12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PaneL_CTA12.Controls.Add(Me.dgw_cta12)
        Me.PaneL_CTA12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaneL_CTA12.Location = New System.Drawing.Point(101, 110)
        Me.PaneL_CTA12.Name = "PaneL_CTA12"
        Me.PaneL_CTA12.Size = New System.Drawing.Size(447, 143)
        Me.PaneL_CTA12.TabIndex = 156
        Me.PaneL_CTA12.Visible = False
        '
        'dgw_cta12
        '
        Me.dgw_cta12.AllowUserToAddRows = False
        Me.dgw_cta12.AllowUserToDeleteRows = False
        Me.dgw_cta12.AllowUserToOrderColumns = True
        Me.dgw_cta12.AllowUserToResizeRows = False
        Me.dgw_cta12.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_cta12.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_cta12.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cta12.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cta12.Location = New System.Drawing.Point(5, -1)
        Me.dgw_cta12.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta12.MultiSelect = False
        Me.dgw_cta12.Name = "dgw_cta12"
        Me.dgw_cta12.ReadOnly = True
        Me.dgw_cta12.RowHeadersWidth = 25
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw_cta12.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgw_cta12.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta12.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta12.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta12.Size = New System.Drawing.Size(427, 134)
        Me.dgw_cta12.TabIndex = 17
        '
        'PaneL_CTA2
        '
        Me.PaneL_CTA2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PaneL_CTA2.Controls.Add(Me.dgw_cta2)
        Me.PaneL_CTA2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaneL_CTA2.Location = New System.Drawing.Point(101, 80)
        Me.PaneL_CTA2.Name = "PaneL_CTA2"
        Me.PaneL_CTA2.Size = New System.Drawing.Size(441, 143)
        Me.PaneL_CTA2.TabIndex = 157
        Me.PaneL_CTA2.Visible = False
        '
        'dgw_cta2
        '
        Me.dgw_cta2.AllowUserToAddRows = False
        Me.dgw_cta2.AllowUserToDeleteRows = False
        Me.dgw_cta2.AllowUserToOrderColumns = True
        Me.dgw_cta2.AllowUserToResizeRows = False
        Me.dgw_cta2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_cta2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_cta2.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cta2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cta2.Location = New System.Drawing.Point(14, -1)
        Me.dgw_cta2.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta2.MultiSelect = False
        Me.dgw_cta2.Name = "dgw_cta2"
        Me.dgw_cta2.ReadOnly = True
        Me.dgw_cta2.RowHeadersWidth = 25
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw_cta2.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgw_cta2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta2.Size = New System.Drawing.Size(418, 134)
        Me.dgw_cta2.TabIndex = 17
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.btn_archivo2)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.btn_pantalla2)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(165, 183)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(278, 61)
        Me.GroupBox2.TabIndex = 155
        Me.GroupBox2.TabStop = False
        '
        'btn_archivo2
        '
        Me.btn_archivo2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo2.Location = New System.Drawing.Point(186, 17)
        Me.btn_archivo2.Name = "btn_archivo2"
        Me.btn_archivo2.Size = New System.Drawing.Size(82, 33)
        Me.btn_archivo2.TabIndex = 2
        Me.btn_archivo2.Text = "&Archivo"
        Me.btn_archivo2.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(98, 17)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(82, 33)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "&Imprimir"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btn_pantalla2
        '
        Me.btn_pantalla2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pantalla2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla2.Location = New System.Drawing.Point(10, 17)
        Me.btn_pantalla2.Name = "btn_pantalla2"
        Me.btn_pantalla2.Size = New System.Drawing.Size(82, 33)
        Me.btn_pantalla2.TabIndex = 0
        Me.btn_pantalla2.Text = "&Pantalla"
        Me.btn_pantalla2.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_digitos2)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txt_desc_cta12)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txt_cod_cta12)
        Me.GroupBox3.Controls.Add(Me.cbo_nivel2)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cbo_mes2)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txt_desc_cta02)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txt_cod_cta02)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.KL2)
        Me.GroupBox3.Controls.Add(Me.TextBox8)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(20, 14)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(528, 152)
        Me.GroupBox3.TabIndex = 154
        Me.GroupBox3.TabStop = False
        '
        'txt_digitos2
        '
        Me.txt_digitos2.BackColor = System.Drawing.Color.White
        Me.txt_digitos2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_digitos2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_digitos2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_digitos2.Location = New System.Drawing.Point(364, 20)
        Me.txt_digitos2.MaxLength = 8
        Me.txt_digitos2.Name = "txt_digitos2"
        Me.txt_digitos2.Size = New System.Drawing.Size(59, 20)
        Me.txt_digitos2.TabIndex = 154
        Me.txt_digitos2.TabStop = False
        Me.txt_digitos2.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(318, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 14)
        Me.Label4.TabIndex = 153
        Me.Label4.Text = "Código"
        Me.Label4.Visible = False
        '
        'txt_desc_cta12
        '
        Me.txt_desc_cta12.Location = New System.Drawing.Point(157, 76)
        Me.txt_desc_cta12.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_cta12.MaxLength = 40
        Me.txt_desc_cta12.Name = "txt_desc_cta12"
        Me.txt_desc_cta12.Size = New System.Drawing.Size(347, 20)
        Me.txt_desc_cta12.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 14)
        Me.Label6.TabIndex = 152
        Me.Label6.Text = "Cuenta al"
        '
        'txt_cod_cta12
        '
        Me.txt_cod_cta12.Location = New System.Drawing.Point(96, 76)
        Me.txt_cod_cta12.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_cta12.MaxLength = 8
        Me.txt_cod_cta12.Name = "txt_cod_cta12"
        Me.txt_cod_cta12.Size = New System.Drawing.Size(60, 20)
        Me.txt_cod_cta12.TabIndex = 5
        '
        'cbo_nivel2
        '
        Me.cbo_nivel2.BackColor = System.Drawing.Color.White
        Me.cbo_nivel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_nivel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_nivel2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_nivel2.FormattingEnabled = True
        Me.cbo_nivel2.Location = New System.Drawing.Point(96, 20)
        Me.cbo_nivel2.Name = "cbo_nivel2"
        Me.cbo_nivel2.Size = New System.Drawing.Size(213, 22)
        Me.cbo_nivel2.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 14)
        Me.Label7.TabIndex = 148
        Me.Label7.Text = "Nivel"
        '
        'cbo_mes2
        '
        Me.cbo_mes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes2.FormattingEnabled = True
        Me.cbo_mes2.Items.AddRange(New Object() {"INICIO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.cbo_mes2.Location = New System.Drawing.Point(96, 101)
        Me.cbo_mes2.Name = "cbo_mes2"
        Me.cbo_mes2.Size = New System.Drawing.Size(90, 22)
        Me.cbo_mes2.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label8.Location = New System.Drawing.Point(17, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 14)
        Me.Label8.TabIndex = 146
        Me.Label8.Text = "Mes"
        '
        'txt_desc_cta02
        '
        Me.txt_desc_cta02.Location = New System.Drawing.Point(157, 50)
        Me.txt_desc_cta02.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_cta02.MaxLength = 40
        Me.txt_desc_cta02.Name = "txt_desc_cta02"
        Me.txt_desc_cta02.Size = New System.Drawing.Size(347, 20)
        Me.txt_desc_cta02.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(17, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 14)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Cuenta del"
        '
        'txt_cod_cta02
        '
        Me.txt_cod_cta02.Location = New System.Drawing.Point(96, 50)
        Me.txt_cod_cta02.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_cta02.MaxLength = 8
        Me.txt_cod_cta02.Name = "txt_cod_cta02"
        Me.txt_cod_cta02.Size = New System.Drawing.Size(60, 20)
        Me.txt_cod_cta02.TabIndex = 2
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.Location = New System.Drawing.Point(422, 104)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(82, 33)
        Me.Button4.TabIndex = 30
        Me.Button4.TabStop = False
        Me.Button4.Text = "&Salir"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'KL2
        '
        Me.KL2.Location = New System.Drawing.Point(444, 50)
        Me.KL2.Margin = New System.Windows.Forms.Padding(0)
        Me.KL2.MaxLength = 8
        Me.KL2.Name = "KL2"
        Me.KL2.Size = New System.Drawing.Size(10, 20)
        Me.KL2.TabIndex = 3
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(413, 76)
        Me.TextBox8.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBox8.MaxLength = 8
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(10, 20)
        Me.TextBox8.TabIndex = 6
        '
        'REPORTE_ESTADISTICA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 293)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.stEstado)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_ESTADISTICA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Estadísticas de Cuentas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gb1.ResumeLayout(False)
        Me.PaneL_CTA.ResumeLayout(False)
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PaneL_CTA1.ResumeLayout(False)
        CType(Me.dgw_cta1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stEstado.ResumeLayout(False)
        Me.stEstado.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.PaneL_CTA12.ResumeLayout(False)
        CType(Me.dgw_cta12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PaneL_CTA2.ResumeLayout(False)
        CType(Me.dgw_cta2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_archivo1 As Button
    Friend WithEvents btn_imprimir1 As Button
    Friend WithEvents btn_pantalla1 As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents cbo_mes As ComboBox
    Friend WithEvents cbo_nivel As ComboBox
    Friend WithEvents dgw_cta As DataGridView
    Friend WithEvents dgw_cta1 As DataGridView
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents KL As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PaneL_CTA As Panel
    Friend WithEvents PaneL_CTA1 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txt_cod_cta0 As TextBox
    Friend WithEvents txt_cod_cta1 As TextBox
    Friend WithEvents txt_desc_cta0 As TextBox
    Friend WithEvents txt_desc_cta1 As TextBox
    Friend WithEvents txt_digitos As TextBox
    Friend WithEvents stEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tspbExportar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tslblMensaje As System.Windows.Forms.ToolStripStatusLabel

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        bwExportar.WorkerReportsProgress = True
        bwExportar.WorkerSupportsCancellation = True
        AddHandler bwExportar.DoWork, AddressOf ExportarWork
        AddHandler bwExportar.ProgressChanged, AddressOf ExportarProgress
        AddHandler bwExportar.RunWorkerCompleted, AddressOf ExportarComplete

        'Agregue cualquier inicialización después de la llamada a InitializeComponent().2
        bwExportar2.WorkerReportsProgress = True
        bwExportar2.WorkerSupportsCancellation = True
        AddHandler bwExportar2.DoWork, AddressOf ExportarWork2
        AddHandler bwExportar2.ProgressChanged, AddressOf ExportarProgress
        AddHandler bwExportar2.RunWorkerCompleted, AddressOf ExportarComplete


    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents PaneL_CTA12 As System.Windows.Forms.Panel
    Friend WithEvents dgw_cta12 As System.Windows.Forms.DataGridView
    Friend WithEvents PaneL_CTA2 As System.Windows.Forms.Panel
    Friend WithEvents dgw_cta2 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_archivo2 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btn_pantalla2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_digitos2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_desc_cta12 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_cod_cta12 As System.Windows.Forms.TextBox
    Friend WithEvents cbo_nivel2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_mes2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_desc_cta02 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_cod_cta02 As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents KL2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
End Class
