using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortening.Data;
using UrlShortening.Data.Contexts;
using UrlShortening.Domain.Interfaces;

namespace UrlShortening.Services.Services
{
    public class UrlService : IUrlService
    {
        private readonly UrlsDbContext dbContext;
        private const string chars = "aAbBcCdDeEfFgGhHiIjJhHkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ01234567890123456789";

        public UrlService(UrlsDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<string> CreateShortUrl(string url)
        {
            List<string> shortUrls = dbContext.Urls.Select(r => r.ShortUrl).ToList();   //To check if is there any duplicate shortUrl to our new shortUrl

            string shortUrl = GetRandomString(shortUrls);                               //Create new shortUrl with random chars

            Url newUrl = new Url { OriginalUrl = url, ShortUrl = shortUrl };            //Creating new Url entity

            await dbContext.Urls.AddAsync(newUrl);                                      //Saving the new entity to DB
            await dbContext.SaveChangesAsync();    

            return newUrl.ShortUrl;
        }

        public async Task<string> GetUrl(string url)
        {
            var shortUrl = url.Replace("/", "");

            var Url = dbContext.Urls.Where(x => x.ShortUrl == shortUrl).Select(x => x.OriginalUrl).FirstOrDefault();

            return Url;
        }


        private string GetRandomString(List<string> shortUrls)
        {
            var random = new Random();
            string result;

            do
            {
                result = new string(
                Enumerable.Repeat(chars, 6)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            } while (string.IsNullOrEmpty(result) &&  shortUrls.Contains(result));


            return result;

        }
    }
}
