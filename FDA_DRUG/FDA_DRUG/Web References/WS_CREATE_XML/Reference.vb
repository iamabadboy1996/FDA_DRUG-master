﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
'
Namespace WS_CREATE_XML
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="WS_INSERT_XML_DRUGSoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class WS_INSERT_XML_DRUG
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private XML_DRUG_LICENSEOperationCompleted As System.Threading.SendOrPostCallback
        
        Private XML_DRUG_LICENSE_DELETEOperationCompleted As System.Threading.SendOrPostCallback
        
        Private XML_DRUG_DH_DI_DP_DSOperationCompleted As System.Threading.SendOrPostCallback
        
        Private XML_DRUG_FORMULAOperationCompleted As System.Threading.SendOrPostCallback
        
        Private XML_DRUG_FORMULA_DELETEOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.FDA_DRUG.My.MySettings.Default.FDA_DRUG_WS_CREATE_XML_WS_INSERT_XML_DRUG
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event XML_DRUG_LICENSECompleted As XML_DRUG_LICENSECompletedEventHandler
        
        '''<remarks/>
        Public Event XML_DRUG_LICENSE_DELETECompleted As XML_DRUG_LICENSE_DELETECompletedEventHandler
        
        '''<remarks/>
        Public Event XML_DRUG_DH_DI_DP_DSCompleted As XML_DRUG_DH_DI_DP_DSCompletedEventHandler
        
        '''<remarks/>
        Public Event XML_DRUG_FORMULACompleted As XML_DRUG_FORMULACompletedEventHandler
        
        '''<remarks/>
        Public Event XML_DRUG_FORMULA_DELETECompleted As XML_DRUG_FORMULA_DELETECompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/XML_DRUG_LICENSE", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function XML_DRUG_LICENSE(ByVal Newcode As String) As String
            Dim results() As Object = Me.Invoke("XML_DRUG_LICENSE", New Object() {Newcode})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub XML_DRUG_LICENSEAsync(ByVal Newcode As String)
            Me.XML_DRUG_LICENSEAsync(Newcode, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub XML_DRUG_LICENSEAsync(ByVal Newcode As String, ByVal userState As Object)
            If (Me.XML_DRUG_LICENSEOperationCompleted Is Nothing) Then
                Me.XML_DRUG_LICENSEOperationCompleted = AddressOf Me.OnXML_DRUG_LICENSEOperationCompleted
            End If
            Me.InvokeAsync("XML_DRUG_LICENSE", New Object() {Newcode}, Me.XML_DRUG_LICENSEOperationCompleted, userState)
        End Sub
        
        Private Sub OnXML_DRUG_LICENSEOperationCompleted(ByVal arg As Object)
            If (Not (Me.XML_DRUG_LICENSECompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent XML_DRUG_LICENSECompleted(Me, New XML_DRUG_LICENSECompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/XML_DRUG_LICENSE_DELETE", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function XML_DRUG_LICENSE_DELETE(ByVal Newcode As String) As String
            Dim results() As Object = Me.Invoke("XML_DRUG_LICENSE_DELETE", New Object() {Newcode})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub XML_DRUG_LICENSE_DELETEAsync(ByVal Newcode As String)
            Me.XML_DRUG_LICENSE_DELETEAsync(Newcode, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub XML_DRUG_LICENSE_DELETEAsync(ByVal Newcode As String, ByVal userState As Object)
            If (Me.XML_DRUG_LICENSE_DELETEOperationCompleted Is Nothing) Then
                Me.XML_DRUG_LICENSE_DELETEOperationCompleted = AddressOf Me.OnXML_DRUG_LICENSE_DELETEOperationCompleted
            End If
            Me.InvokeAsync("XML_DRUG_LICENSE_DELETE", New Object() {Newcode}, Me.XML_DRUG_LICENSE_DELETEOperationCompleted, userState)
        End Sub
        
        Private Sub OnXML_DRUG_LICENSE_DELETEOperationCompleted(ByVal arg As Object)
            If (Not (Me.XML_DRUG_LICENSE_DELETECompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent XML_DRUG_LICENSE_DELETECompleted(Me, New XML_DRUG_LICENSE_DELETECompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/XML_DRUG_DH_DI_DP_DS", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function XML_DRUG_DH_DI_DP_DS(ByVal Newcode As String) As Object
            Dim results() As Object = Me.Invoke("XML_DRUG_DH_DI_DP_DS", New Object() {Newcode})
            Return CType(results(0),Object)
        End Function
        
        '''<remarks/>
        Public Overloads Sub XML_DRUG_DH_DI_DP_DSAsync(ByVal Newcode As String)
            Me.XML_DRUG_DH_DI_DP_DSAsync(Newcode, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub XML_DRUG_DH_DI_DP_DSAsync(ByVal Newcode As String, ByVal userState As Object)
            If (Me.XML_DRUG_DH_DI_DP_DSOperationCompleted Is Nothing) Then
                Me.XML_DRUG_DH_DI_DP_DSOperationCompleted = AddressOf Me.OnXML_DRUG_DH_DI_DP_DSOperationCompleted
            End If
            Me.InvokeAsync("XML_DRUG_DH_DI_DP_DS", New Object() {Newcode}, Me.XML_DRUG_DH_DI_DP_DSOperationCompleted, userState)
        End Sub
        
        Private Sub OnXML_DRUG_DH_DI_DP_DSOperationCompleted(ByVal arg As Object)
            If (Not (Me.XML_DRUG_DH_DI_DP_DSCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent XML_DRUG_DH_DI_DP_DSCompleted(Me, New XML_DRUG_DH_DI_DP_DSCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/XML_DRUG_FORMULA", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function XML_DRUG_FORMULA(ByVal Newcode As String, ByVal IDENTIFY_EDIT As String) As String
            Dim results() As Object = Me.Invoke("XML_DRUG_FORMULA", New Object() {Newcode, IDENTIFY_EDIT})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub XML_DRUG_FORMULAAsync(ByVal Newcode As String, ByVal IDENTIFY_EDIT As String)
            Me.XML_DRUG_FORMULAAsync(Newcode, IDENTIFY_EDIT, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub XML_DRUG_FORMULAAsync(ByVal Newcode As String, ByVal IDENTIFY_EDIT As String, ByVal userState As Object)
            If (Me.XML_DRUG_FORMULAOperationCompleted Is Nothing) Then
                Me.XML_DRUG_FORMULAOperationCompleted = AddressOf Me.OnXML_DRUG_FORMULAOperationCompleted
            End If
            Me.InvokeAsync("XML_DRUG_FORMULA", New Object() {Newcode, IDENTIFY_EDIT}, Me.XML_DRUG_FORMULAOperationCompleted, userState)
        End Sub
        
        Private Sub OnXML_DRUG_FORMULAOperationCompleted(ByVal arg As Object)
            If (Not (Me.XML_DRUG_FORMULACompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent XML_DRUG_FORMULACompleted(Me, New XML_DRUG_FORMULACompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/XML_DRUG_FORMULA_DELETE", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function XML_DRUG_FORMULA_DELETE(ByVal Newcode As String) As String
            Dim results() As Object = Me.Invoke("XML_DRUG_FORMULA_DELETE", New Object() {Newcode})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub XML_DRUG_FORMULA_DELETEAsync(ByVal Newcode As String)
            Me.XML_DRUG_FORMULA_DELETEAsync(Newcode, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub XML_DRUG_FORMULA_DELETEAsync(ByVal Newcode As String, ByVal userState As Object)
            If (Me.XML_DRUG_FORMULA_DELETEOperationCompleted Is Nothing) Then
                Me.XML_DRUG_FORMULA_DELETEOperationCompleted = AddressOf Me.OnXML_DRUG_FORMULA_DELETEOperationCompleted
            End If
            Me.InvokeAsync("XML_DRUG_FORMULA_DELETE", New Object() {Newcode}, Me.XML_DRUG_FORMULA_DELETEOperationCompleted, userState)
        End Sub
        
        Private Sub OnXML_DRUG_FORMULA_DELETEOperationCompleted(ByVal arg As Object)
            If (Not (Me.XML_DRUG_FORMULA_DELETECompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent XML_DRUG_FORMULA_DELETECompleted(Me, New XML_DRUG_FORMULA_DELETECompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")>  _
    Public Delegate Sub XML_DRUG_LICENSECompletedEventHandler(ByVal sender As Object, ByVal e As XML_DRUG_LICENSECompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class XML_DRUG_LICENSECompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")>  _
    Public Delegate Sub XML_DRUG_LICENSE_DELETECompletedEventHandler(ByVal sender As Object, ByVal e As XML_DRUG_LICENSE_DELETECompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class XML_DRUG_LICENSE_DELETECompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")>  _
    Public Delegate Sub XML_DRUG_DH_DI_DP_DSCompletedEventHandler(ByVal sender As Object, ByVal e As XML_DRUG_DH_DI_DP_DSCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class XML_DRUG_DH_DI_DP_DSCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Object
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Object)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")>  _
    Public Delegate Sub XML_DRUG_FORMULACompletedEventHandler(ByVal sender As Object, ByVal e As XML_DRUG_FORMULACompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class XML_DRUG_FORMULACompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")>  _
    Public Delegate Sub XML_DRUG_FORMULA_DELETECompletedEventHandler(ByVal sender As Object, ByVal e As XML_DRUG_FORMULA_DELETECompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class XML_DRUG_FORMULA_DELETECompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
End Namespace
