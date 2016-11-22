Imports ProjectDTO

Public Class Utile

    Friend Function verifierDat(ByVal d As Date) As Boolean
        Return Not Equals(d, CommonBase.DateTime_NullValue)
    End Function

    Friend Function verifierString(ByVal s As String) As Boolean
        Return s <> CommonBase.String_NullValue And Not Equals(s, "null")
    End Function

    Friend Function verifierInt(ByVal i As Integer?) As Boolean
        Return Not Equals(i, CommonBase.Int_NullValue)
    End Function

    Friend Function verifierChar(ByVal c As Char) As Boolean
        Return c <> CommonBase.Char_NullValue
    End Function

    Friend Function verifierVille(ByVal v As Ville) As Boolean
        Return v IsNot CommonBase.Ville_NullValue
    End Function

    Friend Function verifierPres(ByVal p As President) As Boolean
        Return p IsNot CommonBase.president_NullValue
    End Function

    Friend Function verifierAsso(ByVal a As Association) As Boolean
        Return a IsNot CommonBase.Association_NullValue
    End Function

    Friend Function verifierDeci(ByVal d As Decision) As Boolean
        Return d IsNot CommonBase.Decision_NullValue
    End Function

    Friend Function verifierType(ByVal t As TypeDecision) As Boolean
        Return t IsNot CommonBase.TypeDecision_NullValue
    End Function

    Friend Function verifierCorr(ByVal c As Correspondance) As Boolean
        Return c IsNot Nothing
    End Function

End Class
