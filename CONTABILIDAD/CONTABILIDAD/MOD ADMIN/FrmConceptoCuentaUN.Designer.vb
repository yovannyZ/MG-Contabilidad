<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConceptoCuentaUN
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
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
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.f1 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.btnAsociar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgwListado = New System.Windows.Forms.DataGridView
        Me.tabConcepto = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.cboTipo = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.PanelConcepto = New System.Windows.Forms.Panel
        Me.dgwConcepto = New System.Windows.Forms.DataGridView
        Me.PaneL_CTA = New System.Windows.Forms.Panel
        Me.dgw_cta = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgwConceptoCuenta = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.txtDescCuenta = New System.Windows.Forms.TextBox
        Me.txtCodCuenta = New System.Windows.Forms.TextBox
        Me.txtDescConcepto = New System.Windows.Forms.TextBox
        Me.txtCodConcepto = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkTodos = New System.Windows.Forms.CheckBox
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.f1.SuspendLayout()
        CType(Me.dgwListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabConcepto.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.PanelConcepto.SuspendLayout()
        CType(Me.dgwConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PaneL_CTA.SuspendLayout()
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwConceptoCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.Location = New System.Drawing.Point(86, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(77, 29)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btnGuardar)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnCancelar)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(405, 387)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(169, 37)
        Me.FlowLayoutPanel1.TabIndex = 10
        '
        'btnGuardar
        '
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.Location = New System.Drawing.Point(3, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(77, 29)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'f1
        '
        Me.f1.Controls.Add(Me.btnNuevo)
        Me.f1.Controls.Add(Me.btnAsociar)
        Me.f1.Controls.Add(Me.btnSalir)
        Me.f1.Location = New System.Drawing.Point(689, 172)
        Me.f1.Name = "f1"
        Me.f1.Size = New System.Drawing.Size(85, 109)
        Me.f1.TabIndex = 1
        '
        'btnNuevo
        '
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.Location = New System.Drawing.Point(3, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(77, 29)
        Me.btnNuevo.TabIndex = 4
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnAsociar
        '
        Me.btnAsociar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAsociar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btnAsociar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAsociar.Location = New System.Drawing.Point(3, 38)
        Me.btnAsociar.Name = "btnAsociar"
        Me.btnAsociar.Size = New System.Drawing.Size(77, 29)
        Me.btnAsociar.TabIndex = 1
        Me.btnAsociar.Text = "&Modificar"
        Me.btnAsociar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.Location = New System.Drawing.Point(3, 73)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(77, 29)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(177, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Concepto"
        '
        'dgwListado
        '
        Me.dgwListado.AllowUserToAddRows = False
        Me.dgwListado.AllowUserToDeleteRows = False
        Me.dgwListado.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgwListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwListado.Location = New System.Drawing.Point(3, 21)
        Me.dgwListado.MultiSelect = False
        Me.dgwListado.Name = "dgwListado"
        Me.dgwListado.ReadOnly = True
        Me.dgwListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwListado.Size = New System.Drawing.Size(682, 349)
        Me.dgwListado.TabIndex = 2
        '
        'tabConcepto
        '
        Me.tabConcepto.Controls.Add(Me.TabPage1)
        Me.tabConcepto.Controls.Add(Me.TabPage2)
        Me.tabConcepto.Location = New System.Drawing.Point(3, 9)
        Me.tabConcepto.Name = "tabConcepto"
        Me.tabConcepto.SelectedIndex = 0
        Me.tabConcepto.Size = New System.Drawing.Size(788, 483)
        Me.tabConcepto.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgwListado)
        Me.TabPage1.Controls.Add(Me.f1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(780, 457)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Listado"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cboTipo)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.PanelConcepto)
        Me.TabPage2.Controls.Add(Me.PaneL_CTA)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.dgwConceptoCuenta)
        Me.TabPage2.Controls.Add(Me.txtDescCuenta)
        Me.TabPage2.Controls.Add(Me.txtCodCuenta)
        Me.TabPage2.Controls.Add(Me.txtDescConcepto)
        Me.TabPage2.Controls.Add(Me.txtCodConcepto)
        Me.TabPage2.Controls.Add(Me.FlowLayoutPanel1)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.chkTodos)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(780, 457)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalle"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.White
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Items.AddRange(New Object() {"INGRESO", "GASTO", "COSTO"})
        Me.cboTipo.Location = New System.Drawing.Point(236, 26)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(105, 22)
        Me.cboTipo.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(180, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Tipo"
        '
        'PanelConcepto
        '
        Me.PanelConcepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelConcepto.Controls.Add(Me.dgwConcepto)
        Me.PanelConcepto.Location = New System.Drawing.Point(236, 76)
        Me.PanelConcepto.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PanelConcepto.Name = "PanelConcepto"
        Me.PanelConcepto.Size = New System.Drawing.Size(406, 107)
        Me.PanelConcepto.TabIndex = 23
        Me.PanelConcepto.Visible = False
        '
        'dgwConcepto
        '
        Me.dgwConcepto.AllowUserToAddRows = False
        Me.dgwConcepto.AllowUserToDeleteRows = False
        Me.dgwConcepto.AllowUserToOrderColumns = True
        Me.dgwConcepto.AllowUserToResizeRows = False
        Me.dgwConcepto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgwConcepto.BackgroundColor = System.Drawing.Color.White
        Me.dgwConcepto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwConcepto.Location = New System.Drawing.Point(9, 0)
        Me.dgwConcepto.Margin = New System.Windows.Forms.Padding(0)
        Me.dgwConcepto.MultiSelect = False
        Me.dgwConcepto.Name = "dgwConcepto"
        Me.dgwConcepto.ReadOnly = True
        Me.dgwConcepto.RowHeadersWidth = 25
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgwConcepto.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgwConcepto.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgwConcepto.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgwConcepto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwConcepto.Size = New System.Drawing.Size(395, 101)
        Me.dgwConcepto.TabIndex = 17
        '
        'PaneL_CTA
        '
        Me.PaneL_CTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PaneL_CTA.Controls.Add(Me.dgw_cta)
        Me.PaneL_CTA.Location = New System.Drawing.Point(233, 112)
        Me.PaneL_CTA.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PaneL_CTA.Name = "PaneL_CTA"
        Me.PaneL_CTA.Size = New System.Drawing.Size(410, 107)
        Me.PaneL_CTA.TabIndex = 22
        Me.PaneL_CTA.Visible = False
        '
        'dgw_cta
        '
        Me.dgw_cta.AllowUserToAddRows = False
        Me.dgw_cta.AllowUserToDeleteRows = False
        Me.dgw_cta.AllowUserToOrderColumns = True
        Me.dgw_cta.AllowUserToResizeRows = False
        Me.dgw_cta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_cta.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cta.Location = New System.Drawing.Point(9, 1)
        Me.dgw_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta.MultiSelect = False
        Me.dgw_cta.Name = "dgw_cta"
        Me.dgw_cta.ReadOnly = True
        Me.dgw_cta.RowHeadersWidth = 25
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw_cta.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta.Size = New System.Drawing.Size(399, 101)
        Me.dgw_cta.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(180, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Centro costo"
        Me.Label3.Visible = False
        '
        'dgwConceptoCuenta
        '
        Me.dgwConceptoCuenta.AllowUserToAddRows = False
        Me.dgwConceptoCuenta.AllowUserToDeleteRows = False
        Me.dgwConceptoCuenta.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgwConceptoCuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwConceptoCuenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgwConceptoCuenta.Location = New System.Drawing.Point(172, 127)
        Me.dgwConceptoCuenta.MultiSelect = False
        Me.dgwConceptoCuenta.Name = "dgwConceptoCuenta"
        Me.dgwConceptoCuenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwConceptoCuenta.Size = New System.Drawing.Size(419, 259)
        Me.dgwConceptoCuenta.TabIndex = 23
        '
        'Column1
        '
        Me.Column1.HeaderText = "Código"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descripción"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 225
        '
        'Column3
        '
        Me.Column3.HeaderText = "Ok"
        Me.Column3.Name = "Column3"
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column3.Width = 30
        '
        'txtDescCuenta
        '
        Me.txtDescCuenta.Location = New System.Drawing.Point(299, 81)
        Me.txtDescCuenta.Name = "txtDescCuenta"
        Me.txtDescCuenta.Size = New System.Drawing.Size(278, 20)
        Me.txtDescCuenta.TabIndex = 1
        '
        'txtCodCuenta
        '
        Me.txtCodCuenta.Location = New System.Drawing.Point(236, 81)
        Me.txtCodCuenta.Name = "txtCodCuenta"
        Me.txtCodCuenta.Size = New System.Drawing.Size(57, 20)
        Me.txtCodCuenta.TabIndex = 0
        '
        'txtDescConcepto
        '
        Me.txtDescConcepto.Enabled = False
        Me.txtDescConcepto.Location = New System.Drawing.Point(302, 54)
        Me.txtDescConcepto.Name = "txtDescConcepto"
        Me.txtDescConcepto.Size = New System.Drawing.Size(194, 20)
        Me.txtDescConcepto.TabIndex = 12
        '
        'txtCodConcepto
        '
        Me.txtCodConcepto.Enabled = False
        Me.txtCodConcepto.Location = New System.Drawing.Point(236, 54)
        Me.txtCodConcepto.Name = "txtCodConcepto"
        Me.txtCodConcepto.Size = New System.Drawing.Size(57, 20)
        Me.txtCodConcepto.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(177, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Cuenta"
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Location = New System.Drawing.Point(480, 106)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(111, 17)
        Me.chkTodos.TabIndex = 25
        Me.chkTodos.Text = "Seleccionar todos"
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'FrmConceptoCuentaUN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 488)
        Me.ControlBox = False
        Me.Controls.Add(Me.tabConcepto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "FrmConceptoCuentaUN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Concepto - Cuenta"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.f1.ResumeLayout(False)
        CType(Me.dgwListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabConcepto.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.PanelConcepto.ResumeLayout(False)
        CType(Me.dgwConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PaneL_CTA.ResumeLayout(False)
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwConceptoCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents f1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAsociar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgwListado As System.Windows.Forms.DataGridView
    Friend WithEvents tabConcepto As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtDescConcepto As System.Windows.Forms.TextBox
    Friend WithEvents txtCodConcepto As System.Windows.Forms.TextBox
    Friend WithEvents dgwConceptoCuenta As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PaneL_CTA As System.Windows.Forms.Panel
    Friend WithEvents dgw_cta As System.Windows.Forms.DataGridView
    Friend WithEvents txtDescCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents PanelConcepto As System.Windows.Forms.Panel
    Friend WithEvents dgwConcepto As System.Windows.Forms.DataGridView
    Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
