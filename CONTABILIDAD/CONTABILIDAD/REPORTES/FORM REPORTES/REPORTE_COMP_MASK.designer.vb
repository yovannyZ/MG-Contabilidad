Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_COMP_MASK
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
        Me.txt_mask = New System.Windows.Forms.TextBox
        Me.ch_ac = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_salir = New System.Windows.Forms.Button
        Me.dtp1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBO_MES2 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CBO_MES1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.gp2 = New System.Windows.Forms.GroupBox
        Me.txt_mask2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn_salir2 = New System.Windows.Forms.Button
        Me.dtp2 = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.CBO_MES22 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btn_archivo2 = New System.Windows.Forms.Button
        Me.btn_imprimir2 = New System.Windows.Forms.Button
        Me.btn_pantalla2 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.gb1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.gp2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_mask)
        Me.GroupBox1.Controls.Add(Me.ch_ac)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.dtp1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CBO_MES2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CBO_MES1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(427, 176)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txt_mask
        '
        Me.txt_mask.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_mask.Location = New System.Drawing.Point(102, 35)
        Me.txt_mask.MaxLength = 8
        Me.txt_mask.Name = "txt_mask"
        Me.txt_mask.Size = New System.Drawing.Size(68, 20)
        Me.txt_mask.TabIndex = 0
        '
        'ch_ac
        '
        Me.ch_ac.AutoSize = True
        Me.ch_ac.Location = New System.Drawing.Point(218, 36)
        Me.ch_ac.Name = "ch_ac"
        Me.ch_ac.Size = New System.Drawing.Size(80, 18)
        Me.ch_ac.TabIndex = 33
        Me.ch_ac.TabStop = False
        Me.ch_ac.Text = "Acumulado"
        Me.ch_ac.UseVisualStyleBackColor = True
        Me.ch_ac.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 14)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Máscara"
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.SystemColors.Control
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(309, 129)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(82, 31)
        Me.btn_salir.TabIndex = 30
        Me.btn_salir.TabStop = False
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'dtp1
        '
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(102, 90)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(80, 20)
        Me.dtp1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 14)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Emisión"
        '
        'CBO_MES2
        '
        Me.CBO_MES2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_MES2.FormattingEnabled = True
        Me.CBO_MES2.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13"})
        Me.CBO_MES2.Location = New System.Drawing.Point(258, 58)
        Me.CBO_MES2.Name = "CBO_MES2"
        Me.CBO_MES2.Size = New System.Drawing.Size(40, 22)
        Me.CBO_MES2.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(212, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 14)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Al Mes"
        '
        'CBO_MES1
        '
        Me.CBO_MES1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_MES1.FormattingEnabled = True
        Me.CBO_MES1.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13"})
        Me.CBO_MES1.Location = New System.Drawing.Point(102, 61)
        Me.CBO_MES1.Name = "CBO_MES1"
        Me.CBO_MES1.Size = New System.Drawing.Size(43, 22)
        Me.CBO_MES1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 14)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Del Mes"
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(85, 245)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(289, 67)
        Me.gb1.TabIndex = 1
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
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(295, 21)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(92, 3)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(484, 362)
        Me.TabControl1.TabIndex = 61
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.gb1)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(476, 333)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Comprobación"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gp2)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(476, 333)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Saldo"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'gp2
        '
        Me.gp2.Controls.Add(Me.txt_mask2)
        Me.gp2.Controls.Add(Me.Label5)
        Me.gp2.Controls.Add(Me.btn_salir2)
        Me.gp2.Controls.Add(Me.dtp2)
        Me.gp2.Controls.Add(Me.Label6)
        Me.gp2.Controls.Add(Me.CBO_MES22)
        Me.gp2.Controls.Add(Me.Label7)
        Me.gp2.Location = New System.Drawing.Point(25, 31)
        Me.gp2.Name = "gp2"
        Me.gp2.Size = New System.Drawing.Size(427, 176)
        Me.gp2.TabIndex = 2
        Me.gp2.TabStop = False
        '
        'txt_mask2
        '
        Me.txt_mask2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_mask2.Location = New System.Drawing.Point(102, 35)
        Me.txt_mask2.MaxLength = 8
        Me.txt_mask2.Name = "txt_mask2"
        Me.txt_mask2.Size = New System.Drawing.Size(68, 20)
        Me.txt_mask2.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 14)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Máscara"
        '
        'btn_salir2
        '
        Me.btn_salir2.BackColor = System.Drawing.SystemColors.Control
        Me.btn_salir2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir2.Location = New System.Drawing.Point(309, 129)
        Me.btn_salir2.Name = "btn_salir2"
        Me.btn_salir2.Size = New System.Drawing.Size(82, 31)
        Me.btn_salir2.TabIndex = 30
        Me.btn_salir2.TabStop = False
        Me.btn_salir2.Text = "&Salir"
        Me.btn_salir2.UseVisualStyleBackColor = False
        '
        'dtp2
        '
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(102, 90)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(80, 20)
        Me.dtp2.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(40, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 14)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Emisión"
        '
        'CBO_MES22
        '
        Me.CBO_MES22.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_MES22.FormattingEnabled = True
        Me.CBO_MES22.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13"})
        Me.CBO_MES22.Location = New System.Drawing.Point(102, 61)
        Me.CBO_MES22.Name = "CBO_MES22"
        Me.CBO_MES22.Size = New System.Drawing.Size(40, 22)
        Me.CBO_MES22.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(40, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Al Mes"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.btn_archivo2)
        Me.GroupBox3.Controls.Add(Me.btn_imprimir2)
        Me.GroupBox3.Controls.Add(Me.btn_pantalla2)
        Me.GroupBox3.Location = New System.Drawing.Point(88, 234)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(289, 67)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'btn_archivo2
        '
        Me.btn_archivo2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo2.Location = New System.Drawing.Point(186, 16)
        Me.btn_archivo2.Name = "btn_archivo2"
        Me.btn_archivo2.Size = New System.Drawing.Size(82, 31)
        Me.btn_archivo2.TabIndex = 2
        Me.btn_archivo2.Text = "&Archivo"
        Me.btn_archivo2.UseVisualStyleBackColor = False
        '
        'btn_imprimir2
        '
        Me.btn_imprimir2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_imprimir2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprimir2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.btn_imprimir2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir2.Location = New System.Drawing.Point(98, 16)
        Me.btn_imprimir2.Name = "btn_imprimir2"
        Me.btn_imprimir2.Size = New System.Drawing.Size(82, 31)
        Me.btn_imprimir2.TabIndex = 1
        Me.btn_imprimir2.Text = "&Imprimir"
        Me.btn_imprimir2.UseVisualStyleBackColor = False
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
        'REPORTE_COMP_MASK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 362)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_COMP_MASK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Comprobación (Máscara)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gb1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.gp2.ResumeLayout(False)
        Me.gp2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_archivo1 As Button
    Friend WithEvents btn_imprimir1 As Button
    Friend WithEvents btn_pantalla1 As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents CBO_MES1 As ComboBox
    Friend WithEvents CBO_MES2 As ComboBox
    Friend WithEvents ch_ac As CheckBox
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_mask As TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents gp2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_mask2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_salir2 As System.Windows.Forms.Button
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CBO_MES22 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_archivo2 As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir2 As System.Windows.Forms.Button
    Friend WithEvents btn_pantalla2 As System.Windows.Forms.Button


End Class
