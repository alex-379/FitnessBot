Use FitnessBot
Go

Create procedure AddWorkoutTypesByName
@Name nvarchar(30), @IsDeleted bit
As
Begin
Insert into [WorkoutTypes] values (@Name, @IsDeleted)
End
Go
