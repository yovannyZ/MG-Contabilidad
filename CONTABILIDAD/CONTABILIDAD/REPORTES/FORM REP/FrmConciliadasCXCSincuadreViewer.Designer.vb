<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConciliadasCXCSincuadreViewer
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
        Me.Dt_01BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsConciliadasSinCuadrar = New CONTABILIDAD.DsConciliadasSinCuadrar
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.Dt_01BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsConciliadasSinCuadrar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dt_01BindingSource
        '
        Me.Dt_01BindingSource.DataMember = "Dt_01"
        Me.Dt_01BindingSource.DataSource = Me.DsConciliadasSinCuadrar
        '
        'DsConciliadasSinCuadrar
        '
        Me.DsConciliadasSinCuadrar.DataSetName = "DsConciliadasSinCuadrar"
        Me.DsConciliadasSinCuadrar.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DsConciliadasSinCuadrar_Dt_01"
        ReportDataSource1.Value = Me.Dt_01BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CONTABILIDAD.ReporteConciliadasSincuadre.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(724, 456)
        Me.ReportViewer1.TabIndex = 0
        '
        'FrmConciliadasCXCSincuadreViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 456)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FrmConciliadasCXCSincuadreViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte  de cuadre"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Dt_01BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsConciliadasSinCuadrar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Dt_01BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsConciliadasSinCuadrar As CONTABILIDAD.DsConciliadasSinCuadrar
End Class
