Imports ProjectDTO
Imports ProjetBLL

Public Class recuperation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub demandeBT_Click() Handles demandeBT.Click
        If New CompteBLL().Recuperer(emailTB.Text) Then
            emailNotFoundLB.Text = "تم ارسال رسالة لبريدكم الالكتروني"
        Else
            emailNotFoundLB.Text = "ايميل غير متواجد"
        End If
    End Sub

End Class