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

Partial Public Class addUser



    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()

        ' Insert code required on object creation below this point.
        groupsCB.ItemsSource = New GroupBLL().GetAllGroup
        groupsCB.DisplayMemberPath = "nomGrp"
    End Sub


    Private Sub addBT_Click() Handles addBT.Click
        Dim u As New User
        u.userName = userNameTB.Text
        u.MDP = pwdTB.Text
        u.grp = groupsCB.SelectedItem
        Dim uBll As New UserBLL()
        If uBll.AjouterUser(u) Then
            MsgBox("تمت الاضافة")
        Else
            MsgBox("لم تتم الاضافة")
        End If
    End Sub
End Class
