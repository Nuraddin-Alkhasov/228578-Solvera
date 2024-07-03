DELETE [VisiWin#Alarms].[dbo].[Alarms#Diagnose] WHERE [TimeIn] < dateadd(YEAR, -3, cast(getdate() as date))
