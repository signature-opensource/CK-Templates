using CK.Core;
using CK.SqlServer;
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
        static SampleTable SampleTable => TestHelper.CreateAutomaticServices().GetRequiredService<SampleTable>();

        [Test]
        public async Task can_create_Sample_Async()
        {
            using var ctx = new SqlStandardCallContext();

            string sampleName = Guid.NewGuid().ToString();
            int sampleId = await SampleTable.CreateSampleAsync( ctx, 1, sampleName );

            SampleTable.Database.ReadFirstRow( "select SampleName from CK.tSample where SampleId = @0;", sampleId )
                .Should().NotBeNull()
                .And.Subject.Single().Should().Be( sampleName );
        }

        [Test]
        public async Task can_destroy_Sample_Async()
        {
            using var ctx = new SqlStandardCallContext();

            int sampleId = await SampleTable.CreateSampleAsync( ctx, 1, Guid.NewGuid().ToString() );

            await SampleTable.Invoking( table => table.DestroySampleAsync( ctx, 1, sampleId ) )
                .Should().NotThrowAsync();
        }
    }
}
