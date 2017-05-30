<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CXP_PTE1_COI
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
        Me.REPORTE_CXP_PTES1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_VARIOS = New CONTABILIDAD.DT_VARIOS
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_CXP_PTES1TableAdapter = New CONTABILIDAD.DT_VARIOSTableAdapters.REPORTE_CXP_PTES1TableAdapter
        CType(Me.REPORTE_CXP_PTES1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_VARIOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_CXP_PTES1BindingSource
        '
        Me.REPORTE_CXP_PTES1BindingSource.DataMember = "REPORTE_CXP_PTES1"
        Me.REPORTE_CXP_PTES1BindingSource.DataSource = Me.DT_VARIOS
        '
        'DT_VARIOS
        '
        Me.DT_VARIOS.DataSetName = "DT_VARIOS"
        Me.DT_VARIOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_VARIOS_REPORTE_CXP_PTES1"
        ReportDataSource1.Value = Me.REPORTE_CXP_PTES1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CXP_PTE11.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(766, 643)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_CXP_PTES1TableAdapter
        '
        Me.REPORTE_CXP_PTES1TableAdapter.ClearBeforeFill = True
        '
        'REP_CXP_PTE1_COI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 643)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CXP_PTE1_COI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP_CXP_PTE1_COI"
        CType(Me.REPORTE_CXP_PTES1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_VARIOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_CXP_PTES1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_VARIOS As CONTABILIDAD.DT_VARIOS
    Friend WithEvents REPORTE_CXP_PTES1TableAdapter As CONTABILIDAD.DT_VARIOSTableAdapters.REPORTE_CXP_PTES1TableAdapter
End Class
