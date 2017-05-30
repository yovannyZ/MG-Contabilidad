<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_ESTADISTICA_GASTO
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
        Me.ESTADISTICA_GASTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_ESTADISTICA = New CONTABILIDAD.DT_ESTADISTICA
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.ESTADISTICA_GASTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_ESTADISTICA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ESTADISTICA_GASTOBindingSource
        '
        Me.ESTADISTICA_GASTOBindingSource.DataMember = "ESTADISTICA_GASTO"
        Me.ESTADISTICA_GASTOBindingSource.DataSource = Me.DT_ESTADISTICA
        '
        'DT_ESTADISTICA
        '
        Me.DT_ESTADISTICA.DataSetName = "DT_ESTADISTICA"
        Me.DT_ESTADISTICA.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_ESTADISTICA_ESTADISTICA_GASTO"
        ReportDataSource1.Value = Me.ESTADISTICA_GASTOBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_ESTADISTICA_GASTO.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1113, 765)
        Me.ReportViewer1.TabIndex = 0
        '
        'REP_ESTADISTICA_GASTO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1113, 765)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_ESTADISTICA_GASTO"
        Me.Text = "Reporte Estadistica Gasto"
        CType(Me.ESTADISTICA_GASTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_ESTADISTICA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ESTADISTICA_GASTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_ESTADISTICA As CONTABILIDAD.DT_ESTADISTICA
End Class
