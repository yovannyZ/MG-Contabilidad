<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarPlanilla
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txt_Campos = New System.Windows.Forms.TextBox
        Me.DG = New System.Windows.Forms.DataGridView
        Me.Btn_Salir = New System.Windows.Forms.Button
        Me.DialogOpen = New System.Windows.Forms.OpenFileDialog
        Me.txt_Esquema = New System.Windows.Forms.TextBox
        Me.Btn_Cargar = New System.Windows.Forms.Button
        Me.txt_Datos = New System.Windows.Forms.TextBox
        Me.Btn_Abrir = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.ch_comp = New System.Windows.Forms.CheckBox
        Me.cbo_aux = New System.Windows.Forms.ComboBox
        Me.dtp_com = New System.Windows.Forms.DateTimePicker
        Me.cbo_com = New System.Windows.Forms.ComboBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.txt_nro_comp = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtp1 = New System.Windows.Forms.DateTimePicker
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column27 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column29 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column28 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_Campos
        '
        Me.txt_Campos.Location = New System.Drawing.Point(11, 351)
        Me.txt_Campos.Name = "txt_Campos"
        Me.txt_Campos.Size = New System.Drawing.Size(143, 20)
        Me.txt_Campos.TabIndex = 56
        Me.txt_Campos.Visible = False
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DG.BackgroundColor = System.Drawing.Color.White
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column24, Me.Column25, Me.Column26, Me.Column27, Me.Column19, Me.Column20, Me.Column21, Me.Column22, Me.Column23, Me.Column29, Me.Column28})
        Me.DG.Location = New System.Drawing.Point(12, 148)
        Me.DG.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DG.MultiSelect = False
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        Me.DG.RowHeadersWidth = 18
        Me.DG.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DG.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG.Size = New System.Drawing.Size(756, 344)
        Me.DG.TabIndex = 50
        '
        'Btn_Salir
        '
        Me.Btn_Salir.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Salir.Location = New System.Drawing.Point(556, 17)
        Me.Btn_Salir.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(80, 29)
        Me.Btn_Salir.TabIndex = 48
        Me.Btn_Salir.Text = "&Salir"
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'DialogOpen
        '
        Me.DialogOpen.FileName = "OpenFileDialog1"
        '
        'txt_Esquema
        '
        Me.txt_Esquema.Location = New System.Drawing.Point(12, 215)
        Me.txt_Esquema.Multiline = True
        Me.txt_Esquema.Name = "txt_Esquema"
        Me.txt_Esquema.Size = New System.Drawing.Size(223, 242)
        Me.txt_Esquema.TabIndex = 57
        Me.txt_Esquema.Visible = False
        '
        'Btn_Cargar
        '
        Me.Btn_Cargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Cargar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cargar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Next_set_2_1
        Me.Btn_Cargar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Cargar.Location = New System.Drawing.Point(529, 24)
        Me.Btn_Cargar.Name = "Btn_Cargar"
        Me.Btn_Cargar.Size = New System.Drawing.Size(124, 26)
        Me.Btn_Cargar.TabIndex = 47
        Me.Btn_Cargar.Text = "&Cargar Archivo."
        Me.Btn_Cargar.UseVisualStyleBackColor = True
        '
        'txt_Datos
        '
        Me.txt_Datos.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_Datos.Location = New System.Drawing.Point(153, 27)
        Me.txt_Datos.Name = "txt_Datos"
        Me.txt_Datos.Size = New System.Drawing.Size(290, 20)
        Me.txt_Datos.TabIndex = 51
        '
        'Btn_Abrir
        '
        Me.Btn_Abrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Abrir.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Btn_Abrir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_search_
        Me.Btn_Abrir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Abrir.Location = New System.Drawing.Point(449, 24)
        Me.Btn_Abrir.Name = "Btn_Abrir"
        Me.Btn_Abrir.Size = New System.Drawing.Size(74, 26)
        Me.Btn_Abrir.TabIndex = 52
        Me.Btn_Abrir.Text = "&Buscar"
        Me.Btn_Abrir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 33)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 14)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Seleccione el archivo (*.txt)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_aceptar)
        Me.GroupBox2.Controls.Add(Me.ch_comp)
        Me.GroupBox2.Controls.Add(Me.cbo_aux)
        Me.GroupBox2.Controls.Add(Me.dtp_com)
        Me.GroupBox2.Controls.Add(Me.cbo_com)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.txt_nro_comp)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.Btn_Salir)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.dtp1)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(11, 69)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(642, 73)
        Me.GroupBox2.TabIndex = 58
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Generar a Contabilidad"
        '
        'btn_aceptar
        '
        Me.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aceptar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Card_file_1
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar.Location = New System.Drawing.Point(392, 17)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(159, 29)
        Me.btn_aceptar.TabIndex = 1
        Me.btn_aceptar.Text = "&Generar a Contabilidad"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'ch_comp
        '
        Me.ch_comp.AutoSize = True
        Me.ch_comp.Checked = True
        Me.ch_comp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_comp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch_comp.Location = New System.Drawing.Point(322, 21)
        Me.ch_comp.Name = "ch_comp"
        Me.ch_comp.Size = New System.Drawing.Size(57, 18)
        Me.ch_comp.TabIndex = 34
        Me.ch_comp.Text = "x Doc."
        Me.ch_comp.UseVisualStyleBackColor = True
        Me.ch_comp.Visible = False
        '
        'cbo_aux
        '
        Me.cbo_aux.BackColor = System.Drawing.Color.White
        Me.cbo_aux.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_aux.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_aux.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_aux.FormattingEnabled = True
        Me.cbo_aux.Location = New System.Drawing.Point(81, 19)
        Me.cbo_aux.MaxDropDownItems = 9
        Me.cbo_aux.Name = "cbo_aux"
        Me.cbo_aux.Size = New System.Drawing.Size(139, 22)
        Me.cbo_aux.TabIndex = 26
        '
        'dtp_com
        '
        Me.dtp_com.CalendarForeColor = System.Drawing.SystemColors.Desktop
        Me.dtp_com.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaptionText
        Me.dtp_com.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_com.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_com.Location = New System.Drawing.Point(259, 45)
        Me.dtp_com.Name = "dtp_com"
        Me.dtp_com.Size = New System.Drawing.Size(77, 20)
        Me.dtp_com.TabIndex = 30
        '
        'cbo_com
        '
        Me.cbo_com.BackColor = System.Drawing.Color.White
        Me.cbo_com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_com.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_com.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_com.FormattingEnabled = True
        Me.cbo_com.Location = New System.Drawing.Point(81, 45)
        Me.cbo_com.MaxDropDownItems = 10
        Me.cbo_com.Name = "cbo_com"
        Me.cbo_com.Size = New System.Drawing.Size(139, 22)
        Me.cbo_com.TabIndex = 27
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(6, 22)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(43, 14)
        Me.Label35.TabIndex = 33
        Me.Label35.Text = "Auxiliar"
        '
        'txt_nro_comp
        '
        Me.txt_nro_comp.BackColor = System.Drawing.Color.White
        Me.txt_nro_comp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nro_comp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_nro_comp.Location = New System.Drawing.Point(259, 19)
        Me.txt_nro_comp.MaxLength = 4
        Me.txt_nro_comp.Name = "txt_nro_comp"
        Me.txt_nro_comp.ReadOnly = True
        Me.txt_nro_comp.Size = New System.Drawing.Size(47, 20)
        Me.txt_nro_comp.TabIndex = 29
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(222, 22)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(19, 14)
        Me.Label29.TabIndex = 32
        Me.Label29.Text = "Nº"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 14)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Comprobante"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(222, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Fecha "
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(467, 19)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(84, 20)
        Me.dtp1.TabIndex = 24
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
        Me.Column2.HeaderText = "Glosa"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column3
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle1.Format = "N2"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.HeaderText = "Soles"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 70
        '
        'Column4
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.HeaderText = "Dolares"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 70
        '
        'Column5
        '
        Me.Column5.HeaderText = "D/H"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 30
        '
        'Column6
        '
        Me.Column6.HeaderText = "Mon"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 30
        '
        'Column7
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "N4"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column7.HeaderText = "T.C."
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 70
        '
        'Column8
        '
        Me.Column8.HeaderText = "Cod Doc"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 30
        '
        'Column9
        '
        Me.Column9.HeaderText = "Nro Doc"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "Fecha"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 80
        '
        'Column11
        '
        Me.Column11.HeaderText = "Cta. Cte."
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 60
        '
        'Column12
        '
        Me.Column12.HeaderText = "Razon Social"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 120
        '
        'Column13
        '
        Me.Column13.HeaderText = "Ruc/Dni"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "Ref."
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.Width = 60
        '
        'Column15
        '
        Me.Column15.HeaderText = "Nro. Ref"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column16
        '
        Me.Column16.HeaderText = "C.Costos"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.Width = 60
        '
        'Column17
        '
        Me.Column17.HeaderText = "Control"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Width = 70
        '
        'Column18
        '
        Me.Column18.HeaderText = "Proyectos"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.Width = 70
        '
        'Column24
        '
        Me.Column24.HeaderText = "Status_CC"
        Me.Column24.Name = "Column24"
        Me.Column24.ReadOnly = True
        Me.Column24.Width = 70
        '
        'Column25
        '
        Me.Column25.HeaderText = "Status_Cont"
        Me.Column25.Name = "Column25"
        Me.Column25.ReadOnly = True
        Me.Column25.Width = 70
        '
        'Column26
        '
        Me.Column26.HeaderText = "Status_Pro"
        Me.Column26.Name = "Column26"
        Me.Column26.ReadOnly = True
        Me.Column26.Width = 70
        '
        'Column27
        '
        Me.Column27.HeaderText = "Status"
        Me.Column27.Name = "Column27"
        Me.Column27.ReadOnly = True
        Me.Column27.Width = 30
        '
        'Column19
        '
        Me.Column19.HeaderText = "Au"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        Me.Column19.Width = 30
        '
        'Column20
        '
        Me.Column20.HeaderText = "Enlace"
        Me.Column20.Name = "Column20"
        Me.Column20.ReadOnly = True
        '
        'Column21
        '
        Me.Column21.HeaderText = "Destino"
        Me.Column21.Name = "Column21"
        Me.Column21.ReadOnly = True
        '
        'Column22
        '
        Me.Column22.HeaderText = "Rep."
        Me.Column22.Name = "Column22"
        Me.Column22.ReadOnly = True
        Me.Column22.Width = 30
        '
        'Column23
        '
        Me.Column23.HeaderText = "Cod_Act."
        Me.Column23.Name = "Column23"
        Me.Column23.ReadOnly = True
        Me.Column23.Width = 50
        '
        'Column29
        '
        Me.Column29.HeaderText = "Mes"
        Me.Column29.Name = "Column29"
        Me.Column29.ReadOnly = True
        Me.Column29.Width = 50
        '
        'Column28
        '
        Me.Column28.HeaderText = "Año"
        Me.Column28.Name = "Column28"
        Me.Column28.ReadOnly = True
        Me.Column28.Width = 50
        '
        'ImportarPlanilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 504)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txt_Esquema)
        Me.Controls.Add(Me.txt_Campos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Abrir)
        Me.Controls.Add(Me.txt_Datos)
        Me.Controls.Add(Me.DG)
        Me.Controls.Add(Me.Btn_Cargar)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ImportarPlanilla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ImportarPlanilla"
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_Campos As System.Windows.Forms.TextBox
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents DialogOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txt_Esquema As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Cargar As System.Windows.Forms.Button
    Friend WithEvents txt_Datos As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Abrir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents ch_comp As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_aux As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_com As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo_com As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txt_nro_comp As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column28 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
