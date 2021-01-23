using System;
using NUnit.Framework;
using CandidateTesting.WythorFerreiraBazan.iTaaS;
using System.IO;

namespace CandidateTesting.WythorFerreiraBazan.iTaaSTests
{
    public class ConvertTests
    {
        private Scrape scrape;
        private Uri url;
        
        [SetUp]
        public void Setup()
        {
            scrape = new Scrape();
            url = new Uri("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt");
        }

        [Test]
        public void RegexMustWork()
        {
            var aux = scrape.GetLogFile(url);
            Assert.IsTrue(aux.Count > 0);
        }

        [Test]
        public void MustTellInvalidFileFormat()
        {
            Uri auxUrl = new Uri("https://http.cat/409");

            var ex = Assert.Throws<Exception>(() => scrape.GetLogFile(auxUrl));
            Assert.That(ex.Message, Is.EqualTo("Invalid MINHA CDN file format."));
        }

        [Test]
        public void ShouldFileExistsOnEndOfProcess()
        {
            var log = scrape.GetLogFile(url);
            string filePath = ".output.txt";
            scrape.ConvertFile(log,filePath);

            Assert.IsTrue(File.Exists(filePath));
        }

        [Test]
        public void ShouldFileIsntEmpty()
        {
            string filePath = ".output.txt";
            var log = scrape.GetLogFile(url);
            scrape.ConvertFile(log,filePath);
            string text = File.ReadAllText(filePath);

            Assert.IsFalse(String.IsNullOrEmpty(text));
        }
    }
}