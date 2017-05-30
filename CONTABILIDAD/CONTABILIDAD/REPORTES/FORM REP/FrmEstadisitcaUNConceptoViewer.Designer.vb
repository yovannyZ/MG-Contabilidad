<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEstadisitcaUNConceptoViewer
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
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.DsUnidadNegocioConcepto = New CONTABILIDAD.DsUnidadNegocioConcepto
        Me.Dt_4BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DsUnidadNegocioConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt_4BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource3.Name = "DsUnidadNegocioConcepto_Dt_4"
        ReportDataSource3.Value = Me.Dt_4BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.ReporteEstadisticaUNConcepto.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(284, 262)
        Me.ReportViewer1.TabIndex = 0
        '
        'DsUnidadNegocioConcepto
        '
        Me.DsUnidadNegocioConcepto.DataSetName = "DsUnidadNegocioConcepto"
        Me.DsUnidadNegocioConcepto.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Dt_4BindingSource
        '
        Me.Dt_4BindingSource.DataMember = "Dt_4"
        Me.Dt_4BindingSource.DataSource = Me.DsUnidadNegocioConcepto
        '
        'FrmEstadisitcaUNConceptoViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FrmEstadisitcaUNConceptoViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Estadisticas Unidad de Negocio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DsUnidadNegocioConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt_4BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Dt_4BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsUnidadNegocioConcepto As CONTABILIDAD.DsUnidadNegocioConcepto
End Class
