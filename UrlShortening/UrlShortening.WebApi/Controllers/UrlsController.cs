using Microsoft.AspNetCore.Mvc;
using UrlShortening.Domain.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrlShortening.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlsController : ControllerBase
    {
        private readonly IUrlService service;

        public UrlsController(IUrlService _service)
        {
            service = _service;
        }

        [HttpGet("{shortUrl}")]
        public async Task<string> Get(string shortUrl)
        {
            try
            {
                string url = await service.GetUrl(shortUrl);

                return url;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public async Task<string> Post([FromBody] string originalUrl)
        {
            try
            {
                string shortUrl = await service.CreateShortUrl(originalUrl);

                return shortUrl;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       
    }
}
