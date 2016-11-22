Imports ProjectDTO
Imports ProjetDAL

Public Class AssociationBLL
    Inherits Utile

    Private Function verifierAss(ByVal a As Association) As Boolean
        Return verifierString(a.nomAss) And verifierString(a.adrAss) And verifierVille(a.ville)
    End Function

    Private Function verifierAssSupp(ByVal a As Association) As Boolean
        Return verifierString(a.datCrea) And verifierString(a.emailAss) And verifierString(a.site) And verifierString(a.telAss) And verifierPres(a.pres)
    End Function

    Public Function estComplet(ByVal a As Association) As Boolean
        Return verifierAsso(a) And verifierAss(a) And verifierAssSupp(a)
    End Function

    Friend Function Recuperer(ByVal c As Compte) As Boolean
        Dim site As String = "www.mcrp.gov.ma"
        Dim mdp As String = c.MDP
        Dim login As String = c.login
        Dim lien As String = "www.mcrp.gov.ma/app"

        Dim e As String = c.login
        Dim o As String = "تذكير بكلمة مرور حسابكم على موقع وزارة العلاقات مع البرلمان والمجتمع المدني"

        Dim t As String = "حساب  " & c.ass.nomAss & " على الموقع " _
                            & vbNewLine & " " & site & "" _
                            & vbNewLine & ": اسم المستخدم" _
                            & vbNewLine & "" & login & "" _
                            & vbNewLine & ": كلمة المرور " _
                            & vbNewLine & " " & mdp & "" _
                            & vbNewLine & ": رابط الدخول الى حسابكم" _
                            & vbNewLine & " " & lien & "" & vbNewLine & ""


        Return envoyerMail(e, o, t)
    End Function


    Friend Function Notifier(ByVal c As Compte) As Boolean
        Dim site As String = "www.mcrp.gov.ma"
        Dim mdp As String = c.MDP
        Dim login As String = c.login
        Dim lien As String = "www.mcrp.gov.ma/app"

        Dim e As String = c.login
        Dim o As String = "حساب على موقع وزارة العلاقات مع البرلمان والمجتمع المدني"

        Dim t As String = "لقد تم انشاء حساب ل " & c.ass.nomAss & " على الموقع " _
                            & vbNewLine & " " & site & "" _
                            & vbNewLine & ": اسم المستخدم" _
                            & vbNewLine & "" & login & "" _
                            & vbNewLine & ": كلمة المرور " _
                            & vbNewLine & " " & mdp & "" _
                            & vbNewLine & ": رابط الدخول الى حسابكم" _
                            & vbNewLine & " " & lien & "" & vbNewLine & ""


        Return envoyerMail(e, o, t)
    End Function


    Friend Function NotifierDecision(ByVal d As Decision) As Boolean
        Dim lien As String = "www.mcrp.gov.ma/app"
        Dim obCor As String = d.Cor.objet
        Dim dec As String = d.type.libTyp
        Dim decinfo As String
        If (d.infDec IsNot String.Empty) Then
            decinfo = d.infDec
        Else
            decinfo = "لا توجد"
        End If

        Dim e As String = d.Cor.ass.emailAss
        Dim o As String = "اشعار باتخاذ قرار"

        Dim t As String = "لقد تم اتخاذ قرار على مراسلتكم بعنوان  " _
                            & vbNewLine & " " & obCor & "" _
                            & vbNewLine & ": نوع القرار" _
                            & vbNewLine & "" & dec & "" _
                            & vbNewLine & ": معلومات اضافية " _
                            & vbNewLine & " " & decinfo & "" _
                            & vbNewLine & ": رابط الدخول الى حسابكم" _
                            & vbNewLine & " " & lien & "" & vbNewLine & ""


        Return envoyerMail(e, o, t)
    End Function


    Friend Function EnvoyerAcc(ByVal c As Correspondance) As Boolean
        Dim lien As String = "www.mcrp.gov.ma/app"
        Dim obCor As String = c.objet
        Dim d As String = c.datRec.Value.Date.ToString
        Dim site As String = "www.mcrp.gov.ma"

        Dim e As String = c.ass.emailAss
        Dim o As String = "اشعار بوصول مراسلة"

        Dim t As String = "وصول مراسلتكم بعنوان  " _
                            & vbNewLine & " " & obCor & "" _
                            & vbNewLine & ": بتاريخ" _
                            & vbNewLine & "" & d & "" _
                            & vbNewLine & ": يمكنكم تتبع مراسلتكم في موقع الوزارة عبر حسابكم " _
                            & vbNewLine & " " & site & "" _
                            & vbNewLine & ": رابط الدخول الى حسابكم" _
                            & vbNewLine & " " & lien & "" & vbNewLine & ""


        Return envoyerMail(e, o, t)
    End Function


    Private Function envoyerMail(ByVal e As String, ByVal o As String, ByVal t As String) As Boolean
        Dim client As New System.Net.Mail.SmtpClient
        Dim message As New System.Net.Mail.MailMessage
        client.Credentials = New System.Net.NetworkCredential("faridkaiba@gmail.com", "17071993")

        Try

            client.Port = 587 'définition du port 
            client.Host = "smtp.gmail.com" 'définition du serveur smtp
            client.EnableSsl = True
            message.From = New System.Net.Mail.MailAddress("faridkaiba@gmail.com")
            message.To.Add(e)

            'Dim item As New System.Net.Mail.Attachment("LIEN_DE_LA_PIECE_JOINTE_EVENTUELLE_ICI")
            'message.Attachments.Add(item) 'ajout de la pièce jointe au message

            message.Subject = o
            message.Body = t

            client.Send(message) 'envoi du mail
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function AjouterAss(ByVal a As Association) As Boolean
        If verifierAsso(a) And verifierAss(a) Then
            Dim assDal As New AssociationDAL
            If assDal.AjouterAss(a) Then
                If verifierString(a.emailAss) Then
                    Dim cBll As New CompteBLL
                    a.ID = assDal.getLastId
                    If a.pres IsNot Nothing Then
                        a.pres.Ass = a
                        Dim p As New PresidentBLL
                        p.AjouterPresident(a.pres)
                    End If
                    Dim c = cBll.CreerCompte(a)
                    Return cBll.AjouterCompte(c)
                Else
                    Return True
                End If
            Else
                Return False
            End If
            Else
                Return False
            End If
    End Function

    Public Function ModifierAss(ByVal a As Association) As Boolean
        If verifierAsso(a) And verifierInt(a.ID) Then
            Dim assDal As New AssociationDAL
            Return assDal.ModifierAss(a)
        Else
            Return False
        End If
    End Function

    Public Function SupprimerAss(ByVal a As Association) As Boolean
        If verifierAsso(a) And verifierInt(a.ID) Then
            Dim assDal As New AssociationDAL
            Return assDal.SupprimerAss(a)
        Else
            Return False
        End If
    End Function

    Public Function GetAllAss() As List(Of Association)
        Dim assDal As New AssociationDAL
        Return assDal.GetAllAss()
    End Function

    Public Function RechercheAssById(ByVal id As Integer) As Association
        Dim assDal As New AssociationDAL
        Return assDal.RechercheAssById(id)
    End Function

    Public Function RechercheAssByNom(ByVal n As String) As List(Of Association)
        Dim assDal As New AssociationDAL
        Return assDal.RechercheAssByNom(n)
    End Function

    Public Function RechercheAssByTel(ByVal t As String) As Association
        Dim assDal As New AssociationDAL
        Return assDal.RechercheAssByTel(t)
    End Function

    Public Function RechercheAssByEmail(ByVal e As String) As Association
        Dim assDal As New AssociationDAL
        Return assDal.RechercheAssByEmail(e)
    End Function

    Public Function RechercheAssByDom(ByVal d As Domaine) As List(Of Association)
        Dim assDal As New AssociationDAL
        Return assDal.RechercheAssByDom(d)
    End Function

    Public Function RechercheAssByReg(ByVal r As Region) As List(Of Association)
        Dim assDal As New AssociationDAL
        Return assDal.RechercheAssByReg(r)
    End Function

    Public Function RechercheAssByVil(ByVal v As Ville) As List(Of Association)
        Dim assDal As New AssociationDAL
        Return assDal.RechercheAssByVil(v)
    End Function


End Class
