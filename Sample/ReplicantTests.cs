
// https://github.com/SimonCropp/Replicant

[UsesVerify]
public class ReplicantTests
{
    static HttpCache cache;

    static ReplicantTests()
    {
        var directory = Path.Combine(AttributeReader.GetSolutionDirectory(), "ReplicantCache");
        cache = new HttpCache(directory);
    }

    [Fact]
    public async Task Json()
    {
        var json = await cache.StringAsync("https://raw.githubusercontent.com/LearnWebCode/json-example/master/animals-1.json");
        await Verifier.Verify(json);
    }

    [Fact]
    public async Task Image()
    {
        using var response = await cache.ResponseAsync("https://upload.wikimedia.org/wikipedia/commons/6/6e/Golde33443.jpg");
        await Verifier.Verify(response);
    }
}