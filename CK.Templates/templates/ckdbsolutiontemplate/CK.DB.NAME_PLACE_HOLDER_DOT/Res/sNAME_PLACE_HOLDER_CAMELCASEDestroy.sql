-- SetupConfig: {}
create procedure CK.sNAME_PLACE_HOLDER_CAMELCASEDestroy
(
    @ActorId int,
    @NAME_PLACE_HOLDER_CAMELCASEId int
)
as
begin
    if @ActorId <= 0 throw 50000, 'Security.AnonymousNotAllowed', 1;
	if @NAME_PLACE_HOLDER_CAMELCASEId <= 0 throw 50000, 'Argument.InvalidNAME_PLACE_HOLDER_CAMELCASEId', 1;

    --[beginsp]

    --<PreDestroy revert />

    delete from CK.tNAME_PLACE_HOLDER_CAMELCASE where NAME_PLACE_HOLDER_CAMELCASEId = @NAME_PLACE_HOLDER_CAMELCASEId;

    --<PostDestroy />

    --[endsp]
end
