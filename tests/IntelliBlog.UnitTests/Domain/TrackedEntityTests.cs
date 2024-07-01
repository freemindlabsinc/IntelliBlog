using IntelliBlog.Domain;
using IntelliBlog.Domain.Article;

namespace IntelliBlog.UnitTests.Domain;
public class TrackedEntityTests
{
    public readonly record struct TestId(int value)
    {
        public static TestId Empty { get; } = default;
    }

    class TestTrackedEntity : TrackedEntity<TestId>
    {        
    }

    [Fact]
    public void CreateNew()
    {
        var trackedEntity = new TestTrackedEntity();

        trackedEntity.Id.Should().Be(TestId.Empty);
        trackedEntity.CreatedBy.Should().BeNull();
        trackedEntity.LastModified.Should().BeNull();
        trackedEntity.LastModifiedBy.Should().BeNull();
    }
}
