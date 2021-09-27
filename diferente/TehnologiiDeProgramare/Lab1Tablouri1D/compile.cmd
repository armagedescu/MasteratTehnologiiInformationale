@set dotnetver=v4.0.30319
@set frmdir=Framework
@set frmdir=Framework64
@set dotnetdir=%windir%\Microsoft.NET
@set envdir=%dotnetdir%\%frmdir%\%dotnetver%
@set exename=Lab1Tablouri1D.exe
@if exist %exename% del %exename%
%envdir%\csc /nologo /target:exe /out:%exename% *.cs
@if exist %exename% %exename% solrdatabase.txt
@if exist  %exename% del  %exename%
