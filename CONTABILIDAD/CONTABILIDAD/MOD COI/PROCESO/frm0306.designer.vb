<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm0306
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_exportar = New System.Windows.Forms.Button
        Me.cboAño = New System.Windows.Forms.ComboBox
        Me.lblAño = New System.Windows.Forms.Label
        Me.btnConsultar = New System.Windows.Forms.Button
        Me.txt_desc_cta0 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_cod_cta0 = New System.Windows.Forms.TextBox
        Me.dgvCuentaCorriente = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.PaneL_CTA = New System.Windows.Forms.Panel
        Me.dgw_cta = New System.Windows.Forms.DataGridView
        Me.lblSumaMontos = New System.Windows.Forms.Label
        Me.txtSumaMontos = New System.Windows.Forms.TextBox
        Me.btnExcel = New System.Windows.Forms.Button
        Me.chkContinuo = New System.Windows.Forms.CheckBox
        CType(Me.dgvCuentaCorriente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PaneL_CTA.SuspendLayout()
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_salir
        '
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(866, 504)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(79, 31)
        Me.btn_salir.TabIndex = 14
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_exportar
        '
        Me.btn_exportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exportar.Image = Global.CONTABILIDAD.My.Resources.Resources.notepad
        Me.btn_exportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_exportar.Location = New System.Drawing.Point(777, 504)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(83, 31)
        Me.btn_exportar.TabIndex = 13
        Me.btn_exportar.Text = "&Exportar"
        Me.btn_exportar.UseVisualStyleBackColor = True
        '
        'cboAño
        '
        Me.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAño.FormattingEnabled = True
        Me.cboAño.Location = New System.Drawing.Point(281, 11)
        Me.cboAño.Name = "cboAño"
        Me.cboAño.Size = New System.Drawing.Size(93, 21)
        Me.cboAño.TabIndex = 12
        '
        'lblAño
        '
        Me.lblAño.AutoSize = True
        Me.lblAño.Location = New System.Drawing.Point(243, 15)
        Me.lblAño.Name = "lblAño"
        Me.lblAño.Size = New System.Drawing.Size(26, 13)
        Me.lblAño.TabIndex = 11
        Me.lblAño.Text = "Año"
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Search_1
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.Location = New System.Drawing.Point(688, 10)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(91, 23)
        Me.btnConsultar.TabIndex = 10
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'txt_desc_cta0
        '
        Me.txt_desc_cta0.Location = New System.Drawing.Point(342, 12)
        Me.txt_desc_cta0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_cta0.MaxLength = 40
        Me.txt_desc_cta0.Name = "txt_desc_cta0"
        Me.txt_desc_cta0.Size = New System.Drawing.Size(329, 20)
        Me.txt_desc_cta0.TabIndex = 36
        Me.txt_desc_cta0.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(232, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 14)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Cuenta"
        Me.Label2.Visible = False
        '
        'txt_cod_cta0
        '
        Me.txt_cod_cta0.Location = New System.Drawing.Point(281, 12)
        Me.txt_cod_cta0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_cta0.MaxLength = 8
        Me.txt_cod_cta0.Name = "txt_cod_cta0"
        Me.txt_cod_cta0.Size = New System.Drawing.Size(60, 20)
        Me.txt_cod_cta0.TabIndex = 35
        Me.txt_cod_cta0.Visible = False
        '
        'dgvCuentaCorriente
        '
        Me.dgvCuentaCorriente.AllowUserToAddRows = False
        Me.dgvCuentaCorriente.AllowUserToDeleteRows = False
        Me.dgvCuentaCorriente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuentaCorriente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column7, Me.Column6, Me.Column8, Me.Column9, Me.Column10, Me.Column18, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17})
        Me.dgvCuentaCorriente.Location = New System.Drawing.Point(19, 72)
        Me.dgvCuentaCorriente.Name = "dgvCuentaCorriente"
        Me.dgvCuentaCorriente.Size = New System.Drawing.Size(973, 413)
        Me.dgvCuentaCorriente.TabIndex = 38
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
        Me.Column4.Width = 50
        '
        'Column5
        '
        Me.Column5.HeaderText = "Nro Doc"
        Me.Column5.Name = "Column5"
        Me.Column5.ToolTipText = "Número de Documento"
        '
        'Column7
        '
        Me.Column7.HeaderText = "Descripción"
        Me.Column7.Name = "Column7"
        Me.Column7.ToolTipText = "Descripción"
        Me.Column7.Width = 300
        '
        'Column6
        '
        Me.Column6.HeaderText = "Emisión"
        Me.Column6.Name = "Column6"
        Me.Column6.ToolTipText = "Fecha Emisión"
        Me.Column6.Width = 75
        '
        'Column8
        '
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column8.HeaderText = "Monto"
        Me.Column8.Name = "Column8"
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
        Me.Column14.Width = 75
        '
        'Column15
        '
        Me.Column15.HeaderText = "Moneda"
        Me.Column15.Name = "Column15"
        Me.Column15.ToolTipText = "Tipo Moneda"
        Me.Column15.Width = 75
        '
        'Column16
        '
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Column16.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column16.HeaderText = "Mon. Moneda Ext."
        Me.Column16.Name = "Column16"
        Me.Column16.ToolTipText = "Monto Moneda Extranjera"
        '
        'Column17
        '
        Me.Column17.HeaderText = "T. C."
        Me.Column17.Name = "Column17"
        Me.Column17.ToolTipText = "Tipo Cambio"
        Me.Column17.Width = 65
        '
        'PaneL_CTA
        '
        Me.PaneL_CTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PaneL_CTA.Controls.Add(Me.dgw_cta)
        Me.PaneL_CTA.Location = New System.Drawing.Point(263, 35)
        Me.PaneL_CTA.Name = "PaneL_CTA"
        Me.PaneL_CTA.Size = New System.Drawing.Size(425, 141)
        Me.PaneL_CTA.TabIndex = 39
        Me.PaneL_CTA.Visible = False
        '
        'dgw_cta
        '
        Me.dgw_cta.AllowUserToAddRows = False
        Me.dgw_cta.AllowUserToDeleteRows = False
        Me.dgw_cta.AllowUserToOrderColumns = True
        Me.dgw_cta.AllowUserToResizeRows = False
        Me.dgw_cta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_cta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_cta.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cta.Location = New System.Drawing.Point(23, -1)
        Me.dgw_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta.MultiSelect = False
        Me.dgw_cta.Name = "dgw_cta"
        Me.dgw_cta.ReadOnly = True
        Me.dgw_cta.RowHeadersWidth = 25
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw_cta.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta.Size = New System.Drawing.Size(384, 134)
        Me.dgw_cta.TabIndex = 17
        '
        'lblSumaMontos
        '
        Me.lblSumaMontos.AutoSize = True
        Me.lblSumaMontos.Location = New System.Drawing.Point(30, 508)
        Me.lblSumaMontos.Name = "lblSumaMontos"
        Me.lblSumaMontos.Size = New System.Drawing.Size(72, 13)
        Me.lblSumaMontos.TabIndex = 40
        Me.lblSumaMontos.Text = "Suma Montos"
        '
        'txtSumaMontos
        '
        Me.txtSumaMontos.Location = New System.Drawing.Point(111, 504)
        Me.txtSumaMontos.Name = "txtSumaMontos"
        Me.txtSumaMontos.Size = New System.Drawing.Size(100, 20)
        Me.txtSumaMontos.TabIndex = 41
        '
        'btnExcel
        '
        Me.btnExcel.Image = Global.CONTABILIDAD.My.Resources.Resources.excel
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.Location = New System.Drawing.Point(688, 39)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(91, 23)
        Me.btnExcel.TabIndex = 57
        Me.btnExcel.Text = "&Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'chkContinuo
        '
        Me.chkContinuo.AutoSize = True
        Me.chkContinuo.Location = New System.Drawing.Point(785, 43)
        Me.chkContinuo.Name = "chkContinuo"
        Me.chkContinuo.Size = New System.Drawing.Size(68, 17)
        Me.chkContinuo.TabIndex = 160
        Me.chkContinuo.Text = "Continuo"
        Me.chkContinuo.UseVisualStyleBackColor = True
        '
        'frm0306
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 569)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkContinuo)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.txtSumaMontos)
        Me.Controls.Add(Me.lblSumaMontos)
        Me.Controls.Add(Me.PaneL_CTA)
        Me.Controls.Add(Me.lblAño)
        Me.Controls.Add(Me.cboAño)
        Me.Controls.Add(Me.dgvCuentaCorriente)
        Me.Controls.Add(Me.txt_desc_cta0)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_cod_cta0)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.btn_exportar)
        Me.Controls.Add(Me.btnConsultar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frm0306"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Libro Cuenta Corriente"
        CType(Me.dgvCuentaCorriente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PaneL_CTA.ResumeLayout(False)
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
    Friend WithEvents cboAño As System.Windows.Forms.ComboBox
    Friend WithEvents lblAño As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents txt_desc_cta0 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_cod_cta0 As System.Windows.Forms.TextBox
    Friend WithEvents dgvCuentaCorriente As System.Windows.Forms.DataGridView
    Friend WithEvents PaneL_CTA As System.Windows.Forms.Panel
    Friend WithEvents dgw_cta As System.Windows.Forms.DataGridView
    Friend WithEvents lblSumaMontos As System.Windows.Forms.Label
    Friend WithEvents txtSumaMontos As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents chkContinuo As System.Windows.Forms.CheckBox
End Class
