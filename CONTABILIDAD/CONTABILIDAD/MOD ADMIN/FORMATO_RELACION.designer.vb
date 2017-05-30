<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FORMATO_RELACION
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_modificar = New System.Windows.Forms.Button
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.panel_cta = New System.Windows.Forms.Panel
        Me.dgw_cta = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_guardar2 = New System.Windows.Forms.Button
        Me.btn_cancelar2 = New System.Windows.Forms.Button
        Me.txt_cod_cta = New System.Windows.Forms.TextBox
        Me.K1 = New System.Windows.Forms.TextBox
        Me.ch_por = New System.Windows.Forms.CheckBox
        Me.cbo_detalle = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_desc_cta = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_nuevo2 = New System.Windows.Forms.Button
        Me.btn_grabar2 = New System.Windows.Forms.Button
        Me.Panel0 = New System.Windows.Forms.Panel
        Me.btn_eliminar2 = New System.Windows.Forms.Button
        Me.btn_agregar = New System.Windows.Forms.Button
        Me.dgw_det = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.btn_grabar = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.cbo_grupo = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbo_formato = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.panel_cta.SuspendLayout()
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel0.SuspendLayout()
        CType(Me.dgw_det, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb1.SuspendLayout()
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
        Me.TabControl1.Size = New System.Drawing.Size(528, 452)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btn_eliminar)
        Me.TabPage1.Controls.Add(Me.btn_nuevo)
        Me.TabPage1.Controls.Add(Me.btn_salir)
        Me.TabPage1.Controls.Add(Me.btn_modificar)
        Me.TabPage1.Controls.Add(Me.dgw1)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(520, 425)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Lista de Formatos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar.Location = New System.Drawing.Point(352, 383)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(77, 27)
        Me.btn_eliminar.TabIndex = 3
        Me.btn_eliminar.Text = "&Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.Location = New System.Drawing.Point(352, 350)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(77, 27)
        Me.btn_nuevo.TabIndex = 1
        Me.btn_nuevo.Text = "&Nuevo"
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(435, 383)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(77, 27)
        Me.btn_salir.TabIndex = 4
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_modificar
        '
        Me.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar.Location = New System.Drawing.Point(435, 350)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(77, 27)
        Me.btn_modificar.TabIndex = 2
        Me.btn_modificar.Text = "&Modificar"
        Me.btn_modificar.UseVisualStyleBackColor = True
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AllowUserToOrderColumns = True
        Me.dgw1.AllowUserToResizeRows = False
        Me.dgw1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw1.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgw1.Location = New System.Drawing.Point(3, 3)
        Me.dgw1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.ReadOnly = True
        Me.dgw1.RowHeadersWidth = 25
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(514, 331)
        Me.dgw1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Controls.Add(Me.gb1)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(520, 425)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalles"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.panel_cta)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Location = New System.Drawing.Point(3, 103)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(517, 319)
        Me.Panel2.TabIndex = 30
        Me.Panel2.Visible = False
        '
        'panel_cta
        '
        Me.panel_cta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_cta.Controls.Add(Me.dgw_cta)
        Me.panel_cta.Location = New System.Drawing.Point(22, 141)
        Me.panel_cta.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.panel_cta.Name = "panel_cta"
        Me.panel_cta.Size = New System.Drawing.Size(458, 120)
        Me.panel_cta.TabIndex = 6
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
        Me.dgw_cta.Location = New System.Drawing.Point(8, 3)
        Me.dgw_cta.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgw_cta.MultiSelect = False
        Me.dgw_cta.Name = "dgw_cta"
        Me.dgw_cta.ReadOnly = True
        Me.dgw_cta.RowHeadersWidth = 25
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta.Size = New System.Drawing.Size(442, 112)
        Me.dgw_cta.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_guardar2)
        Me.GroupBox1.Controls.Add(Me.btn_cancelar2)
        Me.GroupBox1.Controls.Add(Me.txt_cod_cta)
        Me.GroupBox1.Controls.Add(Me.K1)
        Me.GroupBox1.Controls.Add(Me.ch_por)
        Me.GroupBox1.Controls.Add(Me.cbo_detalle)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_desc_cta)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(463, 154)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btn_guardar2
        '
        Me.btn_guardar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_guardar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar2.Location = New System.Drawing.Point(293, 116)
        Me.btn_guardar2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_guardar2.Name = "btn_guardar2"
        Me.btn_guardar2.Size = New System.Drawing.Size(77, 27)
        Me.btn_guardar2.TabIndex = 5
        Me.btn_guardar2.Text = "&Agregar"
        Me.btn_guardar2.UseVisualStyleBackColor = True
        '
        'btn_cancelar2
        '
        Me.btn_cancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar2.Location = New System.Drawing.Point(374, 116)
        Me.btn_cancelar2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_cancelar2.Name = "btn_cancelar2"
        Me.btn_cancelar2.Size = New System.Drawing.Size(77, 27)
        Me.btn_cancelar2.TabIndex = 6
        Me.btn_cancelar2.Text = "&Cancelar"
        Me.btn_cancelar2.UseVisualStyleBackColor = True
        '
        'txt_cod_cta
        '
        Me.txt_cod_cta.BackColor = System.Drawing.Color.White
        Me.txt_cod_cta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_cod_cta.Location = New System.Drawing.Point(57, 46)
        Me.txt_cod_cta.MaxLength = 8
        Me.txt_cod_cta.Name = "txt_cod_cta"
        Me.txt_cod_cta.Size = New System.Drawing.Size(70, 20)
        Me.txt_cod_cta.TabIndex = 2
        '
        'K1
        '
        Me.K1.BackColor = System.Drawing.Color.White
        Me.K1.Location = New System.Drawing.Point(77, 46)
        Me.K1.MaxLength = 8
        Me.K1.Name = "K1"
        Me.K1.Size = New System.Drawing.Size(10, 20)
        Me.K1.TabIndex = 4
        '
        'ch_por
        '
        Me.ch_por.AutoSize = True
        Me.ch_por.Location = New System.Drawing.Point(57, 80)
        Me.ch_por.Name = "ch_por"
        Me.ch_por.Size = New System.Drawing.Size(64, 18)
        Me.ch_por.TabIndex = 4
        Me.ch_por.Text = "Base %"
        Me.ch_por.UseVisualStyleBackColor = True
        '
        'cbo_detalle
        '
        Me.cbo_detalle.BackColor = System.Drawing.Color.White
        Me.cbo_detalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_detalle.FormattingEnabled = True
        Me.cbo_detalle.Location = New System.Drawing.Point(57, 20)
        Me.cbo_detalle.Name = "cbo_detalle"
        Me.cbo_detalle.Size = New System.Drawing.Size(394, 22)
        Me.cbo_detalle.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 14)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Orden"
        '
        'txt_desc_cta
        '
        Me.txt_desc_cta.BackColor = System.Drawing.Color.White
        Me.txt_desc_cta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_desc_cta.Location = New System.Drawing.Point(128, 46)
        Me.txt_desc_cta.MaxLength = 30
        Me.txt_desc_cta.Name = "txt_desc_cta"
        Me.txt_desc_cta.Size = New System.Drawing.Size(323, 20)
        Me.txt_desc_cta.TabIndex = 3
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 50)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 14)
        Me.Label17.TabIndex = 45
        Me.Label17.Text = "Cuenta"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_nuevo2)
        Me.Panel1.Controls.Add(Me.btn_grabar2)
        Me.Panel1.Controls.Add(Me.Panel0)
        Me.Panel1.Controls.Add(Me.dgw_det)
        Me.Panel1.Controls.Add(Me.btn_grabar)
        Me.Panel1.Controls.Add(Me.btn_cancelar)
        Me.Panel1.Location = New System.Drawing.Point(3, 106)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(514, 313)
        Me.Panel1.TabIndex = 29
        '
        'btn_nuevo2
        '
        Me.btn_nuevo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo2.Location = New System.Drawing.Point(230, 262)
        Me.btn_nuevo2.Name = "btn_nuevo2"
        Me.btn_nuevo2.Size = New System.Drawing.Size(77, 27)
        Me.btn_nuevo2.TabIndex = 3
        Me.btn_nuevo2.Text = "&Nuevo"
        Me.btn_nuevo2.UseVisualStyleBackColor = True
        '
        'btn_grabar2
        '
        Me.btn_grabar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_grabar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_grabar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_grabar2.Location = New System.Drawing.Point(147, 262)
        Me.btn_grabar2.Name = "btn_grabar2"
        Me.btn_grabar2.Size = New System.Drawing.Size(77, 27)
        Me.btn_grabar2.TabIndex = 2
        Me.btn_grabar2.Text = "&Grabar"
        Me.btn_grabar2.UseVisualStyleBackColor = True
        '
        'Panel0
        '
        Me.Panel0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel0.Controls.Add(Me.btn_eliminar2)
        Me.Panel0.Controls.Add(Me.btn_agregar)
        Me.Panel0.Location = New System.Drawing.Point(433, 8)
        Me.Panel0.Name = "Panel0"
        Me.Panel0.Size = New System.Drawing.Size(81, 64)
        Me.Panel0.TabIndex = 1
        '
        'btn_eliminar2
        '
        Me.btn_eliminar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar2.Location = New System.Drawing.Point(2, 32)
        Me.btn_eliminar2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_eliminar2.Name = "btn_eliminar2"
        Me.btn_eliminar2.Size = New System.Drawing.Size(74, 27)
        Me.btn_eliminar2.TabIndex = 2
        Me.btn_eliminar2.Text = "&Eliminar"
        Me.btn_eliminar2.UseVisualStyleBackColor = True
        '
        'btn_agregar
        '
        Me.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_agregar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_agregar.Location = New System.Drawing.Point(2, 2)
        Me.btn_agregar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(74, 27)
        Me.btn_agregar.TabIndex = 1
        Me.btn_agregar.Text = "&Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'dgw_det
        '
        Me.dgw_det.AllowUserToAddRows = False
        Me.dgw_det.AllowUserToDeleteRows = False
        Me.dgw_det.AllowUserToOrderColumns = True
        Me.dgw_det.AllowUserToResizeRows = False
        Me.dgw_det.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgw_det.BackgroundColor = System.Drawing.Color.White
        Me.dgw_det.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_det.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dgw_det.Location = New System.Drawing.Point(5, 8)
        Me.dgw_det.MultiSelect = False
        Me.dgw_det.Name = "dgw_det"
        Me.dgw_det.ReadOnly = True
        Me.dgw_det.RowHeadersWidth = 25
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw_det.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgw_det.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_det.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_det.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_det.Size = New System.Drawing.Size(426, 235)
        Me.dgw_det.TabIndex = 1
        Me.dgw_det.TabStop = False
        '
        'Column1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column1.HeaderText = "Ord."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 30
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descripción"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column3
        '
        Me.Column3.HeaderText = "Cuenta"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 70
        '
        'Column4
        '
        Me.Column4.HeaderText = "Descripción"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 150
        '
        'Column5
        '
        Me.Column5.HeaderText = "B%"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 25
        '
        'btn_grabar
        '
        Me.btn_grabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_grabar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_grabar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_grabar.Location = New System.Drawing.Point(147, 262)
        Me.btn_grabar.Name = "btn_grabar"
        Me.btn_grabar.Size = New System.Drawing.Size(77, 27)
        Me.btn_grabar.TabIndex = 2
        Me.btn_grabar.Text = "&Grabar"
        Me.btn_grabar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.Location = New System.Drawing.Point(313, 262)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(77, 27)
        Me.btn_cancelar.TabIndex = 4
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'gb1
        '
        Me.gb1.Controls.Add(Me.cbo_grupo)
        Me.gb1.Controls.Add(Me.Label6)
        Me.gb1.Controls.Add(Me.cbo_formato)
        Me.gb1.Controls.Add(Me.Label5)
        Me.gb1.Location = New System.Drawing.Point(32, 30)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(463, 70)
        Me.gb1.TabIndex = 0
        Me.gb1.TabStop = False
        '
        'cbo_grupo
        '
        Me.cbo_grupo.BackColor = System.Drawing.Color.White
        Me.cbo_grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_grupo.FormattingEnabled = True
        Me.cbo_grupo.Location = New System.Drawing.Point(57, 39)
        Me.cbo_grupo.Name = "cbo_grupo"
        Me.cbo_grupo.Size = New System.Drawing.Size(394, 22)
        Me.cbo_grupo.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 14)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Grupo"
        '
        'cbo_formato
        '
        Me.cbo_formato.BackColor = System.Drawing.Color.White
        Me.cbo_formato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_formato.FormattingEnabled = True
        Me.cbo_formato.Location = New System.Drawing.Point(57, 14)
        Me.cbo_formato.Name = "cbo_formato"
        Me.cbo_formato.Size = New System.Drawing.Size(394, 22)
        Me.cbo_formato.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 14)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Formato"
        '
        'FORMATO_RELACION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 452)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FORMATO_RELACION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relaciones de Detalles"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.panel_cta.ResumeLayout(False)
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel0.ResumeLayout(False)
        CType(Me.dgw_det, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb1.ResumeLayout(False)
        Me.gb1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_agregar As Button
    Friend WithEvents btn_cancelar As Button
    Friend WithEvents btn_cancelar2 As Button
    Friend WithEvents btn_eliminar As Button
    Friend WithEvents btn_eliminar2 As Button
    Friend WithEvents btn_grabar As Button
    Friend WithEvents btn_grabar2 As Button
    Friend WithEvents btn_guardar2 As Button
    Friend WithEvents btn_modificar As Button
    Friend WithEvents btn_nuevo As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents cbo_detalle As ComboBox
    Friend WithEvents cbo_formato As ComboBox
    Friend WithEvents cbo_grupo As ComboBox
    Friend WithEvents ch_por As CheckBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewCheckBoxColumn
    Friend WithEvents dgw_cta As DataGridView
    Friend WithEvents dgw_det As DataGridView
    Friend WithEvents dgw1 As DataGridView
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents K1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents panel_cta As Panel
    Friend WithEvents Panel0 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txt_cod_cta As TextBox
    Friend WithEvents txt_desc_cta As TextBox
    Friend WithEvents btn_nuevo2 As System.Windows.Forms.Button

End Class
