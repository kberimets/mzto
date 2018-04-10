create table [dbo].[ParameterType]
(
	[Id] int not null identity,
	[Description] nvarchar(256)

	constraint pk_ParameterType_Id primary key(Id)
)
