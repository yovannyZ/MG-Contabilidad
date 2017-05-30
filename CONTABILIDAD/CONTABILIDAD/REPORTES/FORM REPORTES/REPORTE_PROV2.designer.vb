Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_PROV2
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbo_prov = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbo_mes2 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbo_mes1 = New System.Windows.Forms.ComboBox
        Me.btn_cancelar1 = New System.Windows.Forms.Button
        Me.dgw_importe = New System.Windows.Forms.DataGridView
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column27 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column28 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column29 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column30 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column31 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column32 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column34 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column35 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column36 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column37 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column38 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column39 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgw_calculo = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gb1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgw_importe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgw_calculo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(154, 252)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(242, 62)
        Me.gb1.TabIndex = 104
        Me.gb1.TabStop = False
        '
        'btn_pantalla1
        '
        Me.btn_pantalla1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pantalla1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pantalla1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla1.Location = New System.Drawing.Point(82, 19)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(77, 31)
        Me.btn_pantalla1.TabIndex = 0
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbo_prov)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbo_mes2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbo_mes1)
        Me.GroupBox1.Controls.Add(Me.btn_cancelar1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(68, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(418, 196)
        Me.GroupBox1.TabIndex = 103
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(48, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 14)
        Me.Label5.TabIndex = 96
        Me.Label5.Text = "Provisiones"
        '
        'cbo_prov
        '
        Me.cbo_prov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_prov.FormattingEnabled = True
        Me.cbo_prov.Items.AddRange(New Object() {"REGISTRO COMPRAS", "REGISTRO VENTAS", "REGISTRO HONORARIOS"})
        Me.cbo_prov.Location = New System.Drawing.Point(158, 123)
        Me.cbo_prov.Name = "cbo_prov"
        Me.cbo_prov.Size = New System.Drawing.Size(135, 22)
        Me.cbo_prov.TabIndex = 95
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(48, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 14)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Al mes"
        '
        'cbo_mes2
        '
        Me.cbo_mes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes2.FormattingEnabled = True
        Me.cbo_mes2.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbo_mes2.Location = New System.Drawing.Point(158, 88)
        Me.cbo_mes2.Name = "cbo_mes2"
        Me.cbo_mes2.Size = New System.Drawing.Size(135, 22)
        Me.cbo_mes2.TabIndex = 93
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 14)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Del mes"
        '
        'cbo_mes1
        '
        Me.cbo_mes1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes1.FormattingEnabled = True
        Me.cbo_mes1.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbo_mes1.Location = New System.Drawing.Point(158, 53)
        Me.cbo_mes1.Name = "cbo_mes1"
        Me.cbo_mes1.Size = New System.Drawing.Size(135, 22)
        Me.cbo_mes1.TabIndex = 84
        '
        'btn_cancelar1
        '
        Me.btn_cancelar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btn_cancelar1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar1.Location = New System.Drawing.Point(320, 113)
        Me.btn_cancelar1.Name = "btn_cancelar1"
        Me.btn_cancelar1.Size = New System.Drawing.Size(77, 31)
        Me.btn_cancelar1.TabIndex = 80
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
        Me.dgw_importe.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column9, Me.Column21, Me.Column22, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column23, Me.Column24, Me.Column25, Me.Column3, Me.Column4, Me.Column26, Me.Column27, Me.Column28, Me.Column29, Me.Column30, Me.Column31, Me.Column32, Me.Column33, Me.Column34, Me.Column35, Me.Column36, Me.Column37, Me.Column38, Me.Column39})
        Me.dgw_importe.Location = New System.Drawing.Point(11, 214)
        Me.dgw_importe.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgw_importe.MultiSelect = False
        Me.dgw_importe.Name = "dgw_importe"
        Me.dgw_importe.RowHeadersWidth = 25
        Me.dgw_importe.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_importe.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_importe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_importe.ShowRowErrors = False
        Me.dgw_importe.Size = New System.Drawing.Size(103, 79)
        Me.dgw_importe.TabIndex = 106
        Me.dgw_importe.Visible = False
        '
        'Column9
        '
        Me.Column9.HeaderText = "doc"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 25
        '
        'Column21
        '
        Me.Column21.HeaderText = "des_doc"
        Me.Column21.Name = "Column21"
        Me.Column21.Width = 60
        '
        'Column22
        '
        Me.Column22.HeaderText = "m"
        Me.Column22.Name = "Column22"
        Me.Column22.Width = 25
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn2.HeaderText = "1"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 45
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn3.HeaderText = "2"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 45
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn4.HeaderText = "3"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 45
        '
        'Column5
        '
        Me.Column5.HeaderText = "4"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 45
        '
        'Column6
        '
        Me.Column6.HeaderText = "5"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 45
        '
        'Column7
        '
        Me.Column7.HeaderText = "6"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 45
        '
        'Column8
        '
        Me.Column8.HeaderText = "7"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 45
        '
        'Column23
        '
        Me.Column23.HeaderText = "8"
        Me.Column23.Name = "Column23"
        Me.Column23.Width = 45
        '
        'Column24
        '
        Me.Column24.HeaderText = "9"
        Me.Column24.Name = "Column24"
        Me.Column24.Width = 45
        '
        'Column25
        '
        Me.Column25.HeaderText = "10"
        Me.Column25.Name = "Column25"
        Me.Column25.Width = 45
        '
        'Column3
        '
        Me.Column3.HeaderText = "R1"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 45
        '
        'Column4
        '
        Me.Column4.HeaderText = "R2"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 45
        '
        'Column26
        '
        Me.Column26.HeaderText = "R3"
        Me.Column26.Name = "Column26"
        Me.Column26.Width = 45
        '
        'Column27
        '
        Me.Column27.HeaderText = "R4"
        Me.Column27.Name = "Column27"
        Me.Column27.Width = 45
        '
        'Column28
        '
        Me.Column28.HeaderText = "R5"
        Me.Column28.Name = "Column28"
        Me.Column28.Width = 45
        '
        'Column29
        '
        Me.Column29.HeaderText = "R6"
        Me.Column29.Name = "Column29"
        Me.Column29.Width = 45
        '
        'Column30
        '
        Me.Column30.HeaderText = "R7"
        Me.Column30.Name = "Column30"
        Me.Column30.Width = 45
        '
        'Column31
        '
        Me.Column31.HeaderText = "R8"
        Me.Column31.Name = "Column31"
        Me.Column31.Width = 45
        '
        'Column32
        '
        Me.Column32.HeaderText = "S1"
        Me.Column32.Name = "Column32"
        Me.Column32.Width = 40
        '
        'Column33
        '
        Me.Column33.HeaderText = "S2"
        Me.Column33.Name = "Column33"
        Me.Column33.Width = 40
        '
        'Column34
        '
        Me.Column34.HeaderText = "S3"
        Me.Column34.Name = "Column34"
        Me.Column34.Width = 40
        '
        'Column35
        '
        Me.Column35.HeaderText = "S4"
        Me.Column35.Name = "Column35"
        Me.Column35.Width = 40
        '
        'Column36
        '
        Me.Column36.HeaderText = "S5"
        Me.Column36.Name = "Column36"
        Me.Column36.Width = 40
        '
        'Column37
        '
        DataGridViewCellStyle4.Format = "n2"
        Me.Column37.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column37.HeaderText = "S6"
        Me.Column37.Name = "Column37"
        Me.Column37.Width = 40
        '
        'Column38
        '
        Me.Column38.HeaderText = "S7"
        Me.Column38.Name = "Column38"
        Me.Column38.Width = 40
        '
        'Column39
        '
        Me.Column39.HeaderText = "S8"
        Me.Column39.Name = "Column39"
        Me.Column39.Width = 40
        '
        'dgw_calculo
        '
        Me.dgw_calculo.AllowUserToAddRows = False
        Me.dgw_calculo.AllowUserToDeleteRows = False
        Me.dgw_calculo.AllowUserToOrderColumns = True
        Me.dgw_calculo.AllowUserToResizeRows = False
        Me.dgw_calculo.BackgroundColor = System.Drawing.Color.White
        Me.dgw_calculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_calculo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.dgw_calculo.Location = New System.Drawing.Point(11, 214)
        Me.dgw_calculo.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgw_calculo.MultiSelect = False
        Me.dgw_calculo.Name = "dgw_calculo"
        Me.dgw_calculo.RowHeadersWidth = 25
        Me.dgw_calculo.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_calculo.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_calculo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_calculo.ShowRowErrors = False
        Me.dgw_calculo.Size = New System.Drawing.Size(87, 72)
        Me.dgw_calculo.TabIndex = 105
        Me.dgw_calculo.Visible = False
        '
        'Column1
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column1.HeaderText = "Item"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 35
        '
        'Column2
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column2.HeaderText = "Cálculo"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 80
        '
        'REPORTE_PROV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 335)
        Me.ControlBox = False
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgw_importe)
        Me.Controls.Add(Me.dgw_calculo)
        Me.Name = "REPORTE_PROV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Resumen"
        Me.gb1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgw_importe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgw_calculo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_cancelar1 As Button
    Friend WithEvents btn_pantalla1 As Button
    Friend WithEvents cbo_mes1 As ComboBox
    Friend WithEvents cbo_mes2 As ComboBox
    Friend WithEvents cbo_prov As ComboBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column21 As DataGridViewTextBoxColumn
    Friend WithEvents Column22 As DataGridViewTextBoxColumn
    Friend WithEvents Column23 As DataGridViewTextBoxColumn
    Friend WithEvents Column24 As DataGridViewTextBoxColumn
    Friend WithEvents Column25 As DataGridViewTextBoxColumn
    Friend WithEvents Column26 As DataGridViewTextBoxColumn
    Friend WithEvents Column27 As DataGridViewTextBoxColumn
    Friend WithEvents Column28 As DataGridViewTextBoxColumn
    Friend WithEvents Column29 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column30 As DataGridViewTextBoxColumn
    Friend WithEvents Column31 As DataGridViewTextBoxColumn
    Friend WithEvents Column32 As DataGridViewTextBoxColumn
    Friend WithEvents Column33 As DataGridViewTextBoxColumn
    Friend WithEvents Column34 As DataGridViewTextBoxColumn
    Friend WithEvents Column35 As DataGridViewTextBoxColumn
    Friend WithEvents Column36 As DataGridViewTextBoxColumn
    Friend WithEvents Column37 As DataGridViewTextBoxColumn
    Friend WithEvents Column38 As DataGridViewTextBoxColumn
    Friend WithEvents Column39 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents dgw_calculo As DataGridView
    Friend WithEvents dgw_importe As DataGridView
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label

End Class
