<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CUADRE_AUTO
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_MAESTROS = New CONTABILIDAD.REPORTE_MAESTROS
        Me.CUADRE_AUTOMATICABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CUADRE_AUTOMATICATableAdapter = New CONTABILIDAD.REPORTE_MAESTROSTableAdapters.CUADRE_AUTOMATICATableAdapter
        CType(Me.REPORTE_MAESTROS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CUADRE_AUTOMATICABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "REPORTE_MAESTROS_CUADRE_AUTOMATICA"
        ReportDataSource1.Value = Me.CUADRE_AUTOMATICABindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CUADRE_AUTO.rdlc"
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
        'CUADRE_AUTOMATICABindingSource
        '
        Me.CUADRE_AUTOMATICABindingSource.DataMember = "CUADRE_AUTOMATICA"
        Me.CUADRE_AUTOMATICABindingSource.DataSource = Me.REPORTE_MAESTROS
        '
        'CUADRE_AUTOMATICATableAdapter
        '
        Me.CUADRE_AUTOMATICATableAdapter.ClearBeforeFill = True
        '
        'REP_CUADRE_AUTO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 542)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CUADRE_AUTO"
        Me.Text = "REP_CUADRE_AUTO"
        CType(Me.REPORTE_MAESTROS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CUADRE_AUTOMATICABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CUADRE_AUTOMATICABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents REPORTE_MAESTROS As CONTABILIDAD.REPORTE_MAESTROS
    Friend WithEvents CUADRE_AUTOMATICATableAdapter As CONTABILIDAD.REPORTE_MAESTROSTableAdapters.CUADRE_AUTOMATICATableAdapter
End Class
