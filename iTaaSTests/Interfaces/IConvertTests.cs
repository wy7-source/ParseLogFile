using System.Text.RegularExpressions;

namespace CandidateTesting.WythorFerreiraBazan.iTaaSTests.Interfaces
{
    public interface IConvertTests
    {
        void Convert_ShouldFileExistsOnEndOfProcess();
        void Convert_FileMustNotBeEmptyAfterConversion();
    }
}