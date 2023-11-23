using CK.Core;
using CK.SqlServer;
using System.Threading.Tasks;

namespace CK.DB.NAME_PLACE_HOLDER_DOT
{
    [SqlTable( "tNAME_PLACE_HOLDER_CAMELCASE", Package = typeof( Package ) )]
    [Versions( "1.0.0" )]
    public abstract class NAME_PLACE_HOLDER_CAMELCASETable : SqlTable
    {
        void StObjConstruct() { }

        /// <summary>
        /// Create a NAME_PLACE_HOLDER_CAMELCASE.
        /// </summary>
        /// <param name="ctx">The SQL Call Context.</param>
        /// <param name="actorId">The acting actor identifier.</param>
        /// <param name="NAME_PLACE_HOLDER_CAMELCASEName">The name of the NAME_PLACE_HOLDER_CAMELCASE.</param>
        /// <returns>The NAME_PLACE_HOLDER_CAMELCASE identifier.</returns>
        [SqlProcedure( "sNAME_PLACE_HOLDER_CAMELCASECreate" )]
        public abstract Task<int> CreateNAME_PLACE_HOLDER_CAMELCASEAsync( ISqlCallContext ctx, int actorId, string NAME_PLACE_HOLDER_CAMELCASEName );

        /// <summary>
        /// Destroy a NAME_PLACE_HOLDER_CAMELCASE if it exists.
        /// </summary>
        /// <param name="ctx">The SQL Call Context.</param>
        /// <param name="actorId">The acting actor identifier.</param>
        /// <param name="NAME_PLACE_HOLDER_CAMELCASEId">The NAME_PLACE_HOLDER_CAMELCASE identifier.</param>
        /// <returns>An awaitable.</returns>
        [SqlProcedure( "sNAME_PLACE_HOLDER_CAMELCASEDestroy" )]
        public abstract Task DestroyNAME_PLACE_HOLDER_CAMELCASEAsync( ISqlCallContext ctx, int actorId, int NAME_PLACE_HOLDER_CAMELCASEId );
    }
}
