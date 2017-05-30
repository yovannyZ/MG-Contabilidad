<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CONCILIACION
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
        Me.DT_REP_CONCILICACION = New CONTABILIDAD.DT_REP_CONCILICACION
        Me.CONCILIACIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CONCILIACIONTableAdapter = New CONTABILIDAD.DT_REP_CONCILICACIONTableAdapters.CONCILIACIONTableAdapter
        CType(Me.DT_REP_CONCILICACION, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CONCILIACIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_CONCILICACION_CONCILIACION"
        ReportDataSource1.Value = Me.CONCILIACIONBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CONCILIACION.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(977, 653)
        Me.ReportViewer1.TabIndex = 0
        '
        'DT_REP_CONCILICACION
        '
        Me.DT_REP_CONCILICACION.DataSetName = "DT_REP_CONCILICACION"
        Me.DT_REP_CONCILICACION.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CONCILIACIONBindingSource
        '
        Me.CONCILIACIONBindingSource.DataMember = "CONCILIACION"
        Me.CONCILIACIONBindingSource.DataSource = Me.DT_REP_CONCILICACION
        '
        'CONCILIACIONTableAdapter
        '
        Me.CONCILIACIONTableAdapter.ClearBeforeFill = True
        '
        'REP_CONCILIACION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(977, 653)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CONCILIACION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Concilicación"
        CType(Me.DT_REP_CONCILICACION, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CONCILIACIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CONCILIACIONBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_CONCILICACION As CONTABILIDAD.DT_REP_CONCILICACION
    Friend WithEvents CONCILIACIONTableAdapter As CONTABILIDAD.DT_REP_CONCILICACIONTableAdapters.CONCILIACIONTableAdapter
End Class
