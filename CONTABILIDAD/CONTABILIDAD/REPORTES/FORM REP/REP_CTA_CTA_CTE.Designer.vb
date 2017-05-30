<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CTA_CTA_CTE
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
        Me.REPORTE_CTA_CTA_CTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_CTA_AUX = New CONTABILIDAD.DT_REP_CTA_AUX
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_CTA_CTA_CTETableAdapter = New CONTABILIDAD.DT_REP_CTA_AUXTableAdapters.REPORTE_CTA_CTA_CTETableAdapter
        CType(Me.REPORTE_CTA_CTA_CTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_CTA_AUX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_CTA_CTA_CTEBindingSource
        '
        Me.REPORTE_CTA_CTA_CTEBindingSource.DataMember = "REPORTE_CTA_CTA_CTE"
        Me.REPORTE_CTA_CTA_CTEBindingSource.DataSource = Me.DT_REP_CTA_AUX
        '
        'DT_REP_CTA_AUX
        '
        Me.DT_REP_CTA_AUX.DataSetName = "DT_REP_CTA_AUX"
        Me.DT_REP_CTA_AUX.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_CTA_AUX_REPORTE_CTA_CTA_CTE"
        ReportDataSource1.Value = Me.REPORTE_CTA_CTA_CTEBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CTA_CTA_CTE.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(699, 579)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_CTA_CTA_CTETableAdapter
        '
        Me.REPORTE_CTA_CTA_CTETableAdapter.ClearBeforeFill = True
        '
        'REP_CTA_CTA_CTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 579)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CTA_CTA_CTE"
        Me.Text = "REP_CTA_CTA_CTE"
        CType(Me.REPORTE_CTA_CTA_CTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_CTA_AUX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_CTA_CTA_CTEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_CTA_AUX As CONTABILIDAD.DT_REP_CTA_AUX
    Friend WithEvents REPORTE_CTA_CTA_CTETableAdapter As CONTABILIDAD.DT_REP_CTA_AUXTableAdapters.REPORTE_CTA_CTA_CTETableAdapter
End Class
