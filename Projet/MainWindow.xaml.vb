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

Class MainWindow
    Inherits Window

    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()

        ' Insert code required on object creation below this point.
        principal = Me
        fPrincipal = contentFrame
        lRegions = New RegionBLL().GetAllReg()
        lVilles = New VilleBLL().GetAllVille()
        lTypes = New TypeDecisionBLL().GetAllTypDec()
        lDoms = New DomaineBLL().GetAllDom()
    End Sub

    Private Sub addAssBT_Click() Handles addAssBT.Click
        contentFrame.Source = New System.Uri("userControls/addAss.xaml", UriKind.Relative)
    End Sub

    Private Sub addCorrBT_Click() Handles addCorrBT.Click
        contentFrame.Source = New System.Uri("userControls/preAddCor.xaml", UriKind.Relative)
    End Sub

    Private Sub archCorrBT_Click() Handles archCorrBT.Click
        contentFrame.Source = New System.Uri("userControls/corrArch.xaml", UriKind.Relative)
    End Sub

    Private Sub majCorrBT_Click() Handles majCorrBT.Click
        contentFrame.Source = New System.Uri("userControls/majCorr.xaml", UriKind.Relative)
    End Sub

    Private Sub searchAssBT_Click() Handles searchAssBT.Click
        contentFrame.Source = New System.Uri("userControls/searchAss.xaml", UriKind.Relative)
    End Sub

    Private Sub majAssBT_Click() Handles majAssBT.Click
        contentFrame.Source = New System.Uri("userControls/searchMajAss.xaml", UriKind.Relative)
    End Sub

    Private Sub notifBT_Click() Handles notifBT.Click
        Dim w As New Notifications
        w.ShowDialog()
    End Sub

End Class