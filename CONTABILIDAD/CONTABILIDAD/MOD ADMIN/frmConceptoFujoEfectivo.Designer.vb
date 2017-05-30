<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConceptoFujoEfectivo
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmsGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAgregar = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuModificar = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuEliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.tcConceptos = New System.Windows.Forms.TabControl
        Me.tpListado = New System.Windows.Forms.TabPage
        Me.gbBotones = New System.Windows.Forms.GroupBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.btn_Modificar = New System.Windows.Forms.Button
        Me.tgvDetalle = New AdvancedDataGridView.TreeGridView
        Me.Column1 = New AdvancedDataGridView.TreeGridColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tpDetalle = New System.Windows.Forms.TabPage
        Me.gbDatos = New System.Windows.Forms.GroupBox
        Me.gbBuscar = New System.Windows.Forms.GroupBox
        Me.llblVerCuentas = New System.Windows.Forms.LinkLabel
        Me.txtCuenta = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.tgvCuentas = New AdvancedDataGridView.TreeGridView
        Me.Column7 = New AdvancedDataGridView.TreeGridColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtNivel = New System.Windows.Forms.TextBox
        Me.chkFlujo = New System.Windows.Forms.CheckBox
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDescConceptoSuper = New System.Windows.Forms.TextBox
        Me.txtCodConceptoSuperior = New System.Windows.Forms.TextBox
        Me.txtAbreviado = New System.Windows.Forms.TextBox
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.cmsGrid.SuspendLayout()
        Me.tcConceptos.SuspendLayout()
        Me.tpListado.SuspendLayout()
        Me.gbBotones.SuspendLayout()
        CType(Me.tgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDetalle.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        Me.gbBuscar.SuspendLayout()
        CType(Me.tgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmsGrid
        '
        Me.cmsGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAgregar, Me.mnuModificar, Me.ToolStripMenuItem1, Me.mnuEliminar})
        Me.cmsGrid.Name = "cmsGrid"
        Me.cmsGrid.Size = New System.Drawing.Size(170, 76)
        '
        'mnuAgregar
        '
        Me.mnuAgregar.Image = Global.CONTABILIDAD.My.Resources.Resources.add
        Me.mnuAgregar.Name = "mnuAgregar"
        Me.mnuAgregar.Size = New System.Drawing.Size(169, 22)
        Me.mnuAgregar.Text = "Agregar concepto"
        '
        'mnuModificar
        '
        Me.mnuModificar.Image = Global.CONTABILIDAD.My.Resources.Resources.edit
        Me.mnuModificar.Name = "mnuModificar"
        Me.mnuModificar.Size = New System.Drawing.Size(169, 22)
        Me.mnuModificar.Text = "Modificar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(166, 6)
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Image = Global.CONTABILIDAD.My.Resources.Resources.delete
        Me.mnuEliminar.Name = "mnuEliminar"
        Me.mnuEliminar.Size = New System.Drawing.Size(169, 22)
        Me.mnuEliminar.Text = "Eliminar"
        '
        'tcConceptos
        '
        Me.tcConceptos.Controls.Add(Me.tpListado)
        Me.tcConceptos.Controls.Add(Me.tpDetalle)
        Me.tcConceptos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcConceptos.Location = New System.Drawing.Point(0, 0)
        Me.tcConceptos.Name = "tcConceptos"
        Me.tcConceptos.SelectedIndex = 0
        Me.tcConceptos.Size = New System.Drawing.Size(515, 429)
        Me.tcConceptos.TabIndex = 0
        '
        'tpListado
        '
        Me.tpListado.Controls.Add(Me.gbBotones)
        Me.tpListado.Controls.Add(Me.tgvDetalle)
        Me.tpListado.Location = New System.Drawing.Point(4, 23)
        Me.tpListado.Name = "tpListado"
        Me.tpListado.Padding = New System.Windows.Forms.Padding(3)
        Me.tpListado.Size = New System.Drawing.Size(507, 402)
        Me.tpListado.TabIndex = 0
        Me.tpListado.Text = "Listado de Conceptos"
        Me.tpListado.UseVisualStyleBackColor = True
        '
        'gbBotones
        '
        Me.gbBotones.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbBotones.Controls.Add(Me.btn_salir)
        Me.gbBotones.Controls.Add(Me.btn_eliminar)
        Me.gbBotones.Controls.Add(Me.btn_nuevo)
        Me.gbBotones.Controls.Add(Me.btn_Modificar)
        Me.gbBotones.Location = New System.Drawing.Point(402, 6)
        Me.gbBotones.Name = "gbBotones"
        Me.gbBotones.Size = New System.Drawing.Size(99, 167)
        Me.gbBotones.TabIndex = 1
        Me.gbBotones.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(7, 122)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(85, 35)
        Me.btn_salir.TabIndex = 3
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar.Location = New System.Drawing.Point(7, 86)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(85, 35)
        Me.btn_eliminar.TabIndex = 2
        Me.btn_eliminar.Text = "&Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.Location = New System.Drawing.Point(7, 14)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(85, 35)
        Me.btn_nuevo.TabIndex = 0
        Me.btn_nuevo.Text = "&Nuevo"
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'btn_Modificar
        '
        Me.btn_Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Modificar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Modificar.Location = New System.Drawing.Point(7, 50)
        Me.btn_Modificar.Name = "btn_Modificar"
        Me.btn_Modificar.Size = New System.Drawing.Size(85, 35)
        Me.btn_Modificar.TabIndex = 1
        Me.btn_Modificar.Text = "&Modificar"
        Me.btn_Modificar.UseVisualStyleBackColor = True
        '
        'tgvDetalle
        '
        Me.tgvDetalle.AllowUserToAddRows = False
        Me.tgvDetalle.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.tgvDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.tgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgvDetalle.BackgroundColor = System.Drawing.Color.White
        Me.tgvDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.tgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.tgvDetalle.ContextMenuStrip = Me.cmsGrid
        Me.tgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.tgvDetalle.ImageList = Nothing
        Me.tgvDetalle.Location = New System.Drawing.Point(0, 0)
        Me.tgvDetalle.Name = "tgvDetalle"
        Me.tgvDetalle.RowHeadersVisible = False
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue
        Me.tgvDetalle.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.tgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tgvDetalle.Size = New System.Drawing.Size(396, 402)
        Me.tgvDetalle.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DefaultNodeImage = Nothing
        Me.Column1.HeaderText = "Código"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 90
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descripción"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 280
        '
        'Column3
        '
        Me.Column3.HeaderText = "Abreviado"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Visible = False
        Me.Column3.Width = 180
        '
        'Column4
        '
        Me.Column4.HeaderText = "Gen."
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        Me.Column4.Width = 30
        '
        'Column5
        '
        Me.Column5.HeaderText = "Cod. Sup."
        Me.Column5.Name = "Column5"
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column5.Visible = False
        Me.Column5.Width = 90
        '
        'Column6
        '
        Me.Column6.HeaderText = "Nivel"
        Me.Column6.Name = "Column6"
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column6.Visible = False
        Me.Column6.Width = 30
        '
        'tpDetalle
        '
        Me.tpDetalle.Controls.Add(Me.gbDatos)
        Me.tpDetalle.Location = New System.Drawing.Point(4, 23)
        Me.tpDetalle.Name = "tpDetalle"
        Me.tpDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDetalle.Size = New System.Drawing.Size(507, 402)
        Me.tpDetalle.TabIndex = 1
        Me.tpDetalle.Text = "Detalles"
        Me.tpDetalle.UseVisualStyleBackColor = True
        '
        'gbDatos
        '
        Me.gbDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDatos.Controls.Add(Me.gbBuscar)
        Me.gbDatos.Controls.Add(Me.tgvCuentas)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Controls.Add(Me.txtNivel)
        Me.gbDatos.Controls.Add(Me.chkFlujo)
        Me.gbDatos.Controls.Add(Me.btn_guardar)
        Me.gbDatos.Controls.Add(Me.btn_cancelar)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.txtDescConceptoSuper)
        Me.gbDatos.Controls.Add(Me.txtCodConceptoSuperior)
        Me.gbDatos.Controls.Add(Me.txtAbreviado)
        Me.gbDatos.Controls.Add(Me.txtDescripcion)
        Me.gbDatos.Controls.Add(Me.txtCodigo)
        Me.gbDatos.Location = New System.Drawing.Point(8, 6)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(493, 390)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        '
        'gbBuscar
        '
        Me.gbBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbBuscar.Controls.Add(Me.llblVerCuentas)
        Me.gbBuscar.Controls.Add(Me.txtCuenta)
        Me.gbBuscar.Controls.Add(Me.Label6)
        Me.gbBuscar.Location = New System.Drawing.Point(6, 345)
        Me.gbBuscar.Name = "gbBuscar"
        Me.gbBuscar.Size = New System.Drawing.Size(315, 39)
        Me.gbBuscar.TabIndex = 15
        Me.gbBuscar.TabStop = False
        '
        'llblVerCuentas
        '
        Me.llblVerCuentas.AutoSize = True
        Me.llblVerCuentas.Location = New System.Drawing.Point(199, 16)
        Me.llblVerCuentas.Name = "llblVerCuentas"
        Me.llblVerCuentas.Size = New System.Drawing.Size(101, 14)
        Me.llblVerCuentas.TabIndex = 17
        Me.llblVerCuentas.TabStop = True
        Me.llblVerCuentas.Text = "cuentas agregadas"
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(56, 12)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(137, 20)
        Me.txtCuenta.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 14)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Cuenta:"
        '
        'tgvCuentas
        '
        Me.tgvCuentas.AllowUserToAddRows = False
        Me.tgvCuentas.AllowUserToDeleteRows = False
        Me.tgvCuentas.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue
        Me.tgvCuentas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.tgvCuentas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tgvCuentas.BackgroundColor = System.Drawing.Color.White
        Me.tgvCuentas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.tgvCuentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column7, Me.Column8, Me.Column9})
        Me.tgvCuentas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.tgvCuentas.ImageList = Nothing
        Me.tgvCuentas.Location = New System.Drawing.Point(6, 152)
        Me.tgvCuentas.Name = "tgvCuentas"
        Me.tgvCuentas.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue
        Me.tgvCuentas.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.tgvCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tgvCuentas.Size = New System.Drawing.Size(420, 187)
        Me.tgvCuentas.TabIndex = 14
        '
        'Column7
        '
        Me.Column7.DefaultNodeImage = Nothing
        Me.Column7.HeaderText = "Cod. Cuenta"
        Me.Column7.Name = "Column7"
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column7.Width = 80
        '
        'Column8
        '
        Me.Column8.HeaderText = "Desc. Cuenta"
        Me.Column8.Name = "Column8"
        Me.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column8.Width = 285
        '
        'Column9
        '
        Me.Column9.HeaderText = "Ok"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(342, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 14)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Nivel:"
        '
        'txtNivel
        '
        Me.txtNivel.BackColor = System.Drawing.Color.White
        Me.txtNivel.Location = New System.Drawing.Point(381, 126)
        Me.txtNivel.Name = "txtNivel"
        Me.txtNivel.ReadOnly = True
        Me.txtNivel.Size = New System.Drawing.Size(38, 20)
        Me.txtNivel.TabIndex = 12
        Me.txtNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkFlujo
        '
        Me.chkFlujo.AutoSize = True
        Me.chkFlujo.Location = New System.Drawing.Point(82, 128)
        Me.chkFlujo.Name = "chkFlujo"
        Me.chkFlujo.Size = New System.Drawing.Size(97, 18)
        Me.chkFlujo.TabIndex = 9
        Me.chkFlujo.Text = "¿Genera flujo?"
        Me.chkFlujo.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.Location = New System.Drawing.Point(327, 357)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(77, 27)
        Me.btn_guardar.TabIndex = 10
        Me.btn_guardar.Text = "&Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.Location = New System.Drawing.Point(410, 357)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(77, 27)
        Me.btn_cancelar.TabIndex = 11
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cpto. Super."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Abreviatura:"
        '
        'txtDescConceptoSuper
        '
        Me.txtDescConceptoSuper.BackColor = System.Drawing.Color.White
        Me.txtDescConceptoSuper.Location = New System.Drawing.Point(117, 102)
        Me.txtDescConceptoSuper.MaxLength = 80
        Me.txtDescConceptoSuper.Name = "txtDescConceptoSuper"
        Me.txtDescConceptoSuper.ReadOnly = True
        Me.txtDescConceptoSuper.Size = New System.Drawing.Size(302, 20)
        Me.txtDescConceptoSuper.TabIndex = 8
        '
        'txtCodConceptoSuperior
        '
        Me.txtCodConceptoSuperior.BackColor = System.Drawing.Color.White
        Me.txtCodConceptoSuperior.Location = New System.Drawing.Point(82, 102)
        Me.txtCodConceptoSuperior.MaxLength = 5
        Me.txtCodConceptoSuperior.Name = "txtCodConceptoSuperior"
        Me.txtCodConceptoSuperior.ReadOnly = True
        Me.txtCodConceptoSuperior.Size = New System.Drawing.Size(34, 20)
        Me.txtCodConceptoSuperior.TabIndex = 7
        '
        'txtAbreviado
        '
        Me.txtAbreviado.BackColor = System.Drawing.Color.White
        Me.txtAbreviado.Location = New System.Drawing.Point(82, 78)
        Me.txtAbreviado.MaxLength = 20
        Me.txtAbreviado.Name = "txtAbreviado"
        Me.txtAbreviado.Size = New System.Drawing.Size(180, 20)
        Me.txtAbreviado.TabIndex = 5
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        Me.txtDescripcion.Location = New System.Drawing.Point(82, 54)
        Me.txtDescripcion.MaxLength = 80
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(337, 20)
        Me.txtDescripcion.TabIndex = 3
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(82, 30)
        Me.txtCodigo.MaxLength = 5
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(53, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'frmConceptoFujoEfectivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(515, 429)
        Me.Controls.Add(Me.tcConceptos)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmConceptoFujoEfectivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conceptos Fujo Efectivo"
        Me.cmsGrid.ResumeLayout(False)
        Me.tcConceptos.ResumeLayout(False)
        Me.tpListado.ResumeLayout(False)
        Me.gbBotones.ResumeLayout(False)
        CType(Me.tgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDetalle.ResumeLayout(False)
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.gbBuscar.ResumeLayout(False)
        Me.gbBuscar.PerformLayout()
        CType(Me.tgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmsGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuAgregar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tcConceptos As System.Windows.Forms.TabControl
    Friend WithEvents tpListado As System.Windows.Forms.TabPage
    Friend WithEvents tpDetalle As System.Windows.Forms.TabPage
    Friend WithEvents tgvDetalle As AdvancedDataGridView.TreeGridView
    Friend WithEvents gbBotones As System.Windows.Forms.GroupBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_Modificar As System.Windows.Forms.Button
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAbreviado As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents chkFlujo As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCodConceptoSuperior As System.Windows.Forms.TextBox
    Friend WithEvents txtDescConceptoSuper As System.Windows.Forms.TextBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents txtNivel As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Column1 As AdvancedDataGridView.TreeGridColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tgvCuentas As AdvancedDataGridView.TreeGridView
    Friend WithEvents Column7 As AdvancedDataGridView.TreeGridColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents gbBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents llblVerCuentas As System.Windows.Forms.LinkLabel
End Class
