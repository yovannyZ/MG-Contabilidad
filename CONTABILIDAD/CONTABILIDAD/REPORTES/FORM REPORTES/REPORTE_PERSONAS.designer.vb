<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_PERSONAS
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
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BTN_SALIR = New System.Windows.Forms.Button
        Me.cbo_cat = New System.Windows.Forms.ComboBox
        Me.cbo_clase = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ch_pro = New System.Windows.Forms.CheckBox
        Me.ch_dist = New System.Windows.Forms.CheckBox
        Me.ch_dep = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.cbo_cat2 = New System.Windows.Forms.ComboBox
        Me.cbo_clase2 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbo_pais = New System.Windows.Forms.ComboBox
        Me.cbo_dep = New System.Windows.Forms.ComboBox
        Me.cbo_dist = New System.Windows.Forms.ComboBox
        Me.cbo_pro = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.stEstado = New System.Windows.Forms.StatusStrip
        Me.tspbExportar = New System.Windows.Forms.ToolStripProgressBar
        Me.tslblMensaje = New System.Windows.Forms.ToolStripStatusLabel
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gb1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.stEstado.SuspendLayout()
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
        Me.TabControl1.Size = New System.Drawing.Size(492, 223)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gb1)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(484, 196)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Corrido"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(108, 118)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(261, 54)
        Me.gb1.TabIndex = 1
        Me.gb1.TabStop = False
        '
        'btn_archivo1
        '
        Me.btn_archivo1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo1.Location = New System.Drawing.Point(172, 15)
        Me.btn_archivo1.Name = "btn_archivo1"
        Me.btn_archivo1.Size = New System.Drawing.Size(77, 27)
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
        Me.btn_imprimir1.Location = New System.Drawing.Point(91, 15)
        Me.btn_imprimir1.Name = "btn_imprimir1"
        Me.btn_imprimir1.Size = New System.Drawing.Size(77, 27)
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
        Me.btn_pantalla1.Location = New System.Drawing.Point(10, 15)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(77, 27)
        Me.btn_pantalla1.TabIndex = 0
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTN_SALIR)
        Me.GroupBox1.Controls.Add(Me.cbo_cat)
        Me.GroupBox1.Controls.Add(Me.cbo_clase)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(450, 99)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_SALIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_SALIR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.Location = New System.Drawing.Point(369, 67)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(75, 26)
        Me.BTN_SALIR.TabIndex = 3
        Me.BTN_SALIR.Text = "&Salir"
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'cbo_cat
        '
        Me.cbo_cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_cat.FormattingEnabled = True
        Me.cbo_cat.Location = New System.Drawing.Point(116, 51)
        Me.cbo_cat.Name = "cbo_cat"
        Me.cbo_cat.Size = New System.Drawing.Size(188, 22)
        Me.cbo_cat.TabIndex = 2
        '
        'cbo_clase
        '
        Me.cbo_clase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_clase.FormattingEnabled = True
        Me.cbo_clase.Location = New System.Drawing.Point(116, 19)
        Me.cbo_clase.Name = "cbo_clase"
        Me.cbo_clase.Size = New System.Drawing.Size(188, 22)
        Me.cbo_clase.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(41, 54)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(53, 14)
        Me.Label24.TabIndex = 6
        Me.Label24.Text = "Categoría"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(41, 22)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(34, 14)
        Me.Label22.TabIndex = 3
        Me.Label22.Text = "Clase"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(484, 196)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Con Quiebre"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Location = New System.Drawing.Point(110, 136)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(261, 52)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(172, 15)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(77, 27)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "&Archivo"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.Location = New System.Drawing.Point(91, 15)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(77, 27)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "&Imprimir"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.Location = New System.Drawing.Point(10, 15)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(77, 27)
        Me.Button4.TabIndex = 0
        Me.Button4.Text = "&Pantalla"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ch_pro)
        Me.GroupBox2.Controls.Add(Me.ch_dist)
        Me.GroupBox2.Controls.Add(Me.ch_dep)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.cbo_cat2)
        Me.GroupBox2.Controls.Add(Me.cbo_clase2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cbo_pais)
        Me.GroupBox2.Controls.Add(Me.cbo_dep)
        Me.GroupBox2.Controls.Add(Me.cbo_dist)
        Me.GroupBox2.Controls.Add(Me.cbo_pro)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(468, 123)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'ch_pro
        '
        Me.ch_pro.AutoSize = True
        Me.ch_pro.Location = New System.Drawing.Point(316, 15)
        Me.ch_pro.Name = "ch_pro"
        Me.ch_pro.Size = New System.Drawing.Size(15, 14)
        Me.ch_pro.TabIndex = 6
        Me.ch_pro.UseVisualStyleBackColor = True
        '
        'ch_dist
        '
        Me.ch_dist.AutoSize = True
        Me.ch_dist.Location = New System.Drawing.Point(316, 43)
        Me.ch_dist.Name = "ch_dist"
        Me.ch_dist.Size = New System.Drawing.Size(15, 14)
        Me.ch_dist.TabIndex = 8
        Me.ch_dist.UseVisualStyleBackColor = True
        '
        'ch_dep
        '
        Me.ch_dep.AutoSize = True
        Me.ch_dep.Location = New System.Drawing.Point(86, 98)
        Me.ch_dep.Name = "ch_dep"
        Me.ch_dep.Size = New System.Drawing.Size(15, 14)
        Me.ch_dep.TabIndex = 4
        Me.ch_dep.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(385, 85)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 27)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "&Salir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbo_cat2
        '
        Me.cbo_cat2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_cat2.FormattingEnabled = True
        Me.cbo_cat2.Location = New System.Drawing.Point(81, 40)
        Me.cbo_cat2.Name = "cbo_cat2"
        Me.cbo_cat2.Size = New System.Drawing.Size(159, 22)
        Me.cbo_cat2.TabIndex = 2
        '
        'cbo_clase2
        '
        Me.cbo_clase2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_clase2.FormattingEnabled = True
        Me.cbo_clase2.Location = New System.Drawing.Point(81, 13)
        Me.cbo_clase2.Name = "cbo_clase2"
        Me.cbo_clase2.Size = New System.Drawing.Size(159, 22)
        Me.cbo_clase2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 14)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Categoría"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 14)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Clase"
        '
        'cbo_pais
        '
        Me.cbo_pais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_pais.FormattingEnabled = True
        Me.cbo_pais.Location = New System.Drawing.Point(81, 66)
        Me.cbo_pais.Name = "cbo_pais"
        Me.cbo_pais.Size = New System.Drawing.Size(159, 22)
        Me.cbo_pais.TabIndex = 3
        '
        'cbo_dep
        '
        Me.cbo_dep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_dep.FormattingEnabled = True
        Me.cbo_dep.Location = New System.Drawing.Point(119, 90)
        Me.cbo_dep.Name = "cbo_dep"
        Me.cbo_dep.Size = New System.Drawing.Size(121, 22)
        Me.cbo_dep.TabIndex = 5
        '
        'cbo_dist
        '
        Me.cbo_dist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_dist.FormattingEnabled = True
        Me.cbo_dist.Location = New System.Drawing.Point(335, 41)
        Me.cbo_dist.Name = "cbo_dist"
        Me.cbo_dist.Size = New System.Drawing.Size(127, 22)
        Me.cbo_dist.TabIndex = 9
        '
        'cbo_pro
        '
        Me.cbo_pro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_pro.FormattingEnabled = True
        Me.cbo_pro.Location = New System.Drawing.Point(335, 13)
        Me.cbo_pro.Name = "cbo_pro"
        Me.cbo_pro.Size = New System.Drawing.Size(127, 22)
        Me.cbo_pro.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 72)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(27, 14)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "País"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 100)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(74, 14)
        Me.Label18.TabIndex = 11
        Me.Label18.Text = "Departamento"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(259, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 14)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Provincia"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(265, 44)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 14)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Distrito"
        '
        'stEstado
        '
        Me.stEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspbExportar, Me.tslblMensaje})
        Me.stEstado.Location = New System.Drawing.Point(0, 201)
        Me.stEstado.Name = "stEstado"
        Me.stEstado.Size = New System.Drawing.Size(492, 22)
        Me.stEstado.TabIndex = 158
        Me.stEstado.Text = "StatusStrip1"
        Me.stEstado.Visible = False
        '
        'tspbExportar
        '
        Me.tspbExportar.Name = "tspbExportar"
        Me.tspbExportar.Size = New System.Drawing.Size(100, 16)
        Me.tspbExportar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        '
        'tslblMensaje
        '
        Me.tslblMensaje.Name = "tslblMensaje"
        Me.tslblMensaje.Size = New System.Drawing.Size(99, 17)
        Me.tslblMensaje.Text = "Generando Archivo"
        '
        'REPORTE_PERSONAS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 223)
        Me.ControlBox = False
        Me.Controls.Add(Me.stEstado)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_PERSONAS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Personas"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.gb1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.stEstado.ResumeLayout(False)
        Me.stEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cbo_cat As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_clase As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents gb1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_archivo1 As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir1 As System.Windows.Forms.Button
    Friend WithEvents btn_pantalla1 As System.Windows.Forms.Button
    Friend WithEvents BTN_SALIR As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cbo_cat2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_clase2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbo_pais As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_dep As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_dist As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_pro As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ch_dist As System.Windows.Forms.CheckBox
    Friend WithEvents ch_dep As System.Windows.Forms.CheckBox
    Friend WithEvents ch_pro As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents stEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tspbExportar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tslblMensaje As System.Windows.Forms.ToolStripStatusLabel
End Class
