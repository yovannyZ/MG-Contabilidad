<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TIPO_PLANILLA
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
        Me.cboTipo = New System.Windows.Forms.ComboBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.cboAño = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboMes = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnDataBase = New System.Windows.Forms.Button
        Me.txtServidor = New System.Windows.Forms.TextBox
        Me.txtBaseDatos = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtFechaCierrePlanilla = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtUsuCierrePlanilla = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.White
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(125, 23)
        Me.cboTipo.MaxDropDownItems = 9
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(171, 22)
        Me.cboTipo.TabIndex = 23
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(38, 31)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(27, 14)
        Me.Label35.TabIndex = 24
        Me.Label35.Text = "Tipo"
        '
        'cboAño
        '
        Me.cboAño.BackColor = System.Drawing.Color.White
        Me.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAño.Enabled = False
        Me.cboAño.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAño.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboAño.FormattingEnabled = True
        Me.cboAño.Location = New System.Drawing.Point(125, 51)
        Me.cboAño.MaxDropDownItems = 9
        Me.cboAño.Name = "cboAño"
        Me.cboAño.Size = New System.Drawing.Size(59, 22)
        Me.cboAño.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 14)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Año"
        '
        'cboMes
        '
        Me.cboMes.BackColor = System.Drawing.Color.White
        Me.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMes.Enabled = False
        Me.cboMes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboMes.FormattingEnabled = True
        Me.cboMes.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cboMes.Location = New System.Drawing.Point(237, 51)
        Me.cboMes.MaxDropDownItems = 9
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(59, 22)
        Me.cboMes.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(199, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 14)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Mes"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 14)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Servidor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(38, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 14)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Base de datos"
        '
        'btnDataBase
        '
        Me.btnDataBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDataBase.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDataBase.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Ok_1
        Me.btnDataBase.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDataBase.Location = New System.Drawing.Point(82, 204)
        Me.btnDataBase.Name = "btnDataBase"
        Me.btnDataBase.Size = New System.Drawing.Size(74, 27)
        Me.btnDataBase.TabIndex = 33
        Me.btnDataBase.Text = "&Aceptar"
        Me.btnDataBase.UseVisualStyleBackColor = True
        '
        'txtServidor
        '
        Me.txtServidor.Enabled = False
        Me.txtServidor.Location = New System.Drawing.Point(125, 131)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(171, 20)
        Me.txtServidor.TabIndex = 34
        '
        'txtBaseDatos
        '
        Me.txtBaseDatos.Enabled = False
        Me.txtBaseDatos.Location = New System.Drawing.Point(125, 157)
        Me.txtBaseDatos.Name = "txtBaseDatos"
        Me.txtBaseDatos.Size = New System.Drawing.Size(171, 20)
        Me.txtBaseDatos.TabIndex = 35
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(162, 204)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 29)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "&Cancelar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtFechaCierrePlanilla
        '
        Me.txtFechaCierrePlanilla.Enabled = False
        Me.txtFechaCierrePlanilla.Location = New System.Drawing.Point(125, 105)
        Me.txtFechaCierrePlanilla.Name = "txtFechaCierrePlanilla"
        Me.txtFechaCierrePlanilla.Size = New System.Drawing.Size(136, 20)
        Me.txtFechaCierrePlanilla.TabIndex = 44
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(38, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 14)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Fecha cierre"
        '
        'txtUsuCierrePlanilla
        '
        Me.txtUsuCierrePlanilla.Enabled = False
        Me.txtUsuCierrePlanilla.Location = New System.Drawing.Point(125, 79)
        Me.txtUsuCierrePlanilla.Name = "txtUsuCierrePlanilla"
        Me.txtUsuCierrePlanilla.Size = New System.Drawing.Size(76, 20)
        Me.txtUsuCierrePlanilla.TabIndex = 42
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(38, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 14)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Usuario cierre "
        '
        'TIPO_PLANILLA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(327, 246)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtFechaCierrePlanilla)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtUsuCierrePlanilla)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtBaseDatos)
        Me.Controls.Add(Me.txtServidor)
        Me.Controls.Add(Me.btnDataBase)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboMes)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboAño)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.Label35)
        Me.Name = "TIPO_PLANILLA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tipo Planilla"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cboAño As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnDataBase As System.Windows.Forms.Button
    Friend WithEvents txtServidor As System.Windows.Forms.TextBox
    Friend WithEvents txtBaseDatos As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtFechaCierrePlanilla As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtUsuCierrePlanilla As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
