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
Imports System.Windows.Interop

Partial Public Class addCorr
    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()

        ' Insert code required on object creation below this point.
        enteteLB.Content = " المرسل " & currentAssociation.nomAss
    End Sub



    Private Sub addCorBT_Click() Handles addCorBT.Click
        Dim p = creerCor()
        Dim pBll As New PostaleBLL
        If pBll.AjouterPos(p) Then
            Dim nBll As New NotificationBLL
            Dim n As New Notification
            n.emetteur = currentUser
            n.datNot = p.datRec
            n.cor = p
            n.etat = "new"
            n.info = "وصول مراسل"
            n.destinataire = New GroupBLL().RechercheGrpById(1)
            Dim t = New NotificationBLL().AjouterNotification(n)
            MsgBox("تمت اضافة المراسلة بنجاح")
        Else
            MsgBox("المرجوا اعادة ادخال المراسلة")
        End If
    End Sub

    Private Function notEmpty(ByVal s As String) As Boolean
        Return Not Equals(s, "")
    End Function

    Private Function creerCor() As Postale
        Dim res As New Postale()
        If notEmpty(objTB.Text) Then
            res.objet = objTB.Text
        End If
        res.datEnv = datenvDP.SelectedDate
        res.datRec = datRecDP.SelectedDate
        res.ass = currentAssociation
        res.estPos = True
        res.etat = "انتظار القرار"
        If notEmpty(numCorrTB.Text) Then
            res.NBO = numCorrTB.Text
        End If
        If notEmpty(cheminPdfTB.Text) Then
            res.cheminPDF = cheminPdfTB.Text
        End If
        If notEmpty(imgsuppTB.Text) Then
            res.imgSupp = imgsuppTB.Text
        End If
        Return res
    End Function

    Private Sub scanBT_Click() Handles scanBT.Click
        Dim form As New Form1(1)
        form.ShowDialog()
        cheminPdfTB.Text = chemin
        'Dim p As New Postale
        'p = New PostaleBLL().addChemin(p)
        'If notEmpty(p.cheminPDF) Then
        'cheminPdfTB.Text = p.cheminPDF
        'scan2BT.IsEnabled = True
        'Else
        'MsgBox("لم تتم العملية")
        'End If
    End Sub

    Private Sub scan2BT_Click() Handles scan2BT.Click
        Dim form As New Form1(2)
        form.ShowDialog()
        imgsuppTB.Text = chemin
        'Dim p As New Postale
        'p.cheminPDF = cheminPdfTB.Text
        'p = New PostaleBLL().addChemin(p)
        'If notEmpty(p.imgSupp) Then
        'imgsuppTB.Text = p.imgSupp
        'Else
        'MsgBox("لم تتم العملية")
        'End If
    End Sub

End Class
