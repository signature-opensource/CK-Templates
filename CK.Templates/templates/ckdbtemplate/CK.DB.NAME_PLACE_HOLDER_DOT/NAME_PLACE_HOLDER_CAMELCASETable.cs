using CK.Core;
using CK.SqlServer;
using System.Threading.Tasks;

namespace CK.DB.NAME_PLACE_HOLDER_DOT;

/// <summary>
/// Holds the persisted <see cref="NAME_PLACE_HOLDER_DOT"/>.
/// </summary>
[SqlTable( "tNAME_PLACE_HOLDER_CAMELCASE", Package = typeof( Package ) )]
[Versions( "1.0.0" )]
public abstract class NAME_PLACE_HOLDER_CAMELCASETable : SqlTable
{
    /// <summary>
    /// Destroys a NAME_PLACE_HOLDER_CAMELCASE by its identifier (does nothing if the NAME_PLACE_HOLDER_CAMELCASE does not exist).
    /// </summary>
    /// <param name="c">The sql call context to use.</param>
    /// <param name="actorId">The current actor identifier.</param>
    /// <param name="NAME_PLACE_HOLDER_CAMELCASEId">The NAME_PLACE_HOLDER_CAMELCASE identifier to destroy.</param>
    [SqlProcedure( "sNAME_PLACE_HOLDER_CAMELCASEDestroy" )]
    public abstract void Destroy( ISqlCallContext c, int actorId, int NAME_PLACE_HOLDER_CAMELCASEId );

    /// <summary>
    /// Destroys a NAME_PLACE_HOLDER_CAMELCASE by its identifier (does nothing if the NAME_PLACE_HOLDER_CAMELCASE does not exist).
    /// </summary>
    /// <param name="c">The sql call context to use.</param>
    /// <param name="actorId">The current actor identifier.</param>
    /// <param name="NAME_PLACE_HOLDER_CAMELCASEId">The NAME_PLACE_HOLDER_CAMELCASE identifier to destroy.</param>
    [SqlProcedure( "sNAME_PLACE_HOLDER_CAMELCASEDestroy" )]
    public abstract Task DestroyAsync( ISqlCallContext c, int actorId, int NAME_PLACE_HOLDER_CAMELCASEId );

    /// <summary>
    /// Creates a NAME_PLACE_HOLDER_CAMELCASE.
    /// </summary>
    /// <param name="c">The sql call context to use.</param>
    /// <param name="actorId">The current actor identifier.</param>
    /// <param name="NAME_PLACE_HOLDER_CAMELCASEName">The NAME_PLACE_HOLDER_CAMELCASE name to create.</param>
    [SqlProcedure( "sNAME_PLACE_HOLDER_CAMELCASECreate" )]
    public abstract void Create( ISqlCallContext c, int actorId, string NAME_PLACE_HOLDER_CAMELCASEName );

    /// <summary>
    /// Creates a NAME_PLACE_HOLDER_CAMELCASE.
    /// </summary>
    /// <param name="c">The sql call context to use.</param>
    /// <param name="actorId">The current actor identifier.</param>
    /// <param name="NAME_PLACE_HOLDER_CAMELCASEName">The NAME_PLACE_HOLDER_CAMELCASE name to create.</param>
    [SqlProcedure( "sNAME_PLACE_HOLDER_CAMELCASECreate" )]
    public abstract Task CreateAsync( ISqlCallContext c, int actorId, string NAME_PLACE_HOLDER_CAMELCASEName );
}
