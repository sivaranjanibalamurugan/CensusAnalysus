using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CensusAnalysisTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string stateCensusPath = @"C:\Users\user\source\repos\CensusAnalyser\CensusAnalyser\ImdianStateCensusData.csv";
            string wrongPath = @"C:\Users\user\source\repos\CensusAnalyser\CensusAnalyser";
            string wrongFileType = @"C:\Users\user\source\repos\CensusAnalyser\CensusAnalyser";
            string invalidDelimeter = @"C:\Users\user\source\repos\CensusAnalyser\CensusAnalyser";
            IndianStateCensusAnalyser.CensusAdapterFactory csv = null;
            CensusAdapter adapter;
            Dictionary<string, CensusDataDAO> totalRecord;
            string[] stateRecord;

            [TestInitialize]
            public void testSetup()
            {
                csv = new CensusAdapterFactory();
                adapter = new CensusAdapter();
                totalRecord = new Dictionary<string, CensusDataDAO>();
            }

        }
    }
}
