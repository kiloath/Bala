Dim WshShell
Set WshShell = CreateObject("WScript.Shell")
Set WshShellEnv = WshShell.Environment("SYSTEM")

r = WshShell.Run("%WINDIR%/System32/regsvr32.exe /u /S ConcordsCAPIATL.dll",1,true)
If r <> 0 Then
MsgBox "ConcordsCAPIATL.dll �ϵ��U����", vbCritical
Else
MsgBox "ConcordsCAPIATL.dll �ϵ��U���\"
End If

If WshShellEnv("PROCESSOR_ARCHITECTURE") = "AMD64" Then
	r = WshShell.Run("%WINDIR%/System32/regsvr32.exe /u /s ConcordsCAPIATLx64.dll",1,True)
	If r <> 0 Then
	MsgBox "ConcordsCAPIATLx64 �ϵ��U����", vbCritical
	Else
	MsgBox "ConcordsCAPIATLx64 �ϵ��U���\"
	End If
End If
Set WshShell = Nothing