public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyImageMagick.RegisterComparers(.019);
        VerifyXaml.Enable();
        VerifyWinForms.Enable();
    }
}