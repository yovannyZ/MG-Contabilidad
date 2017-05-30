Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_EEPP_UNIDAD_NEGOCIO
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
        Me.panCabecera = New System.Windows.Forms.Panel
        Me.rbMensual = New System.Windows.Forms.RadioButton
        Me.rbAcumulado = New System.Windows.Forms.RadioButton
        Me.cboAño = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboMes = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.panButtons = New System.Windows.Forms.Panel
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.chkResumen = New System.Windows.Forms.CheckBox
        Me.panCabecera.SuspendLayout()
        Me.panButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'panCabecera
        '
        Me.panCabecera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panCabecera.Controls.Add(Me.chkResumen)
        Me.panCabecera.Controls.Add(Me.rbMensual)
        Me.panCabecera.Controls.Add(Me.rbAcumulado)
        Me.panCabecera.Controls.Add(Me.cboAño)
        Me.panCabecera.Controls.Add(Me.Label10)
        Me.panCabecera.Controls.Add(Me.cboMes)
        Me.panCabecera.Controls.Add(Me.Label9)
        Me.panCabecera.Location = New System.Drawing.Point(25, 12)
        Me.panCabecera.Name = "panCabecera"
        Me.panCabecera.Size = New System.Drawing.Size(525, 114)
        Me.panCabecera.TabIndex = 0
        '
        'rbMensual
        '
        Me.rbMensual.AutoSize = True
        Me.rbMensual.Location = New System.Drawing.Point(180, 82)
        Me.rbMensual.Name = "rbMensual"
        Me.rbMensual.Size = New System.Drawing.Size(65, 18)
        Me.rbMensual.TabIndex = 6
        Me.rbMensual.TabStop = True
        Me.rbMensual.Text = "Mensual"
        Me.rbMensual.UseVisualStyleBackColor = True
        '
        'rbAcumulado
        '
        Me.rbAcumulado.AutoSize = True
        Me.rbAcumulado.Location = New System.Drawing.Point(294, 82)
        Me.rbAcumulado.Name = "rbAcumulado"
        Me.rbAcumulado.Size = New System.Drawing.Size(79, 18)
        Me.rbAcumulado.TabIndex = 6
        Me.rbAcumulado.TabStop = True
        Me.rbAcumulado.Text = "Acumulado"
        Me.rbAcumulado.UseVisualStyleBackColor = True
        '
        'cboAño
        '
        Me.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAño.FormattingEnabled = True
        Me.cboAño.Location = New System.Drawing.Point(334, 41)
        Me.cboAño.Name = "cboAño"
        Me.cboAño.Size = New System.Drawing.Size(121, 22)
        Me.cboAño.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(264, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 14)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Año"
        '
        'cboMes
        '
        Me.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMes.FormattingEnabled = True
        Me.cboMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboMes.Location = New System.Drawing.Point(118, 41)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(121, 22)
        Me.cboMes.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(48, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 14)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Mes"
        '
        'panButtons
        '
        Me.panButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panButtons.Controls.Add(Me.btn_archivo1)
        Me.panButtons.Controls.Add(Me.btn_imprimir1)
        Me.panButtons.Controls.Add(Me.btn_pantalla1)
        Me.panButtons.Location = New System.Drawing.Point(144, 132)
        Me.panButtons.Name = "panButtons"
        Me.panButtons.Size = New System.Drawing.Size(304, 60)
        Me.panButtons.TabIndex = 1
        '
        'btn_archivo1
        '
        Me.btn_archivo1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo1.Location = New System.Drawing.Point(198, 13)
        Me.btn_archivo1.Name = "btn_archivo1"
        Me.btn_archivo1.Size = New System.Drawing.Size(82, 33)
        Me.btn_archivo1.TabIndex = 5
        Me.btn_archivo1.Text = "&Archivo"
        Me.btn_archivo1.UseVisualStyleBackColor = False
        '
        'btn_imprimir1
        '
        Me.btn_imprimir1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_imprimir1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprimir1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.btn_imprimir1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir1.Location = New System.Drawing.Point(110, 13)
        Me.btn_imprimir1.Name = "btn_imprimir1"
        Me.btn_imprimir1.Size = New System.Drawing.Size(82, 33)
        Me.btn_imprimir1.TabIndex = 4
        Me.btn_imprimir1.Text = "&Imprimir"
        Me.btn_imprimir1.UseVisualStyleBackColor = False
        '
        'btn_pantalla1
        '
        Me.btn_pantalla1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pantalla1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla1.Location = New System.Drawing.Point(22, 13)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(82, 33)
        Me.btn_pantalla1.TabIndex = 3
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(468, 146)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 33)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "&Salir"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'chkResumen
        '
        Me.chkResumen.AutoSize = True
        Me.chkResumen.Location = New System.Drawing.Point(428, 82)
        Me.chkResumen.Name = "chkResumen"
        Me.chkResumen.Size = New System.Drawing.Size(71, 18)
        Me.chkResumen.TabIndex = 7
        Me.chkResumen.Text = "Resumen"
        Me.chkResumen.UseVisualStyleBackColor = True
        '
        'REPORTE_EEPP_UNIDAD_NEGOCIO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 234)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.panButtons)
        Me.Controls.Add(Me.panCabecera)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_EEPP_UNIDAD_NEGOCIO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Estadísticas de Perdidas y Ganancias"
        Me.panCabecera.ResumeLayout(False)
        Me.panCabecera.PerformLayout()
        Me.panButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panCabecera As System.Windows.Forms.Panel
    Friend WithEvents panButtons As System.Windows.Forms.Panel
    Friend WithEvents btn_archivo1 As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir1 As System.Windows.Forms.Button
    Friend WithEvents btn_pantalla1 As System.Windows.Forms.Button
    Friend WithEvents cboAño As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rbMensual As System.Windows.Forms.RadioButton
    Friend WithEvents rbAcumulado As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkResumen As System.Windows.Forms.CheckBox

    'Public Sub New()

    '    ' Llamada necesaria para el Diseñador de Windows Forms.
    '    InitializeComponent()

    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    'End Sub
End Class
