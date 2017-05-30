<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CXC_CANC1
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
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.REPORTE_CXC_CANC1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.REPORTE_VARIOS = New CONTABILIDAD.REPORTE_VARIOS
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_CXC_CANC1TableAdapter = New CONTABILIDAD.REPORTE_VARIOSTableAdapters.REPORTE_CXC_CANC1TableAdapter
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.ReportViewer3 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.REPORTE_CXC_CANC1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTE_VARIOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_CXC_CANC1BindingSource
        '
        Me.REPORTE_CXC_CANC1BindingSource.DataMember = "REPORTE_CXC_CANC1"
        Me.REPORTE_CXC_CANC1BindingSource.DataSource = Me.REPORTE_VARIOS
        '
        'REPORTE_VARIOS
        '
        Me.REPORTE_VARIOS.DataSetName = "REPORTE_VARIOS"
        Me.REPORTE_VARIOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "REPORTE_VARIOS_REPORTE_CXC_CANC1"
        ReportDataSource1.Value = Me.REPORTE_CXC_CANC1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CXC_CAN11.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(757, 668)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_CXC_CANC1TableAdapter
        '
        Me.REPORTE_CXC_CANC1TableAdapter.ClearBeforeFill = True
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "REPORTE_VARIOS_REPORTE_CXC_CANC1"
        ReportDataSource2.Value = Me.REPORTE_CXC_CANC1BindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CXC_CAN12.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(757, 668)
        Me.ReportViewer2.TabIndex = 1
        '
        'ReportViewer3
        '
        Me.ReportViewer3.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource3.Name = "REPORTE_VARIOS_REPORTE_CXC_CANC1"
        ReportDataSource3.Value = Me.REPORTE_CXC_CANC1BindingSource
        Me.ReportViewer3.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer3.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CXC_CAN13.rdlc"
        Me.ReportViewer3.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer3.Name = "ReportViewer3"
        Me.ReportViewer3.Size = New System.Drawing.Size(757, 668)
        Me.ReportViewer3.TabIndex = 2
        '
        'REP_CXC_CANC1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 668)
        Me.Controls.Add(Me.ReportViewer3)
        Me.Controls.Add(Me.ReportViewer2)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CXC_CANC1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP_CXC_CANC1"
        CType(Me.REPORTE_CXC_CANC1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTE_VARIOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_CXC_CANC1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents REPORTE_VARIOS As CONTABILIDAD.REPORTE_VARIOS
    Friend WithEvents REPORTE_CXC_CANC1TableAdapter As CONTABILIDAD.REPORTE_VARIOSTableAdapters.REPORTE_CXC_CANC1TableAdapter
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ReportViewer3 As Microsoft.Reporting.WinForms.ReportViewer
End Class
