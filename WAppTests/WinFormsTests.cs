using SimpleCalculator;

[TestFixture]
[Apartment(ApartmentState.STA)]
public class WinFormsTests
{
    [Test]
    public async Task FormUsage()
    {
        var form = new Form1();
        await Verifier.Verify(form);
    }
}