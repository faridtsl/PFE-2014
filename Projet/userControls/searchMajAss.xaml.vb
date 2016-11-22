Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports ProjectDTO
Imports ProjetBLL

Partial Public Class searchMajAss
	Public Sub New()
		MyBase.New()

		Me.InitializeComponent()

		' Insert code required on object creation below this point.
	End Sub

    Private Sub majAssBT_Click() Handles majAssBT.Click
        currentAssociation = rechAssDG.SelectedItem
        If currentAssociation Is Nothing Then
            MsgBox("المرجوا اختيار جمعية")
        Else
            Dim w As majWindow = New majWindow()
            w.ShowDialog()
        End If
    End Sub

    Private Sub rechAssCorrBT_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles rechAssCorrBT.Click
        bindAss()
    End Sub

    Private Sub bindAss()
        Dim aBll As New AssociationBLL()
        Dim lAss As New List(Of Association)
        If Not Equals(emailTB.Text, "") Then
            Dim temp = aBll.RechercheAssByEmail(emailTB.Text)
            If temp IsNot Nothing Then
                lAss.Add(temp)
            End If
        ElseIf Not Equals(nameTB.Text, "") Then
            lAss = aBll.RechercheAssByNom(nameTB.Text)
        Else
            MsgBox("المرجوا ادخال معلومات البحث")
        End If
        rechAssDG.ItemsSource = lAss
    End Sub

End Class
