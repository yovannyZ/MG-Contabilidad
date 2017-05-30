<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTE_CC
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
        Me.DT_CENTRO_COSTOS = New CONTABILIDAD.DT_CENTRO_COSTOS
        Me.CENTRO_COSTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CENTRO_COSTOSTableAdapter = New CONTABILIDAD.DT_CENTRO_COSTOSTableAdapters.CENTRO_COSTOSTableAdapter
        CType(Me.DT_CENTRO_COSTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CENTRO_COSTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_CENTRO_COSTOS_CENTRO_COSTOS"
        ReportDataSource1.Value = Me.CENTRO_COSTOSBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.reporte_centro_costos.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(727, 608)
        Me.ReportViewer1.TabIndex = 0
        '
        'DT_CENTRO_COSTOS
        '
        Me.DT_CENTRO_COSTOS.DataSetName = "DT_CENTRO_COSTOS"
        Me.DT_CENTRO_COSTOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CENTRO_COSTOSBindingSource
        '
        Me.CENTRO_COSTOSBindingSource.DataMember = "CENTRO_COSTOS"
        Me.CENTRO_COSTOSBindingSource.DataSource = Me.DT_CENTRO_COSTOS
        '
        'CENTRO_COSTOSTableAdapter
        '
        Me.CENTRO_COSTOSTableAdapter.ClearBeforeFill = True
        '
        'REPORTE_CC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 608)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REPORTE_CC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reprote de Centro de Costos"
        CType(Me.DT_CENTRO_COSTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CENTRO_COSTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CENTRO_COSTOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_CENTRO_COSTOS As CONTABILIDAD.DT_CENTRO_COSTOS
    Friend WithEvents CENTRO_COSTOSTableAdapter As CONTABILIDAD.DT_CENTRO_COSTOSTableAdapters.CENTRO_COSTOSTableAdapter
End Class
