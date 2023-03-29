-- SetupConfig: {}

alter procedure CK.sNAME_PLACE_HOLDER_CAMELCASECreate(
    @ActorId int,
    @NAME_PLACE_HOLDER_CAMELCASEName nvarchar(max)
)
as
begin
    if @ActorId <= 0 throw 50000, 'Security.AnonymousNotAllowed', 1;

    --[beginsp]


    --<PreCreate revert />
    insert into CK.tNAME_PLACE_HOLDER_CAMELCASE (NAME_PLACE_HOLDER_CAMELCASEName)
    values (@NAME_PLACE_HOLDER_CAMELCASEName)
    --<PostCreate />

    --[endsp]
end

