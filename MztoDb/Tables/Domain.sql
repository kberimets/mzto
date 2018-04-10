create table [dbo].[Domain]
(
	[Id] int not null identity,
	[Name] nvarchar(256) not null

	constraint pk_Domain_Id primary key(Id)
)
