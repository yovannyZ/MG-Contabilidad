Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_TCXC
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
        Me.PaneL_CTA = New System.Windows.Forms.Panel
        Me.dgw_cta = New System.Windows.Forms.DataGridView
        Me.Panel_per = New System.Windows.Forms.Panel
        Me.dgw_per = New System.Windows.Forms.DataGridView
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_doc_per = New System.Windows.Forms.TextBox
        Me.txt_desc_per = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CH_PER = New System.Windows.Forms.CheckBox
        Me.txt_cod_per = New System.Windows.Forms.TextBox
        Me.txt_desc_cta0 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_cod_cta0 = New System.Windows.Forms.TextBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.ch_p = New System.Windows.Forms.CheckBox
        Me.KL = New System.Windows.Forms.TextBox
        Me.PaneL_CTA.SuspendLayout()
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_per.SuspendLayout()
        CType(Me.dgw_per, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PaneL_CTA
        '
        Me.PaneL_CTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PaneL_CTA.Controls.Add(Me.dgw_cta)
        Me.PaneL_CTA.Location = New System.Drawing.Point(97, 73)
        Me.PaneL_CTA.Name = "PaneL_CTA"
        Me.PaneL_CTA.Size = New System.Drawing.Size(426, 141)
        Me.PaneL_CTA.TabIndex = 145
        Me.PaneL_CTA.Visible = False
        '
        'dgw_cta
        '
        Me.dgw_cta.AllowUserToAddRows = False
        Me.dgw_cta.AllowUserToDeleteRows = False
        Me.dgw_cta.AllowUserToOrderColumns = True
        Me.dgw_cta.AllowUserToResizeRows = False
        Me.dgw_cta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_cta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_cta.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cta.Location = New System.Drawing.Point(23, -1)
        Me.dgw_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta.MultiSelect = False
        Me.dgw_cta.Name = "dgw_cta"
        Me.dgw_cta.ReadOnly = True
        Me.dgw_cta.RowHeadersWidth = 25
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw_cta.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta.Size = New System.Drawing.Size(384, 134)
        Me.dgw_cta.TabIndex = 17
        '
        'Panel_per
        '
        Me.Panel_per.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_per.Controls.Add(Me.dgw_per)
        Me.Panel_per.Location = New System.Drawing.Point(97, 112)
        Me.Panel_per.Name = "Panel_per"
        Me.Panel_per.Size = New System.Drawing.Size(524, 143)
        Me.Panel_per.TabIndex = 146
        Me.Panel_per.Visible = False
        '
        'dgw_per
        '
        Me.dgw_per.AllowUserToAddRows = False
        Me.dgw_per.AllowUserToDeleteRows = False
        Me.dgw_per.AllowUserToOrderColumns = True
        Me.dgw_per.AllowUserToResizeRows = False
        Me.dgw_per.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_per.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_per.BackgroundColor = System.Drawing.Color.White
        Me.dgw_per.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_per.Location = New System.Drawing.Point(23, 0)
        Me.dgw_per.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_per.MultiSelect = False
        Me.dgw_per.Name = "dgw_per"
        Me.dgw_per.ReadOnly = True
        Me.dgw_per.RowHeadersWidth = 25
        Me.dgw_per.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_per.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_per.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_per.Size = New System.Drawing.Size(489, 136)
        Me.dgw_per.TabIndex = 15
        Me.dgw_per.TabStop = False
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(182, 226)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(289, 65)
        Me.gb1.TabIndex = 144
        Me.gb1.TabStop = False
        '
        'btn_archivo1
        '
        Me.btn_archivo1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo1.Location = New System.Drawing.Point(186, 17)
        Me.btn_archivo1.Name = "btn_archivo1"
        Me.btn_archivo1.Size = New System.Drawing.Size(82, 33)
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
        Me.btn_imprimir1.Location = New System.Drawing.Point(98, 17)
        Me.btn_imprimir1.Name = "btn_imprimir1"
        Me.btn_imprimir1.Size = New System.Drawing.Size(82, 33)
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
        Me.btn_pantalla1.Location = New System.Drawing.Point(10, 17)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(82, 33)
        Me.btn_pantalla1.TabIndex = 0
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbo_año)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbo_mes)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_doc_per)
        Me.GroupBox1.Controls.Add(Me.txt_desc_per)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CH_PER)
        Me.GroupBox1.Controls.Add(Me.txt_cod_per)
        Me.GroupBox1.Controls.Add(Me.txt_desc_cta0)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_cod_cta0)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.ch_p)
        Me.GroupBox1.Controls.Add(Me.KL)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(598, 192)
        Me.GroupBox1.TabIndex = 143
        Me.GroupBox1.TabStop = False
        '
        'cbo_año
        '
        Me.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año.FormattingEnabled = True
        Me.cbo_año.Location = New System.Drawing.Point(288, 103)
        Me.cbo_año.Name = "cbo_año"
        Me.cbo_año.Size = New System.Drawing.Size(79, 22)
        Me.cbo_año.TabIndex = 145
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(237, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 14)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Año"
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(128, 100)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(90, 22)
        Me.cbo_mes.TabIndex = 144
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.Location = New System.Drawing.Point(95, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 14)
        Me.Label5.TabIndex = 146
        Me.Label5.Text = "Mes"
        '
        'txt_doc_per
        '
        Me.txt_doc_per.BackColor = System.Drawing.Color.White
        Me.txt_doc_per.Enabled = False
        Me.txt_doc_per.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_doc_per.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_doc_per.Location = New System.Drawing.Point(482, 62)
        Me.txt_doc_per.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_doc_per.MaxLength = 20
        Me.txt_doc_per.Name = "txt_doc_per"
        Me.txt_doc_per.Size = New System.Drawing.Size(105, 20)
        Me.txt_doc_per.TabIndex = 139
        '
        'txt_desc_per
        '
        Me.txt_desc_per.BackColor = System.Drawing.Color.White
        Me.txt_desc_per.Enabled = False
        Me.txt_desc_per.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_per.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_desc_per.Location = New System.Drawing.Point(159, 62)
        Me.txt_desc_per.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_per.Name = "txt_desc_per"
        Me.txt_desc_per.Size = New System.Drawing.Size(323, 20)
        Me.txt_desc_per.TabIndex = 141
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 14)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "Persona"
        '
        'CH_PER
        '
        Me.CH_PER.AutoSize = True
        Me.CH_PER.Location = New System.Drawing.Point(80, 67)
        Me.CH_PER.Name = "CH_PER"
        Me.CH_PER.Size = New System.Drawing.Size(15, 14)
        Me.CH_PER.TabIndex = 143
        Me.CH_PER.UseVisualStyleBackColor = True
        '
        'txt_cod_per
        '
        Me.txt_cod_per.BackColor = System.Drawing.Color.White
        Me.txt_cod_per.Enabled = False
        Me.txt_cod_per.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_per.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_cod_per.Location = New System.Drawing.Point(98, 62)
        Me.txt_cod_per.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_per.MaxLength = 5
        Me.txt_cod_per.Name = "txt_cod_per"
        Me.txt_cod_per.Size = New System.Drawing.Size(61, 20)
        Me.txt_cod_per.TabIndex = 138
        '
        'txt_desc_cta0
        '
        Me.txt_desc_cta0.Location = New System.Drawing.Point(159, 28)
        Me.txt_desc_cta0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_cta0.MaxLength = 40
        Me.txt_desc_cta0.Name = "txt_desc_cta0"
        Me.txt_desc_cta0.Size = New System.Drawing.Size(323, 20)
        Me.txt_desc_cta0.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 14)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Cuenta"
        '
        'txt_cod_cta0
        '
        Me.txt_cod_cta0.Location = New System.Drawing.Point(98, 28)
        Me.txt_cod_cta0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_cta0.MaxLength = 8
        Me.txt_cod_cta0.Name = "txt_cod_cta0"
        Me.txt_cod_cta0.Size = New System.Drawing.Size(60, 20)
        Me.txt_cod_cta0.TabIndex = 31
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.SystemColors.Control
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(494, 145)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(82, 33)
        Me.btn_salir.TabIndex = 30
        Me.btn_salir.TabStop = False
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'ch_p
        '
        Me.ch_p.AutoSize = True
        Me.ch_p.Location = New System.Drawing.Point(408, 106)
        Me.ch_p.Name = "ch_p"
        Me.ch_p.Size = New System.Drawing.Size(73, 18)
        Me.ch_p.TabIndex = 29
        Me.ch_p.TabStop = False
        Me.ch_p.Text = "Pendiente"
        Me.ch_p.UseVisualStyleBackColor = True
        Me.ch_p.Visible = False
        '
        'KL
        '
        Me.KL.Location = New System.Drawing.Point(264, 28)
        Me.KL.Margin = New System.Windows.Forms.Padding(0)
        Me.KL.MaxLength = 8
        Me.KL.Name = "KL"
        Me.KL.Size = New System.Drawing.Size(10, 20)
        Me.KL.TabIndex = 35
        '
        'REPORTE_TCXC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 324)
        Me.ControlBox = False
        Me.Controls.Add(Me.PaneL_CTA)
        Me.Controls.Add(Me.Panel_per)
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_TCXC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Cuentas por Cobrar"
        Me.PaneL_CTA.ResumeLayout(False)
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_per.ResumeLayout(False)
        CType(Me.dgw_per, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_archivo1 As Button
    Friend WithEvents btn_imprimir1 As Button
    Friend WithEvents btn_pantalla1 As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents cbo_año As ComboBox
    Friend WithEvents cbo_mes As ComboBox
    Friend WithEvents ch_p As CheckBox
    Friend WithEvents CH_PER As CheckBox
    Friend WithEvents dgw_cta As DataGridView
    Friend WithEvents dgw_per As DataGridView
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents KL As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PaneL_CTA As Panel
    Friend WithEvents Panel_per As Panel
    Friend WithEvents txt_cod_cta0 As TextBox
    Friend WithEvents txt_cod_per As TextBox
    Friend WithEvents txt_desc_cta0 As TextBox
    Friend WithEvents txt_desc_per As TextBox
    Friend WithEvents txt_doc_per As TextBox


End Class
