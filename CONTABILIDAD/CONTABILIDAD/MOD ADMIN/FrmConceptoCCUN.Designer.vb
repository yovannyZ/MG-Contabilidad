<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConceptoCCUN
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
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtCentroCosto = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDesCentroCosto = New System.Windows.Forms.TextBox
        Me.txtDescConcepto = New System.Windows.Forms.TextBox
        Me.btnAsociar = New System.Windows.Forms.Button
        Me.f1 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnSalir = New System.Windows.Forms.Button
        Me.txtCodConcepto = New System.Windows.Forms.TextBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgwListado = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.tabConcepto = New System.Windows.Forms.TabControl
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.cboTipo = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgwListaUnidadesNegocio = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.f1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgwListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabConcepto.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgwListaUnidadesNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'txtCentroCosto
        '
        Me.txtCentroCosto.Location = New System.Drawing.Point(210, 67)
        Me.txtCentroCosto.Name = "txtCentroCosto"
        Me.txtCentroCosto.ReadOnly = True
        Me.txtCentroCosto.Size = New System.Drawing.Size(57, 20)
        Me.txtCentroCosto.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(143, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Centro costo"
        '
        'txtDesCentroCosto
        '
        Me.txtDesCentroCosto.Location = New System.Drawing.Point(270, 67)
        Me.txtDesCentroCosto.Name = "txtDesCentroCosto"
        Me.txtDesCentroCosto.ReadOnly = True
        Me.txtDesCentroCosto.Size = New System.Drawing.Size(278, 20)
        Me.txtDesCentroCosto.TabIndex = 4
        '
        'txtDescConcepto
        '
        Me.txtDescConcepto.Location = New System.Drawing.Point(270, 41)
        Me.txtDescConcepto.Name = "txtDescConcepto"
        Me.txtDescConcepto.ReadOnly = True
        Me.txtDescConcepto.Size = New System.Drawing.Size(278, 20)
        Me.txtDescConcepto.TabIndex = 12
        '
        'btnAsociar
        '
        Me.btnAsociar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAsociar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btnAsociar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAsociar.Location = New System.Drawing.Point(3, 3)
        Me.btnAsociar.Name = "btnAsociar"
        Me.btnAsociar.Size = New System.Drawing.Size(77, 29)
        Me.btnAsociar.TabIndex = 1
        Me.btnAsociar.Text = "&Asociar"
        Me.btnAsociar.UseVisualStyleBackColor = True
        '
        'f1
        '
        Me.f1.Controls.Add(Me.btnAsociar)
        Me.f1.Controls.Add(Me.btnSalir)
        Me.f1.Location = New System.Drawing.Point(768, 169)
        Me.f1.Name = "f1"
        Me.f1.Size = New System.Drawing.Size(85, 72)
        Me.f1.TabIndex = 1
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.Location = New System.Drawing.Point(3, 38)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(77, 29)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'txtCodConcepto
        '
        Me.txtCodConcepto.Location = New System.Drawing.Point(210, 41)
        Me.txtCodConcepto.Name = "txtCodConcepto"
        Me.txtCodConcepto.ReadOnly = True
        Me.txtCodConcepto.Size = New System.Drawing.Size(57, 20)
        Me.txtCodConcepto.TabIndex = 11
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
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btnGuardar)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnCancelar)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(394, 343)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(169, 37)
        Me.FlowLayoutPanel1.TabIndex = 10
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgwListado)
        Me.TabPage1.Controls.Add(Me.f1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(868, 425)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Listado"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgwListado
        '
        Me.dgwListado.AllowUserToAddRows = False
        Me.dgwListado.AllowUserToDeleteRows = False
        Me.dgwListado.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgwListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwListado.Location = New System.Drawing.Point(11, 18)
        Me.dgwListado.MultiSelect = False
        Me.dgwListado.Name = "dgwListado"
        Me.dgwListado.ReadOnly = True
        Me.dgwListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwListado.Size = New System.Drawing.Size(751, 347)
        Me.dgwListado.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(143, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Concepto"
        '
        'tabConcepto
        '
        Me.tabConcepto.Controls.Add(Me.TabPage1)
        Me.tabConcepto.Controls.Add(Me.TabPage2)
        Me.tabConcepto.Location = New System.Drawing.Point(-2, 0)
        Me.tabConcepto.Name = "tabConcepto"
        Me.tabConcepto.SelectedIndex = 0
        Me.tabConcepto.Size = New System.Drawing.Size(876, 451)
        Me.tabConcepto.TabIndex = 5
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cboTipo)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.dgwListaUnidadesNegocio)
        Me.TabPage2.Controls.Add(Me.txtDesCentroCosto)
        Me.TabPage2.Controls.Add(Me.txtCentroCosto)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.txtDescConcepto)
        Me.TabPage2.Controls.Add(Me.txtCodConcepto)
        Me.TabPage2.Controls.Add(Me.FlowLayoutPanel1)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(868, 425)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalle"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.White
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Enabled = False
        Me.cboTipo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Items.AddRange(New Object() {"INGRESO", "GASTO", "COSTO"})
        Me.cboTipo.Location = New System.Drawing.Point(210, 13)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(105, 22)
        Me.cboTipo.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(143, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Tipo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(129, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Unidades de Nogocio:"
        '
        'dgwListaUnidadesNegocio
        '
        Me.dgwListaUnidadesNegocio.AllowUserToAddRows = False
        Me.dgwListaUnidadesNegocio.AllowUserToDeleteRows = False
        Me.dgwListaUnidadesNegocio.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgwListaUnidadesNegocio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwListaUnidadesNegocio.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgwListaUnidadesNegocio.Location = New System.Drawing.Point(128, 116)
        Me.dgwListaUnidadesNegocio.MultiSelect = False
        Me.dgwListaUnidadesNegocio.Name = "dgwListaUnidadesNegocio"
        Me.dgwListaUnidadesNegocio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgwListaUnidadesNegocio.Size = New System.Drawing.Size(438, 221)
        Me.dgwListaUnidadesNegocio.TabIndex = 25
        '
        'Column1
        '
        Me.Column1.HeaderText = "Codigo"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descripción"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 240
        '
        'Column3
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.HeaderText = "Porcentaje"
        Me.Column3.Name = "Column3"
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'FrmConceptoCCUN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 446)
        Me.ControlBox = False
        Me.Controls.Add(Me.tabConcepto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmConceptoCCUN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Concepto - Centro costo"
        Me.f1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgwListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabConcepto.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgwListaUnidadesNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtCentroCosto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDesCentroCosto As System.Windows.Forms.TextBox
    Friend WithEvents txtDescConcepto As System.Windows.Forms.TextBox
    Friend WithEvents btnAsociar As System.Windows.Forms.Button
    Friend WithEvents f1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents txtCodConcepto As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgwListado As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabConcepto As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgwListaUnidadesNegocio As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
