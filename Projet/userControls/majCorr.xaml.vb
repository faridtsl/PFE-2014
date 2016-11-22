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

Partial Public Class majCorr
	Public Sub New()
		MyBase.New()

		Me.InitializeComponent()

        ' Insert code required on object creation below this point.
        If lTypes IsNot Nothing Then
            typCB.ItemsSource = lTypes
            typCB.DisplayMemberPath = "libTyp"
        Else
            bindTypes()
        End If
        serviceCB.ItemsSource = New GroupBLL().GetServices()
        serviceCB.DisplayMemberPath = "nomGrp"
        If currentCorrespondance Is Nothing Then
            corrDG.ItemsSource = New PostaleBLL().GetAllPos()
            majCorrBT.IsEnabled = False
            choixBT.IsEnabled = False
            commentaireTB.IsEnabled = False
            infoSuppTB.IsEnabled = False
            serviceCB.IsEnabled = False
            typCB.IsEnabled = False
            datDecDP.IsEnabled = False
        Else
            corrDG.IsEnabled = False
            choixBT.IsEnabled = False
            Button1.IsEnabled = False
        End If
    End Sub

    Private Sub bindTypes()
        Dim tBll As New TypeDecisionBLL
        Dim lTypes = tBll.GetAllTypDec
        typCB.ItemsSource = lTypes
        typCB.DisplayMemberPath = "libTyp"
    End Sub

    Private Sub rechCorrBT_Click() Handles rechCorrBT.Click
        Dim pBll As New PostaleBLL
        Dim eBll As New EmailBLL
        Dim lP As New List(Of Postale)
        Dim lE As New List(Of Email)
        If Not Equals(rechCorrByIdTB.Text, "") Then
            Dim temp = pBll.RecherchePosByNBO(rechCorrByIdTB.Text)
            If temp IsNot Nothing Then
                lP.Add(temp)
            End If
        End If
        corrDG.ItemsSource = lP
    End Sub

    Private Sub OnHyperlinkClick(ByVal o As Object, ByVal s As RoutedEventArgs)
        Try
            Dim d = TryCast(s.OriginalSource, Hyperlink).NavigateUri
            Process.Start(d.ToString)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub choixBT_Click() Handles choixBT.Click
        If corrDG.SelectedItem IsNot Nothing Then
            If Equals(corrDG.SelectedItem.GetType, New Postale().GetType) Then
                corrDG.IsEnabled = False
                majCorrBT.IsEnabled = True
                commentaireTB.IsEnabled = True
                infoSuppTB.IsEnabled = True
                serviceCB.IsEnabled = True
                typCB.IsEnabled = True
                datDecDP.IsEnabled = True
            Else

            End If
        End If
    End Sub


    Private Sub Button1_Click() Handles Button1.Click
        corrDG.IsEnabled = True
        majCorrBT.IsEnabled = False
        commentaireTB.IsEnabled = False
        infoSuppTB.IsEnabled = False
        serviceCB.IsEnabled = False
        typCB.IsEnabled = False
        datDecDP.IsEnabled = False
    End Sub

    Private Sub corrDG_SelectionChanged() Handles corrDG.SelectionChanged
        If corrDG.SelectedItem IsNot Nothing Then
            If Equals(corrDG.SelectedItem.GetType, New Postale().GetType) Then
                choixBT.IsEnabled = True
                currentCorrespondance = corrDG.SelectedItem
            Else
                choixBT.IsEnabled = False
            End If
        End If
    End Sub

    Private Function creerDec() As Decision
        Dim d As New Decision
        If commentaireTB.Text <> "" Then
            d.commentaire = commentaireTB.Text
        End If
        If infoSuppTB.Text <> "" Then
            d.infDec = infoSuppTB.Text
        End If
        d.estApp = False
        d.Cor = currentCorrespondance
        d.datDec = datDecDP.SelectedDate
        d.type = typCB.SelectedItem
        Return d
    End Function

    Private Sub majCorrBT_Click() Handles majCorrBT.Click
        Dim d = creerDec()
        Dim dBll As New DecisionBLL
        If dBll.AjouterDecision(d) Then
            currentCorrespondance.etat = "تم اتخاذ القرار"
            If New PostaleBLL().ModifierCor(currentCorrespondance) Then
                MsgBox("تمت اضافة القرار بنجاح")
                If serviceCB.SelectedItem IsNot Nothing Then
                    Dim n As New Notification
                    n.cor = currentCorrespondance
                    n.etat = "new"
                    n.emetteur = currentUser
                    n.datNot = d.datDec
                    n.info = "اتخاذ قرار"
                    n.destinataire = serviceCB.SelectedItem
                    Dim t = New NotificationBLL().AjouterNotification(n)
                End If
                currentCorrespondance = Nothing
                fPrincipal.Source = Nothing
            Else
                MsgBox("لم يتم تعديل حالة المراسلة")
            End If
        Else
            MsgBox("المرجوا اعادة ادخال القرار")
        End If
    End Sub

End Class
