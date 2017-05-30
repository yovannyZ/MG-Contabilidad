<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm031601
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
        Me.txtEstadoOperacion = New System.Windows.Forms.TextBox
        Me.pnlBoton = New System.Windows.Forms.Panel
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.dtpFechaAumentoCapital = New System.Windows.Forms.DateTimePicker
        Me.txtAumentoCapital = New System.Windows.Forms.TextBox
        Me.txtNroAccionistas = New System.Windows.Forms.TextBox
        Me.txtNroAccionesPagadas = New System.Windows.Forms.TextBox
        Me.txtNroAccionesSuscritas = New System.Windows.Forms.TextBox
        Me.txtValorNominal = New System.Windows.Forms.TextBox
        Me.txtImporteCapital = New System.Windows.Forms.TextBox
        Me.txtPeriodo = New System.Windows.Forms.TextBox
        Me.lblFechaAumentoCapital = New System.Windows.Forms.Label
        Me.lblAumentoCapital = New System.Windows.Forms.Label
        Me.lblNroAccionistas = New System.Windows.Forms.Label
        Me.lblEstadoOperacion = New System.Windows.Forms.Label
        Me.lblNroAccionesPagadas = New System.Windows.Forms.Label
        Me.lblNroAccionesSucritas = New System.Windows.Forms.Label
        Me.lblValorNominal = New System.Windows.Forms.Label
        Me.lblImporteCapital = New System.Windows.Forms.Label
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
        Me.Column2.HeaderText = "Capital Social"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Valor Nominal"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Nro Acciones Suscritas"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Nro Acciones Pagadas"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Est Ope"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Numero Accionistas"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Aumento Capital"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Fecha Aumento Capital"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
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
        Me.gbComprobante.Controls.Add(Me.txtEstadoOperacion)
        Me.gbComprobante.Controls.Add(Me.pnlBoton)
        Me.gbComprobante.Controls.Add(Me.dtpFechaAumentoCapital)
        Me.gbComprobante.Controls.Add(Me.txtAumentoCapital)
        Me.gbComprobante.Controls.Add(Me.txtNroAccionistas)
        Me.gbComprobante.Controls.Add(Me.txtNroAccionesPagadas)
        Me.gbComprobante.Controls.Add(Me.txtNroAccionesSuscritas)
        Me.gbComprobante.Controls.Add(Me.txtValorNominal)
        Me.gbComprobante.Controls.Add(Me.txtImporteCapital)
        Me.gbComprobante.Controls.Add(Me.txtPeriodo)
        Me.gbComprobante.Controls.Add(Me.lblFechaAumentoCapital)
        Me.gbComprobante.Controls.Add(Me.lblAumentoCapital)
        Me.gbComprobante.Controls.Add(Me.lblNroAccionistas)
        Me.gbComprobante.Controls.Add(Me.lblEstadoOperacion)
        Me.gbComprobante.Controls.Add(Me.lblNroAccionesPagadas)
        Me.gbComprobante.Controls.Add(Me.lblNroAccionesSucritas)
        Me.gbComprobante.Controls.Add(Me.lblValorNominal)
        Me.gbComprobante.Controls.Add(Me.lblImporteCapital)
        Me.gbComprobante.Controls.Add(Me.lblPeriodo)
        Me.gbComprobante.Location = New System.Drawing.Point(198, 8)
        Me.gbComprobante.Name = "gbComprobante"
        Me.gbComprobante.Size = New System.Drawing.Size(334, 326)
        Me.gbComprobante.TabIndex = 0
        Me.gbComprobante.TabStop = False
        Me.gbComprobante.Text = "Comprobante"
        '
        'txtEstadoOperacion
        '
        Me.txtEstadoOperacion.Location = New System.Drawing.Point(130, 165)
        Me.txtEstadoOperacion.MaxLength = 1
        Me.txtEstadoOperacion.Name = "txtEstadoOperacion"
        Me.txtEstadoOperacion.Size = New System.Drawing.Size(26, 20)
        Me.txtEstadoOperacion.TabIndex = 15
        Me.txtEstadoOperacion.Text = "1"
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
        'dtpFechaAumentoCapital
        '
        Me.dtpFechaAumentoCapital.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAumentoCapital.Location = New System.Drawing.Point(153, 245)
        Me.dtpFechaAumentoCapital.Name = "dtpFechaAumentoCapital"
        Me.dtpFechaAumentoCapital.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaAumentoCapital.TabIndex = 18
        '
        'txtAumentoCapital
        '
        Me.txtAumentoCapital.Location = New System.Drawing.Point(130, 216)
        Me.txtAumentoCapital.Name = "txtAumentoCapital"
        Me.txtAumentoCapital.Size = New System.Drawing.Size(145, 20)
        Me.txtAumentoCapital.TabIndex = 17
        '
        'txtNroAccionistas
        '
        Me.txtNroAccionistas.Location = New System.Drawing.Point(130, 189)
        Me.txtNroAccionistas.Name = "txtNroAccionistas"
        Me.txtNroAccionistas.Size = New System.Drawing.Size(145, 20)
        Me.txtNroAccionistas.TabIndex = 16
        '
        'txtNroAccionesPagadas
        '
        Me.txtNroAccionesPagadas.Location = New System.Drawing.Point(130, 140)
        Me.txtNroAccionesPagadas.Name = "txtNroAccionesPagadas"
        Me.txtNroAccionesPagadas.Size = New System.Drawing.Size(145, 20)
        Me.txtNroAccionesPagadas.TabIndex = 14
        '
        'txtNroAccionesSuscritas
        '
        Me.txtNroAccionesSuscritas.Location = New System.Drawing.Point(130, 111)
        Me.txtNroAccionesSuscritas.Name = "txtNroAccionesSuscritas"
        Me.txtNroAccionesSuscritas.Size = New System.Drawing.Size(145, 20)
        Me.txtNroAccionesSuscritas.TabIndex = 13
        '
        'txtValorNominal
        '
        Me.txtValorNominal.Location = New System.Drawing.Point(130, 82)
        Me.txtValorNominal.Name = "txtValorNominal"
        Me.txtValorNominal.Size = New System.Drawing.Size(145, 20)
        Me.txtValorNominal.TabIndex = 12
        '
        'txtImporteCapital
        '
        Me.txtImporteCapital.Location = New System.Drawing.Point(130, 48)
        Me.txtImporteCapital.Name = "txtImporteCapital"
        Me.txtImporteCapital.Size = New System.Drawing.Size(145, 20)
        Me.txtImporteCapital.TabIndex = 11
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Location = New System.Drawing.Point(131, 18)
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(107, 20)
        Me.txtPeriodo.TabIndex = 10
        '
        'lblFechaAumentoCapital
        '
        Me.lblFechaAumentoCapital.AutoSize = True
        Me.lblFechaAumentoCapital.Location = New System.Drawing.Point(15, 249)
        Me.lblFechaAumentoCapital.Name = "lblFechaAumentoCapital"
        Me.lblFechaAumentoCapital.Size = New System.Drawing.Size(132, 13)
        Me.lblFechaAumentoCapital.TabIndex = 9
        Me.lblFechaAumentoCapital.Text = "Fecha Aumento de Capital"
        '
        'lblAumentoCapital
        '
        Me.lblAumentoCapital.AutoSize = True
        Me.lblAumentoCapital.Location = New System.Drawing.Point(15, 220)
        Me.lblAumentoCapital.Name = "lblAumentoCapital"
        Me.lblAumentoCapital.Size = New System.Drawing.Size(99, 13)
        Me.lblAumentoCapital.TabIndex = 8
        Me.lblAumentoCapital.Text = "Aumento de Capital"
        '
        'lblNroAccionistas
        '
        Me.lblNroAccionistas.AutoSize = True
        Me.lblNroAccionistas.Location = New System.Drawing.Point(15, 193)
        Me.lblNroAccionistas.Name = "lblNroAccionistas"
        Me.lblNroAccionistas.Size = New System.Drawing.Size(81, 13)
        Me.lblNroAccionistas.TabIndex = 6
        Me.lblNroAccionistas.Text = "Nro Accionistas"
        '
        'lblEstadoOperacion
        '
        Me.lblEstadoOperacion.AutoSize = True
        Me.lblEstadoOperacion.Location = New System.Drawing.Point(15, 169)
        Me.lblEstadoOperacion.Name = "lblEstadoOperacion"
        Me.lblEstadoOperacion.Size = New System.Drawing.Size(77, 13)
        Me.lblEstadoOperacion.TabIndex = 5
        Me.lblEstadoOperacion.Text = "Est. Operación"
        '
        'lblNroAccionesPagadas
        '
        Me.lblNroAccionesPagadas.AutoSize = True
        Me.lblNroAccionesPagadas.Location = New System.Drawing.Point(15, 144)
        Me.lblNroAccionesPagadas.Name = "lblNroAccionesPagadas"
        Me.lblNroAccionesPagadas.Size = New System.Drawing.Size(116, 13)
        Me.lblNroAccionesPagadas.TabIndex = 4
        Me.lblNroAccionesPagadas.Text = "Nro Acciones Pagadas"
        '
        'lblNroAccionesSucritas
        '
        Me.lblNroAccionesSucritas.AutoSize = True
        Me.lblNroAccionesSucritas.Location = New System.Drawing.Point(15, 115)
        Me.lblNroAccionesSucritas.Name = "lblNroAccionesSucritas"
        Me.lblNroAccionesSucritas.Size = New System.Drawing.Size(112, 13)
        Me.lblNroAccionesSucritas.TabIndex = 3
        Me.lblNroAccionesSucritas.Text = "Nro Acciones Sucritas"
        '
        'lblValorNominal
        '
        Me.lblValorNominal.AutoSize = True
        Me.lblValorNominal.Location = New System.Drawing.Point(15, 86)
        Me.lblValorNominal.Name = "lblValorNominal"
        Me.lblValorNominal.Size = New System.Drawing.Size(72, 13)
        Me.lblValorNominal.TabIndex = 2
        Me.lblValorNominal.Text = "Valor Nominal"
        '
        'lblImporteCapital
        '
        Me.lblImporteCapital.AutoSize = True
        Me.lblImporteCapital.Location = New System.Drawing.Point(15, 52)
        Me.lblImporteCapital.Name = "lblImporteCapital"
        Me.lblImporteCapital.Size = New System.Drawing.Size(94, 13)
        Me.lblImporteCapital.TabIndex = 1
        Me.lblImporteCapital.Text = "Importe del Capital"
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
        'frm031601
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 608)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frm031601"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "3.16.1 Detalle del saldo de la cuenta 50"
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
    Friend WithEvents lblNroAccionistas As System.Windows.Forms.Label
    Friend WithEvents lblEstadoOperacion As System.Windows.Forms.Label
    Friend WithEvents lblNroAccionesPagadas As System.Windows.Forms.Label
    Friend WithEvents lblNroAccionesSucritas As System.Windows.Forms.Label
    Friend WithEvents lblValorNominal As System.Windows.Forms.Label
    Friend WithEvents lblImporteCapital As System.Windows.Forms.Label
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents txtAumentoCapital As System.Windows.Forms.TextBox
    Friend WithEvents txtNroAccionistas As System.Windows.Forms.TextBox
    Friend WithEvents txtNroAccionesPagadas As System.Windows.Forms.TextBox
    Friend WithEvents txtNroAccionesSuscritas As System.Windows.Forms.TextBox
    Friend WithEvents txtValorNominal As System.Windows.Forms.TextBox
    Friend WithEvents txtImporteCapital As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaAumentoCapital As System.Windows.Forms.Label
    Friend WithEvents lblAumentoCapital As System.Windows.Forms.Label
    Friend WithEvents dtpFechaAumentoCapital As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlBoton As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtEstadoOperacion As System.Windows.Forms.TextBox
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
