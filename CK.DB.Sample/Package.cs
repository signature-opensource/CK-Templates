using CK.Core;

namespace CK.DB.Sample
{
    [SqlPackage( Schema = "CK", ResourcePath = "Res" )]
    [Versions( "1.0.0" )]
    public abstract class Package : SqlPackage
    {
        void StObjConstruct() { }

        [InjectObject]
        public SampleTable SampleTable { get; protected set; }
    }
}
