<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CUADRE_TCON_TCTAS
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.CUADRE_TCON_VS_TCTASXCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_CUADRE_TCON_TCTAS = New CONTABILIDAD.DT_CUADRE_TCON_TCTAS
        Me.CUADRE_TCON_VS_TCTASXPBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.CUADRE_TCON_VS_TCTASXCTableAdapter = New CONTABILIDAD.DT_CUADRE_TCON_TCTASTableAdapters.CUADRE_TCON_VS_TCTASXCTableAdapter
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.CUADRE_TCON_VS_TCTASXPTableAdapter = New CONTABILIDAD.DT_CUADRE_TCON_TCTASTableAdapters.CUADRE_TCON_VS_TCTASXPTableAdapter
        CType(Me.CUADRE_TCON_VS_TCTASXCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_CUADRE_TCON_TCTAS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CUADRE_TCON_VS_TCTASXPBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CUADRE_TCON_VS_TCTASXCBindingSource
        '
        Me.CUADRE_TCON_VS_TCTASXCBindingSource.DataMember = "CUADRE_TCON_VS_TCTASXC"
        Me.CUADRE_TCON_VS_TCTASXCBindingSource.DataSource = Me.DT_CUADRE_TCON_TCTAS
        '
        'DT_CUADRE_TCON_TCTAS
        '
        Me.DT_CUADRE_TCON_TCTAS.DataSetName = "DT_CUADRE_TCON_TCTAS"
        Me.DT_CUADRE_TCON_TCTAS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CUADRE_TCON_VS_TCTASXPBindingSource
        '
        Me.CUADRE_TCON_VS_TCTASXPBindingSource.DataMember = "CUADRE_TCON_VS_TCTASXP"
        Me.CUADRE_TCON_VS_TCTASXPBindingSource.DataSource = Me.DT_CUADRE_TCON_TCTAS
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_CUADRE_TCON_TCTAS_CUADRE_TCON_VS_TCTASXC"
        ReportDataSource1.Value = Me.CUADRE_TCON_VS_TCTASXCBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CUADRE_TCON_TCTAS_COBRAR.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(811, 698)
        Me.ReportViewer1.TabIndex = 0
        '
        'CUADRE_TCON_VS_TCTASXCTableAdapter
        '
        Me.CUADRE_TCON_VS_TCTASXCTableAdapter.ClearBeforeFill = True
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DT_CUADRE_TCON_TCTAS_CUADRE_TCON_VS_TCTASXP"
        ReportDataSource2.Value = Me.CUADRE_TCON_VS_TCTASXPBindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CUADRE_TCON_TCTAS_PAGAR.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(811, 698)
        Me.ReportViewer2.TabIndex = 1
        '
        'CUADRE_TCON_VS_TCTASXPTableAdapter
        '
        Me.CUADRE_TCON_VS_TCTASXPTableAdapter.ClearBeforeFill = True
        '
        'REP_CUADRE_TCON_TCTAS_COBRAR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 698)
        Me.Controls.Add(Me.ReportViewer2)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CUADRE_TCON_TCTAS_COBRAR"
        CType(Me.CUADRE_TCON_VS_TCTASXCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_CUADRE_TCON_TCTAS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CUADRE_TCON_VS_TCTASXPBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CUADRE_TCON_VS_TCTASXCBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_CUADRE_TCON_TCTAS As CONTABILIDAD.DT_CUADRE_TCON_TCTAS
    Friend WithEvents CUADRE_TCON_VS_TCTASXCTableAdapter As CONTABILIDAD.DT_CUADRE_TCON_TCTASTableAdapters.CUADRE_TCON_VS_TCTASXCTableAdapter
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CUADRE_TCON_VS_TCTASXPBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CUADRE_TCON_VS_TCTASXPTableAdapter As CONTABILIDAD.DT_CUADRE_TCON_TCTASTableAdapters.CUADRE_TCON_VS_TCTASXPTableAdapter
End Class
