using CK.SqlServer;
using NUnit.Framework;
using CK.Core;
using static CK.Testing.DBSetupTestHelper;
using System.Diagnostics;
using Dapper;
using CK.SqlServer;

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

        context[package].Execute( "delete from CK.tNAME_PLACE_HOLDER_CAMELCASE" );

        var inputName = "Hello world!";
        package.NAME_PLACE_HOLDER_CAMELCASETable.Create( context, actorId, inputName );

        var sql = @"
select top 1 NAME_PLACE_HOLDER_CAMELCASEId
from CK.tNAME_PLACE_HOLDER_CAMELCASE
where NAME_PLACE_HOLDER_CAMELCASEName = @Name;
";

        var id = context[package].QuerySingle<int>( sql, new { Name = inputName } );

        package.NAME_PLACE_HOLDER_CAMELCASETable.Destroy( context, actorId, id );
    }
}
