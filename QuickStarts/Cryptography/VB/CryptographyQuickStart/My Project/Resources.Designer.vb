﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.42
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("CryptographyQuickStart.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Decrypted text: {0}.
        '''</summary>
        Friend ReadOnly Property DecryptedTextMessage() As String
            Get
                Return ResourceManager.GetString("DecryptedTextMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to You should encrypt a text first.
        '''</summary>
        Friend ReadOnly Property DecryptErrorMessage() As String
            Get
                Return ResourceManager.GetString("DecryptErrorMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Encrypted text: {0}.
        '''</summary>
        Friend ReadOnly Property EncryptedTextMessage() As String
            Get
                Return ResourceManager.GetString("EncryptedTextMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Enter the text to be encrypted:.
        '''</summary>
        Friend ReadOnly Property EncryptInstructionsMessage() As String
            Get
                Return ResourceManager.GetString("EncryptInstructionsMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Text to encrypt.
        '''</summary>
        Friend ReadOnly Property EncryptTitleMessage() As String
            Get
                Return ResourceManager.GetString("EncryptTitleMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to You must first generate a hash from text.
        '''</summary>
        Friend ReadOnly Property HashErrorMessage() As String
            Get
                Return ResourceManager.GetString("HashErrorMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Enter the text to be used for generating a hash value:.
        '''</summary>
        Friend ReadOnly Property HashInstructionsMessage() As String
            Get
                Return ResourceManager.GetString("HashInstructionsMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Generated hash: {0}.
        '''</summary>
        Friend ReadOnly Property HashMessage() As String
            Get
                Return ResourceManager.GetString("HashMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Text for hash.
        '''</summary>
        Friend ReadOnly Property HashTitleMessage() As String
            Get
                Return ResourceManager.GetString("HashTitleMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Unable to write key file.
        '''</summary>
        Friend ReadOnly Property KeyFileErrorTitle() As String
            Get
                Return ResourceManager.GetString("KeyFileErrorTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Original text: {0}.
        '''</summary>
        Friend ReadOnly Property OriginalTextMessage() As String
            Get
                Return ResourceManager.GetString("OriginalTextMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to The original text has not been tampered.
        '''</summary>
        Friend ReadOnly Property TextNotTamperedMessage() As String
            Get
                Return ResourceManager.GetString("TextNotTamperedMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to The original text has been tampered.
        '''</summary>
        Friend ReadOnly Property TextTamperedMessage() As String
            Get
                Return ResourceManager.GetString("TextTamperedMessage", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to We are sorry but this quick start is unable to run. It requires a key file to be created to be used for symmetric cryptographic operations, and we can&apos;t create this file.  The most common reason for this is that the quick starts were not installed into their default installation location. If this is true, please edit the configuration file to reflect the installation path. The exception message is: {0}.
        '''</summary>
        Friend ReadOnly Property UnableToWriteKeyFileErrorMessage() As String
            Get
                Return ResourceManager.GetString("UnableToWriteKeyFileErrorMessage", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
