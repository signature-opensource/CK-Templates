--[beginscript]

create table CK.tNAME_PLACE_HOLDER_CAMELCASE
(
	NAME_PLACE_HOLDER_CAMELCASEId int not null identity(0,1),
	NAME_PLACE_HOLDER_CAMELCASEName nvarchar(max),

	constraint PK_CK_NAME_PLACE_HOLDER_CAMELCASE primary key nonclustered (NAME_PLACE_HOLDER_CAMELCASEId),
);

--[endscript]
