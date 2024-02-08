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

Create Procedure GetAllWorkouts As
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

Create procedure DeleteWorkoutsById  
	@Id int 
As 
BEGIN 
	Update dbo.[Workouts] 
	Set  [IsDeleted]=1 
	Where [Id]=@Id 
END
Go 

Create procedure UpdateWorkoutsById
	@Id int,
	@SportTypeId int,
	@Price int NULL,
	@Duration int NULL,
	@NumberPlaces int NULL,
	@IsGroup bit NULL,
	@Comment nvarchar(250) NULL 
As
BEGIN
	Update dbo.[Workouts]
	Set [SportTypeId] = @SportTypeId, [Price] = @Price, [Duration] = @Duration, [NumberPlaces] = @NumberPlaces, 
	[IsGroup] = @IsGroup, [Comment] = @Comment
	Where [Id]=@Id and [IsDeleted]=0
END
Go