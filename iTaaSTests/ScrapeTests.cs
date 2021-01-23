using System;
using NUnit.Framework;
using CandidateTesting.WythorFerreiraBazan.iTaaS;
using System.IO;

namespace CandidateTesting.WythorFerreiraBazan.iTaaSTests
{
    public class ScrapeTests
    {
        private ScrapeService scrapeService;
        private ConvertService convertService;
        private string url;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            scrapeService = new ScrapeService();
            convertService = new ConvertService();
            url = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
        }

        [Test]
        // RegexMustWork is our test if the Regex work in right moment.
        public void Convert_RegexMustWork()
        {
            var aux = scrapeService.GetLogFile(url);
            Assert.IsTrue(aux.Count > 0);
        }

        [TestCase("https://http.cat/409")]
        // MustTellInvalidFileFormat is our test if wrong file format generated exception.
        public void Convert_MustTellInvalidFileFormat(string url)
        {
            var ex = Assert.Throws<Exception>(() => scrapeService.GetLogFile(url));
            Assert.That(ex.Message, Is.EqualTo("Invalid MINHA CDN file format."));
        }
    }
}