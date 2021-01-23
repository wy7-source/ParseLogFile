using System;

namespace CandidateTesting.WythorFerreiraBazan.iTaaS
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ScrapeService  _scrapeService = new ScrapeService();
                ConvertService _convertService = new ConvertService();
              
                var log = _scrapeService.GetLogFile(args[0]);
                _convertService.ConvertFile(log,args[1]);
            }
            catch(IndexOutOfRangeException)
            {
                throw new Exception("Missing one or more arguments on command line!");
            }
            catch(Exception e)
            {
                throw new Exception("Something went Wrong:\n "+e);
            }
        }
    }
}
