using IndianStateAnalyser;
using IndianStateAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;

namespace CensusAnalyserTest
{
    public class Tests
    {
        public string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        public string indianStateCensusFilePath = @"C:\Users\LENOVO\source\repos\IndianStateAnalyser\IndianStateAnalyser\CSVFiles\IndiaStateCensusData.csv";
        public string wrongHeaderIndianCensusFilePath = @"C:\Users\LENOVO\source\repos\IndianStateAnalyser\IndianStateAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        public string delimeterIndianCensusFilePath = @"C:\Users\LENOVO\source\repos\IndianStateAnalyser\IndianStateAnalyser\CSVFiles\DelimiterIndiaStateCensusData.csv";
        public string wrongIndianStateCensusFilePath = @"C:\Users\LENOVO\source\repos\IndianStateAnalyser\IndianStateAnalyser\CSVFiles\IndiaData.csv";
        public string wrongIndianStateCensusFileType = @"C:\Users\LENOVO\source\repos\IndianStateAnalyser\IndianStateAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        public string indianStateCodeFilePath = @"C:\Users\LENOVO\source\repos\IndianStateAnalyser\IndianStateAnalyser\CSVFiles\IndiaStateCode.csv";
        public string wrongIndianStateCodeFileType = @"C:\Users\LENOVO\source\repos\IndianStateAnalyser\IndianStateAnalyser\CSVFiles\IndiaStateCode.txt";
        public string delimeterIndianStateCodeFilePath = @"C:\Users\LENOVO\source\repos\IndianStateAnalyser\IndianStateAnalyser\CSVFiles\DelimiterIndiaStateCode.csv";
        public string wrongHeaderStateCodeFilePath = @"C:\Users\LENOVO\source\repos\IndianStateAnalyser\IndianStateAnalyser\CSVFiles\WrongIndiaStateCode.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecords;
        Dictionary<string, CensusDTO> stateRecords;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReadReturnCensusDataCount()
        {
            totalRecords = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecords = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecords.Count);
            Assert.AreEqual(37, stateRecords.Count);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReadReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(()=>censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders) );
            var stateException = Assert.Throws<CensusAnalyserException>(()=>censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCodeHeaders) );
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReadReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(()=> censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFileType_ButIncorrectDelimeter_WhenReadReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(()=> censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(()=> censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER, stateException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFileType_ButIncorrectHeader_WhenReadReturnException()
        {
            var censusException =Assert.Throws<CensusAnalyserException>(()=> censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(()=> censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}