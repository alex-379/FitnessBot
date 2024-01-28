Use FitnessBot
Go

Create procedure GetAllSportTypesById
@Id int
As
Begin
Select [Id], [Name] from dbo.[SportTypes] as ST
Where [Id]=@Id and St.[IsDeleted]=0
End
Go
