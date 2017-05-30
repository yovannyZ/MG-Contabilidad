<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_DISTRIBUCION
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
        Me.components = New System.ComponentModel.Container
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_DISTRIBUCIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_ESTADISTICA = New CONTABILIDAD.DT_ESTADISTICA
        Me.REPORTE_DISTRIBUCIONTableAdapter = New CONTABILIDAD.DT_ESTADISTICATableAdapters.REPORTE_DISTRIBUCIONTableAdapter
        CType(Me.REPORTE_DISTRIBUCIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_ESTADISTICA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_ESTADISTICA_REPORTE_DISTRIBUCION"
        ReportDataSource1.Value = Me.REPORTE_DISTRIBUCIONBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_DISTRIBUCION.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1085, 648)
        Me.ReportViewer1.TabIndex = 0
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DT_ESTADISTICA_REPORTE_DISTRIBUCION"
        ReportDataSource2.Value = Me.REPORTE_DISTRIBUCIONBindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CCOSTOS.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(1085, 648)
        Me.ReportViewer2.TabIndex = 1
        '
        'REPORTE_DISTRIBUCIONBindingSource
        '
        Me.REPORTE_DISTRIBUCIONBindingSource.DataMember = "REPORTE_DISTRIBUCION"
        Me.REPORTE_DISTRIBUCIONBindingSource.DataSource = Me.DT_ESTADISTICA
        '
        'DT_ESTADISTICA
        '
        Me.DT_ESTADISTICA.DataSetName = "DT_ESTADISTICA"
        Me.DT_ESTADISTICA.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'REPORTE_DISTRIBUCIONTableAdapter
        '
        Me.REPORTE_DISTRIBUCIONTableAdapter.ClearBeforeFill = True
        '
        'REP_DISTRIBUCION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1085, 648)
        Me.Controls.Add(Me.ReportViewer2)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_DISTRIBUCION"
        Me.Text = "Distribución - Centro de Costos"
        CType(Me.REPORTE_DISTRIBUCIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_ESTADISTICA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_DISTRIBUCIONBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_ESTADISTICA As CONTABILIDAD.DT_ESTADISTICA
    Friend WithEvents REPORTE_DISTRIBUCIONTableAdapter As CONTABILIDAD.DT_ESTADISTICATableAdapters.REPORTE_DISTRIBUCIONTableAdapter
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
End Class
