<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CXC_PTE1
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.DT_VARIOS = New CONTABILIDAD.DT_VARIOS
        Me.REPORTE_CXC_PTES1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.REPORTE_CXC_PTES1TableAdapter = New CONTABILIDAD.DT_VARIOSTableAdapters.REPORTE_CXC_PTES1TableAdapter
        CType(Me.DT_VARIOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTE_CXC_PTES1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DT_VARIOS_REPORTE_CXC_PTES1"
        ReportDataSource2.Value = Me.REPORTE_CXC_PTES1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CXC_PTE11.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(784, 709)
        Me.ReportViewer1.TabIndex = 0
        '
        'DT_VARIOS
        '
        Me.DT_VARIOS.DataSetName = "DT_VARIOS"
        Me.DT_VARIOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'REPORTE_CXC_PTES1BindingSource
        '
        Me.REPORTE_CXC_PTES1BindingSource.DataMember = "REPORTE_CXC_PTES1"
        Me.REPORTE_CXC_PTES1BindingSource.DataSource = Me.DT_VARIOS
        '
        'REPORTE_CXC_PTES1TableAdapter
        '
        Me.REPORTE_CXC_PTES1TableAdapter.ClearBeforeFill = True
        '
        'REP_CXC_PTE1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 709)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CXC_PTE1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP_CXC_PTE1"
        CType(Me.DT_VARIOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTE_CXC_PTES1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_CXC_PTES1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_VARIOS As CONTABILIDAD.DT_VARIOS
    Friend WithEvents REPORTE_CXC_PTES1TableAdapter As CONTABILIDAD.DT_VARIOSTableAdapters.REPORTE_CXC_PTES1TableAdapter
End Class
