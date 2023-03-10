namespace ReadAppSettings.Controllers;

[Route("static")]
[ApiController]
public class StaticFileDemoController : ControllerBase
{
    private readonly FormatSettings _formatSettings;

    public StaticFileDemoController(IWebHostEnvironment environment)
    {
        var configFile = environment.WebRootFileProvider.GetFileInfo("static_config.json");

        var config = new ConfigurationBuilder()
            .AddJsonFile(configFile.PhysicalPath)
            .Build();

        _formatSettings = config.GetSection("Formatting").Get<FormatSettings>();
    }

    [HttpGet("formatting")]
    public FormatSettings Get() => _formatSettings;
}