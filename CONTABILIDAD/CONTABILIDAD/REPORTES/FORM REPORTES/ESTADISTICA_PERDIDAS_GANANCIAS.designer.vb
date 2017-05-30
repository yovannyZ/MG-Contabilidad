Imports System.ComponentModel
Imports System.Drawing.Point
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ESTADISTICA_PERDIDAS_GANANCIAS
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
        Me.btnPantallaUnidad = New System.Windows.Forms.Button
        Me.stEstado = New System.Windows.Forms.StatusStrip
        Me.tspbExportar = New System.Windows.Forms.ToolStripProgressBar
        Me.tslblMensaje = New System.Windows.Forms.ToolStripStatusLabel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btnSalirUnidadNegocio = New System.Windows.Forms.Button
        Me.gbUnidadNegocio = New System.Windows.Forms.GroupBox
        Me.chkUnidadNegocio = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboUnidadNegocio = New System.Windows.Forms.ComboBox
        Me.cboAñoUnidadNegocio = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboMesUnidadNegocio = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btnSalirCentroCostos = New System.Windows.Forms.Button
        Me.gbCentroCostos = New System.Windows.Forms.GroupBox
        Me.chkCentroCostos = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboCentroCostos = New System.Windows.Forms.ComboBox
        Me.cboAñoCentroCostos = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboMesCentroCostos = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnExcelCC = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.btnPantallaCentroCostos = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.btnSalirZona = New System.Windows.Forms.Button
        Me.gbZona = New System.Windows.Forms.GroupBox
        Me.chkZona = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboZona = New System.Windows.Forms.ComboBox
        Me.cboAñoZona = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboMesZona = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.btnPantallaZona = New System.Windows.Forms.Button
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.btnSalirGeneral = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.btnPantallaGeneral = New System.Windows.Forms.Button
        Me.gbGeneral = New System.Windows.Forms.GroupBox
        Me.cboAñoGeneral = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboMesGeneral = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.gb1.SuspendLayout()
        Me.stEstado.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gbUnidadNegocio.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.gbCentroCostos.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.gbZona.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.Controls.Add(Me.btn_archivo1)
        Me.gb1.Controls.Add(Me.btn_imprimir1)
        Me.gb1.Controls.Add(Me.btnPantallaUnidad)
        Me.gb1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb1.Location = New System.Drawing.Point(157, 177)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(278, 61)
        Me.gb1.TabIndex = 2
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
        'btnPantallaUnidad
        '
        Me.btnPantallaUnidad.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPantallaUnidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPantallaUnidad.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btnPantallaUnidad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPantallaUnidad.Location = New System.Drawing.Point(10, 17)
        Me.btnPantallaUnidad.Name = "btnPantallaUnidad"
        Me.btnPantallaUnidad.Size = New System.Drawing.Size(82, 33)
        Me.btnPantallaUnidad.TabIndex = 0
        Me.btnPantallaUnidad.Text = "&Pantalla"
        Me.btnPantallaUnidad.UseVisualStyleBackColor = False
        '
        'stEstado
        '
        Me.stEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspbExportar, Me.tslblMensaje})
        Me.stEstado.Location = New System.Drawing.Point(0, 271)
        Me.stEstado.Name = "stEstado"
        Me.stEstado.Size = New System.Drawing.Size(576, 22)
        Me.stEstado.TabIndex = 154
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
        Me.tslblMensaje.Size = New System.Drawing.Size(109, 17)
        Me.tslblMensaje.Text = "Generando Archivo"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(600, 315)
        Me.TabControl1.TabIndex = 155
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnSalirUnidadNegocio)
        Me.TabPage1.Controls.Add(Me.gbUnidadNegocio)
        Me.TabPage1.Controls.Add(Me.gb1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(592, 288)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Unidad Negocio"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnSalirUnidadNegocio
        '
        Me.btnSalirUnidadNegocio.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSalirUnidadNegocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalirUnidadNegocio.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btnSalirUnidadNegocio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalirUnidadNegocio.Location = New System.Drawing.Point(453, 194)
        Me.btnSalirUnidadNegocio.Name = "btnSalirUnidadNegocio"
        Me.btnSalirUnidadNegocio.Size = New System.Drawing.Size(82, 33)
        Me.btnSalirUnidadNegocio.TabIndex = 2
        Me.btnSalirUnidadNegocio.Text = "&Salir"
        Me.btnSalirUnidadNegocio.UseVisualStyleBackColor = False
        '
        'gbUnidadNegocio
        '
        Me.gbUnidadNegocio.Controls.Add(Me.chkUnidadNegocio)
        Me.gbUnidadNegocio.Controls.Add(Me.Label3)
        Me.gbUnidadNegocio.Controls.Add(Me.cboUnidadNegocio)
        Me.gbUnidadNegocio.Controls.Add(Me.cboAñoUnidadNegocio)
        Me.gbUnidadNegocio.Controls.Add(Me.Label1)
        Me.gbUnidadNegocio.Controls.Add(Me.cboMesUnidadNegocio)
        Me.gbUnidadNegocio.Controls.Add(Me.Label2)
        Me.gbUnidadNegocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbUnidadNegocio.Location = New System.Drawing.Point(60, 61)
        Me.gbUnidadNegocio.Name = "gbUnidadNegocio"
        Me.gbUnidadNegocio.Size = New System.Drawing.Size(453, 88)
        Me.gbUnidadNegocio.TabIndex = 3
        Me.gbUnidadNegocio.TabStop = False
        '
        'chkUnidadNegocio
        '
        Me.chkUnidadNegocio.AutoSize = True
        Me.chkUnidadNegocio.Location = New System.Drawing.Point(143, 23)
        Me.chkUnidadNegocio.Name = "chkUnidadNegocio"
        Me.chkUnidadNegocio.Size = New System.Drawing.Size(15, 14)
        Me.chkUnidadNegocio.TabIndex = 3
        Me.chkUnidadNegocio.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 14)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Unidad Negocio :"
        '
        'cboUnidadNegocio
        '
        Me.cboUnidadNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidadNegocio.Enabled = False
        Me.cboUnidadNegocio.FormattingEnabled = True
        Me.cboUnidadNegocio.Location = New System.Drawing.Point(164, 19)
        Me.cboUnidadNegocio.Name = "cboUnidadNegocio"
        Me.cboUnidadNegocio.Size = New System.Drawing.Size(121, 22)
        Me.cboUnidadNegocio.TabIndex = 1
        '
        'cboAñoUnidadNegocio
        '
        Me.cboAñoUnidadNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAñoUnidadNegocio.FormattingEnabled = True
        Me.cboAñoUnidadNegocio.Location = New System.Drawing.Point(302, 50)
        Me.cboAñoUnidadNegocio.Name = "cboAñoUnidadNegocio"
        Me.cboAñoUnidadNegocio.Size = New System.Drawing.Size(121, 22)
        Me.cboAñoUnidadNegocio.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(245, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Año :"
        '
        'cboMesUnidadNegocio
        '
        Me.cboMesUnidadNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesUnidadNegocio.FormattingEnabled = True
        Me.cboMesUnidadNegocio.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboMesUnidadNegocio.Location = New System.Drawing.Point(75, 50)
        Me.cboMesUnidadNegocio.Name = "cboMesUnidadNegocio"
        Me.cboMesUnidadNegocio.Size = New System.Drawing.Size(121, 22)
        Me.cboMesUnidadNegocio.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Al Mes :"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnSalirCentroCostos)
        Me.TabPage2.Controls.Add(Me.gbCentroCostos)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(592, 288)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Centro Costos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnSalirCentroCostos
        '
        Me.btnSalirCentroCostos.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSalirCentroCostos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalirCentroCostos.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btnSalirCentroCostos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalirCentroCostos.Location = New System.Drawing.Point(454, 178)
        Me.btnSalirCentroCostos.Name = "btnSalirCentroCostos"
        Me.btnSalirCentroCostos.Size = New System.Drawing.Size(82, 33)
        Me.btnSalirCentroCostos.TabIndex = 6
        Me.btnSalirCentroCostos.Text = "&Salir"
        Me.btnSalirCentroCostos.UseVisualStyleBackColor = False
        '
        'gbCentroCostos
        '
        Me.gbCentroCostos.Controls.Add(Me.chkCentroCostos)
        Me.gbCentroCostos.Controls.Add(Me.Label4)
        Me.gbCentroCostos.Controls.Add(Me.cboCentroCostos)
        Me.gbCentroCostos.Controls.Add(Me.cboAñoCentroCostos)
        Me.gbCentroCostos.Controls.Add(Me.Label5)
        Me.gbCentroCostos.Controls.Add(Me.cboMesCentroCostos)
        Me.gbCentroCostos.Controls.Add(Me.Label6)
        Me.gbCentroCostos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbCentroCostos.Location = New System.Drawing.Point(58, 45)
        Me.gbCentroCostos.Name = "gbCentroCostos"
        Me.gbCentroCostos.Size = New System.Drawing.Size(453, 88)
        Me.gbCentroCostos.TabIndex = 5
        Me.gbCentroCostos.TabStop = False
        '
        'chkCentroCostos
        '
        Me.chkCentroCostos.AutoSize = True
        Me.chkCentroCostos.Location = New System.Drawing.Point(136, 23)
        Me.chkCentroCostos.Name = "chkCentroCostos"
        Me.chkCentroCostos.Size = New System.Drawing.Size(15, 14)
        Me.chkCentroCostos.TabIndex = 3
        Me.chkCentroCostos.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 14)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Centro Costos :"
        '
        'cboCentroCostos
        '
        Me.cboCentroCostos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentroCostos.Enabled = False
        Me.cboCentroCostos.FormattingEnabled = True
        Me.cboCentroCostos.Location = New System.Drawing.Point(157, 19)
        Me.cboCentroCostos.Name = "cboCentroCostos"
        Me.cboCentroCostos.Size = New System.Drawing.Size(266, 22)
        Me.cboCentroCostos.TabIndex = 1
        '
        'cboAñoCentroCostos
        '
        Me.cboAñoCentroCostos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAñoCentroCostos.FormattingEnabled = True
        Me.cboAñoCentroCostos.Location = New System.Drawing.Point(302, 50)
        Me.cboAñoCentroCostos.Name = "cboAñoCentroCostos"
        Me.cboAñoCentroCostos.Size = New System.Drawing.Size(121, 22)
        Me.cboAñoCentroCostos.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(245, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 14)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Año :"
        '
        'cboMesCentroCostos
        '
        Me.cboMesCentroCostos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCentroCostos.FormattingEnabled = True
        Me.cboMesCentroCostos.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboMesCentroCostos.Location = New System.Drawing.Point(75, 50)
        Me.cboMesCentroCostos.Name = "cboMesCentroCostos"
        Me.cboMesCentroCostos.Size = New System.Drawing.Size(121, 22)
        Me.cboMesCentroCostos.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 14)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Al Mes :"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.btnExcelCC)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.btnPantallaCentroCostos)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(155, 161)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(278, 61)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'btnExcelCC
        '
        Me.btnExcelCC.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExcelCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelCC.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.btnExcelCC.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelCC.Location = New System.Drawing.Point(186, 17)
        Me.btnExcelCC.Name = "btnExcelCC"
        Me.btnExcelCC.Size = New System.Drawing.Size(82, 33)
        Me.btnExcelCC.TabIndex = 2
        Me.btnExcelCC.Text = "&Archivo"
        Me.btnExcelCC.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.Location = New System.Drawing.Point(98, 17)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(82, 33)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "&Imprimir"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'btnPantallaCentroCostos
        '
        Me.btnPantallaCentroCostos.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPantallaCentroCostos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPantallaCentroCostos.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btnPantallaCentroCostos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPantallaCentroCostos.Location = New System.Drawing.Point(10, 17)
        Me.btnPantallaCentroCostos.Name = "btnPantallaCentroCostos"
        Me.btnPantallaCentroCostos.Size = New System.Drawing.Size(82, 33)
        Me.btnPantallaCentroCostos.TabIndex = 0
        Me.btnPantallaCentroCostos.Text = "&Pantalla"
        Me.btnPantallaCentroCostos.UseVisualStyleBackColor = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnSalirZona)
        Me.TabPage3.Controls.Add(Me.gbZona)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(592, 288)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Zonas"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnSalirZona
        '
        Me.btnSalirZona.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSalirZona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalirZona.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btnSalirZona.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalirZona.Location = New System.Drawing.Point(448, 178)
        Me.btnSalirZona.Name = "btnSalirZona"
        Me.btnSalirZona.Size = New System.Drawing.Size(82, 33)
        Me.btnSalirZona.TabIndex = 8
        Me.btnSalirZona.Text = "&Salir"
        Me.btnSalirZona.UseVisualStyleBackColor = False
        '
        'gbZona
        '
        Me.gbZona.Controls.Add(Me.chkZona)
        Me.gbZona.Controls.Add(Me.Label7)
        Me.gbZona.Controls.Add(Me.cboZona)
        Me.gbZona.Controls.Add(Me.cboAñoZona)
        Me.gbZona.Controls.Add(Me.Label8)
        Me.gbZona.Controls.Add(Me.cboMesZona)
        Me.gbZona.Controls.Add(Me.Label9)
        Me.gbZona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbZona.Location = New System.Drawing.Point(58, 45)
        Me.gbZona.Name = "gbZona"
        Me.gbZona.Size = New System.Drawing.Size(453, 88)
        Me.gbZona.TabIndex = 7
        Me.gbZona.TabStop = False
        '
        'chkZona
        '
        Me.chkZona.AutoSize = True
        Me.chkZona.Location = New System.Drawing.Point(143, 23)
        Me.chkZona.Name = "chkZona"
        Me.chkZona.Size = New System.Drawing.Size(15, 14)
        Me.chkZona.TabIndex = 3
        Me.chkZona.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Zona :"
        '
        'cboZona
        '
        Me.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZona.Enabled = False
        Me.cboZona.FormattingEnabled = True
        Me.cboZona.Location = New System.Drawing.Point(164, 19)
        Me.cboZona.Name = "cboZona"
        Me.cboZona.Size = New System.Drawing.Size(121, 22)
        Me.cboZona.TabIndex = 1
        '
        'cboAñoZona
        '
        Me.cboAñoZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAñoZona.FormattingEnabled = True
        Me.cboAñoZona.Location = New System.Drawing.Point(302, 50)
        Me.cboAñoZona.Name = "cboAñoZona"
        Me.cboAñoZona.Size = New System.Drawing.Size(121, 22)
        Me.cboAñoZona.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(245, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 14)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Año :"
        '
        'cboMesZona
        '
        Me.cboMesZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesZona.FormattingEnabled = True
        Me.cboMesZona.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboMesZona.Location = New System.Drawing.Point(75, 50)
        Me.cboMesZona.Name = "cboMesZona"
        Me.cboMesZona.Size = New System.Drawing.Size(121, 22)
        Me.cboMesZona.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 14)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Al Mes :"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.Button6)
        Me.GroupBox4.Controls.Add(Me.Button7)
        Me.GroupBox4.Controls.Add(Me.btnPantallaZona)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(155, 161)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(278, 61)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_1
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.Location = New System.Drawing.Point(186, 17)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(82, 33)
        Me.Button6.TabIndex = 2
        Me.Button6.Text = "&Archivo"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.Location = New System.Drawing.Point(98, 17)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(82, 33)
        Me.Button7.TabIndex = 1
        Me.Button7.Text = "&Imprimir"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'btnPantallaZona
        '
        Me.btnPantallaZona.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPantallaZona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPantallaZona.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btnPantallaZona.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPantallaZona.Location = New System.Drawing.Point(10, 17)
        Me.btnPantallaZona.Name = "btnPantallaZona"
        Me.btnPantallaZona.Size = New System.Drawing.Size(82, 33)
        Me.btnPantallaZona.TabIndex = 0
        Me.btnPantallaZona.Text = "&Pantalla"
        Me.btnPantallaZona.UseVisualStyleBackColor = False
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.btnSalirGeneral)
        Me.TabPage4.Controls.Add(Me.GroupBox1)
        Me.TabPage4.Controls.Add(Me.gbGeneral)
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(592, 288)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "General"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'btnSalirGeneral
        '
        Me.btnSalirGeneral.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSalirGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalirGeneral.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btnSalirGeneral.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalirGeneral.Location = New System.Drawing.Point(430, 177)
        Me.btnSalirGeneral.Name = "btnSalirGeneral"
        Me.btnSalirGeneral.Size = New System.Drawing.Size(82, 33)
        Me.btnSalirGeneral.TabIndex = 4
        Me.btnSalirGeneral.Text = "&Salir"
        Me.btnSalirGeneral.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.btnPantallaGeneral)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(140, 160)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 61)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
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
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Print_1
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.Location = New System.Drawing.Point(98, 17)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(82, 33)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "&Imprimir"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnPantallaGeneral
        '
        Me.btnPantallaGeneral.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPantallaGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPantallaGeneral.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Screen_1
        Me.btnPantallaGeneral.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPantallaGeneral.Location = New System.Drawing.Point(10, 17)
        Me.btnPantallaGeneral.Name = "btnPantallaGeneral"
        Me.btnPantallaGeneral.Size = New System.Drawing.Size(82, 33)
        Me.btnPantallaGeneral.TabIndex = 0
        Me.btnPantallaGeneral.Text = "&Pantalla"
        Me.btnPantallaGeneral.UseVisualStyleBackColor = False
        '
        'gbGeneral
        '
        Me.gbGeneral.Controls.Add(Me.cboAñoGeneral)
        Me.gbGeneral.Controls.Add(Me.Label12)
        Me.gbGeneral.Controls.Add(Me.cboMesGeneral)
        Me.gbGeneral.Controls.Add(Me.Label11)
        Me.gbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbGeneral.Location = New System.Drawing.Point(59, 49)
        Me.gbGeneral.Name = "gbGeneral"
        Me.gbGeneral.Size = New System.Drawing.Size(453, 88)
        Me.gbGeneral.TabIndex = 0
        Me.gbGeneral.TabStop = False
        '
        'cboAñoGeneral
        '
        Me.cboAñoGeneral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAñoGeneral.FormattingEnabled = True
        Me.cboAñoGeneral.Location = New System.Drawing.Point(302, 36)
        Me.cboAñoGeneral.Name = "cboAñoGeneral"
        Me.cboAñoGeneral.Size = New System.Drawing.Size(121, 22)
        Me.cboAñoGeneral.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(245, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 14)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Año :"
        '
        'cboMesGeneral
        '
        Me.cboMesGeneral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesGeneral.FormattingEnabled = True
        Me.cboMesGeneral.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboMesGeneral.Location = New System.Drawing.Point(75, 36)
        Me.cboMesGeneral.Name = "cboMesGeneral"
        Me.cboMesGeneral.Size = New System.Drawing.Size(121, 22)
        Me.cboMesGeneral.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 39)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 14)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Al Mes :"
        '
        'ESTADISTICA_PERDIDAS_GANANCIAS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 315)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.stEstado)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ESTADISTICA_PERDIDAS_GANANCIAS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Estadísticas de Perdidas y Ganancias"
        Me.gb1.ResumeLayout(False)
        Me.stEstado.ResumeLayout(False)
        Me.stEstado.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.gbUnidadNegocio.ResumeLayout(False)
        Me.gbUnidadNegocio.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.gbCentroCostos.ResumeLayout(False)
        Me.gbCentroCostos.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.gbZona.ResumeLayout(False)
        Me.gbZona.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.gbGeneral.ResumeLayout(False)
        Me.gbGeneral.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_archivo1 As Button
    Friend WithEvents btn_imprimir1 As Button
    Friend WithEvents btnPantallaUnidad As Button
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents stEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tspbExportar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tslblMensaje As System.Windows.Forms.ToolStripStatusLabel

    'Public Sub New()

    '    ' Llamada necesaria para el Diseñador de Windows Forms.
    '    InitializeComponent()

    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    'End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents gbGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents cboMesGeneral As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboAñoGeneral As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnPantallaGeneral As System.Windows.Forms.Button
    Friend WithEvents gbUnidadNegocio As System.Windows.Forms.GroupBox
    Friend WithEvents cboAñoUnidadNegocio As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMesUnidadNegocio As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkUnidadNegocio As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboUnidadNegocio As System.Windows.Forms.ComboBox
    Friend WithEvents gbCentroCostos As System.Windows.Forms.GroupBox
    Friend WithEvents chkCentroCostos As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCentroCostos As System.Windows.Forms.ComboBox
    Friend WithEvents cboAñoCentroCostos As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboMesCentroCostos As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExcelCC As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents btnPantallaCentroCostos As System.Windows.Forms.Button
    Friend WithEvents gbZona As System.Windows.Forms.GroupBox
    Friend WithEvents chkZona As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboZona As System.Windows.Forms.ComboBox
    Friend WithEvents cboAñoZona As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboMesZona As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents btnPantallaZona As System.Windows.Forms.Button
    Friend WithEvents btnSalirUnidadNegocio As System.Windows.Forms.Button
    Friend WithEvents btnSalirCentroCostos As System.Windows.Forms.Button
    Friend WithEvents btnSalirZona As System.Windows.Forms.Button
    Friend WithEvents btnSalirGeneral As System.Windows.Forms.Button
End Class
