
//https://github.com/SimonCropp/XunitContext

[UsesVerify]
public class XunitContextTests :
    XunitContextBase
{
    [Fact]
    public Task Usage()
    {
        Trace.WriteLine("Message written to Trace");
        Debug.WriteLine("Message written to Debug");
        return Verifier.Verify(
            new
            {
                base.SolutionDirectory,
                base.SourceFile,
                base.Logs
            });
    }

    public XunitContextTests(ITestOutputHelper output) :
        base(output)
    {
    }
}