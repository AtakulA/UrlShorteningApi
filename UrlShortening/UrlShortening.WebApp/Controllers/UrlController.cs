using Microsoft.AspNetCore.Mvc;
using UrlShortening.WebApp.Services;

namespace UrlShortening.WebApp.Controllers
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

        
        public JsonResult CreateShortUrl(string data)
        {
            try
            {
                string shortUrl =  service.CreateShortUrl(data).Result;
                string baseUrl = Request.Scheme + "://" + Request.Host;
                string newUrl = baseUrl + "/" + shortUrl;
                return Json(newUrl);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet("{shortUrl}")]
        public IActionResult Redirect(string shortUrl)
        {
            try
            {
                string originalUrl =  service.GetOriginalUrl(shortUrl).Result;

                if (string.IsNullOrEmpty(originalUrl))
                {
                    return RedirectToAction("Error");
                }

                return  new RedirectResult(originalUrl);
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
