Use FitnessBot
Go

Create procedure AddCoach
@RoleId int, @FamilyName nvarchar(20), @FirstName nvarchar(20), @Patronymic  nvarchar(20), @PhoneNumber nvarchar(12), 
@Email nvarchar(40), @Age int, @Sex bit, @IsDeleted bit
As
Begin
Insert into [Persons] values (@RoleId, @FamilyName, @FirstName, @Patronymic, @PhoneNumber, @Email, @Age, @Sex, @IsDeleted)
End
Go
