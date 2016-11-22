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

Partial Public Class gestionVilles
	Public Sub New()
		MyBase.New()

		Me.InitializeComponent()

        ' Insert code required on object creation below this point.
        If lRegions Is Nothing Then
            bindReg()
        Else
            regionCB.ItemsSource = lRegions
            regionCB.DisplayMemberPath = "nomReg"
        End If
	End Sub

    Private Sub bindReg()
        Dim rBLL As New RegionBLL()
        Dim lRegions = rBLL.GetAllReg()
        regionCB.ItemsSource = lRegions
        regionCB.DisplayMemberPath = "nomReg"
    End Sub


    Private Sub addVilBT_Click() Handles addVilBT.Click
        If regionCB.SelectedItem IsNot Nothing Or vilTB.Text <> "" Then
            If existe(vilTB.Text) Then
                MsgBox("المدينة متواجدة")
            Else
                Dim v As New Ville
                v.nomVil = vilTB.Text
                v.reg = regionCB.SelectedItem
                If New VilleBLL().AjouterVille(v) Then
                    MsgBox("تمت الاضافة")
                Else
                    MsgBox("لم تتم الاضافة")
                End If
            End If
        Else
            MsgBox("المرجوا ملئ جميع الخانات")
        End If
    End Sub

    Private Function existe(ByVal s As String) As Boolean
        If lVilles Is Nothing Then
            lVilles = New VilleBLL().GetAllVille
        End If
        Return lVilles.Find(Function(v As Ville) Equals(v.nomVil, s)) IsNot Nothing
    End Function

End Class
