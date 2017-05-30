<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_TC_CONSULTA
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
        Me.DT_CONSULTA_TC = New CONTABILIDAD.DT_CONSULTA_TC
        Me.TCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DT_CONSULTA_TC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_CONSULTA_TC_TC"
        ReportDataSource1.Value = Me.TCBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_TC_CONSULTA.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(858, 694)
        Me.ReportViewer1.TabIndex = 0
        '
        'DT_CONSULTA_TC
        '
        Me.DT_CONSULTA_TC.DataSetName = "DT_CONSULTA_TC"
        Me.DT_CONSULTA_TC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TCBindingSource
        '
        Me.TCBindingSource.DataMember = "TC"
        Me.TCBindingSource.DataSource = Me.DT_CONSULTA_TC
        '
        'REP_TC_CONSULTA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 694)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_TC_CONSULTA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Consulta de Tipo de Cambio"
        CType(Me.DT_CONSULTA_TC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TCBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_CONSULTA_TC As CONTABILIDAD.DT_CONSULTA_TC
End Class
