using Xunit;

namespace Vortx.Application.Tests
{
    [CollectionDefinition(nameof(TestCollection))]
    public class TestCollection : ICollectionFixture<TestsFixtures> { }
}
