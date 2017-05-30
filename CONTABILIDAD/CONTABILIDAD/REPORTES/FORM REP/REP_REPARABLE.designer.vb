<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_REPARABLE
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
        Me.REPORTE_CUENTA_REPARABLEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REPARABLE = New CONTABILIDAD.DT_REPARABLE
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_CUENTA_REPARABLETableAdapter = New CONTABILIDAD.DT_REPARABLETableAdapters.REPORTE_CUENTA_REPARABLETableAdapter
        CType(Me.REPORTE_CUENTA_REPARABLEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REPARABLE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_CUENTA_REPARABLEBindingSource
        '
        Me.REPORTE_CUENTA_REPARABLEBindingSource.DataMember = "REPORTE_CUENTA_REPARABLE"
        Me.REPORTE_CUENTA_REPARABLEBindingSource.DataSource = Me.DT_REPARABLE
        '
        'DT_REPARABLE
        '
        Me.DT_REPARABLE.DataSetName = "DT_REPARABLE"
        Me.DT_REPARABLE.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REPARABLE_REPORTE_CUENTA_REPARABLE"
        ReportDataSource1.Value = Me.REPORTE_CUENTA_REPARABLEBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_REPARABLE.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(610, 562)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_CUENTA_REPARABLETableAdapter
        '
        Me.REPORTE_CUENTA_REPARABLETableAdapter.ClearBeforeFill = True
        '
        'REP_REPARABLE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 562)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_REPARABLE"
        Me.Text = "REP_REPARABLE"
        CType(Me.REPORTE_CUENTA_REPARABLEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REPARABLE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_CUENTA_REPARABLEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REPARABLE As CONTABILIDAD.DT_REPARABLE
    Friend WithEvents REPORTE_CUENTA_REPARABLETableAdapter As CONTABILIDAD.DT_REPARABLETableAdapters.REPORTE_CUENTA_REPARABLETableAdapter
End Class
