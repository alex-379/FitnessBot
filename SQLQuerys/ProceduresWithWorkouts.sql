Use [FitnessClub]

Go

Create procedure AddWorkout
	@SportTypeId int,
	@Price decimal NULL,
	@Duration int NULL,
	@NumberPlaces int NULL,
	@IsGroup bit NULL,
	@Comment nvarchar(250) NULL 
As
Begin
	Insert dbo.[Workouts]
	Output Inserted.Id
	Values (@SportTypeId, @Price, @Duration, @NumberPlaces, @IsGroup, @Comment, 0)
End

Go

Create Procedure GetAllWorkouts As
Begin
	Select [Id], [SportTypeId], [Price], [Duration], [NumberPlaces], [IsGroup], [Comment] from dbo.[Workouts]
	Where [IsDeleted] = 0
End

Go

Create Procedure GetWorkoutById
@Id int
AS
Begin
	Select [Id], [SportTypeId], [Price], [Duration], [NumberPlaces], [IsGroup], [Comment] from dbo.[Workouts]
	Where [Id]=@Id and [IsDeleted] = 0
End

Go

Create procedure UpdateWorkoutOnId
	@Id int,
	@SportTypeId int,
	@Price decimal NULL,
	@Duration int NULL,
	@NumberPlaces int NULL,
	@IsGroup bit NULL,
	@Comment nvarchar(250) NULL 
As
Begin
	Update dbo.[Workouts]
	Set [SportTypeId] = @SportTypeId, [Price] = @Price, [Duration] = @Duration, [NumberPlaces] = @NumberPlaces, 
	[IsGroup] = @IsGroup, [Comment] = @Comment
	Where [Id]=@Id
End

Go

Create procedure DeleteWorkoutOnId  
	@Id int 
As 
Begin 
	Update dbo.[Workouts] 
	Set  [IsDeleted]=1 
	Where [Id]=@Id 
End

Go

Create procedure GetAllWorkoutsWithSportType
As
Begin
	Select W.[Id], W.[Price], W.[Duration], W.[NumberPlaces], W.[IsGroup], W.[Comment],
	ST.[Id] As [SportTypeId], ST.[Name] As [SportType] from dbo.[Workouts] as W
	Join dbo.SportTypes as ST on W.[SportTypeId] = ST.[Id]
	Where W.[IsDeleted] = 0
End

Go

Create procedure GetWorkoutWithSportTypeById
	@Id int
As
Begin
	Select W.[Id], W.[Price], W.[Duration], W.[NumberPlaces], W.[IsGroup], W.[Comment],
	ST.[Id] As [SportTypeId], ST.[Name] As [SportType] from dbo.[Workouts] as W
	Join dbo.SportTypes as ST on W.[SportTypeId] = ST.[Id]
	Where W.[Id]=@Id and W.[IsDeleted] = 0
End

Go

Create procedure GetWorkoutWithSportTypeBySportTypeId
	@SportTypeId int
As
Begin
	Select W.[Id], W.[Price], W.[Duration], W.[NumberPlaces], W.[IsGroup], W.[Comment],
	ST.[Id] As [SportTypeId], ST.[Name] As [SportType] from dbo.[Workouts] as W
	Join dbo.SportTypes as ST on W.[SportTypeId] = ST.[Id]
	Where W.[SportTypeId]=@SportTypeId and W.[IsDeleted] = 0
End

Go