<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PERSONA_RENTA
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.btn_Modificar = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ch_s = New System.Windows.Forms.CheckBox
        Me.txt_servicio = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel_per = New System.Windows.Forms.Panel
        Me.dgw_per = New System.Windows.Forms.DataGridView
        Me.txt_doc_per = New System.Windows.Forms.TextBox
        Me.txt_desc_per = New System.Windows.Forms.TextBox
        Me.txt_cod_per0 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtp_ini = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.R2 = New System.Windows.Forms.RadioButton
        Me.R1 = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.A2 = New System.Windows.Forms.RadioButton
        Me.A1 = New System.Windows.Forms.RadioButton
        Me.gb_det = New System.Windows.Forms.GroupBox
        Me.S2 = New System.Windows.Forms.RadioButton
        Me.S1 = New System.Windows.Forms.RadioButton
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.btn_modificar2 = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.TXT_KLP = New System.Windows.Forms.TextBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel_per.SuspendLayout()
        CType(Me.dgw_per, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gb_det.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(258, 18)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(617, 335)
        Me.TabControl1.TabIndex = 61
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgw1)
        Me.TabPage1.Controls.Add(Me.btn_salir)
        Me.TabPage1.Controls.Add(Me.btn_eliminar)
        Me.TabPage1.Controls.Add(Me.btn_nuevo)
        Me.TabPage1.Controls.Add(Me.btn_Modificar)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(609, 309)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Lista de Personas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AllowUserToOrderColumns = True
        Me.dgw1.AllowUserToResizeRows = False
        Me.dgw1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw1.Location = New System.Drawing.Point(24, 29)
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.ReadOnly = True
        Me.dgw1.RowHeadersWidth = 25
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw1.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(463, 255)
        Me.dgw1.TabIndex = 7
        '
        'btn_salir
        '
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(507, 152)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(85, 35)
        Me.btn_salir.TabIndex = 4
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar.Location = New System.Drawing.Point(507, 111)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(85, 35)
        Me.btn_eliminar.TabIndex = 3
        Me.btn_eliminar.Text = "&Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.Location = New System.Drawing.Point(507, 29)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(85, 35)
        Me.btn_nuevo.TabIndex = 1
        Me.btn_nuevo.Text = "&Nuevo"
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'btn_Modificar
        '
        Me.btn_Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Modificar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Modificar.Location = New System.Drawing.Point(507, 70)
        Me.btn_Modificar.Name = "btn_Modificar"
        Me.btn_Modificar.Size = New System.Drawing.Size(85, 35)
        Me.btn_Modificar.TabIndex = 2
        Me.btn_Modificar.Text = "&Modificar"
        Me.btn_Modificar.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(585, 309)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalles"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ch_s)
        Me.GroupBox2.Controls.Add(Me.txt_servicio)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Panel_per)
        Me.GroupBox2.Controls.Add(Me.txt_doc_per)
        Me.GroupBox2.Controls.Add(Me.txt_desc_per)
        Me.GroupBox2.Controls.Add(Me.txt_cod_per0)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtp_ini)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.gb_det)
        Me.GroupBox2.Controls.Add(Me.btn_guardar)
        Me.GroupBox2.Controls.Add(Me.btn_modificar2)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Controls.Add(Me.TXT_KLP)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(569, 272)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'ch_s
        '
        Me.ch_s.AutoSize = True
        Me.ch_s.Location = New System.Drawing.Point(101, 212)
        Me.ch_s.Name = "ch_s"
        Me.ch_s.Size = New System.Drawing.Size(83, 18)
        Me.ch_s.TabIndex = 8
        Me.ch_s.Text = "Suspensión"
        Me.ch_s.UseVisualStyleBackColor = True
        '
        'txt_servicio
        '
        Me.txt_servicio.BackColor = System.Drawing.Color.White
        Me.txt_servicio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_servicio.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_servicio.Location = New System.Drawing.Point(101, 180)
        Me.txt_servicio.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_servicio.MaxLength = 100
        Me.txt_servicio.Name = "txt_servicio"
        Me.txt_servicio.Size = New System.Drawing.Size(460, 20)
        Me.txt_servicio.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 14)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Servicio Prestado"
        '
        'Panel_per
        '
        Me.Panel_per.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_per.Controls.Add(Me.dgw_per)
        Me.Panel_per.Location = New System.Drawing.Point(0, 35)
        Me.Panel_per.Name = "Panel_per"
        Me.Panel_per.Size = New System.Drawing.Size(569, 121)
        Me.Panel_per.TabIndex = 71
        Me.Panel_per.Visible = False
        '
        'dgw_per
        '
        Me.dgw_per.AllowUserToAddRows = False
        Me.dgw_per.AllowUserToDeleteRows = False
        Me.dgw_per.AllowUserToOrderColumns = True
        Me.dgw_per.AllowUserToResizeRows = False
        Me.dgw_per.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_per.BackgroundColor = System.Drawing.Color.White
        Me.dgw_per.Location = New System.Drawing.Point(86, 1)
        Me.dgw_per.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_per.MultiSelect = False
        Me.dgw_per.Name = "dgw_per"
        Me.dgw_per.ReadOnly = True
        Me.dgw_per.RowHeadersWidth = 25
        Me.dgw_per.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_per.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_per.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_per.Size = New System.Drawing.Size(474, 114)
        Me.dgw_per.TabIndex = 15
        Me.dgw_per.TabStop = False
        '
        'txt_doc_per
        '
        Me.txt_doc_per.BackColor = System.Drawing.Color.White
        Me.txt_doc_per.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_doc_per.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_doc_per.Location = New System.Drawing.Point(476, 16)
        Me.txt_doc_per.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_doc_per.MaxLength = 20
        Me.txt_doc_per.Name = "txt_doc_per"
        Me.txt_doc_per.Size = New System.Drawing.Size(85, 20)
        Me.txt_doc_per.TabIndex = 3
        '
        'txt_desc_per
        '
        Me.txt_desc_per.BackColor = System.Drawing.Color.White
        Me.txt_desc_per.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_per.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_desc_per.Location = New System.Drawing.Point(134, 16)
        Me.txt_desc_per.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_per.Name = "txt_desc_per"
        Me.txt_desc_per.Size = New System.Drawing.Size(339, 20)
        Me.txt_desc_per.TabIndex = 2
        '
        'txt_cod_per0
        '
        Me.txt_cod_per0.BackColor = System.Drawing.Color.White
        Me.txt_cod_per0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_per0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_cod_per0.Location = New System.Drawing.Point(87, 16)
        Me.txt_cod_per0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_per0.MaxLength = 5
        Me.txt_cod_per0.Name = "txt_cod_per0"
        Me.txt_cod_per0.Size = New System.Drawing.Size(47, 20)
        Me.txt_cod_per0.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 14)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Persona"
        '
        'dtp_ini
        '
        Me.dtp_ini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_ini.Location = New System.Drawing.Point(226, 53)
        Me.dtp_ini.Name = "dtp_ini"
        Me.dtp_ini.Size = New System.Drawing.Size(80, 20)
        Me.dtp_ini.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(87, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 14)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Fecha de Nacimiento"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.R2)
        Me.GroupBox3.Controls.Add(Me.R1)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(402, 92)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(159, 75)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Condicion de Domicilio"
        '
        'R2
        '
        Me.R2.AutoSize = True
        Me.R2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.R2.Location = New System.Drawing.Point(8, 48)
        Me.R2.Name = "R2"
        Me.R2.Size = New System.Drawing.Size(94, 18)
        Me.R2.TabIndex = 4
        Me.R2.Text = "No Domiciliado"
        Me.R2.UseVisualStyleBackColor = True
        '
        'R1
        '
        Me.R1.AutoSize = True
        Me.R1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.R1.Location = New System.Drawing.Point(8, 24)
        Me.R1.Name = "R1"
        Me.R1.Size = New System.Drawing.Size(78, 18)
        Me.R1.TabIndex = 6
        Me.R1.Text = "Domiciliado"
        Me.R1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.A2)
        Me.GroupBox1.Controls.Add(Me.A1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(198, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(180, 75)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "¿Afiliacion a EsSalud + Vida?"
        '
        'A2
        '
        Me.A2.AutoSize = True
        Me.A2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.A2.Location = New System.Drawing.Point(33, 48)
        Me.A2.Name = "A2"
        Me.A2.Size = New System.Drawing.Size(38, 18)
        Me.A2.TabIndex = 4
        Me.A2.Text = "No"
        Me.A2.UseVisualStyleBackColor = True
        '
        'A1
        '
        Me.A1.AutoSize = True
        Me.A1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.A1.Location = New System.Drawing.Point(33, 24)
        Me.A1.Name = "A1"
        Me.A1.Size = New System.Drawing.Size(34, 18)
        Me.A1.TabIndex = 7
        Me.A1.Text = "Si"
        Me.A1.UseVisualStyleBackColor = True
        '
        'gb_det
        '
        Me.gb_det.Controls.Add(Me.S2)
        Me.gb_det.Controls.Add(Me.S1)
        Me.gb_det.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_det.Location = New System.Drawing.Point(87, 92)
        Me.gb_det.Name = "gb_det"
        Me.gb_det.Size = New System.Drawing.Size(87, 75)
        Me.gb_det.TabIndex = 4
        Me.gb_det.TabStop = False
        Me.gb_det.Text = "Sexo"
        '
        'S2
        '
        Me.S2.AutoSize = True
        Me.S2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.S2.Location = New System.Drawing.Point(8, 48)
        Me.S2.Name = "S2"
        Me.S2.Size = New System.Drawing.Size(71, 18)
        Me.S2.TabIndex = 4
        Me.S2.Text = "Femenino"
        Me.S2.UseVisualStyleBackColor = True
        '
        'S1
        '
        Me.S1.AutoSize = True
        Me.S1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.S1.Location = New System.Drawing.Point(8, 24)
        Me.S1.Name = "S1"
        Me.S1.Size = New System.Drawing.Size(67, 18)
        Me.S1.TabIndex = 8
        Me.S1.Text = "Maculino"
        Me.S1.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.Location = New System.Drawing.Point(390, 234)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(77, 27)
        Me.btn_guardar.TabIndex = 9
        Me.btn_guardar.Text = "&Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_modificar2
        '
        Me.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar2.Location = New System.Drawing.Point(390, 234)
        Me.btn_modificar2.Name = "btn_modificar2"
        Me.btn_modificar2.Size = New System.Drawing.Size(77, 27)
        Me.btn_modificar2.TabIndex = 9
        Me.btn_modificar2.Text = "&Guardar"
        Me.btn_modificar2.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.Location = New System.Drawing.Point(473, 234)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(77, 27)
        Me.btn_cancelar.TabIndex = 10
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'TXT_KLP
        '
        Me.TXT_KLP.BackColor = System.Drawing.Color.White
        Me.TXT_KLP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_KLP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TXT_KLP.Location = New System.Drawing.Point(372, 16)
        Me.TXT_KLP.Margin = New System.Windows.Forms.Padding(0)
        Me.TXT_KLP.MaxLength = 20
        Me.TXT_KLP.Name = "TXT_KLP"
        Me.TXT_KLP.Size = New System.Drawing.Size(16, 20)
        Me.TXT_KLP.TabIndex = 4
        '
        'PERSONA_RENTA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 335)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "PERSONA_RENTA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento Persona Renta"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel_per.ResumeLayout(False)
        CType(Me.dgw_per, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gb_det.ResumeLayout(False)
        Me.gb_det.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgw1 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_Modificar As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gb_det As System.Windows.Forms.GroupBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar2 As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents R2 As System.Windows.Forms.RadioButton
    Friend WithEvents R1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents A2 As System.Windows.Forms.RadioButton
    Friend WithEvents A1 As System.Windows.Forms.RadioButton
    Friend WithEvents S2 As System.Windows.Forms.RadioButton
    Friend WithEvents S1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel_per As System.Windows.Forms.Panel
    Friend WithEvents dgw_per As System.Windows.Forms.DataGridView
    Friend WithEvents txt_doc_per As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc_per As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod_per0 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXT_KLP As System.Windows.Forms.TextBox
    Friend WithEvents ch_s As System.Windows.Forms.CheckBox
    Friend WithEvents txt_servicio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
