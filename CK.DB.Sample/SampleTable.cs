using CK.Core;
using CK.SqlServer;
using System.Threading.Tasks;

namespace CK.DB.Sample
{
    [SqlTable( "tSample", Package = typeof( Package ) )]
    [Versions( "1.0.0" )]
    public abstract class SampleTable : SqlTable
    {
        void StObjConstruct() { }

        /// <summary>
        /// Create a sample.
        /// </summary>
        /// <param name="ctx">The SQL Call Context.</param>
        /// <param name="actorId">The acting actor identifier.</param>
        /// <param name="sampleName">The name of the sample.</param>
        /// <returns>The sample identifier.</returns>
        [SqlProcedure( "sSampleCreate" )]
        public abstract Task<int> CreateSampleAsync( ISqlCallContext ctx, int actorId, string sampleName );

        /// <summary>
        /// Destroy a sample if it exists.
        /// </summary>
        /// <param name="ctx">The SQL Call Context.</param>
        /// <param name="actorId">The acting actor identifier.</param>
        /// <param name="sampleId">The sample identifier.</param>
        /// <returns>An awaitable.</returns>
        [SqlProcedure( "sSampleDestroy" )]
        public abstract Task DestroySampleAsync( ISqlCallContext ctx, int actorId, int sampleId );
    }
}
