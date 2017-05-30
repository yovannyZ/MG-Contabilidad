<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_GASTO_PRODUCC
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
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Rb_Orden = New System.Windows.Forms.RadioButton
        Me.Rb_Costos = New System.Windows.Forms.RadioButton
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.BTN_SALIR = New System.Windows.Forms.Button
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.stEstado = New System.Windows.Forms.StatusStrip
        Me.tspbExportar = New System.Windows.Forms.ToolStripProgressBar
        Me.tslblMensaje = New System.Windows.Forms.ToolStripStatusLabel
        Me.gb1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.stEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(97, 190)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(272, 60)
        Me.gb1.TabIndex = 136
        Me.gb1.TabStop = False
        '
        'btn_archivo1
        '
        Me.btn_archivo1.BackColor = System.Drawing.Color.White
        Me.btn_archivo1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_2
        Me.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo1.Location = New System.Drawing.Point(181, 16)
        Me.btn_archivo1.Name = "btn_archivo1"
        Me.btn_archivo1.Size = New System.Drawing.Size(80, 33)
        Me.btn_archivo1.TabIndex = 2
        Me.btn_archivo1.Text = "&Archivo"
        Me.btn_archivo1.UseVisualStyleBackColor = False
        '
        'btn_imprimir1
        '
        Me.btn_imprimir1.BackColor = System.Drawing.Color.White
        Me.btn_imprimir1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_imprimir1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprimir1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.btn_imprimir1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir1.Location = New System.Drawing.Point(96, 16)
        Me.btn_imprimir1.Name = "btn_imprimir1"
        Me.btn_imprimir1.Size = New System.Drawing.Size(80, 33)
        Me.btn_imprimir1.TabIndex = 1
        Me.btn_imprimir1.Text = "&Imprimir"
        Me.btn_imprimir1.UseVisualStyleBackColor = False
        '
        'btn_pantalla1
        '
        Me.btn_pantalla1.BackColor = System.Drawing.Color.White
        Me.btn_pantalla1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_pantalla1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla1.Location = New System.Drawing.Point(10, 16)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(80, 33)
        Me.btn_pantalla1.TabIndex = 0
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Rb_Orden)
        Me.GroupBox1.Controls.Add(Me.Rb_Costos)
        Me.GroupBox1.Controls.Add(Me.cbo_mes)
        Me.GroupBox1.Controls.Add(Me.BTN_SALIR)
        Me.GroupBox1.Controls.Add(Me.cbo_año)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(37, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(367, 152)
        Me.GroupBox1.TabIndex = 135
        Me.GroupBox1.TabStop = False
        '
        'Rb_Orden
        '
        Me.Rb_Orden.AutoSize = True
        Me.Rb_Orden.Checked = True
        Me.Rb_Orden.Location = New System.Drawing.Point(64, 81)
        Me.Rb_Orden.Name = "Rb_Orden"
        Me.Rb_Orden.Size = New System.Drawing.Size(112, 18)
        Me.Rb_Orden.TabIndex = 132
        Me.Rb_Orden.TabStop = True
        Me.Rb_Orden.Text = "Orden Producción"
        Me.Rb_Orden.UseVisualStyleBackColor = True
        '
        'Rb_Costos
        '
        Me.Rb_Costos.AutoSize = True
        Me.Rb_Costos.Location = New System.Drawing.Point(64, 111)
        Me.Rb_Costos.Name = "Rb_Costos"
        Me.Rb_Costos.Size = New System.Drawing.Size(109, 18)
        Me.Rb_Costos.TabIndex = 133
        Me.Rb_Costos.Text = "Centro de Costos"
        Me.Rb_Costos.UseVisualStyleBackColor = True
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(64, 38)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(121, 22)
        Me.cbo_mes.TabIndex = 131
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTN_SALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_SALIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_SALIR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.Location = New System.Drawing.Point(253, 96)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(80, 33)
        Me.BTN_SALIR.TabIndex = 5
        Me.BTN_SALIR.TabStop = False
        Me.BTN_SALIR.Text = "&Salir"
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'cbo_año
        '
        Me.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año.FormattingEnabled = True
        Me.cbo_año.Location = New System.Drawing.Point(253, 38)
        Me.cbo_año.Name = "cbo_año"
        Me.cbo_año.Size = New System.Drawing.Size(79, 22)
        Me.cbo_año.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(208, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 14)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "Año"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(30, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 14)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Mes"
        '
        'stEstado
        '
        Me.stEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspbExportar, Me.tslblMensaje})
        Me.stEstado.Location = New System.Drawing.Point(0, 256)
        Me.stEstado.Name = "stEstado"
        Me.stEstado.Size = New System.Drawing.Size(469, 22)
        Me.stEstado.TabIndex = 140
        Me.stEstado.Text = "StatusStrip1"
        Me.stEstado.Visible = False
        '
        'tspbExportar
        '
        Me.tspbExportar.Name = "tspbExportar"
        Me.tspbExportar.Size = New System.Drawing.Size(100, 16)
        Me.tspbExportar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'tslblMensaje
        '
        Me.tslblMensaje.Name = "tslblMensaje"
        Me.tslblMensaje.Size = New System.Drawing.Size(99, 17)
        Me.tslblMensaje.Text = "Generando Archivo"
        '
        'REPORTE_GASTO_PRODUCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 278)
        Me.ControlBox = False
        Me.Controls.Add(Me.stEstado)
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_GASTO_PRODUCC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gastos Producción"
        Me.gb1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.stEstado.ResumeLayout(False)
        Me.stEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gb1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_archivo1 As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir1 As System.Windows.Forms.Button
    Friend WithEvents btn_pantalla1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents BTN_SALIR As System.Windows.Forms.Button
    Friend WithEvents cbo_año As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Rb_Costos As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Orden As System.Windows.Forms.RadioButton
    Friend WithEvents stEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tspbExportar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tslblMensaje As System.Windows.Forms.ToolStripStatusLabel
End Class
