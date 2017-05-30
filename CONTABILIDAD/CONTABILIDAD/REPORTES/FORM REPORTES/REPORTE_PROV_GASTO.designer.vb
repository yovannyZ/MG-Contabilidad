Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_PROV_GASTO
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbo_prov = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbo_orden = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.btn_cancelar1 = New System.Windows.Forms.Button
        Me.dgw_importe = New System.Windows.Forms.DataGridView
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gb1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgw_importe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(191, 235)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(190, 64)
        Me.gb1.TabIndex = 3
        Me.gb1.TabStop = False
        '
        'btn_pantalla1
        '
        Me.btn_pantalla1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pantalla1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pantalla1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla1.Location = New System.Drawing.Point(55, 19)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(77, 31)
        Me.btn_pantalla1.TabIndex = 7
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbo_año)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbo_prov)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbo_orden)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbo_mes)
        Me.GroupBox1.Controls.Add(Me.btn_cancelar1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(39, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(474, 190)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cbo_año
        '
        Me.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año.FormattingEnabled = True
        Me.cbo_año.Location = New System.Drawing.Point(207, 94)
        Me.cbo_año.Name = "cbo_año"
        Me.cbo_año.Size = New System.Drawing.Size(79, 22)
        Me.cbo_año.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(99, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 14)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "Año"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(99, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 14)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Provisiones"
        '
        'cbo_prov
        '
        Me.cbo_prov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_prov.FormattingEnabled = True
        Me.cbo_prov.Items.AddRange(New Object() {"REGISTRO COMPRAS", "REGISTRO VENTAS"})
        Me.cbo_prov.Location = New System.Drawing.Point(207, 68)
        Me.cbo_prov.Name = "cbo_prov"
        Me.cbo_prov.Size = New System.Drawing.Size(135, 22)
        Me.cbo_prov.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(99, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 14)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Orden"
        '
        'cbo_orden
        '
        Me.cbo_orden.BackColor = System.Drawing.Color.White
        Me.cbo_orden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_orden.FormattingEnabled = True
        Me.cbo_orden.Items.AddRange(New Object() {"FECHA", "COMPROBANTE", "Nº DOCUMENTO"})
        Me.cbo_orden.Location = New System.Drawing.Point(207, 120)
        Me.cbo_orden.Name = "cbo_orden"
        Me.cbo_orden.Size = New System.Drawing.Size(135, 22)
        Me.cbo_orden.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(99, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 14)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Mes"
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"INICIO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(207, 42)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(135, 22)
        Me.cbo_mes.TabIndex = 1
        '
        'btn_cancelar1
        '
        Me.btn_cancelar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btn_cancelar1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar1.Location = New System.Drawing.Point(375, 134)
        Me.btn_cancelar1.Name = "btn_cancelar1"
        Me.btn_cancelar1.Size = New System.Drawing.Size(77, 31)
        Me.btn_cancelar1.TabIndex = 100
        Me.btn_cancelar1.TabStop = False
        Me.btn_cancelar1.Text = "&Salir"
        Me.btn_cancelar1.UseVisualStyleBackColor = True
        '
        'dgw_importe
        '
        Me.dgw_importe.AllowUserToAddRows = False
        Me.dgw_importe.AllowUserToDeleteRows = False
        Me.dgw_importe.AllowUserToOrderColumns = True
        Me.dgw_importe.AllowUserToResizeRows = False
        Me.dgw_importe.BackgroundColor = System.Drawing.Color.White
        Me.dgw_importe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_importe.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column20, Me.Column9, Me.Column21, Me.Column22, Me.Column40, Me.Column1, Me.Column2, Me.Column4, Me.Column3, Me.Column5})
        Me.dgw_importe.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.dgw_importe.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgw_importe.Location = New System.Drawing.Point(0, 173)
        Me.dgw_importe.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgw_importe.MultiSelect = False
        Me.dgw_importe.Name = "dgw_importe"
        Me.dgw_importe.RowHeadersWidth = 25
        Me.dgw_importe.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_importe.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_importe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_importe.ShowRowErrors = False
        Me.dgw_importe.Size = New System.Drawing.Size(550, 144)
        Me.dgw_importe.TabIndex = 102
        Me.dgw_importe.Visible = False
        '
        'Column10
        '
        Me.Column10.HeaderText = "c.com"
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 55
        '
        'Column11
        '
        Me.Column11.HeaderText = "Nº com"
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 55
        '
        'Column12
        '
        Me.Column12.HeaderText = "c.doc-nºdoc"
        Me.Column12.Name = "Column12"
        '
        'Column13
        '
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Column13.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column13.HeaderText = "fecha_doc"
        Me.Column13.Name = "Column13"
        Me.Column13.Width = 70
        '
        'Column14
        '
        DataGridViewCellStyle4.Format = "d"
        Me.Column14.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column14.HeaderText = "fecha_ven"
        Me.Column14.Name = "Column14"
        Me.Column14.Width = 70
        '
        'Column15
        '
        Me.Column15.HeaderText = "Nº doc per"
        Me.Column15.Name = "Column15"
        Me.Column15.Width = 85
        '
        'Column16
        '
        Me.Column16.HeaderText = "desc_prov"
        Me.Column16.Name = "Column16"
        '
        'Column20
        '
        Me.Column20.HeaderText = "cod_per"
        Me.Column20.Name = "Column20"
        Me.Column20.Width = 30
        '
        'Column9
        '
        Me.Column9.HeaderText = "c.doc"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 30
        '
        'Column21
        '
        Me.Column21.HeaderText = "des_doc"
        Me.Column21.Name = "Column21"
        Me.Column21.Width = 50
        '
        'Column22
        '
        Me.Column22.HeaderText = "mon"
        Me.Column22.Name = "Column22"
        Me.Column22.Width = 35
        '
        'Column40
        '
        Me.Column40.HeaderText = "SERIE"
        Me.Column40.Name = "Column40"
        '
        'Column1
        '
        Me.Column1.HeaderText = "total"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "prov"
        Me.Column2.Name = "Column2"
        '
        'Column4
        '
        Me.Column4.HeaderText = "st_gasto"
        Me.Column4.Name = "Column4"
        '
        'Column3
        '
        Me.Column3.HeaderText = "DOC"
        Me.Column3.Name = "Column3"
        '
        'Column5
        '
        Me.Column5.HeaderText = "FALTAN"
        Me.Column5.Name = "Column5"
        '
        'REPORTE_PROV_GASTO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 317)
        Me.ControlBox = False
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgw_importe)
        Me.Name = "REPORTE_PROV_GASTO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Provisiones"
        Me.gb1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgw_importe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_cancelar1 As Button
    Friend WithEvents btn_pantalla1 As Button
    Friend WithEvents cbo_mes As ComboBox
    Friend WithEvents cbo_orden As ComboBox
    Friend WithEvents cbo_prov As ComboBox
    Friend WithEvents dgw_importe As DataGridView
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cbo_año As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
