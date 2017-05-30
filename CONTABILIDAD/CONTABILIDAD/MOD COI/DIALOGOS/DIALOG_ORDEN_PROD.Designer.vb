<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DIALOG_ORDEN_PROD
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
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button
        Me.BTN_CANCELAR = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTIngreso = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFaltante = New System.Windows.Forms.TextBox
        Me.dgvListaDiferidos = New System.Windows.Forms.DataGridView
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnInsertar = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCC = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCta = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPorcentaje = New System.Windows.Forms.TextBox
        Me.panel_cc = New System.Windows.Forms.Panel
        Me.dgw_cc = New System.Windows.Forms.DataGridView
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.panelCta = New System.Windows.Forms.Panel
        Me.dgvCta = New System.Windows.Forms.DataGridView
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnEliminar = New System.Windows.Forms.Button
        CType(Me.dgvListaDiferidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_cc.SuspendLayout()
        CType(Me.dgw_cc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelCta.SuspendLayout()
        CType(Me.dgvCta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_ACEPTAR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTN_ACEPTAR.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BTN_ACEPTAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_ACEPTAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Ok_11
        Me.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(423, 301)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(72, 25)
        Me.BTN_ACEPTAR.TabIndex = 32
        Me.BTN_ACEPTAR.Text = "&Aceptar"
        '
        'BTN_CANCELAR
        '
        Me.BTN_CANCELAR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_CANCELAR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTN_CANCELAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_CANCELAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CANCELAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.BTN_CANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_CANCELAR.Location = New System.Drawing.Point(501, 301)
        Me.BTN_CANCELAR.Name = "BTN_CANCELAR"
        Me.BTN_CANCELAR.Size = New System.Drawing.Size(67, 25)
        Me.BTN_CANCELAR.TabIndex = 33
        Me.BTN_CANCELAR.Text = "&Salir"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(401, 231)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Total de Porcentajes"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(514, 227)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 37
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 232)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Total Ingreso"
        '
        'txtTIngreso
        '
        Me.txtTIngreso.Location = New System.Drawing.Point(108, 227)
        Me.txtTIngreso.Name = "txtTIngreso"
        Me.txtTIngreso.ReadOnly = True
        Me.txtTIngreso.Size = New System.Drawing.Size(66, 20)
        Me.txtTIngreso.TabIndex = 39
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(180, 231)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Porcentaje Faltante"
        '
        'txtFaltante
        '
        Me.txtFaltante.Location = New System.Drawing.Point(284, 227)
        Me.txtFaltante.Name = "txtFaltante"
        Me.txtFaltante.ReadOnly = True
        Me.txtFaltante.Size = New System.Drawing.Size(100, 20)
        Me.txtFaltante.TabIndex = 41
        '
        'dgvListaDiferidos
        '
        Me.dgvListaDiferidos.AllowUserToAddRows = False
        Me.dgvListaDiferidos.AllowUserToDeleteRows = False
        Me.dgvListaDiferidos.BackgroundColor = System.Drawing.Color.White
        Me.dgvListaDiferidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListaDiferidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column17, Me.Column1, Me.Column2})
        Me.dgvListaDiferidos.Location = New System.Drawing.Point(126, 13)
        Me.dgvListaDiferidos.Name = "dgvListaDiferidos"
        Me.dgvListaDiferidos.ReadOnly = True
        Me.dgvListaDiferidos.Size = New System.Drawing.Size(370, 150)
        Me.dgvListaDiferidos.TabIndex = 42
        '
        'Column17
        '
        Me.Column17.HeaderText = "Centro de Costos"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Width = 120
        '
        'Column1
        '
        Me.Column1.HeaderText = "Cuenta Destino"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Porcentaje"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'btnInsertar
        '
        Me.btnInsertar.Location = New System.Drawing.Point(533, 109)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(75, 23)
        Me.btnInsertar.TabIndex = 3
        Me.btnInsertar.Text = "&Insertar"
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(95, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Centro de Costos"
        '
        'txtCC
        '
        Me.txtCC.Location = New System.Drawing.Point(92, 190)
        Me.txtCC.Name = "txtCC"
        Me.txtCC.Size = New System.Drawing.Size(100, 20)
        Me.txtCC.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(273, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Cuenta Destino"
        '
        'txtCta
        '
        Me.txtCta.Location = New System.Drawing.Point(272, 190)
        Me.txtCta.Name = "txtCta"
        Me.txtCta.Size = New System.Drawing.Size(100, 20)
        Me.txtCta.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(435, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Porcentaje"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.Location = New System.Drawing.Point(430, 190)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(100, 20)
        Me.txtPorcentaje.TabIndex = 2
        '
        'panel_cc
        '
        Me.panel_cc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_cc.Controls.Add(Me.dgw_cc)
        Me.panel_cc.Location = New System.Drawing.Point(30, 223)
        Me.panel_cc.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.panel_cc.Name = "panel_cc"
        Me.panel_cc.Size = New System.Drawing.Size(359, 101)
        Me.panel_cc.TabIndex = 50
        Me.panel_cc.Visible = False
        '
        'dgw_cc
        '
        Me.dgw_cc.AllowUserToAddRows = False
        Me.dgw_cc.AllowUserToDeleteRows = False
        Me.dgw_cc.AllowUserToOrderColumns = True
        Me.dgw_cc.AllowUserToResizeRows = False
        Me.dgw_cc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_cc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_cc.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column6, Me.Column7})
        Me.dgw_cc.Location = New System.Drawing.Point(6, 2)
        Me.dgw_cc.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgw_cc.MultiSelect = False
        Me.dgw_cc.Name = "dgw_cc"
        Me.dgw_cc.ReadOnly = True
        Me.dgw_cc.RowHeadersWidth = 25
        Me.dgw_cc.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cc.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cc.Size = New System.Drawing.Size(346, 92)
        Me.dgw_cc.TabIndex = 1
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Código"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 65
        '
        'Column6
        '
        Me.Column6.HeaderText = "Descripción"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Cta Ana"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'panelCta
        '
        Me.panelCta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelCta.Controls.Add(Me.dgvCta)
        Me.panelCta.Location = New System.Drawing.Point(241, 223)
        Me.panelCta.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.panelCta.Name = "panelCta"
        Me.panelCta.Size = New System.Drawing.Size(359, 101)
        Me.panelCta.TabIndex = 51
        Me.panelCta.Visible = False
        '
        'dgvCta
        '
        Me.dgvCta.AllowUserToAddRows = False
        Me.dgvCta.AllowUserToDeleteRows = False
        Me.dgvCta.AllowUserToOrderColumns = True
        Me.dgvCta.AllowUserToResizeRows = False
        Me.dgvCta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgvCta.BackgroundColor = System.Drawing.Color.White
        Me.dgvCta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column4})
        Me.dgvCta.Location = New System.Drawing.Point(6, 2)
        Me.dgvCta.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgvCta.MultiSelect = False
        Me.dgvCta.Name = "dgvCta"
        Me.dgvCta.ReadOnly = True
        Me.dgvCta.RowHeadersWidth = 25
        Me.dgvCta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgvCta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgvCta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCta.Size = New System.Drawing.Size(346, 92)
        Me.dgvCta.TabIndex = 1
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Código"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 65
        '
        'Column4
        '
        Me.Column4.HeaderText = "Descripción"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(533, 138)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 52
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'DIALOG_ORDEN_PROD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 339)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.panelCta)
        Me.Controls.Add(Me.panel_cc)
        Me.Controls.Add(Me.txtPorcentaje)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCta)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCC)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnInsertar)
        Me.Controls.Add(Me.dgvListaDiferidos)
        Me.Controls.Add(Me.txtFaltante)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTIngreso)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.BTN_CANCELAR)
        Me.KeyPreview = True
        Me.Name = "DIALOG_ORDEN_PROD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Cuentas"
        CType(Me.dgvListaDiferidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_cc.ResumeLayout(False)
        CType(Me.dgw_cc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelCta.ResumeLayout(False)
        CType(Me.dgvCta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTN_ACEPTAR As System.Windows.Forms.Button
    Friend WithEvents BTN_CANCELAR As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTIngreso As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFaltante As System.Windows.Forms.TextBox
    Friend WithEvents dgvListaDiferidos As System.Windows.Forms.DataGridView
    Friend WithEvents btnInsertar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCC As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCta As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents panel_cc As System.Windows.Forms.Panel
    Friend WithEvents dgw_cc As System.Windows.Forms.DataGridView
    Friend WithEvents panelCta As System.Windows.Forms.Panel
    Friend WithEvents dgvCta As System.Windows.Forms.DataGridView
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
