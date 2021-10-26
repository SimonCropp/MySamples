
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
        var url = "https://raw.githubusercontent.com/LearnWebCode/json-example/master/animals-1.json";
        var json = await cache.StringAsync(url);
        await Verifier.Verify(json);
    }

    [Fact]
    public async Task Image()
    {
        var url = "https://upload.wikimedia.org/wikipedia/commons/6/6e/Golde33443.jpg";
        using var response = await cache.ResponseAsync(url);
        await Verifier.Verify(response);
    }
}