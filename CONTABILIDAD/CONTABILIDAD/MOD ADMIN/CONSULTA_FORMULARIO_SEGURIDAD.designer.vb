<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CONSULTA_FORMULARIO_SEGURIDAD
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chk_menu = New System.Windows.Forms.CheckBox
        Me.BTN_CONSULTA1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbo_mod = New System.Windows.Forms.ComboBox
        Me.cbo_menu = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DGW1 = New System.Windows.Forms.DataGridView
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_imprimir = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGW1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_menu)
        Me.GroupBox1.Controls.Add(Me.BTN_CONSULTA1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbo_mod)
        Me.GroupBox1.Controls.Add(Me.cbo_menu)
        Me.GroupBox1.Location = New System.Drawing.Point(214, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(426, 93)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chk_menu
        '
        Me.chk_menu.AutoSize = True
        Me.chk_menu.Location = New System.Drawing.Point(75, 50)
        Me.chk_menu.Name = "chk_menu"
        Me.chk_menu.Size = New System.Drawing.Size(15, 14)
        Me.chk_menu.TabIndex = 17
        Me.chk_menu.UseVisualStyleBackColor = True
        '
        'BTN_CONSULTA1
        '
        Me.BTN_CONSULTA1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CONSULTA1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.BTN_CONSULTA1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Search_1
        Me.BTN_CONSULTA1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_CONSULTA1.Location = New System.Drawing.Point(343, 47)
        Me.BTN_CONSULTA1.Name = "BTN_CONSULTA1"
        Me.BTN_CONSULTA1.Size = New System.Drawing.Size(77, 29)
        Me.BTN_CONSULTA1.TabIndex = 12
        Me.BTN_CONSULTA1.Text = "&Consulta"
        Me.BTN_CONSULTA1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 14)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Menu"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 14)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Modulo"
        '
        'cbo_mod
        '
        Me.cbo_mod.BackColor = System.Drawing.Color.White
        Me.cbo_mod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mod.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_mod.FormattingEnabled = True
        Me.cbo_mod.Items.AddRange(New Object() {"Producto", "Servicio", "Terminado"})
        Me.cbo_mod.Location = New System.Drawing.Point(96, 19)
        Me.cbo_mod.Name = "cbo_mod"
        Me.cbo_mod.Size = New System.Drawing.Size(214, 22)
        Me.cbo_mod.TabIndex = 10
        '
        'cbo_menu
        '
        Me.cbo_menu.BackColor = System.Drawing.Color.White
        Me.cbo_menu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_menu.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_menu.FormattingEnabled = True
        Me.cbo_menu.Items.AddRange(New Object() {"Producto", "Servicio", "Terminado"})
        Me.cbo_menu.Location = New System.Drawing.Point(96, 47)
        Me.cbo_menu.Name = "cbo_menu"
        Me.cbo_menu.Size = New System.Drawing.Size(214, 22)
        Me.cbo_menu.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DGW1)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 145)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(850, 258)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'DGW1
        '
        Me.DGW1.AllowUserToAddRows = False
        Me.DGW1.AllowUserToDeleteRows = False
        Me.DGW1.AllowUserToOrderColumns = True
        Me.DGW1.AllowUserToResizeRows = False
        Me.DGW1.BackgroundColor = System.Drawing.Color.White
        Me.DGW1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGW1.Location = New System.Drawing.Point(8, 16)
        Me.DGW1.Margin = New System.Windows.Forms.Padding(0)
        Me.DGW1.MultiSelect = False
        Me.DGW1.Name = "DGW1"
        Me.DGW1.ReadOnly = True
        Me.DGW1.RowHeadersWidth = 25
        Me.DGW1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DGW1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DGW1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGW1.Size = New System.Drawing.Size(833, 227)
        Me.DGW1.TabIndex = 33
        '
        'btn_salir
        '
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(767, 409)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(77, 29)
        Me.btn_salir.TabIndex = 16
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_imprimir
        '
        Me.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprimir.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btn_imprimir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir.Location = New System.Drawing.Point(684, 409)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(77, 29)
        Me.btn_imprimir.TabIndex = 15
        Me.btn_imprimir.Text = "&Imprimir"
        Me.btn_imprimir.UseVisualStyleBackColor = True
        '
        'CONSULTA_FORMULARIO_SEGURIDAD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.btn_imprimir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CONSULTA_FORMULARIO_SEGURIDAD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Formulario Seguridad"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DGW1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_mod As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_menu As System.Windows.Forms.ComboBox
    Friend WithEvents BTN_CONSULTA1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DGW1 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Private WithEvents chk_menu As System.Windows.Forms.CheckBox
End Class
