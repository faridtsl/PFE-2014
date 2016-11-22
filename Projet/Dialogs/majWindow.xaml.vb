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

Partial Public Class majWindow
    Inherits Window
    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()

        ' Insert code required on object creation below this point.
        currentPresident = currentAssociation.pres
        bindControls()
    End Sub

    Private Sub bindControls()
        nomTB.Text = currentAssociation.nomAss
        emailTB.Text = currentAssociation.emailAss
        adrTB.Text = currentAssociation.adrAss
        siteTB.Text = currentAssociation.site
        datCreaTB.Text = currentAssociation.datCrea
        telTB.Text = currentAssociation.telAss
        currentPresident = currentAssociation.pres
        regionCB.ItemsSource = lRegions
        regionCB.SelectedItem = lRegions.Find(Function(r As Region) r.Equals(currentAssociation.ville.reg))
        regionCB.DisplayMemberPath = "nomReg"
        vilCB.ItemsSource = lVilles
        vilCB.SelectedItem = lVilles.Find(Function(v As Ville) v.Equals(currentAssociation.ville))
        vilCB.DisplayMemberPath = "nomVil"
    End Sub

    Private Sub majPre_Click() Handles majPre.Click
        If currentPresident Is Nothing Then
            Dim w As addPresident = New addPresident()
            w.ShowDialog()
            currentPresident.Ass = currentAssociation
            If New PresidentBLL().AjouterPresident(currentPresident) Then
                MsgBox("تمت اضافة الرئيس")
            End If
            currentPresident = New PresidentBLL().RecherchePreByAss(currentAssociation)
            currentPresident.Ass = currentAssociation
            currentAssociation.pres = currentPresident
        Else
            Dim w As majPres = New majPres()
            w.ShowDialog()
        End If
        If currentPresident IsNot Nothing Then
            preAddedOK.Opacity = 100
        End If
    End Sub

    Private Sub majAssBT_Click() Handles majAssBT.Click
        Dim aBll As New AssociationBLL()
        Dim s As String = "هل انت متأكد من تعديل الجمعية"
        Dim a As Association = creerAss()
        Dim result = MessageBox.Show(s, "", MessageBoxButton.YesNoCancel)
        If MsgBoxResult.Yes = result Then
            If aBll.ModifierAss(a) Then
                MsgBox("تم التعديل بنجاح")
            Else
                MsgBox("لم يتم التعديل")
            End If
        ElseIf result = MsgBoxResult.No Then
            Me.Close()
        ElseIf result = MsgBoxResult.Cancel Then

        End If
    End Sub

    Private Function creerAss() As Association
        Dim a As New Association
        a.ID = currentAssociation.ID
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
        Return a
    End Function

    Private Function notEmpty(ByVal s As String) As Boolean
        Return Not Equals(s, "")
    End Function

End Class
