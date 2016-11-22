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

Partial Public Class Notifications
	Public Sub New()
		MyBase.New()

		Me.InitializeComponent()

        ' Insert code required on object creation below this point.
        notDG.ItemsSource = New NotificationBLL().RechercheNotByGrp(currentUser.grp)
        goBT.IsEnabled = False
	End Sub

    Private Sub goBT_Click() Handles goBT.Click
        currentCorrespondance = TryCast(notDG.SelectedItem, Notification).cor
        Dim temp As Notification = notDG.SelectedItem
        temp.etat = "LU"
        Dim t = New NotificationBLL().ModifierNotification(temp)
        fPrincipal.Source = New System.Uri("userControls/majCorr.xaml", UriKind.Relative)
        Me.Close()
    End Sub

    Private Sub notDG_SelectionChanged() Handles notDG.SelectionChanged
        If TypeOf notDG.SelectedItem Is Notification Then
            goBT.IsEnabled = True
        End If
    End Sub
End Class
