<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_PY
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
        Me.DT_PY = New CONTABILIDAD.DT_PY
        Me.REPORTE_PROYECTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.REPORTE_PROYECTOTableAdapter = New CONTABILIDAD.DT_PYTableAdapters.REPORTE_PROYECTOTableAdapter
        CType(Me.DT_PY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REPORTE_PROYECTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_PY_REPORTE_PROYECTO"
        ReportDataSource1.Value = Me.REPORTE_PROYECTOBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_PY.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(727, 608)
        Me.ReportViewer1.TabIndex = 0
        '
        'DT_PY
        '
        Me.DT_PY.DataSetName = "DT_PY"
        Me.DT_PY.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'REPORTE_PROYECTOBindingSource
        '
        Me.REPORTE_PROYECTOBindingSource.DataMember = "REPORTE_PROYECTO"
        Me.REPORTE_PROYECTOBindingSource.DataSource = Me.DT_PY
        '
        'REPORTE_PROYECTOTableAdapter
        '
        Me.REPORTE_PROYECTOTableAdapter.ClearBeforeFill = True
        '
        'REP_PY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 608)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_PY"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        CType(Me.DT_PY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REPORTE_PROYECTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_PROYECTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_PY As CONTABILIDAD.DT_PY
    Friend WithEvents REPORTE_PROYECTOTableAdapter As CONTABILIDAD.DT_PYTableAdapters.REPORTE_PROYECTOTableAdapter
End Class
