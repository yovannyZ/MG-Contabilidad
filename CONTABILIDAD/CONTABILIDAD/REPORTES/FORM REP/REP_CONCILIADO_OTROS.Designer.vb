<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CONCILIADO_OTROS
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.REPORTE_CONCILIADAS_OTROSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_ANA_OTROS = New CONTABILIDAD.DT_REP_ANA_OTROS
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_CONCILIADAS_OTROSTableAdapter = New CONTABILIDAD.DT_REP_ANA_OTROSTableAdapters.REPORTE_CONCILIADAS_OTROSTableAdapter
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.REPORTE_CONCILIADAS_OTROSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_ANA_OTROS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_CONCILIADAS_OTROSBindingSource
        '
        Me.REPORTE_CONCILIADAS_OTROSBindingSource.DataMember = "REPORTE_CONCILIADAS_OTROS"
        Me.REPORTE_CONCILIADAS_OTROSBindingSource.DataSource = Me.DT_REP_ANA_OTROS
        '
        'DT_REP_ANA_OTROS
        '
        Me.DT_REP_ANA_OTROS.DataSetName = "DT_REP_ANA_OTROS"
        Me.DT_REP_ANA_OTROS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_ANA_OTROS_REPORTE_CONCILIADAS_OTROS"
        ReportDataSource1.Value = Me.REPORTE_CONCILIADAS_OTROSBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CONCILIADO_OTROS.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(806, 469)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_CONCILIADAS_OTROSTableAdapter
        '
        Me.REPORTE_CONCILIADAS_OTROSTableAdapter.ClearBeforeFill = True
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DT_REP_ANA_OTROS_REPORTE_CONCILIADAS_OTROS"
        ReportDataSource2.Value = Me.REPORTE_CONCILIADAS_OTROSBindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CONCILIADO_OTROS_CONTINUO.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(806, 469)
        Me.ReportViewer2.TabIndex = 1
        '
        'REP_CONCILIADO_OTROS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 469)
        Me.Controls.Add(Me.ReportViewer2)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CONCILIADO_OTROS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP_CONCILIADO_OTROS"
        CType(Me.REPORTE_CONCILIADAS_OTROSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_ANA_OTROS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_CONCILIADAS_OTROSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_ANA_OTROS As CONTABILIDAD.DT_REP_ANA_OTROS
    Friend WithEvents REPORTE_CONCILIADAS_OTROSTableAdapter As CONTABILIDAD.DT_REP_ANA_OTROSTableAdapters.REPORTE_CONCILIADAS_OTROSTableAdapter
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
End Class
