
// https://github.com/CopyText/TextCopy

[UsesVerify]
public class TextCopyTests
{
    [Fact]
    public async Task Apis()
    {
        await ClipboardService.SetTextAsync("My text");
        Assert.Equal("My text", await ClipboardService.GetTextAsync());

        ClipboardService.SetText("My text");
        Assert.Equal("My text", ClipboardService.GetText());
    }
}

/*
## Supported on

 * Windows with .NET Framework 4.6.1 and up
 * Windows with .NET Core 2.0 and up
 * Windows with Mono 5.0 and up
 * OSX with .NET Core 2.0 and up
 * OSX with Mono 5.20.1 and up
 * Linux with .NET Core 2.0 and up
 * Linux with Mono 5.20.1 and up
 * Xamarin.Android 9.0 and up
 * Xamarin.iOS 10.0 and up
 * Universal Windows Platform version 10.0.16299 and up
 * Blazor WebAssembly 5.0 and up

*/