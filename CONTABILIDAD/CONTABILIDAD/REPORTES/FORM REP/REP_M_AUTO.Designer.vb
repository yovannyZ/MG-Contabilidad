<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_M_AUTO
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
        Me.REPORTE_MAESTROS = New CONTABILIDAD.REPORTE_MAESTROS
        Me.REPORTE_M_AUTOMATICASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.REPORTE_M_AUTOMATICASTableAdapter = New CONTABILIDAD.REPORTE_MAESTROSTableAdapters.REPORTE_M_AUTOMATICASTableAdapter
        CType(Me.REPORTE_MAESTROS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTE_M_AUTOMATICASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "REPORTE_MAESTROS_REPORTE_M_AUTOMATICAS"
        ReportDataSource1.Value = Me.REPORTE_M_AUTOMATICASBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_M_AUTOMATICAS.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(604, 542)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_MAESTROS
        '
        Me.REPORTE_MAESTROS.DataSetName = "REPORTE_MAESTROS"
        Me.REPORTE_MAESTROS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'REPORTE_M_AUTOMATICASBindingSource
        '
        Me.REPORTE_M_AUTOMATICASBindingSource.DataMember = "REPORTE_M_AUTOMATICAS"
        Me.REPORTE_M_AUTOMATICASBindingSource.DataSource = Me.REPORTE_MAESTROS
        '
        'REPORTE_M_AUTOMATICASTableAdapter
        '
        Me.REPORTE_M_AUTOMATICASTableAdapter.ClearBeforeFill = True
        '
        'REP_M_AUTO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 542)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_M_AUTO"
        Me.Text = "REP_M_AUTO"
        CType(Me.REPORTE_MAESTROS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTE_M_AUTOMATICASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_M_AUTOMATICASBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents REPORTE_MAESTROS As CONTABILIDAD.REPORTE_MAESTROS
    Friend WithEvents REPORTE_M_AUTOMATICASTableAdapter As CONTABILIDAD.REPORTE_MAESTROSTableAdapters.REPORTE_M_AUTOMATICASTableAdapter
End Class
