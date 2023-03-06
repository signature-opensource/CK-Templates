using CK.Core;
using CK.SqlServer;
using Dapper;
using FluentAssertions;
using NUnit.Framework;
using System.Diagnostics;
using static CK.Testing.DBSetupTestHelper;

namespace CK.DB.NAME_PLACE_HOLDER_DOT.Tests
{
    public class CrudTests
    {
        [Test]
        public void Crud()
        {
            var table = TestHelper.StObjMap.StObjs.Obtain<NAME_PLACE_HOLDER_CAMELCASETable>();
            Debug.Assert( table != null );
            using( var context = new SqlStandardCallContext() )
            {
                var actorId = 1;

                context[table].Execute( "delete from CK.tNAME_PLACE_HOLDER_CAMELCASE" );

                var inputName = "Hello world!";
                table.Create( context, actorId, inputName );

                var sql = "select top 1 NAME_PLACE_HOLDER_CAMELCASEId " +
                          "from CK.tNAME_PLACE_HOLDER_CAMELCASE " +
                          "where NAME_PLACE_HOLDER_CAMELCASEName = @Name;";

                var id = context[table].QuerySingle<int>( sql, new { Name = inputName } );
                id.Should().BeGreaterThan( 0 );

                table.Destroy( context, actorId, id );
            }
        }
    }
}
