Public Class Association
    Inherits CommonBase

    Private _id As Integer?
    Private _nomAss As String
    Private _datCrea As String
    Private _adrAss As String
    Private _telAss As String
    Private _emailAss As String
    Private _vilAss As Ville
    Private _P As President
    Private _doms As List(Of Domaine)
    Private _siteAss As String

    Public Property doms As List(Of Domaine)
        Get
            Return _doms
        End Get
        Set(ByVal value As List(Of Domaine))
            _doms = value
        End Set
    End Property

    Public Property site As String
        Get
            Return _siteAss
        End Get
        Set(ByVal value As String)
            _siteAss = value
        End Set
    End Property

    Public Property ID As Integer?
        Get
            Return _id
        End Get
        Set(ByVal value As Integer?)
            _id = value
        End Set
    End Property

    Public Property nomAss() As String
        Get
            Return _nomAss
        End Get
        Set(ByVal value As String)
            _nomAss = value
        End Set
    End Property


    Public Property datCrea() As String
        Get
            Return _datCrea
        End Get
        Set(ByVal value As String)
            _datCrea = value
        End Set
    End Property

    Public Property adrAss() As String
        Get
            Return _adrAss
        End Get
        Set(ByVal value As String)
            _adrAss = value
        End Set
    End Property

    Public Property telAss() As String
        Get
            Return _telAss
        End Get
        Set(ByVal value As String)
            _telAss = value
        End Set
    End Property

    Public Property emailAss() As String
        Get
            Return _emailAss
        End Get
        Set(ByVal value As String)
            _emailAss = value
        End Set
    End Property
    Public Property pres() As President
        Get
            Return _P
        End Get
        Set(ByVal value As President)
            _P = value
        End Set
    End Property
    Public Property ville() As Ville
        Get
            Return _vilAss
        End Get
        Set(ByVal value As Ville)
            _vilAss = value
        End Set
    End Property
    
  


    Public Sub New()
        _id = Int_NullValue
        _vilAss = Ville_NullValue
        _nomAss = String_NullValue
        _datCrea = String_NullValue
        _emailAss = String_NullValue
        _telAss = String_NullValue
        _adrAss = String_NullValue
        _P = president_NullValue
    End Sub






End Class
