using CK.Core;
using CK.SqlServer;
using CK.Testing;
using Shouldly;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using static CK.Testing.MonitorTestHelper;

namespace CK.DB.NAME_PLACE_HOLDER_DOT.Tests
{
    [TestFixture]
    public class NAME_PLACE_HOLDER_CAMELCASETests
    {

        [Test]
        public async Task can_create_NAME_PLACE_HOLDER_CAMELCASE_Async()
        {
            var NAME_PLACE_HOLDER_CAMELCASETable = SharedEngine.AutomaticServices.GetRequiredService<NAME_PLACE_HOLDER_CAMELCASETable>();

            using( var ctx = new SqlStandardCallContext( TestHelper.Monitor ) )
            {
                string NAME_PLACE_HOLDER_CAMELCASEName = Guid.NewGuid().ToString();
                int NAME_PLACE_HOLDER_CAMELCASEId = await NAME_PLACE_HOLDER_CAMELCASETable.CreateNAME_PLACE_HOLDER_CAMELCASEAsync( ctx, 1, NAME_PLACE_HOLDER_CAMELCASEName );

                NAME_PLACE_HOLDER_CAMELCASETable.Database.ReadFirstRow( "select NAME_PLACE_HOLDER_CAMELCASEName from CK.tNAME_PLACE_HOLDER_CAMELCASE where NAME_PLACE_HOLDER_CAMELCASEId = @0;", NAME_PLACE_HOLDER_CAMELCASEId )
                    .ShouldNotBeNull()
                    .And.Subject.Single().ShouldBe( NAME_PLACE_HOLDER_CAMELCASEName );
            }
        }

        [Test]
        public async Task can_destroy_NAME_PLACE_HOLDER_CAMELCASE_Async()
        {
            var NAME_PLACE_HOLDER_CAMELCASETable = SharedEngine.AutomaticServices.GetRequiredService<NAME_PLACE_HOLDER_CAMELCASETable>();

            using( var ctx = new SqlStandardCallContext( TestHelper.Monitor ) )
            {
                int NAME_PLACE_HOLDER_CAMELCASEId = await NAME_PLACE_HOLDER_CAMELCASETable.CreateNAME_PLACE_HOLDER_CAMELCASEAsync( ctx, 1, Guid.NewGuid().ToString() );

                await NAME_PLACE_HOLDER_CAMELCASETable.Invoking( table => table.DestroyNAME_PLACE_HOLDER_CAMELCASEAsync( ctx, 1, NAME_PLACE_HOLDER_CAMELCASEId ) )
                    .ShouldNotThrowAsync();
            }
        }
    }
}
