<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_PROV3
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.CONFIG_PROV3BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_CONFIG_PROV3 = New CONTABILIDAD.DT_CONFIG_PROV3
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.CONFIG_PROV3BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_CONFIG_PROV3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CONFIG_PROV3BindingSource
        '
        Me.CONFIG_PROV3BindingSource.DataMember = "CONFIG_PROV3"
        Me.CONFIG_PROV3BindingSource.DataSource = Me.DT_CONFIG_PROV3
        '
        'DT_CONFIG_PROV3
        '
        Me.DT_CONFIG_PROV3.DataSetName = "DT_CONFIG_PROV3"
        Me.DT_CONFIG_PROV3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DT_CONFIG_PROV3_CONFIG_PROV3"
        ReportDataSource2.Value = Me.CONFIG_PROV3BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_PROV3.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(711, 596)
        Me.ReportViewer1.TabIndex = 0
        '
        'REP_PROV3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 596)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_PROV3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Kardex de Registro de Compras, Ventas y Honorarios"
        CType(Me.CONFIG_PROV3BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_CONFIG_PROV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CONFIG_PROV3BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_CONFIG_PROV3 As CONTABILIDAD.DT_CONFIG_PROV3
End Class
