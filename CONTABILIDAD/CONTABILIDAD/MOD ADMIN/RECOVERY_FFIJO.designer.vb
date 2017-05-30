<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RECOVERY_FFIJO
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
        Me.TabControl2 = New System.Windows.Forms.TabControl
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.dgvDetalle = New System.Windows.Forms.DataGridView
        Me.dgvDatos = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTN_LIMP3 = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.G3 = New System.Windows.Forms.GroupBox
        Me.cboAño = New System.Windows.Forms.ComboBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.btn_consulta3 = New System.Windows.Forms.Button
        Me.cboMes = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column27 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column28 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column29 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column30 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column31 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column32 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column34 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column35 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column36 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column37 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabControl2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.G3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl2.ItemSize = New System.Drawing.Size(258, 18)
        Me.TabControl2.Location = New System.Drawing.Point(0, 0)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.Padding = New System.Drawing.Point(154, 3)
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(750, 513)
        Me.TabControl2.TabIndex = 63
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.dgvDetalle)
        Me.TabPage5.Controls.Add(Me.dgvDatos)
        Me.TabPage5.Controls.Add(Me.BTN_LIMP3)
        Me.TabPage5.Controls.Add(Me.btnSalir)
        Me.TabPage5.Controls.Add(Me.G3)
        Me.TabPage5.Controls.Add(Me.Button2)
        Me.TabPage5.Controls.Add(Me.Button5)
        Me.TabPage5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(742, 487)
        Me.TabPage5.TabIndex = 2
        Me.TabPage5.Text = "Fondo Fijo - Rendiciones"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToOrderColumns = True
        Me.dgvDetalle.AllowUserToResizeRows = False
        Me.dgvDetalle.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column20, Me.Column21, Me.Column22, Me.Column23, Me.Column24, Me.Column25, Me.Column26, Me.Column27, Me.Column28, Me.Column29, Me.Column30, Me.Column31, Me.Column32, Me.Column33, Me.Column34, Me.Column35, Me.Column36, Me.Column37})
        Me.dgvDetalle.Location = New System.Drawing.Point(7, 351)
        Me.dgvDetalle.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgvDetalle.MultiSelect = False
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.RowHeadersWidth = 25
        Me.dgvDetalle.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgvDetalle.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalle.ShowRowErrors = False
        Me.dgvDetalle.Size = New System.Drawing.Size(728, 128)
        Me.dgvDetalle.TabIndex = 176
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.AllowUserToOrderColumns = True
        Me.dgvDatos.AllowUserToResizeRows = False
        Me.dgvDatos.BackgroundColor = System.Drawing.Color.White
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column12, Me.Column8, Me.Column9, Me.Column10, Me.Column11})
        Me.dgvDatos.Location = New System.Drawing.Point(7, 138)
        Me.dgvDatos.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeadersWidth = 25
        Me.dgvDatos.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgvDatos.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatos.ShowRowErrors = False
        Me.dgvDatos.Size = New System.Drawing.Size(728, 207)
        Me.dgvDatos.TabIndex = 176
        '
        'Column1
        '
        Me.Column1.HeaderText = "Doc"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 40
        '
        'Column2
        '
        Me.Column2.HeaderText = "NºDoc"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Cta.Cte."
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 60
        '
        'Column4
        '
        Me.Column4.HeaderText = "Desc. Per"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 230
        '
        'Column5
        '
        Me.Column5.HeaderText = "Nro.Doc"
        Me.Column5.Name = "Column5"
        Me.Column5.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "Importe Inicial"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 90
        '
        'Column7
        '
        Me.Column7.HeaderText = "Importe Doc"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 90
        '
        'Column12
        '
        Me.Column12.HeaderText = "Ok"
        Me.Column12.Name = "Column12"
        Me.Column12.Width = 30
        '
        'Column8
        '
        Me.Column8.HeaderText = "Mon."
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 35
        '
        'Column9
        '
        Me.Column9.HeaderText = "Sucursal"
        Me.Column9.Name = "Column9"
        Me.Column9.Visible = False
        '
        'Column10
        '
        Me.Column10.HeaderText = "Doc.Per.Llave"
        Me.Column10.Name = "Column10"
        Me.Column10.Visible = False
        '
        'Column11
        '
        Me.Column11.HeaderText = "D/H"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 30
        '
        'BTN_LIMP3
        '
        Me.BTN_LIMP3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_LIMP3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_LIMP3.Image = Global.CONTABILIDAD.My.Resources.Resources._16__File_new_1
        Me.BTN_LIMP3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_LIMP3.Location = New System.Drawing.Point(272, 106)
        Me.BTN_LIMP3.Name = "BTN_LIMP3"
        Me.BTN_LIMP3.Size = New System.Drawing.Size(77, 26)
        Me.BTN_LIMP3.TabIndex = 164
        Me.BTN_LIMP3.Text = "&Limpiar"
        Me.BTN_LIMP3.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.Location = New System.Drawing.Point(355, 106)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(77, 26)
        Me.btnSalir.TabIndex = 163
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'G3
        '
        Me.G3.Controls.Add(Me.cboAño)
        Me.G3.Controls.Add(Me.Label30)
        Me.G3.Controls.Add(Me.btn_consulta3)
        Me.G3.Controls.Add(Me.cboMes)
        Me.G3.Controls.Add(Me.Label23)
        Me.G3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.G3.Location = New System.Drawing.Point(31, 4)
        Me.G3.Name = "G3"
        Me.G3.Size = New System.Drawing.Size(649, 98)
        Me.G3.TabIndex = 158
        Me.G3.TabStop = False
        Me.G3.Text = "Consulta"
        '
        'cboAño
        '
        Me.cboAño.BackColor = System.Drawing.Color.White
        Me.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAño.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAño.FormattingEnabled = True
        Me.cboAño.Location = New System.Drawing.Point(279, 38)
        Me.cboAño.Name = "cboAño"
        Me.cboAño.Size = New System.Drawing.Size(108, 22)
        Me.cboAño.TabIndex = 2
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(246, 42)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(27, 14)
        Me.Label30.TabIndex = 155
        Me.Label30.Text = "Año"
        '
        'btn_consulta3
        '
        Me.btn_consulta3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_consulta3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_consulta3.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Search_1
        Me.btn_consulta3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consulta3.Location = New System.Drawing.Point(481, 34)
        Me.btn_consulta3.Name = "btn_consulta3"
        Me.btn_consulta3.Size = New System.Drawing.Size(77, 26)
        Me.btn_consulta3.TabIndex = 6
        Me.btn_consulta3.Text = "&Consulta"
        Me.btn_consulta3.UseVisualStyleBackColor = True
        '
        'cboMes
        '
        Me.cboMes.BackColor = System.Drawing.Color.White
        Me.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMes.FormattingEnabled = True
        Me.cboMes.Items.AddRange(New Object() {"INICIO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.cboMes.Location = New System.Drawing.Point(120, 38)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(108, 22)
        Me.cboMes.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(62, 46)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(27, 14)
        Me.Label23.TabIndex = 24
        Me.Label23.Text = "Mes"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Delete_1
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(189, 106)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(77, 26)
        Me.Button2.TabIndex = 169
        Me.Button2.Text = "&Eliminar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Folder_search_
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.Location = New System.Drawing.Point(492, 106)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(97, 26)
        Me.Button5.TabIndex = 175
        Me.Button5.TabStop = False
        Me.Button5.Text = "&Contabilidad"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "Aux"
        Me.Column13.Name = "Column13"
        Me.Column13.Width = 30
        '
        'Column14
        '
        Me.Column14.HeaderText = "Comp."
        Me.Column14.Name = "Column14"
        Me.Column14.Width = 40
        '
        'Column15
        '
        Me.Column15.HeaderText = "NºComp"
        Me.Column15.Name = "Column15"
        Me.Column15.Width = 60
        '
        'Column16
        '
        Me.Column16.HeaderText = "Doc"
        Me.Column16.Name = "Column16"
        Me.Column16.Width = 30
        '
        'Column17
        '
        Me.Column17.HeaderText = "NºDoc"
        Me.Column17.Name = "Column17"
        '
        'Column18
        '
        Me.Column18.HeaderText = "Cta.Cte."
        Me.Column18.Name = "Column18"
        Me.Column18.Width = 60
        '
        'Column19
        '
        Me.Column19.HeaderText = "Desc. Per"
        Me.Column19.Name = "Column19"
        Me.Column19.Width = 220
        '
        'Column20
        '
        Me.Column20.HeaderText = "NºDoc"
        Me.Column20.Name = "Column20"
        '
        'Column21
        '
        Me.Column21.HeaderText = "Importe Doc."
        Me.Column21.Name = "Column21"
        Me.Column21.Width = 90
        '
        'Column22
        '
        Me.Column22.HeaderText = "Mon"
        Me.Column22.Name = "Column22"
        Me.Column22.Width = 30
        '
        'Column23
        '
        Me.Column23.HeaderText = "Sucursal"
        Me.Column23.Name = "Column23"
        Me.Column23.Visible = False
        '
        'Column24
        '
        Me.Column24.HeaderText = "Doc.Per.Llave"
        Me.Column24.Name = "Column24"
        Me.Column24.Visible = False
        '
        'Column25
        '
        Me.Column25.HeaderText = "D/H"
        Me.Column25.Name = "Column25"
        Me.Column25.Width = 30
        '
        'Column26
        '
        Me.Column26.HeaderText = "Fec.Doc"
        Me.Column26.Name = "Column26"
        '
        'Column27
        '
        Me.Column27.HeaderText = "Fecha Ven."
        Me.Column27.Name = "Column27"
        Me.Column27.Visible = False
        '
        'Column28
        '
        Me.Column28.HeaderText = "TC"
        Me.Column28.Name = "Column28"
        Me.Column28.Visible = False
        '
        'Column29
        '
        Me.Column29.HeaderText = "Cod.Ref"
        Me.Column29.Name = "Column29"
        Me.Column29.Visible = False
        '
        'Column30
        '
        Me.Column30.HeaderText = "Nro Ref"
        Me.Column30.Name = "Column30"
        Me.Column30.Visible = False
        '
        'Column31
        '
        Me.Column31.HeaderText = "Fecha Ref"
        Me.Column31.Name = "Column31"
        Me.Column31.Visible = False
        '
        'Column32
        '
        Me.Column32.HeaderText = "Tipo Ope"
        Me.Column32.Name = "Column32"
        Me.Column32.Visible = False
        '
        'Column33
        '
        Me.Column33.HeaderText = "Glosa"
        Me.Column33.Name = "Column33"
        Me.Column33.Visible = False
        '
        'Column34
        '
        Me.Column34.HeaderText = "Año Traido"
        Me.Column34.Name = "Column34"
        Me.Column34.Visible = False
        '
        'Column35
        '
        Me.Column35.HeaderText = "Mes Traido"
        Me.Column35.Name = "Column35"
        Me.Column35.Visible = False
        '
        'Column36
        '
        Me.Column36.HeaderText = "Suc Traida"
        Me.Column36.Name = "Column36"
        Me.Column36.Visible = False
        '
        'Column37
        '
        Me.Column37.HeaderText = "Cuenta"
        Me.Column37.Name = "Column37"
        '
        'RECOVERY_FFIJO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 513)
        Me.Controls.Add(Me.TabControl2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RECOVERY_FFIJO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.G3.ResumeLayout(False)
        Me.G3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents BTN_LIMP3 As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents G3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboAño As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents btn_consulta3 As System.Windows.Forms.Button
    Friend WithEvents cboMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column37 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
