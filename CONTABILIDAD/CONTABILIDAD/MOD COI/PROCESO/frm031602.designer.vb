<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm031602
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpRegistros = New System.Windows.Forms.TabPage
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_exportar = New System.Windows.Forms.Button
        Me.btn_modificar = New System.Windows.Forms.Button
        Me.dgvDatos = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gbConsulta = New System.Windows.Forms.GroupBox
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.btn_consultar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tpDetalles = New System.Windows.Forms.TabPage
        Me.gbComprobante = New System.Windows.Forms.GroupBox
        Me.txtValorAcciones = New System.Windows.Forms.TextBox
        Me.cboTipoAcciones = New System.Windows.Forms.ComboBox
        Me.cboTipoDocumento = New System.Windows.Forms.ComboBox
        Me.txtNroAcciones = New System.Windows.Forms.TextBox
        Me.pnlBoton = New System.Windows.Forms.Panel
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtEstadoOperacion = New System.Windows.Forms.TextBox
        Me.txtPorcentajeAcciones = New System.Windows.Forms.TextBox
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.txtNroDocumento = New System.Windows.Forms.TextBox
        Me.txtPeriodo = New System.Windows.Forms.TextBox
        Me.lblValorAcciones = New System.Windows.Forms.Label
        Me.lblEstadoOperacion = New System.Windows.Forms.Label
        Me.lblPorcentajeAcciones = New System.Windows.Forms.Label
        Me.lblNumeroAcciones = New System.Windows.Forms.Label
        Me.lblDescripcion = New System.Windows.Forms.Label
        Me.lblTipoAcciones = New System.Windows.Forms.Label
        Me.lblNumeroDocumento = New System.Windows.Forms.Label
        Me.lblTipoDocumento = New System.Windows.Forms.Label
        Me.lblPeriodo = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.tpRegistros.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbConsulta.SuspendLayout()
        Me.tpDetalles.SuspendLayout()
        Me.gbComprobante.SuspendLayout()
        Me.pnlBoton.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpRegistros)
        Me.TabControl1.Controls.Add(Me.tpDetalles)
        Me.TabControl1.Location = New System.Drawing.Point(-2, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(738, 606)
        Me.TabControl1.TabIndex = 0
        '
        'tpRegistros
        '
        Me.tpRegistros.Controls.Add(Me.btnAgregar)
        Me.tpRegistros.Controls.Add(Me.btn_eliminar)
        Me.tpRegistros.Controls.Add(Me.btn_salir)
        Me.tpRegistros.Controls.Add(Me.btn_exportar)
        Me.tpRegistros.Controls.Add(Me.btn_modificar)
        Me.tpRegistros.Controls.Add(Me.dgvDatos)
        Me.tpRegistros.Controls.Add(Me.gbConsulta)
        Me.tpRegistros.Location = New System.Drawing.Point(4, 22)
        Me.tpRegistros.Name = "tpRegistros"
        Me.tpRegistros.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRegistros.Size = New System.Drawing.Size(730, 580)
        Me.tpRegistros.TabIndex = 0
        Me.tpRegistros.Text = "Registros Ple"
        Me.tpRegistros.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregar.Location = New System.Drawing.Point(291, 521)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(83, 31)
        Me.btnAgregar.TabIndex = 12
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar.Location = New System.Drawing.Point(469, 521)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(79, 31)
        Me.btn_eliminar.TabIndex = 9
        Me.btn_eliminar.Text = "&Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(639, 521)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(79, 31)
        Me.btn_salir.TabIndex = 11
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_exportar
        '
        Me.btn_exportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exportar.Image = Global.CONTABILIDAD.My.Resources.Resources.notepad
        Me.btn_exportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_exportar.Location = New System.Drawing.Point(380, 521)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(83, 31)
        Me.btn_exportar.TabIndex = 8
        Me.btn_exportar.Text = "&Exportar"
        Me.btn_exportar.UseVisualStyleBackColor = True
        '
        'btn_modificar
        '
        Me.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar.Location = New System.Drawing.Point(554, 521)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(79, 31)
        Me.btn_modificar.TabIndex = 10
        Me.btn_modificar.Text = "&Modificar"
        Me.btn_modificar.UseVisualStyleBackColor = True
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.AllowUserToResizeRows = False
        Me.dgvDatos.BackgroundColor = System.Drawing.Color.White
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column10, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9})
        Me.dgvDatos.Location = New System.Drawing.Point(12, 76)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.ReadOnly = True
        Me.dgvDatos.RowHeadersVisible = False
        Me.dgvDatos.RowHeadersWidth = 25
        Me.dgvDatos.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgvDatos.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatos.Size = New System.Drawing.Size(706, 434)
        Me.dgvDatos.TabIndex = 7
        '
        'Column1
        '
        Me.Column1.HeaderText = "Periodo"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "Item"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "Tipo Doc."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 75
        '
        'Column3
        '
        Me.Column3.HeaderText = "Nro Doc"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Tipo Ac."
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 75
        '
        'Column5
        '
        Me.Column5.HeaderText = "Descripcion"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 250
        '
        'Column6
        '
        Me.Column6.HeaderText = "Nro Acciones"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "% de Acciones"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Est. Ope"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.ToolTipText = "Estado Operacion"
        Me.Column8.Width = 75
        '
        'Column9
        '
        Me.Column9.HeaderText = "Valor de Acciones"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 120
        '
        'gbConsulta
        '
        Me.gbConsulta.Controls.Add(Me.cbo_año)
        Me.gbConsulta.Controls.Add(Me.cbo_mes)
        Me.gbConsulta.Controls.Add(Me.btn_consultar)
        Me.gbConsulta.Controls.Add(Me.Label1)
        Me.gbConsulta.Controls.Add(Me.Label3)
        Me.gbConsulta.Controls.Add(Me.Label4)
        Me.gbConsulta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbConsulta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbConsulta.Location = New System.Drawing.Point(68, 7)
        Me.gbConsulta.Margin = New System.Windows.Forms.Padding(0)
        Me.gbConsulta.Name = "gbConsulta"
        Me.gbConsulta.Padding = New System.Windows.Forms.Padding(0)
        Me.gbConsulta.Size = New System.Drawing.Size(594, 60)
        Me.gbConsulta.TabIndex = 1
        Me.gbConsulta.TabStop = False
        Me.gbConsulta.Text = "Consulta"
        '
        'cbo_año
        '
        Me.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año.FormattingEnabled = True
        Me.cbo_año.Location = New System.Drawing.Point(114, 25)
        Me.cbo_año.Name = "cbo_año"
        Me.cbo_año.Size = New System.Drawing.Size(79, 22)
        Me.cbo_año.TabIndex = 1
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(251, 25)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(135, 22)
        Me.cbo_mes.TabIndex = 3
        '
        'btn_consultar
        '
        Me.btn_consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_consultar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Search_1
        Me.btn_consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consultar.Location = New System.Drawing.Point(420, 21)
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(99, 31)
        Me.btn_consultar.TabIndex = 4
        Me.btn_consultar.Text = "&Consultar"
        Me.btn_consultar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(76, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Año :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 14)
        Me.Label3.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(212, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 14)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Mes :"
        '
        'tpDetalles
        '
        Me.tpDetalles.Controls.Add(Me.gbComprobante)
        Me.tpDetalles.Location = New System.Drawing.Point(4, 22)
        Me.tpDetalles.Name = "tpDetalles"
        Me.tpDetalles.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDetalles.Size = New System.Drawing.Size(730, 580)
        Me.tpDetalles.TabIndex = 1
        Me.tpDetalles.Text = "Detalles"
        Me.tpDetalles.UseVisualStyleBackColor = True
        '
        'gbComprobante
        '
        Me.gbComprobante.Controls.Add(Me.txtValorAcciones)
        Me.gbComprobante.Controls.Add(Me.cboTipoAcciones)
        Me.gbComprobante.Controls.Add(Me.cboTipoDocumento)
        Me.gbComprobante.Controls.Add(Me.txtNroAcciones)
        Me.gbComprobante.Controls.Add(Me.pnlBoton)
        Me.gbComprobante.Controls.Add(Me.txtEstadoOperacion)
        Me.gbComprobante.Controls.Add(Me.txtPorcentajeAcciones)
        Me.gbComprobante.Controls.Add(Me.txtDescripcion)
        Me.gbComprobante.Controls.Add(Me.txtNroDocumento)
        Me.gbComprobante.Controls.Add(Me.txtPeriodo)
        Me.gbComprobante.Controls.Add(Me.lblValorAcciones)
        Me.gbComprobante.Controls.Add(Me.lblEstadoOperacion)
        Me.gbComprobante.Controls.Add(Me.lblPorcentajeAcciones)
        Me.gbComprobante.Controls.Add(Me.lblNumeroAcciones)
        Me.gbComprobante.Controls.Add(Me.lblDescripcion)
        Me.gbComprobante.Controls.Add(Me.lblTipoAcciones)
        Me.gbComprobante.Controls.Add(Me.lblNumeroDocumento)
        Me.gbComprobante.Controls.Add(Me.lblTipoDocumento)
        Me.gbComprobante.Controls.Add(Me.lblPeriodo)
        Me.gbComprobante.Location = New System.Drawing.Point(155, 8)
        Me.gbComprobante.Name = "gbComprobante"
        Me.gbComprobante.Size = New System.Drawing.Size(420, 326)
        Me.gbComprobante.TabIndex = 0
        Me.gbComprobante.TabStop = False
        Me.gbComprobante.Text = "Comprobante"
        '
        'txtValorAcciones
        '
        Me.txtValorAcciones.Location = New System.Drawing.Point(125, 243)
        Me.txtValorAcciones.Name = "txtValorAcciones"
        Me.txtValorAcciones.Size = New System.Drawing.Size(145, 20)
        Me.txtValorAcciones.TabIndex = 8
        '
        'cboTipoAcciones
        '
        Me.cboTipoAcciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAcciones.FormattingEnabled = True
        Me.cboTipoAcciones.Items.AddRange(New Object() {"ACCIONES CON DERECHO A VOTO", "ACCIONES SIN DERECHO A VOTO", "PARTICIPACIONES", "OTROS"})
        Me.cboTipoAcciones.Location = New System.Drawing.Point(125, 112)
        Me.cboTipoAcciones.Name = "cboTipoAcciones"
        Me.cboTipoAcciones.Size = New System.Drawing.Size(181, 21)
        Me.cboTipoAcciones.TabIndex = 3
        '
        'cboTipoDocumento
        '
        Me.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDocumento.FormattingEnabled = True
        Me.cboTipoDocumento.Location = New System.Drawing.Point(125, 49)
        Me.cboTipoDocumento.Name = "cboTipoDocumento"
        Me.cboTipoDocumento.Size = New System.Drawing.Size(208, 21)
        Me.cboTipoDocumento.TabIndex = 1
        '
        'txtNroAcciones
        '
        Me.txtNroAcciones.Location = New System.Drawing.Point(125, 165)
        Me.txtNroAcciones.Name = "txtNroAcciones"
        Me.txtNroAcciones.Size = New System.Drawing.Size(88, 20)
        Me.txtNroAcciones.TabIndex = 5
        '
        'pnlBoton
        '
        Me.pnlBoton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBoton.Controls.Add(Me.btnGuardar)
        Me.pnlBoton.Controls.Add(Me.btnCancelar)
        Me.pnlBoton.Location = New System.Drawing.Point(125, 273)
        Me.pnlBoton.Name = "pnlBoton"
        Me.pnlBoton.Size = New System.Drawing.Size(199, 42)
        Me.pnlBoton.TabIndex = 19
        Me.pnlBoton.TabStop = True
        '
        'btnGuardar
        '
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.Location = New System.Drawing.Point(103, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(77, 27)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.Location = New System.Drawing.Point(15, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(77, 27)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtEstadoOperacion
        '
        Me.txtEstadoOperacion.Location = New System.Drawing.Point(125, 216)
        Me.txtEstadoOperacion.Name = "txtEstadoOperacion"
        Me.txtEstadoOperacion.Size = New System.Drawing.Size(27, 20)
        Me.txtEstadoOperacion.TabIndex = 7
        Me.txtEstadoOperacion.Text = "1"
        '
        'txtPorcentajeAcciones
        '
        Me.txtPorcentajeAcciones.Location = New System.Drawing.Point(125, 189)
        Me.txtPorcentajeAcciones.Name = "txtPorcentajeAcciones"
        Me.txtPorcentajeAcciones.Size = New System.Drawing.Size(145, 20)
        Me.txtPorcentajeAcciones.TabIndex = 6
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(125, 140)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(284, 20)
        Me.txtDescripcion.TabIndex = 4
        '
        'txtNroDocumento
        '
        Me.txtNroDocumento.Location = New System.Drawing.Point(125, 82)
        Me.txtNroDocumento.Name = "txtNroDocumento"
        Me.txtNroDocumento.Size = New System.Drawing.Size(145, 20)
        Me.txtNroDocumento.TabIndex = 2
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Location = New System.Drawing.Point(125, 18)
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(107, 20)
        Me.txtPeriodo.TabIndex = 0
        '
        'lblValorAcciones
        '
        Me.lblValorAcciones.AutoSize = True
        Me.lblValorAcciones.Location = New System.Drawing.Point(15, 247)
        Me.lblValorAcciones.Name = "lblValorAcciones"
        Me.lblValorAcciones.Size = New System.Drawing.Size(78, 13)
        Me.lblValorAcciones.TabIndex = 9
        Me.lblValorAcciones.Text = "Valor Acciones"
        '
        'lblEstadoOperacion
        '
        Me.lblEstadoOperacion.AutoSize = True
        Me.lblEstadoOperacion.Location = New System.Drawing.Point(15, 220)
        Me.lblEstadoOperacion.Name = "lblEstadoOperacion"
        Me.lblEstadoOperacion.Size = New System.Drawing.Size(92, 13)
        Me.lblEstadoOperacion.TabIndex = 8
        Me.lblEstadoOperacion.Text = "Estado Operacion"
        '
        'lblPorcentajeAcciones
        '
        Me.lblPorcentajeAcciones.AutoSize = True
        Me.lblPorcentajeAcciones.Location = New System.Drawing.Point(15, 193)
        Me.lblPorcentajeAcciones.Name = "lblPorcentajeAcciones"
        Me.lblPorcentajeAcciones.Size = New System.Drawing.Size(105, 13)
        Me.lblPorcentajeAcciones.TabIndex = 6
        Me.lblPorcentajeAcciones.Text = "Porcentaje Acciones"
        '
        'lblNumeroAcciones
        '
        Me.lblNumeroAcciones.AutoSize = True
        Me.lblNumeroAcciones.Location = New System.Drawing.Point(15, 169)
        Me.lblNumeroAcciones.Name = "lblNumeroAcciones"
        Me.lblNumeroAcciones.Size = New System.Drawing.Size(91, 13)
        Me.lblNumeroAcciones.TabIndex = 5
        Me.lblNumeroAcciones.Text = "Numero Acciones"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(15, 144)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 4
        Me.lblDescripcion.Text = "Descripción"
        '
        'lblTipoAcciones
        '
        Me.lblTipoAcciones.AutoSize = True
        Me.lblTipoAcciones.Location = New System.Drawing.Point(15, 115)
        Me.lblTipoAcciones.Name = "lblTipoAcciones"
        Me.lblTipoAcciones.Size = New System.Drawing.Size(75, 13)
        Me.lblTipoAcciones.TabIndex = 3
        Me.lblTipoAcciones.Text = "Tipo Acciones"
        '
        'lblNumeroDocumento
        '
        Me.lblNumeroDocumento.AutoSize = True
        Me.lblNumeroDocumento.Location = New System.Drawing.Point(15, 86)
        Me.lblNumeroDocumento.Name = "lblNumeroDocumento"
        Me.lblNumeroDocumento.Size = New System.Drawing.Size(85, 13)
        Me.lblNumeroDocumento.TabIndex = 2
        Me.lblNumeroDocumento.Text = "Nro. Documento"
        '
        'lblTipoDocumento
        '
        Me.lblTipoDocumento.AutoSize = True
        Me.lblTipoDocumento.Location = New System.Drawing.Point(15, 53)
        Me.lblTipoDocumento.Name = "lblTipoDocumento"
        Me.lblTipoDocumento.Size = New System.Drawing.Size(83, 13)
        Me.lblTipoDocumento.TabIndex = 1
        Me.lblTipoDocumento.Text = "TipoDocumento"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Location = New System.Drawing.Point(15, 22)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(43, 13)
        Me.lblPeriodo.TabIndex = 0
        Me.lblPeriodo.Text = "Periodo"
        '
        'frm031602
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 608)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frm031602"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "3.16.2 Estructura de la participacion accionaria o de participaciones sociales"
        Me.TabControl1.ResumeLayout(False)
        Me.tpRegistros.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbConsulta.ResumeLayout(False)
        Me.gbConsulta.PerformLayout()
        Me.tpDetalles.ResumeLayout(False)
        Me.gbComprobante.ResumeLayout(False)
        Me.gbComprobante.PerformLayout()
        Me.pnlBoton.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpRegistros As System.Windows.Forms.TabPage
    Friend WithEvents tpDetalles As System.Windows.Forms.TabPage
    Friend WithEvents gbConsulta As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_año As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents btn_consultar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents gbComprobante As System.Windows.Forms.GroupBox
    Friend WithEvents lblPorcentajeAcciones As System.Windows.Forms.Label
    Friend WithEvents lblNumeroAcciones As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblTipoAcciones As System.Windows.Forms.Label
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents lblTipoDocumento As System.Windows.Forms.Label
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents txtEstadoOperacion As System.Windows.Forms.TextBox
    Friend WithEvents txtPorcentajeAcciones As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtNroDocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
    Friend WithEvents lblValorAcciones As System.Windows.Forms.Label
    Friend WithEvents lblEstadoOperacion As System.Windows.Forms.Label
    Friend WithEvents pnlBoton As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtNroAcciones As System.Windows.Forms.TextBox
    Friend WithEvents cboTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoAcciones As System.Windows.Forms.ComboBox
    Friend WithEvents txtValorAcciones As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
