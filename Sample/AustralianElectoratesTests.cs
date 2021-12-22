
// https://github.com/pmcau/AustralianElectorates
// https://github.com/pmcau/AustralianElectorates/tree/master/Data

[UsesVerify]
public class AustralianElectoratesTests :
    XunitContextBase
{
    [Fact]
    public Task Usage()
    {
        var electorate = DataLoader.Electorates.Single(x => x.Name == "Canberra");
        return Verify(new
        {
            electorate.Name,
            electorate.Area,
            Elected = electorate.TwoCandidatePreferred!.Elected.FullName(),
            CurrentParty = electorate.CurrentParty!.Name,
            electorate.Description
        });
    }

    [Fact]
    public Task DetailMap()
    {
        var detailMapPath = DetailMaps.MapForElectorate("Canberra");
        return VerifyFile(detailMapPath);
    }

    [Fact]
    public void BogusUsage()
    {
        var faker = new Faker<Target>()
            .RuleFor(u => u.RandomElectorate, f => f.AustralianElectorates().Electorate())
            .RuleFor(u => u.RandomElectorateName, f => f.AustralianElectorates().Name());
        var instance = faker.Generate();
        Trace.WriteLine(JsonConvert.SerializeObject(instance));
    }

    public class Target
    {
        public string? RandomElectorateName { get; set; }
        public IElectorate? RandomElectorate { get; set; }
    }

    public AustralianElectoratesTests(ITestOutputHelper output) :
        base(output)
    {
    }
}