<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm0301
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
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gbConsulta = New System.Windows.Forms.GroupBox
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.btn_consultar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tpDetalles = New System.Windows.Forms.TabPage
        Me.gbComprobante = New System.Windows.Forms.GroupBox
        Me.gbActivos = New System.Windows.Forms.GroupBox
        Me.dgvActivos = New System.Windows.Forms.DataGridView
        Me.txtNota = New System.Windows.Forms.TextBox
        Me.lblNota = New System.Windows.Forms.Label
        Me.txtTipo = New System.Windows.Forms.TextBox
        Me.lblTipo = New System.Windows.Forms.Label
        Me.txtRubroEstadoFinanciero = New System.Windows.Forms.TextBox
        Me.txtNombreRubro = New System.Windows.Forms.TextBox
        Me.txtEstadoOperacion = New System.Windows.Forms.TextBox
        Me.txtSaldoContable = New System.Windows.Forms.TextBox
        Me.cboCatalogo = New System.Windows.Forms.ComboBox
        Me.pnlBoton = New System.Windows.Forms.Panel
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtPeriodo = New System.Windows.Forms.TextBox
        Me.lblEstadoOperacion = New System.Windows.Forms.Label
        Me.lblNombreRubro = New System.Windows.Forms.Label
        Me.lblSaldoContable = New System.Windows.Forms.Label
        Me.lblCodigoRubroFinanciero = New System.Windows.Forms.Label
        Me.lblCatalogo = New System.Windows.Forms.Label
        Me.lblPeriodo = New System.Windows.Forms.Label
        Me.cDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cTipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cMonto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cNota = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabControl1.SuspendLayout()
        Me.tpRegistros.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbConsulta.SuspendLayout()
        Me.tpDetalles.SuspendLayout()
        Me.gbComprobante.SuspendLayout()
        Me.gbActivos.SuspendLayout()
        CType(Me.dgvActivos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8})
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
        'Column2
        '
        Me.Column2.HeaderText = "Cod. Catalogo"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.ToolTipText = "Código Catalogo"
        Me.Column2.Width = 75
        '
        'Column3
        '
        Me.Column3.HeaderText = "Cod Cta Ctble"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.ToolTipText = "Codigo de la Cuenta Contable"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Saldo Rubro"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.ToolTipText = "Saldo del Rubro Contable"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Est. Ope."
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.ToolTipText = "Estado Operación"
        Me.Column5.Width = 75
        '
        'Column6
        '
        Me.Column6.HeaderText = "Nom Rubro"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.ToolTipText = "Nombre Rubro"
        Me.Column6.Width = 300
        '
        'Column7
        '
        Me.Column7.HeaderText = "Tipo"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Notas"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 250
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
        Me.gbComprobante.Controls.Add(Me.gbActivos)
        Me.gbComprobante.Controls.Add(Me.txtNota)
        Me.gbComprobante.Controls.Add(Me.lblNota)
        Me.gbComprobante.Controls.Add(Me.txtTipo)
        Me.gbComprobante.Controls.Add(Me.lblTipo)
        Me.gbComprobante.Controls.Add(Me.txtRubroEstadoFinanciero)
        Me.gbComprobante.Controls.Add(Me.txtNombreRubro)
        Me.gbComprobante.Controls.Add(Me.txtEstadoOperacion)
        Me.gbComprobante.Controls.Add(Me.txtSaldoContable)
        Me.gbComprobante.Controls.Add(Me.cboCatalogo)
        Me.gbComprobante.Controls.Add(Me.pnlBoton)
        Me.gbComprobante.Controls.Add(Me.txtPeriodo)
        Me.gbComprobante.Controls.Add(Me.lblEstadoOperacion)
        Me.gbComprobante.Controls.Add(Me.lblNombreRubro)
        Me.gbComprobante.Controls.Add(Me.lblSaldoContable)
        Me.gbComprobante.Controls.Add(Me.lblCodigoRubroFinanciero)
        Me.gbComprobante.Controls.Add(Me.lblCatalogo)
        Me.gbComprobante.Controls.Add(Me.lblPeriodo)
        Me.gbComprobante.Location = New System.Drawing.Point(6, 8)
        Me.gbComprobante.Name = "gbComprobante"
        Me.gbComprobante.Size = New System.Drawing.Size(713, 544)
        Me.gbComprobante.TabIndex = 0
        Me.gbComprobante.TabStop = False
        Me.gbComprobante.Text = "Comprobante"
        '
        'gbActivos
        '
        Me.gbActivos.Controls.Add(Me.dgvActivos)
        Me.gbActivos.Location = New System.Drawing.Point(5, 87)
        Me.gbActivos.Name = "gbActivos"
        Me.gbActivos.Size = New System.Drawing.Size(702, 257)
        Me.gbActivos.TabIndex = 23
        Me.gbActivos.TabStop = False
        Me.gbActivos.Text = "Activos"
        '
        'dgvActivos
        '
        Me.dgvActivos.AllowUserToAddRows = False
        Me.dgvActivos.AllowUserToDeleteRows = False
        Me.dgvActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvActivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cDescripcion, Me.cCodigo, Me.cTipo, Me.cMonto, Me.cNota})
        Me.dgvActivos.Location = New System.Drawing.Point(6, 19)
        Me.dgvActivos.Name = "dgvActivos"
        Me.dgvActivos.Size = New System.Drawing.Size(690, 232)
        Me.dgvActivos.TabIndex = 0
        '
        'txtNota
        '
        Me.txtNota.Location = New System.Drawing.Point(262, 199)
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(298, 20)
        Me.txtNota.TabIndex = 7
        '
        'lblNota
        '
        Me.lblNota.AutoSize = True
        Me.lblNota.Location = New System.Drawing.Point(152, 203)
        Me.lblNota.Name = "lblNota"
        Me.lblNota.Size = New System.Drawing.Size(30, 13)
        Me.lblNota.TabIndex = 22
        Me.lblNota.Text = "Nota"
        '
        'txtTipo
        '
        Me.txtTipo.Location = New System.Drawing.Point(262, 173)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.ReadOnly = True
        Me.txtTipo.Size = New System.Drawing.Size(298, 20)
        Me.txtTipo.TabIndex = 6
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Location = New System.Drawing.Point(152, 177)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(28, 13)
        Me.lblTipo.TabIndex = 20
        Me.lblTipo.Text = "Tipo"
        '
        'txtRubroEstadoFinanciero
        '
        Me.txtRubroEstadoFinanciero.Location = New System.Drawing.Point(262, 93)
        Me.txtRubroEstadoFinanciero.MaxLength = 6
        Me.txtRubroEstadoFinanciero.Name = "txtRubroEstadoFinanciero"
        Me.txtRubroEstadoFinanciero.ReadOnly = True
        Me.txtRubroEstadoFinanciero.Size = New System.Drawing.Size(143, 20)
        Me.txtRubroEstadoFinanciero.TabIndex = 2
        '
        'txtNombreRubro
        '
        Me.txtNombreRubro.Location = New System.Drawing.Point(262, 148)
        Me.txtNombreRubro.Name = "txtNombreRubro"
        Me.txtNombreRubro.ReadOnly = True
        Me.txtNombreRubro.Size = New System.Drawing.Size(298, 20)
        Me.txtNombreRubro.TabIndex = 5
        '
        'txtEstadoOperacion
        '
        Me.txtEstadoOperacion.Location = New System.Drawing.Point(262, 62)
        Me.txtEstadoOperacion.Name = "txtEstadoOperacion"
        Me.txtEstadoOperacion.ReadOnly = True
        Me.txtEstadoOperacion.Size = New System.Drawing.Size(28, 20)
        Me.txtEstadoOperacion.TabIndex = 4
        Me.txtEstadoOperacion.Text = "1"
        '
        'txtSaldoContable
        '
        Me.txtSaldoContable.Location = New System.Drawing.Point(262, 121)
        Me.txtSaldoContable.Name = "txtSaldoContable"
        Me.txtSaldoContable.Size = New System.Drawing.Size(199, 20)
        Me.txtSaldoContable.TabIndex = 3
        '
        'cboCatalogo
        '
        Me.cboCatalogo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCatalogo.FormattingEnabled = True
        Me.cboCatalogo.Location = New System.Drawing.Point(262, 39)
        Me.cboCatalogo.Name = "cboCatalogo"
        Me.cboCatalogo.Size = New System.Drawing.Size(298, 21)
        Me.cboCatalogo.TabIndex = 1
        '
        'pnlBoton
        '
        Me.pnlBoton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBoton.Controls.Add(Me.btnGuardar)
        Me.pnlBoton.Controls.Add(Me.btnCancelar)
        Me.pnlBoton.Location = New System.Drawing.Point(257, 350)
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
        'txtPeriodo
        '
        Me.txtPeriodo.Location = New System.Drawing.Point(262, 16)
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ReadOnly = True
        Me.txtPeriodo.Size = New System.Drawing.Size(107, 20)
        Me.txtPeriodo.TabIndex = 0
        '
        'lblEstadoOperacion
        '
        Me.lblEstadoOperacion.AutoSize = True
        Me.lblEstadoOperacion.Location = New System.Drawing.Point(152, 66)
        Me.lblEstadoOperacion.Name = "lblEstadoOperacion"
        Me.lblEstadoOperacion.Size = New System.Drawing.Size(92, 13)
        Me.lblEstadoOperacion.TabIndex = 8
        Me.lblEstadoOperacion.Text = "Estado Operacion"
        '
        'lblNombreRubro
        '
        Me.lblNombreRubro.AutoSize = True
        Me.lblNombreRubro.Location = New System.Drawing.Point(152, 152)
        Me.lblNombreRubro.Name = "lblNombreRubro"
        Me.lblNombreRubro.Size = New System.Drawing.Size(76, 13)
        Me.lblNombreRubro.TabIndex = 5
        Me.lblNombreRubro.Text = "Nombre Rubro"
        '
        'lblSaldoContable
        '
        Me.lblSaldoContable.AutoSize = True
        Me.lblSaldoContable.Location = New System.Drawing.Point(152, 125)
        Me.lblSaldoContable.Name = "lblSaldoContable"
        Me.lblSaldoContable.Size = New System.Drawing.Size(79, 13)
        Me.lblSaldoContable.TabIndex = 3
        Me.lblSaldoContable.Text = "Saldo Contable"
        '
        'lblCodigoRubroFinanciero
        '
        Me.lblCodigoRubroFinanciero.AutoSize = True
        Me.lblCodigoRubroFinanciero.Location = New System.Drawing.Point(154, 96)
        Me.lblCodigoRubroFinanciero.Name = "lblCodigoRubroFinanciero"
        Me.lblCodigoRubroFinanciero.Size = New System.Drawing.Size(72, 13)
        Me.lblCodigoRubroFinanciero.TabIndex = 2
        Me.lblCodigoRubroFinanciero.Text = "Codigo Rubro"
        '
        'lblCatalogo
        '
        Me.lblCatalogo.AutoSize = True
        Me.lblCatalogo.Location = New System.Drawing.Point(152, 43)
        Me.lblCatalogo.Name = "lblCatalogo"
        Me.lblCatalogo.Size = New System.Drawing.Size(49, 13)
        Me.lblCatalogo.TabIndex = 1
        Me.lblCatalogo.Text = "Catalogo"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Location = New System.Drawing.Point(152, 20)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(43, 13)
        Me.lblPeriodo.TabIndex = 0
        Me.lblPeriodo.Text = "Periodo"
        '
        'cDescripcion
        '
        Me.cDescripcion.HeaderText = "Descripción"
        Me.cDescripcion.Name = "cDescripcion"
        Me.cDescripcion.ReadOnly = True
        Me.cDescripcion.Width = 200
        '
        'cCodigo
        '
        Me.cCodigo.HeaderText = "Código"
        Me.cCodigo.Name = "cCodigo"
        Me.cCodigo.ReadOnly = True
        Me.cCodigo.Width = 60
        '
        'cTipo
        '
        Me.cTipo.HeaderText = "Tipo"
        Me.cTipo.Name = "cTipo"
        Me.cTipo.Width = 75
        '
        'cMonto
        '
        Me.cMonto.HeaderText = "Monto"
        Me.cMonto.Name = "cMonto"
        '
        'cNota
        '
        Me.cNota.HeaderText = "Nota"
        Me.cNota.Name = "cNota"
        Me.cNota.Width = 250
        '
        'frm0301
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 608)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frm0301"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "3.1 Libro de Inventarios y Balance - Estado de Situación Financiera"
        Me.TabControl1.ResumeLayout(False)
        Me.tpRegistros.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbConsulta.ResumeLayout(False)
        Me.gbConsulta.PerformLayout()
        Me.tpDetalles.ResumeLayout(False)
        Me.gbComprobante.ResumeLayout(False)
        Me.gbComprobante.PerformLayout()
        Me.gbActivos.ResumeLayout(False)
        CType(Me.dgvActivos, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblNombreRubro As System.Windows.Forms.Label
    Friend WithEvents lblSaldoContable As System.Windows.Forms.Label
    Friend WithEvents lblCodigoRubroFinanciero As System.Windows.Forms.Label
    Friend WithEvents lblCatalogo As System.Windows.Forms.Label
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
    Friend WithEvents lblEstadoOperacion As System.Windows.Forms.Label
    Friend WithEvents pnlBoton As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents cboCatalogo As System.Windows.Forms.ComboBox
    Friend WithEvents txtEstadoOperacion As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldoContable As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreRubro As System.Windows.Forms.TextBox
    Friend WithEvents txtRubroEstadoFinanciero As System.Windows.Forms.TextBox
    Friend WithEvents txtNota As System.Windows.Forms.TextBox
    Friend WithEvents lblNota As System.Windows.Forms.Label
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents gbActivos As System.Windows.Forms.GroupBox
    Friend WithEvents dgvActivos As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNota As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
