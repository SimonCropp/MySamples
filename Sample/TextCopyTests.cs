
// https://github.com/CopyText/TextCopy

public class TextCopyTests
{
    [Fact]
    public async Task Usage()
    {
        await ClipboardService.SetTextAsync("My text 1");
        Assert.Equal("My text 1", await ClipboardService.GetTextAsync());

        ClipboardService.SetText("My text 2");
        Assert.Equal("My text 2", ClipboardService.GetText());
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