using Mapster;

namespace UnitTests.Mappings;
public class MappingTests
{
    public readonly record struct SourceRec(int Id, string Name, string Tags);

    public readonly record struct DestinationRec(int Id, string Name);

    [Fact]
    public void Records_adapt_successfully()
    {
        var source = new SourceRec(1, "Name", "Tags");
        var destination = source.Adapt<DestinationRec>();

        Assert.Equal(source.Id, destination.Id);
        Assert.Equal(source.Name, destination.Name);
    }

    [Fact]
    public void Records_adapt_successfully_2()
    {

    }
}
