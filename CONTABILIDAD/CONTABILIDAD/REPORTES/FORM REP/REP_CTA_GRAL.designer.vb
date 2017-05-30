<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CTA_GRAL
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
        Me.REPORTE_CTA_GRALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_CTA_AUX = New CONTABILIDAD.DT_REP_CTA_AUX
        Me.REPORTE_CTA_GRALTableAdapter = New CONTABILIDAD.DT_REP_CTA_AUXTableAdapters.REPORTE_CTA_GRALTableAdapter
        CType(Me.REPORTE_CTA_GRALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_CTA_AUX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_CTA_AUX_REPORTE_CTA_GRAL"
        ReportDataSource1.Value = Me.REPORTE_CTA_GRALBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CTA_GRAL.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(748, 604)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_CTA_GRALBindingSource
        '
        Me.REPORTE_CTA_GRALBindingSource.DataMember = "REPORTE_CTA_GRAL"
        Me.REPORTE_CTA_GRALBindingSource.DataSource = Me.DT_REP_CTA_AUX
        '
        'DT_REP_CTA_AUX
        '
        Me.DT_REP_CTA_AUX.DataSetName = "DT_REP_CTA_AUX"
        Me.DT_REP_CTA_AUX.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'REPORTE_CTA_GRALTableAdapter
        '
        Me.REPORTE_CTA_GRALTableAdapter.ClearBeforeFill = True
        '
        'REP_CTA_GRAL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 604)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CTA_GRAL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP_CTA_GRAL"
        CType(Me.REPORTE_CTA_GRALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_CTA_AUX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_CTA_GRALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_CTA_AUX As CONTABILIDAD.DT_REP_CTA_AUX
    Friend WithEvents REPORTE_CTA_GRALTableAdapter As CONTABILIDAD.DT_REP_CTA_AUXTableAdapters.REPORTE_CTA_GRALTableAdapter
End Class
