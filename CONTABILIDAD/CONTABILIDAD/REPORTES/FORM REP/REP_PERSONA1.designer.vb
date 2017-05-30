<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_PERSONA1
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
        Me.REPORTE_PERSONAS1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_PERSONA1 = New CONTABILIDAD.DT_REP_PERSONA1
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_PERSONAS1TableAdapter = New CONTABILIDAD.DT_REP_PERSONA1TableAdapters.REPORTE_PERSONAS1TableAdapter
        CType(Me.REPORTE_PERSONAS1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_PERSONA1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_PERSONAS1BindingSource
        '
        Me.REPORTE_PERSONAS1BindingSource.DataMember = "REPORTE_PERSONAS1"
        Me.REPORTE_PERSONAS1BindingSource.DataSource = Me.DT_REP_PERSONA1
        '
        'DT_REP_PERSONA1
        '
        Me.DT_REP_PERSONA1.DataSetName = "DT_REP_PERSONA1"
        Me.DT_REP_PERSONA1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_PERSONA1_REPORTE_PERSONAS1"
        ReportDataSource1.Value = Me.REPORTE_PERSONAS1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_PERSONA01.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(726, 621)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_PERSONAS1TableAdapter
        '
        Me.REPORTE_PERSONAS1TableAdapter.ClearBeforeFill = True
        '
        'REP_PERSONA1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 621)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_PERSONA1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP_PERSONA1"
        CType(Me.REPORTE_PERSONAS1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_PERSONA1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_PERSONAS1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_PERSONA1 As CONTABILIDAD.DT_REP_PERSONA1
    Friend WithEvents REPORTE_PERSONAS1TableAdapter As CONTABILIDAD.DT_REP_PERSONA1TableAdapters.REPORTE_PERSONAS1TableAdapter
End Class
