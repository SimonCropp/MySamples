[UsesVerify]
public class XunitContextSample :
    XunitContextBase
{
    [Fact]
    public Task Apis()
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

    public XunitContextSample(ITestOutputHelper output) :
        base(output)
    {
    }
}