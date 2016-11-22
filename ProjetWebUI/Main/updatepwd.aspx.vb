Imports ProjectDTO
Imports ProjetBLL



Public Class updatepwd
    Inherits System.Web.UI.Page

    Dim a As Association
    Dim c As Compte

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("association") Is Nothing) Then
            Response.Redirect("../default.aspx")
        Else
            a = Session("association")
            c = New CompteBLL().RechercheComByAss(a)
        End If
    End Sub

    Private Function creerCompte() As Compte
        Dim com As New Compte
        Dim temp = New CompteBLL().RechercheComByAss(a)
        com.ID = temp.ID
        com.ass = a
        com.login = a.emailAss
        com.MDP = cnmdpTB.Text
        Return com
    End Function


    Protected Sub okBT_Click(ByVal sender As Object, ByVal e As EventArgs) Handles okBT.Click
        Dim anC As New Compte
        anC.login = a.emailAss
        anC.MDP = amdpTB.Text
        If New CompteBLL().Authentifier(anC) Then
            If Equals(cnmdpTB.Text, nmdpTB.Text) Then
                Dim cm = creerCompte()
                Dim t = New CompteBLL().ModifierCom(cm)
                errLB.Text = "تم تغيير كلمة المرور بنجاح"
            Else
                errLB.Text = "المرجوا التأكد من كلمة المرور الجديدة و تأكيدها"
            End If
        Else
            errLB.Text = "كلمة المرور خاطئة"
        End If
    End Sub


End Class