Imports ProjectDTO

Public Class Utile

    Friend Shared Function RegionDataSetToList(ByVal ds As DataSet) As List(Of Region)
        Dim dt As DataTable = ds.Tables("TRegion")
        Dim result As New List(Of Region)
        Dim temp As Region
        For Each r As DataRow In dt.Rows
            temp = New Region
            temp.ID = r.Field(Of Integer)("idReg")
            temp.nomReg = r.Field(Of String)("nomReg")
            result.Add(temp)
        Next
        Return result
    End Function

    Friend Shared Function VilleDataSetToList(ByVal ds As DataSet) As List(Of Ville)
        Dim dt As DataTable = ds.Tables("TVille")
        Dim result As New List(Of Ville)
        Dim temp As Ville
        For Each r As DataRow In dt.Rows
            temp = New Ville
            temp.ID = r.Field(Of Integer)("idVil")
            temp.nomVil = r.Field(Of String)("nomVil")
            temp.reg = New RegionDAL().RechercheRegById(r.Field(Of Integer)("idReg"))
            If temp.reg.villes Is Nothing Then
                temp.reg.villes = New List(Of Ville)
            End If
            temp.reg.villes.Add(temp)
            result.Add(temp)
        Next
        Return result
    End Function

    Friend Shared Function DomaineDataSetToList(ByVal ds As DataSet) As List(Of Domaine)
        Dim dt As DataTable = ds.Tables("TDomaine")
        Dim result As New List(Of Domaine)
        Dim temp As Domaine
        For Each r As DataRow In dt.Rows
            temp = New Domaine
            temp.ID = r.Field(Of Integer)("idDom")
            temp.nomDom = r.Field(Of String)("nomDom")
            result.Add(temp)
        Next
        Return result
    End Function

    Friend Shared Function TypDecDataSetToList(ByVal ds As DataSet) As List(Of TypeDecision)
        Dim dt As DataTable = ds.Tables("TtypesDecision")
        Dim result As New List(Of TypeDecision)
        Dim temp As TypeDecision
        For Each r As DataRow In dt.Rows
            temp = New TypeDecision
            temp.id = r.Field(Of Integer)("idTyp")
            temp.libTyp = r.Field(Of String)("libele")
            result.Add(temp)
        Next
        Return result
    End Function

    Friend Shared Function DecDataSetToList(ByVal ds As DataSet) As List(Of Decision)
        Dim dt As DataTable = ds.Tables("TDecision")
        Dim result As New List(Of Decision)
        Dim temp As Decision
        For Each r As DataRow In dt.Rows
            temp = New Decision
            temp.idDec = r.Field(Of Integer)("idDec")
            temp.type = New TypeDecisionDAL().RechercheTypDecById(r.Field(Of Integer)("idTyp"))
            temp.infDec = r.Field(Of String)("infoSuppDec")
            temp.commentaire = r.Field(Of String)("commentaire")
            temp.estApp = r.Field(Of Boolean)("estApp")
            temp.datDec = Date.Parse(r.Field(Of String)("datDec"))
            result.Add(temp)
        Next
        Return result
    End Function

    Friend Shared Function AssDataSetToList(ByVal ds As DataSet) As List(Of Association)
        Dim dt As DataTable = ds.Tables("TAssociation")
        Dim result As New List(Of Association)
        Dim temp As Association
        For Each r As DataRow In dt.Rows
            temp = New Association
            temp.ID = r.Field(Of Integer)("idAss")
            temp.nomAss = r.Field(Of String)("nomAss")
            temp.telAss = r.Field(Of String)("telAss")
            temp.emailAss = r.Field(Of String)("emailAss")
            temp.adrAss = r.Field(Of String)("adrAss")
            temp.datCrea = r.Field(Of String)("datCreaAss")
            temp.site = r.Field(Of String)("siteAss")
            temp.pres = New PresidentDAL().RecherchePreByAss(temp)
            temp.doms = New DomaineDAL().RechercheDomByAss(temp)
            If temp.pres IsNot Nothing Then
                temp.pres.Ass = temp
            End If
            temp.ville = New VilleDAL().RechercheVilleById(r.Field(Of Integer)("idVil"))
            result.Add(temp)
        Next
        Return result
    End Function

    Friend Shared Function CompteDataSetToList(ByVal ds As DataSet) As List(Of Compte)
        Dim dt As DataTable = ds.Tables("TComptes")
        Dim result As New List(Of Compte)
        Dim temp As Compte
        For Each r As DataRow In dt.Rows
            temp = New Compte
            temp.ID = r.Field(Of Integer)("idCom")
            temp.login = r.Field(Of String)("loginMail")
            temp.MDP = r.Field(Of String)("MDP")
            temp.estComplet = r.Field(Of Boolean)("estComplet")
            temp.ass = New AssociationDAL().RechercheAssById(r.Field(Of Integer)("idAss"))
            result.Add(temp)
        Next
        Return result
    End Function

    Friend Shared Function PreDataSetToList(ByVal ds As DataSet) As List(Of President)
        Dim dt As DataTable = ds.Tables("TPresident")
        Dim result As New List(Of President)
        Dim temp As President
        For Each r As DataRow In dt.Rows
            temp = New President
            temp.Id = r.Field(Of Integer)("idPre")
            temp.nomPres = r.Field(Of String)("nomPre")
            temp.prePres = r.Field(Of String)("prenomPre")
            temp.Age = r.Field(Of Integer)("agePre")
            temp.sexe = r.Field(Of String)("sexe")
            temp.telPres = r.Field(Of String)("telPre")
            result.Add(temp)
        Next
        Return result
    End Function

    Friend Shared Function CorDataSetToList(ByVal ds As DataSet) As List(Of Correspondance)
        Dim dt As DataTable = ds.Tables("TCorrespondance")
        Dim result As New List(Of Correspondance)
        Dim temp As Correspondance
        For Each r As DataRow In dt.Rows
            temp = New Correspondance
            temp.idCor = r.Field(Of Integer)("idCor")
            temp.objet = r.Field(Of String)("objet")
            temp.datEnv = (r.Field(Of Date)("datEnv"))
            temp.datRec = (r.Field(Of Date)("datRec"))
            temp.etat = r.Field(Of String)("etat")
            temp.estPos = r.Field(Of Boolean)("estPostale")
            temp.ass = New AssociationDAL().RechercheAssById(r.Field(Of Integer)("idAss"))
            temp.dec = New DecisionDAL().RechercheDecByCor(temp)
            If temp.dec IsNot Nothing Then
                temp.dec.Cor = temp
            End If
            result.Add(temp)
        Next
        Return result
    End Function

    Friend Shared Function UserDataSetToList(ByVal ds As DataSet) As List(Of User)
        Dim dt As DataTable = ds.Tables("TUsers")
        Dim result As New List(Of User)
        Dim temp As User
        For Each r As DataRow In dt.Rows
            temp = New User
            temp.idUser = r.Field(Of Integer)("idUser")
            temp.userName = r.Field(Of String)("userName")
            temp.MDP = r.Field(Of String)("MDP")
            temp.grp = New GroupDAL().RechercheGrpById(r.Field(Of Integer)("idGrp"))
            temp.grp.membres.Add(temp)
            result.Add(temp)
        Next
        Return result
    End Function

    Friend Shared Function GrpDataSetToList(ByVal ds As DataSet) As List(Of Group)
        Dim dt As DataTable = ds.Tables("TGroups")
        Dim result As New List(Of Group)
        Dim temp As Group
        For Each r As DataRow In dt.Rows
            temp = New Group
            temp.idGrp = r.Field(Of Integer)("idGrp")
            temp.nomGrp = r.Field(Of String)("nomGrp")
            result.Add(temp)
        Next
        Return result
    End Function

    Friend Shared Function NotDataSetToList(ByVal ds As DataSet) As List(Of Notification)
        Dim dt As DataTable = ds.Tables("TNotifications")
        Dim result As New List(Of Notification)
        Dim temp As Notification
        For Each r As DataRow In dt.Rows
            temp = New Notification
            temp.idNot = r.Field(Of Integer)("idNot")
            temp.info = r.Field(Of String)("info")
            temp.datNot = (Date.Parse(r.Field(Of String)("datNot")))
            temp.etat = r.Field(Of String)("etat")
            temp.cor = New CorrespondanceDAL().RechercheCorById(r.Field(Of Integer)("idCor"))
            temp.destinataire = New GroupDAL().RechercheGrpById(r.Field(Of Integer)("idRec"))
            temp.destinataire.notifications.Add(temp)
            temp.emetteur = New UserDAL().RechercheUserById(r.Field(Of Integer)("idEmetteur"))
            result.Add(temp)
        Next
        Return result
    End Function

End Class
