<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_PROV2
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
        Me.CONFIG_PROV2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_CONFIG_PROV2 = New CONTABILIDAD.DT_CONFIG_PROV2
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.CONFIG_PROV2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_CONFIG_PROV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CONFIG_PROV2BindingSource
        '
        Me.CONFIG_PROV2BindingSource.DataMember = "CONFIG_PROV2"
        Me.CONFIG_PROV2BindingSource.DataSource = Me.DT_CONFIG_PROV2
        '
        'DT_CONFIG_PROV2
        '
        Me.DT_CONFIG_PROV2.DataSetName = "DT_CONFIG_PROV2"
        Me.DT_CONFIG_PROV2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_CONFIG_PROV2_CONFIG_PROV2"
        ReportDataSource1.Value = Me.CONFIG_PROV2BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_PROV2.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(722, 587)
        Me.ReportViewer1.TabIndex = 0
        '
        'REP_PROV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 587)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_PROV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Provisiones"
        CType(Me.CONFIG_PROV2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_CONFIG_PROV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CONFIG_PROV2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_CONFIG_PROV2 As CONTABILIDAD.DT_CONFIG_PROV2
End Class
