public static class VerifyModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifierSettings.DontScrubSolutionDirectory();
        VerifierSettings.DontScrubProjectDirectory();
        VerifyHttp.Enable();
        VerifyImageMagick.RegisterComparers(.01);

        VerifierSettings.ModifySerialization(settings =>
        {
            settings.IgnoreMembers(
                "Age",
                "X-Cache",
                "traceparent",
                "Traceparent",
                "X-Amzn-Trace-Id",
                "origin",
                "Content-Length",
                "TrailingHeaders");
        });


        // remove some noise from the html snapshot

        VerifierSettings.ScrubEmptyLines();
        VerifierSettings.ScrubLinesWithReplace(s => s.Replace("<!--!-->", ""));
        HtmlPrettyPrint.All();
        VerifierSettings.ScrubLinesContaining("<script src=\"_framework/dotnet.");

        VerifyPlaywright.Enable();
    }
}