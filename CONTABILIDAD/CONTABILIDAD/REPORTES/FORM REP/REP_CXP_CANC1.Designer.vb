<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CXP_CANC1
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.REPORTE_CXP_CANC1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REPORTES = New CONTABILIDAD.DT_REPORTES
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_CXP_CANC1TableAdapter = New CONTABILIDAD.DT_REPORTESTableAdapters.REPORTE_CXP_CANC1TableAdapter
        Me.ReportViewer3 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.REPORTE_CXP_CANC1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REPORTES, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_CXP_CANC1BindingSource
        '
        Me.REPORTE_CXP_CANC1BindingSource.DataMember = "REPORTE_CXP_CANC1"
        Me.REPORTE_CXP_CANC1BindingSource.DataSource = Me.DT_REPORTES
        '
        'DT_REPORTES
        '
        Me.DT_REPORTES.DataSetName = "DT_REPORTES"
        Me.DT_REPORTES.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REPORTES_REPORTE_CXP_CANC1"
        ReportDataSource1.Value = Me.REPORTE_CXP_CANC1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CXP_CAN11.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(845, 681)
        Me.ReportViewer1.TabIndex = 0
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DT_REPORTES_REPORTE_CXP_CANC1"
        ReportDataSource2.Value = Me.REPORTE_CXP_CANC1BindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CXP_CAN112.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(845, 681)
        Me.ReportViewer2.TabIndex = 1
        '
        'REPORTE_CXP_CANC1TableAdapter
        '
        Me.REPORTE_CXP_CANC1TableAdapter.ClearBeforeFill = True
        '
        'ReportViewer3
        '
        Me.ReportViewer3.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer3.Name = "ReportViewer3"
        Me.ReportViewer3.Size = New System.Drawing.Size(400, 250)
        Me.ReportViewer3.TabIndex = 0
        Me.ReportViewer3.Visible = False
        '
        'REP_CXP_CANC1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 681)
        Me.Controls.Add(Me.ReportViewer2)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CXP_CANC1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP_CXP_CANC1"
        CType(Me.REPORTE_CXP_CANC1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REPORTES, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_CXP_CANC1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REPORTES As CONTABILIDAD.DT_REPORTES
    Friend WithEvents REPORTE_CXP_CANC1TableAdapter As CONTABILIDAD.DT_REPORTESTableAdapters.REPORTE_CXP_CANC1TableAdapter
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ReportViewer3 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_CXP_CANC12BindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents REPORTE_MAESTROS As CONTABILIDAD.REPORTE_MAESTROS
    'Friend WithEvents REPORTE_CXP_CANC12TableAdapter As CONTABILIDAD.REPORTE_MAESTROSTableAdapters.REPORTE_CXP_CANC12TableAdapter
End Class
