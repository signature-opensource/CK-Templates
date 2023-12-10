-- SetupConfig: {}
create procedure CK.sSampleCreate
(
    @ActorId int,
    @SampleName nvarchar(256),
    @SampleId int output
)
as
begin
    if @ActorId <= 0 throw 50000, 'Security.AnonymousNotAllowed', 1;

    --[beginsp]

    --<PreCreate revert />

    insert into CK.tSample( SampleName ) values( @SampleName );
    set @SampleId = scope_identity();

    --<PostCreate />

    --[endsp]
end
