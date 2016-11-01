Imports System.IO
Imports System.Xml.XPath
Imports System.Xml
Imports Microsoft.Office.Interop

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles SeleccionarUnXML.Click

        Dim unStream As Stream = Nothing
        Dim dialogoAbrirArchivo As New OpenFileDialog()

        dialogoAbrirArchivo.InitialDirectory = "c:\Users\boroz_000\OneDrive\Compartida\UnidAR\Athelia\François-Athelia\LCTA\"
        dialogoAbrirArchivo.Filter = "Archivos XML (*.xml)|*.xml"
        dialogoAbrirArchivo.FilterIndex = 2
        dialogoAbrirArchivo.RestoreDirectory = True

        If dialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                unStream = dialogoAbrirArchivo.OpenFile()
                If (unStream IsNot Nothing) Then
                    ' Insert code to read the stream here.
                    NombreArchivo.Text = dialogoAbrirArchivo.SafeFileName
                    NombreArchivoXMLCompleto.Text = dialogoAbrirArchivo.FileName
                    'NombreArchivo.Text = "NOMBRE DEL ARCHIVO"
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (unStream IsNot Nothing) Then
                    unStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub ProcesarElXML_Click(sender As Object, e As EventArgs) Handles ProcesarElXML.Click

        NombreDelCasoDePrueba.Text = Me.NombreArchivoXMLCompleto.Text
        Dim documentoXML As XPathDocument = New XPathDocument(Me.NombreArchivoXMLCompleto.Text)
        Dim navegador As XPathNavigator = documentoXML.CreateNavigator()
        Dim manejador As XmlNamespaceManager = New XmlNamespaceManager(navegador.NameTable)

        Dim tituloCaso As String = ""
        Dim tituloPaso As String = ""
        Dim tituloResultado As String = ""

        Dim laPresentacion As PowerPoint.Presentation
        Dim oApp As PowerPoint.Application

        'Dim nombreDelCaso As XPathExpression = XPathExpression.Compile("/testsuite[1]/testsuite[1]/testsuite[1]/testcase[1]/@name")
        'nombreDelCaso.SetContext(manejador)
        'Me.NombreDelCasoDePrueba.Text = Evalua(nombreDelCaso, navegador)

        Dim txtSuite2 As String = "txt"
        Dim txtSuite3 As String = "txt"
        Dim txtCaso As String = "txt"
        Dim txtPaso As String = "txt"
        Dim cuentaCasos As Integer = 0

        Dim l As Integer = 0
        Do 'Primer test suite, que es el segundo
            l = l + 1
            Dim suite2 As XPathExpression = XPathExpression.Compile("/testsuite[1]/testsuite[" + Convert.ToString(l) + "]/@name")
            suite2.SetContext(manejador)
            txtSuite2 = Evalua(suite2, navegador)
            If txtSuite2 = "" Then
                Exit Do
            Else
                Dim k As Integer = 0
                Do 'Segundo test suite, que es el tercero
                    k = k + 1
                    Dim suite3 As XPathExpression = XPathExpression.Compile("/testsuite[1]/testsuite[" + Convert.ToString(l) + "]/testsuite[" + Convert.ToString(k) + "]/@name")
                    suite3.SetContext(manejador)
                    txtSuite3 = Evalua(suite3, navegador)
                    If txtSuite3 = "" Then
                        Exit Do
                    Else
                        Dim j As Integer = 0
                        Do 'Casos de prueba
                            j = j + 1
                            Dim casoDePrueba As XPathExpression = XPathExpression.Compile("/testsuite[1]/testsuite[" + Convert.ToString(l) + "]/testsuite[" + Convert.ToString(k) + "]/testcase[" + Convert.ToString(j) + "]/@name")
                            casoDePrueba.SetContext(manejador)
                            txtCaso = Evalua(casoDePrueba, navegador)
                            If txtCaso = "" Then
                                Exit Do
                            Else
                                'Crear una nueva presentación con una diapositiva de título
                                GC.Collect()
                                GC.WaitForPendingFinalizers()
                                cuentaCasos = cuentaCasos + 1
                                oApp = New PowerPoint.Application
                                laPresentacion = NuevaPresentacion(Convert.ToString(cuentaCasos) + "-" + Evalua(casoDePrueba, navegador), oApp)
                                'Me.NombreDelCasoDePrueba.Text = Evalua(casoDePrueba, navegador)
                                Dim i As Integer = 0
                                Do 'Pasos
                                    i = i + 1
                                    Dim pasoDelCaso As XPathExpression = XPathExpression.Compile("/testsuite[1]/testsuite[" + Convert.ToString(l) + "]/testsuite[" + Convert.ToString(k) + "]/testcase[" + Convert.ToString(j) + "]/steps[1]/step[" + Convert.ToString(i) + "]/actions")
                                    Dim resultadoDelCaso As XPathExpression = XPathExpression.Compile("/testsuite[1]/testsuite[" + Convert.ToString(l) + "]/testsuite[" + Convert.ToString(k) + "]/testcase[" + Convert.ToString(j) + "]/steps[1]/step[" + Convert.ToString(i) + "]/expectedresults")
                                    pasoDelCaso.SetContext(manejador)
                                    resultadoDelCaso.SetContext(manejador)
                                    txtPaso = Evalua(pasoDelCaso, navegador)
                                    tituloResultado = Evalua(resultadoDelCaso, navegador)
                                    If txtPaso = "" Then
                                        'Se acabaron los pasos, guardar y cerrar la presentación creada
                                        guardarycerrar(laPresentacion, Convert.ToString(cuentaCasos) + "-" + Evalua(casoDePrueba, navegador))

                                        laPresentacion.Close()
                                        laPresentacion = Nothing
                                        GC.Collect()
                                        GC.WaitForPendingFinalizers()
                                        oApp.Quit()
                                        Exit Do
                                    Else
                                        'Crear una nueva diapositiva con el paso y resultado esperado
                                        NuevaDiapositiva(laPresentacion, txtPaso, tituloResultado)
                                        Me.Paso.Text = Convert.ToString(i) + ": " + txtPaso
                                    End If
                                Loop
                            End If
                        Loop
                    End If
                Loop
            End If
        Loop

        'Dim txt As String = navegador.Evaluate(pasoDelCaso).ToString

        'navegador.SelectSingleNode(pasoDelCaso) Then
        'Me.Paso.Text = Evalua(pasoDelCaso, navegador)

        'navegador.MoveToChild("testsuite", "")
        'navegador.MoveToChild("testsuite", "")
        'navegador.MoveToChild("testsuite", "")
        'If navegador.MoveToChild("testcase", "") Then
        'NombreDelCasoDePrueba.Text = "True"
        'Else
        'NombreDelCasoDePrueba.Text = "False"
        'End If

    End Sub

    Public Shared Function Evalua(ByVal expresion As XPathExpression, ByVal navegador As XPathNavigator)
        Select Case expresion.ReturnType
            Case XPathResultType.Number
                Return navegador.Evaluate(expresion)

            Case XPathResultType.NodeSet
                Dim nodos As XPathNodeIterator = navegador.Select(expresion)
                While nodos.MoveNext()
                    Return nodos.Current.ToString()
                End While

            Case XPathResultType.Boolean
                If CType(navegador.Evaluate(expresion), Boolean) Then
                    Return "Cierto"
                End If

            Case XPathResultType.String
                Return navegador.Evaluate(expresion)

        End Select
    End Function

    Public Shared Function NuevaPresentacion(ByVal titulo As String, PowerPointApp As PowerPoint.Application) As PowerPoint.Presentation

        Dim oPres As PowerPoint.Presentation
        Dim oSlide As PowerPoint.Slide

        'Iniciar PowerPoint.
        'oApp = New PowerPoint.Application()
        PowerPointApp.Visible = True
        'Hacer una nueva presentación
        oPres = PowerPointApp.Presentations.Add
        'Ahora, una nueva diapositiva
        oSlide = oPres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutTitle)
        'Se le pone el título de la presentación, que es el nombre del caso
        With oSlide.Shapes.Item(1).TextFrame.TextRange
            .Text = Form1.Prefijo.Text + "-" + titulo
        End With
        oSlide = Nothing
        Return oPres
    End Function

    Public Shared Sub NuevaDiapositiva(ByVal presentacion As PowerPoint.Presentation, ByVal paso As String, ByVal resultado As String)
        Dim oPres As PowerPoint.Presentation = presentacion
        Dim oSlide As PowerPoint.Slide

        oSlide = oPres.Slides.Add(oPres.Slides.Count + 1, PowerPoint.PpSlideLayout.ppLayoutTwoObjects)
        With oSlide.Shapes.Item(1).TextFrame.TextRange
            .Text = "Step: " + paso + vbCrLf + "Result: " + resultado
            .Font.Size = 14
        End With
        oPres = Nothing
    End Sub

    Public Shared Sub guardarycerrar(ByVal presentacion As PowerPoint.Presentation, ByVal nombre As String)
        Dim oPres As PowerPoint.Presentation = presentacion

        oPres.SaveAs("C:\Users\boroz_000\Desktop\Presentaciones\" + Form1.Prefijo.Text + "-" + nombre)
        'oPres.Close()
        'oPres = Nothing
    End Sub
End Class
