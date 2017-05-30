<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm0309
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
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnExportar = New System.Windows.Forms.Button
        Me.btnModificar = New System.Windows.Forms.Button
        Me.dgvDatos = New System.Windows.Forms.DataGridView
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
        Me.gbConsulta = New System.Windows.Forms.GroupBox
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.btn_consultar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tpDetalles = New System.Windows.Forms.TabPage
        Me.gbComprobante = New System.Windows.Forms.GroupBox
        Me.txtCodigoInterno = New System.Windows.Forms.TextBox
        Me.lblCodigoInterno = New System.Windows.Forms.Label
        Me.txtTasa = New System.Windows.Forms.TextBox
        Me.Tasa = New System.Windows.Forms.Label
        Me.txtVidaUtil = New System.Windows.Forms.TextBox
        Me.lblVidaUtil = New System.Windows.Forms.Label
        Me.txtEstadoOperacion = New System.Windows.Forms.TextBox
        Me.lblEstadoOperacion = New System.Windows.Forms.Label
        Me.txtAmortizacion = New System.Windows.Forms.TextBox
        Me.lblAmortizacion = New System.Windows.Forms.Label
        Me.txtValorDelIntangible = New System.Windows.Forms.TextBox
        Me.lblValorDelIntangible = New System.Windows.Forms.Label
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.lblDescripcion = New System.Windows.Forms.Label
        Me.txtCodigoCuentaContable = New System.Windows.Forms.TextBox
        Me.lblCodCtaCtble = New System.Windows.Forms.Label
        Me.dtpFechaOperacion = New System.Windows.Forms.DateTimePicker
        Me.lblFecha = New System.Windows.Forms.Label
        Me.txtCorrelativo = New System.Windows.Forms.TextBox
        Me.lblCorrelativo = New System.Windows.Forms.Label
        Me.txtCUO = New System.Windows.Forms.TextBox
        Me.lblCUO = New System.Windows.Forms.Label
        Me.pnlBoton = New System.Windows.Forms.Panel
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtPeriodo = New System.Windows.Forms.TextBox
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
        Me.TabControl1.Location = New System.Drawing.Point(-3, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(738, 606)
        Me.TabControl1.TabIndex = 0
        '
        'tpRegistros
        '
        Me.tpRegistros.Controls.Add(Me.btnAgregar)
        Me.tpRegistros.Controls.Add(Me.btnEliminar)
        Me.tpRegistros.Controls.Add(Me.btnSalir)
        Me.tpRegistros.Controls.Add(Me.btnExportar)
        Me.tpRegistros.Controls.Add(Me.btnModificar)
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
        'btnEliminar
        '
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.Location = New System.Drawing.Point(469, 521)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(79, 31)
        Me.btnEliminar.TabIndex = 9
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.Location = New System.Drawing.Point(639, 521)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(79, 31)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportar.Image = Global.CONTABILIDAD.My.Resources.Resources.notepad
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportar.Location = New System.Drawing.Point(554, 521)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(83, 31)
        Me.btnExportar.TabIndex = 8
        Me.btnExportar.Text = "&Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModificar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModificar.Location = New System.Drawing.Point(384, 521)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(79, 31)
        Me.btnModificar.TabIndex = 10
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.AllowUserToResizeRows = False
        Me.dgvDatos.BackgroundColor = System.Drawing.Color.White
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15})
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
        Me.Column2.HeaderText = "C.U.O"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Correlativo"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "FechaInicioOpe"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Cuenta Contable"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Descripción"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Valor"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Amortización"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Est. Ope."
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "Vida Util"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "Tasa"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "Codigo Interno Intangible"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "Año"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Visible = False
        '
        'Column14
        '
        Me.Column14.HeaderText = "Mes"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.Visible = False
        '
        'Column15
        '
        Me.Column15.HeaderText = "Item"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Visible = False
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
        Me.gbComprobante.Controls.Add(Me.txtCodigoInterno)
        Me.gbComprobante.Controls.Add(Me.lblCodigoInterno)
        Me.gbComprobante.Controls.Add(Me.txtTasa)
        Me.gbComprobante.Controls.Add(Me.Tasa)
        Me.gbComprobante.Controls.Add(Me.txtVidaUtil)
        Me.gbComprobante.Controls.Add(Me.lblVidaUtil)
        Me.gbComprobante.Controls.Add(Me.txtEstadoOperacion)
        Me.gbComprobante.Controls.Add(Me.lblEstadoOperacion)
        Me.gbComprobante.Controls.Add(Me.txtAmortizacion)
        Me.gbComprobante.Controls.Add(Me.lblAmortizacion)
        Me.gbComprobante.Controls.Add(Me.txtValorDelIntangible)
        Me.gbComprobante.Controls.Add(Me.lblValorDelIntangible)
        Me.gbComprobante.Controls.Add(Me.txtDescripcion)
        Me.gbComprobante.Controls.Add(Me.lblDescripcion)
        Me.gbComprobante.Controls.Add(Me.txtCodigoCuentaContable)
        Me.gbComprobante.Controls.Add(Me.lblCodCtaCtble)
        Me.gbComprobante.Controls.Add(Me.dtpFechaOperacion)
        Me.gbComprobante.Controls.Add(Me.lblFecha)
        Me.gbComprobante.Controls.Add(Me.txtCorrelativo)
        Me.gbComprobante.Controls.Add(Me.lblCorrelativo)
        Me.gbComprobante.Controls.Add(Me.txtCUO)
        Me.gbComprobante.Controls.Add(Me.lblCUO)
        Me.gbComprobante.Controls.Add(Me.pnlBoton)
        Me.gbComprobante.Controls.Add(Me.txtPeriodo)
        Me.gbComprobante.Controls.Add(Me.lblPeriodo)
        Me.gbComprobante.Location = New System.Drawing.Point(151, 8)
        Me.gbComprobante.Name = "gbComprobante"
        Me.gbComprobante.Size = New System.Drawing.Size(429, 398)
        Me.gbComprobante.TabIndex = 0
        Me.gbComprobante.TabStop = False
        Me.gbComprobante.Text = "Comprobante"
        '
        'txtCodigoInterno
        '
        Me.txtCodigoInterno.Location = New System.Drawing.Point(147, 306)
        Me.txtCodigoInterno.Name = "txtCodigoInterno"
        Me.txtCodigoInterno.Size = New System.Drawing.Size(107, 20)
        Me.txtCodigoInterno.TabIndex = 11
        '
        'lblCodigoInterno
        '
        Me.lblCodigoInterno.AutoSize = True
        Me.lblCodigoInterno.Location = New System.Drawing.Point(15, 310)
        Me.lblCodigoInterno.Name = "lblCodigoInterno"
        Me.lblCodigoInterno.Size = New System.Drawing.Size(76, 13)
        Me.lblCodigoInterno.TabIndex = 40
        Me.lblCodigoInterno.Text = "Codigo Interno"
        '
        'txtTasa
        '
        Me.txtTasa.Location = New System.Drawing.Point(147, 280)
        Me.txtTasa.Name = "txtTasa"
        Me.txtTasa.Size = New System.Drawing.Size(107, 20)
        Me.txtTasa.TabIndex = 10
        '
        'Tasa
        '
        Me.Tasa.AutoSize = True
        Me.Tasa.Location = New System.Drawing.Point(15, 284)
        Me.Tasa.Name = "Tasa"
        Me.Tasa.Size = New System.Drawing.Size(94, 13)
        Me.Tasa.TabIndex = 38
        Me.Tasa.Text = "Tasa Amortizacion"
        '
        'txtVidaUtil
        '
        Me.txtVidaUtil.Location = New System.Drawing.Point(147, 254)
        Me.txtVidaUtil.Name = "txtVidaUtil"
        Me.txtVidaUtil.Size = New System.Drawing.Size(107, 20)
        Me.txtVidaUtil.TabIndex = 9
        '
        'lblVidaUtil
        '
        Me.lblVidaUtil.AutoSize = True
        Me.lblVidaUtil.Location = New System.Drawing.Point(15, 258)
        Me.lblVidaUtil.Name = "lblVidaUtil"
        Me.lblVidaUtil.Size = New System.Drawing.Size(46, 13)
        Me.lblVidaUtil.TabIndex = 36
        Me.lblVidaUtil.Text = "Vida Útil"
        '
        'txtEstadoOperacion
        '
        Me.txtEstadoOperacion.Location = New System.Drawing.Point(147, 228)
        Me.txtEstadoOperacion.Name = "txtEstadoOperacion"
        Me.txtEstadoOperacion.Size = New System.Drawing.Size(25, 20)
        Me.txtEstadoOperacion.TabIndex = 8
        Me.txtEstadoOperacion.Text = "1"
        '
        'lblEstadoOperacion
        '
        Me.lblEstadoOperacion.AutoSize = True
        Me.lblEstadoOperacion.Location = New System.Drawing.Point(15, 232)
        Me.lblEstadoOperacion.Name = "lblEstadoOperacion"
        Me.lblEstadoOperacion.Size = New System.Drawing.Size(92, 13)
        Me.lblEstadoOperacion.TabIndex = 34
        Me.lblEstadoOperacion.Text = "Estado Operación"
        '
        'txtAmortizacion
        '
        Me.txtAmortizacion.Location = New System.Drawing.Point(147, 202)
        Me.txtAmortizacion.Name = "txtAmortizacion"
        Me.txtAmortizacion.Size = New System.Drawing.Size(262, 20)
        Me.txtAmortizacion.TabIndex = 7
        '
        'lblAmortizacion
        '
        Me.lblAmortizacion.AutoSize = True
        Me.lblAmortizacion.Location = New System.Drawing.Point(15, 206)
        Me.lblAmortizacion.Name = "lblAmortizacion"
        Me.lblAmortizacion.Size = New System.Drawing.Size(67, 13)
        Me.lblAmortizacion.TabIndex = 32
        Me.lblAmortizacion.Text = "Amortizacion"
        '
        'txtValorDelIntangible
        '
        Me.txtValorDelIntangible.Location = New System.Drawing.Point(147, 176)
        Me.txtValorDelIntangible.Name = "txtValorDelIntangible"
        Me.txtValorDelIntangible.Size = New System.Drawing.Size(107, 20)
        Me.txtValorDelIntangible.TabIndex = 6
        '
        'lblValorDelIntangible
        '
        Me.lblValorDelIntangible.AutoSize = True
        Me.lblValorDelIntangible.Location = New System.Drawing.Point(15, 180)
        Me.lblValorDelIntangible.Name = "lblValorDelIntangible"
        Me.lblValorDelIntangible.Size = New System.Drawing.Size(97, 13)
        Me.lblValorDelIntangible.TabIndex = 30
        Me.lblValorDelIntangible.Text = "Valor del Intangible"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(147, 150)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(262, 20)
        Me.txtDescripcion.TabIndex = 5
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(15, 154)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 28
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtCodigoCuentaContable
        '
        Me.txtCodigoCuentaContable.Location = New System.Drawing.Point(147, 124)
        Me.txtCodigoCuentaContable.Name = "txtCodigoCuentaContable"
        Me.txtCodigoCuentaContable.Size = New System.Drawing.Size(107, 20)
        Me.txtCodigoCuentaContable.TabIndex = 4
        '
        'lblCodCtaCtble
        '
        Me.lblCodCtaCtble.AutoSize = True
        Me.lblCodCtaCtble.Location = New System.Drawing.Point(15, 128)
        Me.lblCodCtaCtble.Name = "lblCodCtaCtble"
        Me.lblCodCtaCtble.Size = New System.Drawing.Size(104, 13)
        Me.lblCodCtaCtble.TabIndex = 26
        Me.lblCodCtaCtble.Text = "Codigo Cta Contable"
        '
        'dtpFechaOperacion
        '
        Me.dtpFechaOperacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaOperacion.Location = New System.Drawing.Point(147, 98)
        Me.dtpFechaOperacion.Name = "dtpFechaOperacion"
        Me.dtpFechaOperacion.Size = New System.Drawing.Size(107, 20)
        Me.dtpFechaOperacion.TabIndex = 3
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(15, 102)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 24
        Me.lblFecha.Text = "Fecha"
        '
        'txtCorrelativo
        '
        Me.txtCorrelativo.Location = New System.Drawing.Point(147, 70)
        Me.txtCorrelativo.Name = "txtCorrelativo"
        Me.txtCorrelativo.ReadOnly = True
        Me.txtCorrelativo.Size = New System.Drawing.Size(107, 20)
        Me.txtCorrelativo.TabIndex = 2
        '
        'lblCorrelativo
        '
        Me.lblCorrelativo.AutoSize = True
        Me.lblCorrelativo.Location = New System.Drawing.Point(15, 74)
        Me.lblCorrelativo.Name = "lblCorrelativo"
        Me.lblCorrelativo.Size = New System.Drawing.Size(57, 13)
        Me.lblCorrelativo.TabIndex = 22
        Me.lblCorrelativo.Text = "Correlativo"
        '
        'txtCUO
        '
        Me.txtCUO.Location = New System.Drawing.Point(147, 44)
        Me.txtCUO.Name = "txtCUO"
        Me.txtCUO.Size = New System.Drawing.Size(107, 20)
        Me.txtCUO.TabIndex = 1
        '
        'lblCUO
        '
        Me.lblCUO.AutoSize = True
        Me.lblCUO.Location = New System.Drawing.Point(15, 48)
        Me.lblCUO.Name = "lblCUO"
        Me.lblCUO.Size = New System.Drawing.Size(123, 13)
        Me.lblCUO.TabIndex = 20
        Me.lblCUO.Text = "Codigo Unico Operación"
        '
        'pnlBoton
        '
        Me.pnlBoton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBoton.Controls.Add(Me.btnGuardar)
        Me.pnlBoton.Controls.Add(Me.btnCancelar)
        Me.pnlBoton.Location = New System.Drawing.Point(115, 346)
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
        Me.txtPeriodo.Location = New System.Drawing.Point(147, 18)
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ReadOnly = True
        Me.txtPeriodo.Size = New System.Drawing.Size(107, 20)
        Me.txtPeriodo.TabIndex = 0
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
        'frm0309
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 608)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "frm0309"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Saldo Cta 34"
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
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents gbConsulta As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_año As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents btn_consultar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tpDetalles As System.Windows.Forms.TabPage
    Friend WithEvents gbComprobante As System.Windows.Forms.GroupBox
    Friend WithEvents pnlBoton As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtCorrelativo As System.Windows.Forms.TextBox
    Friend WithEvents lblCorrelativo As System.Windows.Forms.Label
    Friend WithEvents txtCUO As System.Windows.Forms.TextBox
    Friend WithEvents lblCUO As System.Windows.Forms.Label
    Friend WithEvents dtpFechaOperacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents txtCodigoCuentaContable As System.Windows.Forms.TextBox
    Friend WithEvents lblCodCtaCtble As System.Windows.Forms.Label
    Friend WithEvents txtValorDelIntangible As System.Windows.Forms.TextBox
    Friend WithEvents lblValorDelIntangible As System.Windows.Forms.Label
    Friend WithEvents txtCodigoInterno As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoInterno As System.Windows.Forms.Label
    Friend WithEvents txtTasa As System.Windows.Forms.TextBox
    Friend WithEvents Tasa As System.Windows.Forms.Label
    Friend WithEvents txtVidaUtil As System.Windows.Forms.TextBox
    Friend WithEvents lblVidaUtil As System.Windows.Forms.Label
    Friend WithEvents txtEstadoOperacion As System.Windows.Forms.TextBox
    Friend WithEvents lblEstadoOperacion As System.Windows.Forms.Label
    Friend WithEvents txtAmortizacion As System.Windows.Forms.TextBox
    Friend WithEvents lblAmortizacion As System.Windows.Forms.Label
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
End Class
