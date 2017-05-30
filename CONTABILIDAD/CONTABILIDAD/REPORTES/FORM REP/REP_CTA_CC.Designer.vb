<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CTA_CC
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
        Me.DT_CTA_CC = New CONTABILIDAD.DT_CTA_CC
        Me.REPORTE_CUENTA_DEPBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.REPORTE_CUENTA_DEPTableAdapter = New CONTABILIDAD.DT_CTA_CCTableAdapters.REPORTE_CUENTA_DEPTableAdapter
        CType(Me.DT_CTA_CC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTE_CUENTA_DEPBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_CTA_CC_REPORTE_CUENTA_DEP"
        ReportDataSource1.Value = Me.REPORTE_CUENTA_DEPBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CTA_CC.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(650, 490)
        Me.ReportViewer1.TabIndex = 0
        '
        'DT_CTA_CC
        '
        Me.DT_CTA_CC.DataSetName = "DT_CTA_CC"
        Me.DT_CTA_CC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'REPORTE_CUENTA_DEPBindingSource
        '
        Me.REPORTE_CUENTA_DEPBindingSource.DataMember = "REPORTE_CUENTA_DEP"
        Me.REPORTE_CUENTA_DEPBindingSource.DataSource = Me.DT_CTA_CC
        '
        'REPORTE_CUENTA_DEPTableAdapter
        '
        Me.REPORTE_CUENTA_DEPTableAdapter.ClearBeforeFill = True
        '
        'REP_CTA_CC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 490)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CTA_CC"
        Me.Text = "REP_CTA_CC"
        CType(Me.DT_CTA_CC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTE_CUENTA_DEPBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_CUENTA_DEPBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_CTA_CC As CONTABILIDAD.DT_CTA_CC
    Friend WithEvents REPORTE_CUENTA_DEPTableAdapter As CONTABILIDAD.DT_CTA_CCTableAdapters.REPORTE_CUENTA_DEPTableAdapter
End Class
