Use [FitnessClub]

Go

Create procedure AddTimetable
@CoachId int, @WorkoutId int, @GymId int, @Date nvarchar(20), @StartTime nvarchar(20)
As
Begin
Insert dbo.[Timetables]
Output Inserted.Id
Values (@CoachId, @WorkoutId, @GymId, @Date, @StartTime)
End

Go

Create procedure AddClientTimetable
@ClientId int, @TimetableId int
As
Begin
Insert dbo.[Clients_Timetables]
Values (@ClientId, @TimetableId)
End

Go

Create procedure GetAllTimetables As
Begin
Select [Id], [Date], [StartTime], [CoachId], [WorkoutId], [GymId] from dbo.[Timetables]
Where [IsCompleted] = 0
End

Go

Create procedure GetTimetableById
@Id int
As
Begin
Select [Id], [Date], [StartTime], [CoachId], [WorkoutId], [GymId] from dbo.[Timetables]
Where [Id]=@Id and [IsCompleted] = 0
End

Go

Create procedure UpdateTimetableOnId
@Id int, @CoachId int, @WorkoutId int, @GymId int, @Date nvarchar(20), @StartTime nvarchar(20)
As
Begin
Update dbo.[Timetables]
Set [CoachId]=@CoachId, [WorkoutId]=@WorkoutId, [GymId]=@GymId, [Date]=@Date, [StartTime]=@StartTime
Where [Id]=@Id
End

Go

Create procedure DeleteTimetableById 
@Id int
As
Begin
Update dbo.[Timetables]
Set [IsDeleted]=1
Where [Id]=@Id
End

Go

Create procedure UndeleteTimetableById 
@Id int
As
Begin
Update dbo.[Timetables]
Set [IsDeleted]=0
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

Create procedure GetAllTimetablesWithCoachWorkoutsGymsClients
As
Begin
Select T.[Id], T.[Date], T.[StartTime], 
PCL.[Id], PCL.[FamilyName], PCL.[FirstName], PCL.[Patronymic], PCL.[PhoneNumber], PCL.[Email], PCL.[DateBirth], PCL.[Sex],
PC.[Id], PC.[FamilyName], PC.[FirstName], PC.[Patronymic], PC.[PhoneNumber], PC.[Email], PC.[DateBirth], PC.[Sex],
W.[Id], W.[Price], W.[Duration], W.[NumberPlaces], W.[IsGroup], W.[Comment],
ST.[Id] As [SportTypeId], ST.[Name] As SportType,
G.[Id] As [GymId], G.[Name] As [Gym],
WT.[Id] as WorkoutTypeId, WT.[Name] as WorkoutType from dbo.[Timetables] as T
Join dbo.[Clients_Timetables] As CT On T.[Id] = CT.[TimetableId]
Join dbo.[Persons] as PCL on CT.[ClientId]= PCL.[Id]
Join dbo.[Persons] as PC on T.[CoachId]=PC.[Id]
Join dbo.[Workouts] as W on T.[WorkoutId]=W.[Id]
Join dbo.[SportTypes] as ST on W.[SportTypeId]=ST.[Id]
Join dbo.[Gyms] as G on T.[GymId]=G.[Id]
Join dbo.[Coaches_WorkoutTypes] As CW On PC.[Id]=CW.[CoachId]
Join dbo.[WorkoutTypes] as WT on CW.[WorkoutTypeId]= WT.[Id]
Where T.[IsDeleted]=0
End

Go

Create procedure GetTimetableWithCoachWorkoutsGymsClientsById
@Id int
As
Begin
Select T.[Id], T.[Date], T.[StartTime],
PCL.[Id], PCL.[FamilyName], PCL.[FirstName], PCL.[Patronymic], PCL.[PhoneNumber], PCL.[Email], PCL.[DateBirth], PCL.[Sex],
PC.[Id], PC.[FamilyName], PC.[FirstName], PC.[Patronymic], PC.[PhoneNumber], PC.[Email], PC.[DateBirth], PC.[Sex],
W.[Id], W.[Price], W.[Duration], W.[NumberPlaces], W.[IsGroup], W.[Comment],
ST.[Id] As [SportTypeId], ST.[Name] As SportType,
G.[Id] As [GymId], G.[Name] As [Gym] from dbo.[Timetables] as T
Join dbo.[Clients_Timetables] As CT On T.[Id] = CT.[TimetableId]
Join dbo.[Persons] as PCL on CT.[ClientId]= PCL.[Id]
Join dbo.[Persons] as PC on T.[CoachId]=PC.[Id]
Join dbo.[Workouts] as W on T.[WorkoutId]=W.[Id]
Join dbo.[SportTypes] as ST on W.[SportTypeId]=ST.[Id]
Join dbo.[Gyms] as G on T.[GymId]=G.[Id]
Where T.[Id]=@Id and T.[IsDeleted]=0
End

Go