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

Partial Public Class GestionUsers
	Public Sub New()
		MyBase.New()

		Me.InitializeComponent()

        ' Insert code required on object creation below this point.
        userDG.ItemsSource = New UserBLL().GetAllUsers
    End Sub

    Private Sub suppBT_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles suppBT.Click
        If New UserBLL().SupprimerUser(userDG.SelectedItem) Then
            MsgBox("تم")
            userDG.ItemsSource = New UserBLL().GetAllUsers
        Else
            MsgBox("لم تتم العملية بنجاح")
        End If
    End Sub


    Private Sub addBT_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles addBT.Click
        Dim w As New addUser
        w.ShowDialog()
    End Sub


    Private Sub majBT_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles majBT.Click
        Dim w As New majUser(userDG.SelectedItem)
        w.ShowDialog()
    End Sub

End Class
