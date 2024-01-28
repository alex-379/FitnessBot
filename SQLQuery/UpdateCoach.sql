Use FitnessBot
Go

Create procedure UpdateCoach
@Id int, @FamilyName nvarchar(20), @FirstName nvarchar(20), @Patronymic  nvarchar(20), @PhoneNumber nvarchar(12), 
@Email nvarchar(40), @Age int, @Sex bit
As
Begin
Update  [Persons]
set  [FamilyName]=@FamilyName, [FirstName]=@FirstName, [Patronymic]=@Patronymic, [PhoneNumber]=@PhoneNumber, [Email]=@Email,
[Age]=@Age, [Sex]=@Sex
where [Id]=@Id and [IsDeleted]=0
End
Go
