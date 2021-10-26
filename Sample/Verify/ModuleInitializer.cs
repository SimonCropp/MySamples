public static class VerifyModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyHttp.Enable();
        VerifyImageMagick.RegisterComparers(.01);

        VerifierSettings.ModifySerialization(settings =>
        {
            settings.IgnoreMembers(
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