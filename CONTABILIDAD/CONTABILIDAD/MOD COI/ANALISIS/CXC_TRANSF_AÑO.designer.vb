Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CXC_TRANSF_AÑO
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Elegir = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.btn_salir = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbVenta = New System.Windows.Forms.RadioButton
        Me.rbCompra = New System.Windows.Forms.RadioButton
        Me.ch_ajuste = New System.Windows.Forms.CheckBox
        Me.ch1 = New System.Windows.Forms.CheckBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ch2 = New System.Windows.Forms.CheckBox
        Me.btn_salir2 = New System.Windows.Forms.Button
        Me.btn_aceptar2 = New System.Windows.Forms.Button
        Me.dgw2 = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgw2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Elegir las Cuentas:"
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AllowUserToOrderColumns = True
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cuenta, Me.desc, Me.Elegir, Me.Column1})
        Me.dgw1.Location = New System.Drawing.Point(8, 33)
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.RowHeadersWidth = 25
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(561, 234)
        Me.dgw1.TabIndex = 0
        '
        'Cuenta
        '
        Me.Cuenta.FillWeight = 40.0!
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.Width = 85
        '
        'desc
        '
        Me.desc.FillWeight = 200.0!
        Me.desc.HeaderText = "Descripción"
        Me.desc.Name = "desc"
        Me.desc.Width = 280
        '
        'Elegir
        '
        Me.Elegir.FillWeight = 30.0!
        Me.Elegir.HeaderText = "Elegir Cuenta"
        Me.Elegir.Name = "Elegir"
        Me.Elegir.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Elegir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Elegir.Width = 80
        '
        'Column1
        '
        Me.Column1.HeaderText = "Dif.Cambio"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 78
        '
        'btn_aceptar
        '
        Me.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aceptar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar.Location = New System.Drawing.Point(295, 297)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(79, 31)
        Me.btn_aceptar.TabIndex = 1
        Me.btn_aceptar.Text = "&Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(380, 297)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(79, 31)
        Me.btn_salir.TabIndex = 2
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.rbVenta)
        Me.GroupBox1.Controls.Add(Me.rbCompra)
        Me.GroupBox1.Controls.Add(Me.ch_ajuste)
        Me.GroupBox1.Controls.Add(Me.ch1)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.btn_aceptar)
        Me.GroupBox1.Controls.Add(Me.dgw1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(575, 378)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'rbVenta
        '
        Me.rbVenta.AutoSize = True
        Me.rbVenta.Location = New System.Drawing.Point(11, 345)
        Me.rbVenta.Name = "rbVenta"
        Me.rbVenta.Size = New System.Drawing.Size(114, 18)
        Me.rbVenta.TabIndex = 165
        Me.rbVenta.Text = "Tipo Cambio Venta"
        Me.rbVenta.UseVisualStyleBackColor = True
        '
        'rbCompra
        '
        Me.rbCompra.AutoSize = True
        Me.rbCompra.Checked = True
        Me.rbCompra.Location = New System.Drawing.Point(11, 321)
        Me.rbCompra.Name = "rbCompra"
        Me.rbCompra.Size = New System.Drawing.Size(123, 18)
        Me.rbCompra.TabIndex = 164
        Me.rbCompra.TabStop = True
        Me.rbCompra.Text = "Tipo Cambio Compra"
        Me.rbCompra.UseVisualStyleBackColor = True
        '
        'ch_ajuste
        '
        Me.ch_ajuste.AutoSize = True
        Me.ch_ajuste.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ch_ajuste.Location = New System.Drawing.Point(11, 297)
        Me.ch_ajuste.Name = "ch_ajuste"
        Me.ch_ajuste.Size = New System.Drawing.Size(142, 18)
        Me.ch_ajuste.TabIndex = 4
        Me.ch_ajuste.Text = "Seleccionar Todo Ajuste"
        Me.ch_ajuste.UseVisualStyleBackColor = True
        '
        'ch1
        '
        Me.ch1.AutoSize = True
        Me.ch1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ch1.Location = New System.Drawing.Point(11, 273)
        Me.ch1.Name = "ch1"
        Me.ch1.Size = New System.Drawing.Size(109, 18)
        Me.ch1.TabIndex = 3
        Me.ch1.Text = "Seleccionar Todo"
        Me.ch1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(586, 405)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(578, 378)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cierre"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(578, 378)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Regresar Cierre"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.ch2)
        Me.GroupBox2.Controls.Add(Me.btn_salir2)
        Me.GroupBox2.Controls.Add(Me.btn_aceptar2)
        Me.GroupBox2.Controls.Add(Me.dgw2)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(562, 357)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'ch2
        '
        Me.ch2.AutoSize = True
        Me.ch2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ch2.Location = New System.Drawing.Point(26, 273)
        Me.ch2.Name = "ch2"
        Me.ch2.Size = New System.Drawing.Size(109, 18)
        Me.ch2.TabIndex = 3
        Me.ch2.Text = "Seleccionar Todo"
        Me.ch2.UseVisualStyleBackColor = True
        '
        'btn_salir2
        '
        Me.btn_salir2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir2.Location = New System.Drawing.Point(400, 297)
        Me.btn_salir2.Name = "btn_salir2"
        Me.btn_salir2.Size = New System.Drawing.Size(79, 31)
        Me.btn_salir2.TabIndex = 2
        Me.btn_salir2.Text = "&Salir"
        Me.btn_salir2.UseVisualStyleBackColor = True
        '
        'btn_aceptar2
        '
        Me.btn_aceptar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aceptar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_aceptar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar2.Location = New System.Drawing.Point(315, 297)
        Me.btn_aceptar2.Name = "btn_aceptar2"
        Me.btn_aceptar2.Size = New System.Drawing.Size(79, 31)
        Me.btn_aceptar2.TabIndex = 1
        Me.btn_aceptar2.Text = "&Aceptar"
        Me.btn_aceptar2.UseVisualStyleBackColor = True
        '
        'dgw2
        '
        Me.dgw2.AllowUserToAddRows = False
        Me.dgw2.AllowUserToDeleteRows = False
        Me.dgw2.AllowUserToOrderColumns = True
        Me.dgw2.BackgroundColor = System.Drawing.Color.White
        Me.dgw2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewCheckBoxColumn1})
        Me.dgw2.Location = New System.Drawing.Point(26, 33)
        Me.dgw2.MultiSelect = False
        Me.dgw2.Name = "dgw2"
        Me.dgw2.RowHeadersWidth = 25
        Me.dgw2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw2.Size = New System.Drawing.Size(478, 234)
        Me.dgw2.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 40.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Cuenta"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 85
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 200.0!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 290
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.FillWeight = 30.0!
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Elegir"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckBoxColumn1.Width = 45
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Elegir las Cuentas:"
        '
        'CXC_TRANSF_AÑO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 405)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CXC_TRANSF_AÑO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierre Anual  de Cuentas por Cobrar"
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgw2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_aceptar As Button
    Friend WithEvents btn_aceptar2 As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents btn_salir2 As Button
    Friend WithEvents ch1 As CheckBox
    Friend WithEvents ch2 As CheckBox
    Friend WithEvents dgw1 As DataGridView
    Friend WithEvents dgw2 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ch_ajuste As System.Windows.Forms.CheckBox
    Friend WithEvents rbVenta As System.Windows.Forms.RadioButton
    Friend WithEvents rbCompra As System.Windows.Forms.RadioButton
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Elegir As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
