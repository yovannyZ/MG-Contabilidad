<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_RETENCION
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
        Me.DT_RETENCION = New CONTABILIDAD.DT_RETENCION
        Me.REPORTE_RETENCIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.REPORTE_RETENCIONTableAdapter = New CONTABILIDAD.DT_RETENCIONTableAdapters.REPORTE_RETENCIONTableAdapter
        CType(Me.DT_RETENCION, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTE_RETENCIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_RETENCION_REPORTE_RETENCION"
        ReportDataSource1.Value = Me.REPORTE_RETENCIONBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_RETENCION.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(727, 608)
        Me.ReportViewer1.TabIndex = 0
        '
        'DT_RETENCION
        '
        Me.DT_RETENCION.DataSetName = "DT_RETENCION"
        Me.DT_RETENCION.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'REPORTE_RETENCIONBindingSource
        '
        Me.REPORTE_RETENCIONBindingSource.DataMember = "REPORTE_RETENCION"
        Me.REPORTE_RETENCIONBindingSource.DataSource = Me.DT_RETENCION
        '
        'REPORTE_RETENCIONTableAdapter
        '
        Me.REPORTE_RETENCIONTableAdapter.ClearBeforeFill = True
        '
        'REP_RETENCION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 608)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_RETENCION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Retenciones"
        CType(Me.DT_RETENCION, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTE_RETENCIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_RETENCIONBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_RETENCION As CONTABILIDAD.DT_RETENCION
    Friend WithEvents REPORTE_RETENCIONTableAdapter As CONTABILIDAD.DT_RETENCIONTableAdapters.REPORTE_RETENCIONTableAdapter
End Class
