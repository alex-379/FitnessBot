Use FitnessBot
Go

Create procedure GetAllSportTypesById
@Id int
As
Begin
Select [Id], [Name] from dbo.[SportTypes]
Where [Id]=@Id
End
Go
