using System.Text.RegularExpressions;

namespace CandidateTesting.WythorFerreiraBazan.iTaaS.Interfaces
{
    public interface IScrapeServices
    {
        MatchCollection GetLogFile(string url);
    }
}