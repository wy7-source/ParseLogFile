using System;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace CandidateTesting.WythorFerreiraBazan.iTaaS
{
    class Scrape
    {
        // WebScrape is our method that download the MINHA CDN file.
        public MatchCollection WebScrape(string uri)
        {
            MatchCollection encontrados;
            try
            {
                WebClient wc = new WebClient();
                var sourceLogFile = wc.DownloadString(uri);

                StringBuilder stb = new StringBuilder();

                stb.Append(@"([0-9][0-9][0-9])\|([0-9][0-9][0-9])\|(INVALIDATE|MISS|HIT)\|");
                stb.Append("\"");
                stb.Append(@"(GET|POST) (/.*) HTTP\/1\.1");
                stb.Append("\"");
                stb.Append(@"\|([0-9][0-9][0-9]\.[0-9])\r\n");

                var rgx = new Regex(stb.ToString());
                
                encontrados = rgx.Matches(sourceLogFile);
                if(encontrados.Count == 0)
                {
                    throw new Exception(message: "Invalid MINHA CDN file format.");
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return encontrados;
        }
    }
}
