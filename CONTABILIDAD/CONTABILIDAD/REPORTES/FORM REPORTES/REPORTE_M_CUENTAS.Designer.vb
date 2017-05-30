<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_M_CUENTAS
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
        Me.btn_salir = New System.Windows.Forms.Button
        Me.txt_desc2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_cod2 = New System.Windows.Forms.TextBox
        Me.txt_desc1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_cod1 = New System.Windows.Forms.TextBox
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btn_salir2 = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.btn_pantalla2 = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.btn_salir3 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.btn_pantalla3 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.gb1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.txt_desc2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_cod2)
        Me.GroupBox1.Controls.Add(Me.txt_desc1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_cod1)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(487, 147)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.SystemColors.Control
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(363, 101)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(82, 31)
        Me.btn_salir.TabIndex = 4
        Me.btn_salir.TabStop = False
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'txt_desc2
        '
        Me.txt_desc2.Location = New System.Drawing.Point(136, 69)
        Me.txt_desc2.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc2.MaxLength = 40
        Me.txt_desc2.Name = "txt_desc2"
        Me.txt_desc2.Size = New System.Drawing.Size(309, 20)
        Me.txt_desc2.TabIndex = 3
        Me.txt_desc2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 14)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Cuenta"
        '
        'txt_cod2
        '
        Me.txt_cod2.Location = New System.Drawing.Point(87, 69)
        Me.txt_cod2.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod2.MaxLength = 2
        Me.txt_cod2.Name = "txt_cod2"
        Me.txt_cod2.Size = New System.Drawing.Size(40, 20)
        Me.txt_cod2.TabIndex = 2
        '
        'txt_desc1
        '
        Me.txt_desc1.Location = New System.Drawing.Point(136, 41)
        Me.txt_desc1.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc1.MaxLength = 40
        Me.txt_desc1.Name = "txt_desc1"
        Me.txt_desc1.Size = New System.Drawing.Size(309, 20)
        Me.txt_desc1.TabIndex = 1
        Me.txt_desc1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 14)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Cuenta"
        '
        'txt_cod1
        '
        Me.txt_cod1.Location = New System.Drawing.Point(87, 41)
        Me.txt_cod1.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod1.MaxLength = 2
        Me.txt_cod1.Name = "txt_cod1"
        Me.txt_cod1.Size = New System.Drawing.Size(40, 20)
        Me.txt_cod1.TabIndex = 0
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(115, 186)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(289, 67)
        Me.gb1.TabIndex = 3
        Me.gb1.TabStop = False
        '
        'btn_archivo1
        '
        Me.btn_archivo1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo1.Location = New System.Drawing.Point(186, 16)
        Me.btn_archivo1.Name = "btn_archivo1"
        Me.btn_archivo1.Size = New System.Drawing.Size(82, 31)
        Me.btn_archivo1.TabIndex = 2
        Me.btn_archivo1.Text = "&Archivo"
        Me.btn_archivo1.UseVisualStyleBackColor = False
        '
        'btn_imprimir1
        '
        Me.btn_imprimir1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_imprimir1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprimir1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.btn_imprimir1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir1.Location = New System.Drawing.Point(98, 16)
        Me.btn_imprimir1.Name = "btn_imprimir1"
        Me.btn_imprimir1.Size = New System.Drawing.Size(82, 31)
        Me.btn_imprimir1.TabIndex = 1
        Me.btn_imprimir1.Text = "&Imprimir"
        Me.btn_imprimir1.UseVisualStyleBackColor = False
        '
        'btn_pantalla1
        '
        Me.btn_pantalla1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pantalla1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla1.Location = New System.Drawing.Point(10, 16)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(82, 31)
        Me.btn_pantalla1.TabIndex = 0
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(560, 310)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gb1)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(552, 283)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Plan de Cuentas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btn_salir2)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(552, 283)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Automáticas"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btn_salir2
        '
        Me.btn_salir2.BackColor = System.Drawing.SystemColors.Control
        Me.btn_salir2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir2.Location = New System.Drawing.Point(432, 129)
        Me.btn_salir2.Name = "btn_salir2"
        Me.btn_salir2.Size = New System.Drawing.Size(82, 31)
        Me.btn_salir2.TabIndex = 5
        Me.btn_salir2.TabStop = False
        Me.btn_salir2.Text = "&Salir"
        Me.btn_salir2.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.btn_pantalla2)
        Me.GroupBox2.Location = New System.Drawing.Point(118, 113)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(289, 67)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(186, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 31)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "&Archivo"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(98, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(82, 31)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "&Imprimir"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btn_pantalla2
        '
        Me.btn_pantalla2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pantalla2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla2.Location = New System.Drawing.Point(10, 16)
        Me.btn_pantalla2.Name = "btn_pantalla2"
        Me.btn_pantalla2.Size = New System.Drawing.Size(82, 31)
        Me.btn_pantalla2.TabIndex = 0
        Me.btn_pantalla2.Text = "&Pantalla"
        Me.btn_pantalla2.UseVisualStyleBackColor = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btn_salir3)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(552, 283)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cuadre Automaticas"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btn_salir3
        '
        Me.btn_salir3.BackColor = System.Drawing.SystemColors.Control
        Me.btn_salir3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir3.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir3.Location = New System.Drawing.Point(432, 129)
        Me.btn_salir3.Name = "btn_salir3"
        Me.btn_salir3.Size = New System.Drawing.Size(82, 31)
        Me.btn_salir3.TabIndex = 7
        Me.btn_salir3.TabStop = False
        Me.btn_salir3.Text = "&Salir"
        Me.btn_salir3.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Controls.Add(Me.btn_pantalla3)
        Me.GroupBox3.Location = New System.Drawing.Point(118, 113)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(289, 67)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.Location = New System.Drawing.Point(186, 16)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(82, 31)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "&Archivo"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.Location = New System.Drawing.Point(98, 16)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(82, 31)
        Me.Button5.TabIndex = 1
        Me.Button5.Text = "&Imprimir"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'btn_pantalla3
        '
        Me.btn_pantalla3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pantalla3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla3.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla3.Location = New System.Drawing.Point(10, 16)
        Me.btn_pantalla3.Name = "btn_pantalla3"
        Me.btn_pantalla3.Size = New System.Drawing.Size(82, 31)
        Me.btn_pantalla3.TabIndex = 0
        Me.btn_pantalla3.Text = "&Pantalla"
        Me.btn_pantalla3.UseVisualStyleBackColor = False
        '
        'REPORTE_M_CUENTAS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 310)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_M_CUENTAS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Mastro de Cuentas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gb1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_archivo1 As Button
    Friend WithEvents btn_imprimir1 As Button
    Friend WithEvents btn_pantalla1 As Button
    Friend WithEvents btn_pantalla2 As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents btn_salir2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txt_cod1 As TextBox
    Friend WithEvents txt_cod2 As TextBox
    Friend WithEvents txt_desc1 As TextBox
    Friend WithEvents txt_desc2 As TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btn_salir3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents btn_pantalla3 As System.Windows.Forms.Button

End Class
