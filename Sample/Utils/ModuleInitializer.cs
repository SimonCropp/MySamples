public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
    }
}