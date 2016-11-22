Imports ProjetBLL
Imports ProjectDTO

Public Class inscription
    Inherits System.Web.UI.Page

    Dim lRegions As List(Of Region)
    Dim lVilles As List(Of Ville)

    Protected Sub Page_Load() Handles Me.Load

        If Not IsPostBack Then
            bindReg()
        End If
        lRegions = New RegionBLL().GetAllReg
    End Sub

    Private Sub bindReg()
        Dim rBLL As New RegionBLL()
        lRegions = rBLL.GetAllReg()
        regCB.DataTextField = "nomReg"
        regCB.DataValueField = "id"
        regCB.DataSource = lRegions
        regCB.DataBind()
    End Sub


    Private Sub bindVilByReg(ByVal r As Region)
        Dim vBLL As New VilleBLL
        lVilles = vBLL.RechercheVilleByReg(r)
        vilCB.DataSource = lVilles
        vilCB.DataTextField = "nomVil"
        vilCB.DataValueField = "id"
        vilCB.DataBind()
    End Sub

    Protected Sub confirmerBT_Click() Handles confirmerBT.Click

    End Sub

    Protected Sub itemSelected()
        Dim r As Region = lRegions.Find(Function(re As Region) re.ID = (regCB.SelectedValue))
        bindVilByReg(r)
    End Sub

End Class