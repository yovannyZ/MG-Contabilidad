<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarTxtPersona
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportarTxtPersona))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Rb_2 = New System.Windows.Forms.RadioButton
        Me.Rb_1 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_Datos = New System.Windows.Forms.TextBox
        Me.DG = New System.Windows.Forms.DataGridView
        Me.btn_guardar = New System.Windows.Forms.Button
        Me.Btn_Cargar = New System.Windows.Forms.Button
        Me.Btn_Abrir = New System.Windows.Forms.Button
        Me.Btn_Salir = New System.Windows.Forms.Button
        Me.DialogOpen = New System.Windows.Forms.OpenFileDialog
        Me.DGPersona = New System.Windows.Forms.DataGridView
        Me.DGPersonaDet = New System.Windows.Forms.DataGridView
        Me.Column0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox3.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGPersonaDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Rb_2)
        Me.GroupBox3.Controls.Add(Me.Rb_1)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(534, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(108, 34)
        Me.GroupBox3.TabIndex = 26
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Delimitado por:"
        '
        'Rb_2
        '
        Me.Rb_2.AutoSize = True
        Me.Rb_2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Rb_2.Location = New System.Drawing.Point(44, 13)
        Me.Rb_2.Name = "Rb_2"
        Me.Rb_2.Size = New System.Drawing.Size(27, 18)
        Me.Rb_2.TabIndex = 4
        Me.Rb_2.Text = "|"
        Me.Rb_2.UseVisualStyleBackColor = True
        '
        'Rb_1
        '
        Me.Rb_1.AutoSize = True
        Me.Rb_1.Checked = True
        Me.Rb_1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Rb_1.Location = New System.Drawing.Point(10, 13)
        Me.Rb_1.Name = "Rb_1"
        Me.Rb_1.Size = New System.Drawing.Size(28, 18)
        Me.Rb_1.TabIndex = 3
        Me.Rb_1.TabStop = True
        Me.Rb_1.Text = ";"
        Me.Rb_1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 14)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Cargar archivo txt"
        '
        'txt_Datos
        '
        Me.txt_Datos.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_Datos.Location = New System.Drawing.Point(109, 16)
        Me.txt_Datos.Name = "txt_Datos"
        Me.txt_Datos.Size = New System.Drawing.Size(339, 20)
        Me.txt_Datos.TabIndex = 23
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DG.BackgroundColor = System.Drawing.Color.White
        Me.DG.Location = New System.Drawing.Point(9, 349)
        Me.DG.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DG.MultiSelect = False
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        Me.DG.RowHeadersWidth = 18
        Me.DG.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DG.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG.Size = New System.Drawing.Size(55, 10)
        Me.DG.TabIndex = 22
        Me.DG.Visible = False
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.Location = New System.Drawing.Point(584, 346)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(80, 31)
        Me.btn_guardar.TabIndex = 27
        Me.btn_guardar.Text = "&Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'Btn_Cargar
        '
        Me.Btn_Cargar.Enabled = False
        Me.Btn_Cargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Cargar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cargar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Next_set_2_1
        Me.Btn_Cargar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Cargar.Location = New System.Drawing.Point(648, 13)
        Me.Btn_Cargar.Name = "Btn_Cargar"
        Me.Btn_Cargar.Size = New System.Drawing.Size(64, 28)
        Me.Btn_Cargar.TabIndex = 20
        Me.Btn_Cargar.Text = "&Sgte."
        Me.Btn_Cargar.UseVisualStyleBackColor = True
        '
        'Btn_Abrir
        '
        Me.Btn_Abrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Abrir.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Btn_Abrir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Binoculars_2_1
        Me.Btn_Abrir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Abrir.Location = New System.Drawing.Point(454, 13)
        Me.Btn_Abrir.Name = "Btn_Abrir"
        Me.Btn_Abrir.Size = New System.Drawing.Size(74, 28)
        Me.Btn_Abrir.TabIndex = 24
        Me.Btn_Abrir.Text = "&Buscar"
        Me.Btn_Abrir.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Salir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Salir.Location = New System.Drawing.Point(669, 346)
        Me.Btn_Salir.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(80, 31)
        Me.Btn_Salir.TabIndex = 21
        Me.Btn_Salir.Text = "&Salir"
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'DialogOpen
        '
        Me.DialogOpen.FileName = "OpenFileDialog1"
        '
        'DGPersona
        '
        Me.DGPersona.AllowUserToAddRows = False
        Me.DGPersona.AllowUserToDeleteRows = False
        Me.DGPersona.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGPersona.BackgroundColor = System.Drawing.Color.White
        Me.DGPersona.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column0, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.DGPersona.Location = New System.Drawing.Point(9, 50)
        Me.DGPersona.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DGPersona.MultiSelect = False
        Me.DGPersona.Name = "DGPersona"
        Me.DGPersona.ReadOnly = True
        Me.DGPersona.RowHeadersWidth = 18
        Me.DGPersona.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DGPersona.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DGPersona.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGPersona.Size = New System.Drawing.Size(744, 141)
        Me.DGPersona.TabIndex = 28
        '
        'DGPersonaDet
        '
        Me.DGPersonaDet.AllowUserToAddRows = False
        Me.DGPersonaDet.AllowUserToDeleteRows = False
        Me.DGPersonaDet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGPersonaDet.BackgroundColor = System.Drawing.Color.White
        Me.DGPersonaDet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Column8, Me.Column11, Me.Column12, Me.Column9})
        Me.DGPersonaDet.Location = New System.Drawing.Point(9, 197)
        Me.DGPersonaDet.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DGPersonaDet.MultiSelect = False
        Me.DGPersonaDet.Name = "DGPersonaDet"
        Me.DGPersonaDet.ReadOnly = True
        Me.DGPersonaDet.RowHeadersWidth = 18
        Me.DGPersonaDet.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DGPersonaDet.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DGPersonaDet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGPersonaDet.Size = New System.Drawing.Size(744, 140)
        Me.DGPersonaDet.TabIndex = 29
        '
        'Column0
        '
        Me.Column0.Frozen = True
        Me.Column0.HeaderText = "Código"
        Me.Column0.Name = "Column0"
        Me.Column0.ReadOnly = True
        Me.Column0.Width = 50
        '
        'Column1
        '
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = "T. Per"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.Frozen = True
        Me.Column2.HeaderText = "T. Doc"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 50
        '
        'Column3
        '
        Me.Column3.Frozen = True
        Me.Column3.HeaderText = "Nº Doc"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column4
        '
        Me.Column4.Frozen = True
        Me.Column4.HeaderText = "Descripción Persona"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 150
        '
        'Column5
        '
        Me.Column5.Frozen = True
        Me.Column5.HeaderText = "Nombre"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.Frozen = True
        Me.Column6.HeaderText = "Apellido Paterno"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 150
        '
        'Column7
        '
        Me.Column7.Frozen = True
        Me.Column7.HeaderText = "Apellido Materno"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 150
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "Código"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "Clase Persona"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'Column8
        '
        Me.Column8.Frozen = True
        Me.Column8.HeaderText = "Categoria"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 80
        '
        'Column11
        '
        Me.Column11.Frozen = True
        Me.Column11.HeaderText = "T. Per"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 50
        '
        'Column12
        '
        Me.Column12.Frozen = True
        Me.Column12.HeaderText = "T. Doc"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 50
        '
        'Column9
        '
        Me.Column9.Frozen = True
        Me.Column9.HeaderText = "Nº Doc"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 80
        '
        'ImportarTxtPersona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 386)
        Me.ControlBox = False
        Me.Controls.Add(Me.DGPersonaDet)
        Me.Controls.Add(Me.DGPersona)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.Btn_Cargar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Abrir)
        Me.Controls.Add(Me.txt_Datos)
        Me.Controls.Add(Me.DG)
        Me.Controls.Add(Me.Btn_Salir)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ImportarTxtPersona"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar datos de persona (txt)"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGPersona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGPersonaDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents Btn_Cargar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_2 As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btn_Abrir As System.Windows.Forms.Button
    Friend WithEvents txt_Datos As System.Windows.Forms.TextBox
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents DialogOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DGPersona As System.Windows.Forms.DataGridView
    Friend WithEvents DGPersonaDet As System.Windows.Forms.DataGridView
    Friend WithEvents Column0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
