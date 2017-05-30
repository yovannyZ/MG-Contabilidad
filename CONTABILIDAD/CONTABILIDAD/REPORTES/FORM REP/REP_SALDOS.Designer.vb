<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_SALDOS
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
        Me.REPORTE_MAESTRO_SALDOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_SALDOS = New CONTABILIDAD.DT_REP_SALDOS
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_MAESTRO_SALDOSTableAdapter = New CONTABILIDAD.DT_REP_SALDOSTableAdapters.REPORTE_MAESTRO_SALDOSTableAdapter
        CType(Me.REPORTE_MAESTRO_SALDOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_SALDOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_MAESTRO_SALDOSBindingSource
        '
        Me.REPORTE_MAESTRO_SALDOSBindingSource.DataMember = "REPORTE_MAESTRO_SALDOS"
        Me.REPORTE_MAESTRO_SALDOSBindingSource.DataSource = Me.DT_REP_SALDOS
        '
        'DT_REP_SALDOS
        '
        Me.DT_REP_SALDOS.DataSetName = "DT_REP_SALDOS"
        Me.DT_REP_SALDOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_SALDOS_REPORTE_MAESTRO_SALDOS"
        ReportDataSource1.Value = Me.REPORTE_MAESTRO_SALDOSBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_SALDOS.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(682, 534)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_MAESTRO_SALDOSTableAdapter
        '
        Me.REPORTE_MAESTRO_SALDOSTableAdapter.ClearBeforeFill = True
        '
        'REP_SALDOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 534)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_SALDOS"
        Me.Text = "REP_SALDOS"
        CType(Me.REPORTE_MAESTRO_SALDOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_SALDOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_MAESTRO_SALDOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_SALDOS As CONTABILIDAD.DT_REP_SALDOS
    Friend WithEvents REPORTE_MAESTRO_SALDOSTableAdapter As CONTABILIDAD.DT_REP_SALDOSTableAdapters.REPORTE_MAESTRO_SALDOSTableAdapter
End Class
