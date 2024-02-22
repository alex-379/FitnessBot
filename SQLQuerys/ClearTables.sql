Use [FitnessClub]

Truncate TABLE Coaches_SportTypes

Truncate TABLE Coaches_WorkoutTypes

Truncate TABLE Clients_Timetables

Delete from [Timetables]
DBCC CHECKIDENT ([Timetables], RESEED, 0)
Go

Delete from [Persons]
DBCC CHECKIDENT ([Persons], RESEED, 0)
Go

Delete from [Workouts]
DBCC CHECKIDENT ([Workouts], RESEED, 0)
Go