<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TITULOS
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.btn_salir = New System.Windows.Forms.Button
        Me.btn_eliminar = New System.Windows.Forms.Button
        Me.btn_modificar = New System.Windows.Forms.Button
        Me.btn_nuevo = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_des = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_linea1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_linea2 = New System.Windows.Forms.TextBox
        Me.txt_cod = New System.Windows.Forms.TextBox
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.btn_modificar2 = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.TabControl1.Size = New System.Drawing.Size(560, 335)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgw1)
        Me.TabPage1.Controls.Add(Me.btn_salir)
        Me.TabPage1.Controls.Add(Me.btn_eliminar)
        Me.TabPage1.Controls.Add(Me.btn_modificar)
        Me.TabPage1.Controls.Add(Me.btn_nuevo)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(552, 308)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Lista de Títulos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AllowUserToOrderColumns = True
        Me.dgw1.AllowUserToResizeRows = False
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.Location = New System.Drawing.Point(8, 6)
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.ReadOnly = True
        Me.dgw1.RowHeadersWidth = 25
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(415, 294)
        Me.dgw1.TabIndex = 7
        '
        'btn_salir
        '
        Me.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(448, 158)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(85, 35)
        Me.btn_salir.TabIndex = 4
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eliminar.Location = New System.Drawing.Point(448, 117)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(85, 35)
        Me.btn_eliminar.TabIndex = 3
        Me.btn_eliminar.Text = "&Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_modificar
        '
        Me.btn_modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Edit_2_1
        Me.btn_modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar.Location = New System.Drawing.Point(448, 76)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(85, 35)
        Me.btn_modificar.TabIndex = 2
        Me.btn_modificar.Text = "&Modificar"
        Me.btn_modificar.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.Location = New System.Drawing.Point(448, 35)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(85, 35)
        Me.btn_nuevo.TabIndex = 1
        Me.btn_nuevo.Text = "&Nuevo"
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(552, 308)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalles"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_des)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_linea1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_linea2)
        Me.GroupBox1.Controls.Add(Me.txt_cod)
        Me.GroupBox1.Controls.Add(Me.btn_guardar)
        Me.GroupBox1.Controls.Add(Me.btn_modificar2)
        Me.GroupBox1.Controls.Add(Me.btn_cancelar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(540, 294)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'txt_des
        '
        Me.txt_des.BackColor = System.Drawing.Color.White
        Me.txt_des.Location = New System.Drawing.Point(94, 60)
        Me.txt_des.MaxLength = 60
        Me.txt_des.Name = "txt_des"
        Me.txt_des.Size = New System.Drawing.Size(426, 20)
        Me.txt_des.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 14)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Descripción"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Línea 1"
        '
        'txt_linea1
        '
        Me.txt_linea1.BackColor = System.Drawing.Color.White
        Me.txt_linea1.Location = New System.Drawing.Point(94, 90)
        Me.txt_linea1.MaxLength = 700
        Me.txt_linea1.Multiline = True
        Me.txt_linea1.Name = "txt_linea1"
        Me.txt_linea1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txt_linea1.Size = New System.Drawing.Size(426, 59)
        Me.txt_linea1.TabIndex = 3
        Me.txt_linea1.WordWrap = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Línea 2"
        '
        'txt_linea2
        '
        Me.txt_linea2.BackColor = System.Drawing.Color.White
        Me.txt_linea2.Location = New System.Drawing.Point(94, 163)
        Me.txt_linea2.MaxLength = 700
        Me.txt_linea2.Multiline = True
        Me.txt_linea2.Name = "txt_linea2"
        Me.txt_linea2.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txt_linea2.Size = New System.Drawing.Size(426, 59)
        Me.txt_linea2.TabIndex = 4
        Me.txt_linea2.WordWrap = False
        '
        'txt_cod
        '
        Me.txt_cod.BackColor = System.Drawing.Color.White
        Me.txt_cod.Location = New System.Drawing.Point(94, 30)
        Me.txt_cod.MaxLength = 4
        Me.txt_cod.Name = "txt_cod"
        Me.txt_cod.Size = New System.Drawing.Size(33, 20)
        Me.txt_cod.TabIndex = 1
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.Location = New System.Drawing.Point(359, 241)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(77, 27)
        Me.btn_guardar.TabIndex = 5
        Me.btn_guardar.Text = "&Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_modificar2
        '
        Me.btn_modificar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_modificar2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Save_as_1
        Me.btn_modificar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_modificar2.Location = New System.Drawing.Point(359, 241)
        Me.btn_modificar2.Name = "btn_modificar2"
        Me.btn_modificar2.Size = New System.Drawing.Size(77, 27)
        Me.btn_modificar2.TabIndex = 5
        Me.btn_modificar2.Text = "&Modificar"
        Me.btn_modificar2.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.Location = New System.Drawing.Point(442, 241)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(77, 27)
        Me.btn_cancelar.TabIndex = 6
        Me.btn_cancelar.Text = "&Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cód.Reporte"
        '
        'TITULOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 335)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "TITULOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Títulos"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar2 As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents dgw1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txt_cod As System.Windows.Forms.TextBox
    Friend WithEvents txt_des As System.Windows.Forms.TextBox
    Friend WithEvents txt_linea1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_linea2 As System.Windows.Forms.TextBox

End Class
