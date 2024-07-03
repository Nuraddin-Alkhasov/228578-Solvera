@echo off 

IF NOT EXIST "C:\Backup\" MKDIR C:\Backup


IF EXIST "C:\Backup\*Alarms*" DEL /Q /F "C:\Backup\*Alarms*"
IF EXIST "C:\Backup\*Logs*" DEL /Q /F "C:\Backup\*Logs*"
IF EXIST "C:\Backup\*Orders*" DEL /Q /F "C:\Backup\*Orders*"
IF EXIST "C:\Backup\*Recipes*" DEL /Q /F "C:\Backup\*Recipes*"

sqlcmd -S 228578-Solvera\MSSQLE -U sa -P 2555 -i "C:\Users\Public\Documents\VisiWin 7\7.2\Projects\228578-Solvera\Resources\SQL\Backup.sql"
sqlcmd -S 228578-Solvera\MSSQLE -U sa -P 2555 -i "C:\Users\Public\Documents\VisiWin 7\7.2\Projects\228578-Solvera\Resources\SQL\ClearAlarms.sql"
sqlcmd -S 228578-Solvera\MSSQLE -U sa -P 2555 -i "C:\Users\Public\Documents\VisiWin 7\7.2\Projects\228578-Solvera\Resources\SQL\ClearLogs.sql"
sqlcmd -S 228578-Solvera\MSSQLE -U sa -P 2555 -i "C:\Users\Public\Documents\VisiWin 7\7.2\Projects\228578-Solvera\Resources\SQL\ClearProtocol.sql"
