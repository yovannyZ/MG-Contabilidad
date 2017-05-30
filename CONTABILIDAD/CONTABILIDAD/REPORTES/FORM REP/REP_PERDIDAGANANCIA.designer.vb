<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_PERDIDAGANANCIA
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
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource6 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource7 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource8 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.REPORTE_PERDIDAS_GANANCIASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtEstadisticaPerdidasGanancia = New CONTABILIDAD.dtEstadisticaPerdidasGanancia
        Me.REPORTE_TRABAJADORESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.ReportViewer3 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.ReportViewer4 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.REPORTE_PERDIDAS_GANANCIASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEstadisticaPerdidasGanancia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTE_TRABAJADORESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_PERDIDAS_GANANCIASBindingSource
        '
        Me.REPORTE_PERDIDAS_GANANCIASBindingSource.DataMember = "REPORTE_PERDIDAS_GANANCIAS"
        Me.REPORTE_PERDIDAS_GANANCIASBindingSource.DataSource = Me.dtEstadisticaPerdidasGanancia
        '
        'dtEstadisticaPerdidasGanancia
        '
        Me.dtEstadisticaPerdidasGanancia.DataSetName = "dtEstadisticaPerdidasGanancia"
        Me.dtEstadisticaPerdidasGanancia.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'REPORTE_TRABAJADORESBindingSource
        '
        Me.REPORTE_TRABAJADORESBindingSource.DataMember = "REPORTE_TRABAJADORES"
        Me.REPORTE_TRABAJADORESBindingSource.DataSource = Me.dtEstadisticaPerdidasGanancia
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dtEstadisticaPerdidasGanancia_REPORTE_PERDIDAS_GANANCIAS"
        ReportDataSource1.Value = Me.REPORTE_PERDIDAS_GANANCIASBindingSource
        ReportDataSource2.Name = "dtEstadisticaPerdidasGanancia_REPORTE_TRABAJADORES"
        ReportDataSource2.Value = Me.REPORTE_TRABAJADORESBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_UNIDADNEGOCIO.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(713, 504)
        Me.ReportViewer1.TabIndex = 0
        '
        'ReportViewer3
        '
        Me.ReportViewer3.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource3.Name = "dtEstadisticaPerdidasGanancia_REPORTE_PERDIDAS_GANANCIAS"
        ReportDataSource3.Value = Me.REPORTE_PERDIDAS_GANANCIASBindingSource
        ReportDataSource4.Name = "dtEstadisticaPerdidasGanancia_REPORTE_TRABAJADORES"
        ReportDataSource4.Value = Me.REPORTE_TRABAJADORESBindingSource
        Me.ReportViewer3.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer3.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer3.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_ZONA.rdlc"
        Me.ReportViewer3.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer3.Name = "ReportViewer3"
        Me.ReportViewer3.Size = New System.Drawing.Size(713, 504)
        Me.ReportViewer3.TabIndex = 1
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource5.Name = "dtEstadisticaPerdidasGanancia_REPORTE_PERDIDAS_GANANCIAS"
        ReportDataSource5.Value = Me.REPORTE_PERDIDAS_GANANCIASBindingSource
        ReportDataSource6.Name = "dtEstadisticaPerdidasGanancia_REPORTE_TRABAJADORES"
        ReportDataSource6.Value = Me.REPORTE_TRABAJADORESBindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource5)
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource6)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CENTROCOSTOS.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(713, 504)
        Me.ReportViewer2.TabIndex = 2
        '
        'ReportViewer4
        '
        Me.ReportViewer4.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource7.Name = "dtEstadisticaPerdidasGanancia_REPORTE_PERDIDAS_GANANCIAS"
        ReportDataSource7.Value = Me.REPORTE_PERDIDAS_GANANCIASBindingSource
        ReportDataSource8.Name = "dtEstadisticaPerdidasGanancia_REPORTE_TRABAJADORES"
        ReportDataSource8.Value = Me.REPORTE_TRABAJADORESBindingSource
        Me.ReportViewer4.LocalReport.DataSources.Add(ReportDataSource7)
        Me.ReportViewer4.LocalReport.DataSources.Add(ReportDataSource8)
        Me.ReportViewer4.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_GENERAL.rdlc"
        Me.ReportViewer4.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer4.Name = "ReportViewer4"
        Me.ReportViewer4.Size = New System.Drawing.Size(713, 504)
        Me.ReportViewer4.TabIndex = 3
        '
        'REP_PERDIDAGANANCIA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 504)
        Me.Controls.Add(Me.ReportViewer4)
        Me.Controls.Add(Me.ReportViewer2)
        Me.Controls.Add(Me.ReportViewer3)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_PERDIDAGANANCIA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Estadistica Perdidas Ganancias"
        CType(Me.REPORTE_PERDIDAS_GANANCIASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEstadisticaPerdidasGanancia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTE_TRABAJADORESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_PERDIDAS_GANANCIASBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dtEstadisticaPerdidasGanancia As CONTABILIDAD.dtEstadisticaPerdidasGanancia
    Friend WithEvents ReportViewer3 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ReportViewer4 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_TRABAJADORESBindingSource As System.Windows.Forms.BindingSource
End Class
