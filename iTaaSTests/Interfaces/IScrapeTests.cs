using System.Text.RegularExpressions;

namespace CandidateTesting.WythorFerreiraBazan.iTaaSTests.Interfaces
{
    public interface IScrapeTests
    {
        void Scrape_RegexMustWork();
        void Scrape_MustTellInvalidFileFormat(string url);
    }
}