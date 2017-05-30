<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CAMBIO
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
        Me.DT_REP_CAMBIO = New CONTABILIDAD.DT_REP_CAMBIO
        Me.TIPO_CAMBIOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TIPO_CAMBIOTableAdapter = New CONTABILIDAD.DT_REP_CAMBIOTableAdapters.TIPO_CAMBIOTableAdapter
        CType(Me.DT_REP_CAMBIO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIPO_CAMBIOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_CAMBIO_TIPO_CAMBIO"
        ReportDataSource1.Value = Me.TIPO_CAMBIOBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CAMBIO.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(748, 562)
        Me.ReportViewer1.TabIndex = 0
        '
        'DT_REP_CAMBIO
        '
        Me.DT_REP_CAMBIO.DataSetName = "DT_REP_CAMBIO"
        Me.DT_REP_CAMBIO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TIPO_CAMBIOBindingSource
        '
        Me.TIPO_CAMBIOBindingSource.DataMember = "TIPO_CAMBIO"
        Me.TIPO_CAMBIOBindingSource.DataSource = Me.DT_REP_CAMBIO
        '
        'TIPO_CAMBIOTableAdapter
        '
        Me.TIPO_CAMBIOTableAdapter.ClearBeforeFill = True
        '
        'REP_CAMBIO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 562)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CAMBIO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP_CAMBIO"
        CType(Me.DT_REP_CAMBIO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIPO_CAMBIOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TIPO_CAMBIOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_CAMBIO As CONTABILIDAD.DT_REP_CAMBIO
    Friend WithEvents TIPO_CAMBIOTableAdapter As CONTABILIDAD.DT_REP_CAMBIOTableAdapters.TIPO_CAMBIOTableAdapter
End Class
