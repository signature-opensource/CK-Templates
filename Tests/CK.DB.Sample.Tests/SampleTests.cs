using CK.Core;
using CK.SqlServer;
using CK.Testing;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using static CK.Testing.MonitorTestHelper;

namespace CK.DB.Sample.Tests
{
    [TestFixture]
    public class SampleTests
    {

        [Test]
        public async Task can_create_Sample_Async()
        {
            var sampleTable = SharedEngine.AutomaticServices.GetRequiredService<SampleTable>();

            using( var ctx = new SqlStandardCallContext( TestHelper.Monitor ) )
            {
                string sampleName = Guid.NewGuid().ToString();
                int sampleId = await sampleTable.CreateSampleAsync( ctx, 1, sampleName );

                sampleTable.Database.ReadFirstRow( "select SampleName from CK.tSample where SampleId = @0;", sampleId )
                    .Should().NotBeNull()
                    .And.Subject.Single().Should().Be( sampleName );
            }
        }

        [Test]
        public async Task can_destroy_Sample_Async()
        {
            var sampleTable = SharedEngine.AutomaticServices.GetRequiredService<SampleTable>();

            using( var ctx = new SqlStandardCallContext( TestHelper.Monitor ) )
            {
                int sampleId = await sampleTable.CreateSampleAsync( ctx, 1, Guid.NewGuid().ToString() );

                await sampleTable.Invoking( table => table.DestroySampleAsync( ctx, 1, sampleId ) )
                    .Should().NotThrowAsync();
            }
        }
    }
}
