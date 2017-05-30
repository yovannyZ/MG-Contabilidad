<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CXP_CANC113
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
        Me.REPORTE_CXP_CANC12BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.REPORTE_VARIOS = New CONTABILIDAD.REPORTE_VARIOS
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_CXP_CANC12TableAdapter = New CONTABILIDAD.REPORTE_VARIOSTableAdapters.REPORTE_CXP_CANC12TableAdapter
        CType(Me.REPORTE_CXP_CANC12BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTE_VARIOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_CXP_CANC12BindingSource
        '
        Me.REPORTE_CXP_CANC12BindingSource.DataMember = "REPORTE_CXP_CANC12"
        Me.REPORTE_CXP_CANC12BindingSource.DataSource = Me.REPORTE_VARIOS
        '
        'REPORTE_VARIOS
        '
        Me.REPORTE_VARIOS.DataSetName = "REPORTE_VARIOS"
        Me.REPORTE_VARIOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "REPORTE_VARIOS_REPORTE_CXP_CANC12"
        ReportDataSource1.Value = Me.REPORTE_CXP_CANC12BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CXP_CAN113.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(811, 698)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_CXP_CANC12TableAdapter
        '
        Me.REPORTE_CXP_CANC12TableAdapter.ClearBeforeFill = True
        '
        'REP_CXP_CANC113
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 698)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CXP_CANC113"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP_CXP_CANC113"
        CType(Me.REPORTE_CXP_CANC12BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTE_VARIOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_CXP_CANC12BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents REPORTE_VARIOS As CONTABILIDAD.REPORTE_VARIOS
    Friend WithEvents REPORTE_CXP_CANC12TableAdapter As CONTABILIDAD.REPORTE_VARIOSTableAdapters.REPORTE_CXP_CANC12TableAdapter
End Class
