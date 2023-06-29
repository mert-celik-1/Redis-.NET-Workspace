using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace In_MemoryCaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        readonly IMemoryCache _memoryCache;

        public TestController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache; 
        }

        [HttpGet]
        public IActionResult Test() 
        {
            _memoryCache.Set("name", "mert");
            //var data = _memoryCache.Get<string>("name");

            if (_memoryCache.TryGetValue("name",out string data))
            {
                return Ok(data);
            }

            return Ok(data);
        }

        [HttpGet("setDate")]
        public void SetDate()
        {
            _memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(5)
            });
        }
        [HttpGet("getDate")]
        public DateTime GetDate()
        {
            return _memoryCache.Get<DateTime>("date");
        }
    }
}
