using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortening.Domain.Interfaces
{
    public interface IUrlService
    {
        public Task<string> CreateShortUrl(string url);
        public Task<string> GetUrl(string url);
    }
}
