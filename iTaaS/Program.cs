using System;
using System.Text;

namespace CandidateTesting.WythorFerreiraBazan.iTaaS
{
    class Program
    {
        static void Main(string[] args)
        {
            Scrape scrape = new Scrape();
            Console.WriteLine(scrape.WebScrape(args[0]));

        }
    }
}
