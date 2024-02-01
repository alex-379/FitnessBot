Use FitnessClub
Go

Create procedure AddPerson
@RoleId int, @FamilyName nvarchar(20) = null, @FirstName nvarchar(20) = null, @Patronymic nvarchar(20) = null, @PhoneNumber nvarchar(12) = null, 
@Email nvarchar(40) =null, @DateBirth nvarchar(20) = null, @Sex bit = null
As
Begin
Insert dbo.[Persons] Values (@RoleId, @FamilyName, @FirstName, @Patronymic, @PhoneNumber, @Email, @DateBirth, @Sex, 0)
End
Go

Create procedure AddCoachSportType
@CoachId int, @SportTypeId int
As
Begin
Insert dbo.[Coaches_SportTypes] Values (@CoachId, @SportTypeId)
End
Go

Create procedure AddCoachWorkoutType
@CoachId int, @WorkoutTypeId int
As
Begin
Insert dbo.[Coaches_WorkoutTypes] Values (@CoachId, @WorkoutTypeId)
End
Go

Create procedure GetAllPerson As
Begin
Select [Id], [RoleId], [FamilyName], [FirstName], [Patronymic], [PhoneNumber], [Email], [DateBirth], [Sex] from dbo.[Persons]
Where [IsDeleted] = 0
End
Go

Create procedure GetPersonById
@Id int
As
Begin
Select [Id], [RoleId], [FamilyName], [FirstName], [Patronymic], [PhoneNumber], [Email], [DateBirth], [Sex] from dbo.[Persons]
Where [Id]=@Id and [IsDeleted] <> 0
End
Go

exec GetPersonById 1
Go

Create procedure UpdatePersonById
--@Id int, @RoleId int = 'GetPersonById 2', @FamilyName nvarchar(20)= [FamilyName], @FirstName nvarchar(20) = [FirstName], @Patronymic  nvarchar(20) = [Patronymic], @PhoneNumber nvarchar(12) = [PhoneNumber], 
--@Email nvarchar(40) = [Email], @DateBirth int = [DateBirth], @Sex bit = [Sex]
@Id int, @RoleId int, @FamilyName nvarchar(20), @FirstName nvarchar(20), @Patronymic  nvarchar(20), @PhoneNumber nvarchar(12), 
@Email nvarchar(40), @DateBirth int, @Sex bit
As
Begin
Update dbo.[Persons]
Set [RoleId]=@RoleId, [FamilyName]=@FamilyName, [FirstName]=@FirstName, [Patronymic]=@Patronymic, [PhoneNumber]=@PhoneNumber, [Email]=@Email,
[DateBirth]=@DateBirth, [Sex]=@Sex
Where [Id]=@Id and [IsDeleted]=0
End
Go

exec UpdatePersonById 2, @FamilyName=Petrov
Go

Create procedure UpdateCoachSportTypeByCoachId
@CoachId int, @SportTypeId int
As
Begin
Update dbo.[Coaches_SportTypes]
Set [CoachId]=@CoachId, [SportTypeId]=@SportTypeId
End
Go

Create procedure UpdateCoachWorkoutTypeByCoachId
@CoachId int, @WorkoutTypeId int
As
Begin
Update dbo.[Coaches_WorkoutTypes]
Set [CoachId]=@CoachId, [WorkoutTypeId]=@WorkoutTypeId
End
Go

Create procedure DeletePersonById 
@Id int
As
Begin
Update dbo.[Persons]
Set  [IsDeleted]=1
Where [Id]=@Id
End
Go

Create procedure DeleteCoachSportTypeByCoachId 
@CoachId int
As
Begin
Delete From dbo.[Coaches_SportTypes]
Where [CoachId]=@CoachId
End
Go

Create procedure DeleteCoachWorkoutTypeByCoachId 
@CoachId int
As
Begin
Delete From dbo.[Coaches_WorkoutTypes]
Where [CoachId]=@CoachId
End
Go

Create procedure GetAllPersonsByRole
@Id int
As
Begin
Select P.[Id], [FamilyName], [FirstName], [Patronymic], [PhoneNumber], [Email], [Age], [Sex],
ST.[Id] as SportTypeId, ST.[Name] as SportTypeName, WT.[Id] as WorkTypeId, WT.[Name] as WorkTypeName from dbo.[Persons] as P
Join dbo.[Coaches_SportTypes] as CST on P.[Id]=CST.[CoachId]
Join dbo.[SportTypes] as ST on CST.[SportTypeId]=ST.[Id]
Join dbo.[Coaches_WorkoutTypes] as CWT on P.[Id]=CWT.[CoachId]
Join dbo.[WorkoutTypes] as WT on CWT.[WorkoutTypeId]=WT.[Id]
Where P.[Id]=@Id and P.[IsDeleted]=0
End
Go