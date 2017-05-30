<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_MCPTO
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
        Me.MAESTRO_CONCEPTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_MCPTO = New CONTABILIDAD.DT_REP_MCPTO
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.MAESTRO_CONCEPTOSTableAdapter = New CONTABILIDAD.DT_REP_MCPTOTableAdapters.MAESTRO_CONCEPTOSTableAdapter
        CType(Me.MAESTRO_CONCEPTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_MCPTO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MAESTRO_CONCEPTOSBindingSource
        '
        Me.MAESTRO_CONCEPTOSBindingSource.DataMember = "MAESTRO_CONCEPTOS"
        Me.MAESTRO_CONCEPTOSBindingSource.DataSource = Me.DT_REP_MCPTO
        '
        'DT_REP_MCPTO
        '
        Me.DT_REP_MCPTO.DataSetName = "DT_REP_MCPTO"
        Me.DT_REP_MCPTO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_MCPTO_MAESTRO_CONCEPTOS"
        ReportDataSource1.Value = Me.MAESTRO_CONCEPTOSBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_MCPTO.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(706, 548)
        Me.ReportViewer1.TabIndex = 0
        '
        'MAESTRO_CONCEPTOSTableAdapter
        '
        Me.MAESTRO_CONCEPTOSTableAdapter.ClearBeforeFill = True
        '
        'REPORTE_MCPTO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 548)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REPORTE_MCPTO"
        Me.Text = "REPORTE_MCPTO"
        CType(Me.MAESTRO_CONCEPTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_MCPTO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents MAESTRO_CONCEPTOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_MCPTO As CONTABILIDAD.DT_REP_MCPTO
    Friend WithEvents MAESTRO_CONCEPTOSTableAdapter As CONTABILIDAD.DT_REP_MCPTOTableAdapters.MAESTRO_CONCEPTOSTableAdapter
End Class
