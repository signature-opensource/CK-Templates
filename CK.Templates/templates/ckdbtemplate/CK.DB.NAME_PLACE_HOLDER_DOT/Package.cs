using CK.Core;

namespace CK.DB.NAME_PLACE_HOLDER_DOT;

/// <summary>
/// Package for NAME_PLACE_HOLDER_DOT
/// </summary>
[SqlPackage( Schema = "CK", ResourcePath = "Res" )]
[Versions("1.0.0")]
public abstract class Package : SqlPackage
{
    /// <summary>
    /// Gets the <see cref="NAME_PLACE_HOLDER_CAMELCASETable"/>.
    /// </summary>
    [InjectObject]
    public NAME_PLACE_HOLDER_CAMELCASETable NAME_PLACE_HOLDER_CAMELCASETable { get; private set; }
}
