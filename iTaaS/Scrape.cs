using System;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace CandidateTesting.WythorFerreiraBazan.iTaaS
{
    class Scrape
    {
        // GetLogFile is our method that download the MINHA CDN file.
        public MatchCollection GetLogFile(Uri uri)
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
        public void ConvertFile(MatchCollection collection, string localToSaveFile)
        {
            List<string> lines = new List<string>();
            lines.Add("#Version: 1.0\n #Date: "+ DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "\n #Fields: provider http-method status-code uri-path response-size cache-status");
            foreach(Match item in collection)
            {
                string cacheCode = item.Groups[3].Value;
                string cacheCodeChanged = cacheCode == "INVALIDATE" ? "REFRESH_HIT" : item.Groups[3].Value;
                int timeTakenChanged = Convert.ToInt32(Math.Round(Convert.ToDouble(item.Groups[6].Value),5));
                
                lines.Add("\"MINHA CDN\" "+ item.Groups[4] + " " + item.Groups[2]+ " " + item.Groups[5]+ " " + timeTakenChanged+ " " + item.Groups[1]+ " " + cacheCodeChanged);
            }

            System.IO.File.WriteAllLines(localToSaveFile, lines.ToArray());
        }
    }
}
