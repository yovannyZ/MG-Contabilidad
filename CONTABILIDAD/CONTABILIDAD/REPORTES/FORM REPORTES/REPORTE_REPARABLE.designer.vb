Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_REPARABLE
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
        Me.PaneL_CTA = New System.Windows.Forms.Panel
        Me.dgw_cta = New System.Windows.Forms.DataGridView
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.btn_archivo1 = New System.Windows.Forms.Button
        Me.btn_imprimir1 = New System.Windows.Forms.Button
        Me.btn_pantalla1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ch_cta = New System.Windows.Forms.CheckBox
        Me.txt_desc_cta0 = New System.Windows.Forms.TextBox
        Me.KL = New System.Windows.Forms.TextBox
        Me.btn_salir = New System.Windows.Forms.Button
        Me.CBO_MES2 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBO_MES = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_cod_cta0 = New System.Windows.Forms.TextBox
        Me.PaneL_CTA.SuspendLayout()
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PaneL_CTA
        '
        Me.PaneL_CTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PaneL_CTA.Controls.Add(Me.dgw_cta)
        Me.PaneL_CTA.Location = New System.Drawing.Point(110, 105)
        Me.PaneL_CTA.Name = "PaneL_CTA"
        Me.PaneL_CTA.Size = New System.Drawing.Size(420, 124)
        Me.PaneL_CTA.TabIndex = 21
        Me.PaneL_CTA.Visible = False
        '
        'dgw_cta
        '
        Me.dgw_cta.AllowUserToAddRows = False
        Me.dgw_cta.AllowUserToDeleteRows = False
        Me.dgw_cta.AllowUserToOrderColumns = True
        Me.dgw_cta.AllowUserToResizeRows = False
        Me.dgw_cta.BackgroundColor = System.Drawing.Color.White
        Me.dgw_cta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgw_cta.Location = New System.Drawing.Point(2, -1)
        Me.dgw_cta.Margin = New System.Windows.Forms.Padding(0)
        Me.dgw_cta.MultiSelect = False
        Me.dgw_cta.Name = "dgw_cta"
        Me.dgw_cta.ReadOnly = True
        Me.dgw_cta.RowHeadersWidth = 25
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.dgw_cta.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgw_cta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgw_cta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw_cta.Size = New System.Drawing.Size(409, 120)
        Me.dgw_cta.TabIndex = 17
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Location = New System.Drawing.Point(144, 213)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(270, 48)
        Me.gb1.TabIndex = 20
        Me.gb1.TabStop = False
        '
        'btn_archivo1
        '
        Me.btn_archivo1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_archivo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archivo1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btn_archivo1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_archivo1.Location = New System.Drawing.Point(182, 10)
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
        Me.btn_imprimir1.Location = New System.Drawing.Point(94, 10)
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
        Me.btn_pantalla1.Location = New System.Drawing.Point(6, 10)
        Me.btn_pantalla1.Name = "btn_pantalla1"
        Me.btn_pantalla1.Size = New System.Drawing.Size(82, 33)
        Me.btn_pantalla1.TabIndex = 0
        Me.btn_pantalla1.Text = "&Pantalla"
        Me.btn_pantalla1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ch_cta)
        Me.GroupBox1.Controls.Add(Me.txt_desc_cta0)
        Me.GroupBox1.Controls.Add(Me.KL)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.CBO_MES2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CBO_MES)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_cod_cta0)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(29, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(493, 149)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'ch_cta
        '
        Me.ch_cta.AutoSize = True
        Me.ch_cta.Checked = True
        Me.ch_cta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch_cta.Location = New System.Drawing.Point(63, 59)
        Me.ch_cta.Name = "ch_cta"
        Me.ch_cta.Size = New System.Drawing.Size(15, 14)
        Me.ch_cta.TabIndex = 24
        Me.ch_cta.UseVisualStyleBackColor = True
        '
        'txt_desc_cta0
        '
        Me.txt_desc_cta0.BackColor = System.Drawing.Color.White
        Me.txt_desc_cta0.Location = New System.Drawing.Point(142, 55)
        Me.txt_desc_cta0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_desc_cta0.MaxLength = 40
        Me.txt_desc_cta0.Name = "txt_desc_cta0"
        Me.txt_desc_cta0.Size = New System.Drawing.Size(335, 20)
        Me.txt_desc_cta0.TabIndex = 2
        '
        'KL
        '
        Me.KL.Location = New System.Drawing.Point(336, 55)
        Me.KL.Margin = New System.Windows.Forms.Padding(0)
        Me.KL.MaxLength = 8
        Me.KL.Name = "KL"
        Me.KL.Size = New System.Drawing.Size(10, 20)
        Me.KL.TabIndex = 3
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.SystemColors.Control
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(395, 90)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(82, 33)
        Me.btn_salir.TabIndex = 23
        Me.btn_salir.TabStop = False
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'CBO_MES2
        '
        Me.CBO_MES2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_MES2.FormattingEnabled = True
        Me.CBO_MES2.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.CBO_MES2.Location = New System.Drawing.Point(213, 87)
        Me.CBO_MES2.Name = "CBO_MES2"
        Me.CBO_MES2.Size = New System.Drawing.Size(92, 22)
        Me.CBO_MES2.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(184, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 14)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Al"
        '
        'CBO_MES
        '
        Me.CBO_MES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_MES.FormattingEnabled = True
        Me.CBO_MES.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.CBO_MES.Location = New System.Drawing.Point(81, 87)
        Me.CBO_MES.Name = "CBO_MES"
        Me.CBO_MES.Size = New System.Drawing.Size(92, 22)
        Me.CBO_MES.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(48, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 14)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Del"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 14)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Cuenta"
        '
        'txt_cod_cta0
        '
        Me.txt_cod_cta0.BackColor = System.Drawing.Color.White
        Me.txt_cod_cta0.Location = New System.Drawing.Point(81, 55)
        Me.txt_cod_cta0.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_cod_cta0.MaxLength = 8
        Me.txt_cod_cta0.Name = "txt_cod_cta0"
        Me.txt_cod_cta0.Size = New System.Drawing.Size(60, 20)
        Me.txt_cod_cta0.TabIndex = 1
        '
        'REPORTE_REPARABLE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 290)
        Me.ControlBox = False
        Me.Controls.Add(Me.PaneL_CTA)
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "REPORTE_REPARABLE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Gastos Reparables"
        Me.PaneL_CTA.ResumeLayout(False)
        CType(Me.dgw_cta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_archivo1 As Button
    Friend WithEvents btn_imprimir1 As Button
    Friend WithEvents btn_pantalla1 As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents CBO_MES As ComboBox
    Friend WithEvents ch_cta As CheckBox
    Friend WithEvents dgw_cta As DataGridView
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents KL As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PaneL_CTA As Panel
    Friend WithEvents txt_cod_cta0 As TextBox
    Friend WithEvents txt_desc_cta0 As TextBox
    Friend WithEvents CBO_MES2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
