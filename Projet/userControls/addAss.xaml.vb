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

Partial Public Class addAss
	Public Sub New()
		MyBase.New()

		Me.InitializeComponent()

        ' Insert code required on object creation below this point.
        If lVilles Is Nothing Then
            bindAllVil()
        Else
            vilCB.ItemsSource = lVilles
            vilCB.DisplayMemberPath = "nomVil"
        End If

        If lRegions Is Nothing Then
            bindReg()
        Else
            regionCB.ItemsSource = lRegions
            regionCB.DisplayMemberPath = "nomReg"
        End If

        If lDoms Is Nothing Then
            bindDom()
        Else
            domCB.ItemsSource = lDoms
            domCB.DisplayMemberPath = "nomDom"
        End If

        currentPresident = Nothing
        currentAssociation = Nothing
    End Sub

    Private Sub bindDom()
        Dim dBLL As New DomaineBLL
        Dim lDoms = dBLL.GetAllDom
        domCB.ItemsSource = lDoms
        domCB.DisplayMemberPath = "nomDom"
    End Sub

    Private Sub bindReg()
        Dim rBLL As New RegionBLL()
        Dim lRegions = rBLL.GetAllReg()
        regionCB.ItemsSource = lRegions
        regionCB.DisplayMemberPath = "nomReg"
    End Sub

    Private Sub bindAllVil()
        Dim vBLL As New VilleBLL
        Dim lVilles = vBLL.GetAllVille
        vilCB.ItemsSource = lVilles
        vilCB.DisplayMemberPath = "nomVil"
    End Sub

    Private Sub bindVilByReg(ByVal r As Region)
        Dim vBLL As New VilleBLL
        Dim lVilles = vBLL.RechercheVilleByReg(r)
        vilCB.ItemsSource = lVilles
        vilCB.DisplayMemberPath = "nomVil"
    End Sub

    Private Function notEmpty(ByVal s As String) As Boolean
        Return Not Equals(s, "")
    End Function

    Private Function creerAss() As Association
        Dim a As New Association
        If notEmpty(nomTB.Text) Then
            a.nomAss = nomTB.Text
        End If
        a.ville = vilCB.SelectedItem
        If notEmpty(adrTB.Text) Then
            a.adrAss = adrTB.Text
        End If
        If notEmpty(emailTB.Text) Then
            a.emailAss = emailTB.Text
        End If
        If notEmpty(datCreaTB.Text) Then
            a.datCrea = datCreaTB.Text
        End If
        If notEmpty(siteTB.Text) Then
            a.site = siteTB.Text
        End If
        If notEmpty(telTB.Text) Then
            a.telAss = telTB.Text
        End If
        If currentPresident IsNot Nothing Then
            a.pres = currentPresident
        End If
        If domsLB.Items.Count <> 0 Then
            a.doms = New List(Of Domaine)
            For Each i As Domaine In domsLB.Items
                a.doms.Add(i)
            Next
        End If
        Return a
    End Function

    Private Sub presidentBT_Click() Handles presidentBT.Click
        Dim w As addPresident = New addPresident()
        w.ShowDialog()
        If currentPresident IsNot Nothing Then
            preAddedOK.Opacity = 100
        End If
    End Sub


    Private Sub addAssBT_Click() Handles addAssBT.Click
        Dim aBll As New AssociationBLL
        Dim a As Association = creerAss()
        If aBll.AjouterAss(a) Then
            MsgBox("تمت اضافة الجمعية بنجاح")
        Else
            MsgBox("المرجوا اعادة المحاولة")
        End If
    End Sub

    Private Sub regionCB_SelectionChanged() Handles regionCB.SelectionChanged
        bindVilByReg(regionCB.SelectedItem)
    End Sub

    Private Sub addDomBT_Click() Handles addDomBT.Click
        Dim l As New List(Of Domaine)
        For Each i As Domaine In domsLB.Items
            l.Add(i)
        Next
        If existe(l, domCB.SelectedItem) Then

        Else
            domsLB.Items.Add(domCB.SelectedItem)
            domsLB.DisplayMemberPath = "nomDom"
        End If

    End Sub

    Private Function existe(ByVal l As List(Of Domaine), ByVal d As Domaine) As Boolean
        Return l.Find(Function(dom) Equals(dom.ID, d.ID)) IsNot Nothing
    End Function

End Class
