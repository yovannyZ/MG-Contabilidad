<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_BALANCE_ANUAL
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
        Me.DT_REP_FORMATO = New CONTABILIDAD.DT_REP_FORMATO
        Me.REPORTE_BALANCE_ANUALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DT_REP_FORMATO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTE_BALANCE_ANUALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_FORMATO_REPORTE_BALANCE_ANUAL"
        ReportDataSource1.Value = Me.REPORTE_BALANCE_ANUALBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_FORMATO_BALANCE_ANUAL.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(727, 608)
        Me.ReportViewer1.TabIndex = 0
        '
        'DT_REP_FORMATO
        '
        Me.DT_REP_FORMATO.DataSetName = "DT_REP_FORMATO"
        Me.DT_REP_FORMATO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'REPORTE_BALANCE_ANUALBindingSource
        '
        Me.REPORTE_BALANCE_ANUALBindingSource.DataMember = "REPORTE_BALANCE_ANUAL"
        Me.REPORTE_BALANCE_ANUALBindingSource.DataSource = Me.DT_REP_FORMATO
        '
        'REP_BALANCE_ANUAL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 608)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_BALANCE_ANUAL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        CType(Me.DT_REP_FORMATO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTE_BALANCE_ANUALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_BALANCE_ANUALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_FORMATO As CONTABILIDAD.DT_REP_FORMATO
End Class
