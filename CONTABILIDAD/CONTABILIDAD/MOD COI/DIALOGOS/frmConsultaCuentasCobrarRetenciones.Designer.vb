<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaCuentasCobrarRetenciones
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.rd_nc = New System.Windows.Forms.RadioButton
        Me.rb_ruc = New System.Windows.Forms.RadioButton
        Me.ch_rs = New System.Windows.Forms.RadioButton
        Me.ch_cod = New System.Windows.Forms.RadioButton
        Me.txt_letra = New System.Windows.Forms.TextBox
        Me.LBL = New System.Windows.Forms.Label
        Me.DGW = New System.Windows.Forms.DataGridView
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGW_CAB = New System.Windows.Forms.DataGridView
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Im = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.GroupBox8.SuspendLayout()
        CType(Me.DGW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGW_CAB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.rd_nc)
        Me.GroupBox8.Controls.Add(Me.rb_ruc)
        Me.GroupBox8.Controls.Add(Me.ch_rs)
        Me.GroupBox8.Controls.Add(Me.ch_cod)
        Me.GroupBox8.Controls.Add(Me.txt_letra)
        Me.GroupBox8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(0, 316)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(360, 67)
        Me.GroupBox8.TabIndex = 41
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Buscado por:"
        '
        'rd_nc
        '
        Me.rd_nc.AutoSize = True
        Me.rd_nc.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.rd_nc.Location = New System.Drawing.Point(255, 38)
        Me.rd_nc.Name = "rd_nc"
        Me.rd_nc.Size = New System.Drawing.Size(99, 18)
        Me.rd_nc.TabIndex = 4
        Me.rd_nc.Text = "Nom. Comercial"
        Me.rd_nc.UseVisualStyleBackColor = True
        '
        'rb_ruc
        '
        Me.rb_ruc.AutoSize = True
        Me.rb_ruc.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.rb_ruc.Location = New System.Drawing.Point(187, 40)
        Me.rb_ruc.Name = "rb_ruc"
        Me.rb_ruc.Size = New System.Drawing.Size(62, 18)
        Me.rb_ruc.TabIndex = 3
        Me.rb_ruc.Text = "Ruc/Dni"
        Me.rb_ruc.UseVisualStyleBackColor = True
        '
        'ch_rs
        '
        Me.ch_rs.AutoSize = True
        Me.ch_rs.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_rs.Location = New System.Drawing.Point(106, 38)
        Me.ch_rs.Name = "ch_rs"
        Me.ch_rs.Size = New System.Drawing.Size(75, 18)
        Me.ch_rs.TabIndex = 2
        Me.ch_rs.Text = "Proveedor"
        Me.ch_rs.UseVisualStyleBackColor = True
        '
        'ch_cod
        '
        Me.ch_cod.AutoSize = True
        Me.ch_cod.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ch_cod.Location = New System.Drawing.Point(6, 38)
        Me.ch_cod.Name = "ch_cod"
        Me.ch_cod.Size = New System.Drawing.Size(94, 18)
        Me.ch_cod.TabIndex = 1
        Me.ch_cod.Text = "Nº Documento"
        Me.ch_cod.UseVisualStyleBackColor = True
        '
        'txt_letra
        '
        Me.txt_letra.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txt_letra.Location = New System.Drawing.Point(6, 16)
        Me.txt_letra.Name = "txt_letra"
        Me.txt_letra.Size = New System.Drawing.Size(348, 20)
        Me.txt_letra.TabIndex = 0
        '
        'LBL
        '
        Me.LBL.AutoSize = True
        Me.LBL.Location = New System.Drawing.Point(584, 316)
        Me.LBL.Name = "LBL"
        Me.LBL.Size = New System.Drawing.Size(39, 14)
        Me.LBL.TabIndex = 40
        Me.LBL.Text = "Label1"
        Me.LBL.Visible = False
        '
        'DGW
        '
        Me.DGW.AllowUserToAddRows = False
        Me.DGW.AllowUserToDeleteRows = False
        Me.DGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGW.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column14, Me.Column15, Me.Column16})
        Me.DGW.Location = New System.Drawing.Point(12, 185)
        Me.DGW.Name = "DGW"
        Me.DGW.Size = New System.Drawing.Size(252, 72)
        Me.DGW.TabIndex = 39
        Me.DGW.Visible = False
        '
        'Column14
        '
        Me.Column14.HeaderText = "COD_PER"
        Me.Column14.Name = "Column14"
        '
        'Column15
        '
        Me.Column15.HeaderText = "COD_DOC"
        Me.Column15.Name = "Column15"
        '
        'Column16
        '
        Me.Column16.HeaderText = "NRO_DOC"
        Me.Column16.Name = "Column16"
        '
        'DGW_CAB
        '
        Me.DGW_CAB.AllowUserToAddRows = False
        Me.DGW_CAB.AllowUserToDeleteRows = False
        Me.DGW_CAB.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGW_CAB.BackgroundColor = System.Drawing.Color.White
        Me.DGW_CAB.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column8, Me.Column9, Me.Column5, Me.Column1, Me.Column2, Me.Column6, Me.Column7, Me.Column18, Me.Im, Me.Column19, Me.Column3, Me.Column20, Me.Column21, Me.Column22, Me.Column23, Me.Column24, Me.Column25, Me.Column4})
        Me.DGW_CAB.Dock = System.Windows.Forms.DockStyle.Top
        Me.DGW_CAB.Location = New System.Drawing.Point(0, 0)
        Me.DGW_CAB.Name = "DGW_CAB"
        Me.DGW_CAB.RowHeadersWidth = 20
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop
        Me.DGW_CAB.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DGW_CAB.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DGW_CAB.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DGW_CAB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGW_CAB.Size = New System.Drawing.Size(645, 309)
        Me.DGW_CAB.TabIndex = 38
        '
        'Column8
        '
        Me.Column8.HeaderText = "COD_DOC"
        Me.Column8.Name = "Column8"
        Me.Column8.Visible = False
        '
        'Column9
        '
        Me.Column9.HeaderText = "Documento"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Nº Documento"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "cod_per"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "Proveedor"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        Me.Column2.Width = 180
        '
        'Column6
        '
        DataGridViewCellStyle1.Format = "d"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column6.HeaderText = "Vcto."
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 65
        '
        'Column7
        '
        Me.Column7.HeaderText = "Mon"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 30
        '
        'Column18
        '
        Me.Column18.HeaderText = "imp_ini"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.Visible = False
        '
        'Im
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Im.DefaultCellStyle = DataGridViewCellStyle2
        Me.Im.HeaderText = "Importe"
        Me.Im.Name = "Im"
        Me.Im.ReadOnly = True
        Me.Im.Width = 77
        '
        'Column19
        '
        Me.Column19.HeaderText = "D/H"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        Me.Column19.Width = 30
        '
        'Column3
        '
        Me.Column3.HeaderText = "Ruc/Dni"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        Me.Column3.Width = 95
        '
        'Column20
        '
        Me.Column20.HeaderText = "Nom. Comercial"
        Me.Column20.Name = "Column20"
        Me.Column20.ReadOnly = True
        Me.Column20.Visible = False
        Me.Column20.Width = 95
        '
        'Column21
        '
        Me.Column21.HeaderText = "Cpto."
        Me.Column21.Name = "Column21"
        Me.Column21.ReadOnly = True
        Me.Column21.Width = 55
        '
        'Column22
        '
        Me.Column22.HeaderText = "Cuenta"
        Me.Column22.Name = "Column22"
        Me.Column22.ReadOnly = True
        Me.Column22.Width = 67
        '
        'Column23
        '
        Me.Column23.HeaderText = "Cc"
        Me.Column23.Name = "Column23"
        Me.Column23.ReadOnly = True
        Me.Column23.Visible = False
        Me.Column23.Width = 35
        '
        'Column24
        '
        Me.Column24.HeaderText = "Cont."
        Me.Column24.Name = "Column24"
        Me.Column24.ReadOnly = True
        Me.Column24.Visible = False
        Me.Column24.Width = 35
        '
        'Column25
        '
        Me.Column25.HeaderText = "Proy."
        Me.Column25.Name = "Column25"
        Me.Column25.ReadOnly = True
        Me.Column25.Visible = False
        Me.Column25.Width = 35
        '
        'Column4
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "n2"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column4.HeaderText = "Nuevo Imp."
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 77
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnAceptar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancelar, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(471, 341)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(162, 33)
        Me.TableLayoutPanel1.TabIndex = 37
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Ok_1
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.Location = New System.Drawing.Point(3, 3)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 27)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Image = Global.CONTABILIDAD.My.Resources.Resources._16__Cancel_1
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.Location = New System.Drawing.Point(84, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 27)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        '
        'frmConsultaCuentasCobrarRetenciones
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(645, 388)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.LBL)
        Me.Controls.Add(Me.DGW)
        Me.Controls.Add(Me.DGW_CAB)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaCuentasCobrarRetenciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cuentas por Cobrar - Pendientes"
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.DGW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGW_CAB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents rd_nc As System.Windows.Forms.RadioButton
    Friend WithEvents rb_ruc As System.Windows.Forms.RadioButton
    Friend WithEvents ch_rs As System.Windows.Forms.RadioButton
    Friend WithEvents ch_cod As System.Windows.Forms.RadioButton
    Friend WithEvents txt_letra As System.Windows.Forms.TextBox
    Friend WithEvents LBL As System.Windows.Forms.Label
    Friend WithEvents DGW As System.Windows.Forms.DataGridView
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGW_CAB As System.Windows.Forms.DataGridView
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Im As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
