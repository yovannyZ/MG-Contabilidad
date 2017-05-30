<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_M_CUENTA
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
        Me.REPORTE_M_CUENTASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.REPORTE_MAESTROS = New CONTABILIDAD.REPORTE_MAESTROS
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_M_CUENTASTableAdapter = New CONTABILIDAD.REPORTE_MAESTROSTableAdapters.REPORTE_M_CUENTASTableAdapter
        CType(Me.REPORTE_M_CUENTASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTE_MAESTROS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_M_CUENTASBindingSource
        '
        Me.REPORTE_M_CUENTASBindingSource.DataMember = "REPORTE_M_CUENTAS"
        Me.REPORTE_M_CUENTASBindingSource.DataSource = Me.REPORTE_MAESTROS
        '
        'REPORTE_MAESTROS
        '
        Me.REPORTE_MAESTROS.DataSetName = "REPORTE_MAESTROS"
        Me.REPORTE_MAESTROS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "REPORTE_MAESTROS_REPORTE_M_CUENTAS"
        ReportDataSource1.Value = Me.REPORTE_M_CUENTASBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_M_CUENTAS.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(692, 530)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_M_CUENTASTableAdapter
        '
        Me.REPORTE_M_CUENTASTableAdapter.ClearBeforeFill = True
        '
        'REP_M_CUENTA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 530)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_M_CUENTA"
        Me.Text = "REP_M_CUENTA"
        CType(Me.REPORTE_M_CUENTASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTE_MAESTROS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_M_CUENTASBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents REPORTE_MAESTROS As CONTABILIDAD.REPORTE_MAESTROS
    Friend WithEvents REPORTE_M_CUENTASTableAdapter As CONTABILIDAD.REPORTE_MAESTROSTableAdapters.REPORTE_M_CUENTASTableAdapter
End Class
