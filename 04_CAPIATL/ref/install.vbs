Dim WshShell
Set WshShell = CreateObject("WScript.Shell")
Set WshShellEnv = WshShell.Environment("SYSTEM")

r = WshShell.Run("%WINDIR%/System32/regsvr32.exe /S ConcordsCAPIATL.dll",1,true)
If r <> 0 Then
MsgBox "ConcordsCAPIATL.dll ���U����", vbCritical
Else
MsgBox "ConcordsCAPIATL.dll ���U���\"
End If

If WshShellEnv("PROCESSOR_ARCHITECTURE") = "AMD64" Then
	r = WshShell.Run("%WINDIR%/System32/regsvr32.exe /s ConcordsCAPIATLx64.dll",1,True)
	If r <> 0 Then
	MsgBox "ConcordsCAPIATLx64 ���U����", vbCritical
	Else
	MsgBox "ConcordsCAPIATLx64 ���U���\"
	End If
End If
Set WshShell = Nothing