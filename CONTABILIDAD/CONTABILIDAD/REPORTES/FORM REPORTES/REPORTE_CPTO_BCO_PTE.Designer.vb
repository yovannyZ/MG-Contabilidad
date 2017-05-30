Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_CPTO_BCO_PTE
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
        Me.panel_cta = New System.Windows.Forms.Panel
        Me.dgw_cta = New System.Windows.Forms.DataGridView
        Me.panel_bancos = New System.Windows.Forms.Panel
        Me.dgw_ban = New System.Windows.Forms.DataGridView
        Me.txt_desc_cta = New System.Windows.Forms.TextBox
        Me.k1 = New System.Windows.Forms.TextBox
        Me.txt_cod_cta = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt_desc_ban = New System.Windows.Forms.TextBox
        Me.KL1 = New System.Windows.Forms.TextBox
        Me.dtp_al = New System.Windows.Forms.DateTimePicker
        Me.BTN_SALIR = New System.Windows.Forms.Button
        Me.dtp_del = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_cod_ban = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.panel_cta.SuspendLayout()
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_bancos.SuspendLayout()
        CType(Me.dgw_ban, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.panel_cta)
        Me.GroupBox1.Controls.Add(Me.panel_bancos)
        Me.GroupBox1.Controls.Add(Me.txt_desc_cta)
        Me.GroupBox1.Controls.Add(Me.k1)
        Me.GroupBox1.Controls.Add(Me.txt_cod_cta)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txt_desc_ban)
        Me.GroupBox1.Controls.Add(Me.KL1)
        Me.GroupBox1.Controls.Add(Me.dtp_al)
        Me.GroupBox1.Controls.Add(Me.BTN_SALIR)
        Me.GroupBox1.Controls.Add(Me.dtp_del)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_cod_ban)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(571, 198)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'panel_cta
        '
        Me.panel_cta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_cta.Controls.Add(Me.dgw_cta)
        Me.panel_cta.Location = New System.Drawing.Point(22, 45)
        Me.panel_cta.Name = "panel_cta"
        Me.panel_cta.Size = New System.Drawing.Size(518, 114)
        Me.panel_cta.TabIndex = 140
        Me.panel_cta.Visible = False
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
        Me.dgw_cta.Location = New System.Drawing.Point(114, 2)
        Me.dgw_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta.MultiSelect = False
        Me.dgw_cta.Name = "dgw_cta"
        Me.dgw_cta.ReadOnly = True
        Me.dgw_cta.RowHeadersWidth = 25
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta.Size = New System.Drawing.Size(396, 101)
        Me.dgw_cta.TabIndex = 90
        Me.dgw_cta.TabStop = False
        '
        'panel_bancos
        '
        Me.panel_bancos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_bancos.Controls.Add(Me.dgw_ban)
        Me.panel_bancos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_bancos.Location = New System.Drawing.Point(22, 78)
        Me.panel_bancos.Name = "panel_bancos"
        Me.panel_bancos.Size = New System.Drawing.Size(518, 105)
        Me.panel_bancos.TabIndex = 0
        Me.panel_bancos.Visible = False
        '
        'dgw_ban
        '
        Me.dgw_ban.AllowUserToAddRows = False
        Me.dgw_ban.AllowUserToDeleteRows = False
        Me.dgw_ban.AllowUserToOrderColumns = True
        Me.dgw_ban.AllowUserToResizeRows = False
        Me.dgw_ban.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgw_ban.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgw_ban.BackgroundColor = System.Drawing.Color.White
        Me.dgw_ban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_ban.Location = New System.Drawing.Point(114, 2)
        Me.dgw_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_ban.MultiSelect = False
        Me.dgw_ban.Name = "dgw_ban"
        Me.dgw_ban.ReadOnly = True
        Me.dgw_ban.RowHeadersWidth = 25
        Me.dgw_ban.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_ban.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_ban.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_ban.Size = New System.Drawing.Size(396, 95)
        Me.dgw_ban.TabIndex = 0
        Me.dgw_ban.TabStop = False
        '
        'txt_desc_cta
        '
        Me.txt_desc_cta.BackColor = System.Drawing.Color.White
        Me.txt_desc_cta.Location = New System.Drawing.Point(186, 25)
        Me.txt_desc_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_cta.MaxLength = 40
        Me.txt_desc_cta.Name = "txt_desc_cta"
        Me.txt_desc_cta.Size = New System.Drawing.Size(347, 20)
        Me.txt_desc_cta.TabIndex = 2
        '
        'k1
        '
        Me.k1.Location = New System.Drawing.Point(282, 25)
        Me.k1.Name = "k1"
        Me.k1.Size = New System.Drawing.Size(10, 20)
        Me.k1.TabIndex = 3
        '
        'txt_cod_cta
        '
        Me.txt_cod_cta.BackColor = System.Drawing.Color.White
        Me.txt_cod_cta.Location = New System.Drawing.Point(137, 25)
        Me.txt_cod_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_cta.MaxLength = 5
        Me.txt_cod_cta.Name = "txt_cod_cta"
        Me.txt_cod_cta.Size = New System.Drawing.Size(45, 20)
        Me.txt_cod_cta.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(48, 28)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 14)
        Me.Label16.TabIndex = 143
        Me.Label16.Text = "Concepto"
        '
        'txt_desc_ban
        '
        Me.txt_desc_ban.BackColor = System.Drawing.Color.White
        Me.txt_desc_ban.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_desc_ban.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_ban.Location = New System.Drawing.Point(186, 55)
        Me.txt_desc_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_ban.MaxLength = 40
        Me.txt_desc_ban.Name = "txt_desc_ban"
        Me.txt_desc_ban.Size = New System.Drawing.Size(347, 20)
        Me.txt_desc_ban.TabIndex = 5
        '
        'KL1
        '
        Me.KL1.Location = New System.Drawing.Point(359, 55)
        Me.KL1.Name = "KL1"
        Me.KL1.Size = New System.Drawing.Size(16, 20)
        Me.KL1.TabIndex = 6
        '
        'dtp_al
        '
        Me.dtp_al.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_al.Location = New System.Drawing.Point(267, 88)
        Me.dtp_al.Name = "dtp_al"
        Me.dtp_al.Size = New System.Drawing.Size(83, 20)
        Me.dtp_al.TabIndex = 8
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_SALIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_SALIR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.Location = New System.Drawing.Point(453, 128)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(80, 31)
        Me.BTN_SALIR.TabIndex = 9
        Me.BTN_SALIR.TabStop = False
        Me.BTN_SALIR.Text = "&Salir"
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'dtp_del
        '
        Me.dtp_del.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_del.Location = New System.Drawing.Point(137, 88)
        Me.dtp_del.Name = "dtp_del"
        Me.dtp_del.Size = New System.Drawing.Size(83, 20)
        Me.dtp_del.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(234, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 14)
        Me.Label3.TabIndex = 138
        Me.Label3.Text = "Al"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 14)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Del"
        '
        'txt_cod_ban
        '
        Me.txt_cod_ban.BackColor = System.Drawing.Color.White
        Me.txt_cod_ban.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_ban.Location = New System.Drawing.Point(137, 55)
        Me.txt_cod_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_ban.MaxLength = 4
        Me.txt_cod_ban.Name = "txt_cod_ban"
        Me.txt_cod_ban.Size = New System.Drawing.Size(45, 20)
        Me.txt_cod_ban.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Banco"
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(133, 237)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(326, 65)
        Me.gb1.TabIndex = 138
        Me.gb1.TabStop = False
        '
        'btn_archivo1
        '
        Me.btn_archivo1.BackColor = System.Drawing.Color.White
        Me.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo1.Location = New System.Drawing.Point(198, 19)
        Me.btn_archivo1.Name = "btn_archivo1"
        Me.btn_archivo1.Size = New System.Drawing.Size(80, 31)
        Me.btn_archivo1.TabIndex = 2
        Me.btn_archivo1.Text = "&Archivo"
        Me.btn_archivo1.UseVisualStyleBackColor = False
        '
        'btn_imprimir1
        '
        Me.btn_imprimir1.BackColor = System.Drawing.Color.White
        Me.btn_imprimir1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprimir1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.btn_imprimir1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir1.Location = New System.Drawing.Point(112, 19)
        Me.btn_imprimir1.Name = "btn_imprimir1"
        Me.btn_imprimir1.Size = New System.Drawing.Size(80, 31)
        Me.btn_imprimir1.TabIndex = 1
        Me.btn_imprimir1.Text = "&Imprimir"
        Me.btn_imprimir1.UseVisualStyleBackColor = False
        '
        'btn_pantalla1
        '
        Me.btn_pantalla1.BackColor = System.Drawing.Color.White
        Me.btn_pantalla1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla1.Location = New System.Drawing.Point(26, 19)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(80, 31)
        Me.btn_pantalla1.TabIndex = 0
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'REPORTE_CPTO_BCO_PTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 326)
        Me.ControlBox = False
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_CPTO_BCO_PTE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Concepto (Bancos) Pendientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.panel_cta.ResumeLayout(False)
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_bancos.ResumeLayout(False)
        CType(Me.dgw_ban, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_archivo1 As Button
    Friend WithEvents btn_imprimir1 As Button
    Friend WithEvents btn_pantalla1 As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents dgw_ban As DataGridView
    Friend WithEvents dgw_cta As DataGridView
    Friend WithEvents dtp_al As DateTimePicker
    Friend WithEvents dtp_del As DateTimePicker
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents k1 As TextBox
    Friend WithEvents KL1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents panel_bancos As Panel
    Friend WithEvents panel_cta As Panel
    Friend WithEvents txt_cod_ban As TextBox
    Friend WithEvents txt_cod_cta As TextBox
    Friend WithEvents txt_desc_ban As TextBox
    Friend WithEvents txt_desc_cta As TextBox


End Class
