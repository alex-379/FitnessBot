Use FitnessClub
Go

Create procedure AddPerson
@RoleId int, @FamilyName nvarchar(20), @FirstName nvarchar(20), @Patronymic  nvarchar(20), @PhoneNumber nvarchar(12), 
@Email nvarchar(40), @DateBirth nvarchar(20), @Sex bit
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
Where [IsDeleted] <> 0
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

Create procedure UpdatePersonById
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