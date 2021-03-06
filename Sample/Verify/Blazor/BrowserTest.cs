[UsesVerify]
public class BrowserTest :
    IClassFixture<PlaywrightFixture>
{
    IPage page;

    public BrowserTest(PlaywrightFixture fixture)
    {
        page = fixture.Page;
    }

    [Fact]
    [Trait("Category", "Integration")]
    public async Task Index()
    {
        await page.GotoAsync("http://localhost:5000/");
        await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await Verify(page);
    }

    [Fact]
    [Trait("Category", "Integration")]
    public async Task Counter()
    {
        await page.GotoAsync("http://localhost:5000/counter");
        await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        var element = await page.QuerySelectorAsync(".content");
        await Verify(element);
    }
}