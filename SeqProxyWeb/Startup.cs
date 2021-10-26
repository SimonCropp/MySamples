
// https://github.com/SimonCropp/SeqProxy
// http://localhost:5341/#/events

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvcCore(option => option.EnableEndpointRouting = false);
        services.AddSeqWriter(seqUrl: "http://localhost:5341");
    }

    public void Configure(IApplicationBuilder builder)
    {
        builder.UseSeq();
        builder.UseMvc();
    }
}