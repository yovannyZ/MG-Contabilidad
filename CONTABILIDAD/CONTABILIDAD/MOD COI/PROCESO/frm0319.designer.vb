<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm0319
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
        Me.cDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cMonto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column27 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column28 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column29 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtResultadoEjercicio = New System.Windows.Forms.TextBox
        Me.lblResultadoEjercicio = New System.Windows.Forms.Label
        Me.txtExcedenteRevaluacion = New System.Windows.Forms.TextBox
        Me.lblExcedenteRevaluacion = New System.Windows.Forms.Label
        Me.txtResultadoNetoEjercicio = New System.Windows.Forms.TextBox
        Me.lblResultadoNetoEjercicio = New System.Windows.Forms.Label
        Me.txtAjustesAlPatrimonio = New System.Windows.Forms.TextBox
        Me.lblAjustesPatrimonio = New System.Windows.Forms.Label
        Me.txtDiferenciasConversion = New System.Windows.Forms.TextBox
        Me.lblDiferenciasConversion = New System.Windows.Forms.Label
        Me.txtResultadoAcumulados = New System.Windows.Forms.TextBox
        Me.lblResultadosAcumulados = New System.Windows.Forms.Label
        Me.txtOtrasReservas = New System.Windows.Forms.TextBox
        Me.lblOtrasReservas = New System.Windows.Forms.Label
        Me.txtReservasLegales = New System.Windows.Forms.TextBox
        Me.lblReservasLegales = New System.Windows.Forms.Label
        Me.txtResultadoNoRealizado = New System.Windows.Forms.TextBox
        Me.lblResultadosNoRealizados = New System.Windows.Forms.Label
        Me.txtCapitalAdicional = New System.Windows.Forms.TextBox
        Me.lblCapitalAdicional = New System.Windows.Forms.Label
        Me.txtAccionesInversion = New System.Windows.Forms.TextBox
        Me.lblAccionesInversion = New System.Windows.Forms.Label
        Me.txtRubroEstadoFinanciero = New System.Windows.Forms.TextBox
        Me.txtNombreRubro = New System.Windows.Forms.TextBox
        Me.txtEstadoOperacion = New System.Windows.Forms.TextBox
        Me.txtCapital = New System.Windows.Forms.TextBox
        Me.cboCatalogo = New System.Windows.Forms.ComboBox
        Me.pnlBoton = New System.Windows.Forms.Panel
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtPeriodo = New System.Windows.Forms.TextBox
        Me.lblEstadoOperacion = New System.Windows.Forms.Label
        Me.lblNombreRubro = New System.Windows.Forms.Label
        Me.lblCapital = New System.Windows.Forms.Label
        Me.lblCodigoRubroFinanciero = New System.Windows.Forms.Label
        Me.lblCatalogo = New System.Windows.Forms.Label
        Me.lblPeriodo = New System.Windows.Forms.Label
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column8, Me.Column9, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column5, Me.Column6})
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
        Me.gbConsulta.Location = New System.Drawing.Point(133, 7)
        Me.gbConsulta.Margin = New System.Windows.Forms.Padding(0)
        Me.gbConsulta.Name = "gbConsulta"
        Me.gbConsulta.Padding = New System.Windows.Forms.Padding(0)
        Me.gbConsulta.Size = New System.Drawing.Size(464, 60)
        Me.gbConsulta.TabIndex = 1
        Me.gbConsulta.TabStop = False
        Me.gbConsulta.Text = "Consulta"
        '
        'cbo_año
        '
        Me.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año.FormattingEnabled = True
        Me.cbo_año.Location = New System.Drawing.Point(50, 23)
        Me.cbo_año.Name = "cbo_año"
        Me.cbo_año.Size = New System.Drawing.Size(79, 22)
        Me.cbo_año.TabIndex = 1
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(187, 23)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(135, 22)
        Me.cbo_mes.TabIndex = 3
        '
        'btn_consultar
        '
        Me.btn_consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_consultar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Search_1
        Me.btn_consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consultar.Location = New System.Drawing.Point(356, 19)
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
        Me.Label1.Location = New System.Drawing.Point(12, 27)
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
        Me.Label4.Location = New System.Drawing.Point(148, 27)
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
        Me.gbComprobante.Controls.Add(Me.txtResultadoEjercicio)
        Me.gbComprobante.Controls.Add(Me.lblResultadoEjercicio)
        Me.gbComprobante.Controls.Add(Me.txtExcedenteRevaluacion)
        Me.gbComprobante.Controls.Add(Me.lblExcedenteRevaluacion)
        Me.gbComprobante.Controls.Add(Me.txtResultadoNetoEjercicio)
        Me.gbComprobante.Controls.Add(Me.lblResultadoNetoEjercicio)
        Me.gbComprobante.Controls.Add(Me.txtAjustesAlPatrimonio)
        Me.gbComprobante.Controls.Add(Me.lblAjustesPatrimonio)
        Me.gbComprobante.Controls.Add(Me.txtDiferenciasConversion)
        Me.gbComprobante.Controls.Add(Me.lblDiferenciasConversion)
        Me.gbComprobante.Controls.Add(Me.txtResultadoAcumulados)
        Me.gbComprobante.Controls.Add(Me.lblResultadosAcumulados)
        Me.gbComprobante.Controls.Add(Me.txtOtrasReservas)
        Me.gbComprobante.Controls.Add(Me.lblOtrasReservas)
        Me.gbComprobante.Controls.Add(Me.txtReservasLegales)
        Me.gbComprobante.Controls.Add(Me.lblReservasLegales)
        Me.gbComprobante.Controls.Add(Me.txtResultadoNoRealizado)
        Me.gbComprobante.Controls.Add(Me.lblResultadosNoRealizados)
        Me.gbComprobante.Controls.Add(Me.txtCapitalAdicional)
        Me.gbComprobante.Controls.Add(Me.lblCapitalAdicional)
        Me.gbComprobante.Controls.Add(Me.txtAccionesInversion)
        Me.gbComprobante.Controls.Add(Me.lblAccionesInversion)
        Me.gbComprobante.Controls.Add(Me.txtRubroEstadoFinanciero)
        Me.gbComprobante.Controls.Add(Me.txtNombreRubro)
        Me.gbComprobante.Controls.Add(Me.txtEstadoOperacion)
        Me.gbComprobante.Controls.Add(Me.txtCapital)
        Me.gbComprobante.Controls.Add(Me.cboCatalogo)
        Me.gbComprobante.Controls.Add(Me.pnlBoton)
        Me.gbComprobante.Controls.Add(Me.txtPeriodo)
        Me.gbComprobante.Controls.Add(Me.lblEstadoOperacion)
        Me.gbComprobante.Controls.Add(Me.lblNombreRubro)
        Me.gbComprobante.Controls.Add(Me.lblCapital)
        Me.gbComprobante.Controls.Add(Me.lblCodigoRubroFinanciero)
        Me.gbComprobante.Controls.Add(Me.lblCatalogo)
        Me.gbComprobante.Controls.Add(Me.lblPeriodo)
        Me.gbComprobante.Location = New System.Drawing.Point(7, 8)
        Me.gbComprobante.Name = "gbComprobante"
        Me.gbComprobante.Size = New System.Drawing.Size(717, 538)
        Me.gbComprobante.TabIndex = 0
        Me.gbComprobante.TabStop = False
        Me.gbComprobante.Text = "Comprobante"
        '
        'gbActivos
        '
        Me.gbActivos.Controls.Add(Me.dgvActivos)
        Me.gbActivos.Location = New System.Drawing.Point(6, 102)
        Me.gbActivos.Name = "gbActivos"
        Me.gbActivos.Size = New System.Drawing.Size(705, 367)
        Me.gbActivos.TabIndex = 41
        Me.gbActivos.TabStop = False
        Me.gbActivos.Text = "Activos"
        '
        'dgvActivos
        '
        Me.dgvActivos.AllowUserToAddRows = False
        Me.dgvActivos.AllowUserToDeleteRows = False
        Me.dgvActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvActivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cDescripcion, Me.cCodigo, Me.cMonto, Me.Column7, Me.Column20, Me.Column21, Me.Column22, Me.Column23, Me.Column24, Me.Column25, Me.Column26, Me.Column27, Me.Column28, Me.Column29})
        Me.dgvActivos.Location = New System.Drawing.Point(6, 19)
        Me.dgvActivos.Name = "dgvActivos"
        Me.dgvActivos.Size = New System.Drawing.Size(690, 329)
        Me.dgvActivos.TabIndex = 0
        '
        'cDescripcion
        '
        Me.cDescripcion.HeaderText = "Descripción"
        Me.cDescripcion.Name = "cDescripcion"
        Me.cDescripcion.ReadOnly = True
        Me.cDescripcion.Width = 360
        '
        'cCodigo
        '
        Me.cCodigo.HeaderText = "Código"
        Me.cCodigo.Name = "cCodigo"
        Me.cCodigo.ReadOnly = True
        Me.cCodigo.Width = 70
        '
        'cMonto
        '
        Me.cMonto.HeaderText = "Capital"
        Me.cMonto.Name = "cMonto"
        Me.cMonto.Width = 110
        '
        'Column7
        '
        Me.Column7.HeaderText = "Acciones de Inversión"
        Me.Column7.Name = "Column7"
        '
        'Column20
        '
        Me.Column20.HeaderText = "Capital Adicional"
        Me.Column20.Name = "Column20"
        '
        'Column21
        '
        Me.Column21.HeaderText = "Resultados No Realizados"
        Me.Column21.Name = "Column21"
        '
        'Column22
        '
        Me.Column22.HeaderText = "Reservas Legales"
        Me.Column22.Name = "Column22"
        '
        'Column23
        '
        Me.Column23.HeaderText = "Otras Reservas"
        Me.Column23.Name = "Column23"
        '
        'Column24
        '
        Me.Column24.HeaderText = "Resultados Acumulados"
        Me.Column24.Name = "Column24"
        '
        'Column25
        '
        Me.Column25.HeaderText = "Diferencias de Conversión"
        Me.Column25.Name = "Column25"
        '
        'Column26
        '
        Me.Column26.HeaderText = "Ajustes al Patrimonio"
        Me.Column26.Name = "Column26"
        '
        'Column27
        '
        Me.Column27.HeaderText = "Resultado Neto del Ejercicio"
        Me.Column27.Name = "Column27"
        '
        'Column28
        '
        Me.Column28.HeaderText = "Excedente de Ravaluación"
        Me.Column28.Name = "Column28"
        '
        'Column29
        '
        Me.Column29.HeaderText = "Resultado del Ejercicio"
        Me.Column29.Name = "Column29"
        '
        'txtResultadoEjercicio
        '
        Me.txtResultadoEjercicio.Location = New System.Drawing.Point(279, 397)
        Me.txtResultadoEjercicio.Name = "txtResultadoEjercicio"
        Me.txtResultadoEjercicio.Size = New System.Drawing.Size(199, 20)
        Me.txtResultadoEjercicio.TabIndex = 14
        '
        'lblResultadoEjercicio
        '
        Me.lblResultadoEjercicio.AutoSize = True
        Me.lblResultadoEjercicio.Location = New System.Drawing.Point(131, 401)
        Me.lblResultadoEjercicio.Name = "lblResultadoEjercicio"
        Me.lblResultadoEjercicio.Size = New System.Drawing.Size(115, 13)
        Me.lblResultadoEjercicio.TabIndex = 40
        Me.lblResultadoEjercicio.Text = "Resultado del Ejercicio"
        '
        'txtExcedenteRevaluacion
        '
        Me.txtExcedenteRevaluacion.Location = New System.Drawing.Point(279, 371)
        Me.txtExcedenteRevaluacion.Name = "txtExcedenteRevaluacion"
        Me.txtExcedenteRevaluacion.Size = New System.Drawing.Size(199, 20)
        Me.txtExcedenteRevaluacion.TabIndex = 13
        '
        'lblExcedenteRevaluacion
        '
        Me.lblExcedenteRevaluacion.AutoSize = True
        Me.lblExcedenteRevaluacion.Location = New System.Drawing.Point(131, 375)
        Me.lblExcedenteRevaluacion.Name = "lblExcedenteRevaluacion"
        Me.lblExcedenteRevaluacion.Size = New System.Drawing.Size(138, 13)
        Me.lblExcedenteRevaluacion.TabIndex = 38
        Me.lblExcedenteRevaluacion.Text = "Excedente De Revaluación"
        '
        'txtResultadoNetoEjercicio
        '
        Me.txtResultadoNetoEjercicio.Location = New System.Drawing.Point(279, 345)
        Me.txtResultadoNetoEjercicio.Name = "txtResultadoNetoEjercicio"
        Me.txtResultadoNetoEjercicio.Size = New System.Drawing.Size(199, 20)
        Me.txtResultadoNetoEjercicio.TabIndex = 12
        '
        'lblResultadoNetoEjercicio
        '
        Me.lblResultadoNetoEjercicio.AutoSize = True
        Me.lblResultadoNetoEjercicio.Location = New System.Drawing.Point(131, 349)
        Me.lblResultadoNetoEjercicio.Name = "lblResultadoNetoEjercicio"
        Me.lblResultadoNetoEjercicio.Size = New System.Drawing.Size(141, 13)
        Me.lblResultadoNetoEjercicio.TabIndex = 36
        Me.lblResultadoNetoEjercicio.Text = "Resultado Neto del Ejercicio"
        '
        'txtAjustesAlPatrimonio
        '
        Me.txtAjustesAlPatrimonio.Location = New System.Drawing.Point(279, 319)
        Me.txtAjustesAlPatrimonio.Name = "txtAjustesAlPatrimonio"
        Me.txtAjustesAlPatrimonio.Size = New System.Drawing.Size(199, 20)
        Me.txtAjustesAlPatrimonio.TabIndex = 11
        '
        'lblAjustesPatrimonio
        '
        Me.lblAjustesPatrimonio.AutoSize = True
        Me.lblAjustesPatrimonio.Location = New System.Drawing.Point(131, 323)
        Me.lblAjustesPatrimonio.Name = "lblAjustesPatrimonio"
        Me.lblAjustesPatrimonio.Size = New System.Drawing.Size(104, 13)
        Me.lblAjustesPatrimonio.TabIndex = 34
        Me.lblAjustesPatrimonio.Text = "Ajustes al Patrimonio"
        '
        'txtDiferenciasConversion
        '
        Me.txtDiferenciasConversion.Location = New System.Drawing.Point(279, 293)
        Me.txtDiferenciasConversion.Name = "txtDiferenciasConversion"
        Me.txtDiferenciasConversion.Size = New System.Drawing.Size(199, 20)
        Me.txtDiferenciasConversion.TabIndex = 10
        '
        'lblDiferenciasConversion
        '
        Me.lblDiferenciasConversion.AutoSize = True
        Me.lblDiferenciasConversion.Location = New System.Drawing.Point(131, 297)
        Me.lblDiferenciasConversion.Name = "lblDiferenciasConversion"
        Me.lblDiferenciasConversion.Size = New System.Drawing.Size(131, 13)
        Me.lblDiferenciasConversion.TabIndex = 32
        Me.lblDiferenciasConversion.Text = "Diferencias de Conversión"
        '
        'txtResultadoAcumulados
        '
        Me.txtResultadoAcumulados.Location = New System.Drawing.Point(279, 267)
        Me.txtResultadoAcumulados.Name = "txtResultadoAcumulados"
        Me.txtResultadoAcumulados.Size = New System.Drawing.Size(199, 20)
        Me.txtResultadoAcumulados.TabIndex = 9
        '
        'lblResultadosAcumulados
        '
        Me.lblResultadosAcumulados.AutoSize = True
        Me.lblResultadosAcumulados.Location = New System.Drawing.Point(131, 271)
        Me.lblResultadosAcumulados.Name = "lblResultadosAcumulados"
        Me.lblResultadosAcumulados.Size = New System.Drawing.Size(121, 13)
        Me.lblResultadosAcumulados.TabIndex = 30
        Me.lblResultadosAcumulados.Text = "Resultados Acumulados"
        '
        'txtOtrasReservas
        '
        Me.txtOtrasReservas.Location = New System.Drawing.Point(279, 241)
        Me.txtOtrasReservas.Name = "txtOtrasReservas"
        Me.txtOtrasReservas.Size = New System.Drawing.Size(199, 20)
        Me.txtOtrasReservas.TabIndex = 8
        '
        'lblOtrasReservas
        '
        Me.lblOtrasReservas.AutoSize = True
        Me.lblOtrasReservas.Location = New System.Drawing.Point(131, 245)
        Me.lblOtrasReservas.Name = "lblOtrasReservas"
        Me.lblOtrasReservas.Size = New System.Drawing.Size(80, 13)
        Me.lblOtrasReservas.TabIndex = 28
        Me.lblOtrasReservas.Text = "Otras Reservas"
        '
        'txtReservasLegales
        '
        Me.txtReservasLegales.Location = New System.Drawing.Point(279, 215)
        Me.txtReservasLegales.Name = "txtReservasLegales"
        Me.txtReservasLegales.Size = New System.Drawing.Size(199, 20)
        Me.txtReservasLegales.TabIndex = 7
        '
        'lblReservasLegales
        '
        Me.lblReservasLegales.AutoSize = True
        Me.lblReservasLegales.Location = New System.Drawing.Point(131, 219)
        Me.lblReservasLegales.Name = "lblReservasLegales"
        Me.lblReservasLegales.Size = New System.Drawing.Size(92, 13)
        Me.lblReservasLegales.TabIndex = 26
        Me.lblReservasLegales.Text = "Reservas Legales"
        '
        'txtResultadoNoRealizado
        '
        Me.txtResultadoNoRealizado.Location = New System.Drawing.Point(279, 189)
        Me.txtResultadoNoRealizado.Name = "txtResultadoNoRealizado"
        Me.txtResultadoNoRealizado.Size = New System.Drawing.Size(199, 20)
        Me.txtResultadoNoRealizado.TabIndex = 6
        '
        'lblResultadosNoRealizados
        '
        Me.lblResultadosNoRealizados.AutoSize = True
        Me.lblResultadosNoRealizados.Location = New System.Drawing.Point(131, 193)
        Me.lblResultadosNoRealizados.Name = "lblResultadosNoRealizados"
        Me.lblResultadosNoRealizados.Size = New System.Drawing.Size(132, 13)
        Me.lblResultadosNoRealizados.TabIndex = 24
        Me.lblResultadosNoRealizados.Text = "Resultados No Realizados"
        '
        'txtCapitalAdicional
        '
        Me.txtCapitalAdicional.Location = New System.Drawing.Point(279, 163)
        Me.txtCapitalAdicional.Name = "txtCapitalAdicional"
        Me.txtCapitalAdicional.Size = New System.Drawing.Size(199, 20)
        Me.txtCapitalAdicional.TabIndex = 5
        '
        'lblCapitalAdicional
        '
        Me.lblCapitalAdicional.AutoSize = True
        Me.lblCapitalAdicional.Location = New System.Drawing.Point(131, 167)
        Me.lblCapitalAdicional.Name = "lblCapitalAdicional"
        Me.lblCapitalAdicional.Size = New System.Drawing.Size(85, 13)
        Me.lblCapitalAdicional.TabIndex = 22
        Me.lblCapitalAdicional.Text = "Capital Adicional"
        '
        'txtAccionesInversion
        '
        Me.txtAccionesInversion.Location = New System.Drawing.Point(279, 137)
        Me.txtAccionesInversion.Name = "txtAccionesInversion"
        Me.txtAccionesInversion.Size = New System.Drawing.Size(199, 20)
        Me.txtAccionesInversion.TabIndex = 4
        '
        'lblAccionesInversion
        '
        Me.lblAccionesInversion.AutoSize = True
        Me.lblAccionesInversion.Location = New System.Drawing.Point(131, 141)
        Me.lblAccionesInversion.Name = "lblAccionesInversion"
        Me.lblAccionesInversion.Size = New System.Drawing.Size(112, 13)
        Me.lblAccionesInversion.TabIndex = 20
        Me.lblAccionesInversion.Text = "Acciones de Inversión"
        '
        'txtRubroEstadoFinanciero
        '
        Me.txtRubroEstadoFinanciero.Location = New System.Drawing.Point(279, 422)
        Me.txtRubroEstadoFinanciero.MaxLength = 6
        Me.txtRubroEstadoFinanciero.Name = "txtRubroEstadoFinanciero"
        Me.txtRubroEstadoFinanciero.ReadOnly = True
        Me.txtRubroEstadoFinanciero.Size = New System.Drawing.Size(143, 20)
        Me.txtRubroEstadoFinanciero.TabIndex = 2
        '
        'txtNombreRubro
        '
        Me.txtNombreRubro.Location = New System.Drawing.Point(279, 449)
        Me.txtNombreRubro.Name = "txtNombreRubro"
        Me.txtNombreRubro.ReadOnly = True
        Me.txtNombreRubro.Size = New System.Drawing.Size(298, 20)
        Me.txtNombreRubro.TabIndex = 16
        '
        'txtEstadoOperacion
        '
        Me.txtEstadoOperacion.Location = New System.Drawing.Point(279, 76)
        Me.txtEstadoOperacion.MaxLength = 1
        Me.txtEstadoOperacion.Name = "txtEstadoOperacion"
        Me.txtEstadoOperacion.ReadOnly = True
        Me.txtEstadoOperacion.Size = New System.Drawing.Size(28, 20)
        Me.txtEstadoOperacion.TabIndex = 15
        Me.txtEstadoOperacion.Text = "1"
        '
        'txtCapital
        '
        Me.txtCapital.Location = New System.Drawing.Point(279, 111)
        Me.txtCapital.Name = "txtCapital"
        Me.txtCapital.Size = New System.Drawing.Size(199, 20)
        Me.txtCapital.TabIndex = 3
        '
        'cboCatalogo
        '
        Me.cboCatalogo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCatalogo.FormattingEnabled = True
        Me.cboCatalogo.Location = New System.Drawing.Point(279, 49)
        Me.cboCatalogo.Name = "cboCatalogo"
        Me.cboCatalogo.Size = New System.Drawing.Size(298, 21)
        Me.cboCatalogo.TabIndex = 1
        '
        'pnlBoton
        '
        Me.pnlBoton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBoton.Controls.Add(Me.btnGuardar)
        Me.pnlBoton.Controls.Add(Me.btnCancelar)
        Me.pnlBoton.Location = New System.Drawing.Point(268, 482)
        Me.pnlBoton.Name = "pnlBoton"
        Me.pnlBoton.Size = New System.Drawing.Size(179, 42)
        Me.pnlBoton.TabIndex = 19
        Me.pnlBoton.TabStop = True
        '
        'btnGuardar
        '
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.Location = New System.Drawing.Point(94, 6)
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
        Me.btnCancelar.Location = New System.Drawing.Point(6, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(77, 27)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Location = New System.Drawing.Point(279, 18)
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(107, 20)
        Me.txtPeriodo.TabIndex = 0
        '
        'lblEstadoOperacion
        '
        Me.lblEstadoOperacion.AutoSize = True
        Me.lblEstadoOperacion.Location = New System.Drawing.Point(131, 80)
        Me.lblEstadoOperacion.Name = "lblEstadoOperacion"
        Me.lblEstadoOperacion.Size = New System.Drawing.Size(92, 13)
        Me.lblEstadoOperacion.TabIndex = 8
        Me.lblEstadoOperacion.Text = "Estado Operacion"
        '
        'lblNombreRubro
        '
        Me.lblNombreRubro.AutoSize = True
        Me.lblNombreRubro.Location = New System.Drawing.Point(131, 453)
        Me.lblNombreRubro.Name = "lblNombreRubro"
        Me.lblNombreRubro.Size = New System.Drawing.Size(76, 13)
        Me.lblNombreRubro.TabIndex = 5
        Me.lblNombreRubro.Text = "Nombre Rubro"
        '
        'lblCapital
        '
        Me.lblCapital.AutoSize = True
        Me.lblCapital.Location = New System.Drawing.Point(131, 115)
        Me.lblCapital.Name = "lblCapital"
        Me.lblCapital.Size = New System.Drawing.Size(39, 13)
        Me.lblCapital.TabIndex = 3
        Me.lblCapital.Text = "Capital"
        '
        'lblCodigoRubroFinanciero
        '
        Me.lblCodigoRubroFinanciero.AutoSize = True
        Me.lblCodigoRubroFinanciero.Location = New System.Drawing.Point(131, 425)
        Me.lblCodigoRubroFinanciero.Name = "lblCodigoRubroFinanciero"
        Me.lblCodigoRubroFinanciero.Size = New System.Drawing.Size(72, 13)
        Me.lblCodigoRubroFinanciero.TabIndex = 2
        Me.lblCodigoRubroFinanciero.Text = "Codigo Rubro"
        '
        'lblCatalogo
        '
        Me.lblCatalogo.AutoSize = True
        Me.lblCatalogo.Location = New System.Drawing.Point(131, 53)
        Me.lblCatalogo.Name = "lblCatalogo"
        Me.lblCatalogo.Size = New System.Drawing.Size(49, 13)
        Me.lblCatalogo.TabIndex = 1
        Me.lblCatalogo.Text = "Catalogo"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Location = New System.Drawing.Point(131, 22)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(43, 13)
        Me.lblPeriodo.TabIndex = 0
        Me.lblPeriodo.Text = "Periodo"
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
        Me.Column3.HeaderText = "Cod Rubro"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.ToolTipText = "Codigo del rubro del Estado Financiero"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Capital"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Acciones de Inversion"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Capital Adicional"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "Resultados No Realizados"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "Reservas Legales"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "Otras Reservas"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "Resultados Acumulados"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.HeaderText = "Diferencias de Conversion"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column16
        '
        Me.Column16.HeaderText = "Ajustes al Patrimonio"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'Column17
        '
        Me.Column17.HeaderText = "Resultado Neto del Ejercicio"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        '
        'Column18
        '
        Me.Column18.HeaderText = "Excedente de Revaluación"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        '
        'Column19
        '
        Me.Column19.HeaderText = "Resultado del Ejercicio"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
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
        'frm0319
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 608)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frm0319"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "3.19 Libro de Inventarios y Balance - Estado de cambios en el patrimonio neto"
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
    Friend WithEvents lblCapital As System.Windows.Forms.Label
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
    Friend WithEvents txtCapital As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreRubro As System.Windows.Forms.TextBox
    Friend WithEvents txtRubroEstadoFinanciero As System.Windows.Forms.TextBox
    Friend WithEvents txtResultadoEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents lblResultadoEjercicio As System.Windows.Forms.Label
    Friend WithEvents txtExcedenteRevaluacion As System.Windows.Forms.TextBox
    Friend WithEvents lblExcedenteRevaluacion As System.Windows.Forms.Label
    Friend WithEvents txtResultadoNetoEjercicio As System.Windows.Forms.TextBox
    Friend WithEvents lblResultadoNetoEjercicio As System.Windows.Forms.Label
    Friend WithEvents txtAjustesAlPatrimonio As System.Windows.Forms.TextBox
    Friend WithEvents lblAjustesPatrimonio As System.Windows.Forms.Label
    Friend WithEvents txtDiferenciasConversion As System.Windows.Forms.TextBox
    Friend WithEvents lblDiferenciasConversion As System.Windows.Forms.Label
    Friend WithEvents txtResultadoAcumulados As System.Windows.Forms.TextBox
    Friend WithEvents lblResultadosAcumulados As System.Windows.Forms.Label
    Friend WithEvents txtOtrasReservas As System.Windows.Forms.TextBox
    Friend WithEvents lblOtrasReservas As System.Windows.Forms.Label
    Friend WithEvents txtReservasLegales As System.Windows.Forms.TextBox
    Friend WithEvents lblReservasLegales As System.Windows.Forms.Label
    Friend WithEvents txtResultadoNoRealizado As System.Windows.Forms.TextBox
    Friend WithEvents lblResultadosNoRealizados As System.Windows.Forms.Label
    Friend WithEvents txtCapitalAdicional As System.Windows.Forms.TextBox
    Friend WithEvents lblCapitalAdicional As System.Windows.Forms.Label
    Friend WithEvents txtAccionesInversion As System.Windows.Forms.TextBox
    Friend WithEvents lblAccionesInversion As System.Windows.Forms.Label
    Friend WithEvents gbActivos As System.Windows.Forms.GroupBox
    Friend WithEvents dgvActivos As System.Windows.Forms.DataGridView
    Friend WithEvents cDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
