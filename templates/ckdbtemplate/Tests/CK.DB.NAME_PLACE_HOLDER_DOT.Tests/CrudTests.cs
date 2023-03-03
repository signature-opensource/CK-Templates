using CK.SqlServer;
using NUnit.Framework;
using CK.Core;
using static CK.Testing.DBSetupTestHelper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace CK.DB.NAME_PLACE_HOLDER_DOT.Tests;

public class CrudTests
{
    [Test]
    public void Crud()
    {
        var package = TestHelper.StObjMap.StObjs.Obtain<Package>();
        Debug.Assert( package != null, nameof( package ) + " != null" );
        using var context = new SqlStandardCallContext();
        var actorId = 1;

        using( var cmd = new SqlCommand( "delete from CK.tNAME_PLACE_HOLDER_CAMELCASE;" ) )
        {
            context[package].ExecuteNonQuery( cmd );
        }

        var inputName = "Hello world!";
        package.NAME_PLACE_HOLDER_CAMELCASETable.Create( context, actorId, inputName );

        int id;
        var cmdText = @"
select top 1 NAME_PLACE_HOLDER_CAMELCASEId
from CK.tNAME_PLACE_HOLDER_CAMELCASE
where NAME_PLACE_HOLDER_CAMELCASEName = @Name;
";
        using( var cmd = new SqlCommand( cmdText ) )
        {
            cmd.Parameters.Add( "@Name", SqlDbType.NChar ).Value = inputName;
            id = context[package].ExecuteSingleRow( cmd, r => r.GetInt32( 0 ) );
        }

        package.NAME_PLACE_HOLDER_CAMELCASETable.Destroy( context, actorId, id );
    }
}
