<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_CHEQUES
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
        Me.dgvDetalle = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkDiferido = New System.Windows.Forms.CheckBox
        Me.btn_consulta = New System.Windows.Forms.Button
        Me.txt_desc_ban = New System.Windows.Forms.TextBox
        Me.KL1 = New System.Windows.Forms.TextBox
        Me.BTN_SALIR = New System.Windows.Forms.Button
        Me.txt_cod_ban = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.panel_bancos = New System.Windows.Forms.Panel
        Me.dgw_ban = New System.Windows.Forms.DataGridView
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbVoucher = New System.Windows.Forms.RadioButton
        Me.rbFactura = New System.Windows.Forms.RadioButton
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.panel_bancos.SuspendLayout()
        CType(Me.dgw_ban, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToOrderColumns = True
        Me.dgvDetalle.AllowUserToResizeRows = False
        Me.dgvDetalle.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column6, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column9, Me.Column7, Me.Column8, Me.Column10, Me.Column11})
        Me.dgvDetalle.Location = New System.Drawing.Point(11, 151)
        Me.dgvDetalle.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgvDetalle.MultiSelect = False
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.RowHeadersWidth = 25
        Me.dgvDetalle.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgvDetalle.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalle.ShowRowErrors = False
        Me.dgvDetalle.Size = New System.Drawing.Size(648, 323)
        Me.dgvDetalle.TabIndex = 2
        '
        'Column1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column1.FillWeight = 56.71418!
        Me.Column1.HeaderText = "Cód MP"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        Me.Column1.Width = 50
        '
        'Column6
        '
        Me.Column6.FillWeight = 355.33!
        Me.Column6.HeaderText = "Nro. Cheque"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 75
        '
        'Column2
        '
        Me.Column2.FillWeight = 57.59118!
        Me.Column2.HeaderText = "Fecha"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 65
        '
        'Column3
        '
        Me.Column3.FillWeight = 57.59118!
        Me.Column3.HeaderText = "Girado a"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 200
        '
        'Column4
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.FillWeight = 57.59118!
        Me.Column4.HeaderText = "Importe"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 70
        '
        'Column5
        '
        Me.Column5.FillWeight = 57.59118!
        Me.Column5.HeaderText = "Mon."
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 30
        '
        'Column9
        '
        Me.Column9.HeaderText = "Ok"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 30
        '
        'Column7
        '
        Me.Column7.FillWeight = 57.59118!
        Me.Column7.HeaderText = "Cod. Usu."
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        Me.Column7.Width = 50
        '
        'Column8
        '
        Me.Column8.HeaderText = "Usuario"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 70
        '
        'Column10
        '
        Me.Column10.HeaderText = "Dif."
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 30
        '
        'Column11
        '
        Me.Column11.HeaderText = "Fec.Pago"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 65
        '
        'cbo_año
        '
        Me.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_año.FormattingEnabled = True
        Me.cbo_año.Location = New System.Drawing.Point(100, 74)
        Me.cbo_año.Name = "cbo_año"
        Me.cbo_año.Size = New System.Drawing.Size(79, 22)
        Me.cbo_año.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(59, 83)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(27, 14)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Año"
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"INICIO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(263, 74)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(136, 22)
        Me.cbo_mes.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(230, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 14)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Mes"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkDiferido)
        Me.GroupBox1.Controls.Add(Me.btn_consulta)
        Me.GroupBox1.Controls.Add(Me.cbo_año)
        Me.GroupBox1.Controls.Add(Me.txt_desc_ban)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.KL1)
        Me.GroupBox1.Controls.Add(Me.cbo_mes)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BTN_SALIR)
        Me.GroupBox1.Controls.Add(Me.txt_cod_ban)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(646, 135)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chkDiferido
        '
        Me.chkDiferido.AutoSize = True
        Me.chkDiferido.Location = New System.Drawing.Point(263, 102)
        Me.chkDiferido.Name = "chkDiferido"
        Me.chkDiferido.Size = New System.Drawing.Size(109, 18)
        Me.chkDiferido.TabIndex = 5
        Me.chkDiferido.Text = "Cheques Diferido"
        Me.chkDiferido.UseVisualStyleBackColor = True
        Me.chkDiferido.Visible = False
        '
        'btn_consulta
        '
        Me.btn_consulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_consulta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_consulta.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Search_1
        Me.btn_consulta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consulta.Location = New System.Drawing.Point(501, 43)
        Me.btn_consulta.Name = "btn_consulta"
        Me.btn_consulta.Size = New System.Drawing.Size(77, 28)
        Me.btn_consulta.TabIndex = 8
        Me.btn_consulta.Text = "&Consulta"
        Me.btn_consulta.UseVisualStyleBackColor = True
        '
        'txt_desc_ban
        '
        Me.txt_desc_ban.BackColor = System.Drawing.Color.White
        Me.txt_desc_ban.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_desc_ban.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_ban.Location = New System.Drawing.Point(146, 50)
        Me.txt_desc_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_ban.MaxLength = 40
        Me.txt_desc_ban.Name = "txt_desc_ban"
        Me.txt_desc_ban.Size = New System.Drawing.Size(324, 20)
        Me.txt_desc_ban.TabIndex = 2
        '
        'KL1
        '
        Me.KL1.Location = New System.Drawing.Point(335, 50)
        Me.KL1.Name = "KL1"
        Me.KL1.Size = New System.Drawing.Size(16, 20)
        Me.KL1.TabIndex = 3
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_SALIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_SALIR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.Location = New System.Drawing.Point(501, 78)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(80, 33)
        Me.BTN_SALIR.TabIndex = 9
        Me.BTN_SALIR.TabStop = False
        Me.BTN_SALIR.Text = "&Salir"
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'txt_cod_ban
        '
        Me.txt_cod_ban.BackColor = System.Drawing.Color.White
        Me.txt_cod_ban.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_ban.Location = New System.Drawing.Point(100, 50)
        Me.txt_cod_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_ban.MaxLength = 4
        Me.txt_cod_ban.Name = "txt_cod_ban"
        Me.txt_cod_ban.Size = New System.Drawing.Size(46, 20)
        Me.txt_cod_ban.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(59, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 14)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Banco"
        '
        'panel_bancos
        '
        Me.panel_bancos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_bancos.Controls.Add(Me.dgw_ban)
        Me.panel_bancos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_bancos.Location = New System.Drawing.Point(18, 80)
        Me.panel_bancos.Name = "panel_bancos"
        Me.panel_bancos.Size = New System.Drawing.Size(489, 122)
        Me.panel_bancos.TabIndex = 1
        Me.panel_bancos.Visible = False
        '
        'dgw_ban
        '
        Me.dgw_ban.AllowUserToAddRows = False
        Me.dgw_ban.AllowUserToDeleteRows = False
        Me.dgw_ban.AllowUserToOrderColumns = True
        Me.dgw_ban.AllowUserToResizeRows = False
        Me.dgw_ban.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_ban.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_ban.BackgroundColor = System.Drawing.Color.White
        Me.dgw_ban.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgw_ban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_ban.Location = New System.Drawing.Point(93, 0)
        Me.dgw_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_ban.MultiSelect = False
        Me.dgw_ban.Name = "dgw_ban"
        Me.dgw_ban.ReadOnly = True
        Me.dgw_ban.RowHeadersWidth = 25
        Me.dgw_ban.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_ban.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_ban.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_ban.Size = New System.Drawing.Size(370, 113)
        Me.dgw_ban.TabIndex = 0
        Me.dgw_ban.TabStop = False
        '
        'btn_imprimir
        '
        Me.btn_imprimir.BackColor = System.Drawing.SystemColors.Control
        Me.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprimir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir.Location = New System.Drawing.Point(576, 513)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(82, 31)
        Me.btn_imprimir.TabIndex = 3
        Me.btn_imprimir.Text = "&Imprimir"
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbVoucher)
        Me.GroupBox2.Controls.Add(Me.rbFactura)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 480)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(147, 64)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Impresion de validación:"
        '
        'rbVoucher
        '
        Me.rbVoucher.AutoSize = True
        Me.rbVoucher.Checked = True
        Me.rbVoucher.Location = New System.Drawing.Point(7, 40)
        Me.rbVoucher.Name = "rbVoucher"
        Me.rbVoucher.Size = New System.Drawing.Size(66, 18)
        Me.rbVoucher.TabIndex = 0
        Me.rbVoucher.TabStop = True
        Me.rbVoucher.Text = "Voucher"
        Me.rbVoucher.UseVisualStyleBackColor = True
        '
        'rbFactura
        '
        Me.rbFactura.AutoSize = True
        Me.rbFactura.Location = New System.Drawing.Point(6, 19)
        Me.rbFactura.Name = "rbFactura"
        Me.rbFactura.Size = New System.Drawing.Size(124, 18)
        Me.rbFactura.TabIndex = 0
        Me.rbFactura.Text = "Factura (Validadora)"
        Me.rbFactura.UseVisualStyleBackColor = True
        '
        'REPORTE_CHEQUES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(670, 556)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btn_imprimir)
        Me.Controls.Add(Me.panel_bancos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "REPORTE_CHEQUES"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Emisión de Cheques"
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.panel_bancos.ResumeLayout(False)
        CType(Me.dgw_ban, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_año As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_desc_ban As System.Windows.Forms.TextBox
    Friend WithEvents KL1 As System.Windows.Forms.TextBox
    Friend WithEvents BTN_SALIR As System.Windows.Forms.Button
    Friend WithEvents txt_cod_ban As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_consulta As System.Windows.Forms.Button
    Friend WithEvents panel_bancos As System.Windows.Forms.Panel
    Friend WithEvents dgw_ban As System.Windows.Forms.DataGridView
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbVoucher As System.Windows.Forms.RadioButton
    Friend WithEvents rbFactura As System.Windows.Forms.RadioButton
    Friend WithEvents chkDiferido As System.Windows.Forms.CheckBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
