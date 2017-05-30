<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AREA
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.GB = New System.Windows.Forms.GroupBox
        Me.cboZona = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboUnidadNegocio = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbo_tipo = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ch_sumario = New System.Windows.Forms.CheckBox
        Me.TXT_CTA_ANA = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_desc2 = New System.Windows.Forms.TextBox
        Me.txt_desc = New System.Windows.Forms.TextBox
        Me.txt_cod = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.btn_modificar = New System.Windows.Forms.Button
        Me.btn_modificar2 = New System.Windows.Forms.Button
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.f1 = New System.Windows.Forms.FlowLayoutPanel
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_sgt = New System.Windows.Forms.Button
        Me.btn_buscar = New System.Windows.Forms.Button
        Me.ch_ca = New System.Windows.Forms.RadioButton
        Me.ch_rs = New System.Windows.Forms.RadioButton
        Me.ch_cod = New System.Windows.Forms.RadioButton
        Me.txt_letra = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.chkSuspendido = New System.Windows.Forms.CheckBox
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB.SuspendLayout()
        Me.f1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AllowUserToOrderColumns = True
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw1.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgw1.Location = New System.Drawing.Point(0, 0)
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
        Me.dgw1.Size = New System.Drawing.Size(561, 280)
        Me.dgw1.TabIndex = 0
        Me.dgw1.TabStop = False
        '
        'GB
        '
        Me.GB.Controls.Add(Me.chkSuspendido)
        Me.GB.Controls.Add(Me.cboZona)
        Me.GB.Controls.Add(Me.Label7)
        Me.GB.Controls.Add(Me.cboUnidadNegocio)
        Me.GB.Controls.Add(Me.Label6)
        Me.GB.Controls.Add(Me.cbo_tipo)
        Me.GB.Controls.Add(Me.Label5)
        Me.GB.Controls.Add(Me.ch_sumario)
        Me.GB.Controls.Add(Me.TXT_CTA_ANA)
        Me.GB.Controls.Add(Me.Label4)
        Me.GB.Controls.Add(Me.txt_desc2)
        Me.GB.Controls.Add(Me.txt_desc)
        Me.GB.Controls.Add(Me.txt_cod)
        Me.GB.Controls.Add(Me.Label3)
        Me.GB.Controls.Add(Me.Label2)
        Me.GB.Controls.Add(Me.Label1)
        Me.GB.Enabled = False
        Me.GB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GB.Location = New System.Drawing.Point(171, 292)
        Me.GB.Name = "GB"
        Me.GB.Size = New System.Drawing.Size(378, 161)
        Me.GB.TabIndex = 1
        Me.GB.TabStop = False
        Me.GB.Text = "Centro de Costos"
        '
        'cboZona
        '
        Me.cboZona.BackColor = System.Drawing.Color.White
        Me.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZona.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZona.FormattingEnabled = True
        Me.cboZona.Items.AddRange(New Object() {"PRODUCCIÓN", "SERVICIOS DIRECTOS", "INTERNO"})
        Me.cboZona.Location = New System.Drawing.Point(62, 137)
        Me.cboZona.Name = "cboZona"
        Me.cboZona.Size = New System.Drawing.Size(136, 22)
        Me.cboZona.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 140)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 14)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Zona"
        '
        'cboUnidadNegocio
        '
        Me.cboUnidadNegocio.BackColor = System.Drawing.Color.White
        Me.cboUnidadNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidadNegocio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUnidadNegocio.FormattingEnabled = True
        Me.cboUnidadNegocio.Items.AddRange(New Object() {"PRODUCCIÓN", "SERVICIOS DIRECTOS", "INTERNO"})
        Me.cboUnidadNegocio.Location = New System.Drawing.Point(62, 110)
        Me.cboUnidadNegocio.Name = "cboUnidadNegocio"
        Me.cboUnidadNegocio.Size = New System.Drawing.Size(182, 22)
        Me.cboUnidadNegocio.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 14)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "U.N."
        '
        'cbo_tipo
        '
        Me.cbo_tipo.BackColor = System.Drawing.Color.White
        Me.cbo_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tipo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_tipo.FormattingEnabled = True
        Me.cbo_tipo.Items.AddRange(New Object() {"PRODUCCIÓN", "SERVICIOS DIRECTOS", "INTERNO"})
        Me.cbo_tipo.Location = New System.Drawing.Point(237, 83)
        Me.cbo_tipo.Name = "cbo_tipo"
        Me.cbo_tipo.Size = New System.Drawing.Size(136, 22)
        Me.cbo_tipo.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(180, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 14)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Tipo Dist."
        '
        'ch_sumario
        '
        Me.ch_sumario.AutoSize = True
        Me.ch_sumario.Enabled = False
        Me.ch_sumario.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch_sumario.Location = New System.Drawing.Point(119, 86)
        Me.ch_sumario.Name = "ch_sumario"
        Me.ch_sumario.Size = New System.Drawing.Size(65, 18)
        Me.ch_sumario.TabIndex = 11
        Me.ch_sumario.Text = "&Sumario"
        Me.ch_sumario.UseVisualStyleBackColor = True
        '
        'TXT_CTA_ANA
        '
        Me.TXT_CTA_ANA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_CTA_ANA.Enabled = False
        Me.TXT_CTA_ANA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_CTA_ANA.Location = New System.Drawing.Point(84, 85)
        Me.TXT_CTA_ANA.MaxLength = 2
        Me.TXT_CTA_ANA.Name = "TXT_CTA_ANA"
        Me.TXT_CTA_ANA.Size = New System.Drawing.Size(30, 20)
        Me.TXT_CTA_ANA.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 14)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Cta. Analitica"
        '
        'txt_desc2
        '
        Me.txt_desc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_desc2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc2.Location = New System.Drawing.Point(84, 61)
        Me.txt_desc2.MaxLength = 15
        Me.txt_desc2.Name = "txt_desc2"
        Me.txt_desc2.Size = New System.Drawing.Size(135, 20)
        Me.txt_desc2.TabIndex = 2
        '
        'txt_desc
        '
        Me.txt_desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_desc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc.Location = New System.Drawing.Point(84, 38)
        Me.txt_desc.MaxLength = 30
        Me.txt_desc.Name = "txt_desc"
        Me.txt_desc.Size = New System.Drawing.Size(214, 20)
        Me.txt_desc.TabIndex = 1
        '
        'txt_cod
        '
        Me.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_cod.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod.Location = New System.Drawing.Point(84, 14)
        Me.txt_cod.MaxLength = 5
        Me.txt_cod.Name = "txt_cod"
        Me.txt_cod.Size = New System.Drawing.Size(55, 20)
        Me.txt_cod.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 14)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Abreviado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Descripción"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 14)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Codigo"
        '
        'btn_salir
        '
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(243, 3)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(70, 29)
        Me.btn_salir.TabIndex = 3
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar.Location = New System.Drawing.Point(162, 3)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(75, 29)
        Me.btn_eliminar.TabIndex = 2
        Me.btn_eliminar.Text = "&Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_modificar
        '
        Me.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar.Location = New System.Drawing.Point(79, 3)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(77, 29)
        Me.btn_modificar.TabIndex = 1
        Me.btn_modificar.Text = "&Modificar"
        Me.btn_modificar.UseVisualStyleBackColor = True
        '
        'btn_modificar2
        '
        Me.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar2.Location = New System.Drawing.Point(8, 5)
        Me.btn_modificar2.Name = "btn_modificar2"
        Me.btn_modificar2.Size = New System.Drawing.Size(75, 29)
        Me.btn_modificar2.TabIndex = 0
        Me.btn_modificar2.Text = "&Aceptar"
        Me.btn_modificar2.UseVisualStyleBackColor = True
        Me.btn_modificar2.Visible = False
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.Location = New System.Drawing.Point(8, 5)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 29)
        Me.btn_guardar.TabIndex = 1
        Me.btn_guardar.Text = "&Aceptar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        Me.btn_guardar.Visible = False
        '
        'f1
        '
        Me.f1.Controls.Add(Me.btn_nuevo)
        Me.f1.Controls.Add(Me.btn_modificar)
        Me.f1.Controls.Add(Me.btn_eliminar)
        Me.f1.Controls.Add(Me.btn_salir)
        Me.f1.Location = New System.Drawing.Point(210, 459)
        Me.f1.Name = "f1"
        Me.f1.Size = New System.Drawing.Size(336, 37)
        Me.f1.TabIndex = 0
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.Location = New System.Drawing.Point(3, 3)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(70, 29)
        Me.btn_nuevo.TabIndex = 0
        Me.btn_nuevo.Text = "&Nuevo"
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.Location = New System.Drawing.Point(89, 5)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(77, 29)
        Me.btn_cancelar.TabIndex = 2
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_sgt)
        Me.GroupBox1.Controls.Add(Me.btn_buscar)
        Me.GroupBox1.Controls.Add(Me.ch_ca)
        Me.GroupBox1.Controls.Add(Me.ch_rs)
        Me.GroupBox1.Controls.Add(Me.ch_cod)
        Me.GroupBox1.Controls.Add(Me.txt_letra)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 306)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(153, 126)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscado por"
        '
        'btn_sgt
        '
        Me.btn_sgt.Enabled = False
        Me.btn_sgt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_sgt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sgt.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Next_set_2_1
        Me.btn_sgt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_sgt.Location = New System.Drawing.Point(83, 92)
        Me.btn_sgt.Name = "btn_sgt"
        Me.btn_sgt.Size = New System.Drawing.Size(64, 27)
        Me.btn_sgt.TabIndex = 4
        Me.btn_sgt.Text = "&Sgte."
        Me.btn_sgt.UseVisualStyleBackColor = True
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_buscar.Enabled = False
        Me.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_buscar.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btn_buscar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Binoculars_2_1
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.Location = New System.Drawing.Point(6, 92)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(74, 27)
        Me.btn_buscar.TabIndex = 1
        Me.btn_buscar.Text = "&Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'ch_ca
        '
        Me.ch_ca.AutoSize = True
        Me.ch_ca.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_ca.Location = New System.Drawing.Point(70, 48)
        Me.ch_ca.Name = "ch_ca"
        Me.ch_ca.Size = New System.Drawing.Size(62, 18)
        Me.ch_ca.TabIndex = 2
        Me.ch_ca.Text = "Cadena"
        Me.ch_ca.UseVisualStyleBackColor = True
        '
        'ch_rs
        '
        Me.ch_rs.AutoSize = True
        Me.ch_rs.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_rs.Location = New System.Drawing.Point(6, 69)
        Me.ch_rs.Name = "ch_rs"
        Me.ch_rs.Size = New System.Drawing.Size(82, 18)
        Me.ch_rs.TabIndex = 3
        Me.ch_rs.Text = "Descripción"
        Me.ch_rs.UseVisualStyleBackColor = True
        '
        'ch_cod
        '
        Me.ch_cod.AutoSize = True
        Me.ch_cod.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_cod.Location = New System.Drawing.Point(6, 48)
        Me.ch_cod.Name = "ch_cod"
        Me.ch_cod.Size = New System.Drawing.Size(58, 18)
        Me.ch_cod.TabIndex = 1
        Me.ch_cod.Text = "Código"
        Me.ch_cod.UseVisualStyleBackColor = True
        '
        'txt_letra
        '
        Me.txt_letra.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_letra.Location = New System.Drawing.Point(6, 20)
        Me.txt_letra.Name = "txt_letra"
        Me.txt_letra.Size = New System.Drawing.Size(141, 20)
        Me.txt_letra.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_guardar)
        Me.Panel1.Controls.Add(Me.btn_cancelar)
        Me.Panel1.Controls.Add(Me.btn_modificar2)
        Me.Panel1.Location = New System.Drawing.Point(282, 459)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(176, 37)
        Me.Panel1.TabIndex = 2
        '
        'chkSuspendido
        '
        Me.chkSuspendido.AutoSize = True
        Me.chkSuspendido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSuspendido.Location = New System.Drawing.Point(250, 112)
        Me.chkSuspendido.Name = "chkSuspendido"
        Me.chkSuspendido.Size = New System.Drawing.Size(83, 18)
        Me.chkSuspendido.TabIndex = 13
        Me.chkSuspendido.Text = "&Suspendido"
        Me.chkSuspendido.UseVisualStyleBackColor = True
        '
        'AREA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(561, 505)
        Me.ControlBox = False
        Me.Controls.Add(Me.f1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GB)
        Me.Controls.Add(Me.dgw1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "AREA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Centro de Costos"
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB.ResumeLayout(False)
        Me.GB.PerformLayout()
        Me.f1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgw1 As System.Windows.Forms.DataGridView
    Friend WithEvents GB As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ch_sumario As System.Windows.Forms.CheckBox
    Friend WithEvents TXT_CTA_ANA As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_desc2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_desc As System.Windows.Forms.TextBox
    Friend WithEvents txt_cod As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar2 As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents f1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_sgt As System.Windows.Forms.Button
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents ch_ca As System.Windows.Forms.RadioButton
    Friend WithEvents ch_rs As System.Windows.Forms.RadioButton
    Friend WithEvents ch_cod As System.Windows.Forms.RadioButton
    Friend WithEvents txt_letra As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboZona As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboUnidadNegocio As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkSuspendido As System.Windows.Forms.CheckBox
End Class
