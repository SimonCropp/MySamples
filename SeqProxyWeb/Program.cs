var builder = WebHost.CreateDefaultBuilder();
builder.UseContentRoot(Directory.GetCurrentDirectory());
builder.UseStartup<Startup>();
builder.UseUrls("http://localhost:5002");
var webHost = builder.Build();
webHost.Run();