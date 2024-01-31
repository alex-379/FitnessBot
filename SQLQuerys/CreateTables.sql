Create database FitnessClub
Go

Use FitnessClub

Create table [Roles]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY,
	[Name] nvarchar (20) NOT NULL,
	[IsDeleted] bit NOT NULL
)
Go

Create table [Persons]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY,
	[RoleId] int NOT NULL,
	[FamilyName] nvarchar (20),
	[FirstName] nvarchar (20),
	[Patronymic] nvarchar (20),
	[PhoneNumber] nvarchar (12),
	[Email] nvarchar (40),
	[DateBirth] nvarchar (20),
	[Sex] bit,
	[IsDeleted] bit NOT NULL
)
Go

Create table [WorkoutTypes]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY,
	[Name] nvarchar (50) NOT NULL,
	[IsDeleted] bit NOT NULL
)
Go

Create table SportTypes
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY,
	[Name] nvarchar (50) NOT NULL,
	[IsDeleted] bit NOT NULL
)
Go

Create table Workouts
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY,
	[SportTypeId] int NOT NULL,
	[Price] decimal,
	[Duration] int,
	[NumberPlaces] int,
	[IsGroup] bit,
	[Comment] nvarchar (255),
	[IsDeleted] bit NOT NULL
)
Go

Create table [Gyms]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY,
	[Name] nvarchar (50) NOT NULL,
	[IsDeleted] bit NOT NULL
)
Go

Create table [Timetables]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY,
	[DateTime] nvarchar (20) NOT NULL,
	[CoachId] int NOT NULL,
	[WorkoutId] int NOT NULL,
	[GymId] int NOT NULL,
	[IsDeleted] bit NOT NULL
)
Go

Create table Coaches_WorkoutTypes
(
	[CoachId] int NOT NULL,
	[WorkoutTypeId] int NOT NULL
)
Go

Create table Coaches_SportTypes
(
	[CoachId] int NOT NULL,
	[SportTypeId] int NOT NULL
)
Go

Create table [Clients_Timetables]
(
	[ClientId] int NOT NULL,
	[TimetableId] int NOT NULL
)
Go

Alter table [Persons]
Add FOREIGN KEY([RoleId]) REFERENCES [Roles] ([Id]);
Go

Alter table [Workouts]
Add FOREIGN KEY([SportTypeId]) REFERENCES [SportTypes] ([Id]);
Go

Alter table [Timetables]
Add FOREIGN KEY([CoachId]) REFERENCES [Persons] ([Id]),
	FOREIGN KEY([WorkoutId]) REFERENCES [Workouts] ([Id]),
	FOREIGN KEY([GymId]) REFERENCES [Gyms] ([Id]);
Go

Alter table [Coaches_WorkoutTypes]
Add FOREIGN KEY([CoachId]) REFERENCES Persons ([Id]),
	FOREIGN KEY([WorkoutTypeId]) REFERENCES WorkoutTypes ([Id]);
Go

Alter table [Coaches_SportTypes]
Add FOREIGN KEY([CoachId]) REFERENCES [Persons] ([Id]),
	FOREIGN KEY([SportTypeId]) REFERENCES [SportTypes] ([Id]);
Go

Alter table [Clients_Timetables]
Add FOREIGN KEY([ClientId]) REFERENCES [Persons] ([Id]),
	FOREIGN KEY([TimetableId]) REFERENCES [Timetables] ([Id]);
Go