Imports System
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports ProjectDTO
Imports ProjetBLL

Partial Public Class majPres

    Dim genre As Char

    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()

        ' Insert code required on object creation below this point.
        bindControls()
    End Sub

    Private Sub bindControls()
        nomPresTB.Text = currentPresident.nomPres
        prenomTB.Text = currentPresident.prePres
        telPresTB.Text = currentPresident.telPres
        ageTB.Text = currentPresident.Age
        If currentPresident.sexe = "M" Then
            mRB.IsChecked = True
        ElseIf currentPresident.sexe = "F" Then
            fRB.IsChecked = True
        End If
    End Sub

    Private Sub majPresBT_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles majPresBT.Click
        Dim pBll As New PresidentBLL()
        Dim s = "هل انت متأكد من تغيير الرئيس"
        Dim p = creerPres()
        Dim result = MessageBox.Show(s, "", MessageBoxButton.YesNoCancel)
        If result = MessageBoxResult.Yes Then
            If pBll.ModifierPre(p) Then
                MsgBox("تم التعديل بنجاح")
            Else
                MsgBox("لم يتم التعديل")
            End If
        ElseIf result = MessageBoxResult.No Then
            Me.Close()
        ElseIf result = MessageBoxResult.Cancel Then

        End If
    End Sub

    Private Sub mRB_Checked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles mRB.Checked
        genre = "M"
    End Sub


    Private Sub fRB_Checked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles fRB.Checked
        genre = "F"
    End Sub

    Private Function creerPres() As President
        Dim p As New President
        p.Ass = currentAssociation
        p.Id = currentPresident.Id
        p.nomPres = nomPresTB.Text
        p.prePres = prenomTB.Text
        p.sexe = genre
        p.telPres = telPresTB.Text
        If Not Equals(ageTB.Text, "") Then
            p.Age = Integer.Parse(ageTB.Text)
        End If
        Return p
    End Function

End Class
