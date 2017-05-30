<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_DESCUADRE_CXP
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
        Me.REPORTE_DESCUADRE_CXPBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REPORTES = New CONTABILIDAD.DT_REPORTES
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_DESCUADRE_CXPTableAdapter = New CONTABILIDAD.DT_REPORTESTableAdapters.REPORTE_DESCUADRE_CXPTableAdapter
        CType(Me.REPORTE_DESCUADRE_CXPBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REPORTES, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_DESCUADRE_CXPBindingSource
        '
        Me.REPORTE_DESCUADRE_CXPBindingSource.DataMember = "REPORTE_DESCUADRE_CXP"
        Me.REPORTE_DESCUADRE_CXPBindingSource.DataSource = Me.DT_REPORTES
        '
        'DT_REPORTES
        '
        Me.DT_REPORTES.DataSetName = "DT_REPORTES"
        Me.DT_REPORTES.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REPORTES_REPORTE_DESCUADRE_CXP"
        ReportDataSource1.Value = Me.REPORTE_DESCUADRE_CXPBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_DESCUADRE_PCXP.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(664, 502)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_DESCUADRE_CXPTableAdapter
        '
        Me.REPORTE_DESCUADRE_CXPTableAdapter.ClearBeforeFill = True
        '
        'REP_DESCUADRE_CXP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 502)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_DESCUADRE_CXP"
        Me.Text = "REP_DESCUADRE_CXP"
        CType(Me.REPORTE_DESCUADRE_CXPBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REPORTES, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_DESCUADRE_CXPBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REPORTES As CONTABILIDAD.DT_REPORTES
    Friend WithEvents REPORTE_DESCUADRE_CXPTableAdapter As CONTABILIDAD.DT_REPORTESTableAdapters.REPORTE_DESCUADRE_CXPTableAdapter
End Class
