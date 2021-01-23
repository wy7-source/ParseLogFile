using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace CandidateTesting.WythorFerreiraBazan.iTaaS
{
    public class ConvertService
    {
        // ConvertFile is our method that convert MINHA CDN file to Agora file.
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
