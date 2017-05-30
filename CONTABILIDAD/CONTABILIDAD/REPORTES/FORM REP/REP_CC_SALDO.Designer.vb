<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CC_SALDO
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
        Me.DT_CC_T_CON = New CONTABILIDAD.DT_CC_T_CON
        Me.REPORTE_CC_SALDO2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DT_CC_T_CON, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTE_CC_SALDO2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_CC_T_CON_REPORTE_CC_SALDO2"
        ReportDataSource1.Value = Me.REPORTE_CC_SALDO2BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CC_SALDO.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(727, 608)
        Me.ReportViewer1.TabIndex = 0
        '
        'DT_CC_T_CON
        '
        Me.DT_CC_T_CON.DataSetName = "DT_CC_T_CON"
        Me.DT_CC_T_CON.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'REPORTE_CC_SALDO2BindingSource
        '
        Me.REPORTE_CC_SALDO2BindingSource.DataMember = "REPORTE_CC_SALDO2"
        Me.REPORTE_CC_SALDO2BindingSource.DataSource = Me.DT_CC_T_CON
        '
        'REP_CC_SALDO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 608)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CC_SALDO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Centro de Costos - Saldo"
        CType(Me.DT_CC_T_CON, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTE_CC_SALDO2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_CC_SALDO2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_CC_T_CON As CONTABILIDAD.DT_CC_T_CON
End Class
