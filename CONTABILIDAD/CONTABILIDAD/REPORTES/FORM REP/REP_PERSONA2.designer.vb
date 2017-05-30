<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_PERSONA2
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
        Me.REPORTE_PERSONAS2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_PERSONAS2 = New CONTABILIDAD.DT_REP_PERSONAS2
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_PERSONAS2TableAdapter = New CONTABILIDAD.DT_REP_PERSONAS2TableAdapters.REPORTE_PERSONAS2TableAdapter
        CType(Me.REPORTE_PERSONAS2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_PERSONAS2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_PERSONAS2BindingSource
        '
        Me.REPORTE_PERSONAS2BindingSource.DataMember = "REPORTE_PERSONAS2"
        Me.REPORTE_PERSONAS2BindingSource.DataSource = Me.DT_REP_PERSONAS2
        '
        'DT_REP_PERSONAS2
        '
        Me.DT_REP_PERSONAS2.DataSetName = "DT_REP_PERSONAS2"
        Me.DT_REP_PERSONAS2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_PERSONAS2_REPORTE_PERSONAS2"
        ReportDataSource1.Value = Me.REPORTE_PERSONAS2BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_PERSONA02.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(680, 620)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_PERSONAS2TableAdapter
        '
        Me.REPORTE_PERSONAS2TableAdapter.ClearBeforeFill = True
        '
        'REP_PERSONA2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(680, 620)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_PERSONA2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP_PERSONA2"
        CType(Me.REPORTE_PERSONAS2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_PERSONAS2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DT_REP_PERSONAS2 As CONTABILIDAD.DT_REP_PERSONAS2
    Friend WithEvents REPORTE_PERSONAS2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents REPORTE_PERSONAS2TableAdapter As CONTABILIDAD.DT_REP_PERSONAS2TableAdapters.REPORTE_PERSONAS2TableAdapter
End Class
