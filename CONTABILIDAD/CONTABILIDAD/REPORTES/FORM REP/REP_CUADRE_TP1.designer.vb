<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REP_CUADRE_TP1
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
        Me.CUADRE_PCTASXP_VS_TCTASXP_DOC1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_CUADRE_TP1 = New CONTABILIDAD.DT_REP_CUADRE_TP1
        Me.CUADRE_PCTASXP_VS_TCTASXP1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_REP_CUADRE_TP2 = New CONTABILIDAD.DT_REP_CUADRE_TP2
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.CUADRE_PCTASXP_VS_TCTASXP_DOC1TableAdapter = New CONTABILIDAD.DT_REP_CUADRE_TP1TableAdapters.CUADRE_PCTASXP_VS_TCTASXP_DOC1TableAdapter
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.CUADRE_PCTASXP_VS_TCTASXP1TableAdapter = New CONTABILIDAD.DT_REP_CUADRE_TP2TableAdapters.CUADRE_PCTASXP_VS_TCTASXP1TableAdapter
        CType(Me.CUADRE_PCTASXP_VS_TCTASXP_DOC1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_CUADRE_TP1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CUADRE_PCTASXP_VS_TCTASXP1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_REP_CUADRE_TP2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CUADRE_PCTASXP_VS_TCTASXP_DOC1BindingSource
        '
        Me.CUADRE_PCTASXP_VS_TCTASXP_DOC1BindingSource.DataMember = "CUADRE_PCTASXP_VS_TCTASXP_DOC1"
        Me.CUADRE_PCTASXP_VS_TCTASXP_DOC1BindingSource.DataSource = Me.DT_REP_CUADRE_TP1
        '
        'DT_REP_CUADRE_TP1
        '
        Me.DT_REP_CUADRE_TP1.DataSetName = "DT_REP_CUADRE_TP1"
        Me.DT_REP_CUADRE_TP1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CUADRE_PCTASXP_VS_TCTASXP1BindingSource
        '
        Me.CUADRE_PCTASXP_VS_TCTASXP1BindingSource.DataMember = "CUADRE_PCTASXP_VS_TCTASXP1"
        Me.CUADRE_PCTASXP_VS_TCTASXP1BindingSource.DataSource = Me.DT_REP_CUADRE_TP2
        '
        'DT_REP_CUADRE_TP2
        '
        Me.DT_REP_CUADRE_TP2.DataSetName = "DT_REP_CUADRE_TP2"
        Me.DT_REP_CUADRE_TP2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DT_REP_CUADRE_TP1_CUADRE_PCTASXP_VS_TCTASXP_DOC1"
        ReportDataSource1.Value = Me.CUADRE_PCTASXP_VS_TCTASXP_DOC1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CUADRE_TP1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(811, 698)
        Me.ReportViewer1.TabIndex = 0
        '
        'CUADRE_PCTASXP_VS_TCTASXP_DOC1TableAdapter
        '
        Me.CUADRE_PCTASXP_VS_TCTASXP_DOC1TableAdapter.ClearBeforeFill = True
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DT_REP_CUADRE_TP2_CUADRE_PCTASXP_VS_TCTASXP1"
        ReportDataSource2.Value = Me.CUADRE_PCTASXP_VS_TCTASXP1BindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.REP_CUADRE_TP2.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(811, 698)
        Me.ReportViewer2.TabIndex = 1
        '
        'CUADRE_PCTASXP_VS_TCTASXP1TableAdapter
        '
        Me.CUADRE_PCTASXP_VS_TCTASXP1TableAdapter.ClearBeforeFill = True
        '
        'REP_CUADRE_TP1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 698)
        Me.Controls.Add(Me.ReportViewer2)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "REP_CUADRE_TP1"
        Me.Text = "Cuadre Ctas. x Pagar"
        CType(Me.CUADRE_PCTASXP_VS_TCTASXP_DOC1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_CUADRE_TP1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CUADRE_PCTASXP_VS_TCTASXP1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_REP_CUADRE_TP2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CUADRE_PCTASXP_VS_TCTASXP_DOC1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_CUADRE_TP1 As CONTABILIDAD.DT_REP_CUADRE_TP1
    Friend WithEvents CUADRE_PCTASXP_VS_TCTASXP_DOC1TableAdapter As CONTABILIDAD.DT_REP_CUADRE_TP1TableAdapters.CUADRE_PCTASXP_VS_TCTASXP_DOC1TableAdapter
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CUADRE_PCTASXP_VS_TCTASXP1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DT_REP_CUADRE_TP2 As CONTABILIDAD.DT_REP_CUADRE_TP2
    Friend WithEvents CUADRE_PCTASXP_VS_TCTASXP1TableAdapter As CONTABILIDAD.DT_REP_CUADRE_TP2TableAdapters.CUADRE_PCTASXP_VS_TCTASXP1TableAdapter
End Class
