Use FitnessBot
Go

Create procedure AddSportTypesByName
@Name nvarchar(30), @IsDeleted bit
As
Begin
Insert into [SportTypes] values (@Name, @IsDeleted)
End
Go
