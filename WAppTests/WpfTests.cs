using WpfApp;

[Apartment(ApartmentState.STA)]
[TestFixture]
public class WpfTests
{
    [Test]
    public async Task WindowUsage()
    {
        var window = new MainWindow();
        await Verify(window);
    }
}