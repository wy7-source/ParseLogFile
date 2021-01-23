using System;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace CandidateTesting.WythorFerreiraBazan.iTaaS
{
    public class ScrapeService
    {
              
        // GetLogFile is our method that download the MINHA CDN file.
        public MatchCollection GetLogFile(string url)
        {
            MatchCollection found;
            try
            {
                Uri uri = new Uri(url);
                WebClient wc = new WebClient();
                var sourceLogFile = wc.DownloadString(uri);

                // Our regex are made this form, because has double quotes on each line of MINHA CDN file format.
                StringBuilder stb = new StringBuilder();
                stb.Append(@"([0-9][0-9][0-9])\|([0-9][0-9][0-9])\|(INVALIDATE|MISS|HIT)\|");
                stb.Append("\"");
                stb.Append(@"(GET|POST) (/.*) HTTP\/1\.1");
                stb.Append("\"");
                stb.Append(@"\|([0-9][0-9][0-9]\.[0-9])\r\n");

                var rgx = new Regex(stb.ToString());
                
                found = rgx.Matches(sourceLogFile);
                if(found.Count == 0)
                {
                    throw new Exception(message: "Invalid MINHA CDN file format.");
                }
            }
            catch(UriFormatException)
            {
                throw new Exception("Invalid URI to get MINHA CDN file.");
            }
            catch(WebException e)
            {
                throw new Exception("URI can't be reached:" + e);
            }
            return found;
        }
    }
}