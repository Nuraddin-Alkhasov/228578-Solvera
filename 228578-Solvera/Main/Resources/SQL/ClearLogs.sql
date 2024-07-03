
DELETE FROM [VisiWin#Logs].[dbo].[Logbook#Logging] WHERE [Date] < dateadd(YEAR, -3, cast(getdate() as date))
