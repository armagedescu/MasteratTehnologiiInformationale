@set dotnetver=v4.0.30319
@set frmdir=Framework
@set frmdir=Framework64
@set dotnetdir=%windir%\Microsoft.NET
@set envdir=%dotnetdir%\%frmdir%\%dotnetver%
%envdir%\csc /nologo /target:winexe /out:MDIApp.exe /main:MDIApp *.cs
Pause
