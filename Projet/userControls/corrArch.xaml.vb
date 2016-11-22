Imports System
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports ProjetBLL
Imports ProjectDTO

Partial Public Class corrArch
	Public Sub New()
		MyBase.New()

		Me.InitializeComponent()

        ' Insert code required on object creation below this point.
        archCorrDG.ItemsSource = New PostaleBLL().GetAllPos
    End Sub

   
    Private Sub rechCorrArchBT_Click() Handles rechCorrArchBT.Click
        bindCor()
    End Sub

    Private Sub bindCor()
        Dim pBll As New PostaleBLL
        Dim eBll As New EmailBLL
        Dim lP As New List(Of Postale)
        Dim lE As New List(Of Email)
        If Not Equals(rechCorrTB.Text, "") Then
            Dim temp = pBll.RecherchePosByNBO(rechCorrTB.Text)
            If temp IsNot Nothing Then
                lP.Add(temp)
            End If
        Else
            Dim aBll As New AssociationBLL
            If parEmailArchRB.IsChecked Then
                Dim a = aBll.RechercheAssByEmail(searchAssArchTB.Text)
                If a IsNot Nothing Then
                    lP = pBll.RecherchePosByAss(a)
                    lE = eBll.RechercheMailByAss(a)
                End If
            ElseIf parTelArchRB.IsChecked Then
                Dim a = aBll.RechercheAssByTel(searchAssArchTB.Text)
                If a IsNot Nothing Then
                    lP = pBll.RecherchePosByAss(a)
                    lE = eBll.RechercheMailByAss(a)
                End If
            End If
        End If
        archCorrDG.ItemsSource = lP
    End Sub

    Private Sub OnHyperlinkClick(ByVal o As Object, ByVal s As RoutedEventArgs)
        Try
            Dim d = TryCast(s.OriginalSource, Hyperlink).NavigateUri
            Process.Start(d.ToString)
        Catch ex As Exception

        End Try
    End Sub

End Class
