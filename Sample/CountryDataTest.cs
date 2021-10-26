using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using CountryData;
using CountryData.Bogus;
using Newtonsoft.Json;
using VerifyXunit;
using Xunit;
using Xunit.Abstractions;

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
    public void RandomData()
    {
        var faker = new Faker<Target>()
            .RuleFor(
                property: u => u.RandomCountryName,
                setter: (f, u) => f.Country().Name())
            .RuleFor(
                property: u => u.AustralianCapital,
                setter: (f, u) => f.Country().Australia().Capital)
            .RuleFor(
                property: u => u.RandomIrelandState,
                setter: (f, u) => f.Country().Ireland().State().Name)
            .RuleFor(
                property: u => u.RandomIcelandPostCode,
                setter: (f, u) => f.Country().Iceland().PostCode());
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