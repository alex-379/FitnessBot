Use FitnessBot
Go

Create procedure GetAllWorkoutTypesById
@Id int
As
Begin
Select [Id], [Name] from dbo.[WorkoutTypes] as WT
Where [Id]=@Id and WT.[IsDeleted]=0
End
Go
