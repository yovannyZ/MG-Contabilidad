Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_PROV1
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.dgw_calculo = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CBO_O2 = New System.Windows.Forms.ComboBox
        Me.CBO_O1 = New System.Windows.Forms.ComboBox
        Me.CBO_PCTAJE = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbo_hoja = New System.Windows.Forms.ComboBox
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbo_prov = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbo_orden = New System.Windows.Forms.ComboBox
        Me.txt_pag = New System.Windows.Forms.TextBox
        Me.dtp2 = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_cancelar1 = New System.Windows.Forms.Button
        Me.dgw_importe = New System.Windows.Forms.DataGridView
        Me.stEstado = New System.Windows.Forms.StatusStrip
        Me.tspbExportar = New System.Windows.Forms.ToolStripProgressBar
        Me.tslblMensaje = New System.Windows.Forms.ToolStripStatusLabel
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column27 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column28 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column29 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column30 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column31 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column32 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column34 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column35 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column36 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column37 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column38 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column39 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column41 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column42 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column43 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column44 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gb1.SuspendLayout()
        CType(Me.dgw_calculo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgw_importe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(191, 235)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(190, 64)
        Me.gb1.TabIndex = 3
        Me.gb1.TabStop = False
        '
        'btn_archivo1
        '
        Me.btn_archivo1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo1.Location = New System.Drawing.Point(98, 19)
        Me.btn_archivo1.Name = "btn_archivo1"
        Me.btn_archivo1.Size = New System.Drawing.Size(82, 31)
        Me.btn_archivo1.TabIndex = 8
        Me.btn_archivo1.Text = "&Archivo"
        Me.btn_archivo1.UseVisualStyleBackColor = False
        '
        'btn_pantalla1
        '
        Me.btn_pantalla1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pantalla1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_pantalla1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pantalla1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla1.Location = New System.Drawing.Point(15, 19)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(77, 31)
        Me.btn_pantalla1.TabIndex = 7
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'dgw_calculo
        '
        Me.dgw_calculo.AllowUserToAddRows = False
        Me.dgw_calculo.AllowUserToDeleteRows = False
        Me.dgw_calculo.AllowUserToOrderColumns = True
        Me.dgw_calculo.AllowUserToResizeRows = False
        Me.dgw_calculo.BackgroundColor = System.Drawing.Color.White
        Me.dgw_calculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_calculo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.dgw_calculo.Location = New System.Drawing.Point(398, 235)
        Me.dgw_calculo.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgw_calculo.MultiSelect = False
        Me.dgw_calculo.Name = "dgw_calculo"
        Me.dgw_calculo.RowHeadersWidth = 25
        Me.dgw_calculo.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_calculo.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_calculo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_calculo.ShowRowErrors = False
        Me.dgw_calculo.Size = New System.Drawing.Size(115, 64)
        Me.dgw_calculo.TabIndex = 101
        Me.dgw_calculo.Visible = False
        '
        'Column1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column1.HeaderText = "Item"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 35
        '
        'Column2
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column2.HeaderText = "Calculo"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 80
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CBO_O2)
        Me.GroupBox1.Controls.Add(Me.CBO_O1)
        Me.GroupBox1.Controls.Add(Me.CBO_PCTAJE)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbo_hoja)
        Me.GroupBox1.Controls.Add(Me.cbo_año)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbo_prov)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbo_orden)
        Me.GroupBox1.Controls.Add(Me.txt_pag)
        Me.GroupBox1.Controls.Add(Me.dtp2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbo_mes)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btn_cancelar1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(39, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(474, 217)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'CBO_O2
        '
        Me.CBO_O2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_O2.FormattingEnabled = True
        Me.CBO_O2.Location = New System.Drawing.Point(359, 88)
        Me.CBO_O2.Name = "CBO_O2"
        Me.CBO_O2.Size = New System.Drawing.Size(79, 22)
        Me.CBO_O2.TabIndex = 108
        '
        'CBO_O1
        '
        Me.CBO_O1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_O1.FormattingEnabled = True
        Me.CBO_O1.Location = New System.Drawing.Point(359, 56)
        Me.CBO_O1.Name = "CBO_O1"
        Me.CBO_O1.Size = New System.Drawing.Size(79, 22)
        Me.CBO_O1.TabIndex = 107
        '
        'CBO_PCTAJE
        '
        Me.CBO_PCTAJE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_PCTAJE.FormattingEnabled = True
        Me.CBO_PCTAJE.Items.AddRange(New Object() {"18%", "19%", "ambos"})
        Me.CBO_PCTAJE.Location = New System.Drawing.Point(359, 28)
        Me.CBO_PCTAJE.Name = "CBO_PCTAJE"
        Me.CBO_PCTAJE.Size = New System.Drawing.Size(79, 22)
        Me.CBO_PCTAJE.TabIndex = 106
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(278, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 14)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "Posición B.I."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(278, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 14)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "Posición I.G.V."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(278, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 14)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "I.G.V."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 183)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 14)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "Hoja"
        '
        'cbo_hoja
        '
        Me.cbo_hoja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_hoja.FormattingEnabled = True
        Me.cbo_hoja.Items.AddRange(New Object() {"A4 ", "CONTINUO", "A3"})
        Me.cbo_hoja.Location = New System.Drawing.Point(112, 177)
        Me.cbo_hoja.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_hoja.Name = "cbo_hoja"
        Me.cbo_hoja.Size = New System.Drawing.Size(121, 22)
        Me.cbo_hoja.TabIndex = 101
        '
        'cbo_año
        '
        Me.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año.FormattingEnabled = True
        Me.cbo_año.Location = New System.Drawing.Point(112, 77)
        Me.cbo_año.Name = "cbo_año"
        Me.cbo_año.Size = New System.Drawing.Size(79, 22)
        Me.cbo_año.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 14)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "Año"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 14)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Provisiones"
        '
        'cbo_prov
        '
        Me.cbo_prov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_prov.FormattingEnabled = True
        Me.cbo_prov.Items.AddRange(New Object() {"REGISTRO COMPRAS", "REGISTRO VENTAS", "REGISTRO HONORARIOS"})
        Me.cbo_prov.Location = New System.Drawing.Point(112, 51)
        Me.cbo_prov.Name = "cbo_prov"
        Me.cbo_prov.Size = New System.Drawing.Size(135, 22)
        Me.cbo_prov.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 14)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Orden"
        '
        'cbo_orden
        '
        Me.cbo_orden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_orden.FormattingEnabled = True
        Me.cbo_orden.Items.AddRange(New Object() {"FECHA", "COMPROBANTE", "Nº DOCUMENTO"})
        Me.cbo_orden.Location = New System.Drawing.Point(112, 103)
        Me.cbo_orden.Name = "cbo_orden"
        Me.cbo_orden.Size = New System.Drawing.Size(135, 22)
        Me.cbo_orden.TabIndex = 4
        '
        'txt_pag
        '
        Me.txt_pag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pag.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pag.Location = New System.Drawing.Point(112, 129)
        Me.txt_pag.MaxLength = 30
        Me.txt_pag.Name = "txt_pag"
        Me.txt_pag.Size = New System.Drawing.Size(34, 20)
        Me.txt_pag.TabIndex = 5
        '
        'dtp2
        '
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(112, 153)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(85, 20)
        Me.dtp2.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 14)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Fecha de Emisión"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 14)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Mes"
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"INICIO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(112, 25)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(135, 22)
        Me.cbo_mes.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 14)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "Nº  Pag."
        '
        'btn_cancelar1
        '
        Me.btn_cancelar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btn_cancelar1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar1.Location = New System.Drawing.Point(359, 166)
        Me.btn_cancelar1.Name = "btn_cancelar1"
        Me.btn_cancelar1.Size = New System.Drawing.Size(77, 31)
        Me.btn_cancelar1.TabIndex = 100
        Me.btn_cancelar1.TabStop = False
        Me.btn_cancelar1.Text = "&Salir"
        Me.btn_cancelar1.UseVisualStyleBackColor = True
        '
        'dgw_importe
        '
        Me.dgw_importe.AllowUserToAddRows = False
        Me.dgw_importe.AllowUserToDeleteRows = False
        Me.dgw_importe.AllowUserToOrderColumns = True
        Me.dgw_importe.AllowUserToResizeRows = False
        Me.dgw_importe.BackgroundColor = System.Drawing.Color.White
        Me.dgw_importe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_importe.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column20, Me.Column9, Me.Column21, Me.Column22, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column23, Me.Column24, Me.Column25, Me.Column3, Me.Column4, Me.Column26, Me.Column27, Me.Column28, Me.Column29, Me.Column30, Me.Column31, Me.Column32, Me.Column33, Me.Column34, Me.Column35, Me.Column36, Me.Column37, Me.Column38, Me.Column39, Me.Column40, Me.Column41, Me.Column42, Me.Column43, Me.Column44})
        Me.dgw_importe.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.dgw_importe.Location = New System.Drawing.Point(36, 235)
        Me.dgw_importe.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgw_importe.MultiSelect = False
        Me.dgw_importe.Name = "dgw_importe"
        Me.dgw_importe.RowHeadersWidth = 25
        Me.dgw_importe.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_importe.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_importe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_importe.ShowRowErrors = False
        Me.dgw_importe.Size = New System.Drawing.Size(149, 64)
        Me.dgw_importe.TabIndex = 102
        Me.dgw_importe.Visible = False
        '
        'stEstado
        '
        Me.stEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspbExportar, Me.tslblMensaje})
        Me.stEstado.Location = New System.Drawing.Point(0, 305)
        Me.stEstado.Name = "stEstado"
        Me.stEstado.Size = New System.Drawing.Size(535, 22)
        Me.stEstado.TabIndex = 147
        Me.stEstado.Text = "StatusStrip1"
        Me.stEstado.Visible = False
        '
        'tspbExportar
        '
        Me.tspbExportar.Name = "tspbExportar"
        Me.tspbExportar.Size = New System.Drawing.Size(100, 16)
        Me.tspbExportar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'tslblMensaje
        '
        Me.tslblMensaje.Name = "tslblMensaje"
        Me.tslblMensaje.Size = New System.Drawing.Size(99, 17)
        Me.tslblMensaje.Text = "Generando Archivo"
        '
        'Column10
        '
        Me.Column10.HeaderText = "c.com"
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 55
        '
        'Column11
        '
        Me.Column11.HeaderText = "Nº com"
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 55
        '
        'Column12
        '
        Me.Column12.HeaderText = "c.doc-nºdoc"
        Me.Column12.Name = "Column12"
        '
        'Column13
        '
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Column13.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column13.HeaderText = "fecha_doc"
        Me.Column13.Name = "Column13"
        Me.Column13.Width = 70
        '
        'Column14
        '
        DataGridViewCellStyle4.Format = "d"
        Me.Column14.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column14.HeaderText = "fecha_ven"
        Me.Column14.Name = "Column14"
        Me.Column14.Width = 70
        '
        'Column15
        '
        Me.Column15.HeaderText = "Nº doc per"
        Me.Column15.Name = "Column15"
        Me.Column15.Width = 85
        '
        'Column16
        '
        Me.Column16.HeaderText = "desc_prov"
        Me.Column16.Name = "Column16"
        '
        'Column17
        '
        Me.Column17.HeaderText = "cod_ref"
        Me.Column17.Name = "Column17"
        Me.Column17.Width = 50
        '
        'Column18
        '
        Me.Column18.HeaderText = "nro_ref"
        Me.Column18.Name = "Column18"
        Me.Column18.Width = 60
        '
        'Column19
        '
        Me.Column19.HeaderText = "tc"
        Me.Column19.Name = "Column19"
        Me.Column19.Width = 30
        '
        'Column20
        '
        Me.Column20.HeaderText = "cod_per"
        Me.Column20.Name = "Column20"
        Me.Column20.Width = 30
        '
        'Column9
        '
        Me.Column9.HeaderText = "c.doc"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 30
        '
        'Column21
        '
        Me.Column21.HeaderText = "des_doc"
        Me.Column21.Name = "Column21"
        Me.Column21.Width = 50
        '
        'Column22
        '
        Me.Column22.HeaderText = "mon"
        Me.Column22.Name = "Column22"
        Me.Column22.Width = 35
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn2.HeaderText = "1"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 45
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn3.HeaderText = "2"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 45
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn4.HeaderText = "3"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 45
        '
        'Column5
        '
        Me.Column5.HeaderText = "4"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 45
        '
        'Column6
        '
        Me.Column6.HeaderText = "5"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 45
        '
        'Column7
        '
        Me.Column7.HeaderText = "6"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 45
        '
        'Column8
        '
        Me.Column8.HeaderText = "7"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 45
        '
        'Column23
        '
        Me.Column23.HeaderText = "8"
        Me.Column23.Name = "Column23"
        Me.Column23.Width = 45
        '
        'Column24
        '
        Me.Column24.HeaderText = "9"
        Me.Column24.Name = "Column24"
        Me.Column24.Width = 45
        '
        'Column25
        '
        Me.Column25.HeaderText = "10"
        Me.Column25.Name = "Column25"
        Me.Column25.Width = 45
        '
        'Column3
        '
        Me.Column3.HeaderText = "R1"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 45
        '
        'Column4
        '
        Me.Column4.HeaderText = "R2"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 45
        '
        'Column26
        '
        Me.Column26.HeaderText = "R3"
        Me.Column26.Name = "Column26"
        Me.Column26.Width = 45
        '
        'Column27
        '
        Me.Column27.HeaderText = "R4"
        Me.Column27.Name = "Column27"
        Me.Column27.Width = 45
        '
        'Column28
        '
        Me.Column28.HeaderText = "R5"
        Me.Column28.Name = "Column28"
        Me.Column28.Width = 45
        '
        'Column29
        '
        Me.Column29.HeaderText = "R6"
        Me.Column29.Name = "Column29"
        Me.Column29.Width = 45
        '
        'Column30
        '
        Me.Column30.HeaderText = "R7"
        Me.Column30.Name = "Column30"
        Me.Column30.Width = 45
        '
        'Column31
        '
        Me.Column31.HeaderText = "R8"
        Me.Column31.Name = "Column31"
        Me.Column31.Width = 45
        '
        'Column32
        '
        Me.Column32.HeaderText = "S1"
        Me.Column32.Name = "Column32"
        Me.Column32.Width = 40
        '
        'Column33
        '
        Me.Column33.HeaderText = "S2"
        Me.Column33.Name = "Column33"
        Me.Column33.Width = 40
        '
        'Column34
        '
        Me.Column34.HeaderText = "S3"
        Me.Column34.Name = "Column34"
        Me.Column34.Width = 40
        '
        'Column35
        '
        Me.Column35.HeaderText = "S4"
        Me.Column35.Name = "Column35"
        Me.Column35.Width = 40
        '
        'Column36
        '
        Me.Column36.HeaderText = "S5"
        Me.Column36.Name = "Column36"
        Me.Column36.Width = 40
        '
        'Column37
        '
        DataGridViewCellStyle8.Format = "n2"
        Me.Column37.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column37.HeaderText = "S6"
        Me.Column37.Name = "Column37"
        Me.Column37.Width = 40
        '
        'Column38
        '
        Me.Column38.HeaderText = "S7"
        Me.Column38.Name = "Column38"
        Me.Column38.Width = 40
        '
        'Column39
        '
        Me.Column39.HeaderText = "S8"
        Me.Column39.Name = "Column39"
        Me.Column39.Width = 40
        '
        'Column40
        '
        Me.Column40.HeaderText = "SERIE"
        Me.Column40.Name = "Column40"
        '
        'Column41
        '
        Me.Column41.HeaderText = "FECHA_REF"
        Me.Column41.Name = "Column41"
        '
        'Column42
        '
        DataGridViewCellStyle9.NullValue = Nothing
        Me.Column42.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column42.HeaderText = "DIVISION"
        Me.Column42.Name = "Column42"
        '
        'Column43
        '
        Me.Column43.HeaderText = "IMPORTE_HON"
        Me.Column43.Name = "Column43"
        '
        'Column44
        '
        Me.Column44.HeaderText = "COD_TIP_DOC"
        Me.Column44.Name = "Column44"
        '
        'REPORTE_PROV1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 327)
        Me.ControlBox = False
        Me.Controls.Add(Me.stEstado)
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.dgw_calculo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgw_importe)
        Me.Name = "REPORTE_PROV1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Provisiones"
        Me.gb1.ResumeLayout(False)
        CType(Me.dgw_calculo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgw_importe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stEstado.ResumeLayout(False)
        Me.stEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_cancelar1 As Button
    Friend WithEvents btn_pantalla1 As Button
    Friend WithEvents cbo_mes As ComboBox
    Friend WithEvents cbo_orden As ComboBox
    Friend WithEvents cbo_prov As ComboBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents dgw_calculo As DataGridView
    Friend WithEvents dgw_importe As DataGridView
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_pag As TextBox
    Friend WithEvents cbo_año As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_hoja As System.Windows.Forms.ComboBox
    Friend WithEvents CBO_O2 As System.Windows.Forms.ComboBox
    Friend WithEvents CBO_O1 As System.Windows.Forms.ComboBox
    Friend WithEvents CBO_PCTAJE As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_archivo1 As System.Windows.Forms.Button
    Friend WithEvents stEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tspbExportar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tslblMensaje As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column37 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column39 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column41 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column42 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column43 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column44 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
