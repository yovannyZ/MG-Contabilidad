<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_GASTOS
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
        Me.REPORTE_GASTOPRODUCCIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_GASTO_PRODUCCION = New CONTABILIDAD.DT_REP_GASTO_PRODUCCION
        Me.REPORTE_GASTOPRODUCCIONCCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_GASTOPRODUCCIONTableAdapter = New CONTABILIDAD.DT_REP_GASTO_PRODUCCIONTableAdapters.REPORTE_GASTOPRODUCCIONTableAdapter
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_GASTOPRODUCCIONCCTableAdapter = New CONTABILIDAD.DT_REP_GASTO_PRODUCCIONTableAdapters.REPORTE_GASTOPRODUCCIONCCTableAdapter
        CType(Me.REPORTE_GASTOPRODUCCIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_GASTO_PRODUCCION, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTE_GASTOPRODUCCIONCCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_GASTOPRODUCCIONBindingSource
        '
        Me.REPORTE_GASTOPRODUCCIONBindingSource.DataMember = "REPORTE_GASTOPRODUCCION"
        Me.REPORTE_GASTOPRODUCCIONBindingSource.DataSource = Me.DT_REP_GASTO_PRODUCCION
        '
        'DT_REP_GASTO_PRODUCCION
        '
        Me.DT_REP_GASTO_PRODUCCION.DataSetName = "DT_REP_GASTO_PRODUCCION"
        Me.DT_REP_GASTO_PRODUCCION.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'REPORTE_GASTOPRODUCCIONCCBindingSource
        '
        Me.REPORTE_GASTOPRODUCCIONCCBindingSource.DataMember = "REPORTE_GASTOPRODUCCIONCC"
        Me.REPORTE_GASTOPRODUCCIONCCBindingSource.DataSource = Me.DT_REP_GASTO_PRODUCCION
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_GASTO_PRODUCCION_REPORTE_GASTOPRODUCCION"
        ReportDataSource1.Value = Me.REPORTE_GASTOPRODUCCIONBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_GASTO_PROD.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(942, 635)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_GASTOPRODUCCIONTableAdapter
        '
        Me.REPORTE_GASTOPRODUCCIONTableAdapter.ClearBeforeFill = True
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DT_REP_GASTO_PRODUCCION_REPORTE_GASTOPRODUCCIONCC"
        ReportDataSource2.Value = Me.REPORTE_GASTOPRODUCCIONCCBindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_GASTO_PROD_CC.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(942, 635)
        Me.ReportViewer2.TabIndex = 1
        '
        'REPORTE_GASTOPRODUCCIONCCTableAdapter
        '
        Me.REPORTE_GASTOPRODUCCIONCCTableAdapter.ClearBeforeFill = True
        '
        'REP_GASTOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 635)
        Me.Controls.Add(Me.ReportViewer2)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_GASTOS"
        CType(Me.REPORTE_GASTOPRODUCCIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_GASTO_PRODUCCION, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTE_GASTOPRODUCCIONCCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_GASTOPRODUCCIONBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_GASTO_PRODUCCION As CONTABILIDAD.DT_REP_GASTO_PRODUCCION
    Friend WithEvents REPORTE_GASTOPRODUCCIONTableAdapter As CONTABILIDAD.DT_REP_GASTO_PRODUCCIONTableAdapters.REPORTE_GASTOPRODUCCIONTableAdapter
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_GASTOPRODUCCIONCCBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents REPORTE_GASTOPRODUCCIONCCTableAdapter As CONTABILIDAD.DT_REP_GASTO_PRODUCCIONTableAdapters.REPORTE_GASTOPRODUCCIONCCTableAdapter
End Class
