#include <Constants.au3>
#include <File.au3>
#include <Misc.au3>
#include <Date.au3>
#include <ScreenCapture.au3>
#include <Array.au3>
#include <WinAPIFiles.au3>

Global $today = StringFormat("%02i%02i%04i", @MDAY,  @MON,  @YEAR)
Global $sStatusFilePath = @ScriptDir & "\Result\status.dp"
Global $sWindowContentFilePath = @ScriptDir & "\Result\wcontent.dp"
Global $sErrorMessageFilePath = @ScriptDir & "\Result\errorm.dp"
Global $sAppPath = @ScriptDir & "\..\..\bin\Debug\netcoreapp3.1"
Global $sOutPutFile = $sAppPath & "\op.dp"
Global $sErrorMessage = ""
Global $sCloseMsg = "This message box closes after 10 seconds or click on OK."

_Log("###########################STARTING AUTOIT SCRIPT#######################")
If _Singleton("dc", 1) = 0 Then
	_FailSafe("An occurrence of this script is already running.")
EndIf

init()
setArguments($CmdLine)
_Log("###########################END OF AUTOIT SCRIPT#######################")


Func runTest($sTestId)
	_Log("Executing Function runTest")
	
	Select
		Case $sTestId = "01"
			setStatus(Test01())
		
		Case $sTestId = "04"
			setStatus(Test04())
		
		Case $sTestId = "05"
			setStatus(Test05())

		Case $sTestId = "07"
			setStatus(Test07())
		
		Case Else ; If nothing matches then execute the following.
			_Log("There's no implementation for this test id. " & $sTestId)
			MsgBox($MB_SYSTEMMODAL, "Transport Test", "There's no implementation for this test id." & @CRLF & $sCloseMsg, 10)
	EndSelect
	FileCopy ($sOutPutFile, $sWindowContentFilePath ,1)
EndFunc

Func Test01()
	_Log("Executing Function Test01")
	startApp()
	sendCommandToWindow("Sleep|1500;1;{ENTER};Sleep|1000;5;{ENTER};exit;{ENTER}")
	Return FileRead(@ScriptDir & "\er01.dp") = FileRead($sOutPutFile)
EndFunc

Func Test04()
	_Log("Executing Function Test04")
	startApp()
	sendCommandToWindow("Sleep|1500;1;{ENTER};Sleep|1000;2;{ENTER};Sleep|1000;5;{ENTER};exit;{ENTER}")
	Return FileRead(@ScriptDir & "\er04.dp") = FileRead($sOutPutFile)
EndFunc

Func Test05()
	_Log("Executing Function Test05")
	startApp()
	sendCommandToWindow("Sleep|1500;2;{ENTER};Sleep|1000;5;{ENTER};exit;{ENTER}")
	Return FileRead(@ScriptDir & "\er05.dp") = FileRead($sOutPutFile)
EndFunc

Func Test07()
	_Log("Executing Function Test07")
	startApp()
	sendCommandToWindow("Sleep|1500;1;{ENTER};Sleep|1000;4;{ENTER};Sleep|3000;5;{ENTER};exit;{ENTER}")
	Return FileRead(@ScriptDir & "\er07.dp") = FileRead($sOutPutFile)
EndFunc


Func getWindow($sTitle, $dSeconds = 0)
	_Log("Executing Function getWindow")
	Local $hWnd
	For $i = 0 To $dSeconds
		$hWnd = WinActivate($sTitle)
		If $hWnd <> 0 Then
			ExitLoop
		Endif
		Sleep(1000)
	Next
	Return $hWnd
EndFunc


Func init()
	_Log("Executing Function init")
	saveStatus("")
	writeToFile($sOutPutFile, "")
EndFunc


Func saveStatus($sContent)
	writeToFile($sStatusFilePath, $sContent)
EndFunc


