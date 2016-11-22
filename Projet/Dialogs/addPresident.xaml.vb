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

Partial Public Class addPresident

    Dim genre As Char

    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()

        ' Insert code required on object creation below this point.
        genre = "n"
    End Sub




    Private Sub mRB_Checked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles mRB.Checked
        genre = "M"
    End Sub


    Private Sub fRB_Checked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles fRB.Checked
        genre = "F"
    End Sub

    Private Function creerPres() As President
        Dim p As New President
        p.nomPres = nomPresTB.Text
        p.prePres = prenomTB.Text
        p.sexe = genre
        p.telPres = telPresTB.Text
        If Not Equals(ageTB.Text, "") Then
            p.Age = Integer.Parse(ageTB.Text)
        End If
        Return p
    End Function

    Private Sub ajtPresBT_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles ajtPresBT.Click
        If genre = "n" Or Equals(nomPresTB.Text, "") Or Equals(prenomTB.Text, String.Empty) Then
            MsgBox("المرجوا اكمال الخانات")
        Else
            currentPresident = creerPres()
            Me.Close()
        End If
    End Sub

End Class
