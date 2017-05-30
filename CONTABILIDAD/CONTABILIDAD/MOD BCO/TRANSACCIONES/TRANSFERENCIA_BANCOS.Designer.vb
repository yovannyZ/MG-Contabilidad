<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TRANSFERENCIA_BANCOS
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
        Me.btn_anular = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel_ban1 = New System.Windows.Forms.Panel
        Me.dgw_ban = New System.Windows.Forms.DataGridView
        Me.Panel_ban2 = New System.Windows.Forms.Panel
        Me.dgw_ban2 = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cbo_moneda_destino = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.kl2 = New System.Windows.Forms.TextBox
        Me.txt_desc_ban2 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_saldo_destino = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_cod_ban2 = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbo_moneda_origen = New System.Windows.Forms.TextBox
        Me.txt_cod_ban = New System.Windows.Forms.TextBox
        Me.txt_desc_ban = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.kl1 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_saldo_origen = New System.Windows.Forms.TextBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_ajuste = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_imp_destino = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_imp_soles = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.cbo_com = New System.Windows.Forms.ComboBox
        Me.txt_cambio = New System.Windows.Forms.TextBox
        Me.cbo_mp = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbo_moneda = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.txt_num_mp = New System.Windows.Forms.TextBox
        Me.txt_desc_ope = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_nro_comp = New System.Windows.Forms.TextBox
        Me.dtp1 = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel_ban1.SuspendLayout()
        CType(Me.dgw_ban, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_ban2.SuspendLayout()
        CType(Me.dgw_ban2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(350, 20)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(683, 334)
        Me.TabControl1.TabIndex = 0
        Me.TabControl1.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.dgw1)
        Me.TabPage1.Controls.Add(Me.btn_anular)
        Me.TabPage1.Controls.Add(Me.btn_salir)
        Me.TabPage1.Controls.Add(Me.btn_nuevo)
        Me.TabPage1.Controls.Add(Me.btn_eliminar)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(675, 306)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Tag = "0"
        Me.TabPage1.Text = "Lista de Comprobantes"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AllowUserToOrderColumns = True
        Me.dgw1.AllowUserToResizeRows = False
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgw1.Location = New System.Drawing.Point(3, 3)
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.ReadOnly = True
        Me.dgw1.RowHeadersWidth = 25
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(669, 252)
        Me.dgw1.TabIndex = 5
        '
        'btn_anular
        '
        Me.btn_anular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_anular.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_anular.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Stop_2_1
        Me.btn_anular.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_anular.Location = New System.Drawing.Point(426, 261)
        Me.btn_anular.Name = "btn_anular"
        Me.btn_anular.Size = New System.Drawing.Size(78, 30)
        Me.btn_anular.TabIndex = 1
        Me.btn_anular.Text = "&Anular"
        Me.btn_anular.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(594, 261)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(78, 30)
        Me.btn_salir.TabIndex = 3
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.Location = New System.Drawing.Point(342, 261)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(78, 30)
        Me.btn_nuevo.TabIndex = 0
        Me.btn_nuevo.Text = "&Nuevo"
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_eliminar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar.Location = New System.Drawing.Point(510, 261)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(78, 30)
        Me.btn_eliminar.TabIndex = 2
        Me.btn_eliminar.Text = "&Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.Panel_ban1)
        Me.TabPage2.Controls.Add(Me.Panel_ban2)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.btn_cancelar)
        Me.TabPage2.Controls.Add(Me.btn_guardar)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(675, 306)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Tag = "1"
        Me.TabPage2.Text = "Detalles"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Ok_1
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(419, 259)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 30)
        Me.Button1.TabIndex = 65
        Me.Button1.Text = "&Ajuste"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel_ban1
        '
        Me.Panel_ban1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_ban1.Controls.Add(Me.dgw_ban)
        Me.Panel_ban1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel_ban1.Location = New System.Drawing.Point(0, 35)
        Me.Panel_ban1.Name = "Panel_ban1"
        Me.Panel_ban1.Size = New System.Drawing.Size(413, 109)
        Me.Panel_ban1.TabIndex = 60
        Me.Panel_ban1.Visible = False
        '
        'dgw_ban
        '
        Me.dgw_ban.AllowUserToAddRows = False
        Me.dgw_ban.AllowUserToDeleteRows = False
        Me.dgw_ban.AllowUserToOrderColumns = True
        Me.dgw_ban.AllowUserToResizeRows = False
        Me.dgw_ban.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_ban.BackgroundColor = System.Drawing.Color.White
        Me.dgw_ban.Location = New System.Drawing.Point(63, 2)
        Me.dgw_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_ban.MultiSelect = False
        Me.dgw_ban.Name = "dgw_ban"
        Me.dgw_ban.ReadOnly = True
        Me.dgw_ban.RowHeadersWidth = 25
        Me.dgw_ban.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_ban.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_ban.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_ban.Size = New System.Drawing.Size(322, 93)
        Me.dgw_ban.TabIndex = 61
        '
        'Panel_ban2
        '
        Me.Panel_ban2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_ban2.Controls.Add(Me.dgw_ban2)
        Me.Panel_ban2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel_ban2.Location = New System.Drawing.Point(0, 89)
        Me.Panel_ban2.Name = "Panel_ban2"
        Me.Panel_ban2.Size = New System.Drawing.Size(413, 100)
        Me.Panel_ban2.TabIndex = 61
        Me.Panel_ban2.Visible = False
        '
        'dgw_ban2
        '
        Me.dgw_ban2.AllowUserToAddRows = False
        Me.dgw_ban2.AllowUserToDeleteRows = False
        Me.dgw_ban2.AllowUserToOrderColumns = True
        Me.dgw_ban2.AllowUserToResizeRows = False
        Me.dgw_ban2.BackgroundColor = System.Drawing.Color.White
        Me.dgw_ban2.Location = New System.Drawing.Point(63, -1)
        Me.dgw_ban2.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_ban2.MultiSelect = False
        Me.dgw_ban2.Name = "dgw_ban2"
        Me.dgw_ban2.ReadOnly = True
        Me.dgw_ban2.RowHeadersWidth = 25
        Me.dgw_ban2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_ban2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_ban2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_ban2.Size = New System.Drawing.Size(331, 95)
        Me.dgw_ban2.TabIndex = 62
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbo_moneda_destino)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.kl2)
        Me.GroupBox3.Controls.Add(Me.txt_desc_ban2)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txt_saldo_destino)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txt_cod_ban2)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 56)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(667, 43)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Destino"
        '
        'cbo_moneda_destino
        '
        Me.cbo_moneda_destino.BackColor = System.Drawing.Color.White
        Me.cbo_moneda_destino.Enabled = False
        Me.cbo_moneda_destino.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_moneda_destino.Location = New System.Drawing.Point(428, 13)
        Me.cbo_moneda_destino.Name = "cbo_moneda_destino"
        Me.cbo_moneda_destino.Size = New System.Drawing.Size(84, 20)
        Me.cbo_moneda_destino.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 14)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Bancos"
        '
        'kl2
        '
        Me.kl2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kl2.Location = New System.Drawing.Point(451, 13)
        Me.kl2.Name = "kl2"
        Me.kl2.Size = New System.Drawing.Size(28, 20)
        Me.kl2.TabIndex = 3
        '
        'txt_desc_ban2
        '
        Me.txt_desc_ban2.BackColor = System.Drawing.Color.White
        Me.txt_desc_ban2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_ban2.Location = New System.Drawing.Point(116, 13)
        Me.txt_desc_ban2.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_ban2.MaxLength = 40
        Me.txt_desc_ban2.Name = "txt_desc_ban2"
        Me.txt_desc_ban2.Size = New System.Drawing.Size(264, 20)
        Me.txt_desc_ban2.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(383, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 14)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Moneda"
        '
        'txt_saldo_destino
        '
        Me.txt_saldo_destino.BackColor = System.Drawing.Color.White
        Me.txt_saldo_destino.Enabled = False
        Me.txt_saldo_destino.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_saldo_destino.Location = New System.Drawing.Point(557, 13)
        Me.txt_saldo_destino.Name = "txt_saldo_destino"
        Me.txt_saldo_destino.Size = New System.Drawing.Size(98, 20)
        Me.txt_saldo_destino.TabIndex = 4
        Me.txt_saldo_destino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(517, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 14)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Saldo"
        '
        'txt_cod_ban2
        '
        Me.txt_cod_ban2.BackColor = System.Drawing.Color.White
        Me.txt_cod_ban2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_ban2.Location = New System.Drawing.Point(58, 13)
        Me.txt_cod_ban2.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_ban2.MaxLength = 4
        Me.txt_cod_ban2.Name = "txt_cod_ban2"
        Me.txt_cod_ban2.Size = New System.Drawing.Size(58, 20)
        Me.txt_cod_ban2.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cbo_moneda_origen)
        Me.GroupBox2.Controls.Add(Me.txt_cod_ban)
        Me.GroupBox2.Controls.Add(Me.txt_desc_ban)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.kl1)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txt_saldo_origen)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(669, 46)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Origen"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Bancos"
        '
        'cbo_moneda_origen
        '
        Me.cbo_moneda_origen.BackColor = System.Drawing.Color.White
        Me.cbo_moneda_origen.Enabled = False
        Me.cbo_moneda_origen.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_moneda_origen.Location = New System.Drawing.Point(428, 13)
        Me.cbo_moneda_origen.Name = "cbo_moneda_origen"
        Me.cbo_moneda_origen.Size = New System.Drawing.Size(84, 20)
        Me.cbo_moneda_origen.TabIndex = 3
        '
        'txt_cod_ban
        '
        Me.txt_cod_ban.BackColor = System.Drawing.Color.White
        Me.txt_cod_ban.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_ban.Location = New System.Drawing.Point(58, 13)
        Me.txt_cod_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_ban.MaxLength = 4
        Me.txt_cod_ban.Name = "txt_cod_ban"
        Me.txt_cod_ban.Size = New System.Drawing.Size(58, 20)
        Me.txt_cod_ban.TabIndex = 0
        '
        'txt_desc_ban
        '
        Me.txt_desc_ban.BackColor = System.Drawing.Color.White
        Me.txt_desc_ban.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_ban.Location = New System.Drawing.Point(116, 13)
        Me.txt_desc_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_ban.MaxLength = 40
        Me.txt_desc_ban.Name = "txt_desc_ban"
        Me.txt_desc_ban.Size = New System.Drawing.Size(264, 20)
        Me.txt_desc_ban.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(383, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 14)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Moneda"
        '
        'kl1
        '
        Me.kl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kl1.Location = New System.Drawing.Point(428, 13)
        Me.kl1.Name = "kl1"
        Me.kl1.Size = New System.Drawing.Size(28, 20)
        Me.kl1.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(517, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 14)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Saldo"
        '
        'txt_saldo_origen
        '
        Me.txt_saldo_origen.BackColor = System.Drawing.Color.White
        Me.txt_saldo_origen.Enabled = False
        Me.txt_saldo_origen.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_saldo_origen.Location = New System.Drawing.Point(557, 13)
        Me.txt_saldo_origen.Name = "txt_saldo_origen"
        Me.txt_saldo_origen.Size = New System.Drawing.Size(98, 20)
        Me.txt_saldo_origen.TabIndex = 4
        Me.txt_saldo_origen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_cancelar
        '
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.Location = New System.Drawing.Point(586, 259)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(78, 30)
        Me.btn_cancelar.TabIndex = 6
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.Location = New System.Drawing.Point(504, 259)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(78, 30)
        Me.btn_guardar.TabIndex = 5
        Me.btn_guardar.Text = "&Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_ajuste)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_imp_destino)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_imp_soles)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.cbo_com)
        Me.GroupBox1.Controls.Add(Me.txt_cambio)
        Me.GroupBox1.Controls.Add(Me.cbo_mp)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbo_moneda)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txt_num_mp)
        Me.GroupBox1.Controls.Add(Me.txt_desc_ope)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txt_nro_comp)
        Me.GroupBox1.Controls.Add(Me.dtp1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 105)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(667, 144)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'txt_ajuste
        '
        Me.txt_ajuste.BackColor = System.Drawing.Color.White
        Me.txt_ajuste.Enabled = False
        Me.txt_ajuste.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ajuste.Location = New System.Drawing.Point(246, 113)
        Me.txt_ajuste.Name = "txt_ajuste"
        Me.txt_ajuste.Size = New System.Drawing.Size(66, 20)
        Me.txt_ajuste.TabIndex = 66
        Me.txt_ajuste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(205, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 14)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Ajuste"
        '
        'txt_imp_destino
        '
        Me.txt_imp_destino.BackColor = System.Drawing.Color.White
        Me.txt_imp_destino.Enabled = False
        Me.txt_imp_destino.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_imp_destino.Location = New System.Drawing.Point(99, 113)
        Me.txt_imp_destino.Name = "txt_imp_destino"
        Me.txt_imp_destino.Size = New System.Drawing.Size(100, 20)
        Me.txt_imp_destino.TabIndex = 64
        Me.txt_imp_destino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 14)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Importe Destino"
        '
        'txt_imp_soles
        '
        Me.txt_imp_soles.BackColor = System.Drawing.Color.White
        Me.txt_imp_soles.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_imp_soles.Location = New System.Drawing.Point(555, 68)
        Me.txt_imp_soles.Name = "txt_imp_soles"
        Me.txt_imp_soles.Size = New System.Drawing.Size(100, 20)
        Me.txt_imp_soles.TabIndex = 7
        Me.txt_imp_soles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, -1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 14)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Transferencia"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(495, 73)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 14)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "Importe"
        '
        'cbo_com
        '
        Me.cbo_com.BackColor = System.Drawing.Color.White
        Me.cbo_com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_com.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_com.FormattingEnabled = True
        Me.cbo_com.Location = New System.Drawing.Point(99, 23)
        Me.cbo_com.Name = "cbo_com"
        Me.cbo_com.Size = New System.Drawing.Size(172, 22)
        Me.cbo_com.TabIndex = 0
        '
        'txt_cambio
        '
        Me.txt_cambio.BackColor = System.Drawing.Color.White
        Me.txt_cambio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cambio.Location = New System.Drawing.Point(428, 68)
        Me.txt_cambio.Name = "txt_cambio"
        Me.txt_cambio.Size = New System.Drawing.Size(61, 20)
        Me.txt_cambio.TabIndex = 6
        Me.txt_cambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbo_mp
        '
        Me.cbo_mp.BackColor = System.Drawing.Color.White
        Me.cbo_mp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_mp.FormattingEnabled = True
        Me.cbo_mp.Location = New System.Drawing.Point(99, 45)
        Me.cbo_mp.Name = "cbo_mp"
        Me.cbo_mp.Size = New System.Drawing.Size(308, 22)
        Me.cbo_mp.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 14)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Moneda"
        '
        'cbo_moneda
        '
        Me.cbo_moneda.BackColor = System.Drawing.Color.White
        Me.cbo_moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_moneda.Enabled = False
        Me.cbo_moneda.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_moneda.FormattingEnabled = True
        Me.cbo_moneda.Location = New System.Drawing.Point(99, 68)
        Me.cbo_moneda.Name = "cbo_moneda"
        Me.cbo_moneda.Size = New System.Drawing.Size(158, 22)
        Me.cbo_moneda.TabIndex = 4
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 26)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(71, 14)
        Me.Label20.TabIndex = 49
        Me.Label20.Text = "Comprobante"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(396, 73)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(25, 14)
        Me.Label21.TabIndex = 55
        Me.Label21.Text = "T.C."
        '
        'txt_num_mp
        '
        Me.txt_num_mp.BackColor = System.Drawing.Color.White
        Me.txt_num_mp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_num_mp.Location = New System.Drawing.Point(531, 47)
        Me.txt_num_mp.MaxLength = 15
        Me.txt_num_mp.Name = "txt_num_mp"
        Me.txt_num_mp.Size = New System.Drawing.Size(124, 20)
        Me.txt_num_mp.TabIndex = 3
        '
        'txt_desc_ope
        '
        Me.txt_desc_ope.BackColor = System.Drawing.Color.White
        Me.txt_desc_ope.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_ope.Location = New System.Drawing.Point(99, 90)
        Me.txt_desc_ope.Name = "txt_desc_ope"
        Me.txt_desc_ope.Size = New System.Drawing.Size(556, 20)
        Me.txt_desc_ope.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(410, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 14)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Numeración de MP."
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(13, 95)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 14)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "Operación"
        '
        'txt_nro_comp
        '
        Me.txt_nro_comp.BackColor = System.Drawing.Color.White
        Me.txt_nro_comp.Enabled = False
        Me.txt_nro_comp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_comp.Location = New System.Drawing.Point(345, 23)
        Me.txt_nro_comp.Name = "txt_nro_comp"
        Me.txt_nro_comp.Size = New System.Drawing.Size(62, 20)
        Me.txt_nro_comp.TabIndex = 1
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(306, 70)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(84, 20)
        Me.dtp1.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(280, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 14)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Nº Comp."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(263, 73)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 14)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 14)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Medios de Pago"
        '
        'TRANSFERENCIA_BANCOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 334)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "TRANSFERENCIA_BANCOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transferencia de Bancos"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel_ban1.ResumeLayout(False)
        CType(Me.dgw_ban, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_ban2.ResumeLayout(False)
        CType(Me.dgw_ban2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_anular As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents cbo_com As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_moneda As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_moneda_destino As System.Windows.Forms.TextBox
    Friend WithEvents cbo_moneda_origen As System.Windows.Forms.TextBox
    Friend WithEvents cbo_mp As System.Windows.Forms.ComboBox
    Friend WithEvents dgw_ban As System.Windows.Forms.DataGridView
    Friend WithEvents dgw_ban2 As System.Windows.Forms.DataGridView
    Friend WithEvents dgw1 As System.Windows.Forms.DataGridView
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents kl1 As System.Windows.Forms.TextBox
    Friend WithEvents kl2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel_ban1 As System.Windows.Forms.Panel
    Friend WithEvents Panel_ban2 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txt_cambio As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_ban As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_ban2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc_ban As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc_ban2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc_ope As System.Windows.Forms.TextBox
    Friend WithEvents txt_imp_soles As System.Windows.Forms.TextBox
    Friend WithEvents txt_nro_comp As System.Windows.Forms.TextBox
    Friend WithEvents txt_num_mp As System.Windows.Forms.TextBox
    Friend WithEvents txt_saldo_destino As System.Windows.Forms.TextBox
    Friend WithEvents txt_saldo_origen As System.Windows.Forms.TextBox
    Friend WithEvents txt_imp_destino As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt_ajuste As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label


End Class
