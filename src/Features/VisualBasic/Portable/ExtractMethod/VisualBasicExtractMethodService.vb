﻿' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Imports System.Composition
Imports Microsoft.CodeAnalysis.ExtractMethod
Imports Microsoft.CodeAnalysis.Host.Mef
Imports Microsoft.CodeAnalysis.Text
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax

Namespace Microsoft.CodeAnalysis.VisualBasic.ExtractMethod
    <Export(GetType(IExtractMethodService)), ExportLanguageService(GetType(IExtractMethodService), LanguageNames.VisualBasic), [Shared]>
    Partial Friend NotInheritable Class VisualBasicExtractMethodService
        Inherits AbstractExtractMethodService(Of
            StatementSyntax,
            ExecutableStatementSyntax,
            ExpressionSyntax)

        <ImportingConstructor>
        <Obsolete(MefConstruction.ImportingConstructorMessage, True)>
        Public Sub New()
        End Sub

        Protected Overrides Function CreateSelectionValidator(document As SemanticDocument, textSpan As TextSpan, localFunction As Boolean) As SelectionValidator
            Return New VisualBasicSelectionValidator(document, textSpan)
        End Function

        Protected Overrides Function CreateMethodExtractor(selectionResult As SelectionResult, options As ExtractMethodGenerationOptions, localFunction As Boolean) As MethodExtractor
            Return New VisualBasicMethodExtractor(selectionResult, options)
        End Function
    End Class
End Namespace
