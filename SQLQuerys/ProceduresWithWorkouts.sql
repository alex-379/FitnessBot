Use FitnessClub
Go

Create procedure AddWorkouts
	@SportTypeId int,
	@Price int NULL,
	@Duration int NULL,
	@NumberPlaces int NULL,
	@IsGroup bit NULL,
	@Comment nvarchar(250) NULL 
As
BEGIN
	INSERT dbo.[Workouts] Values (@SportTypeId, @Price, @Duration, @NumberPlaces, @IsGroup, @Comment, 0)
END
Go

Create Procedure GetAllWorkots AS
BEGIN
	Select [Id], [SportTypeId], [Price], [Duration], [NumberPlaces], [IsGroup], [Comment] from dbo.[Workouts]
	Where [IsDeleted] = 0
END
Go

Create Procedure GetWorkoutsById
@Id int
AS
BEGIN
	Select [Id], [SportTypeId], [Price], [Duration], [NumberPlaces], [IsGroup], [Comment] from dbo.[Workouts]
	Where [Id]=@Id and [IsDeleted] <> 0
END
Go