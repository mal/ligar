Option Explicit

If WScript.Arguments.length = 0 Then
  CreateObject("Shell.Application").ShellExecute "cscript.exe", _
    Chr(34) & WScript.ScriptFullName & Chr(34) & " uac", "", "runas", 1
Else
  Dim liger, handler, options

  WScript.StdOut.Write "liger.exe: "
  liger = WScript.StdIn.ReadLine

  WScript.StdOut.Write "handler: "
  handler = WScript.StdIn.ReadLine

  WScript.StdOut.Write "options: "
  options = WScript.StdIn.ReadLine

  CreateObject("WScript.Shell").RegWrite _
    "HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\notepad.exe\Debugger", _
    Chr(34) + liger + Chr(34) + " " + _
      Chr(34) + handler + Chr(34) + " " + _
      options + " ---", _
    "REG_SZ"

  WScript.StdOut.WriteBlankLines 1
  WScript.StdOut.Write "Registry key written."
  WScript.Sleep 1000
End If
