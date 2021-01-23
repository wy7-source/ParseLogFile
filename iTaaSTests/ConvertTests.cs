using System;
using NUnit.Framework;
using CandidateTesting.WythorFerreiraBazan.iTaaS;
using System.IO;

namespace CandidateTesting.WythorFerreiraBazan.iTaaSTests
{
    public class ConvertTests
    {
        private ScrapeService scrapeService;
        private ConvertService convertService;
        private string url;
        private string filePath;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            scrapeService = new ScrapeService();
            convertService = new ConvertService();
            url = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
            filePath = ".output.txt";
        }

        [Test]
        // ShouldFileExistsOnEndOfProcess is our test if after all process, file has been created.
        public void Convert_ShouldFileExistsOnEndOfProcess()
        {
            var log = scrapeService.GetLogFile(url);
            convertService.ConvertFile(log,filePath);

            Assert.IsTrue(File.Exists(filePath));
        }

        [Test]
        // FileMustNotBeEmptyAfterConversion is our test if after file has been created, it isnt empty.
        public void Convert_FileMustNotBeEmptyAfterConversion()
        {
            var log = scrapeService.GetLogFile(url);
            convertService.ConvertFile(log,filePath);
            string text = File.ReadAllText(filePath);

            Assert.IsFalse(String.IsNullOrEmpty(text));
        }
    }
}