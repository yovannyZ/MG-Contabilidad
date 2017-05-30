<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEstadisticaUNViewer
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
        Me.Dt_2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsUnidadNegocioConcepto = New CONTABILIDAD.DsUnidadNegocioConcepto
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.Dt_2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsUnidadNegocioConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dt_2BindingSource
        '
        Me.Dt_2BindingSource.DataMember = "Dt_2"
        Me.Dt_2BindingSource.DataSource = Me.DsUnidadNegocioConcepto
        '
        'DsUnidadNegocioConcepto
        '
        Me.DsUnidadNegocioConcepto.DataSetName = "DsUnidadNegocioConcepto"
        Me.DsUnidadNegocioConcepto.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DsUnidadNegocioConcepto_Dt_2"
        ReportDataSource1.Value = Me.Dt_2BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.ReporteEstadisticaUN.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(567, 262)
        Me.ReportViewer1.TabIndex = 0
        '
        'FrmEstadisticaUNViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 262)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FrmEstadisticaUNViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Estadistica Unidad de Negocio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Dt_2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsUnidadNegocioConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Dt_2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsUnidadNegocioConcepto As CONTABILIDAD.DsUnidadNegocioConcepto
End Class
