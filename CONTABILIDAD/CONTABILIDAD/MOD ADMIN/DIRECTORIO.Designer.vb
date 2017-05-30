Imports System.ComponentModel
Imports System.DRAWING

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DIRECTORIO
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
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.btn_modificar = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.BTN_CANCELAR = New System.Windows.Forms.Button
        Me.TabControl2 = New System.Windows.Forms.TabControl
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TXT_DESC_det = New System.Windows.Forms.TextBox
        Me.btn_cancelar2 = New System.Windows.Forms.Button
        Me.btn_modificar2 = New System.Windows.Forms.Button
        Me.TXT_COD_det = New System.Windows.Forms.TextBox
        Me.btn_guardar2 = New System.Windows.Forms.Button
        Me.txt_obs_det = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.dgw = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.item1 = New System.Windows.Forms.TextBox
        Me.btn_nuevo2 = New System.Windows.Forms.Button
        Me.btn_eliminar2 = New System.Windows.Forms.Button
        Me.btn_mod2 = New System.Windows.Forms.Button
        Me.j1 = New System.Windows.Forms.GroupBox
        Me.nup_obs = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_desc = New System.Windows.Forms.TextBox
        Me.txt_cod = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.j1.SuspendLayout()
        CType(Me.nup_obs, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.Size = New System.Drawing.Size(543, 323)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btn_salir)
        Me.TabPage1.Controls.Add(Me.btn_eliminar)
        Me.TabPage1.Controls.Add(Me.btn_modificar)
        Me.TabPage1.Controls.Add(Me.btn_nuevo)
        Me.TabPage1.Controls.Add(Me.dgw1)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(535, 296)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Lista de Tablas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(442, 144)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(85, 35)
        Me.btn_salir.TabIndex = 9
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar.Location = New System.Drawing.Point(442, 103)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(85, 35)
        Me.btn_eliminar.TabIndex = 8
        Me.btn_eliminar.Text = "&Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_modificar
        '
        Me.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar.Location = New System.Drawing.Point(442, 62)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(85, 35)
        Me.btn_modificar.TabIndex = 7
        Me.btn_modificar.Text = "&Modificar"
        Me.btn_modificar.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.Location = New System.Drawing.Point(442, 21)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(85, 35)
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
        Me.dgw1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw1.Location = New System.Drawing.Point(19, 21)
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.ReadOnly = True
        Me.dgw1.RowHeadersWidth = 25
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(408, 257)
        Me.dgw1.TabIndex = 0
        Me.dgw1.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.BTN_CANCELAR)
        Me.TabPage2.Controls.Add(Me.TabControl2)
        Me.TabPage2.Controls.Add(Me.j1)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(535, 296)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalles"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'BTN_CANCELAR
        '
        Me.BTN_CANCELAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CANCELAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.BTN_CANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_CANCELAR.Location = New System.Drawing.Point(450, 243)
        Me.BTN_CANCELAR.Name = "BTN_CANCELAR"
        Me.BTN_CANCELAR.Size = New System.Drawing.Size(77, 27)
        Me.BTN_CANCELAR.TabIndex = 80
        Me.BTN_CANCELAR.TabStop = False
        Me.BTN_CANCELAR.Text = "&Cancelar"
        Me.BTN_CANCELAR.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl2.ItemSize = New System.Drawing.Size(425, 19)
        Me.TabControl2.Location = New System.Drawing.Point(6, 101)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(432, 195)
        Me.TabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl2.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel2)
        Me.TabPage3.Controls.Add(Me.dgw)
        Me.TabPage3.Controls.Add(Me.Panel1)
        Me.TabPage3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(424, 168)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Lista de Datos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox5)
        Me.Panel2.Location = New System.Drawing.Point(1, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(423, 165)
        Me.Panel2.TabIndex = 0
        Me.Panel2.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.TXT_DESC_det)
        Me.GroupBox5.Controls.Add(Me.btn_cancelar2)
        Me.GroupBox5.Controls.Add(Me.btn_modificar2)
        Me.GroupBox5.Controls.Add(Me.TXT_COD_det)
        Me.GroupBox5.Controls.Add(Me.btn_guardar2)
        Me.GroupBox5.Controls.Add(Me.txt_obs_det)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(406, 144)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Observación"
        '
        'TXT_DESC_det
        '
        Me.TXT_DESC_det.BackColor = System.Drawing.Color.White
        Me.TXT_DESC_det.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_DESC_det.Location = New System.Drawing.Point(72, 45)
        Me.TXT_DESC_det.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TXT_DESC_det.MaxLength = 60
        Me.TXT_DESC_det.Name = "TXT_DESC_det"
        Me.TXT_DESC_det.Size = New System.Drawing.Size(327, 20)
        Me.TXT_DESC_det.TabIndex = 2
        '
        'btn_cancelar2
        '
        Me.btn_cancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar2.Location = New System.Drawing.Point(322, 111)
        Me.btn_cancelar2.Name = "btn_cancelar2"
        Me.btn_cancelar2.Size = New System.Drawing.Size(77, 27)
        Me.btn_cancelar2.TabIndex = 5
        Me.btn_cancelar2.Text = "&Cancelar"
        Me.btn_cancelar2.UseVisualStyleBackColor = True
        '
        'btn_modificar2
        '
        Me.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar2.Location = New System.Drawing.Point(239, 111)
        Me.btn_modificar2.Name = "btn_modificar2"
        Me.btn_modificar2.Size = New System.Drawing.Size(77, 27)
        Me.btn_modificar2.TabIndex = 4
        Me.btn_modificar2.Text = "&Guardar"
        Me.btn_modificar2.UseVisualStyleBackColor = True
        '
        'TXT_COD_det
        '
        Me.TXT_COD_det.BackColor = System.Drawing.Color.White
        Me.TXT_COD_det.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_COD_det.Location = New System.Drawing.Point(72, 19)
        Me.TXT_COD_det.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TXT_COD_det.MaxLength = 10
        Me.TXT_COD_det.Name = "TXT_COD_det"
        Me.TXT_COD_det.Size = New System.Drawing.Size(100, 20)
        Me.TXT_COD_det.TabIndex = 1
        '
        'btn_guardar2
        '
        Me.btn_guardar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_guardar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar2.Location = New System.Drawing.Point(239, 111)
        Me.btn_guardar2.Name = "btn_guardar2"
        Me.btn_guardar2.Size = New System.Drawing.Size(77, 27)
        Me.btn_guardar2.TabIndex = 4
        Me.btn_guardar2.Text = "&Guardar"
        Me.btn_guardar2.UseVisualStyleBackColor = True
        '
        'txt_obs_det
        '
        Me.txt_obs_det.BackColor = System.Drawing.Color.White
        Me.txt_obs_det.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_obs_det.Location = New System.Drawing.Point(72, 71)
        Me.txt_obs_det.MaxLength = 60
        Me.txt_obs_det.Name = "txt_obs_det"
        Me.txt_obs_det.Size = New System.Drawing.Size(327, 20)
        Me.txt_obs_det.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 14)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Descripción"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 14)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Codigo"
        '
        'dgw
        '
        Me.dgw.AllowUserToAddRows = False
        Me.dgw.AllowUserToDeleteRows = False
        Me.dgw.AllowUserToOrderColumns = True
        Me.dgw.AllowUserToResizeRows = False
        Me.dgw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw.BackgroundColor = System.Drawing.Color.White
        Me.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgw.Location = New System.Drawing.Point(11, 6)
        Me.dgw.MultiSelect = False
        Me.dgw.Name = "dgw"
        Me.dgw.ReadOnly = True
        Me.dgw.RowHeadersWidth = 25
        Me.dgw.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw.Size = New System.Drawing.Size(320, 156)
        Me.dgw.TabIndex = 0
        Me.dgw.TabStop = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Cod"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 70
        '
        'Column2
        '
        Me.Column2.FillWeight = 194.9239!
        Me.Column2.HeaderText = "Descripción"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 223
        '
        'Column3
        '
        Me.Column3.FillWeight = 5.076141!
        Me.Column3.HeaderText = "Observacion"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        Me.Column3.Width = 26
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.item1)
        Me.Panel1.Controls.Add(Me.btn_nuevo2)
        Me.Panel1.Controls.Add(Me.btn_eliminar2)
        Me.Panel1.Controls.Add(Me.btn_mod2)
        Me.Panel1.Location = New System.Drawing.Point(8, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(416, 163)
        Me.Panel1.TabIndex = 15
        '
        'item1
        '
        Me.item1.Location = New System.Drawing.Point(340, 116)
        Me.item1.Name = "item1"
        Me.item1.Size = New System.Drawing.Size(25, 20)
        Me.item1.TabIndex = 14
        Me.item1.Visible = False
        '
        'btn_nuevo2
        '
        Me.btn_nuevo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo2.Location = New System.Drawing.Point(329, 3)
        Me.btn_nuevo2.Name = "btn_nuevo2"
        Me.btn_nuevo2.Size = New System.Drawing.Size(77, 27)
        Me.btn_nuevo2.TabIndex = 1
        Me.btn_nuevo2.Text = "&Agregar"
        Me.btn_nuevo2.UseVisualStyleBackColor = True
        '
        'btn_eliminar2
        '
        Me.btn_eliminar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar2.Location = New System.Drawing.Point(329, 62)
        Me.btn_eliminar2.Name = "btn_eliminar2"
        Me.btn_eliminar2.Size = New System.Drawing.Size(77, 27)
        Me.btn_eliminar2.TabIndex = 3
        Me.btn_eliminar2.Text = "&Eliminar"
        Me.btn_eliminar2.UseVisualStyleBackColor = True
        '
        'btn_mod2
        '
        Me.btn_mod2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_mod2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_mod2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_mod2.Location = New System.Drawing.Point(329, 32)
        Me.btn_mod2.Name = "btn_mod2"
        Me.btn_mod2.Size = New System.Drawing.Size(77, 27)
        Me.btn_mod2.TabIndex = 2
        Me.btn_mod2.Text = "&Modificar"
        Me.btn_mod2.UseVisualStyleBackColor = True
        '
        'j1
        '
        Me.j1.Controls.Add(Me.nup_obs)
        Me.j1.Controls.Add(Me.Label1)
        Me.j1.Controls.Add(Me.txt_desc)
        Me.j1.Controls.Add(Me.txt_cod)
        Me.j1.Controls.Add(Me.Label6)
        Me.j1.Controls.Add(Me.Label5)
        Me.j1.Location = New System.Drawing.Point(23, 8)
        Me.j1.Name = "j1"
        Me.j1.Size = New System.Drawing.Size(475, 87)
        Me.j1.TabIndex = 0
        Me.j1.TabStop = False
        '
        'nup_obs
        '
        Me.nup_obs.BackColor = System.Drawing.Color.White
        Me.nup_obs.Location = New System.Drawing.Point(318, 20)
        Me.nup_obs.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nup_obs.Name = "nup_obs"
        Me.nup_obs.Size = New System.Drawing.Size(36, 20)
        Me.nup_obs.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(213, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Nroº de digitos"
        '
        'txt_desc
        '
        Me.txt_desc.BackColor = System.Drawing.Color.White
        Me.txt_desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_desc.Location = New System.Drawing.Point(77, 48)
        Me.txt_desc.MaxLength = 60
        Me.txt_desc.Name = "txt_desc"
        Me.txt_desc.Size = New System.Drawing.Size(392, 20)
        Me.txt_desc.TabIndex = 3
        '
        'txt_cod
        '
        Me.txt_cod.BackColor = System.Drawing.Color.White
        Me.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_cod.Location = New System.Drawing.Point(77, 19)
        Me.txt_cod.MaxLength = 5
        Me.txt_cod.Name = "txt_cod"
        Me.txt_cod.Size = New System.Drawing.Size(60, 20)
        Me.txt_cod.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 14)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Descripción"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 14)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Codigo"
        '
        'DIRECTORIO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 323)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DIRECTORIO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Directorio"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.j1.ResumeLayout(False)
        Me.j1.PerformLayout()
        CType(Me.nup_obs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
End Class
