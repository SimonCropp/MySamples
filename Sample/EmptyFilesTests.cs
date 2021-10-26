
// https://github.com/VerifyTests/EmptyFiles

public class EmptyFilesTests :
    XunitContextBase
{
    [Fact]
    public void WriteExtensions()
    {
        Write("Archive", AllFiles.Archives);
        Write("Document", AllFiles.Documents);
        Write("Image", AllFiles.Images);
        Write("Sheet", AllFiles.Sheets);
        Write("Slide", AllFiles.Slides);
    }

    static void Write(string category, IReadOnlyDictionary<string, EmptyFile> files)
    {
        Trace.WriteLine($"## {category}");
        foreach (var file in files.OrderBy(x => x.Key))
        {
            var size = Size.Suffix(new FileInfo(file.Value.Path).Length);
            Trace.WriteLine($"  * {file.Key} ({size})");
        }
    }

    public EmptyFilesTests(ITestOutputHelper output) :
        base(output)
    {
    }
}