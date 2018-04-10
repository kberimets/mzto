create table [dbo].[Parameter]
(
	[Id] int not null identity,
	[OikCategoryId] int not null,
	[OikId] int not null,	
	[TypeId] int not null,
	[PowerCenterId] int not null

	constraint pk_Parameter_Id primary key(Id),
	constraint fk_Parameter_OikCategoryId foreign key (OikCategoryId) references OikCategory(Id),
	constraint fk_Parameter_TypeId foreign key (TypeId) references ParameterType(Id),
	constraint fk_Parameter_PowerCenterId foreign key (PowerCenterId) references PowerCenter(Id),
	constraint uq_Parameter_OikCategoryId_OikId unique(OikCategoryId, OikId),
	constraint uq_Parameter_TypeId_PowerCenterId unique(TypeId, PowerCenterId)
)
