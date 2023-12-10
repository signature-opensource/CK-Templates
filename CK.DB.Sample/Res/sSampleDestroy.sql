-- SetupConfig: {}
create procedure CK.sSampleDestroy
(
    @ActorId int,
    @SampleId int
)
as
begin
    if @ActorId <= 0 throw 50000, 'Security.AnonymousNotAllowed', 1;
	if @SampleId <= 0 throw 50000, 'Argument.InvalidSampleId', 1;

    --[beginsp]

    --<PreDestroy revert />

    delete from CK.tSample where SampleId = @SampleId;

    --<PostDestroy />

    --[endsp]
end
