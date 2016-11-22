Imports TwainLib

Public Class Form1

    Dim caller As Integer

    Public Sub New(ByVal i As Integer)
        Me.InitializeComponent()
        caller = i
    End Sub

    Private Sub Form1_Load() Handles MyBase.Load
        chemin = Nothing
    End Sub



    Private Sub chooseBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chooseBT.Click
        'My.Settings.scan = TwainLib.GetScanSource
        'My.Settings.Save()
    End Sub

    Private Sub scanBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scanBT.Click
        'Dim FileNames = TwainLib.ScanImages(, , My.Settings.scan)
        'For Each Itm In FileNames
        'chemin = Itm
        'Next
        Dim ls = TwainLib.ScanImages()
        chemin = ls.Item(0)
    End Sub

    Private Sub okBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okBT.Click
        Me.Close()
    End Sub


End Class