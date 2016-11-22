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
rem %envdir%\csc /nologo /target:exe /out:%exename% MainApp.cs Floare.cs FloareDialog.cs FloareDialog.Designer.cs FloareDialog.FloareTree.cs FloareDialog.FloareList.cs /resource:textressample.txt
%envdir%\csc /nologo /target:exe /out:%exename% *.cs /resource:textressample.txt
@if exist MainApp.exe MainApp flori.db
@if exist MainApp.exe del MainApp.exe