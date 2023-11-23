--[beginscript]

create table CK.tSample
(
    SampleId int not null identity( 0, 1 ),
    SampleName nvarchar(256) collate LATIN1_GENERAL_BIN2 not null,

    constraint PK_CK_Sample primary key nonclustered( SampleId )
);

insert into CK.tSample( SampleName ) values( N'' );

--[endscript]
