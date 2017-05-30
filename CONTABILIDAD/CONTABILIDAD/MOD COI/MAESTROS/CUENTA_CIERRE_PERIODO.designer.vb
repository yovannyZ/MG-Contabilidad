<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CUENTA_CIERRE_PERIODO
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
        Me.Button2 = New System.Windows.Forms.Button
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.btn_modificar = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.dgw = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.PAN_CUENTA = New System.Windows.Forms.Panel
        Me.dgw_cuenta = New System.Windows.Forms.DataGridView
        Me.panel_det = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.btn_nuevo2 = New System.Windows.Forms.Button
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.BTN_CANCELAR = New System.Windows.Forms.Button
        Me.Panel0 = New System.Windows.Forms.Panel
        Me.btn_eliminar2 = New System.Windows.Forms.Button
        Me.btn_agregar = New System.Windows.Forms.Button
        Me.dgw_det = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel_new_det = New System.Windows.Forms.Panel
        Me.pan_cuenta_2 = New System.Windows.Forms.Panel
        Me.dgw_cuenta2 = New System.Windows.Forms.DataGridView
        Me.btn_agregar2 = New System.Windows.Forms.Button
        Me.btn_cancelar2 = New System.Windows.Forms.Button
        Me.txt_des_cuenta2 = New System.Windows.Forms.TextBox
        Me.txt_nivel = New System.Windows.Forms.TextBox
        Me.txt_cuenta2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_glosa = New System.Windows.Forms.TextBox
        Me.txt_desc_cuenta = New System.Windows.Forms.TextBox
        Me.txt_cuenta = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TXT_NIVEL_CAB = New System.Windows.Forms.TextBox
        Me.txt_nro_comp = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.chk_mod = New System.Windows.Forms.CheckBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.PAN_CUENTA.SuspendLayout()
        CType(Me.dgw_cuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_det.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel0.SuspendLayout()
        CType(Me.dgw_det, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_new_det.SuspendLayout()
        Me.pan_cuenta_2.SuspendLayout()
        CType(Me.dgw_cuenta2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(628, 360)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.btn_eliminar)
        Me.TabPage1.Controls.Add(Me.btn_modificar)
        Me.TabPage1.Controls.Add(Me.btn_nuevo)
        Me.TabPage1.Controls.Add(Me.btn_salir)
        Me.TabPage1.Controls.Add(Me.dgw)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(620, 334)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cierre"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Search_1
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(454, 273)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(76, 35)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "&Consulta"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar.Location = New System.Drawing.Point(536, 232)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(76, 35)
        Me.btn_eliminar.TabIndex = 17
        Me.btn_eliminar.Text = "&Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_modificar
        '
        Me.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar.Location = New System.Drawing.Point(454, 232)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(76, 35)
        Me.btn_modificar.TabIndex = 16
        Me.btn_modificar.Text = "&Modificar"
        Me.btn_modificar.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.Location = New System.Drawing.Point(372, 232)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(76, 35)
        Me.btn_nuevo.TabIndex = 15
        Me.btn_nuevo.Text = "&Nuevo"
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(536, 273)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(76, 35)
        Me.btn_salir.TabIndex = 18
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'dgw
        '
        Me.dgw.AllowUserToAddRows = False
        Me.dgw.AllowUserToDeleteRows = False
        Me.dgw.BackgroundColor = System.Drawing.Color.White
        Me.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgw.Location = New System.Drawing.Point(3, 3)
        Me.dgw.MultiSelect = False
        Me.dgw.Name = "dgw"
        Me.dgw.ReadOnly = True
        Me.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw.ShowRowErrors = False
        Me.dgw.Size = New System.Drawing.Size(614, 222)
        Me.dgw.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PAN_CUENTA)
        Me.TabPage2.Controls.Add(Me.panel_det)
        Me.TabPage2.Controls.Add(Me.Panel_new_det)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(620, 334)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalle"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'PAN_CUENTA
        '
        Me.PAN_CUENTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PAN_CUENTA.Controls.Add(Me.dgw_cuenta)
        Me.PAN_CUENTA.Location = New System.Drawing.Point(112, 79)
        Me.PAN_CUENTA.Name = "PAN_CUENTA"
        Me.PAN_CUENTA.Size = New System.Drawing.Size(465, 100)
        Me.PAN_CUENTA.TabIndex = 1
        Me.PAN_CUENTA.Visible = False
        '
        'dgw_cuenta
        '
        Me.dgw_cuenta.AllowUserToAddRows = False
        Me.dgw_cuenta.AllowUserToDeleteRows = False
        Me.dgw_cuenta.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cuenta.Location = New System.Drawing.Point(3, 3)
        Me.dgw_cuenta.MultiSelect = False
        Me.dgw_cuenta.Name = "dgw_cuenta"
        Me.dgw_cuenta.ReadOnly = True
        Me.dgw_cuenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cuenta.ShowRowErrors = False
        Me.dgw_cuenta.Size = New System.Drawing.Size(457, 86)
        Me.dgw_cuenta.TabIndex = 0
        '
        'panel_det
        '
        Me.panel_det.Controls.Add(Me.Panel5)
        Me.panel_det.Controls.Add(Me.Panel0)
        Me.panel_det.Controls.Add(Me.dgw_det)
        Me.panel_det.Location = New System.Drawing.Point(8, 111)
        Me.panel_det.Name = "panel_det"
        Me.panel_det.Size = New System.Drawing.Size(605, 216)
        Me.panel_det.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.btn_nuevo2)
        Me.Panel5.Controls.Add(Me.btn_imprimir)
        Me.Panel5.Controls.Add(Me.btn_guardar)
        Me.Panel5.Controls.Add(Me.BTN_CANCELAR)
        Me.Panel5.Location = New System.Drawing.Point(239, 165)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(338, 39)
        Me.Panel5.TabIndex = 26
        '
        'btn_nuevo2
        '
        Me.btn_nuevo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo2.Location = New System.Drawing.Point(169, 3)
        Me.btn_nuevo2.Name = "btn_nuevo2"
        Me.btn_nuevo2.Size = New System.Drawing.Size(77, 29)
        Me.btn_nuevo2.TabIndex = 6
        Me.btn_nuevo2.Text = "&Nuevo"
        Me.btn_nuevo2.UseVisualStyleBackColor = True
        '
        'btn_imprimir
        '
        Me.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprimir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir.Location = New System.Drawing.Point(87, 3)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(77, 29)
        Me.btn_imprimir.TabIndex = 5
        Me.btn_imprimir.Text = "&Imprimir"
        Me.btn_imprimir.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.Location = New System.Drawing.Point(6, 3)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(77, 29)
        Me.btn_guardar.TabIndex = 3
        Me.btn_guardar.Text = "&Grabar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'BTN_CANCELAR
        '
        Me.BTN_CANCELAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CANCELAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.BTN_CANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_CANCELAR.Location = New System.Drawing.Point(252, 3)
        Me.BTN_CANCELAR.Name = "BTN_CANCELAR"
        Me.BTN_CANCELAR.Size = New System.Drawing.Size(77, 29)
        Me.BTN_CANCELAR.TabIndex = 4
        Me.BTN_CANCELAR.Text = "&Cancelar"
        Me.BTN_CANCELAR.UseVisualStyleBackColor = True
        '
        'Panel0
        '
        Me.Panel0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel0.Controls.Add(Me.btn_eliminar2)
        Me.Panel0.Controls.Add(Me.btn_agregar)
        Me.Panel0.Location = New System.Drawing.Point(493, 18)
        Me.Panel0.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel0.Name = "Panel0"
        Me.Panel0.Size = New System.Drawing.Size(84, 109)
        Me.Panel0.TabIndex = 3
        Me.Panel0.TabStop = True
        '
        'btn_eliminar2
        '
        Me.btn_eliminar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar2.Location = New System.Drawing.Point(2, 63)
        Me.btn_eliminar2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_eliminar2.Name = "btn_eliminar2"
        Me.btn_eliminar2.Size = New System.Drawing.Size(77, 29)
        Me.btn_eliminar2.TabIndex = 12
        Me.btn_eliminar2.Text = "&Eliminar"
        Me.btn_eliminar2.UseVisualStyleBackColor = True
        '
        'btn_agregar
        '
        Me.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_agregar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_agregar.Location = New System.Drawing.Point(2, 17)
        Me.btn_agregar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(77, 29)
        Me.btn_agregar.TabIndex = 10
        Me.btn_agregar.Text = "&Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'dgw_det
        '
        Me.dgw_det.AllowUserToAddRows = False
        Me.dgw_det.AllowUserToDeleteRows = False
        Me.dgw_det.BackgroundColor = System.Drawing.Color.White
        Me.dgw_det.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_det.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgw_det.Location = New System.Drawing.Point(13, 3)
        Me.dgw_det.MultiSelect = False
        Me.dgw_det.Name = "dgw_det"
        Me.dgw_det.ReadOnly = True
        Me.dgw_det.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_det.ShowRowErrors = False
        Me.dgw_det.Size = New System.Drawing.Size(463, 149)
        Me.dgw_det.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Cuenta"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 80
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descripcion Cuenta"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 300
        '
        'Column3
        '
        Me.Column3.HeaderText = "Nivel"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 40
        '
        'Panel_new_det
        '
        Me.Panel_new_det.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_new_det.Controls.Add(Me.pan_cuenta_2)
        Me.Panel_new_det.Controls.Add(Me.btn_agregar2)
        Me.Panel_new_det.Controls.Add(Me.btn_cancelar2)
        Me.Panel_new_det.Controls.Add(Me.txt_des_cuenta2)
        Me.Panel_new_det.Controls.Add(Me.txt_nivel)
        Me.Panel_new_det.Controls.Add(Me.txt_cuenta2)
        Me.Panel_new_det.Controls.Add(Me.Label7)
        Me.Panel_new_det.Controls.Add(Me.Label5)
        Me.Panel_new_det.Controls.Add(Me.Label6)
        Me.Panel_new_det.Location = New System.Drawing.Point(8, 110)
        Me.Panel_new_det.Name = "Panel_new_det"
        Me.Panel_new_det.Size = New System.Drawing.Size(605, 164)
        Me.Panel_new_det.TabIndex = 2
        Me.Panel_new_det.Visible = False
        '
        'pan_cuenta_2
        '
        Me.pan_cuenta_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pan_cuenta_2.Controls.Add(Me.dgw_cuenta2)
        Me.pan_cuenta_2.Location = New System.Drawing.Point(119, 58)
        Me.pan_cuenta_2.Name = "pan_cuenta_2"
        Me.pan_cuenta_2.Size = New System.Drawing.Size(465, 100)
        Me.pan_cuenta_2.TabIndex = 1
        Me.pan_cuenta_2.Visible = False
        '
        'dgw_cuenta2
        '
        Me.dgw_cuenta2.AllowUserToAddRows = False
        Me.dgw_cuenta2.AllowUserToDeleteRows = False
        Me.dgw_cuenta2.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cuenta2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cuenta2.Location = New System.Drawing.Point(3, 3)
        Me.dgw_cuenta2.MultiSelect = False
        Me.dgw_cuenta2.Name = "dgw_cuenta2"
        Me.dgw_cuenta2.ReadOnly = True
        Me.dgw_cuenta2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cuenta2.ShowRowErrors = False
        Me.dgw_cuenta2.Size = New System.Drawing.Size(457, 86)
        Me.dgw_cuenta2.TabIndex = 0
        '
        'btn_agregar2
        '
        Me.btn_agregar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_agregar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_agregar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_agregar2.Location = New System.Drawing.Point(344, 105)
        Me.btn_agregar2.Name = "btn_agregar2"
        Me.btn_agregar2.Size = New System.Drawing.Size(77, 29)
        Me.btn_agregar2.TabIndex = 12
        Me.btn_agregar2.Text = "&Agregar"
        Me.btn_agregar2.UseVisualStyleBackColor = True
        '
        'btn_cancelar2
        '
        Me.btn_cancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar2.Location = New System.Drawing.Point(427, 105)
        Me.btn_cancelar2.Name = "btn_cancelar2"
        Me.btn_cancelar2.Size = New System.Drawing.Size(77, 29)
        Me.btn_cancelar2.TabIndex = 12
        Me.btn_cancelar2.Text = "&Cancelar"
        Me.btn_cancelar2.UseVisualStyleBackColor = True
        '
        'txt_des_cuenta2
        '
        Me.txt_des_cuenta2.Location = New System.Drawing.Point(119, 62)
        Me.txt_des_cuenta2.MaxLength = 300
        Me.txt_des_cuenta2.Name = "txt_des_cuenta2"
        Me.txt_des_cuenta2.Size = New System.Drawing.Size(385, 20)
        Me.txt_des_cuenta2.TabIndex = 11
        '
        'txt_nivel
        '
        Me.txt_nivel.Location = New System.Drawing.Point(303, 36)
        Me.txt_nivel.MaxLength = 1
        Me.txt_nivel.Name = "txt_nivel"
        Me.txt_nivel.Size = New System.Drawing.Size(44, 20)
        Me.txt_nivel.TabIndex = 9
        Me.txt_nivel.Visible = False
        '
        'txt_cuenta2
        '
        Me.txt_cuenta2.Location = New System.Drawing.Point(119, 36)
        Me.txt_cuenta2.MaxLength = 8
        Me.txt_cuenta2.Name = "txt_cuenta2"
        Me.txt_cuenta2.Size = New System.Drawing.Size(110, 20)
        Me.txt_cuenta2.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(255, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Nivel"
        Me.Label7.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(47, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Des. Cuenta"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(71, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Cuenta"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_mod)
        Me.GroupBox1.Controls.Add(Me.txt_glosa)
        Me.GroupBox1.Controls.Add(Me.txt_desc_cuenta)
        Me.GroupBox1.Controls.Add(Me.txt_cuenta)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TXT_NIVEL_CAB)
        Me.GroupBox1.Controls.Add(Me.txt_nro_comp)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(605, 98)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txt_glosa
        '
        Me.txt_glosa.Location = New System.Drawing.Point(231, 19)
        Me.txt_glosa.MaxLength = 60
        Me.txt_glosa.Name = "txt_glosa"
        Me.txt_glosa.Size = New System.Drawing.Size(364, 20)
        Me.txt_glosa.TabIndex = 3
        '
        'txt_desc_cuenta
        '
        Me.txt_desc_cuenta.Location = New System.Drawing.Point(281, 53)
        Me.txt_desc_cuenta.MaxLength = 200
        Me.txt_desc_cuenta.Name = "txt_desc_cuenta"
        Me.txt_desc_cuenta.Size = New System.Drawing.Size(314, 20)
        Me.txt_desc_cuenta.TabIndex = 7
        '
        'txt_cuenta
        '
        Me.txt_cuenta.Location = New System.Drawing.Point(105, 53)
        Me.txt_cuenta.MaxLength = 8
        Me.txt_cuenta.Name = "txt_cuenta"
        Me.txt_cuenta.Size = New System.Drawing.Size(88, 20)
        Me.txt_cuenta.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(209, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Descripcion"
        '
        'TXT_NIVEL_CAB
        '
        Me.TXT_NIVEL_CAB.Location = New System.Drawing.Point(6, 49)
        Me.TXT_NIVEL_CAB.MaxLength = 2
        Me.TXT_NIVEL_CAB.Name = "TXT_NIVEL_CAB"
        Me.TXT_NIVEL_CAB.Size = New System.Drawing.Size(37, 20)
        Me.TXT_NIVEL_CAB.TabIndex = 1
        Me.TXT_NIVEL_CAB.Visible = False
        '
        'txt_nro_comp
        '
        Me.txt_nro_comp.Location = New System.Drawing.Point(104, 19)
        Me.txt_nro_comp.MaxLength = 2
        Me.txt_nro_comp.Name = "txt_nro_comp"
        Me.txt_nro_comp.ReadOnly = True
        Me.txt_nro_comp.Size = New System.Drawing.Size(53, 20)
        Me.txt_nro_comp.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(57, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Cuenta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(190, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Glosa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nº Comprobante"
        '
        'chk_mod
        '
        Me.chk_mod.AutoSize = True
        Me.chk_mod.Location = New System.Drawing.Point(525, 78)
        Me.chk_mod.Name = "chk_mod"
        Me.chk_mod.Size = New System.Drawing.Size(67, 17)
        Me.chk_mod.TabIndex = 8
        Me.chk_mod.Text = "Habilidar"
        Me.chk_mod.UseVisualStyleBackColor = True
        '
        'CUENTA_CIERRE_PERIODO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 360)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "CUENTA_CIERRE_PERIODO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento Cierre de Periodo"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.PAN_CUENTA.ResumeLayout(False)
        CType(Me.dgw_cuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_det.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel0.ResumeLayout(False)
        CType(Me.dgw_det, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_new_det.ResumeLayout(False)
        Me.Panel_new_det.PerformLayout()
        Me.pan_cuenta_2.ResumeLayout(False)
        CType(Me.dgw_cuenta2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgw As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_nro_comp As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_glosa As System.Windows.Forms.TextBox
    Friend WithEvents txt_cuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents panel_det As System.Windows.Forms.Panel
    Friend WithEvents dgw_det As System.Windows.Forms.DataGridView
    Friend WithEvents Panel0 As System.Windows.Forms.Panel
    Friend WithEvents btn_eliminar2 As System.Windows.Forms.Button
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btn_nuevo2 As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents BTN_CANCELAR As System.Windows.Forms.Button
    Friend WithEvents PAN_CUENTA As System.Windows.Forms.Panel
    Friend WithEvents dgw_cuenta As System.Windows.Forms.DataGridView
    Friend WithEvents txt_desc_cuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel_new_det As System.Windows.Forms.Panel
    Friend WithEvents txt_des_cuenta2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_nivel As System.Windows.Forms.TextBox
    Friend WithEvents txt_cuenta2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_agregar2 As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar2 As System.Windows.Forms.Button
    Friend WithEvents pan_cuenta_2 As System.Windows.Forms.Panel
    Friend WithEvents dgw_cuenta2 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TXT_NIVEL_CAB As System.Windows.Forms.TextBox
    Friend WithEvents chk_mod As System.Windows.Forms.CheckBox
End Class
