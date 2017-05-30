<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SALDO_BANCOS
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
        Me.btn_contable = New System.Windows.Forms.Button
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.btn_bloquear = New System.Windows.Forms.Button
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.btn_modificar = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.panel_banco = New System.Windows.Forms.Panel
        Me.dgw_banco = New System.Windows.Forms.DataGridView
        Me.btn_modificar2 = New System.Windows.Forms.Button
        Me.txt_desc_banco = New System.Windows.Forms.TextBox
        Me.txt_kl = New System.Windows.Forms.TextBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.txt_cod_banco = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_haber = New System.Windows.Forms.TextBox
        Me.txt_debe = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbo_ban_año = New System.Windows.Forms.ComboBox
        Me.cbo_ban_mes = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_desc_ban_ini = New System.Windows.Forms.TextBox
        Me.kl_ini = New System.Windows.Forms.TextBox
        Me.btn_cancelar_ini = New System.Windows.Forms.Button
        Me.btn_guardar_ini = New System.Windows.Forms.Button
        Me.txt_cod_ban_ini = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_haber_ini = New System.Windows.Forms.TextBox
        Me.txt_debe_ini = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txt_saldo = New System.Windows.Forms.TextBox
        Me.txt_cod_cta = New System.Windows.Forms.TextBox
        Me.txt_cod = New System.Windows.Forms.TextBox
        Me.txt_desc = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.btn_cancelar_sa = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.btn_guardar_sa = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.btn_cancelar_sa2 = New System.Windows.Forms.Button
        Me.btn_modificar_sa2 = New System.Windows.Forms.Button
        Me.dgw2 = New System.Windows.Forms.DataGridView
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.panel_banco.SuspendLayout()
        CType(Me.dgw_banco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgw2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(634, 326)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btn_contable)
        Me.TabPage1.Controls.Add(Me.dgw1)
        Me.TabPage1.Controls.Add(Me.btn_bloquear)
        Me.TabPage1.Controls.Add(Me.btn_eliminar)
        Me.TabPage1.Controls.Add(Me.btn_modificar)
        Me.TabPage1.Controls.Add(Me.btn_salir)
        Me.TabPage1.Controls.Add(Me.btn_nuevo)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(626, 299)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Saldo Estado de Bancos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btn_contable
        '
        Me.btn_contable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_contable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_contable.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Card_file_
        Me.btn_contable.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_contable.Location = New System.Drawing.Point(515, 105)
        Me.btn_contable.Name = "btn_contable"
        Me.btn_contable.Size = New System.Drawing.Size(88, 36)
        Me.btn_contable.TabIndex = 2
        Me.btn_contable.Text = "&Contable"
        Me.btn_contable.UseVisualStyleBackColor = True
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AllowUserToOrderColumns = True
        Me.dgw1.AllowUserToResizeRows = False
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.Location = New System.Drawing.Point(23, 21)
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.ReadOnly = True
        Me.dgw1.RowHeadersWidth = 25
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(468, 250)
        Me.dgw1.TabIndex = 6
        Me.dgw1.TabStop = False
        '
        'btn_bloquear
        '
        Me.btn_bloquear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_bloquear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_bloquear.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Stop_2_1
        Me.btn_bloquear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_bloquear.Location = New System.Drawing.Point(515, 189)
        Me.btn_bloquear.Name = "btn_bloquear"
        Me.btn_bloquear.Size = New System.Drawing.Size(88, 36)
        Me.btn_bloquear.TabIndex = 4
        Me.btn_bloquear.Text = "&Bloquear"
        Me.btn_bloquear.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_eliminar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar.Location = New System.Drawing.Point(515, 147)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(88, 36)
        Me.btn_eliminar.TabIndex = 3
        Me.btn_eliminar.Text = "&Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_modificar
        '
        Me.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar.Location = New System.Drawing.Point(515, 63)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(88, 36)
        Me.btn_modificar.TabIndex = 1
        Me.btn_modificar.Text = "&Modificar"
        Me.btn_modificar.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(515, 231)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(88, 36)
        Me.btn_salir.TabIndex = 5
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.Location = New System.Drawing.Point(515, 21)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(88, 36)
        Me.btn_nuevo.TabIndex = 0
        Me.btn_nuevo.Text = "&Nuevo"
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(626, 299)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalles"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.panel_banco)
        Me.GroupBox2.Controls.Add(Me.btn_modificar2)
        Me.GroupBox2.Controls.Add(Me.txt_desc_banco)
        Me.GroupBox2.Controls.Add(Me.txt_kl)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Controls.Add(Me.btn_guardar)
        Me.GroupBox2.Controls.Add(Me.txt_cod_banco)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txt_haber)
        Me.GroupBox2.Controls.Add(Me.txt_debe)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cbo_ban_año)
        Me.GroupBox2.Controls.Add(Me.cbo_ban_mes)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(67, 66)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(501, 190)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'panel_banco
        '
        Me.panel_banco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_banco.Controls.Add(Me.dgw_banco)
        Me.panel_banco.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_banco.Location = New System.Drawing.Point(6, 51)
        Me.panel_banco.Name = "panel_banco"
        Me.panel_banco.Size = New System.Drawing.Size(461, 124)
        Me.panel_banco.TabIndex = 129
        Me.panel_banco.Visible = False
        '
        'dgw_banco
        '
        Me.dgw_banco.AllowUserToAddRows = False
        Me.dgw_banco.AllowUserToDeleteRows = False
        Me.dgw_banco.AllowUserToOrderColumns = True
        Me.dgw_banco.AllowUserToResizeRows = False
        Me.dgw_banco.BackgroundColor = System.Drawing.Color.White
        Me.dgw_banco.Location = New System.Drawing.Point(84, 2)
        Me.dgw_banco.MultiSelect = False
        Me.dgw_banco.Name = "dgw_banco"
        Me.dgw_banco.ReadOnly = True
        Me.dgw_banco.RowHeadersWidth = 25
        Me.dgw_banco.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_banco.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_banco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_banco.Size = New System.Drawing.Size(366, 117)
        Me.dgw_banco.TabIndex = 0
        Me.dgw_banco.TabStop = False
        '
        'btn_modificar2
        '
        Me.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar2.Location = New System.Drawing.Point(292, 144)
        Me.btn_modificar2.Name = "btn_modificar2"
        Me.btn_modificar2.Size = New System.Drawing.Size(77, 31)
        Me.btn_modificar2.TabIndex = 7
        Me.btn_modificar2.Text = "&Modificar"
        Me.btn_modificar2.UseVisualStyleBackColor = True
        '
        'txt_desc_banco
        '
        Me.txt_desc_banco.BackColor = System.Drawing.Color.White
        Me.txt_desc_banco.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_banco.Location = New System.Drawing.Point(145, 31)
        Me.txt_desc_banco.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_banco.MaxLength = 40
        Me.txt_desc_banco.Name = "txt_desc_banco"
        Me.txt_desc_banco.Size = New System.Drawing.Size(312, 20)
        Me.txt_desc_banco.TabIndex = 1
        '
        'txt_kl
        '
        Me.txt_kl.Location = New System.Drawing.Point(375, 31)
        Me.txt_kl.Name = "txt_kl"
        Me.txt_kl.Size = New System.Drawing.Size(10, 20)
        Me.txt_kl.TabIndex = 2
        '
        'btn_cancelar
        '
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.Location = New System.Drawing.Point(380, 144)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(77, 31)
        Me.btn_cancelar.TabIndex = 8
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.Location = New System.Drawing.Point(292, 144)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(77, 31)
        Me.btn_guardar.TabIndex = 7
        Me.btn_guardar.Text = "&Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'txt_cod_banco
        '
        Me.txt_cod_banco.BackColor = System.Drawing.Color.White
        Me.txt_cod_banco.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_banco.Location = New System.Drawing.Point(91, 31)
        Me.txt_cod_banco.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_banco.MaxLength = 4
        Me.txt_cod_banco.Name = "txt_cod_banco"
        Me.txt_cod_banco.Size = New System.Drawing.Size(54, 20)
        Me.txt_cod_banco.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 14)
        Me.Label6.TabIndex = 137
        Me.Label6.Text = "Banco"
        '
        'txt_haber
        '
        Me.txt_haber.Location = New System.Drawing.Point(91, 105)
        Me.txt_haber.Name = "txt_haber"
        Me.txt_haber.Size = New System.Drawing.Size(100, 20)
        Me.txt_haber.TabIndex = 6
        Me.txt_haber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_debe
        '
        Me.txt_debe.Location = New System.Drawing.Point(91, 81)
        Me.txt_debe.Name = "txt_debe"
        Me.txt_debe.Size = New System.Drawing.Size(100, 20)
        Me.txt_debe.TabIndex = 5
        Me.txt_debe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 14)
        Me.Label7.TabIndex = 134
        Me.Label7.Text = "Haber"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 84)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 14)
        Me.Label8.TabIndex = 133
        Me.Label8.Text = "Debe"
        '
        'cbo_ban_año
        '
        Me.cbo_ban_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_ban_año.FormattingEnabled = True
        Me.cbo_ban_año.Location = New System.Drawing.Point(91, 55)
        Me.cbo_ban_año.Name = "cbo_ban_año"
        Me.cbo_ban_año.Size = New System.Drawing.Size(65, 22)
        Me.cbo_ban_año.TabIndex = 3
        '
        'cbo_ban_mes
        '
        Me.cbo_ban_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_ban_mes.FormattingEnabled = True
        Me.cbo_ban_mes.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbo_ban_mes.Location = New System.Drawing.Point(197, 55)
        Me.cbo_ban_mes.Name = "cbo_ban_mes"
        Me.cbo_ban_mes.Size = New System.Drawing.Size(38, 22)
        Me.cbo_ban_mes.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(164, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 14)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Mes"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(22, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 14)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Año"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(626, 299)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Saldo Contable"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_desc_ban_ini)
        Me.GroupBox1.Controls.Add(Me.kl_ini)
        Me.GroupBox1.Controls.Add(Me.btn_cancelar_ini)
        Me.GroupBox1.Controls.Add(Me.btn_guardar_ini)
        Me.GroupBox1.Controls.Add(Me.txt_cod_ban_ini)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_haber_ini)
        Me.GroupBox1.Controls.Add(Me.txt_debe_ini)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbo_año)
        Me.GroupBox1.Controls.Add(Me.cbo_mes)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(79, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(486, 173)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txt_desc_ban_ini
        '
        Me.txt_desc_ban_ini.BackColor = System.Drawing.Color.White
        Me.txt_desc_ban_ini.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_ban_ini.Location = New System.Drawing.Point(136, 32)
        Me.txt_desc_ban_ini.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_ban_ini.MaxLength = 40
        Me.txt_desc_ban_ini.Name = "txt_desc_ban_ini"
        Me.txt_desc_ban_ini.ReadOnly = True
        Me.txt_desc_ban_ini.Size = New System.Drawing.Size(332, 20)
        Me.txt_desc_ban_ini.TabIndex = 1
        '
        'kl_ini
        '
        Me.kl_ini.Location = New System.Drawing.Point(375, 32)
        Me.kl_ini.Name = "kl_ini"
        Me.kl_ini.Size = New System.Drawing.Size(10, 20)
        Me.kl_ini.TabIndex = 2
        '
        'btn_cancelar_ini
        '
        Me.btn_cancelar_ini.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar_ini.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar_ini.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar_ini.Location = New System.Drawing.Point(391, 125)
        Me.btn_cancelar_ini.Name = "btn_cancelar_ini"
        Me.btn_cancelar_ini.Size = New System.Drawing.Size(77, 31)
        Me.btn_cancelar_ini.TabIndex = 8
        Me.btn_cancelar_ini.Text = "&Cancelar"
        Me.btn_cancelar_ini.UseVisualStyleBackColor = True
        '
        'btn_guardar_ini
        '
        Me.btn_guardar_ini.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar_ini.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_guardar_ini.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar_ini.Location = New System.Drawing.Point(308, 125)
        Me.btn_guardar_ini.Name = "btn_guardar_ini"
        Me.btn_guardar_ini.Size = New System.Drawing.Size(77, 31)
        Me.btn_guardar_ini.TabIndex = 7
        Me.btn_guardar_ini.Text = "&Guardar"
        Me.btn_guardar_ini.UseVisualStyleBackColor = True
        '
        'txt_cod_ban_ini
        '
        Me.txt_cod_ban_ini.BackColor = System.Drawing.Color.White
        Me.txt_cod_ban_ini.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_ban_ini.Location = New System.Drawing.Point(90, 32)
        Me.txt_cod_ban_ini.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_ban_ini.MaxLength = 4
        Me.txt_cod_ban_ini.Name = "txt_cod_ban_ini"
        Me.txt_cod_ban_ini.ReadOnly = True
        Me.txt_cod_ban_ini.Size = New System.Drawing.Size(46, 20)
        Me.txt_cod_ban_ini.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 14)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "Banco"
        '
        'txt_haber_ini
        '
        Me.txt_haber_ini.Location = New System.Drawing.Point(91, 105)
        Me.txt_haber_ini.Name = "txt_haber_ini"
        Me.txt_haber_ini.Size = New System.Drawing.Size(100, 20)
        Me.txt_haber_ini.TabIndex = 6
        Me.txt_haber_ini.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_debe_ini
        '
        Me.txt_debe_ini.Location = New System.Drawing.Point(91, 81)
        Me.txt_debe_ini.Name = "txt_debe_ini"
        Me.txt_debe_ini.Size = New System.Drawing.Size(100, 20)
        Me.txt_debe_ini.TabIndex = 5
        Me.txt_debe_ini.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 14)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "Haber"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 14)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "Debe"
        '
        'cbo_año
        '
        Me.cbo_año.BackColor = System.Drawing.Color.White
        Me.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año.Enabled = False
        Me.cbo_año.FormattingEnabled = True
        Me.cbo_año.Location = New System.Drawing.Point(91, 55)
        Me.cbo_año.Name = "cbo_año"
        Me.cbo_año.Size = New System.Drawing.Size(65, 22)
        Me.cbo_año.TabIndex = 3
        '
        'cbo_mes
        '
        Me.cbo_mes.BackColor = System.Drawing.Color.White
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.Enabled = False
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbo_mes.Location = New System.Drawing.Point(197, 55)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(38, 22)
        Me.cbo_mes.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(164, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Mes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Año"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Panel2)
        Me.TabPage4.Controls.Add(Me.btn_cancelar_sa2)
        Me.TabPage4.Controls.Add(Me.btn_modificar_sa2)
        Me.TabPage4.Controls.Add(Me.dgw2)
        Me.TabPage4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(626, 299)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Saldo Actual"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txt_saldo)
        Me.Panel2.Controls.Add(Me.txt_cod_cta)
        Me.Panel2.Controls.Add(Me.txt_cod)
        Me.Panel2.Controls.Add(Me.txt_desc)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.GroupBox5)
        Me.Panel2.Location = New System.Drawing.Point(8, 22)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(610, 256)
        Me.Panel2.TabIndex = 5
        Me.Panel2.Visible = False
        '
        'txt_saldo
        '
        Me.txt_saldo.BackColor = System.Drawing.Color.White
        Me.txt_saldo.Location = New System.Drawing.Point(123, 134)
        Me.txt_saldo.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_saldo.MaxLength = 8
        Me.txt_saldo.Name = "txt_saldo"
        Me.txt_saldo.Size = New System.Drawing.Size(92, 20)
        Me.txt_saldo.TabIndex = 11
        Me.txt_saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_cod_cta
        '
        Me.txt_cod_cta.BackColor = System.Drawing.Color.White
        Me.txt_cod_cta.Location = New System.Drawing.Point(123, 109)
        Me.txt_cod_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_cta.MaxLength = 8
        Me.txt_cod_cta.Name = "txt_cod_cta"
        Me.txt_cod_cta.ReadOnly = True
        Me.txt_cod_cta.Size = New System.Drawing.Size(92, 20)
        Me.txt_cod_cta.TabIndex = 9
        '
        'txt_cod
        '
        Me.txt_cod.BackColor = System.Drawing.Color.White
        Me.txt_cod.Location = New System.Drawing.Point(123, 63)
        Me.txt_cod.MaxLength = 4
        Me.txt_cod.Name = "txt_cod"
        Me.txt_cod.ReadOnly = True
        Me.txt_cod.Size = New System.Drawing.Size(49, 20)
        Me.txt_cod.TabIndex = 5
        '
        'txt_desc
        '
        Me.txt_desc.BackColor = System.Drawing.Color.White
        Me.txt_desc.Location = New System.Drawing.Point(123, 86)
        Me.txt_desc.MaxLength = 40
        Me.txt_desc.Name = "txt_desc"
        Me.txt_desc.ReadOnly = True
        Me.txt_desc.Size = New System.Drawing.Size(448, 20)
        Me.txt_desc.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(48, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 14)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Descripción"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btn_cancelar_sa)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.btn_guardar_sa)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Location = New System.Drawing.Point(28, 17)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(562, 209)
        Me.GroupBox5.TabIndex = 13
        Me.GroupBox5.TabStop = False
        '
        'btn_cancelar_sa
        '
        Me.btn_cancelar_sa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar_sa.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar_sa.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar_sa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar_sa.Location = New System.Drawing.Point(452, 149)
        Me.btn_cancelar_sa.Name = "btn_cancelar_sa"
        Me.btn_cancelar_sa.Size = New System.Drawing.Size(80, 31)
        Me.btn_cancelar_sa.TabIndex = 11
        Me.btn_cancelar_sa.Text = "&Cancelar"
        Me.btn_cancelar_sa.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(20, 120)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 14)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Saldo"
        '
        'btn_guardar_sa
        '
        Me.btn_guardar_sa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar_sa.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar_sa.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_guardar_sa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar_sa.Location = New System.Drawing.Point(366, 149)
        Me.btn_guardar_sa.Name = "btn_guardar_sa"
        Me.btn_guardar_sa.Size = New System.Drawing.Size(80, 31)
        Me.btn_guardar_sa.TabIndex = 10
        Me.btn_guardar_sa.Text = "&Guardar"
        Me.btn_guardar_sa.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(20, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 14)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Código"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(20, 95)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 14)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Cuenta"
        '
        'btn_cancelar_sa2
        '
        Me.btn_cancelar_sa2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar_sa2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar_sa2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar_sa2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar_sa2.Location = New System.Drawing.Point(518, 59)
        Me.btn_cancelar_sa2.Name = "btn_cancelar_sa2"
        Me.btn_cancelar_sa2.Size = New System.Drawing.Size(80, 31)
        Me.btn_cancelar_sa2.TabIndex = 11
        Me.btn_cancelar_sa2.Text = "&Cancelar"
        Me.btn_cancelar_sa2.UseVisualStyleBackColor = True
        '
        'btn_modificar_sa2
        '
        Me.btn_modificar_sa2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar_sa2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar_sa2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_modificar_sa2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar_sa2.Location = New System.Drawing.Point(518, 22)
        Me.btn_modificar_sa2.Name = "btn_modificar_sa2"
        Me.btn_modificar_sa2.Size = New System.Drawing.Size(80, 31)
        Me.btn_modificar_sa2.TabIndex = 10
        Me.btn_modificar_sa2.Text = "&Modificar"
        Me.btn_modificar_sa2.UseVisualStyleBackColor = True
        '
        'dgw2
        '
        Me.dgw2.AllowUserToAddRows = False
        Me.dgw2.AllowUserToDeleteRows = False
        Me.dgw2.AllowUserToOrderColumns = True
        Me.dgw2.AllowUserToResizeRows = False
        Me.dgw2.BackgroundColor = System.Drawing.Color.White
        Me.dgw2.Location = New System.Drawing.Point(59, 22)
        Me.dgw2.MultiSelect = False
        Me.dgw2.Name = "dgw2"
        Me.dgw2.ReadOnly = True
        Me.dgw2.RowHeadersWidth = 25
        Me.dgw2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw2.Size = New System.Drawing.Size(443, 220)
        Me.dgw2.TabIndex = 14
        Me.dgw2.TabStop = False
        '
        'SALDO_BANCOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(634, 326)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "SALDO_BANCOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Saldos de Bancos"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.panel_banco.ResumeLayout(False)
        CType(Me.dgw_banco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgw2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_bloquear As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar_ini As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar_sa As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar_sa2 As System.Windows.Forms.Button
    Friend WithEvents btn_contable As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar_ini As System.Windows.Forms.Button
    Friend WithEvents btn_guardar_sa As System.Windows.Forms.Button
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar_sa2 As System.Windows.Forms.Button
    Friend WithEvents btn_modificar2 As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents cbo_año As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_ban_año As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_ban_mes As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents dgw_banco As System.Windows.Forms.DataGridView
    Friend WithEvents dgw1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgw2 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents kl_ini As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents panel_banco As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents txt_cod As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_ban_ini As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_banco As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_cta As System.Windows.Forms.TextBox
    Friend WithEvents txt_debe As System.Windows.Forms.TextBox
    Friend WithEvents txt_debe_ini As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc_ban_ini As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc_banco As System.Windows.Forms.TextBox
    Friend WithEvents txt_haber As System.Windows.Forms.TextBox
    Friend WithEvents txt_haber_ini As System.Windows.Forms.TextBox
    Friend WithEvents txt_kl As System.Windows.Forms.TextBox
    Friend WithEvents txt_saldo As System.Windows.Forms.TextBox


End Class
