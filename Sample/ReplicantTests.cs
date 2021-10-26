
// https://github.com/SimonCropp/Replicant

[UsesVerify]
public class ReplicantTests
{
    static HttpCache httpCache;

    static ReplicantTests()
    {
        var directory = Path.Combine(AttributeReader.GetSolutionDirectory(), "ReplicantCache");
        httpCache = new HttpCache(directory);
    }

    [Fact]
    public async Task Json()
    {
        var json = await httpCache.StringAsync("https://raw.githubusercontent.com/LearnWebCode/json-example/master/animals-1.json");
        await Verifier.Verify(json);
    }

    [Fact]
    public async Task Image()
    {
        using var response = await httpCache.ResponseAsync("https://upload.wikimedia.org/wikipedia/commons/6/6e/Golde33443.jpg");
        await Verifier.Verify(response);
    }
}