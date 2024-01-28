Use FitnessBot
Go

Create procedure DeleteCoach2
@Id int
As
Begin
Update  [Persons]
set  [IsDeleted]=1
where [Id]=@Id and [IsDeleted]=0
End
Go
