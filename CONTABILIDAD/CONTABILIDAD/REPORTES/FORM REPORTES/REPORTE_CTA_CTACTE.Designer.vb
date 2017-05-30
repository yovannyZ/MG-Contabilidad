Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_CTA_CTACTE
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
        Me.txt_desc_cta = New System.Windows.Forms.TextBox
        Me.txt_doc_per = New System.Windows.Forms.TextBox
        Me.CH_PER = New System.Windows.Forms.CheckBox
        Me.KL2 = New System.Windows.Forms.TextBox
        Me.KL1 = New System.Windows.Forms.TextBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.CBO_ORDEN = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CBO_MES2 = New System.Windows.Forms.ComboBox
        Me.CBO_MES = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_desc_per = New System.Windows.Forms.TextBox
        Me.txt_cod_per = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_cta = New System.Windows.Forms.TextBox
        Me.dgw_per = New System.Windows.Forms.DataGridView
        Me.dgw_cta = New System.Windows.Forms.DataGridView
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.Panel_cta = New System.Windows.Forms.Panel
        Me.Panel_per = New System.Windows.Forms.Panel
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgw_per, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb1.SuspendLayout()
        Me.Panel_cta.SuspendLayout()
        Me.Panel_per.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_desc_cta)
        Me.GroupBox1.Controls.Add(Me.txt_doc_per)
        Me.GroupBox1.Controls.Add(Me.CH_PER)
        Me.GroupBox1.Controls.Add(Me.KL2)
        Me.GroupBox1.Controls.Add(Me.KL1)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.CBO_ORDEN)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CBO_MES2)
        Me.GroupBox1.Controls.Add(Me.CBO_MES)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_desc_per)
        Me.GroupBox1.Controls.Add(Me.txt_cod_per)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txt_cta)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(614, 181)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txt_desc_cta
        '
        Me.txt_desc_cta.Location = New System.Drawing.Point(161, 44)
        Me.txt_desc_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_cta.Name = "txt_desc_cta"
        Me.txt_desc_cta.Size = New System.Drawing.Size(323, 20)
        Me.txt_desc_cta.TabIndex = 1
        '
        'txt_doc_per
        '
        Me.txt_doc_per.BackColor = System.Drawing.Color.White
        Me.txt_doc_per.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_doc_per.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_doc_per.Location = New System.Drawing.Point(484, 70)
        Me.txt_doc_per.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_doc_per.MaxLength = 20
        Me.txt_doc_per.Name = "txt_doc_per"
        Me.txt_doc_per.Size = New System.Drawing.Size(105, 20)
        Me.txt_doc_per.TabIndex = 5
        '
        'CH_PER
        '
        Me.CH_PER.AutoSize = True
        Me.CH_PER.Location = New System.Drawing.Point(82, 74)
        Me.CH_PER.Name = "CH_PER"
        Me.CH_PER.Size = New System.Drawing.Size(15, 14)
        Me.CH_PER.TabIndex = 137
        Me.CH_PER.UseVisualStyleBackColor = True
        '
        'KL2
        '
        Me.KL2.Location = New System.Drawing.Point(494, 70)
        Me.KL2.Margin = New System.Windows.Forms.Padding(0)
        Me.KL2.MaxLength = 8
        Me.KL2.Name = "KL2"
        Me.KL2.Size = New System.Drawing.Size(10, 20)
        Me.KL2.TabIndex = 6
        '
        'KL1
        '
        Me.KL1.Location = New System.Drawing.Point(254, 44)
        Me.KL1.Margin = New System.Windows.Forms.Padding(0)
        Me.KL1.MaxLength = 8
        Me.KL1.Name = "KL1"
        Me.KL1.Size = New System.Drawing.Size(10, 20)
        Me.KL1.TabIndex = 2
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.SystemColors.Control
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(507, 127)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(82, 31)
        Me.btn_salir.TabIndex = 69
        Me.btn_salir.TabStop = False
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'CBO_ORDEN
        '
        Me.CBO_ORDEN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_ORDEN.FormattingEnabled = True
        Me.CBO_ORDEN.Items.AddRange(New Object() {"Doc.", "Fecha"})
        Me.CBO_ORDEN.Location = New System.Drawing.Point(100, 124)
        Me.CBO_ORDEN.Name = "CBO_ORDEN"
        Me.CBO_ORDEN.Size = New System.Drawing.Size(76, 22)
        Me.CBO_ORDEN.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 14)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "Orden"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(177, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 14)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Al Mes"
        '
        'CBO_MES2
        '
        Me.CBO_MES2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_MES2.FormattingEnabled = True
        Me.CBO_MES2.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13"})
        Me.CBO_MES2.Location = New System.Drawing.Point(223, 96)
        Me.CBO_MES2.Name = "CBO_MES2"
        Me.CBO_MES2.Size = New System.Drawing.Size(55, 22)
        Me.CBO_MES2.TabIndex = 8
        '
        'CBO_MES
        '
        Me.CBO_MES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_MES.FormattingEnabled = True
        Me.CBO_MES.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13"})
        Me.CBO_MES.Location = New System.Drawing.Point(100, 96)
        Me.CBO_MES.Name = "CBO_MES"
        Me.CBO_MES.Size = New System.Drawing.Size(52, 22)
        Me.CBO_MES.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 14)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Del Mes"
        '
        'txt_desc_per
        '
        Me.txt_desc_per.BackColor = System.Drawing.Color.White
        Me.txt_desc_per.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_per.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_desc_per.Location = New System.Drawing.Point(161, 70)
        Me.txt_desc_per.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_per.Name = "txt_desc_per"
        Me.txt_desc_per.Size = New System.Drawing.Size(323, 20)
        Me.txt_desc_per.TabIndex = 4
        '
        'txt_cod_per
        '
        Me.txt_cod_per.BackColor = System.Drawing.Color.White
        Me.txt_cod_per.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_per.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_cod_per.Location = New System.Drawing.Point(100, 70)
        Me.txt_cod_per.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_per.MaxLength = 5
        Me.txt_cod_per.Name = "txt_cod_per"
        Me.txt_cod_per.Size = New System.Drawing.Size(61, 20)
        Me.txt_cod_per.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 14)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Persona"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 14)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "Cuenta"
        '
        'txt_cta
        '
        Me.txt_cta.Location = New System.Drawing.Point(100, 44)
        Me.txt_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cta.MaxLength = 8
        Me.txt_cta.Name = "txt_cta"
        Me.txt_cta.Size = New System.Drawing.Size(61, 20)
        Me.txt_cta.TabIndex = 0
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
        Me.dgw_per.Location = New System.Drawing.Point(112, 0)
        Me.dgw_per.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_per.MultiSelect = False
        Me.dgw_per.Name = "dgw_per"
        Me.dgw_per.ReadOnly = True
        Me.dgw_per.RowHeadersWidth = 25
        Me.dgw_per.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_per.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_per.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_per.Size = New System.Drawing.Size(489, 87)
        Me.dgw_per.TabIndex = 15
        Me.dgw_per.TabStop = False
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
        Me.dgw_cta.Location = New System.Drawing.Point(112, 2)
        Me.dgw_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta.MultiSelect = False
        Me.dgw_cta.Name = "dgw_cta"
        Me.dgw_cta.ReadOnly = True
        Me.dgw_cta.RowHeadersWidth = 25
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta.Size = New System.Drawing.Size(389, 107)
        Me.dgw_cta.TabIndex = 55
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(179, 228)
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
        'Panel_cta
        '
        Me.Panel_cta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_cta.Controls.Add(Me.dgw_cta)
        Me.Panel_cta.Location = New System.Drawing.Point(9, 105)
        Me.Panel_cta.Name = "Panel_cta"
        Me.Panel_cta.Size = New System.Drawing.Size(524, 111)
        Me.Panel_cta.TabIndex = 64
        Me.Panel_cta.Visible = False
        '
        'Panel_per
        '
        Me.Panel_per.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_per.Controls.Add(Me.dgw_per)
        Me.Panel_per.Location = New System.Drawing.Point(9, 131)
        Me.Panel_per.Name = "Panel_per"
        Me.Panel_per.Size = New System.Drawing.Size(621, 91)
        Me.Panel_per.TabIndex = 65
        Me.Panel_per.Visible = False
        '
        'REPORTE_CTA_CTACTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 318)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel_cta)
        Me.Controls.Add(Me.Panel_per)
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_CTA_CTACTE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Cuenta / Cta. Cte."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgw_per, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb1.ResumeLayout(False)
        Me.Panel_cta.ResumeLayout(False)
        Me.Panel_per.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_archivo1 As Button
    Friend WithEvents btn_imprimir1 As Button
    Friend WithEvents btn_pantalla1 As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents CBO_MES As ComboBox
    Friend WithEvents CBO_MES2 As ComboBox
    Friend WithEvents CBO_ORDEN As ComboBox
    Friend WithEvents CH_PER As CheckBox
    Friend WithEvents dgw_cta As DataGridView
    Friend WithEvents dgw_per As DataGridView
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents KL1 As TextBox
    Friend WithEvents KL2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel_cta As Panel
    Friend WithEvents Panel_per As Panel
    Friend WithEvents txt_cod_per As TextBox
    Friend WithEvents txt_cta As TextBox
    Friend WithEvents txt_desc_cta As TextBox
    Friend WithEvents txt_desc_per As TextBox
    Friend WithEvents txt_doc_per As TextBox


End Class
