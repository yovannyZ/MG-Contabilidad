<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFlujoEfectivoDirecta
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFlujoEfectivoDirecta))
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tcFlujoEfectivo = New System.Windows.Forms.TabControl
        Me.tpGeneracion = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkTodos = New System.Windows.Forms.CheckBox
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnConsulta = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.cbo_auxiliar = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.tgvComprobantes = New AdvancedDataGridView.TreeGridView
        Me.Column1 = New AdvancedDataGridView.TreeGridColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewCheckBoxColumn
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
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tpActualizacion = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.tgvFlujoEfectivo = New AdvancedDataGridView.TreeGridView
        Me.cmsGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuCopiar = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMover = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.ExpandirTodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContraerTodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnSalir1 = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.btnConsulta1 = New System.Windows.Forms.Button
        Me.cboMes1 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.tgvFlujoEfectivoMensual = New AdvancedDataGridView.TreeGridView
        Me.Column39 = New AdvancedDataGridView.TreeGridColumn
        Me.Column40 = New AdvancedDataGridView.TreeGridColumn
        Me.Column41 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column42 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnActualizarAcumulado = New System.Windows.Forms.Button
        Me.btnPantalla = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.tgvFlujoEfectivoAcumulado = New AdvancedDataGridView.TreeGridView
        Me.Column43 = New AdvancedDataGridView.TreeGridColumn
        Me.Column44 = New AdvancedDataGridView.TreeGridColumn
        Me.Column45 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column46 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.btnSaldoInicial = New System.Windows.Forms.Button
        Me.btnPantalla1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Column37 = New AdvancedDataGridView.TreeGridColumn
        Me.Column38 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column29 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column30 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column31 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column32 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column34 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column35 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column36 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column27 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column28 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column47 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.tcFlujoEfectivo.SuspendLayout()
        Me.tpGeneracion.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.tgvComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpActualizacion.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.tgvFlujoEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsGrid.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.tgvFlujoEfectivoMensual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.tgvFlujoEfectivoAcumulado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcFlujoEfectivo
        '
        Me.tcFlujoEfectivo.Controls.Add(Me.tpGeneracion)
        Me.tcFlujoEfectivo.Controls.Add(Me.tpActualizacion)
        Me.tcFlujoEfectivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcFlujoEfectivo.Location = New System.Drawing.Point(0, 0)
        Me.tcFlujoEfectivo.Name = "tcFlujoEfectivo"
        Me.tcFlujoEfectivo.SelectedIndex = 0
        Me.tcFlujoEfectivo.Size = New System.Drawing.Size(1246, 691)
        Me.tcFlujoEfectivo.TabIndex = 1
        '
        'tpGeneracion
        '
        Me.tpGeneracion.Controls.Add(Me.GroupBox1)
        Me.tpGeneracion.Controls.Add(Me.GroupBox2)
        Me.tpGeneracion.Controls.Add(Me.tgvComprobantes)
        Me.tpGeneracion.Location = New System.Drawing.Point(4, 23)
        Me.tpGeneracion.Name = "tpGeneracion"
        Me.tpGeneracion.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGeneracion.Size = New System.Drawing.Size(1083, 664)
        Me.tpGeneracion.TabIndex = 0
        Me.tpGeneracion.Text = "Generación"
        Me.tpGeneracion.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkTodos)
        Me.GroupBox1.Controls.Add(Me.btnGenerar)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(385, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(373, 94)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Generar"
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Location = New System.Drawing.Point(6, 27)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(127, 18)
        Me.chkTodos.TabIndex = 29
        Me.chkTodos.Text = "Seleccionar Todos"
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'btnGenerar
        '
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.Location = New System.Drawing.Point(139, 15)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(77, 29)
        Me.btnGenerar.TabIndex = 8
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnConsulta)
        Me.GroupBox2.Controls.Add(Me.btnSalir)
        Me.GroupBox2.Controls.Add(Me.cbo_auxiliar)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cbo_mes)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(373, 94)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Consulta"
        '
        'btnConsulta
        '
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsulta.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Search_1
        Me.btnConsulta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsulta.Location = New System.Drawing.Point(287, 12)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(77, 29)
        Me.btnConsulta.TabIndex = 8
        Me.btnConsulta.Text = "&Consulta"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.Location = New System.Drawing.Point(287, 44)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(77, 30)
        Me.btnSalir.TabIndex = 9
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'cbo_auxiliar
        '
        Me.cbo_auxiliar.BackColor = System.Drawing.Color.White
        Me.cbo_auxiliar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_auxiliar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_auxiliar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_auxiliar.FormattingEnabled = True
        Me.cbo_auxiliar.Location = New System.Drawing.Point(67, 19)
        Me.cbo_auxiliar.MaxDropDownItems = 9
        Me.cbo_auxiliar.Name = "cbo_auxiliar"
        Me.cbo_auxiliar.Size = New System.Drawing.Size(176, 22)
        Me.cbo_auxiliar.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(18, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 14)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Auxiliar"
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(67, 47)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(176, 22)
        Me.cbo_mes.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(18, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 14)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Mes"
        '
        'tgvComprobantes
        '
        Me.tgvComprobantes.AllowUserToAddRows = False
        Me.tgvComprobantes.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.tgvComprobantes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.tgvComprobantes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgvComprobantes.BackgroundColor = System.Drawing.Color.White
        Me.tgvComprobantes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.tgvComprobantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column20, Me.Column21, Me.Column22})
        Me.tgvComprobantes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.tgvComprobantes.ImageList = Nothing
        Me.tgvComprobantes.Location = New System.Drawing.Point(6, 106)
        Me.tgvComprobantes.Name = "tgvComprobantes"
        Me.tgvComprobantes.RowHeadersVisible = False
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Blue
        Me.tgvComprobantes.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.tgvComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tgvComprobantes.Size = New System.Drawing.Size(853, 423)
        Me.tgvComprobantes.TabIndex = 22
        '
        'Column1
        '
        Me.Column1.DefaultNodeImage = Nothing
        Me.Column1.HeaderText = "Aux."
        Me.Column1.Name = "Column1"
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.HeaderText = "Comp."
        Me.Column2.Name = "Column2"
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 40
        '
        'Column3
        '
        Me.Column3.HeaderText = "N° Comp."
        Me.Column3.Name = "Column3"
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 60
        '
        'Column4
        '
        DataGridViewCellStyle2.Format = "d"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.HeaderText = "Fec. Comp."
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 65
        '
        'Column5
        '
        Me.Column5.HeaderText = "Cuenta"
        Me.Column5.Name = "Column5"
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column5.Width = 70
        '
        'Column6
        '
        Me.Column6.HeaderText = "Cod. Usuario"
        Me.Column6.Name = "Column6"
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column6.Visible = False
        '
        'Column7
        '
        Me.Column7.HeaderText = "Glosa"
        Me.Column7.Name = "Column7"
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column7.Width = 220
        '
        'Column8
        '
        Me.Column8.HeaderText = "Ok"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 30
        '
        'Column9
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column9.HeaderText = "S/.Debe"
        Me.Column9.Name = "Column9"
        Me.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column9.Width = 70
        '
        'Column10
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column10.HeaderText = "S/.Haber"
        Me.Column10.Name = "Column10"
        Me.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column10.Width = 70
        '
        'Column11
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.Column11.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column11.HeaderText = "$Debe"
        Me.Column11.Name = "Column11"
        Me.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column11.Width = 70
        '
        'Column12
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Me.Column12.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column12.HeaderText = "$Haber"
        Me.Column12.Name = "Column12"
        Me.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column12.Width = 70
        '
        'Column13
        '
        Me.Column13.HeaderText = "Mon."
        Me.Column13.Name = "Column13"
        Me.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column13.Width = 30
        '
        'Column14
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N4"
        Me.Column14.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column14.HeaderText = "T.C."
        Me.Column14.Name = "Column14"
        Me.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column14.Width = 60
        '
        'Column15
        '
        Me.Column15.HeaderText = "Cod."
        Me.Column15.Name = "Column15"
        Me.Column15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column15.Width = 30
        '
        'Column16
        '
        Me.Column16.HeaderText = "N° Doc."
        Me.Column16.Name = "Column16"
        Me.Column16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column17
        '
        DataGridViewCellStyle8.Format = "d"
        Me.Column17.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column17.HeaderText = "Fec. Doc."
        Me.Column17.Name = "Column17"
        Me.Column17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column17.Width = 65
        '
        'Column18
        '
        Me.Column18.HeaderText = "C. Cte."
        Me.Column18.Name = "Column18"
        Me.Column18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column18.Width = 45
        '
        'Column19
        '
        Me.Column19.HeaderText = "D/H"
        Me.Column19.Name = "Column19"
        Me.Column19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column19.Width = 30
        '
        'Column20
        '
        Me.Column20.HeaderText = "Desc. Cuenta"
        Me.Column20.Name = "Column20"
        Me.Column20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column20.Visible = False
        Me.Column20.Width = 220
        '
        'Column21
        '
        Me.Column21.HeaderText = "Cod. Cpto."
        Me.Column21.Name = "Column21"
        Me.Column21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column21.Width = 50
        '
        'Column22
        '
        Me.Column22.HeaderText = "Concepto"
        Me.Column22.Name = "Column22"
        Me.Column22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column22.Width = 200
        '
        'tpActualizacion
        '
        Me.tpActualizacion.Controls.Add(Me.SplitContainer1)
        Me.tpActualizacion.Location = New System.Drawing.Point(4, 23)
        Me.tpActualizacion.Name = "tpActualizacion"
        Me.tpActualizacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tpActualizacion.Size = New System.Drawing.Size(1238, 664)
        Me.tpActualizacion.TabIndex = 1
        Me.tpActualizacion.Text = "Actualización"
        Me.tpActualizacion.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tgvFlujoEfectivo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox5)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1232, 658)
        Me.SplitContainer1.SplitterDistance = 819
        Me.SplitContainer1.SplitterWidth = 10
        Me.SplitContainer1.TabIndex = 35
        '
        'tgvFlujoEfectivo
        '
        Me.tgvFlujoEfectivo.AllowUserToAddRows = False
        Me.tgvFlujoEfectivo.AllowUserToDeleteRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Blue
        Me.tgvFlujoEfectivo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.tgvFlujoEfectivo.BackgroundColor = System.Drawing.Color.White
        Me.tgvFlujoEfectivo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.tgvFlujoEfectivo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column37, Me.Column38, Me.Column29, Me.Column30, Me.Column31, Me.Column32, Me.Column33, Me.Column34, Me.Column35, Me.Column36, Me.Column23, Me.Column24, Me.Column25, Me.Column26, Me.Column27, Me.Column28, Me.Column47})
        Me.tgvFlujoEfectivo.ContextMenuStrip = Me.cmsGrid
        Me.tgvFlujoEfectivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tgvFlujoEfectivo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.tgvFlujoEfectivo.ImageList = Nothing
        Me.tgvFlujoEfectivo.Location = New System.Drawing.Point(0, 80)
        Me.tgvFlujoEfectivo.MultiSelect = False
        Me.tgvFlujoEfectivo.Name = "tgvFlujoEfectivo"
        Me.tgvFlujoEfectivo.RowHeadersVisible = False
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Blue
        Me.tgvFlujoEfectivo.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.tgvFlujoEfectivo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tgvFlujoEfectivo.Size = New System.Drawing.Size(819, 522)
        Me.tgvFlujoEfectivo.TabIndex = 30
        '
        'cmsGrid
        '
        Me.cmsGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCopiar, Me.mnuMover, Me.mnuEliminar, Me.ToolStripMenuItem1, Me.ExpandirTodoToolStripMenuItem, Me.ContraerTodoToolStripMenuItem})
        Me.cmsGrid.Name = "cmsGrid"
        Me.cmsGrid.Size = New System.Drawing.Size(151, 120)
        '
        'mnuCopiar
        '
        Me.mnuCopiar.Image = CType(resources.GetObject("mnuCopiar.Image"), System.Drawing.Image)
        Me.mnuCopiar.Name = "mnuCopiar"
        Me.mnuCopiar.Size = New System.Drawing.Size(150, 22)
        Me.mnuCopiar.Text = "Duplicar"
        '
        'mnuMover
        '
        Me.mnuMover.Name = "mnuMover"
        Me.mnuMover.Size = New System.Drawing.Size(150, 22)
        Me.mnuMover.Text = "Mover"
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.mnuEliminar.Name = "mnuEliminar"
        Me.mnuEliminar.Size = New System.Drawing.Size(150, 22)
        Me.mnuEliminar.Text = "Eliminar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(147, 6)
        '
        'ExpandirTodoToolStripMenuItem
        '
        Me.ExpandirTodoToolStripMenuItem.Image = Global.CONTABILIDAD.My.Resources.Resources.expand
        Me.ExpandirTodoToolStripMenuItem.Name = "ExpandirTodoToolStripMenuItem"
        Me.ExpandirTodoToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ExpandirTodoToolStripMenuItem.Text = "Expandir Todo"
        '
        'ContraerTodoToolStripMenuItem
        '
        Me.ContraerTodoToolStripMenuItem.Image = Global.CONTABILIDAD.My.Resources.Resources.collapse
        Me.ContraerTodoToolStripMenuItem.Name = "ContraerTodoToolStripMenuItem"
        Me.ContraerTodoToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ContraerTodoToolStripMenuItem.Text = "Contraer todo"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnSalir1)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(0, 602)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(819, 56)
        Me.GroupBox4.TabIndex = 33
        Me.GroupBox4.TabStop = False
        '
        'btnSalir1
        '
        Me.btnSalir1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btnSalir1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir1.Location = New System.Drawing.Point(576, 19)
        Me.btnSalir1.Name = "btnSalir1"
        Me.btnSalir1.Size = New System.Drawing.Size(77, 31)
        Me.btnSalir1.TabIndex = 9
        Me.btnSalir1.Text = "&Salir"
        Me.btnSalir1.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnConsulta1)
        Me.GroupBox5.Controls.Add(Me.cboMes1)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(819, 80)
        Me.GroupBox5.TabIndex = 32
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Consulta"
        '
        'btnConsulta1
        '
        Me.btnConsulta1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsulta1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Search_1
        Me.btnConsulta1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsulta1.Location = New System.Drawing.Point(270, 18)
        Me.btnConsulta1.Name = "btnConsulta1"
        Me.btnConsulta1.Size = New System.Drawing.Size(77, 29)
        Me.btnConsulta1.TabIndex = 8
        Me.btnConsulta1.Text = "&Consulta"
        Me.btnConsulta1.UseVisualStyleBackColor = True
        '
        'cboMes1
        '
        Me.cboMes1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMes1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMes1.FormattingEnabled = True
        Me.cboMes1.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboMes1.Location = New System.Drawing.Point(65, 22)
        Me.cboMes1.Name = "cboMes1"
        Me.cboMes1.Size = New System.Drawing.Size(176, 22)
        Me.cboMes1.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 14)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Mes"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 32)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(403, 626)
        Me.TabControl1.TabIndex = 37
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tgvFlujoEfectivoMensual)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(395, 599)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Flujo Mensual"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tgvFlujoEfectivoMensual
        '
        Me.tgvFlujoEfectivoMensual.AllowUserToAddRows = False
        Me.tgvFlujoEfectivoMensual.AllowUserToDeleteRows = False
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Blue
        Me.tgvFlujoEfectivoMensual.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle16
        Me.tgvFlujoEfectivoMensual.BackgroundColor = System.Drawing.Color.White
        Me.tgvFlujoEfectivoMensual.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.tgvFlujoEfectivoMensual.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column39, Me.Column40, Me.Column41, Me.Column42})
        Me.tgvFlujoEfectivoMensual.ContextMenuStrip = Me.cmsGrid
        Me.tgvFlujoEfectivoMensual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tgvFlujoEfectivoMensual.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.tgvFlujoEfectivoMensual.ImageList = Nothing
        Me.tgvFlujoEfectivoMensual.Location = New System.Drawing.Point(3, 3)
        Me.tgvFlujoEfectivoMensual.Name = "tgvFlujoEfectivoMensual"
        Me.tgvFlujoEfectivoMensual.RowHeadersVisible = False
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Blue
        Me.tgvFlujoEfectivoMensual.RowsDefaultCellStyle = DataGridViewCellStyle18
        Me.tgvFlujoEfectivoMensual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tgvFlujoEfectivoMensual.Size = New System.Drawing.Size(389, 537)
        Me.tgvFlujoEfectivoMensual.TabIndex = 34
        '
        'Column39
        '
        Me.Column39.DefaultNodeImage = Nothing
        Me.Column39.HeaderText = "Codigo"
        Me.Column39.Name = "Column39"
        Me.Column39.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column39.Visible = False
        Me.Column39.Width = 90
        '
        'Column40
        '
        Me.Column40.DefaultNodeImage = Nothing
        Me.Column40.HeaderText = "Descripción"
        Me.Column40.Name = "Column40"
        Me.Column40.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column40.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column40.Width = 280
        '
        'Column41
        '
        Me.Column41.HeaderText = "Nivel"
        Me.Column41.Name = "Column41"
        Me.Column41.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column41.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column41.Visible = False
        Me.Column41.Width = 30
        '
        'Column42
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "N2"
        Me.Column42.DefaultCellStyle = DataGridViewCellStyle17
        Me.Column42.HeaderText = "Importe"
        Me.Column42.Name = "Column42"
        Me.Column42.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column42.Width = 90
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnActualizarAcumulado)
        Me.GroupBox3.Controls.Add(Me.btnPantalla)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(3, 540)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(389, 56)
        Me.GroupBox3.TabIndex = 37
        Me.GroupBox3.TabStop = False
        '
        'btnActualizarAcumulado
        '
        Me.btnActualizarAcumulado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizarAcumulado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizarAcumulado.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btnActualizarAcumulado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActualizarAcumulado.Location = New System.Drawing.Point(221, 19)
        Me.btnActualizarAcumulado.Name = "btnActualizarAcumulado"
        Me.btnActualizarAcumulado.Size = New System.Drawing.Size(102, 31)
        Me.btnActualizarAcumulado.TabIndex = 10
        Me.btnActualizarAcumulado.Text = "&Acumulado"
        Me.btnActualizarAcumulado.UseVisualStyleBackColor = True
        '
        'btnPantalla
        '
        Me.btnPantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPantalla.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btnPantalla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPantalla.Location = New System.Drawing.Point(113, 19)
        Me.btnPantalla.Name = "btnPantalla"
        Me.btnPantalla.Size = New System.Drawing.Size(102, 31)
        Me.btnPantalla.TabIndex = 3
        Me.btnPantalla.Text = "&Pantalla"
        Me.btnPantalla.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.tgvFlujoEfectivoAcumulado)
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(400, 600)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Flujo Acumulado"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'tgvFlujoEfectivoAcumulado
        '
        Me.tgvFlujoEfectivoAcumulado.AllowUserToAddRows = False
        Me.tgvFlujoEfectivoAcumulado.AllowUserToDeleteRows = False
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Blue
        Me.tgvFlujoEfectivoAcumulado.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle19
        Me.tgvFlujoEfectivoAcumulado.BackgroundColor = System.Drawing.Color.White
        Me.tgvFlujoEfectivoAcumulado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.tgvFlujoEfectivoAcumulado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column43, Me.Column44, Me.Column45, Me.Column46})
        Me.tgvFlujoEfectivoAcumulado.ContextMenuStrip = Me.cmsGrid
        Me.tgvFlujoEfectivoAcumulado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tgvFlujoEfectivoAcumulado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.tgvFlujoEfectivoAcumulado.ImageList = Nothing
        Me.tgvFlujoEfectivoAcumulado.Location = New System.Drawing.Point(3, 3)
        Me.tgvFlujoEfectivoAcumulado.Name = "tgvFlujoEfectivoAcumulado"
        Me.tgvFlujoEfectivoAcumulado.RowHeadersVisible = False
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Blue
        Me.tgvFlujoEfectivoAcumulado.RowsDefaultCellStyle = DataGridViewCellStyle21
        Me.tgvFlujoEfectivoAcumulado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tgvFlujoEfectivoAcumulado.Size = New System.Drawing.Size(394, 538)
        Me.tgvFlujoEfectivoAcumulado.TabIndex = 39
        '
        'Column43
        '
        Me.Column43.DefaultNodeImage = Nothing
        Me.Column43.HeaderText = "Código"
        Me.Column43.Name = "Column43"
        Me.Column43.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column43.Visible = False
        Me.Column43.Width = 90
        '
        'Column44
        '
        Me.Column44.DefaultNodeImage = Nothing
        Me.Column44.HeaderText = "Descripción"
        Me.Column44.Name = "Column44"
        Me.Column44.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column44.Width = 280
        '
        'Column45
        '
        Me.Column45.HeaderText = "Nivel"
        Me.Column45.Name = "Column45"
        Me.Column45.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column45.Visible = False
        Me.Column45.Width = 30
        '
        'Column46
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.Format = "N2"
        Me.Column46.DefaultCellStyle = DataGridViewCellStyle20
        Me.Column46.HeaderText = "Importe"
        Me.Column46.Name = "Column46"
        Me.Column46.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column46.Width = 90
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnSaldoInicial)
        Me.GroupBox6.Controls.Add(Me.btnPantalla1)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox6.Location = New System.Drawing.Point(3, 541)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(394, 56)
        Me.GroupBox6.TabIndex = 38
        Me.GroupBox6.TabStop = False
        '
        'btnSaldoInicial
        '
        Me.btnSaldoInicial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaldoInicial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaldoInicial.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Stop_2_1
        Me.btnSaldoInicial.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaldoInicial.Location = New System.Drawing.Point(221, 19)
        Me.btnSaldoInicial.Name = "btnSaldoInicial"
        Me.btnSaldoInicial.Size = New System.Drawing.Size(102, 31)
        Me.btnSaldoInicial.TabIndex = 10
        Me.btnSaldoInicial.Text = "&Saldo Inicial"
        Me.btnSaldoInicial.UseVisualStyleBackColor = True
        '
        'btnPantalla1
        '
        Me.btnPantalla1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPantalla1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPantalla1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btnPantalla1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPantalla1.Location = New System.Drawing.Point(113, 19)
        Me.btnPantalla1.Name = "btnPantalla1"
        Me.btnPantalla1.Size = New System.Drawing.Size(102, 31)
        Me.btnPantalla1.TabIndex = 3
        Me.btnPantalla1.Text = "&Pantalla"
        Me.btnPantalla1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(403, 32)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Estado de Flujos Efectivo"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Column37
        '
        Me.Column37.DefaultNodeImage = Nothing
        Me.Column37.HeaderText = "Cod. Cpto."
        Me.Column37.Name = "Column37"
        Me.Column37.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column37.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column38
        '
        Me.Column38.HeaderText = "Desc. Cpto."
        Me.Column38.Name = "Column38"
        Me.Column38.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column38.Width = 220
        '
        'Column29
        '
        Me.Column29.HeaderText = "Ok"
        Me.Column29.Name = "Column29"
        Me.Column29.Visible = False
        Me.Column29.Width = 30
        '
        'Column30
        '
        DataGridViewCellStyle11.Format = "N2"
        Me.Column30.DefaultCellStyle = DataGridViewCellStyle11
        Me.Column30.HeaderText = "S/.Importe"
        Me.Column30.Name = "Column30"
        Me.Column30.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column30.Width = 90
        '
        'Column31
        '
        Me.Column31.HeaderText = "Cod."
        Me.Column31.Name = "Column31"
        Me.Column31.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column31.Width = 30
        '
        'Column32
        '
        Me.Column32.HeaderText = "N° Doc."
        Me.Column32.Name = "Column32"
        Me.Column32.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column33
        '
        DataGridViewCellStyle12.Format = "d"
        Me.Column33.DefaultCellStyle = DataGridViewCellStyle12
        Me.Column33.HeaderText = "Fec. Doc"
        Me.Column33.Name = "Column33"
        Me.Column33.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column33.Width = 70
        '
        'Column34
        '
        Me.Column34.HeaderText = "Cta. Cte."
        Me.Column34.Name = "Column34"
        Me.Column34.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column34.Visible = False
        Me.Column34.Width = 45
        '
        'Column35
        '
        Me.Column35.HeaderText = "D/H"
        Me.Column35.Name = "Column35"
        Me.Column35.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column35.Visible = False
        Me.Column35.Width = 30
        '
        'Column36
        '
        Me.Column36.HeaderText = "Desc. Cta."
        Me.Column36.Name = "Column36"
        Me.Column36.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column36.Visible = False
        Me.Column36.Width = 220
        '
        'Column23
        '
        Me.Column23.HeaderText = "Aux."
        Me.Column23.Name = "Column23"
        Me.Column23.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column23.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column23.Width = 50
        '
        'Column24
        '
        Me.Column24.HeaderText = "Comp."
        Me.Column24.Name = "Column24"
        Me.Column24.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column24.Width = 40
        '
        'Column25
        '
        Me.Column25.HeaderText = "N° Comp."
        Me.Column25.Name = "Column25"
        Me.Column25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column25.Width = 60
        '
        'Column26
        '
        DataGridViewCellStyle13.Format = "d"
        Me.Column26.DefaultCellStyle = DataGridViewCellStyle13
        Me.Column26.HeaderText = "Fec. Comp."
        Me.Column26.Name = "Column26"
        Me.Column26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column26.Visible = False
        Me.Column26.Width = 70
        '
        'Column27
        '
        Me.Column27.HeaderText = "N"
        Me.Column27.Name = "Column27"
        Me.Column27.Visible = False
        Me.Column27.Width = 20
        '
        'Column28
        '
        Me.Column28.HeaderText = "Item"
        Me.Column28.Name = "Column28"
        Me.Column28.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column28.Width = 40
        '
        'Column47
        '
        DataGridViewCellStyle14.NullValue = False
        Me.Column47.DefaultCellStyle = DataGridViewCellStyle14
        Me.Column47.HeaderText = "M"
        Me.Column47.Name = "Column47"
        Me.Column47.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column47.Visible = False
        Me.Column47.Width = 30
        '
        'frmFlujoEfectivoDirecta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1246, 691)
        Me.Controls.Add(Me.tcFlujoEfectivo)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.Name = "frmFlujoEfectivoDirecta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generación flujo efectivo - Directa"
        Me.tcFlujoEfectivo.ResumeLayout(False)
        Me.tpGeneracion.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.tgvComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpActualizacion.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.tgvFlujoEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsGrid.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.tgvFlujoEfectivoMensual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.tgvFlujoEfectivoAcumulado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcFlujoEfectivo As System.Windows.Forms.TabControl
    Friend WithEvents tpGeneracion As System.Windows.Forms.TabPage
    Friend WithEvents tpActualizacion As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents cbo_auxiliar As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tgvComprobantes As AdvancedDataGridView.TreeGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents tgvFlujoEfectivo As AdvancedDataGridView.TreeGridView
    Friend WithEvents cmsGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuCopiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExpandirTodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContraerTodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Column1 As AdvancedDataGridView.TreeGridColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewCheckBoxColumn
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
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnuMover As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnConsulta1 As System.Windows.Forms.Button
    Friend WithEvents cboMes1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tgvFlujoEfectivoMensual As AdvancedDataGridView.TreeGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Column39 As AdvancedDataGridView.TreeGridColumn
    Friend WithEvents Column40 As AdvancedDataGridView.TreeGridColumn
    Friend WithEvents Column41 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column42 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSalir1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnActualizarAcumulado As System.Windows.Forms.Button
    Friend WithEvents btnPantalla As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSaldoInicial As System.Windows.Forms.Button
    Friend WithEvents btnPantalla1 As System.Windows.Forms.Button
    Friend WithEvents tgvFlujoEfectivoAcumulado As AdvancedDataGridView.TreeGridView
    Friend WithEvents Column43 As AdvancedDataGridView.TreeGridColumn
    Friend WithEvents Column44 As AdvancedDataGridView.TreeGridColumn
    Friend WithEvents Column45 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column46 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column37 As AdvancedDataGridView.TreeGridColumn
    Friend WithEvents Column38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column29 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column27 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column47 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
