<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NRO_MEDIO_PAGO
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
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_Eliminar = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.btn_Modificar = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_cod_banco = New System.Windows.Forms.TextBox
        Me.panel_banco = New System.Windows.Forms.Panel
        Me.dgw_banco = New System.Windows.Forms.DataGridView
        Me.ch_auto = New System.Windows.Forms.CheckBox
        Me.txt_desc_banco = New System.Windows.Forms.TextBox
        Me.cbo_long = New System.Windows.Forms.NumericUpDown
        Me.k1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_modificar2 = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.txt_num = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbo_mp = New System.Windows.Forms.ComboBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.panel_banco.SuspendLayout()
        CType(Me.dgw_banco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_long, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(299, 18)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(442, 286)
        Me.TabControl1.TabIndex = 50
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgw1)
        Me.TabPage1.Controls.Add(Me.btn_salir)
        Me.TabPage1.Controls.Add(Me.btn_Eliminar)
        Me.TabPage1.Controls.Add(Me.btn_nuevo)
        Me.TabPage1.Controls.Add(Me.btn_Modificar)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(434, 260)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Lista de Nro. de Medios de Pago"
        Me.TabPage1.UseVisualStyleBackColor = True
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
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.ReadOnly = True
        Me.dgw1.RowHeadersWidth = 25
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(428, 183)
        Me.dgw1.TabIndex = 0
        '
        'btn_salir
        '
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(351, 225)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(75, 27)
        Me.btn_salir.TabIndex = 4
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Eliminar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Eliminar.Location = New System.Drawing.Point(270, 225)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(75, 27)
        Me.btn_Eliminar.TabIndex = 3
        Me.btn_Eliminar.Text = "&Eliminar"
        Me.btn_Eliminar.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.Location = New System.Drawing.Point(270, 192)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(75, 27)
        Me.btn_nuevo.TabIndex = 1
        Me.btn_nuevo.Text = "&Nuevo"
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'btn_Modificar
        '
        Me.btn_Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Modificar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Modificar.Location = New System.Drawing.Point(351, 192)
        Me.btn_Modificar.Name = "btn_Modificar"
        Me.btn_Modificar.Size = New System.Drawing.Size(75, 27)
        Me.btn_Modificar.TabIndex = 2
        Me.btn_Modificar.Text = "&Modificar"
        Me.btn_Modificar.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(434, 260)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalles"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_cod_banco)
        Me.GroupBox2.Controls.Add(Me.panel_banco)
        Me.GroupBox2.Controls.Add(Me.ch_auto)
        Me.GroupBox2.Controls.Add(Me.txt_desc_banco)
        Me.GroupBox2.Controls.Add(Me.cbo_long)
        Me.GroupBox2.Controls.Add(Me.k1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Controls.Add(Me.btn_modificar2)
        Me.GroupBox2.Controls.Add(Me.btn_guardar)
        Me.GroupBox2.Controls.Add(Me.txt_num)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cbo_mp)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(405, 200)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'txt_cod_banco
        '
        Me.txt_cod_banco.BackColor = System.Drawing.Color.White
        Me.txt_cod_banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_cod_banco.Location = New System.Drawing.Point(88, 19)
        Me.txt_cod_banco.MaxLength = 4
        Me.txt_cod_banco.Name = "txt_cod_banco"
        Me.txt_cod_banco.Size = New System.Drawing.Size(50, 20)
        Me.txt_cod_banco.TabIndex = 0
        '
        'panel_banco
        '
        Me.panel_banco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_banco.Controls.Add(Me.dgw_banco)
        Me.panel_banco.Location = New System.Drawing.Point(0, 40)
        Me.panel_banco.Name = "panel_banco"
        Me.panel_banco.Size = New System.Drawing.Size(405, 160)
        Me.panel_banco.TabIndex = 26
        Me.panel_banco.Visible = False
        '
        'dgw_banco
        '
        Me.dgw_banco.AllowUserToAddRows = False
        Me.dgw_banco.AllowUserToDeleteRows = False
        Me.dgw_banco.AllowUserToOrderColumns = True
        Me.dgw_banco.AllowUserToResizeRows = False
        Me.dgw_banco.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_banco.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_banco.BackgroundColor = System.Drawing.Color.White
        Me.dgw_banco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_banco.EnableHeadersVisualStyles = False
        Me.dgw_banco.Location = New System.Drawing.Point(12, 2)
        Me.dgw_banco.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_banco.MultiSelect = False
        Me.dgw_banco.Name = "dgw_banco"
        Me.dgw_banco.ReadOnly = True
        Me.dgw_banco.RowHeadersWidth = 25
        Me.dgw_banco.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_banco.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_banco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_banco.Size = New System.Drawing.Size(380, 154)
        Me.dgw_banco.TabIndex = 25
        '
        'ch_auto
        '
        Me.ch_auto.AutoSize = True
        Me.ch_auto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch_auto.Location = New System.Drawing.Point(88, 125)
        Me.ch_auto.Name = "ch_auto"
        Me.ch_auto.Size = New System.Drawing.Size(80, 18)
        Me.ch_auto.TabIndex = 6
        Me.ch_auto.Text = "Automático"
        Me.ch_auto.UseVisualStyleBackColor = True
        '
        'txt_desc_banco
        '
        Me.txt_desc_banco.BackColor = System.Drawing.Color.White
        Me.txt_desc_banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_desc_banco.Location = New System.Drawing.Point(139, 19)
        Me.txt_desc_banco.Name = "txt_desc_banco"
        Me.txt_desc_banco.Size = New System.Drawing.Size(254, 20)
        Me.txt_desc_banco.TabIndex = 1
        '
        'cbo_long
        '
        Me.cbo_long.BackColor = System.Drawing.Color.White
        Me.cbo_long.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_long.Location = New System.Drawing.Point(88, 98)
        Me.cbo_long.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.cbo_long.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.cbo_long.Name = "cbo_long"
        Me.cbo_long.Size = New System.Drawing.Size(33, 20)
        Me.cbo_long.TabIndex = 5
        Me.cbo_long.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.cbo_long.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'k1
        '
        Me.k1.BackColor = System.Drawing.Color.White
        Me.k1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.k1.Location = New System.Drawing.Point(109, 19)
        Me.k1.Name = "k1"
        Me.k1.Size = New System.Drawing.Size(10, 20)
        Me.k1.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 14)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Nro de Digitos"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.Location = New System.Drawing.Point(316, 159)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(77, 27)
        Me.btn_cancelar.TabIndex = 8
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_modificar2
        '
        Me.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar2.Location = New System.Drawing.Point(233, 159)
        Me.btn_modificar2.Name = "btn_modificar2"
        Me.btn_modificar2.Size = New System.Drawing.Size(77, 27)
        Me.btn_modificar2.TabIndex = 7
        Me.btn_modificar2.Text = "&Guardar"
        Me.btn_modificar2.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.Location = New System.Drawing.Point(233, 159)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(77, 27)
        Me.btn_guardar.TabIndex = 7
        Me.btn_guardar.Text = "&Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'txt_num
        '
        Me.txt_num.BackColor = System.Drawing.Color.White
        Me.txt_num.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_num.Location = New System.Drawing.Point(88, 72)
        Me.txt_num.MaxLength = 15
        Me.txt_num.Name = "txt_num"
        Me.txt_num.Size = New System.Drawing.Size(105, 20)
        Me.txt_num.TabIndex = 4
        Me.txt_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Numeración"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Medio de Pago"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Banco"
        '
        'cbo_mp
        '
        Me.cbo_mp.BackColor = System.Drawing.Color.White
        Me.cbo_mp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mp.FormattingEnabled = True
        Me.cbo_mp.Location = New System.Drawing.Point(88, 44)
        Me.cbo_mp.Name = "cbo_mp"
        Me.cbo_mp.Size = New System.Drawing.Size(305, 22)
        Me.cbo_mp.TabIndex = 3
        '
        'NRO_MEDIO_PAGO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 286)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "NRO_MEDIO_PAGO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Nro. de Medio de Pago"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.panel_banco.ResumeLayout(False)
        CType(Me.dgw_banco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_long, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_cancelar As Button
    Friend WithEvents btn_Eliminar As Button
    Friend WithEvents btn_guardar As Button
    Friend WithEvents btn_Modificar As Button
    Friend WithEvents btn_modificar2 As Button
    Friend WithEvents btn_nuevo As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents cbo_long As NumericUpDown
    Friend WithEvents cbo_mp As ComboBox
    Friend WithEvents ch_auto As CheckBox
    Friend WithEvents dgw_banco As DataGridView
    Friend WithEvents dgw1 As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents k1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents panel_banco As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txt_cod_banco As TextBox
    Friend WithEvents txt_desc_banco As TextBox
    Friend WithEvents txt_num As TextBox

End Class
