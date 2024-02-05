Use FitnessClub
Go

Create procedure AddTimetable
@DateTime nvarchar(40), @CoachId int, @WorkoutId int, @GymId int
As
Begin
Insert dbo.[Timetables] Values (@DateTime, @CoachId, @WorkoutId, @GymId, 0)
End
Go

Create procedure AddClientTimetable
@ClientId int, @TimetableId int
As
Begin
Insert dbo.[Clients_Timetables] Values (@ClientId, @TimetableId)
End
Go

Create procedure DeleteTimetableById 
@Id int
As
Begin
Update dbo.[Timetables]
Set  [IsDeleted]=1
Where [Id]=@Id
End
Go

Create procedure DeleteClientTimetable
@ClientId int, @TimetableId int
As
Begin
Delete From dbo.[Clients_Timetables]
Where [ClientId]=@ClientId and [TimetableId]=@TimetableId
End
Go

Create procedure GetTimetableWithWorkoutById
@Id int
As
Begin
Select T.[Id], [DateTime], [CoachId], [WorkoutId], [GymId], 
W.[SportTypeId] as SportTypeId, W.[Price], W.[Duration], W.[NumberPlaces], W.[IsGroup], W.[Comment] from dbo.[Timetables] as T
Join dbo.[Workouts] as W on T.[WorkoutId]=W.[Id]
Where T.[Id]=@Id and T.[IsDeleted]=0
End
Go

Create procedure GetAllTimetablesWithWorkouts
As
Begin
Select T.[Id], [DateTime], [CoachId], [WorkoutId], [GymId], 
W.[SportTypeId] as SportTypeId, W.[Price], W.[Duration], W.[NumberPlaces], W.[IsGroup], W.[Comment] from dbo.[Timetables] as T
Join dbo.[Workouts] as W on T.[WorkoutId]=W.[Id]
Where T.[IsDeleted]=0
End
Go

Create procedure GetAllDeletedTimetablesWithWorkouts
As
Begin
Select T.[Id], [DateTime], [CoachId], [WorkoutId], [GymId], 
W.[SportTypeId] as SportTypeId, W.[Price], W.[Duration], W.[NumberPlaces], W.[IsGroup], W.[Comment] from dbo.[Timetables] as T
Join dbo.[Workouts] as W on T.[WorkoutId]=W.[Id]
Where T.[IsDeleted]=1
End
Go
