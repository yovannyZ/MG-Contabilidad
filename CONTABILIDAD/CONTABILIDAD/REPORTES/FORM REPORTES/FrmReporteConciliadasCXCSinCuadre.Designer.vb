<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporteConciliadasCXCSinCuadre
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.dgw_cta = New System.Windows.Forms.DataGridView
        Me.cbo_año = New System.Windows.Forms.ComboBox
        Me.cbo_mes = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.PaneL_CTA = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_desc_cta0 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_cod_cta0 = New System.Windows.Forms.TextBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.KL = New System.Windows.Forms.TextBox
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PaneL_CTA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_pantalla1
        '
        Me.btn_pantalla1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_pantalla1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_pantalla1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pantalla1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btn_pantalla1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pantalla1.Location = New System.Drawing.Point(161, 132)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(82, 33)
        Me.btn_pantalla1.TabIndex = 4
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
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
        Me.dgw_cta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgw_cta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cta.Location = New System.Drawing.Point(23, -1)
        Me.dgw_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta.MultiSelect = False
        Me.dgw_cta.Name = "dgw_cta"
        Me.dgw_cta.ReadOnly = True
        Me.dgw_cta.RowHeadersWidth = 25
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw_cta.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta.Size = New System.Drawing.Size(384, 134)
        Me.dgw_cta.TabIndex = 17
        '
        'cbo_año
        '
        Me.cbo_año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_año.FormattingEnabled = True
        Me.cbo_año.Location = New System.Drawing.Point(311, 83)
        Me.cbo_año.Name = "cbo_año"
        Me.cbo_año.Size = New System.Drawing.Size(79, 21)
        Me.cbo_año.TabIndex = 3
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"INICIO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.cbo_mes.Location = New System.Drawing.Point(151, 80)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(90, 21)
        Me.cbo_mes.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(260, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 14)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Año"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.Location = New System.Drawing.Point(118, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 14)
        Me.Label5.TabIndex = 146
        Me.Label5.Text = "Mes"
        '
        'PaneL_CTA
        '
        Me.PaneL_CTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PaneL_CTA.Controls.Add(Me.dgw_cta)
        Me.PaneL_CTA.Location = New System.Drawing.Point(97, 64)
        Me.PaneL_CTA.Name = "PaneL_CTA"
        Me.PaneL_CTA.Size = New System.Drawing.Size(419, 134)
        Me.PaneL_CTA.TabIndex = 0
        Me.PaneL_CTA.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PaneL_CTA)
        Me.GroupBox1.Controls.Add(Me.cbo_año)
        Me.GroupBox1.Controls.Add(Me.btn_pantalla1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbo_mes)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_desc_cta0)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_cod_cta0)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.KL)
        Me.GroupBox1.Location = New System.Drawing.Point(1, -16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(598, 288)
        Me.GroupBox1.TabIndex = 145
        Me.GroupBox1.TabStop = False
        '
        'txt_desc_cta0
        '
        Me.txt_desc_cta0.Location = New System.Drawing.Point(158, 42)
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
        Me.Label2.Location = New System.Drawing.Point(20, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 14)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Cuenta"
        '
        'txt_cod_cta0
        '
        Me.txt_cod_cta0.Location = New System.Drawing.Point(97, 42)
        Me.txt_cod_cta0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_cta0.MaxLength = 8
        Me.txt_cod_cta0.Name = "txt_cod_cta0"
        Me.txt_cod_cta0.Size = New System.Drawing.Size(60, 20)
        Me.txt_cod_cta0.TabIndex = 0
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(263, 132)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(82, 33)
        Me.btn_salir.TabIndex = 30
        Me.btn_salir.TabStop = False
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'KL
        '
        Me.KL.Location = New System.Drawing.Point(263, 42)
        Me.KL.Margin = New System.Windows.Forms.Padding(0)
        Me.KL.MaxLength = 8
        Me.KL.Name = "KL"
        Me.KL.Size = New System.Drawing.Size(10, 20)
        Me.KL.TabIndex = 1
        '
        'FrmReporteConciliadasCXCSinCuadre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 234)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "FrmReporteConciliadasCXCSinCuadre"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cta. por cobrar cuadre"
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PaneL_CTA.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_pantalla1 As System.Windows.Forms.Button
    Friend WithEvents dgw_cta As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_año As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PaneL_CTA As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_desc_cta0 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_cod_cta0 As System.Windows.Forms.TextBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents KL As System.Windows.Forms.TextBox
End Class
