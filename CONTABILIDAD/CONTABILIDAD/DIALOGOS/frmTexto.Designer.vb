<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTexto
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
        Me.rtbTexto = New System.Windows.Forms.RichTextBox
        Me.gbBuscar = New System.Windows.Forms.GroupBox
        Me.txtBuscar = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.tsslTitulo = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsslDescripcion = New System.Windows.Forms.ToolStripStatusLabel
        Me.gbBuscar.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbTexto
        '
        Me.rtbTexto.Dock = System.Windows.Forms.DockStyle.Top
        Me.rtbTexto.Location = New System.Drawing.Point(0, 0)
        Me.rtbTexto.Name = "rtbTexto"
        Me.rtbTexto.Size = New System.Drawing.Size(563, 437)
        Me.rtbTexto.TabIndex = 0
        Me.rtbTexto.Text = ""
        '
        'gbBuscar
        '
        Me.gbBuscar.Controls.Add(Me.txtBuscar)
        Me.gbBuscar.Location = New System.Drawing.Point(12, 443)
        Me.gbBuscar.Name = "gbBuscar"
        Me.gbBuscar.Size = New System.Drawing.Size(200, 52)
        Me.gbBuscar.TabIndex = 1
        Me.gbBuscar.TabStop = False
        Me.gbBuscar.Text = "Buscar"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(6, 20)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(188, 20)
        Me.txtBuscar.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslTitulo, Me.tsslDescripcion})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 496)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(563, 24)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslTitulo
        '
        Me.tsslTitulo.BorderSides = CType(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslTitulo.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslTitulo.ForeColor = System.Drawing.Color.Navy
        Me.tsslTitulo.Name = "tsslTitulo"
        Me.tsslTitulo.Size = New System.Drawing.Size(50, 19)
        Me.tsslTitulo.Text = "[Titulo]"
        '
        'tsslDescripcion
        '
        Me.tsslDescripcion.BorderSides = CType(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslDescripcion.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslDescripcion.Name = "tsslDescripcion"
        Me.tsslDescripcion.Size = New System.Drawing.Size(47, 19)
        Me.tsslDescripcion.Text = "[Desc.]"
        '
        'frmTexto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 520)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gbBuscar)
        Me.Controls.Add(Me.rtbTexto)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmTexto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Texto"
        Me.gbBuscar.ResumeLayout(False)
        Me.gbBuscar.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtbTexto As System.Windows.Forms.RichTextBox
    Friend WithEvents gbBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslTitulo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslDescripcion As System.Windows.Forms.ToolStripStatusLabel
End Class
