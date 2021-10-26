
// https://github.com/SimonCropp/NaughtyStrings

[UsesVerify]
public class NaughtyStringsTests :
    XunitContextBase
{
    [Fact]
    public void Write()
    {
        Write("SQLInjection", TheNaughtyStrings.SQLInjection);

        //https://github.com/SimonCropp/NaughtyStrings/blob/main/src/NaughtyStrings/TheNaughtyStrings.cs#L889
        Write("ZalgoText", TheNaughtyStrings.ZalgoText);

        //https://github.com/SimonCropp/NaughtyStrings/blob/main/src/NaughtyStrings/TheNaughtyStrings.cs#L698
        Write("UnicodeSymbols", TheNaughtyStrings.UnicodeSymbols);
    }

    static void Write(string category, IEnumerable<string> lines)
    {
        Trace.WriteLine($"## {category}");
        foreach (var line in lines)
        {
            Trace.WriteLine($"  * {line}");
        }
    }

    public NaughtyStringsTests(ITestOutputHelper output) :
        base(output)
    {
    }
}
