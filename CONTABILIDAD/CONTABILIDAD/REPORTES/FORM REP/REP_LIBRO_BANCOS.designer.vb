<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_LIBRO_BANCOS
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
        Me.DT_REP_LIBRO_BANCOS = New CONTABILIDAD.DT_REP_LIBRO_BANCOS
        Me.LIBRO_BANCOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LIBRO_BANCOSTableAdapter = New CONTABILIDAD.DT_REP_LIBRO_BANCOSTableAdapters.LIBRO_BANCOSTableAdapter
        CType(Me.DT_REP_LIBRO_BANCOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LIBRO_BANCOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_LIBRO_BANCOS_LIBRO_BANCOS"
        ReportDataSource1.Value = Me.LIBRO_BANCOSBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_LIBRO_BANCOS.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(810, 599)
        Me.ReportViewer1.TabIndex = 0
        '
        'DT_REP_LIBRO_BANCOS
        '
        Me.DT_REP_LIBRO_BANCOS.DataSetName = "DT_REP_LIBRO_BANCOS"
        Me.DT_REP_LIBRO_BANCOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LIBRO_BANCOSBindingSource
        '
        Me.LIBRO_BANCOSBindingSource.DataMember = "LIBRO_BANCOS"
        Me.LIBRO_BANCOSBindingSource.DataSource = Me.DT_REP_LIBRO_BANCOS
        '
        'LIBRO_BANCOSTableAdapter
        '
        Me.LIBRO_BANCOSTableAdapter.ClearBeforeFill = True
        '
        'REP_LIBRO_BANCOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 599)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_LIBRO_BANCOS"
        Me.Text = "REP_LIBRO_BANCOS"
        CType(Me.DT_REP_LIBRO_BANCOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LIBRO_BANCOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents LIBRO_BANCOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_LIBRO_BANCOS As CONTABILIDAD.DT_REP_LIBRO_BANCOS
    Friend WithEvents LIBRO_BANCOSTableAdapter As CONTABILIDAD.DT_REP_LIBRO_BANCOSTableAdapters.LIBRO_BANCOSTableAdapter
End Class
