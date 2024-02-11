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

Create procedure GetWorkoutWithSportTypes
As
BEGIN
	Select W.[Id],  W.[Price], W.[Duration], W.[NumberPlaces], W.[IsGroup], 
	St.[Id], St.[Name] from dbo.[Workouts] as W 
	join dbo.[SportTypes] as St on W.[SportTypeId] = St.[Id]
END

Go

Create procedure GetWorkoutWithSportTypeCoaches
As
BEGIN
	Select W.[Id], W.[Price], W.[Duration], W.[NumberPlaces], W.[IsGroup],
	St.[Id], St.[Name], C.[CoachId] from dbo.[Workouts] as W
	join dbo.SportTypes as St on W.[SportTypeId] = St.[Id]
	join dbo.Coaches_SportTypes as C on St.[Id] = C.[SportTypeId]
END

Go