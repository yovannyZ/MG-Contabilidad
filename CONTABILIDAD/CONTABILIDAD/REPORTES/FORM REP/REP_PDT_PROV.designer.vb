<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_PDT_PROV
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
        Me.PDTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_PDT_PROVISIONES = New CONTABILIDAD.DT_PDT_PROVISIONES
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.PDTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_PDT_PROVISIONES, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PDTBindingSource
        '
        Me.PDTBindingSource.DataMember = "PDT"
        Me.PDTBindingSource.DataSource = Me.DT_PDT_PROVISIONES
        '
        'DT_PDT_PROVISIONES
        '
        Me.DT_PDT_PROVISIONES.DataSetName = "DT_PDT_PROVISIONES"
        Me.DT_PDT_PROVISIONES.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_PDT_PROVISIONES_PDT"
        ReportDataSource1.Value = Me.PDTBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_PDT_PROV.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(754, 637)
        Me.ReportViewer1.TabIndex = 0
        '
        'REP_PDT_PROV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 637)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_PDT_PROV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        CType(Me.PDTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_PDT_PROVISIONES, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PDTBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_PDT_PROVISIONES As CONTABILIDAD.DT_PDT_PROVISIONES
End Class
