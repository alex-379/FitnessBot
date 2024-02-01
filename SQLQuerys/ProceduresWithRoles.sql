Use FitnessBot
Go

Create procedure AddRole
	@Name nvarchar(20),
	@IsDeleted bit
As
Begin
Insert dbo.[Roles] values (@Name, @IsDeleted)
End
Go

Create trigger products_delete
On dbo.[Roles]
Instead of delete
As
Update dbo.[Roles]
Set IsDeleted = 1
Where Id = (Select Id From deleted)
Go

Create procedure DeleteRoleById
	@Id int
As
Begin
Delete From dbo.[Roles]
Where [Id] = @Id
End
Go

Create procedure GetAllRoles As
Begin
Select R.[Id], R.[Name] From dbo.[Roles] As R
Where R.[IsDeleted] = 0
End
Go

