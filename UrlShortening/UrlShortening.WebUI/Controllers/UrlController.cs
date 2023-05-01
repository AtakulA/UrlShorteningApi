using Microsoft.AspNetCore.Mvc;
using UrlShortening.WebUI.Services;

namespace UrlShortening.WebUI.Controllers
{
    public class UrlController : Controller
    {
        private readonly ApiCallService service;

        public UrlController(ApiCallService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] string originalUrl)
        {
            try
            {
                string shortUrl = await service.CreateShortUrl(originalUrl);
                return Json(shortUrl);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet("{shortUrl}")]
        public async Task<IActionResult> Redirect(string shortUrl)
        {
            try
            {
                string originalUrl = await service.GetOriginalUrl(shortUrl);

                if (string.IsNullOrEmpty(originalUrl))
                {
                    Response.StatusCode = 404;
                    return View("/Error");
                }

                return await Redirect(originalUrl);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
