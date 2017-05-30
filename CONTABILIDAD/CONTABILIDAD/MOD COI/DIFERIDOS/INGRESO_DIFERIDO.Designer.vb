<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class INGRESO_DIFERIDO
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
        Me.btn_op = New System.Windows.Forms.Button
        Me.BTN_CANCELAR = New System.Windows.Forms.Button
        Me.btn_Eliminar = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_TRansf = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.gbDatosContabilidad = New System.Windows.Forms.GroupBox
        Me.btnDiferir = New System.Windows.Forms.Button
        Me.cboCuenta = New System.Windows.Forms.ComboBox
        Me.txtCodComprobante = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtAuxiliar = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtNroCuotas = New System.Windows.Forms.TextBox
        Me.txtNroDoc = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpFechaInicioOp = New System.Windows.Forms.DateTimePicker
        Me.txtCodDoc = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpFechaVigAl = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtCodPer = New System.Windows.Forms.TextBox
        Me.dtpFechaVigDel = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpFechaDoc = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtImporte = New System.Windows.Forms.TextBox
        Me.txtNroComprobante = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnImportarContabilidad = New System.Windows.Forms.Button
        Me.LBL_MES = New System.Windows.Forms.Label
        Me.CBO_AÑO = New System.Windows.Forms.ComboBox
        Me.CBO_MES = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgvDetalleDiferido = New System.Windows.Forms.DataGridView
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        Me.gbDatosContabilidad.SuspendLayout()
        CType(Me.dgvDetalleDiferido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_op
        '
        Me.btn_op.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_op.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_op.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Card_file_
        Me.btn_op.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_op.Location = New System.Drawing.Point(148, 284)
        Me.btn_op.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_op.Name = "btn_op"
        Me.btn_op.Size = New System.Drawing.Size(129, 34)
        Me.btn_op.TabIndex = 9
        Me.btn_op.Text = "&Cuentas ++"
        Me.btn_op.UseVisualStyleBackColor = True
        '
        'BTN_CANCELAR
        '
        Me.BTN_CANCELAR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTN_CANCELAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CANCELAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.BTN_CANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_CANCELAR.Location = New System.Drawing.Point(580, 284)
        Me.BTN_CANCELAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BTN_CANCELAR.Name = "BTN_CANCELAR"
        Me.BTN_CANCELAR.Size = New System.Drawing.Size(100, 34)
        Me.BTN_CANCELAR.TabIndex = 12
        Me.BTN_CANCELAR.Text = "&Limpiar"
        Me.BTN_CANCELAR.UseVisualStyleBackColor = True
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Eliminar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Eliminar.Location = New System.Drawing.Point(285, 284)
        Me.btn_Eliminar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(177, 34)
        Me.btn_Eliminar.TabIndex = 10
        Me.btn_Eliminar.Text = "&Eliminar Detalle"
        Me.btn_Eliminar.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(688, 284)
        Me.btn_salir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(100, 34)
        Me.btn_salir.TabIndex = 13
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_TRansf
        '
        Me.btn_TRansf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_TRansf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_TRansf.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_TRansf.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_TRansf.Location = New System.Drawing.Point(471, 284)
        Me.btn_TRansf.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn_TRansf.Name = "btn_TRansf"
        Me.btn_TRansf.Size = New System.Drawing.Size(101, 34)
        Me.btn_TRansf.TabIndex = 11
        Me.btn_TRansf.Text = "&Grabar"
        Me.btn_TRansf.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gbDatosContabilidad)
        Me.GroupBox1.Controls.Add(Me.btnImportarContabilidad)
        Me.GroupBox1.Controls.Add(Me.LBL_MES)
        Me.GroupBox1.Controls.Add(Me.CBO_AÑO)
        Me.GroupBox1.Controls.Add(Me.CBO_MES)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 7)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(915, 268)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'gbDatosContabilidad
        '
        Me.gbDatosContabilidad.Controls.Add(Me.btnDiferir)
        Me.gbDatosContabilidad.Controls.Add(Me.cboCuenta)
        Me.gbDatosContabilidad.Controls.Add(Me.txtCodComprobante)
        Me.gbDatosContabilidad.Controls.Add(Me.Label15)
        Me.gbDatosContabilidad.Controls.Add(Me.txtAuxiliar)
        Me.gbDatosContabilidad.Controls.Add(Me.Label13)
        Me.gbDatosContabilidad.Controls.Add(Me.txtNroCuotas)
        Me.gbDatosContabilidad.Controls.Add(Me.txtNroDoc)
        Me.gbDatosContabilidad.Controls.Add(Me.Label12)
        Me.gbDatosContabilidad.Controls.Add(Me.Label1)
        Me.gbDatosContabilidad.Controls.Add(Me.dtpFechaInicioOp)
        Me.gbDatosContabilidad.Controls.Add(Me.txtCodDoc)
        Me.gbDatosContabilidad.Controls.Add(Me.Label11)
        Me.gbDatosContabilidad.Controls.Add(Me.Label2)
        Me.gbDatosContabilidad.Controls.Add(Me.dtpFechaVigAl)
        Me.gbDatosContabilidad.Controls.Add(Me.Label5)
        Me.gbDatosContabilidad.Controls.Add(Me.Label10)
        Me.gbDatosContabilidad.Controls.Add(Me.txtCodPer)
        Me.gbDatosContabilidad.Controls.Add(Me.dtpFechaVigDel)
        Me.gbDatosContabilidad.Controls.Add(Me.Label6)
        Me.gbDatosContabilidad.Controls.Add(Me.Label4)
        Me.gbDatosContabilidad.Controls.Add(Me.dtpFechaDoc)
        Me.gbDatosContabilidad.Controls.Add(Me.Label7)
        Me.gbDatosContabilidad.Controls.Add(Me.Label9)
        Me.gbDatosContabilidad.Controls.Add(Me.txtImporte)
        Me.gbDatosContabilidad.Controls.Add(Me.txtNroComprobante)
        Me.gbDatosContabilidad.Controls.Add(Me.Label8)
        Me.gbDatosContabilidad.Location = New System.Drawing.Point(19, 49)
        Me.gbDatosContabilidad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbDatosContabilidad.Name = "gbDatosContabilidad"
        Me.gbDatosContabilidad.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbDatosContabilidad.Size = New System.Drawing.Size(773, 208)
        Me.gbDatosContabilidad.TabIndex = 34
        Me.gbDatosContabilidad.TabStop = False
        Me.gbDatosContabilidad.Text = "Datos Contabilidad"
        '
        'btnDiferir
        '
        Me.btnDiferir.Location = New System.Drawing.Point(493, 167)
        Me.btnDiferir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDiferir.Name = "btnDiferir"
        Me.btnDiferir.Size = New System.Drawing.Size(100, 28)
        Me.btnDiferir.TabIndex = 34
        Me.btnDiferir.Text = "&Meses"
        Me.btnDiferir.UseVisualStyleBackColor = True
        '
        'cboCuenta
        '
        Me.cboCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCuenta.FormattingEnabled = True
        Me.cboCuenta.Location = New System.Drawing.Point(105, 57)
        Me.cboCuenta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboCuenta.Name = "cboCuenta"
        Me.cboCuenta.Size = New System.Drawing.Size(138, 24)
        Me.cboCuenta.TabIndex = 40
        '
        'txtCodComprobante
        '
        Me.txtCodComprobante.Location = New System.Drawing.Point(336, 95)
        Me.txtCodComprobante.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodComprobante.Name = "txtCodComprobante"
        Me.txtCodComprobante.ReadOnly = True
        Me.txtCodComprobante.Size = New System.Drawing.Size(132, 22)
        Me.txtCodComprobante.TabIndex = 39
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(237, 91)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 34)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Código " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Comprobante"
        '
        'txtAuxiliar
        '
        Me.txtAuxiliar.Location = New System.Drawing.Point(105, 95)
        Me.txtAuxiliar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAuxiliar.Name = "txtAuxiliar"
        Me.txtAuxiliar.ReadOnly = True
        Me.txtAuxiliar.Size = New System.Drawing.Size(72, 22)
        Me.txtAuxiliar.TabIndex = 37
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(32, 100)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 17)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Auxiliar"
        '
        'txtNroCuotas
        '
        Me.txtNroCuotas.Location = New System.Drawing.Point(379, 170)
        Me.txtNroCuotas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNroCuotas.Name = "txtNroCuotas"
        Me.txtNroCuotas.Size = New System.Drawing.Size(52, 22)
        Me.txtNroCuotas.TabIndex = 33
        '
        'txtNroDoc
        '
        Me.txtNroDoc.Location = New System.Drawing.Point(336, 23)
        Me.txtNroDoc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNroDoc.Name = "txtNroDoc"
        Me.txtNroDoc.ReadOnly = True
        Me.txtNroDoc.Size = New System.Drawing.Size(100, 22)
        Me.txtNroDoc.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(297, 175)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 17)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "N° Cuotas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 17)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Cod Doc."
        '
        'dtpFechaInicioOp
        '
        Me.dtpFechaInicioOp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicioOp.Location = New System.Drawing.Point(131, 132)
        Me.dtpFechaInicioOp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpFechaInicioOp.Name = "dtpFechaInicioOp"
        Me.dtpFechaInicioOp.Size = New System.Drawing.Size(112, 22)
        Me.dtpFechaInicioOp.TabIndex = 31
        '
        'txtCodDoc
        '
        Me.txtCodDoc.Location = New System.Drawing.Point(105, 23)
        Me.txtCodDoc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodDoc.Name = "txtCodDoc"
        Me.txtCodDoc.ReadOnly = True
        Me.txtCodDoc.Size = New System.Drawing.Size(72, 22)
        Me.txtCodDoc.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 137)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 17)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Fecha Inicio Op"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(268, 28)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 17)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Nro Doc"
        '
        'dtpFechaVigAl
        '
        Me.dtpFechaVigAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaVigAl.Location = New System.Drawing.Point(649, 132)
        Me.dtpFechaVigAl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpFechaVigAl.Name = "dtpFechaVigAl"
        Me.dtpFechaVigAl.Size = New System.Drawing.Size(112, 22)
        Me.dtpFechaVigAl.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(264, 60)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 17)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Cod Per."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(519, 137)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 17)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Fecha Vigente Al :"
        '
        'txtCodPer
        '
        Me.txtCodPer.Location = New System.Drawing.Point(336, 55)
        Me.txtCodPer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodPer.Name = "txtCodPer"
        Me.txtCodPer.ReadOnly = True
        Me.txtCodPer.Size = New System.Drawing.Size(76, 22)
        Me.txtCodPer.TabIndex = 17
        '
        'dtpFechaVigDel
        '
        Me.dtpFechaVigDel.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaVigDel.Location = New System.Drawing.Point(396, 132)
        Me.dtpFechaVigDel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpFechaVigDel.Name = "dtpFechaVigDel"
        Me.dtpFechaVigDel.Size = New System.Drawing.Size(112, 22)
        Me.dtpFechaVigDel.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 60)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Cod Cuenta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(261, 137)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 17)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Fecha Vigente del :"
        '
        'dtpFechaDoc
        '
        Me.dtpFechaDoc.Enabled = False
        Me.dtpFechaDoc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDoc.Location = New System.Drawing.Point(577, 23)
        Me.dtpFechaDoc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpFechaDoc.Name = "dtpFechaDoc"
        Me.dtpFechaDoc.Size = New System.Drawing.Size(121, 22)
        Me.dtpFechaDoc.TabIndex = 25
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(64, 175)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 17)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Importe"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(493, 28)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 17)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Fecha Doc"
        '
        'txtImporte
        '
        Me.txtImporte.Location = New System.Drawing.Point(128, 170)
        Me.txtImporte.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(132, 22)
        Me.txtImporte.TabIndex = 21
        '
        'txtNroComprobante
        '
        Me.txtNroComprobante.Location = New System.Drawing.Point(616, 95)
        Me.txtNroComprobante.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNroComprobante.Name = "txtNroComprobante"
        Me.txtNroComprobante.ReadOnly = True
        Me.txtNroComprobante.Size = New System.Drawing.Size(123, 22)
        Me.txtNroComprobante.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(491, 100)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 17)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "N° Comprobante"
        '
        'btnImportarContabilidad
        '
        Me.btnImportarContabilidad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImportarContabilidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportarContabilidad.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Address_book_
        Me.btnImportarContabilidad.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnImportarContabilidad.Location = New System.Drawing.Point(803, 52)
        Me.btnImportarContabilidad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnImportarContabilidad.Name = "btnImportarContabilidad"
        Me.btnImportarContabilidad.Size = New System.Drawing.Size(103, 48)
        Me.btnImportarContabilidad.TabIndex = 11
        Me.btnImportarContabilidad.Text = "&Importar Contabilidad"
        Me.btnImportarContabilidad.UseVisualStyleBackColor = True
        '
        'LBL_MES
        '
        Me.LBL_MES.AutoSize = True
        Me.LBL_MES.Location = New System.Drawing.Point(475, 23)
        Me.LBL_MES.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBL_MES.Name = "LBL_MES"
        Me.LBL_MES.Size = New System.Drawing.Size(33, 17)
        Me.LBL_MES.TabIndex = 2
        Me.LBL_MES.Text = "Año"
        '
        'CBO_AÑO
        '
        Me.CBO_AÑO.BackColor = System.Drawing.Color.White
        Me.CBO_AÑO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_AÑO.Enabled = False
        Me.CBO_AÑO.FormattingEnabled = True
        Me.CBO_AÑO.Location = New System.Drawing.Point(531, 18)
        Me.CBO_AÑO.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CBO_AÑO.Name = "CBO_AÑO"
        Me.CBO_AÑO.Size = New System.Drawing.Size(85, 24)
        Me.CBO_AÑO.TabIndex = 3
        '
        'CBO_MES
        '
        Me.CBO_MES.BackColor = System.Drawing.Color.White
        Me.CBO_MES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_MES.Enabled = False
        Me.CBO_MES.FormattingEnabled = True
        Me.CBO_MES.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.CBO_MES.Location = New System.Drawing.Point(404, 18)
        Me.CBO_MES.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CBO_MES.Name = "CBO_MES"
        Me.CBO_MES.Size = New System.Drawing.Size(61, 24)
        Me.CBO_MES.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(297, 23)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Mes Proceso"
        '
        'dgvDetalleDiferido
        '
        Me.dgvDetalleDiferido.AllowUserToAddRows = False
        Me.dgvDetalleDiferido.AllowUserToDeleteRows = False
        Me.dgvDetalleDiferido.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetalleDiferido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleDiferido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column3, Me.Column8, Me.Column1, Me.Column9})
        Me.dgvDetalleDiferido.Location = New System.Drawing.Point(127, 327)
        Me.dgvDetalleDiferido.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvDetalleDiferido.Name = "dgvDetalleDiferido"
        Me.dgvDetalleDiferido.ReadOnly = True
        Me.dgvDetalleDiferido.Size = New System.Drawing.Size(684, 192)
        Me.dgvDetalleDiferido.TabIndex = 15
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "C.C."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 59
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Desc C.C."
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 95
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column8.HeaderText = "Cuenta"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 78
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Descripción"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 107
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column9.HeaderText = "Porcentaje "
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 105
        '
        'INGRESO_DIFERIDO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 553)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvDetalleDiferido)
        Me.Controls.Add(Me.btn_op)
        Me.Controls.Add(Me.BTN_CANCELAR)
        Me.Controls.Add(Me.btn_Eliminar)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.btn_TRansf)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "INGRESO_DIFERIDO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de Diferidos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbDatosContabilidad.ResumeLayout(False)
        Me.gbDatosContabilidad.PerformLayout()
        CType(Me.dgvDetalleDiferido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_op As System.Windows.Forms.Button
    Friend WithEvents BTN_CANCELAR As System.Windows.Forms.Button
    Friend WithEvents btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_TRansf As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LBL_MES As System.Windows.Forms.Label
    Friend WithEvents CBO_AÑO As System.Windows.Forms.ComboBox
    Friend WithEvents CBO_MES As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnImportarContabilidad As System.Windows.Forms.Button
    Friend WithEvents txtNroDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodPer As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtImporte As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNroComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDoc As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicioOp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaVigAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaVigDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNroCuotas As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dgvDetalleDiferido As System.Windows.Forms.DataGridView
    Friend WithEvents gbDatosContabilidad As System.Windows.Forms.GroupBox
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCodComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtAuxiliar As System.Windows.Forms.TextBox
    Friend WithEvents cboCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents btnDiferir As System.Windows.Forms.Button
End Class
