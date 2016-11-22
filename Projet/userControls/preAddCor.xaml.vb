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

Partial Public Class preAddCor
	Public Sub New()
		MyBase.New()

		Me.InitializeComponent()

        ' Insert code required on object creation below this point.
        chooseAssBT.IsEnabled = False
	End Sub

	Private Sub addNewAssBT_Click() Handles addNewAssBT.Click
        Dim w As addAssWindow = New addAssWindow()
        w.ShowDialog()
    End Sub

    Private Sub chooseAssBT_Click() Handles chooseAssBT.Click
        currentAssociation = assDG.SelectedItem
        fPrincipal.Source = New System.Uri("userControls/addCorr.xaml", UriKind.Relative)
    End Sub

    Private Sub searchBT_Click() Handles searchBT.Click
        If Not (emailRB.IsChecked) And Not (nomRB.IsChecked) And Not (telRB.IsChecked) Then
            MsgBox("choose")
        Else
            bindAss()
        End If
    End Sub

    Private Sub bindAss()
        Dim aBll As New AssociationBLL
        Dim l As New List(Of Association)
        Dim temp As Association
        If emailRB.IsChecked Then
            temp = aBll.RechercheAssByEmail(rechAssTB.Text)
            If temp IsNot Nothing Then
                l.Add(temp)
            End If
        ElseIf telRB.IsChecked Then
            temp = aBll.RechercheAssByTel(rechAssTB.Text)
            If temp IsNot Nothing Then
                l.Add(temp)
            End If
        ElseIf nomRB.IsChecked Then
            l = aBll.RechercheAssByNom(rechAssTB.Text)
        End If
        If l Is Nothing Then
            assDG.ItemsSource = New List(Of Association)
        Else
            assDG.ItemsSource = l
        End If
    End Sub

    Private Sub assDG_SelectionChanged() Handles assDG.SelectionChanged
        If assDG.SelectedItem IsNot Nothing Then
            If Equals(assDG.SelectedItem.GetType, New Association().GetType) Then
                chooseAssBT.IsEnabled = True
            Else
                chooseAssBT.IsEnabled = False
            End If
        End If
    End Sub

End Class
