Public Interface IForma
    Function CalcularArea() As Double
End Interface

Public Class Rectangulo
    Implements IForma

    Private _lado1 As Double
    Private _lado2 As Double

    Public Sub New(ByVal lado1 As Double, ByVal lado2 As Double)
        _lado1 = lado1
        _lado2 = lado2
    End Sub

    Public Function CalcularArea() As Double Implements IForma.CalcularArea
        Return _lado1 * _lado2
    End Function
End Class

Public Class Circulo
    Implements IForma

    Private _radio As Double

    Public Sub New(ByVal radio As Double)
        _radio = radio
    End Sub

    Public Function CalcularArea() As Double Implements IForma.CalcularArea
        Return Math.PI * _radio * _radio
    End Function
End Class

Public Class FormularioPrincipal
    Inherits System.Windows.Forms.Form

    Private WithEvents botonAgregarRectangulo As System.Windows.Forms.Button
    Private WithEvents botonAgregarCirculo As System.Windows.Forms.Button
    Private listaFormas As System.Windows.Forms.ListBox

    Private formas As New List(Of IForma)

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "Ejemplo de polimorfismo en Windows Forms"
        Me.botonAgregarRectangulo = New System.Windows.Forms.Button
        Me.botonAgregarRectangulo.Text = "Agregar rectángulo"
        Me.botonAgregarRectangulo.Location = New System.Drawing.Point(10, 10)
        Me.botonAgregarCirculo = New System.Windows.Forms.Button
        Me.botonAgregarCirculo.Text = "Agregar círculo"
        Me.botonAgregarCirculo.Location = New System.Drawing.Point(10, 50)
        Me.listaFormas = New System.Windows.Forms.ListBox
        Me.listaFormas.Location = New System.Drawing.Point(10, 90)
        Me.listaFormas.Size = New System.Drawing.Size(200, 100)
        Me.Controls.Add(Me.botonAgregarRectangulo)
        Me.Controls.Add(Me.botonAgregarCirculo)
        Me.Controls.Add(Me.listaFormas)
    End Sub

    Private Sub BotonAgregarRectangulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonAgregarRectangulo.Click
        Dim rectangulo As New Rectangulo(5, 10)
        formas.Add(rectangulo)
        listaFormas.Items.Add("Rectángulo (5 x 10)")
    End Sub

    Private Sub BotonAgregarCirculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonAgregarCirculo.Click
        Dim circulo As New Circulo(3)
        formas.Add(circulo)
        listaFormas.Items.Add("Círculo (radio = 3)")
    End Sub

    Private Sub ListaFormas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listaForm
