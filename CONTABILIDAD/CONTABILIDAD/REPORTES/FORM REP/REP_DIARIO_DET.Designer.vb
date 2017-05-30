<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_DIARIO_DET
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
        Me.REPORTE_DIARIO_DETBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_DIARIO_DET = New CONTABILIDAD.DT_REP_DIARIO_DET
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_DIARIO_DETTableAdapter = New CONTABILIDAD.DT_REP_DIARIO_DETTableAdapters.REPORTE_DIARIO_DETTableAdapter
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.REPORTE_DIARIO_DETBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_DIARIO_DET, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_DIARIO_DETBindingSource
        '
        Me.REPORTE_DIARIO_DETBindingSource.DataMember = "REPORTE_DIARIO_DET"
        Me.REPORTE_DIARIO_DETBindingSource.DataSource = Me.DT_REP_DIARIO_DET
        '
        'DT_REP_DIARIO_DET
        '
        Me.DT_REP_DIARIO_DET.DataSetName = "DT_REP_DIARIO_DET"
        Me.DT_REP_DIARIO_DET.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_DIARIO_DET_REPORTE_DIARIO_DET"
        ReportDataSource1.Value = Me.REPORTE_DIARIO_DETBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_DIARIO_DET.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(643, 563)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_DIARIO_DETTableAdapter
        '
        Me.REPORTE_DIARIO_DETTableAdapter.ClearBeforeFill = True
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DT_REP_DIARIO_DET_REPORTE_DIARIO_DET"
        ReportDataSource2.Value = Me.REPORTE_DIARIO_DETBindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_DIARIO_DET2.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(643, 563)
        Me.ReportViewer2.TabIndex = 1
        '
        'REP_DIARIO_DET
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 563)
        Me.Controls.Add(Me.ReportViewer2)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_DIARIO_DET"
        Me.Text = "REP_DIARIO_DET"
        CType(Me.REPORTE_DIARIO_DETBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_DIARIO_DET, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_DIARIO_DETBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_DIARIO_DET As CONTABILIDAD.DT_REP_DIARIO_DET
    Friend WithEvents REPORTE_DIARIO_DETTableAdapter As CONTABILIDAD.DT_REP_DIARIO_DETTableAdapters.REPORTE_DIARIO_DETTableAdapter
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
End Class
