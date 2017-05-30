<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_DIFERIDO
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
        Me.REPORTE_I_DIFERIDOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_DIFERIDOS = New CONTABILIDAD.DT_REP_DIFERIDOS
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.REPORTE_I_DIFERIDOTableAdapter = New CONTABILIDAD.DT_REP_DIFERIDOSTableAdapters.REPORTE_I_DIFERIDOTableAdapter
        CType(Me.REPORTE_I_DIFERIDOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_DIFERIDOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'REPORTE_I_DIFERIDOBindingSource
        '
        Me.REPORTE_I_DIFERIDOBindingSource.DataMember = "REPORTE_I_DIFERIDO"
        Me.REPORTE_I_DIFERIDOBindingSource.DataSource = Me.DT_REP_DIFERIDOS
        '
        'DT_REP_DIFERIDOS
        '
        Me.DT_REP_DIFERIDOS.DataSetName = "DT_REP_DIFERIDOS"
        Me.DT_REP_DIFERIDOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_DIFERIDOS_REPORTE_I_DIFERIDO"
        ReportDataSource1.Value = Me.REPORTE_I_DIFERIDOBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_DIFERIDO.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(707, 384)
        Me.ReportViewer1.TabIndex = 0
        '
        'REPORTE_I_DIFERIDOTableAdapter
        '
        Me.REPORTE_I_DIFERIDOTableAdapter.ClearBeforeFill = True
        '
        'REP_DIFERIDO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 384)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_DIFERIDO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP_DIFERIDO"
        CType(Me.REPORTE_I_DIFERIDOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_DIFERIDOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents REPORTE_I_DIFERIDOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_DIFERIDOS As CONTABILIDAD.DT_REP_DIFERIDOS
    Friend WithEvents REPORTE_I_DIFERIDOTableAdapter As CONTABILIDAD.DT_REP_DIFERIDOSTableAdapters.REPORTE_I_DIFERIDOTableAdapter
End Class
