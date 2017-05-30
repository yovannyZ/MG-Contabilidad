<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_BALANCE_H
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
        Me.REPORTE_BALANCEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_FORMATO = New CONTABILIDAD.DT_REP_FORMATO
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_BALANCETableAdapter = New CONTABILIDAD.DT_REP_FORMATOTableAdapters.REPORTE_BALANCETableAdapter
        CType(Me.REPORTE_BALANCEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_FORMATO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_BALANCEBindingSource
        '
        Me.REPORTE_BALANCEBindingSource.DataMember = "REPORTE_BALANCE"
        Me.REPORTE_BALANCEBindingSource.DataSource = Me.DT_REP_FORMATO
        '
        'DT_REP_FORMATO
        '
        Me.DT_REP_FORMATO.DataSetName = "DT_REP_FORMATO"
        Me.DT_REP_FORMATO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_FORMATO_REPORTE_BALANCE"
        ReportDataSource1.Value = Me.REPORTE_BALANCEBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_FORMATO_BALANCE_H.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(727, 608)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_BALANCETableAdapter
        '
        Me.REPORTE_BALANCETableAdapter.ClearBeforeFill = True
        '
        'REP_BALANCE_H
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 608)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_BALANCE_H"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        CType(Me.REPORTE_BALANCEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_FORMATO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_BALANCEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_FORMATO As CONTABILIDAD.DT_REP_FORMATO
    Friend WithEvents REPORTE_BALANCETableAdapter As CONTABILIDAD.DT_REP_FORMATOTableAdapters.REPORTE_BALANCETableAdapter
End Class
