
// https://github.com/SimonCropp/CountryData

[UsesVerify]
public class CountryDataTest :
    XunitContextBase
{
    [Fact]
    public Task Apis()
    {
        var country = CountryLoader.LoadAustraliaLocationData();
        var state = country.States.First();
        var province = state.Provinces.First();
        var community = province.Communities.First();
        var place = community.Places.First();
        return Verifier.Verify(new
        {
            state= state.Name,
            province = province.Name,
            community = community.Name,
            place
        });
    }

    [Fact]
    public void Bogus()
    {
        var faker = new Faker<Target>()
            .RuleFor(u => u.RandomCountryName, f => f.Country().Name())
            .RuleFor(u => u.AustralianCapital, f => f.Country().Australia().Capital)
            .RuleFor(u => u.RandomIrelandState, f => f.Country().Ireland().State().Name)
            .RuleFor(u => u.RandomIcelandPostCode, f => f.Country().Iceland().PostCode());
        var instance = faker.Generate();
        Trace.WriteLine(JsonConvert.SerializeObject(instance));
    }

    public class Target
    {
        public string? AustralianCapital { get; set; }
        public string? RandomCountryName { get; set; }
        public string? RandomIrelandState { get; set; }
        public string? RandomIcelandPostCode { get; set; }
    }

    public CountryDataTest(ITestOutputHelper output) :
        base(output)
    {
    }
}