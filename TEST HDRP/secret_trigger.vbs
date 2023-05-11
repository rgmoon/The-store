WScript.Sleep 10000
dim x, fso, vbpath
Set x = WScript.CreateObject("WScript.Shell")
Set fso = CreateObject("Scripting.FileSystemObject")
vbpath = fso.GetParentFolderName(WScript.ScriptFullName)
suffix = "Assets\secret\P5-1\WindowsFormsApp1.exe"
fspec = fso.BuildPath(vbpath, suffix)
fspec = """" & fspec & """"
x.Run fspec