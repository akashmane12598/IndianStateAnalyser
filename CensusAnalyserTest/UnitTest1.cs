using NUnit.Framework;

namespace CensusAnalyserTest
{
    public class Tests
    {
        public string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        public string indianStateCensusFilePath = @"C:\Users\LENOVO\source\repos\IndianStateAnalyser\IndianStateAnalyser\CSVFiles\IndiaStateCensusData - IndiaStateCensusData.csv";
        public string wrongHeaderIndianCensusFilePath = @"C:\Users\LENOVO\source\repos\IndianStateAnalyser\IndianStateAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}