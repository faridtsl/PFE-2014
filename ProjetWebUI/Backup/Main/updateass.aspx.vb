Imports ProjectDTO
Imports ProjetBLL

Public Class updateass
    Inherits System.Web.UI.Page

    Dim a As Association

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("association") Is Nothing) Then
            Response.Redirect("../default.aspx")
        Else
            a = Session("association")
            If Not IsPostBack Then
                telAssTB.Text = a.telAss
                siteTB.Text = a.site
                datCreaTB.Text = a.datCrea
                adrAssTB.Text = a.adrAss
                vilCB.DataSource = New VilleBLL().GetAllVille()
                vilCB.DataBind()
                vilCB.Items.Insert(0, New ListItem("--اختيار--"))
            End If
        End If
    End Sub

    Private Function creerAss() As Association
        Dim res As New Association
        res.ID = a.ID
        If Not Equals(telAssTB.Text, "") Then
            res.telAss = telAssTB.Text
        End If
        If Not Equals(siteTB.Text, "") Then
            res.site = siteTB.Text
        End If
        If Not Equals(datCreaTB.Text, "") Then
            res.datCrea = datCreaTB.Text
        End If
        If Not Equals(adrAssTB.Text, "") Then
            res.adrAss = adrAssTB.Text
        End If
        If Not Equals(vilCB.SelectedValue, "--اختيار--") Then
            res.ville = New VilleBLL().RechercheVilleById(vilCB.SelectedValue)
        Else
            res.ville = a.ville
        End If
        Return res
    End Function

    Protected Sub confirmerBT_Click(ByVal sender As Object, ByVal e As EventArgs) Handles confirmerBT.Click
        Dim aM = creerAss()
        If New AssociationBLL().ModifierAss(aM) Then
            a = New AssociationBLL().RechercheAssById(a.ID)
            Session("association") = a
            errLB.Text = "تم بنجاح"
        Else
            errLB.Text = "لم يتم التغيير"
        End If
    End Sub


End Class