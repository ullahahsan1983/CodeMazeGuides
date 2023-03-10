using Microsoft.AspNetCore.OutputCaching;

namespace OutputCaching.Controllers;

[Route("api/caching-demo")]
[ApiController]
[OutputCache(Duration = 60)]
public class CachingDemoController : ControllerBase
{
    [HttpGet("response")]
    [ResponseCache(Duration = 120)]
    public IActionResult GetResponse()
    {
        return Ok($"Response was generated at {DateTime.Now}");
    }

    [HttpGet("output")]
    [OutputCache(Duration = 120)]
    public IActionResult GetOutput()
    {
        return Ok($"Output was generated at {DateTime.Now}");
    }

    [HttpGet("output-nocache")]
    [OutputCache(NoStore = true)]
    public IActionResult NonCachedOutput()
    {
        return Ok($"Output was generated at {DateTime.Now}");
    }

    [HttpGet("output-varybykey")]
    [OutputCache(VaryByQueryKeys = new[] { nameof(firstKey) })]
    public IActionResult VaryByKey(string firstKey, string secondKey)
    {
        return Ok($"{firstKey} {secondKey} - retrieved at {DateTime.Now}");
    }

    [HttpGet("output-varybyroute/{firstKey}/{secondKey}")]
    [OutputCache(VaryByRouteValueNames = new[] { nameof(firstKey) })]
    public IActionResult VaryByRoute(string firstKey, string secondKey)
    {
        return Ok($"{firstKey} and {secondKey} - retrieved at {DateTime.Now}");
    }

}