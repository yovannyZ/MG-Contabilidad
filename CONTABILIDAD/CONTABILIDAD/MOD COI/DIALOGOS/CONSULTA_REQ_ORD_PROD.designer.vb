Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CONSULTA_REQ_ORD_PROD
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
        Me.DGW_DET = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGW_CAB = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button
        Me.BTN_CANCELAR = New System.Windows.Forms.Button
        Me.LBL_G = New System.Windows.Forms.Label
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.ch_rs = New System.Windows.Forms.RadioButton
        Me.ch_cod = New System.Windows.Forms.RadioButton
        Me.txt_letra = New System.Windows.Forms.TextBox
        CType(Me.DGW_DET, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGW_CAB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGW_DET
        '
        Me.DGW_DET.AllowUserToAddRows = False
        Me.DGW_DET.AllowUserToDeleteRows = False
        Me.DGW_DET.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.DGW_DET.BackgroundColor = System.Drawing.Color.White
        Me.DGW_DET.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.DGW_DET.Location = New System.Drawing.Point(109, 206)
        Me.DGW_DET.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DGW_DET.MultiSelect = False
        Me.DGW_DET.Name = "DGW_DET"
        Me.DGW_DET.ReadOnly = True
        Me.DGW_DET.RowHeadersWidth = 25
        Me.DGW_DET.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DGW_DET.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DGW_DET.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGW_DET.Size = New System.Drawing.Size(457, 159)
        Me.DGW_DET.TabIndex = 24
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Cod"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Actividad"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 350
        '
        'DGW_CAB
        '
        Me.DGW_CAB.AllowUserToAddRows = False
        Me.DGW_CAB.AllowUserToDeleteRows = False
        Me.DGW_CAB.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.DGW_CAB.BackgroundColor = System.Drawing.Color.White
        Me.DGW_CAB.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.DGW_CAB.Dock = System.Windows.Forms.DockStyle.Top
        Me.DGW_CAB.Location = New System.Drawing.Point(0, 0)
        Me.DGW_CAB.Name = "DGW_CAB"
        Me.DGW_CAB.ReadOnly = True
        Me.DGW_CAB.RowHeadersWidth = 25
        Me.DGW_CAB.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DGW_CAB.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DGW_CAB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGW_CAB.Size = New System.Drawing.Size(674, 200)
        Me.DGW_CAB.TabIndex = 25
        '
        'Column1
        '
        Me.Column1.HeaderText = "Nº Ord. Prod."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descripción"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        Me.Column2.Width = 250
        '
        'Column3
        '
        DataGridViewCellStyle1.Format = "d"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.HeaderText = "Fecha"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 75
        '
        'Column4
        '
        Me.Column4.HeaderText = "Cod.Art."
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 95
        '
        'Column5
        '
        Me.Column5.HeaderText = "Descripción"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 300
        '
        'Column6
        '
        Me.Column6.HeaderText = "Año"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 35
        '
        'Column7
        '
        Me.Column7.HeaderText = "Mes"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 30
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_ACEPTAR.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BTN_ACEPTAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_ACEPTAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Ok_1
        Me.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(477, 404)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(72, 25)
        Me.BTN_ACEPTAR.TabIndex = 26
        Me.BTN_ACEPTAR.Text = "&Agregar"
        '
        'BTN_CANCELAR
        '
        Me.BTN_CANCELAR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_CANCELAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_CANCELAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CANCELAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.BTN_CANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_CANCELAR.Location = New System.Drawing.Point(555, 404)
        Me.BTN_CANCELAR.Name = "BTN_CANCELAR"
        Me.BTN_CANCELAR.Size = New System.Drawing.Size(67, 25)
        Me.BTN_CANCELAR.TabIndex = 27
        Me.BTN_CANCELAR.Text = "&Salir"
        '
        'LBL_G
        '
        Me.LBL_G.AutoSize = True
        Me.LBL_G.Location = New System.Drawing.Point(269, 324)
        Me.LBL_G.Name = "LBL_G"
        Me.LBL_G.Size = New System.Drawing.Size(39, 14)
        Me.LBL_G.TabIndex = 29
        Me.LBL_G.Text = "Label1"
        Me.LBL_G.Visible = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.ch_rs)
        Me.GroupBox8.Controls.Add(Me.ch_cod)
        Me.GroupBox8.Controls.Add(Me.txt_letra)
        Me.GroupBox8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(0, 371)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(231, 65)
        Me.GroupBox8.TabIndex = 30
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Buscado por:"
        '
        'ch_rs
        '
        Me.ch_rs.AutoSize = True
        Me.ch_rs.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_rs.Location = New System.Drawing.Point(6, 41)
        Me.ch_rs.Name = "ch_rs"
        Me.ch_rs.Size = New System.Drawing.Size(89, 18)
        Me.ch_rs.TabIndex = 2
        Me.ch_rs.Text = "Nº Ord. Prod."
        Me.ch_rs.UseVisualStyleBackColor = True
        '
        'ch_cod
        '
        Me.ch_cod.AutoSize = True
        Me.ch_cod.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_cod.Location = New System.Drawing.Point(100, 40)
        Me.ch_cod.Name = "ch_cod"
        Me.ch_cod.Size = New System.Drawing.Size(82, 18)
        Me.ch_cod.TabIndex = 1
        Me.ch_cod.Text = "Descripción"
        Me.ch_cod.UseVisualStyleBackColor = True
        '
        'txt_letra
        '
        Me.txt_letra.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_letra.Location = New System.Drawing.Point(6, 19)
        Me.txt_letra.Name = "txt_letra"
        Me.txt_letra.Size = New System.Drawing.Size(206, 20)
        Me.txt_letra.TabIndex = 0
        '
        'CONSULTA_REQ_ORD_PROD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 457)
        Me.ControlBox = False
        Me.Controls.Add(Me.DGW_DET)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.LBL_G)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.BTN_CANCELAR)
        Me.Controls.Add(Me.DGW_CAB)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CONSULTA_REQ_ORD_PROD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Orden de Producción"
        CType(Me.DGW_DET, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGW_CAB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents BTN_CANCELAR As Button
    Friend WithEvents ch_cod As RadioButton
    Friend WithEvents ch_rs As RadioButton
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DGW_CAB As DataGridView
    Friend WithEvents DGW_DET As DataGridView
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents LBL_G As Label
    Friend WithEvents txt_letra As TextBox
End Class
