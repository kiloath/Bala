Attribute VB_Name = "Module1"
Option Explicit

#If VBA7 Then
    Public Declare PtrSafe Function SetEnvironmentVariable Lib _
      "kernel32" PtrSafe Alias "SetEnvironmentVariableA" (ByVal lpName As String, ByVal lpValue As String) As Long
    Public Declare Function squareForEXL Lib _
      "squareDll.dll" (ByRef x As Double) As Double
#Else
    Public Declare Function SetEnvironmentVariable Lib _
      "kernel32" Alias "SetEnvironmentVariableA" (ByVal lpName As String, ByVal lpValue As String) As Long
    Public Declare Function squareForEXL Lib _
      "squareDll.dll" (ByRef x As Double) As Double
#End If

Function squareOnWorksheet(dArg As Double) As Double
    squareOnWorksheet = squareForEXL(dArg)
End Function

Sub useSquareInVBS()
    MsgBox squareForEXL(10)
End Sub

