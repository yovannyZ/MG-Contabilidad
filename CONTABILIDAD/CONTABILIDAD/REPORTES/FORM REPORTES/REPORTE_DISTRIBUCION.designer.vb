<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_DISTRIBUCION
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
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
        Me.cboNegocio = New System.Windows.Forms.ComboBox
        Me.chkNegocio = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_salir = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.PanelArea = New System.Windows.Forms.Panel
        Me.dgwArea = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.btnpantalla2 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkCentroCostos = New System.Windows.Forms.CheckBox
        Me.txtArea = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCodArea = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.cboAñoNegocio = New System.Windows.Forms.ComboBox
        Me.cboMesNegocio = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboMesCosto = New System.Windows.Forms.ComboBox
        Me.cboAñoCosto = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.gb1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.PanelArea.SuspendLayout()
        CType(Me.dgwArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btn_pantalla1)
        Me.gb1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb1.Location = New System.Drawing.Point(123, 135)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(278, 61)
        Me.gb1.TabIndex = 1
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
        Me.GroupBox1.Controls.Add(Me.cboMesNegocio)
        Me.GroupBox1.Controls.Add(Me.cboAñoNegocio)
        Me.GroupBox1.Controls.Add(Me.cboNegocio)
        Me.GroupBox1.Controls.Add(Me.chkNegocio)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(36, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(460, 93)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cboNegocio
        '
        Me.cboNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNegocio.Enabled = False
        Me.cboNegocio.FormattingEnabled = True
        Me.cboNegocio.Location = New System.Drawing.Point(151, 25)
        Me.cboNegocio.Name = "cboNegocio"
        Me.cboNegocio.Size = New System.Drawing.Size(220, 22)
        Me.cboNegocio.TabIndex = 2
        '
        'chkNegocio
        '
        Me.chkNegocio.AutoSize = True
        Me.chkNegocio.Location = New System.Drawing.Point(130, 28)
        Me.chkNegocio.Name = "chkNegocio"
        Me.chkNegocio.Size = New System.Drawing.Size(15, 14)
        Me.chkNegocio.TabIndex = 1
        Me.chkNegocio.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "U.Negocio : "
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.SystemColors.Control
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(434, 152)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(82, 33)
        Me.btn_salir.TabIndex = 2
        Me.btn_salir.TabStop = False
        Me.btn_salir.Text = "&Salir"
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(554, 250)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gb1)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.btn_salir)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(546, 224)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Unidad Negocio"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PanelArea)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(546, 224)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Centro Costos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'PanelArea
        '
        Me.PanelArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelArea.Controls.Add(Me.dgwArea)
        Me.PanelArea.Location = New System.Drawing.Point(83, 64)
        Me.PanelArea.Name = "PanelArea"
        Me.PanelArea.Size = New System.Drawing.Size(389, 116)
        Me.PanelArea.TabIndex = 1
        Me.PanelArea.Visible = False
        '
        'dgwArea
        '
        Me.dgwArea.AllowUserToAddRows = False
        Me.dgwArea.AllowUserToDeleteRows = False
        Me.dgwArea.AllowUserToOrderColumns = True
        Me.dgwArea.AllowUserToResizeRows = False
        Me.dgwArea.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwArea.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgwArea.BackgroundColor = System.Drawing.Color.White
        Me.dgwArea.Location = New System.Drawing.Point(15, -1)
        Me.dgwArea.Margin = New System.Windows.Forms.Padding(0)
        Me.dgwArea.MultiSelect = False
        Me.dgwArea.Name = "dgwArea"
        Me.dgwArea.ReadOnly = True
        Me.dgwArea.RowHeadersWidth = 25
        Me.dgwArea.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgwArea.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgwArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwArea.Size = New System.Drawing.Size(372, 115)
        Me.dgwArea.TabIndex = 0
        Me.dgwArea.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.btnpantalla2)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(142, 148)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(278, 61)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(186, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 33)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "&Archivo"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(98, 17)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(82, 33)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "&Imprimir"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnpantalla2
        '
        Me.btnpantalla2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnpantalla2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpantalla2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btnpantalla2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnpantalla2.Location = New System.Drawing.Point(10, 17)
        Me.btnpantalla2.Name = "btnpantalla2"
        Me.btnpantalla2.Size = New System.Drawing.Size(82, 33)
        Me.btnpantalla2.TabIndex = 0
        Me.btnpantalla2.Text = "&Pantalla"
        Me.btnpantalla2.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboMesCosto)
        Me.GroupBox3.Controls.Add(Me.cboAñoCosto)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.chkCentroCostos)
        Me.GroupBox3.Controls.Add(Me.txtArea)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtCodArea)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(11, 18)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(517, 110)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'chkCentroCostos
        '
        Me.chkCentroCostos.AutoSize = True
        Me.chkCentroCostos.Location = New System.Drawing.Point(69, 30)
        Me.chkCentroCostos.Name = "chkCentroCostos"
        Me.chkCentroCostos.Size = New System.Drawing.Size(15, 14)
        Me.chkCentroCostos.TabIndex = 1
        Me.chkCentroCostos.UseVisualStyleBackColor = True
        '
        'txtArea
        '
        Me.txtArea.Enabled = False
        Me.txtArea.Location = New System.Drawing.Point(148, 26)
        Me.txtArea.Margin = New System.Windows.Forms.Padding(0)
        Me.txtArea.MaxLength = 40
        Me.txtArea.Name = "txtArea"
        Me.txtArea.Size = New System.Drawing.Size(312, 20)
        Me.txtArea.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CCostos:"
        '
        'txtCodArea
        '
        Me.txtCodArea.Enabled = False
        Me.txtCodArea.Location = New System.Drawing.Point(87, 26)
        Me.txtCodArea.Margin = New System.Windows.Forms.Padding(0)
        Me.txtCodArea.MaxLength = 8
        Me.txtCodArea.Name = "txtCodArea"
        Me.txtCodArea.Size = New System.Drawing.Size(60, 20)
        Me.txtCodArea.TabIndex = 2
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.Location = New System.Drawing.Point(437, 167)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(82, 33)
        Me.Button3.TabIndex = 3
        Me.Button3.TabStop = False
        Me.Button3.Text = "&Salir"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'cboAñoNegocio
        '
        Me.cboAñoNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAñoNegocio.FormattingEnabled = True
        Me.cboAñoNegocio.Location = New System.Drawing.Point(122, 60)
        Me.cboAñoNegocio.Name = "cboAñoNegocio"
        Me.cboAñoNegocio.Size = New System.Drawing.Size(94, 22)
        Me.cboAñoNegocio.TabIndex = 4
        '
        'cboMesNegocio
        '
        Me.cboMesNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesNegocio.FormattingEnabled = True
        Me.cboMesNegocio.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboMesNegocio.Location = New System.Drawing.Point(313, 60)
        Me.cboMesNegocio.Name = "cboMesNegocio"
        Me.cboMesNegocio.Size = New System.Drawing.Size(126, 22)
        Me.cboMesNegocio.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(42, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Año : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(251, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 14)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Mes : "
        '
        'cboMesCosto
        '
        Me.cboMesCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCosto.FormattingEnabled = True
        Me.cboMesCosto.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboMesCosto.Location = New System.Drawing.Point(332, 66)
        Me.cboMesCosto.Name = "cboMesCosto"
        Me.cboMesCosto.Size = New System.Drawing.Size(126, 22)
        Me.cboMesCosto.TabIndex = 7
        '
        'cboAñoCosto
        '
        Me.cboAñoCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAñoCosto.FormattingEnabled = True
        Me.cboAñoCosto.Location = New System.Drawing.Point(141, 66)
        Me.cboAñoCosto.Name = "cboAñoCosto"
        Me.cboAñoCosto.Size = New System.Drawing.Size(94, 22)
        Me.cboAñoCosto.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(270, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 14)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Mes : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(61, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 14)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Año : "
        '
        'REPORTE_DISTRIBUCION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 250)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "REPORTE_DISTRIBUCION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Distribución"
        Me.gb1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.PanelArea.ResumeLayout(False)
        CType(Me.dgwArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_archivo1 As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir1 As System.Windows.Forms.Button
    Friend WithEvents btn_pantalla1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkNegocio As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents cboNegocio As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnpantalla2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCentroCostos As System.Windows.Forms.CheckBox
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanelArea As System.Windows.Forms.Panel
    Friend WithEvents dgwArea As System.Windows.Forms.DataGridView
    Friend WithEvents txtCodArea As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cboMesNegocio As System.Windows.Forms.ComboBox
    Friend WithEvents cboAñoNegocio As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboMesCosto As System.Windows.Forms.ComboBox
    Friend WithEvents cboAñoCosto As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
