using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortening.Data
{
    public class Url
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}
