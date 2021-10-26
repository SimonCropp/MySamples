
// https://github.com/Fody/Resourcer

public class ResourcerTests :
    XunitContextBase
{
    [Fact]
    public void Resourcer()
    {
        var stringValue = Resource.AsString("MyResource.txt");
        Trace.WriteLine(stringValue);
    }
    

    public ResourcerTests(ITestOutputHelper output) :
        base(output)
    {
    }
}
