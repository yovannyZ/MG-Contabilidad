Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CXP_INI_TRANSFERENCIA
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btn_sgt1 = New System.Windows.Forms.Button
        Me.btn_buscar1 = New System.Windows.Forms.Button
        Me.ch_cadena1 = New System.Windows.Forms.RadioButton
        Me.ch_per1 = New System.Windows.Forms.RadioButton
        Me.ch_doc1 = New System.Windows.Forms.RadioButton
        Me.txt_letra1 = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXT_CUENTA = New System.Windows.Forms.TextBox
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.ch1 = New System.Windows.Forms.CheckBox
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dgw2 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_sgt2 = New System.Windows.Forms.Button
        Me.btn_buscar2 = New System.Windows.Forms.Button
        Me.ch_cadena2 = New System.Windows.Forms.RadioButton
        Me.ch_per2 = New System.Windows.Forms.RadioButton
        Me.ch_doc2 = New System.Windows.Forms.RadioButton
        Me.txt_letra2 = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_aceptar2 = New System.Windows.Forms.Button
        Me.ch2 = New System.Windows.Forms.CheckBox
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgw2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_sgt1)
        Me.GroupBox3.Controls.Add(Me.btn_buscar1)
        Me.GroupBox3.Controls.Add(Me.ch_cadena1)
        Me.GroupBox3.Controls.Add(Me.ch_per1)
        Me.GroupBox3.Controls.Add(Me.ch_doc1)
        Me.GroupBox3.Controls.Add(Me.txt_letra1)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(307, 73)
        Me.GroupBox3.TabIndex = 26
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Buscado por:"
        '
        'btn_sgt1
        '
        Me.btn_sgt1.Enabled = False
        Me.btn_sgt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_sgt1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sgt1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Next_set_2_1
        Me.btn_sgt1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_sgt1.Location = New System.Drawing.Point(241, 13)
        Me.btn_sgt1.Name = "btn_sgt1"
        Me.btn_sgt1.Size = New System.Drawing.Size(51, 26)
        Me.btn_sgt1.TabIndex = 2
        Me.btn_sgt1.Text = "&Sgte."
        Me.btn_sgt1.UseVisualStyleBackColor = True
        '
        'btn_buscar1
        '
        Me.btn_buscar1.Enabled = False
        Me.btn_buscar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_buscar1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btn_buscar1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Binoculars_2_1
        Me.btn_buscar1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar1.Location = New System.Drawing.Point(172, 13)
        Me.btn_buscar1.Name = "btn_buscar1"
        Me.btn_buscar1.Size = New System.Drawing.Size(63, 26)
        Me.btn_buscar1.TabIndex = 1
        Me.btn_buscar1.Text = "&Buscar"
        Me.btn_buscar1.UseVisualStyleBackColor = True
        '
        'ch_cadena1
        '
        Me.ch_cadena1.AutoSize = True
        Me.ch_cadena1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_cadena1.Location = New System.Drawing.Point(183, 42)
        Me.ch_cadena1.Name = "ch_cadena1"
        Me.ch_cadena1.Size = New System.Drawing.Size(62, 18)
        Me.ch_cadena1.TabIndex = 5
        Me.ch_cadena1.Text = "Cadena"
        Me.ch_cadena1.UseVisualStyleBackColor = True
        '
        'ch_per1
        '
        Me.ch_per1.AutoSize = True
        Me.ch_per1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_per1.Location = New System.Drawing.Point(106, 42)
        Me.ch_per1.Name = "ch_per1"
        Me.ch_per1.Size = New System.Drawing.Size(75, 18)
        Me.ch_per1.TabIndex = 4
        Me.ch_per1.Text = "Proveedor"
        Me.ch_per1.UseVisualStyleBackColor = True
        '
        'ch_doc1
        '
        Me.ch_doc1.AutoSize = True
        Me.ch_doc1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_doc1.Location = New System.Drawing.Point(6, 42)
        Me.ch_doc1.Name = "ch_doc1"
        Me.ch_doc1.Size = New System.Drawing.Size(94, 18)
        Me.ch_doc1.TabIndex = 3
        Me.ch_doc1.Text = "Nº Documento"
        Me.ch_doc1.UseVisualStyleBackColor = True
        '
        'txt_letra1
        '
        Me.txt_letra1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_letra1.Location = New System.Drawing.Point(6, 16)
        Me.txt_letra1.Name = "txt_letra1"
        Me.txt_letra1.Size = New System.Drawing.Size(160, 20)
        Me.txt_letra1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TXT_CUENTA)
        Me.GroupBox2.Controls.Add(Me.btn_aceptar)
        Me.GroupBox2.Controls.Add(Me.ch1)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(316, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(508, 73)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Generar a Contabilidad"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 14)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Cuenta Default"
        '
        'TXT_CUENTA
        '
        Me.TXT_CUENTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_CUENTA.Location = New System.Drawing.Point(125, 27)
        Me.TXT_CUENTA.MaxLength = 8
        Me.TXT_CUENTA.Name = "TXT_CUENTA"
        Me.TXT_CUENTA.Size = New System.Drawing.Size(76, 20)
        Me.TXT_CUENTA.TabIndex = 23
        '
        'btn_aceptar
        '
        Me.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aceptar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Location = New System.Drawing.Point(322, 13)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(159, 25)
        Me.btn_aceptar.TabIndex = 1
        Me.btn_aceptar.Text = "&Generar a Contabilidad"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'ch1
        '
        Me.ch1.AutoSize = True
        Me.ch1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ch1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch1.Location = New System.Drawing.Point(365, 43)
        Me.ch1.Name = "ch1"
        Me.ch1.Size = New System.Drawing.Size(116, 18)
        Me.ch1.TabIndex = 22
        Me.ch1.Text = "Seleccionar Todos"
        Me.ch1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ch1.UseVisualStyleBackColor = True
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AllowUserToOrderColumns = True
        Me.dgw1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgw1.Location = New System.Drawing.Point(3, 81)
        Me.dgw1.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.ReadOnly = True
        Me.dgw1.RowHeadersWidth = 25
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw1.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(825, 379)
        Me.dgw1.TabIndex = 27
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
        Me.TabControl1.Size = New System.Drawing.Size(839, 490)
        Me.TabControl1.TabIndex = 61
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.dgw1)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(831, 463)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Transferir"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgw2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(831, 463)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cancelar Transferencia"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgw2
        '
        Me.dgw2.AllowUserToAddRows = False
        Me.dgw2.AllowUserToDeleteRows = False
        Me.dgw2.AllowUserToOrderColumns = True
        Me.dgw2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgw2.BackgroundColor = System.Drawing.Color.White
        Me.dgw2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgw2.Location = New System.Drawing.Point(3, 79)
        Me.dgw2.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw2.MultiSelect = False
        Me.dgw2.Name = "dgw2"
        Me.dgw2.RowHeadersWidth = 25
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw2.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgw2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw2.Size = New System.Drawing.Size(825, 381)
        Me.dgw2.TabIndex = 30
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_sgt2)
        Me.GroupBox1.Controls.Add(Me.btn_buscar2)
        Me.GroupBox1.Controls.Add(Me.ch_cadena2)
        Me.GroupBox1.Controls.Add(Me.ch_per2)
        Me.GroupBox1.Controls.Add(Me.ch_doc2)
        Me.GroupBox1.Controls.Add(Me.txt_letra2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(313, 73)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscado por:"
        '
        'btn_sgt2
        '
        Me.btn_sgt2.Enabled = False
        Me.btn_sgt2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_sgt2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sgt2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Next_set_2_1
        Me.btn_sgt2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_sgt2.Location = New System.Drawing.Point(248, 13)
        Me.btn_sgt2.Name = "btn_sgt2"
        Me.btn_sgt2.Size = New System.Drawing.Size(59, 26)
        Me.btn_sgt2.TabIndex = 2
        Me.btn_sgt2.Text = "&Sgte."
        Me.btn_sgt2.UseVisualStyleBackColor = True
        '
        'btn_buscar2
        '
        Me.btn_buscar2.Enabled = False
        Me.btn_buscar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_buscar2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btn_buscar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Binoculars_2_1
        Me.btn_buscar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar2.Location = New System.Drawing.Point(173, 13)
        Me.btn_buscar2.Name = "btn_buscar2"
        Me.btn_buscar2.Size = New System.Drawing.Size(73, 26)
        Me.btn_buscar2.TabIndex = 1
        Me.btn_buscar2.Text = "&Buscar"
        Me.btn_buscar2.UseVisualStyleBackColor = True
        '
        'ch_cadena2
        '
        Me.ch_cadena2.AutoSize = True
        Me.ch_cadena2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_cadena2.Location = New System.Drawing.Point(187, 42)
        Me.ch_cadena2.Name = "ch_cadena2"
        Me.ch_cadena2.Size = New System.Drawing.Size(62, 18)
        Me.ch_cadena2.TabIndex = 5
        Me.ch_cadena2.Text = "Cadena"
        Me.ch_cadena2.UseVisualStyleBackColor = True
        '
        'ch_per2
        '
        Me.ch_per2.AutoSize = True
        Me.ch_per2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_per2.Location = New System.Drawing.Point(106, 42)
        Me.ch_per2.Name = "ch_per2"
        Me.ch_per2.Size = New System.Drawing.Size(75, 18)
        Me.ch_per2.TabIndex = 4
        Me.ch_per2.Text = "Proveedor"
        Me.ch_per2.UseVisualStyleBackColor = True
        '
        'ch_doc2
        '
        Me.ch_doc2.AutoSize = True
        Me.ch_doc2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_doc2.Location = New System.Drawing.Point(6, 42)
        Me.ch_doc2.Name = "ch_doc2"
        Me.ch_doc2.Size = New System.Drawing.Size(94, 18)
        Me.ch_doc2.TabIndex = 3
        Me.ch_doc2.Text = "Nº Documento"
        Me.ch_doc2.UseVisualStyleBackColor = True
        '
        'txt_letra2
        '
        Me.txt_letra2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_letra2.Location = New System.Drawing.Point(6, 16)
        Me.txt_letra2.Name = "txt_letra2"
        Me.txt_letra2.Size = New System.Drawing.Size(161, 20)
        Me.txt_letra2.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btn_aceptar2)
        Me.GroupBox4.Controls.Add(Me.ch2)
        Me.GroupBox4.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(322, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(506, 73)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cancelar deTransferencia"
        '
        'btn_aceptar2
        '
        Me.btn_aceptar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aceptar2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar2.Location = New System.Drawing.Point(95, 23)
        Me.btn_aceptar2.Name = "btn_aceptar2"
        Me.btn_aceptar2.Size = New System.Drawing.Size(159, 25)
        Me.btn_aceptar2.TabIndex = 1
        Me.btn_aceptar2.Text = "&Regresar de Contabilidad"
        Me.btn_aceptar2.UseVisualStyleBackColor = True
        '
        'ch2
        '
        Me.ch2.AutoSize = True
        Me.ch2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ch2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch2.Location = New System.Drawing.Point(318, 27)
        Me.ch2.Name = "ch2"
        Me.ch2.Size = New System.Drawing.Size(116, 18)
        Me.ch2.TabIndex = 22
        Me.ch2.Text = "Seleccionar Todos"
        Me.ch2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ch2.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(119, 25)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(84, 20)
        Me.DateTimePicker2.TabIndex = 24
        '
        'CXP_INI_TRANSFERENCIA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 490)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CXP_INI_TRANSFERENCIA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transferencia de Gestión Comercial - Cuentas por Pagar Inicial"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgw2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_aceptar As Button
    Friend WithEvents btn_aceptar2 As Button
    Friend WithEvents btn_buscar1 As Button
    Friend WithEvents btn_buscar2 As Button
    Friend WithEvents btn_sgt1 As Button
    Friend WithEvents btn_sgt2 As Button
    Friend WithEvents ch_cadena1 As RadioButton
    Friend WithEvents ch_cadena2 As RadioButton
    Friend WithEvents ch_doc1 As RadioButton
    Friend WithEvents ch_doc2 As RadioButton
    Friend WithEvents ch_per1 As RadioButton
    Friend WithEvents ch_per2 As RadioButton
    Friend WithEvents ch1 As CheckBox
    Friend WithEvents ch2 As CheckBox
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents dgw1 As DataGridView
    Friend WithEvents dgw2 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TXT_CUENTA As TextBox
    Friend WithEvents txt_letra1 As TextBox
    Friend WithEvents txt_letra2 As TextBox

End Class
