<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUnidadNConceptoViewer
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
        Me.Dt_1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsUnidadNegocioConcepto = New CONTABILIDAD.DsUnidadNegocioConcepto
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.DtUnidadNegocioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.Dt_1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsUnidadNegocioConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtUnidadNegocioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dt_1BindingSource
        '
        Me.Dt_1BindingSource.DataMember = "Dt_1"
        Me.Dt_1BindingSource.DataSource = Me.DsUnidadNegocioConcepto
        '
        'DsUnidadNegocioConcepto
        '
        Me.DsUnidadNegocioConcepto.DataSetName = "DsUnidadNegocioConcepto"
        Me.DsUnidadNegocioConcepto.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DsUnidadNegocioConcepto_Dt_1"
        ReportDataSource1.Value = Me.Dt_1BindingSource
        ReportDataSource2.Name = "DsUnidadNegocioConcepto_DtUnidadNegocio"
        ReportDataSource2.Value = Me.DtUnidadNegocioBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.ReporteUnidadNConcepto.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(507, 496)
        Me.ReportViewer1.TabIndex = 0
        '
        'DtUnidadNegocioBindingSource
        '
        Me.DtUnidadNegocioBindingSource.DataMember = "DtUnidadNegocio"
        Me.DtUnidadNegocioBindingSource.DataSource = Me.DsUnidadNegocioConcepto
        '
        'FrmUnidadNConceptoViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(507, 496)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FrmUnidadNConceptoViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Unidad Negocio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Dt_1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsUnidadNegocioConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtUnidadNegocioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Dt_1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsUnidadNegocioConcepto As CONTABILIDAD.DsUnidadNegocioConcepto
    Friend WithEvents DtUnidadNegocioBindingSource As System.Windows.Forms.BindingSource
End Class
