<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_BCO_TRANS
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btn_sgt1 = New System.Windows.Forms.Button
        Me.btn_buscar1 = New System.Windows.Forms.Button
        Me.ch_cadena1 = New System.Windows.Forms.RadioButton
        Me.ch_aux = New System.Windows.Forms.RadioButton
        Me.ch_comp = New System.Windows.Forms.RadioButton
        Me.txt_letra1 = New System.Windows.Forms.TextBox
        Me.dgw1 = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.cbo_auxiliar = New System.Windows.Forms.ComboBox
        Me.cbo_comprobante = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.ch1 = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_sgt1)
        Me.GroupBox3.Controls.Add(Me.btn_buscar1)
        Me.GroupBox3.Controls.Add(Me.ch_cadena1)
        Me.GroupBox3.Controls.Add(Me.ch_aux)
        Me.GroupBox3.Controls.Add(Me.ch_comp)
        Me.GroupBox3.Controls.Add(Me.txt_letra1)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(338, 73)
        Me.GroupBox3.TabIndex = 24
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
        Me.btn_sgt1.Location = New System.Drawing.Point(267, 13)
        Me.btn_sgt1.Name = "btn_sgt1"
        Me.btn_sgt1.Size = New System.Drawing.Size(64, 26)
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
        Me.btn_buscar1.Location = New System.Drawing.Point(187, 13)
        Me.btn_buscar1.Name = "btn_buscar1"
        Me.btn_buscar1.Size = New System.Drawing.Size(74, 26)
        Me.btn_buscar1.TabIndex = 1
        Me.btn_buscar1.Text = "&Buscar"
        Me.btn_buscar1.UseVisualStyleBackColor = True
        '
        'ch_cadena1
        '
        Me.ch_cadena1.AutoSize = True
        Me.ch_cadena1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_cadena1.Location = New System.Drawing.Point(205, 47)
        Me.ch_cadena1.Name = "ch_cadena1"
        Me.ch_cadena1.Size = New System.Drawing.Size(62, 18)
        Me.ch_cadena1.TabIndex = 5
        Me.ch_cadena1.Text = "Cadena"
        Me.ch_cadena1.UseVisualStyleBackColor = True
        '
        'ch_aux
        '
        Me.ch_aux.AutoSize = True
        Me.ch_aux.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_aux.Location = New System.Drawing.Point(116, 47)
        Me.ch_aux.Name = "ch_aux"
        Me.ch_aux.Size = New System.Drawing.Size(83, 18)
        Me.ch_aux.TabIndex = 4
        Me.ch_aux.Text = "Cód.Auxiliar"
        Me.ch_aux.UseVisualStyleBackColor = True
        '
        'ch_comp
        '
        Me.ch_comp.AutoSize = True
        Me.ch_comp.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_comp.Location = New System.Drawing.Point(6, 47)
        Me.ch_comp.Name = "ch_comp"
        Me.ch_comp.Size = New System.Drawing.Size(104, 18)
        Me.ch_comp.TabIndex = 3
        Me.ch_comp.Text = "Nº Comprobante"
        Me.ch_comp.UseVisualStyleBackColor = True
        '
        'txt_letra1
        '
        Me.txt_letra1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_letra1.Location = New System.Drawing.Point(6, 19)
        Me.txt_letra1.Name = "txt_letra1"
        Me.txt_letra1.Size = New System.Drawing.Size(175, 20)
        Me.txt_letra1.TabIndex = 0
        '
        'dgw1
        '
        Me.dgw1.AllowUserToAddRows = False
        Me.dgw1.AllowUserToDeleteRows = False
        Me.dgw1.AllowUserToOrderColumns = True
        Me.dgw1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgw1.BackgroundColor = System.Drawing.Color.White
        Me.dgw1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgw1.Location = New System.Drawing.Point(0, 105)
        Me.dgw1.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw1.MultiSelect = False
        Me.dgw1.Name = "dgw1"
        Me.dgw1.RowHeadersWidth = 25
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw1.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw1.Size = New System.Drawing.Size(787, 310)
        Me.dgw1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbo_año)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.btn_cancelar)
        Me.GroupBox2.Controls.Add(Me.cbo_auxiliar)
        Me.GroupBox2.Controls.Add(Me.cbo_comprobante)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cbo_mes)
        Me.GroupBox2.Controls.Add(Me.ch1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btn_aceptar)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(346, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(438, 100)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Reporte de Impresión de Banco"
        '
        'cbo_año
        '
        Me.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_año.FormattingEnabled = True
        Me.cbo_año.Location = New System.Drawing.Point(263, 26)
        Me.cbo_año.Name = "cbo_año"
        Me.cbo_año.Size = New System.Drawing.Size(79, 22)
        Me.cbo_año.TabIndex = 34
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(230, 29)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(27, 14)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Año"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(242, 51)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(97, 18)
        Me.CheckBox1.TabIndex = 30
        Me.CheckBox1.Text = "Papel Continuo"
        Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancelar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.Location = New System.Drawing.Point(348, 69)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(84, 28)
        Me.btn_cancelar.TabIndex = 25
        Me.btn_cancelar.Text = "&Salir"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'cbo_auxiliar
        '
        Me.cbo_auxiliar.BackColor = System.Drawing.Color.White
        Me.cbo_auxiliar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_auxiliar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_auxiliar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_auxiliar.FormattingEnabled = True
        Me.cbo_auxiliar.Location = New System.Drawing.Point(75, 26)
        Me.cbo_auxiliar.MaxDropDownItems = 9
        Me.cbo_auxiliar.Name = "cbo_auxiliar"
        Me.cbo_auxiliar.Size = New System.Drawing.Size(149, 22)
        Me.cbo_auxiliar.TabIndex = 28
        '
        'cbo_comprobante
        '
        Me.cbo_comprobante.BackColor = System.Drawing.Color.White
        Me.cbo_comprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_comprobante.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_comprobante.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_comprobante.FormattingEnabled = True
        Me.cbo_comprobante.Location = New System.Drawing.Point(75, 51)
        Me.cbo_comprobante.MaxDropDownItems = 10
        Me.cbo_comprobante.Name = "cbo_comprobante"
        Me.cbo_comprobante.Size = New System.Drawing.Size(149, 22)
        Me.cbo_comprobante.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 14)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Auxiliar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 14)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Comprobante"
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(75, 74)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(99, 22)
        Me.cbo_mes.TabIndex = 25
        '
        'ch1
        '
        Me.ch1.AutoSize = True
        Me.ch1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ch1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ch1.Location = New System.Drawing.Point(223, 75)
        Me.ch1.Name = "ch1"
        Me.ch1.Size = New System.Drawing.Size(115, 18)
        Me.ch1.TabIndex = 22
        Me.ch1.Text = "Seleccionar Todos"
        Me.ch1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ch1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 14)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Mes"
        '
        'btn_aceptar
        '
        Me.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_aceptar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar.Location = New System.Drawing.Point(348, 37)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(84, 28)
        Me.btn_aceptar.TabIndex = 1
        Me.btn_aceptar.Text = "&Imprimir"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'REPORTE_BCO_TRANS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 415)
        Me.Controls.Add(Me.dgw1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "REPORTE_BCO_TRANS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Impresión de Banco Transferencias"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgw1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_sgt1 As System.Windows.Forms.Button
    Friend WithEvents btn_buscar1 As System.Windows.Forms.Button
    Friend WithEvents ch_cadena1 As System.Windows.Forms.RadioButton
    Friend WithEvents ch_aux As System.Windows.Forms.RadioButton
    Friend WithEvents ch_comp As System.Windows.Forms.RadioButton
    Friend WithEvents txt_letra1 As System.Windows.Forms.TextBox
    Friend WithEvents dgw1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents cbo_auxiliar As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_comprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents ch1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_año As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
