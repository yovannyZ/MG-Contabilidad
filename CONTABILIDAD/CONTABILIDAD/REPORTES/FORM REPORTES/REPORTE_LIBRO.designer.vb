Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_LIBRO
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
        Me.panel_bancos = New System.Windows.Forms.Panel
        Me.dgw_ban = New System.Windows.Forms.DataGridView
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboMes = New System.Windows.Forms.ComboBox
        Me.txt_desc_ban = New System.Windows.Forms.TextBox
        Me.kl1 = New System.Windows.Forms.TextBox
        Me.BTN_SALIR = New System.Windows.Forms.Button
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_cod_ban = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.stEstado = New System.Windows.Forms.StatusStrip
        Me.tspbExportar = New System.Windows.Forms.ToolStripProgressBar
        Me.tslblMensaje = New System.Windows.Forms.ToolStripStatusLabel
        Me.txtNroCuenta = New System.Windows.Forms.TextBox
        Me.panel_bancos.SuspendLayout()
        CType(Me.dgw_ban, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.stEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel_bancos
        '
        Me.panel_bancos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_bancos.Controls.Add(Me.dgw_ban)
        Me.panel_bancos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_bancos.Location = New System.Drawing.Point(5, 86)
        Me.panel_bancos.Name = "panel_bancos"
        Me.panel_bancos.Size = New System.Drawing.Size(523, 122)
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
        Me.dgw_ban.Location = New System.Drawing.Point(113, -1)
        Me.dgw_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_ban.MultiSelect = False
        Me.dgw_ban.Name = "dgw_ban"
        Me.dgw_ban.ReadOnly = True
        Me.dgw_ban.RowHeadersWidth = 25
        Me.dgw_ban.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_ban.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_ban.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_ban.Size = New System.Drawing.Size(401, 112)
        Me.dgw_ban.TabIndex = 0
        Me.dgw_ban.TabStop = False
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(147, 186)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(282, 66)
        Me.gb1.TabIndex = 130
        Me.gb1.TabStop = False
        '
        'btn_archivo1
        '
        Me.btn_archivo1.BackColor = System.Drawing.Color.White
        Me.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo1.Location = New System.Drawing.Point(181, 15)
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
        Me.btn_imprimir1.Location = New System.Drawing.Point(96, 15)
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
        Me.btn_pantalla1.Location = New System.Drawing.Point(10, 15)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(80, 31)
        Me.btn_pantalla1.TabIndex = 0
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNroCuenta)
        Me.GroupBox1.Controls.Add(Me.cboMes)
        Me.GroupBox1.Controls.Add(Me.txt_desc_ban)
        Me.GroupBox1.Controls.Add(Me.kl1)
        Me.GroupBox1.Controls.Add(Me.BTN_SALIR)
        Me.GroupBox1.Controls.Add(Me.cbo_año)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_cod_ban)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(573, 145)
        Me.GroupBox1.TabIndex = 129
        Me.GroupBox1.TabStop = False
        '
        'cboMes
        '
        Me.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMes.FormattingEnabled = True
        Me.cboMes.Items.AddRange(New Object() {"INICIO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.cboMes.Location = New System.Drawing.Point(104, 67)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(197, 22)
        Me.cboMes.TabIndex = 157
        '
        'txt_desc_ban
        '
        Me.txt_desc_ban.BackColor = System.Drawing.Color.White
        Me.txt_desc_ban.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_desc_ban.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_desc_ban.Location = New System.Drawing.Point(158, 44)
        Me.txt_desc_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_ban.MaxLength = 40
        Me.txt_desc_ban.Name = "txt_desc_ban"
        Me.txt_desc_ban.Size = New System.Drawing.Size(350, 20)
        Me.txt_desc_ban.TabIndex = 1
        '
        'kl1
        '
        Me.kl1.BackColor = System.Drawing.Color.White
        Me.kl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kl1.Location = New System.Drawing.Point(363, 44)
        Me.kl1.Margin = New System.Windows.Forms.Padding(0)
        Me.kl1.MaxLength = 4
        Me.kl1.Name = "kl1"
        Me.kl1.Size = New System.Drawing.Size(33, 20)
        Me.kl1.TabIndex = 2
        '
        'BTN_SALIR
        '
        Me.BTN_SALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_SALIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_SALIR.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.BTN_SALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_SALIR.Location = New System.Drawing.Point(425, 97)
        Me.BTN_SALIR.Name = "BTN_SALIR"
        Me.BTN_SALIR.Size = New System.Drawing.Size(80, 31)
        Me.BTN_SALIR.TabIndex = 5
        Me.BTN_SALIR.TabStop = False
        Me.BTN_SALIR.Text = "&Salir"
        Me.BTN_SALIR.UseVisualStyleBackColor = True
        '
        'cbo_año
        '
        Me.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año.FormattingEnabled = True
        Me.cbo_año.Location = New System.Drawing.Point(340, 67)
        Me.cbo_año.Name = "cbo_año"
        Me.cbo_año.Size = New System.Drawing.Size(79, 22)
        Me.cbo_año.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.Location = New System.Drawing.Point(307, 75)
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
        Me.Label2.Location = New System.Drawing.Point(51, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 14)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Mes"
        '
        'txt_cod_ban
        '
        Me.txt_cod_ban.BackColor = System.Drawing.Color.White
        Me.txt_cod_ban.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cod_ban.Location = New System.Drawing.Point(104, 44)
        Me.txt_cod_ban.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_ban.MaxLength = 4
        Me.txt_cod_ban.Name = "txt_cod_ban"
        Me.txt_cod_ban.Size = New System.Drawing.Size(53, 20)
        Me.txt_cod_ban.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Banco"
        '
        'stEstado
        '
        Me.stEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspbExportar, Me.tslblMensaje})
        Me.stEstado.Location = New System.Drawing.Point(0, 257)
        Me.stEstado.Name = "stEstado"
        Me.stEstado.Size = New System.Drawing.Size(609, 22)
        Me.stEstado.TabIndex = 156
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
        'txtNroCuenta
        '
        Me.txtNroCuenta.BackColor = System.Drawing.Color.White
        Me.txtNroCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroCuenta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroCuenta.Location = New System.Drawing.Point(419, 24)
        Me.txtNroCuenta.Margin = New System.Windows.Forms.Padding(0)
        Me.txtNroCuenta.MaxLength = 40
        Me.txtNroCuenta.Name = "txtNroCuenta"
        Me.txtNroCuenta.Size = New System.Drawing.Size(89, 20)
        Me.txtNroCuenta.TabIndex = 158
        Me.txtNroCuenta.Visible = False
        '
        'REPORTE_LIBRO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 279)
        Me.ControlBox = False
        Me.Controls.Add(Me.stEstado)
        Me.Controls.Add(Me.panel_bancos)
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_LIBRO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes de Libro de Bancos"
        Me.panel_bancos.ResumeLayout(False)
        CType(Me.dgw_ban, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.stEstado.ResumeLayout(False)
        Me.stEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_archivo1 As Button
    Friend WithEvents btn_imprimir1 As Button
    Friend WithEvents btn_pantalla1 As Button
    Friend WithEvents BTN_SALIR As Button
    Friend WithEvents cbo_año As ComboBox
    Friend WithEvents dgw_ban As DataGridView
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents kl1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents panel_bancos As Panel
    Friend WithEvents txt_cod_ban As TextBox
    Friend WithEvents txt_desc_ban As TextBox
    Friend WithEvents stEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tspbExportar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tslblMensaje As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cboMes As System.Windows.Forms.ComboBox
    Friend WithEvents txtNroCuenta As System.Windows.Forms.TextBox

End Class
