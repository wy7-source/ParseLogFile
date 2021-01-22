using System;
using System.Text;

namespace CandidateTesting.WythorFerreiraBazan.iTaaS
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Uri url = new Uri(args[0]);
                Scrape scrape = new Scrape();
                var log = scrape.GetLogFile(url);
                scrape.ConvertFile(log,args[1]);
            }
            catch(IndexOutOfRangeException)
            {
                throw new Exception("Missing one or more arguments on command line!");
            }
            catch(UriFormatException)
            {
                throw new Exception("Invalid URI to get MINHA CDN");
            }
            catch(Exception e)
            {
                throw new Exception("Something went Wrong:\n "+e);
            }
        }
    }
}
