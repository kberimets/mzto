create table [dbo].[PowerCenter]
(
	[Id] int not null identity,
	[Name] nvarchar(256) not null,
	[IsObservable] bit not null,
	[DomainId] int not null,

	constraint pk_PowerCenter_Id primary key(Id),
	constraint fk_PowerCenter_DomainId foreign key (DomainId) references Domain(Id)
)
