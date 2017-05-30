<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CTA_CYB
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
        Me.MAESTRO_BANCOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_CTA_CYB = New CONTABILIDAD.DT_REP_CTA_CYB
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.MAESTRO_BANCOSTableAdapter = New CONTABILIDAD.DT_REP_CTA_CYBTableAdapters.MAESTRO_BANCOSTableAdapter
        CType(Me.MAESTRO_BANCOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_CTA_CYB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MAESTRO_BANCOSBindingSource
        '
        Me.MAESTRO_BANCOSBindingSource.DataMember = "MAESTRO_BANCOS"
        Me.MAESTRO_BANCOSBindingSource.DataSource = Me.DT_REP_CTA_CYB
        '
        'DT_REP_CTA_CYB
        '
        Me.DT_REP_CTA_CYB.DataSetName = "DT_REP_CTA_CYB"
        Me.DT_REP_CTA_CYB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_CTA_CYB_MAESTRO_BANCOS"
        ReportDataSource1.Value = Me.MAESTRO_BANCOSBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CTA_CYB.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(654, 575)
        Me.ReportViewer1.TabIndex = 0
        '
        'MAESTRO_BANCOSTableAdapter
        '
        Me.MAESTRO_BANCOSTableAdapter.ClearBeforeFill = True
        '
        'REP_CTA_CYB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 575)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CTA_CYB"
        Me.Text = "REP_CTA_CYB"
        CType(Me.MAESTRO_BANCOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_CTA_CYB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents MAESTRO_BANCOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_CTA_CYB As CONTABILIDAD.DT_REP_CTA_CYB
    Friend WithEvents MAESTRO_BANCOSTableAdapter As CONTABILIDAD.DT_REP_CTA_CYBTableAdapters.MAESTRO_BANCOSTableAdapter
End Class