Func sendCommandToWindow($sCommand, $hWnd = 0)
	_Log("Executing Function sendCommandToWindow")
	If $hWnd = 0 Then
		$hWnd = getWindow("[REGEXPTITLE:.*Transport\.exe.*]", 5)	
	EndIf
	If $hWnd <> 0 Then
		Local $aList = StringSplit($sCommand, ";", 1)
		For $i = 1 To $aList[0]
			Local $aSleep = StringSplit($aList[$i], "|", 1)
			If $aSleep[0] = 2 Then
				Sleep($aSleep[2])
			Else
				Send($aList[$i])
			EndIf
		Next
	EndIf
EndFunc


Func setArguments($aParams)
	_Log("Executing Function setArguments: " & _ArrayToString($aParams))
	Local $bInvalid = False
	If $aParams[0] <> 2 Then
		$bInvalid = True
	Else
		Select
			Case $aParams[1] = "-test"
				runTest($aParams[2])
			
			Case Else
				_Log("Invalid Parameter. " & $aParams[1])
				$bInvalid = True
		EndSelect
	EndIf
	
	If $bInvalid Then
		MsgBox($MB_SYSTEMMODAL, "Transport Test", "Invalid Parameter." & @CRLF & $sCloseMsg, 10)
	EndIf
EndFunc


Func setStatus($bStatus)
	Local $sStatus = "Failed"
	If $bStatus Then
		$sStatus = "Passed"
	Else
		writeToFile($sErrorMessageFilePath, $sErrorMessage)
	EndIf
	_Log("Status set to: " & $sStatus)
	saveStatus($sStatus)
	MsgBox($MB_SYSTEMMODAL, "Transport Test Result", "This test case has " & $sStatus & "." & @CRLF & "This message box close after 10 seconds or select the OK button.", 10)
EndFunc


Func startApp()
	_Log("Executing Function startApp")
	Local $CMD = "powershell "".\Transport.exe | tee op.dp"""
	Run('"' & @ComSpec & '" /k ' & $CMD, $sAppPath)
EndFunc


Func writeToFile($sFilePath, $sContent, $dMode = $FO_OVERWRITE)
	Local $hFileOpen = FileOpen($sFilePath, $dMode)
	FileWrite($hFileOpen, $sContent)
	FileClose($hFileOpen)
EndFunc


; User's COM error function. Will be called if COM error occurs
Func _ErrFunc($oError)
    ; Do anything here.
    _Log(@ScriptName & " (" & $oError.scriptline & ") : ==> COM Error intercepted !" & @CRLF & _
            @TAB & "err.number is: " & @TAB & @TAB & "0x" & Hex($oError.number) & @CRLF & _
            @TAB & "err.windescription:" & @TAB & $oError.windescription & @CRLF & _
            @TAB & "err.description is: " & @TAB & $oError.description & @CRLF & _
            @TAB & "err.source is: " & @TAB & @TAB & $oError.source & @CRLF & _
            @TAB & "err.helpfile is: " & @TAB & $oError.helpfile & @CRLF & _
            @TAB & "err.helpcontext is: " & @TAB & $oError.helpcontext & @CRLF & _
            @TAB & "err.lastdllerror is: " & @TAB & $oError.lastdllerror & @CRLF & _
            @TAB & "err.scriptline is: " & @TAB & $oError.scriptline & @CRLF & _
            @TAB & "err.retcode is: " & @TAB & "0x" & Hex($oError.retcode) & @CRLF & @CRLF)
EndFunc   ;==>_ErrFunc

Func _FailSafe($sMsg)
	_Log("An error has occurred: " & $sMsg)
	saveStatus("Failed")
	_Log("###########################END OF AUTOIT SCRIPT#######################")
	Exit
EndFunc


Func _Log($msg, $bError = False)
	_FileWriteLog(@ScriptDir & "\Result\run" & $today & ".log", $msg)
	If $bError Then
		$sErrorMessage = $msg
	EndIf
EndFunc

