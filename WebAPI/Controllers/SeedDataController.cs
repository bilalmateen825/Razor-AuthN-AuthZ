using Microsoft.AspNetCore.Mvc;
using WebAPI.Classes;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeedDataController : ControllerBase
    {
        private readonly ILogger<SeedDataController> _logger;

        public SeedDataController(ILogger<SeedDataController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSeedData")]
        public IEnumerable<SeedData> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new SeedData
            {
                ID = index,
                DOB = DateTime.Now.AddDays(index),
                Name = $"Name{index}",
            })
            .ToArray();
        }
    }
}
