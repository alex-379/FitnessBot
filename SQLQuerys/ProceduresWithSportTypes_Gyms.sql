Use [FitnessClub]

Go

Create procedure GetAllSportTypes As
Begin
Select [Id] As [SportTypeId], [Name] As [SportType] from dbo.[SportTypes]
End

Go

Create procedure GetAllGyms As
Begin
Select [Id] As [GymId], [Name] As [Gym] from dbo.[Gyms]
End

Go