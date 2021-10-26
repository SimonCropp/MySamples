//https://github.com/pmcau/AustralianElectorates


[UsesVerify]
public class AustralianElectoratesTest :
    XunitContextBase
{
    [Fact]
    public Task Apis()
    {
        var electorate = DataLoader.Electorates.Single(x => x.Name == "Canberra");
        return Verifier.Verify(new
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
        return Verifier.VerifyFile(detailMapPath);
    }

    [Fact]
    public void RandomData()
    {
        var faker = new Faker<Target>()
            .RuleFor(
                property: u => u.RandomElectorate,
                setter: (f, _) => f.AustralianElectorates().Electorate())
            .RuleFor(
                property: u => u.RandomElectorateName,
                setter: (f, _) => f.AustralianElectorates().Name());
        var instance = faker.Generate();
        Trace.WriteLine(JsonConvert.SerializeObject(instance));
    }

    public class Target
    {
        public string? RandomElectorateName { get; set; }
        public IElectorate? RandomElectorate { get; set; }
    }

    public AustralianElectoratesTest(ITestOutputHelper output) :
        base(output)
    {
    }
}