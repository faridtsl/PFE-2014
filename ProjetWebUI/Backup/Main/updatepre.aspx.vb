Imports ProjectDTO
Imports ProjetBLL

Public Class updatepre
    Inherits System.Web.UI.Page

    Dim a As Association
    Dim p As President

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("association") Is Nothing) Then
            Response.Redirect("../default.aspx")
        Else
            a = Session("association")
            p = a.pres
            If Not IsPostBack Then
                If p IsNot Nothing Then
                    nomPreTB.Text = p.nomPres
                    prenomTB.Text = p.prePres
                    telPreTB.Text = p.telPres
                    agePreTB.Text = p.Age
                    If Equals(p.sexe, "M") Then
                        mRB.Checked = True
                    Else
                        fRB.Checked = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Function creerPre() As President
        Dim res As New President
        res.Ass = a
        Dim rB As Boolean = True
        If agePreTB.Text <> "" Then
            res.Age = agePreTB.Text
        End If
        If telPreTB.Text <> "" Then
            res.telPres = telPreTB.Text
        End If
        If prenomTB.Text <> "" Then
            res.prePres = prenomTB.Text
        Else
            rB = False
        End If
        If nomPreTB.Text <> "" Then
            res.nomPres = nomPreTB.Text
        Else
            rB = False
        End If
        If mRB.Checked Then
            res.sexe = "M"
        ElseIf fRB.Checked Then
            res.sexe = "F"
        Else
            rB = False
        End If
        If rB Then
            Return res
        Else
            Return Nothing
        End If
    End Function

    Protected Sub okBT_Click(ByVal sender As Object, ByVal e As EventArgs) Handles okBT.Click
        Dim nP = creerPre()
        If nP Is Nothing Then
            errLB.Text = "'المرجوا تحديد 'الاسم' و 'الجنس"
        Else
            If p Is Nothing Then
                If New PresidentBLL().AjouterPresident(nP) Then
                    errLB.Text = "تم بنجاح"
                Else
                    errLB.Text = "لم تتم اضافة الرئيس"
                End If
            Else
                nP.Id = p.Id
                If New PresidentBLL().ModifierPre(nP) Then
                    errLB.Text = "تم بنجاح"
                Else
                    errLB.Text = "لم يتم تعديل الرئيس"
                End If
            End If
        End If
        a = New AssociationBLL().RechercheAssById(a.ID)
        Session("association") = a
    End Sub


End Class