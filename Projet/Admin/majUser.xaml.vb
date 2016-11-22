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

Partial Public Class majUser

    Dim user As User

    Public Sub New(ByVal u As User)
        Me.New()
        user = u
    End Sub

    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()

        ' Insert code required on object creation below this point.
        groupsCB.ItemsSource = New GroupBLL().GetAllGroup()
        groupsCB.DisplayMemberPath = "nomGrp"
    End Sub

    Private Sub onLoad() Handles Me.Loaded
        If user Is Nothing Then
            Me.Close()
        Else
            pwdTB.Text = user.MDP
            userNameTB.Text = user.userName
        End If
    End Sub


    Private Sub majBT_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles majBT.Click
        Dim u As New User
        u.idUser = user.idUser
        If groupsCB.SelectedItem IsNot Nothing Then
            u.grp = groupsCB.SelectedItem
        Else
            u.grp = user.grp
        End If
        If pwdTB.Text <> Nothing Then
            u.MDP = pwdTB.Text
        Else
            u.MDP = user.MDP
        End If
        If New UserBLL().ModifierUser(u) Then
            MsgBox("DONE")
        Else
            MsgBox("FAIL")
        End If
    End Sub

End Class
