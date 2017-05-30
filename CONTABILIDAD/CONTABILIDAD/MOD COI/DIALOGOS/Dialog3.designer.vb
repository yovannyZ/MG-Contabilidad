<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog3
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
        Me.BTN_CANCELAR = New System.Windows.Forms.Button
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button
        Me.DGW_DET = New System.Windows.Forms.DataGridView
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column38 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column44 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column45 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column18 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DGW_DET, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTN_CANCELAR
        '
        Me.BTN_CANCELAR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_CANCELAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_CANCELAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CANCELAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.BTN_CANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_CANCELAR.Location = New System.Drawing.Point(588, 313)
        Me.BTN_CANCELAR.Name = "BTN_CANCELAR"
        Me.BTN_CANCELAR.Size = New System.Drawing.Size(70, 25)
        Me.BTN_CANCELAR.TabIndex = 1
        Me.BTN_CANCELAR.Text = "&Salir"
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BTN_ACEPTAR.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BTN_ACEPTAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_ACEPTAR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Ok_1
        Me.BTN_ACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(486, 313)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(96, 25)
        Me.BTN_ACEPTAR.TabIndex = 0
        Me.BTN_ACEPTAR.Text = "&Agregar "
        '
        'DGW_DET
        '
        Me.DGW_DET.AllowUserToAddRows = False
        Me.DGW_DET.AllowUserToDeleteRows = False
        Me.DGW_DET.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.DGW_DET.BackgroundColor = System.Drawing.Color.White
        Me.DGW_DET.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column19, Me.Column38, Me.Column44, Me.Column22, Me.Column45, Me.Column18, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column9, Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column20})
        Me.DGW_DET.Dock = System.Windows.Forms.DockStyle.Top
        Me.DGW_DET.Location = New System.Drawing.Point(0, 0)
        Me.DGW_DET.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DGW_DET.MultiSelect = False
        Me.DGW_DET.Name = "DGW_DET"
        Me.DGW_DET.RowHeadersWidth = 25
        Me.DGW_DET.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DGW_DET.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DGW_DET.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGW_DET.ShowCellErrors = False
        Me.DGW_DET.ShowRowErrors = False
        Me.DGW_DET.Size = New System.Drawing.Size(674, 294)
        Me.DGW_DET.TabIndex = 172
        '
        'Column10
        '
        Me.Column10.HeaderText = "Aux"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 30
        '
        'Column11
        '
        Me.Column11.HeaderText = "Comp."
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 40
        '
        'Column12
        '
        Me.Column12.HeaderText = "N°Comp."
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 60
        '
        'Column13
        '
        Me.Column13.HeaderText = "Doc"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Width = 30
        '
        'Column5
        '
        Me.Column5.HeaderText = "N° Doc."
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Per."
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 45
        '
        'Column7
        '
        Me.Column7.HeaderText = "Desc. Per"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 180
        '
        'Column8
        '
        Me.Column8.HeaderText = "nro doc"
        Me.Column8.Name = "Column8"
        Me.Column8.Visible = False
        '
        'Column19
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "n2"
        Me.Column19.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column19.HeaderText = "Importe "
        Me.Column19.Name = "Column19"
        Me.Column19.Width = 70
        '
        'Column38
        '
        Me.Column38.HeaderText = "Mon"
        Me.Column38.Name = "Column38"
        Me.Column38.Width = 35
        '
        'Column44
        '
        Me.Column44.HeaderText = "sucursal"
        Me.Column44.Name = "Column44"
        Me.Column44.Visible = False
        '
        'Column22
        '
        Me.Column22.HeaderText = "doc per llave"
        Me.Column22.Name = "Column22"
        Me.Column22.Visible = False
        '
        'Column45
        '
        Me.Column45.HeaderText = "D/H"
        Me.Column45.Name = "Column45"
        Me.Column45.Width = 30
        '
        'Column18
        '
        Me.Column18.FillWeight = 30.0!
        Me.Column18.HeaderText = "Ok"
        Me.Column18.Name = "Column18"
        Me.Column18.Width = 25
        '
        'Column1
        '
        Me.Column1.HeaderText = "FECHA DOC"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "FECHA VEN"
        Me.Column2.Name = "Column2"
        Me.Column2.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "TC"
        Me.Column3.Name = "Column3"
        Me.Column3.Visible = False
        '
        'Column4
        '
        Me.Column4.HeaderText = "COD_REF"
        Me.Column4.Name = "Column4"
        Me.Column4.Visible = False
        '
        'Column9
        '
        Me.Column9.HeaderText = "NRO_REF"
        Me.Column9.Name = "Column9"
        Me.Column9.Visible = False
        '
        'Column14
        '
        Me.Column14.HeaderText = "FEC_REF"
        Me.Column14.Name = "Column14"
        Me.Column14.Visible = False
        '
        'Column15
        '
        Me.Column15.HeaderText = "TIPO_OPE"
        Me.Column15.Name = "Column15"
        Me.Column15.Visible = False
        '
        'Column16
        '
        Me.Column16.HeaderText = "GLOSA"
        Me.Column16.Name = "Column16"
        Me.Column16.Visible = False
        '
        'Column17
        '
        Me.Column17.HeaderText = "AÑO"
        Me.Column17.Name = "Column17"
        Me.Column17.Visible = False
        '
        'Column20
        '
        Me.Column20.HeaderText = "MES"
        Me.Column20.Name = "Column20"
        Me.Column20.Visible = False
        '
        'Dialog2
        '
        Me.AcceptButton = Me.BTN_CANCELAR
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BTN_ACEPTAR
        Me.ClientSize = New System.Drawing.Size(674, 361)
        Me.ControlBox = False
        Me.Controls.Add(Me.DGW_DET)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.BTN_CANCELAR)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ordenes de Compra"
        CType(Me.DGW_DET, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents BTN_CANCELAR As Button
    Friend WithEvents DGW_DET As System.Windows.Forms.DataGridView
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column44 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column45 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn


End Class
