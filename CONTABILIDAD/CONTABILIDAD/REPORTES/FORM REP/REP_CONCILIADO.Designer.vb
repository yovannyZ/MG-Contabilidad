<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CONCILIADO
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
        Me.REPORTE_CONCILIADASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_ANA_CXP = New CONTABILIDAD.DT_REP_ANA_CXP
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_CONCILIADASTableAdapter = New CONTABILIDAD.DT_REP_ANA_CXPTableAdapters.REPORTE_CONCILIADASTableAdapter
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.REPORTE_CONCILIADASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_ANA_CXP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_CONCILIADASBindingSource
        '
        Me.REPORTE_CONCILIADASBindingSource.DataMember = "REPORTE_CONCILIADAS"
        Me.REPORTE_CONCILIADASBindingSource.DataSource = Me.DT_REP_ANA_CXP
        '
        'DT_REP_ANA_CXP
        '
        Me.DT_REP_ANA_CXP.DataSetName = "DT_REP_ANA_CXP"
        Me.DT_REP_ANA_CXP.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_ANA_CXP_REPORTE_CONCILIADAS"
        ReportDataSource1.Value = Me.REPORTE_CONCILIADASBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CONCILIADO.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1060, 650)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_CONCILIADASTableAdapter
        '
        Me.REPORTE_CONCILIADASTableAdapter.ClearBeforeFill = True
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DT_REP_ANA_CXP_REPORTE_CONCILIADAS"
        ReportDataSource2.Value = Me.REPORTE_CONCILIADASBindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CONCILIADO_CONTINUO.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(1060, 650)
        Me.ReportViewer2.TabIndex = 1
        '
        'REP_CONCILIADO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1060, 650)
        Me.Controls.Add(Me.ReportViewer2)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CONCILIADO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP_CONCILIADO"
        CType(Me.REPORTE_CONCILIADASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_ANA_CXP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_CONCILIADASBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_ANA_CXP As CONTABILIDAD.DT_REP_ANA_CXP
    Friend WithEvents REPORTE_CONCILIADASTableAdapter As CONTABILIDAD.DT_REP_ANA_CXPTableAdapters.REPORTE_CONCILIADASTableAdapter
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
End Class
