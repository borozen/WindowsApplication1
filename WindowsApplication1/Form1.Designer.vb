<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SeleccionarUnXML = New System.Windows.Forms.Button()
        Me.NombreArchivo = New System.Windows.Forms.Label()
        Me.ProcesarElXML = New System.Windows.Forms.Button()
        Me.NombreDelCasoDePrueba = New System.Windows.Forms.Label()
        Me.NombreArchivoXMLCompleto = New System.Windows.Forms.Label()
        Me.Paso = New System.Windows.Forms.Label()
        Me.Prefijo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'SeleccionarUnXML
        '
        Me.SeleccionarUnXML.Location = New System.Drawing.Point(12, 12)
        Me.SeleccionarUnXML.Name = "SeleccionarUnXML"
        Me.SeleccionarUnXML.Size = New System.Drawing.Size(76, 30)
        Me.SeleccionarUnXML.TabIndex = 0
        Me.SeleccionarUnXML.Tag = ""
        Me.SeleccionarUnXML.Text = "Abrir XML"
        Me.SeleccionarUnXML.UseVisualStyleBackColor = True
        '
        'NombreArchivo
        '
        Me.NombreArchivo.AutoSize = True
        Me.NombreArchivo.Location = New System.Drawing.Point(17, 50)
        Me.NombreArchivo.Name = "NombreArchivo"
        Me.NombreArchivo.Size = New System.Drawing.Size(0, 13)
        Me.NombreArchivo.TabIndex = 1
        '
        'ProcesarElXML
        '
        Me.ProcesarElXML.Location = New System.Drawing.Point(13, 71)
        Me.ProcesarElXML.Name = "ProcesarElXML"
        Me.ProcesarElXML.Size = New System.Drawing.Size(75, 23)
        Me.ProcesarElXML.TabIndex = 2
        Me.ProcesarElXML.Text = "Procesar"
        Me.ProcesarElXML.UseVisualStyleBackColor = True
        '
        'NombreDelCasoDePrueba
        '
        Me.NombreDelCasoDePrueba.AutoSize = True
        Me.NombreDelCasoDePrueba.Location = New System.Drawing.Point(18, 105)
        Me.NombreDelCasoDePrueba.Name = "NombreDelCasoDePrueba"
        Me.NombreDelCasoDePrueba.Size = New System.Drawing.Size(0, 13)
        Me.NombreDelCasoDePrueba.TabIndex = 3
        '
        'NombreArchivoXMLCompleto
        '
        Me.NombreArchivoXMLCompleto.AutoSize = True
        Me.NombreArchivoXMLCompleto.Location = New System.Drawing.Point(13, 236)
        Me.NombreArchivoXMLCompleto.Name = "NombreArchivoXMLCompleto"
        Me.NombreArchivoXMLCompleto.Size = New System.Drawing.Size(0, 13)
        Me.NombreArchivoXMLCompleto.TabIndex = 4
        '
        'Paso
        '
        Me.Paso.AutoSize = True
        Me.Paso.Location = New System.Drawing.Point(19, 130)
        Me.Paso.Name = "Paso"
        Me.Paso.Size = New System.Drawing.Size(0, 13)
        Me.Paso.TabIndex = 5
        '
        'Prefijo
        '
        Me.Prefijo.Location = New System.Drawing.Point(115, 152)
        Me.Prefijo.Name = "Prefijo"
        Me.Prefijo.Size = New System.Drawing.Size(100, 20)
        Me.Prefijo.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 155)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Prefijo:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Prefijo)
        Me.Controls.Add(Me.Paso)
        Me.Controls.Add(Me.NombreArchivoXMLCompleto)
        Me.Controls.Add(Me.NombreDelCasoDePrueba)
        Me.Controls.Add(Me.ProcesarElXML)
        Me.Controls.Add(Me.NombreArchivo)
        Me.Controls.Add(Me.SeleccionarUnXML)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SeleccionarUnXML As Button
    Friend WithEvents NombreArchivo As Label
    Friend WithEvents ProcesarElXML As Button
    Friend WithEvents NombreDelCasoDePrueba As Label
    Friend WithEvents NombreArchivoXMLCompleto As Label
    Friend WithEvents Paso As Label
    Friend WithEvents Prefijo As TextBox
    Friend WithEvents Label1 As Label
End Class
