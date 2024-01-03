::mt -manifest Native.CAPIATL_Proxy.manifest -outputresource:CAPIATL_Client.exe

:: --------------------------------------------
::mt -tlb:ConcordsCAPIATL.dll -dll:ConcordsCAPIATL.dll -out:ConcordsCAPIATL.dll.manifest
::mt -manifest ConcordsCAPIATL.dll.manifest -outputresource:CAPIATL_Client.exe

:: --------------------------------------------
::mt -tlb:ConcordsCAPIATL.dll -dll:ConcordsCAPIATL.dll -out:ConcordsCAPIATL.dll.manifest
::mt -manifest ConcordsCAPIATL.dll.manifest -outputresource:Interop.ConcordsCAPIATLLib.dll

:: -----------------------------------------------
mt.exe -tlb:ConcordsCAPIATL.dll -dll:ConcordsCAPIATL.dll -out:ConcordsCAPIATL.dll.manifest
tlbimp ConcordsCAPIATL.dll /namespace:ConcordsCAPIATLLib /out:NetConcordsCAPIATL.dll
mt.exe -manifest ConcordsCAPIATL.dll.manifest -outputresource:NetConcordsCAPIATL.dll
mt.exe -managedassemblyname:NetConcordsCAPIATL.dll -nodependency -out:NetConcordsCAPIATL.dll.manifest
mt.exe -manifest NetConcordsCAPIATL.dll.manifest -outputresource:CAPIATL_Proxy.dll
mt.exe -manifest ConcordsCAPIATL.dll.manifest -outputresource:CAPIATL_Proxy.dll
mt.exe -managedassemblyname:CAPIATL_Proxy.dll -nodependency -out:CAPIATL_Proxy.dll.manifest