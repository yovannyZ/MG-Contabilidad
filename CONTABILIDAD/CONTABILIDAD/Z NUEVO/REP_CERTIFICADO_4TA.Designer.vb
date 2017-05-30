<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CERTIFICADO_4TA
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
        Me.REPORTE_DET_CERTIFICADO_4TABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_CONFIG = New CONTABILIDAD.DT_CONFIG
        Me.REPORTE_DET_CERTIFICADO_4TATableAdapter = New CONTABILIDAD.DT_CONFIGTableAdapters.REPORTE_DET_CERTIFICADO_4TATableAdapter
        Me.DataTable1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.REPORTE_DET_CERTIFICADO_4TABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_CONFIG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_CONFIG_DataTable1"
        ReportDataSource1.Value = Me.DataTable1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.CERTIFICADO_4TA.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(673, 586)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_DET_CERTIFICADO_4TABindingSource
        '
        Me.REPORTE_DET_CERTIFICADO_4TABindingSource.DataMember = "REPORTE_DET_CERTIFICADO_4TA"
        Me.REPORTE_DET_CERTIFICADO_4TABindingSource.DataSource = Me.DT_CONFIG
        '
        'DT_CONFIG
        '
        Me.DT_CONFIG.DataSetName = "DT_CONFIG"
        Me.DT_CONFIG.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'REPORTE_DET_CERTIFICADO_4TATableAdapter
        '
        Me.REPORTE_DET_CERTIFICADO_4TATableAdapter.ClearBeforeFill = True
        '
        'DataTable1BindingSource
        '
        Me.DataTable1BindingSource.DataMember = "DataTable1"
        Me.DataTable1BindingSource.DataSource = Me.DT_CONFIG
        '
        'REP_CERTIFICADO_4TA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 586)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CERTIFICADO_4TA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP_CERTIFICADO_4TA"
        CType(Me.REPORTE_DET_CERTIFICADO_4TABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_CONFIG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_DET_CERTIFICADO_4TABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_CONFIG As CONTABILIDAD.DT_CONFIG
    Friend WithEvents REPORTE_DET_CERTIFICADO_4TATableAdapter As CONTABILIDAD.DT_CONFIGTableAdapters.REPORTE_DET_CERTIFICADO_4TATableAdapter
    Friend WithEvents DataTable1BindingSource As System.Windows.Forms.BindingSource
End Class
