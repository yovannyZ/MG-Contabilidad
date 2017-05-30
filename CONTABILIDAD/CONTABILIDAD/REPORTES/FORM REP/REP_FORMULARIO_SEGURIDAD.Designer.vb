<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_FORMULARIO_SEGURIDAD
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
        Me.FORMULARIO_SEGURIDAD = New CONTABILIDAD.FORMULARIO_SEGURIDAD
        Me.CONSULTA_FORMULARIO_SEGURIDADBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CONSULTA_FORMULARIO_SEGURIDADTableAdapter = New CONTABILIDAD.FORMULARIO_SEGURIDADTableAdapters.CONSULTA_FORMULARIO_SEGURIDADTableAdapter
        CType(Me.FORMULARIO_SEGURIDAD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CONSULTA_FORMULARIO_SEGURIDADBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "FORMULARIO_SEGURIDAD_CONSULTA_FORMULARIO_SEGURIDAD"
        ReportDataSource1.Value = Me.CONSULTA_FORMULARIO_SEGURIDADBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_FORMULARIO_SEGURIDAD.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(608, 529)
        Me.ReportViewer1.TabIndex = 1
        '
        'FORMULARIO_SEGURIDAD
        '
        Me.FORMULARIO_SEGURIDAD.DataSetName = "FORMULARIO_SEGURIDAD"
        Me.FORMULARIO_SEGURIDAD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CONSULTA_FORMULARIO_SEGURIDADBindingSource
        '
        Me.CONSULTA_FORMULARIO_SEGURIDADBindingSource.DataMember = "CONSULTA_FORMULARIO_SEGURIDAD"
        Me.CONSULTA_FORMULARIO_SEGURIDADBindingSource.DataSource = Me.FORMULARIO_SEGURIDAD
        '
        'CONSULTA_FORMULARIO_SEGURIDADTableAdapter
        '
        Me.CONSULTA_FORMULARIO_SEGURIDADTableAdapter.ClearBeforeFill = True
        '
        'REP_FORMULARIO_SEGURIDAD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 529)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_FORMULARIO_SEGURIDAD"
        Me.Text = "REP_FORMULARIO_SEGURIDAD"
        CType(Me.FORMULARIO_SEGURIDAD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CONSULTA_FORMULARIO_SEGURIDADBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CONSULTA_FORMULARIO_SEGURIDADBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FORMULARIO_SEGURIDAD As CONTABILIDAD.FORMULARIO_SEGURIDAD
    Friend WithEvents CONSULTA_FORMULARIO_SEGURIDADTableAdapter As CONTABILIDAD.FORMULARIO_SEGURIDADTableAdapters.CONSULTA_FORMULARIO_SEGURIDADTableAdapter
End Class
