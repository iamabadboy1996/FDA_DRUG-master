﻿Public Class CLASS_EDIT_REQUEST
    Public EDIT_REQUESTs As New EDIT_REQUEST
#Region "SHOW"
    Private _DT_SHOW As New CLS_SHOW
    Public Property DT_SHOW() As CLS_SHOW
        Get
            Return _DT_SHOW
        End Get
        Set(ByVal value As CLS_SHOW)
            _DT_SHOW = value
        End Set
    End Property
#End Region

#Region "MASTER"
    Private _DT_MASTER As New CLS_MASTER
    Public Property DT_MASTER() As CLS_MASTER
        Get
            Return _DT_MASTER
        End Get
        Set(ByVal value As CLS_MASTER)
            _DT_MASTER = value
        End Set
    End Property
#End Region

#Region "DataBase"
    Private _AUTO_ID As String
    Public Property AUTO_ID() As String
        Get
            Return _AUTO_ID
        End Get
        Set(ByVal value As String)
            _AUTO_ID = value
        End Set
    End Property

#End Region
End Class
