<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CPTO_CUENTA
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
        Me.btn_salir = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_mod2 = New System.Windows.Forms.Button
        Me.txt_item = New System.Windows.Forms.TextBox
        Me.btn_nuevo2 = New System.Windows.Forms.Button
        Me.btn_eliminar2 = New System.Windows.Forms.Button
        Me.dgw = New System.Windows.Forms.DataGridView
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cbo_tipo = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_origen = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CBO_AREA = New System.Windows.Forms.ComboBox
        Me.txt_destino = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_enlace = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btn_cancelar2 = New System.Windows.Forms.Button
        Me.btn_modificar2 = New System.Windows.Forms.Button
        Me.btn_guardar2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_area = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BTN_LIMPIAR = New System.Windows.Forms.Button
        Me.txt_des = New System.Windows.Forms.TextBox
        Me.k1 = New System.Windows.Forms.TextBox
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button
        Me.txt_cod = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Panel_cpto = New System.Windows.Forms.Panel
        Me.dgw_cpto = New System.Windows.Forms.DataGridView
        Me.Panel1.SuspendLayout()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel_cpto.SuspendLayout()
        CType(Me.dgw_cpto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_salir
        '
        Me.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(510, 11)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(77, 27)
        Me.btn_salir.TabIndex = 7
        Me.btn_salir.TabStop = False
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btn_mod2)
        Me.Panel1.Controls.Add(Me.txt_item)
        Me.Panel1.Controls.Add(Me.btn_nuevo2)
        Me.Panel1.Controls.Add(Me.btn_eliminar2)
        Me.Panel1.Controls.Add(Me.dgw)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(6, 90)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(599, 211)
        Me.Panel1.TabIndex = 2
        '
        'btn_mod2
        '
        Me.btn_mod2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_mod2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_mod2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_mod2.Location = New System.Drawing.Point(509, 48)
        Me.btn_mod2.Name = "btn_mod2"
        Me.btn_mod2.Size = New System.Drawing.Size(77, 27)
        Me.btn_mod2.TabIndex = 1
        Me.btn_mod2.Text = "&Modificar"
        Me.btn_mod2.UseVisualStyleBackColor = True
        '
        'txt_item
        '
        Me.txt_item.BackColor = System.Drawing.Color.White
        Me.txt_item.Location = New System.Drawing.Point(549, 115)
        Me.txt_item.MaxLength = 8
        Me.txt_item.Name = "txt_item"
        Me.txt_item.ReadOnly = True
        Me.txt_item.Size = New System.Drawing.Size(10, 20)
        Me.txt_item.TabIndex = 37
        Me.txt_item.Visible = False
        '
        'btn_nuevo2
        '
        Me.btn_nuevo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo2.Location = New System.Drawing.Point(509, 19)
        Me.btn_nuevo2.Name = "btn_nuevo2"
        Me.btn_nuevo2.Size = New System.Drawing.Size(77, 27)
        Me.btn_nuevo2.TabIndex = 0
        Me.btn_nuevo2.Text = "&Agregar"
        Me.btn_nuevo2.UseVisualStyleBackColor = True
        '
        'btn_eliminar2
        '
        Me.btn_eliminar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar2.Location = New System.Drawing.Point(509, 78)
        Me.btn_eliminar2.Name = "btn_eliminar2"
        Me.btn_eliminar2.Size = New System.Drawing.Size(77, 27)
        Me.btn_eliminar2.TabIndex = 2
        Me.btn_eliminar2.Text = "&Eliminar"
        Me.btn_eliminar2.UseVisualStyleBackColor = True
        '
        'dgw
        '
        Me.dgw.AllowUserToAddRows = False
        Me.dgw.AllowUserToDeleteRows = False
        Me.dgw.AllowUserToOrderColumns = True
        Me.dgw.AllowUserToResizeRows = False
        Me.dgw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw.BackgroundColor = System.Drawing.Color.White
        Me.dgw.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column3, Me.Column6, Me.Column5, Me.Column4, Me.Column7})
        Me.dgw.Location = New System.Drawing.Point(27, 19)
        Me.dgw.MultiSelect = False
        Me.dgw.Name = "dgw"
        Me.dgw.ReadOnly = True
        Me.dgw.RowHeadersWidth = 25
        Me.dgw.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw.Size = New System.Drawing.Size(473, 176)
        Me.dgw.TabIndex = 34
        Me.dgw.TabStop = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "Cód."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 43
        '
        'Column3
        '
        Me.Column3.HeaderText = "Centro Costos"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 150
        '
        'Column6
        '
        Me.Column6.HeaderText = "Origen"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 70
        '
        'Column5
        '
        Me.Column5.HeaderText = "Destino"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 70
        '
        'Column4
        '
        Me.Column4.HeaderText = "Enlace"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 70
        '
        'Column7
        '
        Me.Column7.HeaderText = "Tipo"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 42
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Location = New System.Drawing.Point(90, 110)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(420, 176)
        Me.Panel2.TabIndex = 21
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbo_tipo)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txt_origen)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.CBO_AREA)
        Me.GroupBox3.Controls.Add(Me.txt_destino)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txt_enlace)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.btn_cancelar2)
        Me.GroupBox3.Controls.Add(Me.btn_modificar2)
        Me.GroupBox3.Controls.Add(Me.btn_guardar2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txt_area)
        Me.GroupBox3.Location = New System.Drawing.Point(27, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(367, 162)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'cbo_tipo
        '
        Me.cbo_tipo.BackColor = System.Drawing.Color.White
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.ItemHeight = 14
        Me.cbo_tipo.Items.AddRange(New Object() {"CTAS GASTO/INGRESO CON CC.", "CTAS DE BALANCE", "CTAS DE INGRESO"})
        Me.cbo_tipo.Location = New System.Drawing.Point(98, 12)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(175, 22)
        Me.cbo_tipo.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 14)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Tipo"
        '
        'txt_origen
        '
        Me.txt_origen.Location = New System.Drawing.Point(98, 70)
        Me.txt_origen.MaxLength = 8
        Me.txt_origen.Name = "txt_origen"
        Me.txt_origen.Size = New System.Drawing.Size(80, 20)
        Me.txt_origen.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 14)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Cuenta Origen"
        '
        'CBO_AREA
        '
        Me.CBO_AREA.BackColor = System.Drawing.Color.White
        Me.CBO_AREA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_AREA.FormattingEnabled = True
        Me.CBO_AREA.ItemHeight = 14
        Me.CBO_AREA.Location = New System.Drawing.Point(98, 41)
        Me.CBO_AREA.Name = "CBO_AREA"
        Me.CBO_AREA.Size = New System.Drawing.Size(175, 22)
        Me.CBO_AREA.TabIndex = 1
        '
        'txt_destino
        '
        Me.txt_destino.Location = New System.Drawing.Point(98, 97)
        Me.txt_destino.MaxLength = 8
        Me.txt_destino.Name = "txt_destino"
        Me.txt_destino.Size = New System.Drawing.Size(80, 20)
        Me.txt_destino.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 14)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Destino"
        '
        'txt_enlace
        '
        Me.txt_enlace.Location = New System.Drawing.Point(236, 70)
        Me.txt_enlace.MaxLength = 8
        Me.txt_enlace.Name = "txt_enlace"
        Me.txt_enlace.Size = New System.Drawing.Size(80, 20)
        Me.txt_enlace.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(191, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 14)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Enlace"
        '
        'btn_cancelar2
        '
        Me.btn_cancelar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar2.Location = New System.Drawing.Point(267, 119)
        Me.btn_cancelar2.Name = "btn_cancelar2"
        Me.btn_cancelar2.Size = New System.Drawing.Size(77, 27)
        Me.btn_cancelar2.TabIndex = 6
        Me.btn_cancelar2.Text = "&Cancelar"
        Me.btn_cancelar2.UseVisualStyleBackColor = True
        '
        'btn_modificar2
        '
        Me.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar2.Location = New System.Drawing.Point(184, 119)
        Me.btn_modificar2.Name = "btn_modificar2"
        Me.btn_modificar2.Size = New System.Drawing.Size(77, 27)
        Me.btn_modificar2.TabIndex = 5
        Me.btn_modificar2.Text = "&Modificar"
        Me.btn_modificar2.UseVisualStyleBackColor = True
        '
        'btn_guardar2
        '
        Me.btn_guardar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_guardar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar2.Location = New System.Drawing.Point(184, 119)
        Me.btn_guardar2.Name = "btn_guardar2"
        Me.btn_guardar2.Size = New System.Drawing.Size(77, 27)
        Me.btn_guardar2.TabIndex = 5
        Me.btn_guardar2.Text = "&Guardar"
        Me.btn_guardar2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 14)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Centro Costos"
        '
        'txt_area
        '
        Me.txt_area.BackColor = System.Drawing.Color.White
        Me.txt_area.Location = New System.Drawing.Point(211, 41)
        Me.txt_area.MaxLength = 8
        Me.txt_area.Name = "txt_area"
        Me.txt_area.ReadOnly = True
        Me.txt_area.Size = New System.Drawing.Size(50, 20)
        Me.txt_area.TabIndex = 38
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTN_LIMPIAR)
        Me.GroupBox1.Controls.Add(Me.txt_des)
        Me.GroupBox1.Controls.Add(Me.k1)
        Me.GroupBox1.Controls.Add(Me.BTN_ACEPTAR)
        Me.GroupBox1.Controls.Add(Me.txt_cod)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(599, 78)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'BTN_LIMPIAR
        '
        Me.BTN_LIMPIAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_LIMPIAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_LIMPIAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.BTN_LIMPIAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_LIMPIAR.Location = New System.Drawing.Point(427, 41)
        Me.BTN_LIMPIAR.Name = "BTN_LIMPIAR"
        Me.BTN_LIMPIAR.Size = New System.Drawing.Size(77, 27)
        Me.BTN_LIMPIAR.TabIndex = 6
        Me.BTN_LIMPIAR.Text = "&Limpiar"
        Me.BTN_LIMPIAR.UseVisualStyleBackColor = True
        '
        'txt_des
        '
        Me.txt_des.BackColor = System.Drawing.Color.White
        Me.txt_des.Location = New System.Drawing.Point(137, 21)
        Me.txt_des.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_des.Name = "txt_des"
        Me.txt_des.Size = New System.Drawing.Size(276, 20)
        Me.txt_des.TabIndex = 3
        '
        'k1
        '
        Me.k1.Location = New System.Drawing.Point(279, 21)
        Me.k1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.k1.MaxLength = 10
        Me.k1.Name = "k1"
        Me.k1.Size = New System.Drawing.Size(10, 20)
        Me.k1.TabIndex = 4
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_ACEPTAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_ACEPTAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Ok_1
        Me.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(427, 11)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(77, 27)
        Me.BTN_ACEPTAR.TabIndex = 5
        Me.BTN_ACEPTAR.Text = "&Aceptar"
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = True
        '
        'txt_cod
        '
        Me.txt_cod.BackColor = System.Drawing.Color.White
        Me.txt_cod.Location = New System.Drawing.Point(69, 21)
        Me.txt_cod.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txt_cod.MaxLength = 10
        Me.txt_cod.Name = "txt_cod"
        Me.txt_cod.Size = New System.Drawing.Size(67, 20)
        Me.txt_cod.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(10, 24)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 14)
        Me.Label17.TabIndex = 99
        Me.Label17.Text = "Concepto"
        '
        'Panel_cpto
        '
        Me.Panel_cpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_cpto.Controls.Add(Me.dgw_cpto)
        Me.Panel_cpto.Location = New System.Drawing.Point(75, 47)
        Me.Panel_cpto.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel_cpto.Name = "Panel_cpto"
        Me.Panel_cpto.Size = New System.Drawing.Size(358, 156)
        Me.Panel_cpto.TabIndex = 102
        Me.Panel_cpto.TabStop = True
        Me.Panel_cpto.Visible = False
        '
        'dgw_cpto
        '
        Me.dgw_cpto.AllowUserToAddRows = False
        Me.dgw_cpto.AllowUserToDeleteRows = False
        Me.dgw_cpto.AllowUserToOrderColumns = True
        Me.dgw_cpto.AllowUserToResizeRows = False
        Me.dgw_cpto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_cpto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_cpto.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cpto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cpto.Location = New System.Drawing.Point(4, 3)
        Me.dgw_cpto.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgw_cpto.MultiSelect = False
        Me.dgw_cpto.Name = "dgw_cpto"
        Me.dgw_cpto.ReadOnly = True
        Me.dgw_cpto.RowHeadersWidth = 25
        Me.dgw_cpto.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cpto.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cpto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cpto.Size = New System.Drawing.Size(345, 143)
        Me.dgw_cpto.TabIndex = 99
        '
        'CPTO_CUENTA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 303)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel_cpto)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CPTO_CUENTA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Concepto - Cuenta"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel_cpto.ResumeLayout(False)
        CType(Me.dgw_cpto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents btn_cancelar2 As Button
    Friend WithEvents btn_eliminar2 As Button
    Friend WithEvents btn_guardar2 As Button
    Friend WithEvents BTN_LIMPIAR As Button
    Friend WithEvents btn_mod2 As Button
    Friend WithEvents btn_modificar2 As Button
    Friend WithEvents btn_nuevo2 As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents CBO_AREA As ComboBox
    Friend WithEvents cbo_tipo As ComboBox
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents dgw As DataGridView
    Friend WithEvents dgw_cpto As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents k1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel_cpto As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txt_area As TextBox
    Friend WithEvents txt_cod As TextBox
    Friend WithEvents txt_des As TextBox
    Friend WithEvents txt_destino As TextBox
    Friend WithEvents txt_enlace As TextBox
    Friend WithEvents txt_item As TextBox
    Friend WithEvents txt_origen As TextBox


End Class
