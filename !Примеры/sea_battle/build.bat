del .\publish\net45\seabattle.exe 

dotnet clean seabattle.sln
dotnet build seabattle.sln

copy .\seabattle\bin\Debug\net45\seabattle.exe .\publish\net45\seabattle.exe 
