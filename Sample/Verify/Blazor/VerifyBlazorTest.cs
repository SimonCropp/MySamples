using BlazorWebApp.Pages;

[UsesVerify]
public class VerifyBlazorTest
{
    [Fact]
    public Task RenderCounter_Web()
    {
        var target = Render.Component<Counter>(
            callback: component => { component.IncrementCount(); });
        return Verify(target);
    }
}