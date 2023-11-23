-- SetupConfig: {}
create procedure CK.sNAME_PLACE_HOLDER_CAMELCASECreate
(
    @ActorId int,
    @NAME_PLACE_HOLDER_CAMELCASEName nvarchar(256),
    @NAME_PLACE_HOLDER_CAMELCASEId int output
)
as
begin
    if @ActorId <= 0 throw 50000, 'Security.AnonymousNotAllowed', 1;

    --[beginsp]

    --<PreCreate revert />

    insert into CK.tNAME_PLACE_HOLDER_CAMELCASE( NAME_PLACE_HOLDER_CAMELCASEName ) values( @NAME_PLACE_HOLDER_CAMELCASEName );
    set @NAME_PLACE_HOLDER_CAMELCASEId = scope_identity();

    --<PostCreate />

    --[endsp]
end
