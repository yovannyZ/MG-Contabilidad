<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_LIBRO_CONTABLE
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
        Me.components = New System.ComponentModel.Container
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.DT_LIBRO = New CONTABILIDAD.DT_LIBRO
        Me.I_BANCO1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.I_BANCO1TableAdapter = New CONTABILIDAD.DT_LIBROTableAdapters.I_BANCO1TableAdapter
        CType(Me.DT_LIBRO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.I_BANCO1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_LIBRO_I_BANCO1"
        ReportDataSource1.Value = Me.I_BANCO1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_LIBRO_CONTABLE.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(727, 608)
        Me.ReportViewer1.TabIndex = 0
        '
        'DT_LIBRO
        '
        Me.DT_LIBRO.DataSetName = "DT_LIBRO"
        Me.DT_LIBRO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'I_BANCO1BindingSource
        '
        Me.I_BANCO1BindingSource.DataMember = "I_BANCO1"
        Me.I_BANCO1BindingSource.DataSource = Me.DT_LIBRO
        '
        'I_BANCO1TableAdapter
        '
        Me.I_BANCO1TableAdapter.ClearBeforeFill = True
        '
        'REP_LIBRO_CONTABLE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 608)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_LIBRO_CONTABLE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Libro Contable"
        CType(Me.DT_LIBRO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.I_BANCO1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents I_BANCO1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_LIBRO As CONTABILIDAD.DT_LIBRO
    Friend WithEvents I_BANCO1TableAdapter As CONTABILIDAD.DT_LIBROTableAdapters.I_BANCO1TableAdapter
End Class
