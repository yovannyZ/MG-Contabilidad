<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_PENDIENTE_CXC_ACTUALIZADO
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.REPORTE_ACTUALIZADOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_ANA_CXC = New CONTABILIDAD.DT_REP_ANA_CXC
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.REPORTE_ACTUALIZADOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_ANA_CXC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_ACTUALIZADOBindingSource
        '
        Me.REPORTE_ACTUALIZADOBindingSource.DataMember = "REPORTE_ACTUALIZADO"
        Me.REPORTE_ACTUALIZADOBindingSource.DataSource = Me.DT_REP_ANA_CXC
        '
        'DT_REP_ANA_CXC
        '
        Me.DT_REP_ANA_CXC.DataSetName = "DT_REP_ANA_CXC"
        Me.DT_REP_ANA_CXC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DT_REP_ANA_CXC_REPORTE_ACTUALIZADO"
        ReportDataSource2.Value = Me.REPORTE_ACTUALIZADOBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_PENDIENTE_CXC_ACTUALIZADO.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(882, 614)
        Me.ReportViewer1.TabIndex = 0
        '
        'REP_PENDIENTE_CXC_ACTUALIZADO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 614)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_PENDIENTE_CXC_ACTUALIZADO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Pendiente Cuentas Actualizado-Por Cobrar"
        CType(Me.REPORTE_ACTUALIZADOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_ANA_CXC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_ACTUALIZADOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_ANA_CXC As CONTABILIDAD.DT_REP_ANA_CXC
End Class
