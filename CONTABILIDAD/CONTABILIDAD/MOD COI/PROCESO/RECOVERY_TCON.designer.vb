Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RECOVERY_TCON
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.btn_aceptar1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btn_salir2 = New System.Windows.Forms.Button
        Me.btn_aceptar2 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbo_año2 = New System.Windows.Forms.ComboBox
        Me.cbo_mes2 = New System.Windows.Forms.ComboBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.TabControl1.Size = New System.Drawing.Size(564, 396)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(556, 369)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Saldos de Cuenta"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.btn_aceptar1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbo_año)
        Me.GroupBox1.Controls.Add(Me.cbo_mes)
        Me.GroupBox1.Location = New System.Drawing.Point(85, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(387, 265)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(33, 194)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(305, 45)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "En este procesos se recalculan los saldos de todas las cuenta por el Año y mes el" & _
            "egidos."
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(263, 128)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 25)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "&Salir"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btn_aceptar1
        '
        Me.btn_aceptar1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_aceptar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aceptar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_aceptar1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar1.Location = New System.Drawing.Point(182, 128)
        Me.btn_aceptar1.Name = "btn_aceptar1"
        Me.btn_aceptar1.Size = New System.Drawing.Size(75, 25)
        Me.btn_aceptar1.TabIndex = 8
        Me.btn_aceptar1.Text = "&Ingresar"
        Me.btn_aceptar1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Año"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Mes"
        '
        'cbo_año
        '
        Me.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año.FormattingEnabled = True
        Me.cbo_año.Location = New System.Drawing.Point(122, 43)
        Me.cbo_año.Name = "cbo_año"
        Me.cbo_año.Size = New System.Drawing.Size(66, 22)
        Me.cbo_año.TabIndex = 4
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"INICIO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(122, 69)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(135, 22)
        Me.cbo_mes.TabIndex = 6
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(556, 369)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Automáticas"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.btn_salir2)
        Me.GroupBox2.Controls.Add(Me.btn_aceptar2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cbo_año2)
        Me.GroupBox2.Controls.Add(Me.cbo_mes2)
        Me.GroupBox2.Location = New System.Drawing.Point(87, 53)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(376, 272)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(33, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(305, 68)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "En este procesos se recalculan los saldos de todas las cuenta por el Año y mes el" & _
            "egidos." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Solo para clase de 9 a 6"
        '
        'btn_salir2
        '
        Me.btn_salir2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_salir2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salir2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir2.Location = New System.Drawing.Point(263, 128)
        Me.btn_salir2.Name = "btn_salir2"
        Me.btn_salir2.Size = New System.Drawing.Size(75, 25)
        Me.btn_salir2.TabIndex = 9
        Me.btn_salir2.Text = "&Salir"
        Me.btn_salir2.UseVisualStyleBackColor = False
        '
        'btn_aceptar2
        '
        Me.btn_aceptar2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_aceptar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aceptar2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_11
        Me.btn_aceptar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar2.Location = New System.Drawing.Point(182, 128)
        Me.btn_aceptar2.Name = "btn_aceptar2"
        Me.btn_aceptar2.Size = New System.Drawing.Size(75, 25)
        Me.btn_aceptar2.TabIndex = 8
        Me.btn_aceptar2.Text = "&Ingresar"
        Me.btn_aceptar2.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 14)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Año"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(35, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 14)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Mes"
        '
        'cbo_año2
        '
        Me.cbo_año2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año2.FormattingEnabled = True
        Me.cbo_año2.Location = New System.Drawing.Point(124, 55)
        Me.cbo_año2.Name = "cbo_año2"
        Me.cbo_año2.Size = New System.Drawing.Size(66, 22)
        Me.cbo_año2.TabIndex = 4
        '
        'cbo_mes2
        '
        Me.cbo_mes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes2.FormattingEnabled = True
        Me.cbo_mes2.Items.AddRange(New Object() {"INICIO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.cbo_mes2.Location = New System.Drawing.Point(124, 81)
        Me.cbo_mes2.Name = "cbo_mes2"
        Me.cbo_mes2.Size = New System.Drawing.Size(135, 22)
        Me.cbo_mes2.TabIndex = 6
        '
        'RECOVERY_TCON
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 396)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "RECOVERY_TCON"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Realizar recovery de saldos"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_aceptar1 As Button
    Friend WithEvents btn_aceptar2 As Button
    Friend WithEvents btn_salir2 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents cbo_año As ComboBox
    Friend WithEvents cbo_año2 As ComboBox
    Friend WithEvents cbo_mes As ComboBox
    Friend WithEvents cbo_mes2 As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage

End Class
