<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BCO_TRANSFERENCIA
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabControl2 = New System.Windows.Forms.TabControl
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.ch1 = New System.Windows.Forms.CheckBox
        Me.DGW_IE = New System.Windows.Forms.DataGridView
        Me.BTN_ACEPTAR1 = New System.Windows.Forms.Button
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.DGW_IE_TRANS = New System.Windows.Forms.DataGridView
        Me.BTN_DES_TRANS = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabControl3 = New System.Windows.Forms.TabControl
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.DGW_TRANS = New System.Windows.Forms.DataGridView
        Me.btn_aceptar2 = New System.Windows.Forms.Button
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.DGW_TRANS_TRANS = New System.Windows.Forms.DataGridView
        Me.BTN_DES_TRANS2 = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.DGW_IE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.DGW_IE_TRANS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.DGW_TRANS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.DGW_TRANS_TRANS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.TabControl1.Size = New System.Drawing.Size(790, 391)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TabControl2)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(782, 364)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Ingresos / Egresos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl2.Location = New System.Drawing.Point(3, 3)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(776, 358)
        Me.TabControl2.TabIndex = 4
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.ch1)
        Me.TabPage3.Controls.Add(Me.DGW_IE)
        Me.TabPage3.Controls.Add(Me.BTN_ACEPTAR1)
        Me.TabPage3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(768, 331)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Pendientes"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ch1
        '
        Me.ch1.AutoSize = True
        Me.ch1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ch1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch1.Location = New System.Drawing.Point(6, 302)
        Me.ch1.Name = "ch1"
        Me.ch1.Size = New System.Drawing.Size(115, 18)
        Me.ch1.TabIndex = 23
        Me.ch1.Text = "Seleccionar Todos"
        Me.ch1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ch1.UseVisualStyleBackColor = True
        '
        'DGW_IE
        '
        Me.DGW_IE.AllowUserToAddRows = False
        Me.DGW_IE.AllowUserToDeleteRows = False
        Me.DGW_IE.AllowUserToOrderColumns = True
        Me.DGW_IE.AllowUserToResizeRows = False
        Me.DGW_IE.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGW_IE.BackgroundColor = System.Drawing.Color.White
        Me.DGW_IE.Dock = System.Windows.Forms.DockStyle.Top
        Me.DGW_IE.Location = New System.Drawing.Point(3, 3)
        Me.DGW_IE.MultiSelect = False
        Me.DGW_IE.Name = "DGW_IE"
        Me.DGW_IE.RowHeadersWidth = 25
        Me.DGW_IE.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DGW_IE.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DGW_IE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGW_IE.Size = New System.Drawing.Size(762, 287)
        Me.DGW_IE.TabIndex = 3
        '
        'BTN_ACEPTAR1
        '
        Me.BTN_ACEPTAR1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_ACEPTAR1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ACEPTAR1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Card_file_1
        Me.BTN_ACEPTAR1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ACEPTAR1.Location = New System.Drawing.Point(658, 296)
        Me.BTN_ACEPTAR1.Name = "BTN_ACEPTAR1"
        Me.BTN_ACEPTAR1.Size = New System.Drawing.Size(104, 29)
        Me.BTN_ACEPTAR1.TabIndex = 1
        Me.BTN_ACEPTAR1.Text = "&Transferir"
        Me.BTN_ACEPTAR1.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.CheckBox1)
        Me.TabPage4.Controls.Add(Me.DGW_IE_TRANS)
        Me.TabPage4.Controls.Add(Me.BTN_DES_TRANS)
        Me.TabPage4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(768, 331)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Transferidos"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(6, 302)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(115, 18)
        Me.CheckBox1.TabIndex = 23
        Me.CheckBox1.Text = "Seleccionar Todos"
        Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'DGW_IE_TRANS
        '
        Me.DGW_IE_TRANS.AllowUserToAddRows = False
        Me.DGW_IE_TRANS.AllowUserToDeleteRows = False
        Me.DGW_IE_TRANS.AllowUserToOrderColumns = True
        Me.DGW_IE_TRANS.AllowUserToResizeRows = False
        Me.DGW_IE_TRANS.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGW_IE_TRANS.BackgroundColor = System.Drawing.Color.White
        Me.DGW_IE_TRANS.Dock = System.Windows.Forms.DockStyle.Top
        Me.DGW_IE_TRANS.Location = New System.Drawing.Point(3, 3)
        Me.DGW_IE_TRANS.MultiSelect = False
        Me.DGW_IE_TRANS.Name = "DGW_IE_TRANS"
        Me.DGW_IE_TRANS.RowHeadersWidth = 25
        Me.DGW_IE_TRANS.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DGW_IE_TRANS.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DGW_IE_TRANS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGW_IE_TRANS.Size = New System.Drawing.Size(762, 287)
        Me.DGW_IE_TRANS.TabIndex = 6
        '
        'BTN_DES_TRANS
        '
        Me.BTN_DES_TRANS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_DES_TRANS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_DES_TRANS.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Stop_2_1
        Me.BTN_DES_TRANS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_DES_TRANS.Location = New System.Drawing.Point(614, 296)
        Me.BTN_DES_TRANS.Name = "BTN_DES_TRANS"
        Me.BTN_DES_TRANS.Size = New System.Drawing.Size(148, 29)
        Me.BTN_DES_TRANS.TabIndex = 4
        Me.BTN_DES_TRANS.Text = "&Des - Transferir"
        Me.BTN_DES_TRANS.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TabControl3)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(782, 364)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Transferencias"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabControl3
        '
        Me.TabControl3.Controls.Add(Me.TabPage5)
        Me.TabControl3.Controls.Add(Me.TabPage6)
        Me.TabControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl3.Location = New System.Drawing.Point(3, 3)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(776, 358)
        Me.TabControl3.TabIndex = 6
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.CheckBox2)
        Me.TabPage5.Controls.Add(Me.DGW_TRANS)
        Me.TabPage5.Controls.Add(Me.btn_aceptar2)
        Me.TabPage5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage5.Location = New System.Drawing.Point(4, 23)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(768, 331)
        Me.TabPage5.TabIndex = 0
        Me.TabPage5.Text = "Pendientes"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(6, 302)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(115, 18)
        Me.CheckBox2.TabIndex = 23
        Me.CheckBox2.Text = "Seleccionar Todos"
        Me.CheckBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'DGW_TRANS
        '
        Me.DGW_TRANS.AllowUserToAddRows = False
        Me.DGW_TRANS.AllowUserToDeleteRows = False
        Me.DGW_TRANS.AllowUserToOrderColumns = True
        Me.DGW_TRANS.AllowUserToResizeRows = False
        Me.DGW_TRANS.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGW_TRANS.BackgroundColor = System.Drawing.Color.White
        Me.DGW_TRANS.Dock = System.Windows.Forms.DockStyle.Top
        Me.DGW_TRANS.Location = New System.Drawing.Point(3, 3)
        Me.DGW_TRANS.MultiSelect = False
        Me.DGW_TRANS.Name = "DGW_TRANS"
        Me.DGW_TRANS.RowHeadersWidth = 25
        Me.DGW_TRANS.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DGW_TRANS.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DGW_TRANS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGW_TRANS.Size = New System.Drawing.Size(762, 287)
        Me.DGW_TRANS.TabIndex = 5
        '
        'btn_aceptar2
        '
        Me.btn_aceptar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aceptar2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Card_file_1
        Me.btn_aceptar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar2.Location = New System.Drawing.Point(653, 296)
        Me.btn_aceptar2.Name = "btn_aceptar2"
        Me.btn_aceptar2.Size = New System.Drawing.Size(99, 29)
        Me.btn_aceptar2.TabIndex = 3
        Me.btn_aceptar2.Text = "&Transferir"
        Me.btn_aceptar2.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.CheckBox3)
        Me.TabPage6.Controls.Add(Me.DGW_TRANS_TRANS)
        Me.TabPage6.Controls.Add(Me.BTN_DES_TRANS2)
        Me.TabPage6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage6.Location = New System.Drawing.Point(4, 23)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(768, 331)
        Me.TabPage6.TabIndex = 1
        Me.TabPage6.Text = "Transferidos"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(6, 303)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(115, 18)
        Me.CheckBox3.TabIndex = 23
        Me.CheckBox3.Text = "Seleccionar Todos"
        Me.CheckBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'DGW_TRANS_TRANS
        '
        Me.DGW_TRANS_TRANS.AllowUserToAddRows = False
        Me.DGW_TRANS_TRANS.AllowUserToDeleteRows = False
        Me.DGW_TRANS_TRANS.AllowUserToOrderColumns = True
        Me.DGW_TRANS_TRANS.AllowUserToResizeRows = False
        Me.DGW_TRANS_TRANS.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGW_TRANS_TRANS.BackgroundColor = System.Drawing.Color.White
        Me.DGW_TRANS_TRANS.Dock = System.Windows.Forms.DockStyle.Top
        Me.DGW_TRANS_TRANS.Location = New System.Drawing.Point(3, 3)
        Me.DGW_TRANS_TRANS.MultiSelect = False
        Me.DGW_TRANS_TRANS.Name = "DGW_TRANS_TRANS"
        Me.DGW_TRANS_TRANS.RowHeadersWidth = 25
        Me.DGW_TRANS_TRANS.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DGW_TRANS_TRANS.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DGW_TRANS_TRANS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGW_TRANS_TRANS.Size = New System.Drawing.Size(762, 287)
        Me.DGW_TRANS_TRANS.TabIndex = 7
        '
        'BTN_DES_TRANS2
        '
        Me.BTN_DES_TRANS2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_DES_TRANS2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_DES_TRANS2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Stop_2_1
        Me.BTN_DES_TRANS2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_DES_TRANS2.Location = New System.Drawing.Point(581, 297)
        Me.BTN_DES_TRANS2.Name = "BTN_DES_TRANS2"
        Me.BTN_DES_TRANS2.Size = New System.Drawing.Size(171, 29)
        Me.BTN_DES_TRANS2.TabIndex = 6
        Me.BTN_DES_TRANS2.Text = "&Des - Transferir"
        Me.BTN_DES_TRANS2.UseVisualStyleBackColor = True
        '
        'BCO_TRANSFERENCIA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 391)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BCO_TRANSFERENCIA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transferencia de Módulo Bancos"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.DGW_IE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.DGW_IE_TRANS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabControl3.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.DGW_TRANS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        CType(Me.DGW_TRANS_TRANS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BTN_ACEPTAR1 As Button
    Friend WithEvents btn_aceptar2 As Button
    Friend WithEvents BTN_DES_TRANS As Button
    Friend WithEvents BTN_DES_TRANS2 As Button
    Friend WithEvents ch1 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents DGW_IE As DataGridView
    Friend WithEvents DGW_IE_TRANS As DataGridView
    Friend WithEvents DGW_TRANS As DataGridView
    Friend WithEvents DGW_TRANS_TRANS As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabControl3 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents TabPage6 As TabPage

End Class
