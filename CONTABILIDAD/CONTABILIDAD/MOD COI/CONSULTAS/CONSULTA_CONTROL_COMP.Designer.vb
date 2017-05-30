<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CONSULTA_CONTROL_COMP
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_consultar = New System.Windows.Forms.Button
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbo_auxiliar = New System.Windows.Forms.ComboBox
        Me.cbo_comprobante = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.numInicio = New System.Windows.Forms.NumericUpDown
        Me.numFin = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnIngresarFile = New System.Windows.Forms.Button
        Me.txtNrofile = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkTodos = New System.Windows.Forms.CheckBox
        Me.dgw2 = New System.Windows.Forms.DataGridView
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgw2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_consultar)
        Me.GroupBox2.Controls.Add(Me.cbo_año)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cbo_auxiliar)
        Me.GroupBox2.Controls.Add(Me.cbo_comprobante)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cbo_mes)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(62, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(578, 77)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Consulta"
        '
        'btn_consultar
        '
        Me.btn_consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_consultar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Search_1
        Me.btn_consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consultar.Location = New System.Drawing.Point(473, 22)
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(99, 31)
        Me.btn_consultar.TabIndex = 4
        Me.btn_consultar.Text = "&Consultar"
        Me.btn_consultar.UseVisualStyleBackColor = True
        '
        'cbo_año
        '
        Me.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_año.FormattingEnabled = True
        Me.cbo_año.Location = New System.Drawing.Point(353, 22)
        Me.cbo_año.Name = "cbo_año"
        Me.cbo_año.Size = New System.Drawing.Size(79, 22)
        Me.cbo_año.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(320, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 14)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Año"
        '
        'cbo_auxiliar
        '
        Me.cbo_auxiliar.BackColor = System.Drawing.Color.White
        Me.cbo_auxiliar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_auxiliar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_auxiliar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_auxiliar.FormattingEnabled = True
        Me.cbo_auxiliar.Location = New System.Drawing.Point(111, 22)
        Me.cbo_auxiliar.MaxDropDownItems = 9
        Me.cbo_auxiliar.Name = "cbo_auxiliar"
        Me.cbo_auxiliar.Size = New System.Drawing.Size(176, 22)
        Me.cbo_auxiliar.TabIndex = 0
        '
        'cbo_comprobante
        '
        Me.cbo_comprobante.BackColor = System.Drawing.Color.White
        Me.cbo_comprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_comprobante.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_comprobante.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_comprobante.FormattingEnabled = True
        Me.cbo_comprobante.Location = New System.Drawing.Point(111, 44)
        Me.cbo_comprobante.MaxDropDownItems = 10
        Me.cbo_comprobante.Name = "cbo_comprobante"
        Me.cbo_comprobante.Size = New System.Drawing.Size(176, 22)
        Me.cbo_comprobante.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 14)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Auxiliar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 14)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Comprobante"
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"INICIO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(353, 44)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(99, 22)
        Me.cbo_mes.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(320, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 14)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Mes"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.Location = New System.Drawing.Point(661, 601)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(70, 31)
        Me.btn_cancelar.TabIndex = 25
        Me.btn_cancelar.Text = "&Salir"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AllowUserToOrderColumns = True
        Me.dgw1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dgw1.Location = New System.Drawing.Point(15, 132)
        Me.dgw1.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.RowHeadersWidth = 25
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw1.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(719, 335)
        Me.dgw1.TabIndex = 21
        '
        'Item
        '
        Me.Item.HeaderText = "Item"
        Me.Item.Name = "Item"
        Me.Item.ReadOnly = True
        Me.Item.Width = 40
        '
        'Column1
        '
        Me.Column1.HeaderText = "Nro File"
        Me.Column1.MaxInputLength = 4
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 70
        '
        'Column2
        '
        Me.Column2.HeaderText = "Nro. Comp."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 70
        '
        'Column3
        '
        Me.Column3.HeaderText = "OK"
        Me.Column3.Name = "Column3"
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column3.Width = 50
        '
        'Column4
        '
        Me.Column4.HeaderText = "Observación"
        Me.Column4.MaxInputLength = 50
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 250
        '
        'Column5
        '
        Me.Column5.HeaderText = "Motivo de Observación"
        Me.Column5.MaxInputLength = 50
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 250
        '
        'btnGrabar
        '
        Me.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrabar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrabar.Location = New System.Drawing.Point(577, 601)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(78, 31)
        Me.btnGrabar.TabIndex = 27
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'numInicio
        '
        Me.numInicio.Location = New System.Drawing.Point(92, 99)
        Me.numInicio.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numInicio.Name = "numInicio"
        Me.numInicio.Size = New System.Drawing.Size(42, 20)
        Me.numInicio.TabIndex = 28
        Me.numInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numFin
        '
        Me.numFin.Location = New System.Drawing.Point(180, 99)
        Me.numFin.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numFin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numFin.Name = "numFin"
        Me.numFin.Size = New System.Drawing.Size(42, 20)
        Me.numFin.TabIndex = 29
        Me.numFin.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(65, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 14)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "De:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(142, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 14)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Hasta"
        '
        'btnIngresarFile
        '
        Me.btnIngresarFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIngresarFile.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Ok_1
        Me.btnIngresarFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIngresarFile.Location = New System.Drawing.Point(355, 95)
        Me.btnIngresarFile.Name = "btnIngresarFile"
        Me.btnIngresarFile.Size = New System.Drawing.Size(121, 26)
        Me.btnIngresarFile.TabIndex = 33
        Me.btnIngresarFile.Text = "&Ingresar Nro. File"
        Me.btnIngresarFile.UseVisualStyleBackColor = True
        '
        'txtNrofile
        '
        Me.txtNrofile.Location = New System.Drawing.Point(277, 99)
        Me.txtNrofile.MaxLength = 4
        Me.txtNrofile.Name = "txtNrofile"
        Me.txtNrofile.Size = New System.Drawing.Size(70, 20)
        Me.txtNrofile.TabIndex = 34
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(228, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 14)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Nro. File"
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Enabled = False
        Me.chkTodos.Location = New System.Drawing.Point(653, 112)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(78, 17)
        Me.chkTodos.TabIndex = 36
        Me.chkTodos.Text = "Ok a todos"
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'dgw2
        '
        Me.dgw2.AllowUserToAddRows = False
        Me.dgw2.AllowUserToDeleteRows = False
        Me.dgw2.AllowUserToOrderColumns = True
        Me.dgw2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgw2.BackgroundColor = System.Drawing.Color.White
        Me.dgw2.Location = New System.Drawing.Point(15, 478)
        Me.dgw2.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw2.MultiSelect = False
        Me.dgw2.Name = "dgw2"
        Me.dgw2.ReadOnly = True
        Me.dgw2.RowHeadersWidth = 25
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw2.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgw2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw2.Size = New System.Drawing.Size(719, 120)
        Me.dgw2.TabIndex = 37
        '
        'CONSULTA_CONTROL_COMP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(751, 639)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgw2)
        Me.Controls.Add(Me.chkTodos)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtNrofile)
        Me.Controls.Add(Me.btnIngresarFile)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.numFin)
        Me.Controls.Add(Me.numInicio)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.dgw1)
        Me.Controls.Add(Me.GroupBox2)
        Me.KeyPreview = True
        Me.Name = "CONSULTA_CONTROL_COMP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Comprobantes"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgw2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_año As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents cbo_auxiliar As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_comprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_consultar As System.Windows.Forms.Button
    Friend WithEvents dgw1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents numInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents numFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnIngresarFile As System.Windows.Forms.Button
    Friend WithEvents txtNrofile As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgw2 As System.Windows.Forms.DataGridView
End Class
