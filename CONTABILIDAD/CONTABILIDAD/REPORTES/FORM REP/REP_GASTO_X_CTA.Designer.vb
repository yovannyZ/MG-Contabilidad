<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_GASTO_X_CTA
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.DT_GASTO_CTA = New CONTABILIDAD.DT_GASTO_CTA
        Me.REPORTE_GASTO_X_CTABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.REPORTE_GASTO_X_CTATableAdapter = New CONTABILIDAD.DT_GASTO_CTATableAdapters.REPORTE_GASTO_X_CTATableAdapter
        CType(Me.DT_GASTO_CTA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTE_GASTO_X_CTABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_GASTO_CTA_REPORTE_GASTO_X_CTA"
        ReportDataSource1.Value = Me.REPORTE_GASTO_X_CTABindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_GASTO_X_CTA.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(737, 786)
        Me.ReportViewer1.TabIndex = 0
        '
        'DT_GASTO_CTA
        '
        Me.DT_GASTO_CTA.DataSetName = "DT_GASTO_CTA"
        Me.DT_GASTO_CTA.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'REPORTE_GASTO_X_CTABindingSource
        '
        Me.REPORTE_GASTO_X_CTABindingSource.DataMember = "REPORTE_GASTO_X_CTA"
        Me.REPORTE_GASTO_X_CTABindingSource.DataSource = Me.DT_GASTO_CTA
        '
        'REPORTE_GASTO_X_CTATableAdapter
        '
        Me.REPORTE_GASTO_X_CTATableAdapter.ClearBeforeFill = True
        '
        'REP_GASTO_X_CTA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 786)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_GASTO_X_CTA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP_GASTO_X_CTA"
        CType(Me.DT_GASTO_CTA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTE_GASTO_X_CTABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_GASTO_X_CTABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_GASTO_CTA As CONTABILIDAD.DT_GASTO_CTA
    Friend WithEvents REPORTE_GASTO_X_CTATableAdapter As CONTABILIDAD.DT_GASTO_CTATableAdapters.REPORTE_GASTO_X_CTATableAdapter
End Class
