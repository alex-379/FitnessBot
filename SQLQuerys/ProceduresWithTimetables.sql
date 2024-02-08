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
Select T.[Id], [DateTime], P.[Id], P.[FamilyName], G.[Id], 
G.[Name], S.[Id], S.[Name], WT.[Id], WT.[Name], W.[Id], W.[Price], W.[Duration], 
W.[NumberPlaces], W.[IsGroup], W.[Comment] from dbo.[Timetables] as T
Join dbo.[Workouts] as W on T.[WorkoutId]=W.[Id]
Join dbo.[SportTypes] as S on W.[SportTypeId]=S.[Id]
Join dbo.[Gyms] as G on T.[GymId]=G.[Id]
Join dbo.[Persons] as P on T.[CoachId]=P.[Id]
Join dbo.[Coaches_WorkoutTypes] as CW on T.[CoachId]=CW.[CoachId]
Join dbo.[WorkoutTypes] as WT on CW.[WorkoutTypeId]=WT.[Id]
Where T.[Id]=@Id and T.[IsDeleted]=0
End
Go

Create procedure GetAllTimetablesWithWorkouts
As
Begin
Select T.[Id], [DateTime], P.[Id], P.[FamilyName], G.[Id], 
G.[Name], S.[Id], S.[Name], WT.[Id], WT.[Name], W.[Id], W.[Price], W.[Duration], 
W.[NumberPlaces], W.[IsGroup], W.[Comment] from dbo.[Timetables] as T
Join dbo.[Workouts] as W on T.[WorkoutId]=W.[Id]
Join dbo.[SportTypes] as S on W.[SportTypeId]=S.[Id]
Join dbo.[Gyms] as G on T.[GymId]=G.[Id]
Join dbo.[Persons] as P on T.[CoachId]=P.[Id]
Join dbo.[Coaches_WorkoutTypes] as CW on T.[CoachId]=CW.[CoachId]
Join dbo.[WorkoutTypes] as WT on CW.[WorkoutTypeId]=WT.[Id]
Where T.[IsDeleted]=0
End
Go

Create procedure GetAllDeletedTimetablesWithWorkouts
As
Begin
Select T.[Id], [DateTime], P.[Id], P.[FamilyName], G.[Id], 
G.[Name], S.[Id], S.[Name], WT.[Id], WT.[Name], W.[Id], W.[Price], W.[Duration], 
W.[NumberPlaces], W.[IsGroup], W.[Comment] from dbo.[Timetables] as T
Join dbo.[Workouts] as W on T.[WorkoutId]=W.[Id]
Join dbo.[SportTypes] as S on W.[SportTypeId]=S.[Id]
Join dbo.[Gyms] as G on T.[GymId]=G.[Id]
Join dbo.[Persons] as P on T.[CoachId]=P.[Id]
Join dbo.[Coaches_WorkoutTypes] as CW on T.[CoachId]=CW.[CoachId]
Join dbo.[WorkoutTypes] as WT on CW.[WorkoutTypeId]=WT.[Id]
Where T.[IsDeleted]=1
End
Go

Create procedure GetAllTimetablesWithWorkoutsClients
As
Begin
Select T.[Id], [DateTime], P.[Id], P.[FamilyName], G.[Id], 
G.[Name], S.[Id], S.[Name], WT.[Id], WT.[Name], W.[Id], W.[Price], W.[Duration], 
W.[NumberPlaces], W.[IsGroup], W.[Comment], C.[Id], C.[FamilyName]  from dbo.[Timetables] as T
Join dbo.[Workouts] as W on T.[WorkoutId]=W.[Id]
Join dbo.[SportTypes] as S on W.[SportTypeId]=S.[Id]
Join dbo.[Gyms] as G on T.[GymId]=G.[Id]
Join dbo.[Persons] as P on T.[CoachId]=P.[Id]
Join dbo.[Coaches_WorkoutTypes] as CW on T.[CoachId]=CW.[CoachId]
Join dbo.[WorkoutTypes] as WT on CW.[WorkoutTypeId]=WT.[Id]
Join dbo.[Clients_Timetables] As CT On T.[Id] = CT.[TimetableId]
Join dbo.[Persons] as C on CT.[ClientId]=C.[Id]
Where T.[IsDeleted]=0
End
Go

Create procedure GetTimetableWithWorkoutsClientsById
@Id int
As
Begin
Select T.[Id], [DateTime], P.[Id], P.[FamilyName], G.[Id], 
G.[Name], S.[Id], S.[Name], WT.[Id], WT.[Name], W.[Id], W.[Price], W.[Duration], 
W.[NumberPlaces], W.[IsGroup], W.[Comment], C.[Id], C.[FamilyName]  from dbo.[Timetables] as T
Join dbo.[Workouts] as W on T.[WorkoutId]=W.[Id]
Join dbo.[SportTypes] as S on W.[SportTypeId]=S.[Id]
Join dbo.[Gyms] as G on T.[GymId]=G.[Id]
Join dbo.[Persons] as P on T.[CoachId]=P.[Id]
Join dbo.[Coaches_WorkoutTypes] as CW on T.[CoachId]=CW.[CoachId]
Join dbo.[WorkoutTypes] as WT on CW.[WorkoutTypeId]=WT.[Id]
Join dbo.[Clients_Timetables] As CT On T.[Id] = CT.[TimetableId]
Join dbo.[Persons] as C on CT.[ClientId]=C.[Id]
Where T.[Id]=@Id and T.[IsDeleted]=0
End
Go