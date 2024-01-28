Use FitnessBot
Go

Create procedure GetAllCoachesById
@Id int
As
Begin
Select P.[Id], [FamilyName], [FirstName], [Patronymic], [PhoneNumber], [Email], [Age], [Sex],
ST.[Id] as SportTypeId, ST.[Name] as SportTypeName, WT.[Id] as WorkTypeId, WT.[Name] as WorkTypeName from dbo.[Persons] as P
Join dbo.[Coaches_SportTypes] as CST on P.[Id]=CST.[CoachId]
Join dbo.[SportTypes] as ST on CST.[SportTypeId]=ST.[Id]
Join dbo.[Coaches_WorkoutTypes] as CWT on P.[Id]=CWT.[CoachId]
Join dbo.[WorkoutTypes] as WT on CWT.[WorkoutTypeId]=WT.[Id]
Where P.[Id]=@Id and P.[IsDeleted]=0
End
Go

