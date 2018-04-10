create table [dbo].[OikCategory]
(
	[Id] int not null identity,
	[OikLetter] nchar not null,
	[Description] nvarchar(256)

	constraint pk_OikCategory_Id primary key(Id)
)
