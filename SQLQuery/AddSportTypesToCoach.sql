Use FitnessBot
Go

Create procedure AddSportTypesToCoach
@CoachId int, @SportTypeId int
As
Begin
Insert into [Coaches_SportTypes] values (@CoachId, @SportTypeId)
End
Go
