
//https://github.com/VerifyTests/EmptyFiles

[UsesVerify]
public class EmptyFilesTest :
    XunitContextBase
{
    [Fact]
    public void WriteExtensions()
    {
        WriteCategory("Archive", AllFiles.Archives);
        WriteCategory("Document", AllFiles.Documents);
        WriteCategory("Image", AllFiles.Images);
        WriteCategory("Sheet", AllFiles.Sheets);
        WriteCategory("Slide", AllFiles.Slides);
    }

    static void WriteCategory(string category, IReadOnlyDictionary<string, EmptyFile> files)
    {
        Trace.WriteLine($"## {category}");
        foreach (var file in files.OrderBy(x => x.Key))
        {
            var size = Size.Suffix(new FileInfo(file.Value.Path).Length);
            Trace.WriteLine($"  * {file.Key} ({size})");
        }
    }

    public EmptyFilesTest(ITestOutputHelper output) :
        base(output)
    {
    }
}