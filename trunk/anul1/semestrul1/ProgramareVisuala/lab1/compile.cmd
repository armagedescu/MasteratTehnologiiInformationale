@set dotnetver=v4.0.30319
@set frmdir=Framework
@set frmdir=Framework64
@set dotnetdir=%windir%\Microsoft.NET
@set envdir=%dotnetdir%\%frmdir%\%dotnetver%
@set exename=MainApp.exe
@if not exist Floare.cs copy Floare.txt Floare.cs 
@if not exist MainApp.cs copy MainApp.txt MainApp.cs 
@if exist %exename% del %exename%
@if exist %exename% del %exename%
@if exist %exename% del %exename%
%envdir%\csc /nologo /target:exe /out:%exename% MainApp.cs Floare.cs /resource:textressample.txt
copy /Y Floare.cs Floare.txt
copy /Y MainApp.cs MainApp.txt
copy /Y compile.cmd compile.txt
@if exist MainApp.exe MainApp