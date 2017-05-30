<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_COMP_MASK_SALDO
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
        Me.SALDOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_COMPROBACION = New CONTABILIDAD.DT_REP_COMPROBACION
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.SALDOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_COMPROBACION, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SALDOBindingSource
        '
        Me.SALDOBindingSource.DataMember = "SALDO"
        Me.SALDOBindingSource.DataSource = Me.DT_REP_COMPROBACION
        '
        'DT_REP_COMPROBACION
        '
        Me.DT_REP_COMPROBACION.DataSetName = "DT_REP_COMPROBACION"
        Me.DT_REP_COMPROBACION.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_COMPROBACION_SALDO"
        ReportDataSource1.Value = Me.SALDOBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_COMP_MASK_SALDO.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(782, 650)
        Me.ReportViewer1.TabIndex = 0
        '
        'REP_COMP_MASK_SALDO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 650)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_COMP_MASK_SALDO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REP_COMP_MASK_SALDO"
        CType(Me.SALDOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_COMPROBACION, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents SALDOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_COMPROBACION As CONTABILIDAD.DT_REP_COMPROBACION
End Class
