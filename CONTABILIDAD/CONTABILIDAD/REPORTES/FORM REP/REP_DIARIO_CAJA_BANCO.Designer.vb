<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_DIARIO_CAJA_BANCO
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
        Me.DT_REPORTE_DIARIO_CAJA_BANCO = New CONTABILIDAD.DT_REPORTE_DIARIO_CAJA_BANCO
        Me.REPORTE_DIARIO_CAJA_BANCOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.REPORTE_DIARIO_CAJA_BANCOTableAdapter = New CONTABILIDAD.DT_REPORTE_DIARIO_CAJA_BANCOTableAdapters.REPORTE_DIARIO_CAJA_BANCOTableAdapter
        CType(Me.DT_REPORTE_DIARIO_CAJA_BANCO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTE_DIARIO_CAJA_BANCOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REPORTE_DIARIO_CAJA_BANCO_REPORTE_DIARIO_CAJA_BANCO"
        ReportDataSource1.Value = Me.REPORTE_DIARIO_CAJA_BANCOBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_DIARIO_CAJA_BANCO.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(782, 382)
        Me.ReportViewer1.TabIndex = 0
        '
        'DT_REPORTE_DIARIO_CAJA_BANCO
        '
        Me.DT_REPORTE_DIARIO_CAJA_BANCO.DataSetName = "DT_REPORTE_DIARIO_CAJA_BANCO"
        Me.DT_REPORTE_DIARIO_CAJA_BANCO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'REPORTE_DIARIO_CAJA_BANCOBindingSource
        '
        Me.REPORTE_DIARIO_CAJA_BANCOBindingSource.DataMember = "REPORTE_DIARIO_CAJA_BANCO"
        Me.REPORTE_DIARIO_CAJA_BANCOBindingSource.DataSource = Me.DT_REPORTE_DIARIO_CAJA_BANCO
        '
        'REPORTE_DIARIO_CAJA_BANCOTableAdapter
        '
        Me.REPORTE_DIARIO_CAJA_BANCOTableAdapter.ClearBeforeFill = True
        '
        'REP_DIARIO_CAJA_BANCO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 382)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_DIARIO_CAJA_BANCO"
        Me.Text = "REP_DIARIO_CAJA_BANCO"
        CType(Me.DT_REPORTE_DIARIO_CAJA_BANCO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTE_DIARIO_CAJA_BANCOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_DIARIO_CAJA_BANCOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REPORTE_DIARIO_CAJA_BANCO As CONTABILIDAD.DT_REPORTE_DIARIO_CAJA_BANCO
    Friend WithEvents REPORTE_DIARIO_CAJA_BANCOTableAdapter As CONTABILIDAD.DT_REPORTE_DIARIO_CAJA_BANCOTableAdapters.REPORTE_DIARIO_CAJA_BANCOTableAdapter
End Class
