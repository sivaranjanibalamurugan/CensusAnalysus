using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndianStateCensusAnalyser;
using System.Collections.Generic;

namespace CensusAnalysisTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string stateCensusPath = @"C:\Users\user\source\repos\CensusAnalyser\CensusAnalyser\IndianStateCensusData.csv";
            string wrongPath = @"C:\Users\user\source\repos\CensusAnalyser\CensusAnalyser\IndiainStateCensus.csv";
            string wrongFileType = @"C:\Users\user\source\repos\CensusAnalyser\CensusAnalyser\TextFile.txt";
            string invalidDelimeter = @"C:\Users\user\source\repos\CensusAnalyser\CensusAnalyser\WrongDelimiter";
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
            //TC1.1
            //Giving correct path it should return total count of the census list
            [TestMethod]
            public void GivenStateCensusReturnTotalRecord()
            {
                stateRecord = adapter.GetCensusData(stateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm");
                int actual = stateRecord.Length - 1;
                int expected = 36;
                //assertion
                Assert.AreEqual(actual, expected);
            }
            //TC 1.2
            //Given the incorrect path return file not exist
            [TestCategory("StateCensusAnalyser")]
            [TestMethod]
            public void GivenIncorrectPath()
            {
                try
                {
                    var stateRecor = adapter.GetCensusData(wrongPath, "State,Population,AreaInSqKm,DensityPerSqKm");

                }
                catch (CensusAnalyserException ce)
                {
                    Assert.AreEqual("File Not Found", ce.Message);
                }
            }
            //TC 1.3
            //Given the invalid file it returns invalid file type exception
            [TestCategory("StateCensusAnalyser")]
            [TestMethod]
            public void GivenInvalidFile()
            {
                try
                {
                    var stateRecor = adapter.GetCensusData(wrongFileType, "State,Population,AreaInSqKm,DensityPerSqKm");

                }
                catch (CensusAnalyserException ce)
                {
                    Assert.AreEqual("Invalid File Type", ce.Message);
                }
            }
            //TC 1.4
            //Given the file with in valid delimeter
            [TestCategory("StateCensusAnalyser")]
            [TestMethod]
            public void GivenInvalidDelimeter()
            {
                try
                {
                    var stateRecor = adapter.GetCensusData(invalidDelimeter, "State,Population,AreaInSqKm,DensityPerSqKm");

                }
                catch (CensusAnalyserException ce)
                {
                    Assert.AreEqual("File contains invalid Delimiter", ce.Message);
                }
            }
            //TC 1.5
            //when passing the incorrect header
            [TestCategory("StateCensusAnalyser")]
            [TestMethod]
            public void GivenIncorrectHeader()
            {
                try
                {
                    var stateRecor = adapter.GetCensusData(invalidDelimeter, "State,Population,Area,DensityPerSqKm");

                }
                catch (CensusAnalyserException ce)
                {
                    Assert.AreEqual("Data header in not matched", ce.Message);
                }
            }
            //TC2.1
            //Giving correct path it should return total count of the census list
            [TestCategory("StateCodeAnalser")]
            [TestMethod]
            public void GivenStateCensusReturnTotalRecordForStateCode()
            {
                stateRecord = adapter.GetCensusData(stateCodePath, "SrNo,State,TIN,StateCode");
                int actual = stateRecord.Length - 1;
                int expected = 37;
                //assertion
                Assert.AreEqual(actual, expected);
            }
        }
        //TC 2.2
        //Given the incorrect path return file not exist
        [TestCategory("StateCode")]
        [TestMethod]
        public void GivenIncorrectPathForStateCode()
        {
            try
            {
                var stateRecor = adapter.GetCensusData(wrongPath, "SrNo,State,TIN,StateCode");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("File Not Found", ce.Message);
            }
        }
        //TC 2.3
        //Given the invalid file it returns invalid file type exception
        [TestCategory("StateCode")]
        [TestMethod]
        public void GivenInvalidFileForUC2()
        {
            try
            {
                var stateRecor = adapter.GetCensusData(wrongFileType, "SrNo,State,TIN,StateCode");

            }
            catch (CensusAnalyserException ce)
            {
                Assert.AreEqual("Invalid File Type", ce.Message);
            }
        }
    }
}
