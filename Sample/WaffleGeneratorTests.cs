
// https://github.com/SimonCropp/WaffleGenerator
// https://wafflegen.azurewebsites.net/

using WaffleGenerator;

[UsesVerify]
public class WaffleGeneratorTests :
    XunitContextBase
{
    [Fact]
    public void Apis()
    {
        var text = WaffleEngine.Html(
            paragraphs: 2,
            includeHeading: true,
            includeHeadAndBody: true);
        Debug.WriteLine(text);
    }

    [Fact]
    public void Bogus()
    {
        var faker = new Faker<Target>()
            .RuleFor(u => u.Title, f => f.WaffleTitle())
            .RuleFor(u => u.HtmlParagraph, f => f.WaffleHtml())
            .RuleFor(u => u.TextParagraph, f => f.WaffleHtml())
            .RuleFor(u => u.MarkdownParagraph, f => f.WaffleText());

        var target = faker.Generate();
        Trace.WriteLine(target.Title);
        Trace.WriteLine(target.MarkdownParagraph);
        Trace.WriteLine(target.TextParagraph);
        Trace.WriteLine(target.HtmlParagraph);
    }

    public class Target
    {
        public string Title { get; set; }
        public string? MarkdownParagraph { get; set; }
        public string? TextParagraph { get; set; }
        public string? HtmlParagraph { get; set; }
    }

    public WaffleGeneratorTests(ITestOutputHelper output) :
        base(output)
    {
    }
}