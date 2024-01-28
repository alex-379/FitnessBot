Use FitnessBot
Go

Create procedure AddWorkoutTypesToCoach
@CoachId int, @WorkoutTypeId int
As
Begin
Insert into [Coaches_WorkoutTypes] values (@CoachId, @WorkoutTypeId)
End
Go
