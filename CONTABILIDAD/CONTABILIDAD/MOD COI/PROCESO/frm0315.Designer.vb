<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm0315
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnExcel = New System.Windows.Forms.Button
        Me.txtSumaMontos = New System.Windows.Forms.TextBox
        Me.lblSumaMontos = New System.Windows.Forms.Label
        Me.lblAño = New System.Windows.Forms.Label
        Me.cboAño = New System.Windows.Forms.ComboBox
        Me.dgvCuentaCorriente = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_cod_cta0 = New System.Windows.Forms.TextBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_exportar = New System.Windows.Forms.Button
        Me.btnConsultar = New System.Windows.Forms.Button
        Me.btnExportarExcel = New System.Windows.Forms.Button
        Me.stEstado = New System.Windows.Forms.StatusStrip
        Me.tspbExportar = New System.Windows.Forms.ToolStripProgressBar
        Me.tslblMensaje = New System.Windows.Forms.ToolStripStatusLabel
        Me.chkContinuo = New System.Windows.Forms.CheckBox
        CType(Me.dgvCuentaCorriente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExcel
        '
        Me.btnExcel.Image = Global.CONTABILIDAD.My.Resources.Resources.excel
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.Location = New System.Drawing.Point(533, 50)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(91, 23)
        Me.btnExcel.TabIndex = 56
        Me.btnExcel.Text = "&Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'txtSumaMontos
        '
        Me.txtSumaMontos.Location = New System.Drawing.Point(106, 511)
        Me.txtSumaMontos.Name = "txtSumaMontos"
        Me.txtSumaMontos.Size = New System.Drawing.Size(100, 20)
        Me.txtSumaMontos.TabIndex = 55
        '
        'lblSumaMontos
        '
        Me.lblSumaMontos.AutoSize = True
        Me.lblSumaMontos.Location = New System.Drawing.Point(25, 515)
        Me.lblSumaMontos.Name = "lblSumaMontos"
        Me.lblSumaMontos.Size = New System.Drawing.Size(72, 13)
        Me.lblSumaMontos.TabIndex = 54
        Me.lblSumaMontos.Text = "Suma Montos"
        '
        'lblAño
        '
        Me.lblAño.AutoSize = True
        Me.lblAño.Location = New System.Drawing.Point(377, 22)
        Me.lblAño.Name = "lblAño"
        Me.lblAño.Size = New System.Drawing.Size(26, 13)
        Me.lblAño.TabIndex = 45
        Me.lblAño.Text = "Año"
        '
        'cboAño
        '
        Me.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAño.FormattingEnabled = True
        Me.cboAño.Location = New System.Drawing.Point(419, 18)
        Me.cboAño.Name = "cboAño"
        Me.cboAño.Size = New System.Drawing.Size(93, 21)
        Me.cboAño.TabIndex = 46
        '
        'dgvCuentaCorriente
        '
        Me.dgvCuentaCorriente.AllowUserToAddRows = False
        Me.dgvCuentaCorriente.AllowUserToDeleteRows = False
        Me.dgvCuentaCorriente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuentaCorriente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column7, Me.Column6, Me.Column8, Me.Column19, Me.Column20, Me.Column9, Me.Column10, Me.Column18, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17})
        Me.dgvCuentaCorriente.Location = New System.Drawing.Point(14, 79)
        Me.dgvCuentaCorriente.Name = "dgvCuentaCorriente"
        Me.dgvCuentaCorriente.Size = New System.Drawing.Size(973, 413)
        Me.dgvCuentaCorriente.TabIndex = 52
        '
        'Column1
        '
        Me.Column1.HeaderText = "Periodo"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 75
        '
        'Column2
        '
        Me.Column2.HeaderText = "C. U. P."
        Me.Column2.Name = "Column2"
        Me.Column2.ToolTipText = "Código Unico Operación"
        Me.Column2.Width = 75
        '
        'Column3
        '
        Me.Column3.HeaderText = "Nro. Asiento"
        Me.Column3.Name = "Column3"
        Me.Column3.ToolTipText = "Número de Asiento"
        Me.Column3.Width = 50
        '
        'Column4
        '
        Me.Column4.HeaderText = "Doc Iden."
        Me.Column4.Name = "Column4"
        Me.Column4.ToolTipText = "Tipo Doc Identidad"
        Me.Column4.Visible = False
        Me.Column4.Width = 50
        '
        'Column5
        '
        Me.Column5.HeaderText = "Nro Doc"
        Me.Column5.Name = "Column5"
        Me.Column5.ToolTipText = "Número de Documento"
        Me.Column5.Visible = False
        '
        'Column7
        '
        Me.Column7.HeaderText = "Descripción"
        Me.Column7.Name = "Column7"
        Me.Column7.ToolTipText = "Descripción"
        Me.Column7.Visible = False
        Me.Column7.Width = 300
        '
        'Column6
        '
        Me.Column6.HeaderText = "Emisión"
        Me.Column6.Name = "Column6"
        Me.Column6.ToolTipText = "Fecha Emisión"
        Me.Column6.Visible = False
        Me.Column6.Width = 75
        '
        'Column8
        '
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column8.HeaderText = "Monto"
        Me.Column8.Name = "Column8"
        '
        'Column19
        '
        Me.Column19.HeaderText = "Adiciones"
        Me.Column19.Name = "Column19"
        '
        'Column20
        '
        Me.Column20.HeaderText = "Deducciones"
        Me.Column20.Name = "Column20"
        '
        'Column9
        '
        Me.Column9.HeaderText = "Est. Ope."
        Me.Column9.Name = "Column9"
        Me.Column9.ToolTipText = "Estado Operación"
        Me.Column9.Width = 50
        '
        'Column10
        '
        Me.Column10.HeaderText = "Cta Ctble"
        Me.Column10.Name = "Column10"
        Me.Column10.ToolTipText = "Cuenta Contable"
        Me.Column10.Width = 75
        '
        'Column18
        '
        Me.Column18.HeaderText = "Descripcion Cta"
        Me.Column18.Name = "Column18"
        Me.Column18.ToolTipText = "Descripcion Cuenta"
        Me.Column18.Width = 200
        '
        'Column11
        '
        Me.Column11.HeaderText = "Tipo Doc"
        Me.Column11.Name = "Column11"
        Me.Column11.ToolTipText = "Tipo Documento Pago"
        Me.Column11.Width = 50
        '
        'Column12
        '
        Me.Column12.HeaderText = "Serie Doc"
        Me.Column12.Name = "Column12"
        Me.Column12.ToolTipText = "Serie Documento Pago"
        Me.Column12.Width = 50
        '
        'Column13
        '
        Me.Column13.HeaderText = "Nro Doc"
        Me.Column13.Name = "Column13"
        Me.Column13.ToolTipText = "Numero Documento"
        '
        'Column14
        '
        Me.Column14.HeaderText = "Fecha Ven."
        Me.Column14.Name = "Column14"
        Me.Column14.ToolTipText = "Fecha Vencimiento Comprobante"
        Me.Column14.Visible = False
        Me.Column14.Width = 75
        '
        'Column15
        '
        Me.Column15.HeaderText = "Moneda"
        Me.Column15.Name = "Column15"
        Me.Column15.ToolTipText = "Tipo Moneda"
        Me.Column15.Visible = False
        Me.Column15.Width = 75
        '
        'Column16
        '
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Column16.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column16.HeaderText = "Mon. Moneda Ext."
        Me.Column16.Name = "Column16"
        Me.Column16.ToolTipText = "Monto Moneda Extranjera"
        Me.Column16.Visible = False
        '
        'Column17
        '
        Me.Column17.HeaderText = "T. C."
        Me.Column17.Name = "Column17"
        Me.Column17.ToolTipText = "Tipo Cambio"
        Me.Column17.Visible = False
        Me.Column17.Width = 65
        '
        'txt_cod_cta0
        '
        Me.txt_cod_cta0.Location = New System.Drawing.Point(419, 18)
        Me.txt_cod_cta0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_cta0.MaxLength = 8
        Me.txt_cod_cta0.Name = "txt_cod_cta0"
        Me.txt_cod_cta0.Size = New System.Drawing.Size(60, 20)
        Me.txt_cod_cta0.TabIndex = 49
        Me.txt_cod_cta0.Visible = False
        '
        'btn_salir
        '
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(861, 511)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(79, 31)
        Me.btn_salir.TabIndex = 48
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_exportar
        '
        Me.btn_exportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exportar.Image = Global.CONTABILIDAD.My.Resources.Resources.notepad
        Me.btn_exportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_exportar.Location = New System.Drawing.Point(772, 511)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(83, 31)
        Me.btn_exportar.TabIndex = 47
        Me.btn_exportar.Text = "&Exportar"
        Me.btn_exportar.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Search_1
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.Location = New System.Drawing.Point(533, 17)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(91, 23)
        Me.btnConsultar.TabIndex = 44
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportarExcel.Image = Global.CONTABILIDAD.My.Resources.Resources.excel
        Me.btnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportarExcel.Location = New System.Drawing.Point(652, 511)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(114, 31)
        Me.btnExportarExcel.TabIndex = 57
        Me.btnExportarExcel.Text = "&Exportar Excel"
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'stEstado
        '
        Me.stEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspbExportar, Me.tslblMensaje})
        Me.stEstado.Location = New System.Drawing.Point(0, 579)
        Me.stEstado.Name = "stEstado"
        Me.stEstado.Size = New System.Drawing.Size(1001, 22)
        Me.stEstado.TabIndex = 158
        Me.stEstado.Text = "StatusStrip1"
        Me.stEstado.Visible = False
        '
        'tspbExportar
        '
        Me.tspbExportar.Name = "tspbExportar"
        Me.tspbExportar.Size = New System.Drawing.Size(100, 16)
        Me.tspbExportar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        '
        'tslblMensaje
        '
        Me.tslblMensaje.Name = "tslblMensaje"
        Me.tslblMensaje.Size = New System.Drawing.Size(109, 17)
        Me.tslblMensaje.Text = "Generando Archivo"
        '
        'chkContinuo
        '
        Me.chkContinuo.AutoSize = True
        Me.chkContinuo.Location = New System.Drawing.Point(630, 54)
        Me.chkContinuo.Name = "chkContinuo"
        Me.chkContinuo.Size = New System.Drawing.Size(68, 17)
        Me.chkContinuo.TabIndex = 159
        Me.chkContinuo.Text = "Continuo"
        Me.chkContinuo.UseVisualStyleBackColor = True
        '
        'frm0315
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 601)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkContinuo)
        Me.Controls.Add(Me.stEstado)
        Me.Controls.Add(Me.btnExportarExcel)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.txtSumaMontos)
        Me.Controls.Add(Me.lblSumaMontos)
        Me.Controls.Add(Me.lblAño)
        Me.Controls.Add(Me.cboAño)
        Me.Controls.Add(Me.dgvCuentaCorriente)
        Me.Controls.Add(Me.txt_cod_cta0)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.btn_exportar)
        Me.Controls.Add(Me.btnConsultar)
        Me.Name = "frm0315"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm0315"
        CType(Me.dgvCuentaCorriente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stEstado.ResumeLayout(False)
        Me.stEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents txtSumaMontos As System.Windows.Forms.TextBox
    Friend WithEvents lblSumaMontos As System.Windows.Forms.Label
    Friend WithEvents lblAño As System.Windows.Forms.Label
    Friend WithEvents cboAño As System.Windows.Forms.ComboBox
    Friend WithEvents dgvCuentaCorriente As System.Windows.Forms.DataGridView
    Friend WithEvents txt_cod_cta0 As System.Windows.Forms.TextBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents stEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tspbExportar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tslblMensaje As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chkContinuo As System.Windows.Forms.CheckBox
End Class
