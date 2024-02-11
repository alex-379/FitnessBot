Use [FitnessClub]

Go

Create procedure AddTimetable
@DateTime nvarchar(40), @CoachId int, @WorkoutId int, @GymId int
As
Begin
Insert dbo.[Timetables]
Output Inserted.Id
Values (@DateTime, @CoachId, @WorkoutId, @GymId, 0)
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
Select [Id], [DateTime], [CoachId], [WorkoutId], [GymId] from dbo.[Timetables]
Where [IsDeleted] = 0
End

Go

Create procedure GetTimetableById
@Id int
As
Begin
Select [Id], [DateTime], [CoachId], [WorkoutId], [GymId] from dbo.[Timetables]
Where [Id]=@Id and [IsDeleted] = 0
End

Go

Create procedure UpdateTimetableOnId
@Id int, @DateTime nvarchar(20), @CoachId int, @WorkoutId int, @GymId int
As
Begin
Update dbo.[Timetables]
Set [DateTime]=@DateTime, [CoachId]=@CoachId, [WorkoutId]=@WorkoutId, [GymId]=@GymId
Where [Id]=@Id
End

Go

Create procedure DeleteTimetableOnId 
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

Create procedure GetAllTimetablesWithCoachWorkoutsGymsClients
As
Begin
Select T.[Id], T.[DateTime], 
PCL.[Id] As [ClientId], PCL.[FamilyName] As [ClientFamilyName], PCL.[FirstName] As [ClientFirstName], PCL.[Patronymic] As [ClientPatronymic], PCL.[PhoneNumber] As [ClientPhoneNumber], PCL.[Email] As [ClientEmail], PCL.[DateBirth] As [CLientDateBirth], PCL.[Sex] As [ClientSex],
PC.[Id] As [CoachId], PC.[FamilyName] As [CoachFamilyName], PC.[FirstName] As [CoachFirstName], PC.[Patronymic] As [CoachPatronymic], PC.[PhoneNumber] As [CoachPhoneNumber], PC.[Email] As [CoachEmail], PC.[DateBirth] As [CoachDateBirth], PC.[Sex] As [CoachSex],
W.[Id] As [WorkoutId], W.[Price], W.[Duration], W.[NumberPlaces], W.[IsGroup], W.[Comment],
ST.[Id] As [SportTypeId], ST.[Name] As SportType,
G.[Id] As [GymId], G.[Name] As [Gym] from dbo.[Timetables] as T
Join dbo.[Clients_Timetables] As CT On T.[Id] = CT.[TimetableId]
Join dbo.[Persons] as PCL on CT.[ClientId]= PCL.[Id]
Join dbo.[Persons] as PC on T.[CoachId]=PC.[Id]
Join dbo.[Workouts] as W on T.[WorkoutId]=W.[Id]
Join dbo.[SportTypes] as ST on W.[SportTypeId]=ST.[Id]
Join dbo.[Gyms] as G on T.[GymId]=G.[Id]
Where T.[IsDeleted]=0
End


Create procedure GetTimetableWithCoachWorkoutsGymsClientsById
@Id int
As
Begin
Select T.[Id], T.[DateTime], 
PCL.[Id] As [ClientId], PCL.[FamilyName] As [ClientFamilyName], PCL.[FirstName] As [ClientFirstName], PCL.[Patronymic] As [ClientPatronymic], PCL.[PhoneNumber] As [ClientPhoneNumber], PCL.[Email] As [ClientEmail], PCL.[DateBirth] As [CLientDateBirth], PCL.[Sex] As [ClientSex],
PC.[Id] As [CoachId], PC.[FamilyName] As [CoachFamilyName], PC.[FirstName] As [CoachFirstName], PC.[Patronymic] As [CoachPatronymic], PC.[PhoneNumber] As [CoachPhoneNumber], PC.[Email] As [CoachEmail], PC.[DateBirth] As [CoachDateBirth], PC.[Sex] As [CoachSex],
W.[Id] As [WorkoutId], W.[Price], W.[Duration], W.[NumberPlaces], W.[IsGroup], W.[Comment],
ST.[Id] As [SportTypeId], ST.[Name] As SportType,
G.[Id] As [GymId], G.[Name] As [Gym] from dbo.[Timetables] as T
Join dbo.[Clients_Timetables] As CT On T.[Id] = CT.[TimetableId]
Join dbo.[Persons] as PCL on CT.[ClientId]= PCL.[Id]
Join dbo.[Persons] as PC on T.[CoachId]=PC.[Id]
Join dbo.[Workouts] as W on T.[WorkoutId]=W.[Id]
Join dbo.[SportTypes] as ST on W.[SportTypeId]=ST.[Id]
Join dbo.[Gyms] as G on T.[GymId]=G.[Id]
Where T.[Id]=@Id T.[IsDeleted]=0
End