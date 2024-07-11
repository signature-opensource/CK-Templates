using CK.Core;
using System.Diagnostics.CodeAnalysis;

namespace CK.DB.NAME_PLACE_HOLDER_DOT
{
    [SqlPackage( Schema = "CK", ResourcePath = "Res" )]
    [Versions( "1.0.0" )]
    public abstract class Package : SqlPackage
    {
        void StObjConstruct() { }

        [InjectObject, AllowNull]
        public NAME_PLACE_HOLDER_CAMELCASETable NAME_PLACE_HOLDER_CAMELCASETable { get; protected set; }
    }
}
