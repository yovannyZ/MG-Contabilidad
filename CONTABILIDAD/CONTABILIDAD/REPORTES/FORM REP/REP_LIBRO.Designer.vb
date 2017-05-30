<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_LIBRO
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
        Me.I_BANCOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_LIBRO = New CONTABILIDAD.DT_LIBRO
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.I_BANCOTableAdapter = New CONTABILIDAD.DT_LIBROTableAdapters.I_BANCOTableAdapter
        CType(Me.I_BANCOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_LIBRO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'I_BANCOBindingSource
        '
        Me.I_BANCOBindingSource.DataMember = "I_BANCO"
        Me.I_BANCOBindingSource.DataSource = Me.DT_LIBRO
        '
        'DT_LIBRO
        '
        Me.DT_LIBRO.DataSetName = "DT_LIBRO"
        Me.DT_LIBRO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_LIBRO_I_BANCO"
        ReportDataSource1.Value = Me.I_BANCOBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_LIBRO.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(644, 546)
        Me.ReportViewer1.TabIndex = 0
        '
        'I_BANCOTableAdapter
        '
        Me.I_BANCOTableAdapter.ClearBeforeFill = True
        '
        'REP_LIBRO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 546)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_LIBRO"
        Me.Text = "REP_LIBRO"
        CType(Me.I_BANCOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_LIBRO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents I_BANCOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_LIBRO As CONTABILIDAD.DT_LIBRO
    Friend WithEvents I_BANCOTableAdapter As CONTABILIDAD.DT_LIBROTableAdapters.I_BANCOTableAdapter
End Class
