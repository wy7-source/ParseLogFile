using System.Text.RegularExpressions;

namespace CandidateTesting.WythorFerreiraBazan.iTaaS.Interfaces
{
    public interface IConvertServices
    {
        void ConvertFile(MatchCollection collection, string localToSaveFile);
    }
}