<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_DETRACCION
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
        Me.DT_DETRACCION = New CONTABILIDAD.DT_DETRACCION
        Me.REPORTE_DETRACCIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.REPORTE_DETRACCIONTableAdapter = New CONTABILIDAD.DT_DETRACCIONTableAdapters.REPORTE_DETRACCIONTableAdapter
        CType(Me.DT_DETRACCION, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTE_DETRACCIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_DETRACCION_REPORTE_DETRACCION"
        ReportDataSource1.Value = Me.REPORTE_DETRACCIONBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_DETRACCION.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(727, 608)
        Me.ReportViewer1.TabIndex = 0
        '
        'DT_DETRACCION
        '
        Me.DT_DETRACCION.DataSetName = "DT_DETRACCION"
        Me.DT_DETRACCION.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'REPORTE_DETRACCIONBindingSource
        '
        Me.REPORTE_DETRACCIONBindingSource.DataMember = "REPORTE_DETRACCION"
        Me.REPORTE_DETRACCIONBindingSource.DataSource = Me.DT_DETRACCION
        '
        'REPORTE_DETRACCIONTableAdapter
        '
        Me.REPORTE_DETRACCIONTableAdapter.ClearBeforeFill = True
        '
        'REP_DETRACCION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 608)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_DETRACCION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        CType(Me.DT_DETRACCION, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTE_DETRACCIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_DETRACCIONBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_DETRACCION As CONTABILIDAD.DT_DETRACCION
    Friend WithEvents REPORTE_DETRACCIONTableAdapter As CONTABILIDAD.DT_DETRACCIONTableAdapters.REPORTE_DETRACCIONTableAdapter
End Class
