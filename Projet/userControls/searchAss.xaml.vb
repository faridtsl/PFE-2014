Imports System
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports ProjetBLL
Imports ProjectDTO
Imports Microsoft.Office.Interop

Partial Public Class searchAss


    Dim lAss As New List(Of Association)

    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()

        ' Insert code required on object creation below this point.
        If lRegions Is Nothing Then
            bindReg()
        Else
            rechByRegionCB.ItemsSource = lRegions
            rechByRegionCB.DisplayMemberPath = "nomReg"
        End If
        If lDoms Is Nothing Then
            bindDom()
        Else
            domCB.ItemsSource = lDoms
            domCB.DisplayMemberPath = "nomDom"
        End If
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
        rechByRegionCB.ItemsSource = lRegions
        rechByRegionCB.DisplayMemberPath = "nomReg"
    End Sub

    Private Sub rechAssCorrBT_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles rechAssCorrBT.Click
        bindAss()
    End Sub

    Private Sub bindAss()
        Dim aBll As New AssociationBLL()
        If rechByRegionCB.SelectedItem IsNot Nothing And domCB.SelectedItem IsNot Nothing Then

        ElseIf rechByRegionCB.SelectedItem IsNot Nothing Then
            lAss = aBll.RechercheAssByReg(rechByRegionCB.SelectedItem)
            rechAssDG.SelectedItem = 0
        ElseIf domCB.SelectedItem IsNot Nothing Then
            lAss = aBll.RechercheAssByDom(domCB.SelectedItem)
        Else
            MsgBox("SELECT")
        End If
        rechAssDG.ItemsSource = lAss
    End Sub

    Private Sub impressionBT_Click() Handles impressionBT.Click
        dgToXls()
    End Sub

    Private Sub dgToXls()
        Dim xlApp As Excel.Application
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet

        xlApp = CType(CreateObject("Excel.Application"), Excel.Application)
        xlBook = CType(xlApp.Workbooks.Add, Excel.Workbook)
        xlSheet = CType(xlBook.Worksheets(1), Excel.Worksheet)

        ' Ici on compte le nombre de lignes et de colonnes du datatable 
        Dim nbrLigne As Integer = lAss.Count - 1
        Dim nbrColon As Integer = 6
        Dim x, y As Integer

        For x = 0 To nbrColon
            ' Ici on prend le titre des colonnes du datatable 
            xlSheet.Cells(1, x + 1) = rechAssDG.Columns.Item(x).Header
            ' On met la première ligne en gras 
            xlSheet.Rows(1).Font.Bold = True

            ' Pour chaque colonne et chaque ligne on transfère les données 
            For y = 0 To nbrLigne
                xlSheet.Cells(y + 2, x + 1) = getCell(lAss, x, y)
            Next
        Next

        ' Ici on affiche les résultats dans Excel 
        xlSheet.Application.Visible = True
        ' On peut sauvegarder notre document sur le disque 
        xlSheet.SaveAs("D:\test.xlsx")
        ' On quitte l'application et on détruit les objets 
        xlApp.Quit()
        xlSheet = Nothing
        xlBook = Nothing
        xlApp = Nothing
    End Sub

    Private Function getCell(ByVal l As List(Of Association), ByVal nc As Integer, ByVal nl As Integer) As String
        Select Case nc
            Case 0
                Return lAss.Item(nl).nomAss
            Case 1
                Return lAss.Item(nl).emailAss
            Case 2
                Return lAss.Item(nl).telAss
            Case 3
                Return lAss.Item(nl).ville.nomVil
            Case 4
                Return lAss.Item(nl).adrAss
            Case 5
                Return lAss.Item(nl).site
            Case 6
                If lAss.Item(nl).doms IsNot Nothing Then
                    If lAss.Item(nl).doms.Count <> 0 Then
                        Return lAss.Item(nl).doms.Item(0).nomDom
                    Else
                        Return ""
                    End If
                Else
                    Return ""
                End If
            Case Else
                Return ""
        End Select
    End Function

End Class
