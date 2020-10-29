using NUnit.Framework;
using IndianStateCensusAnalyser;
using System.Collections.Generic;
using IndianStateCensusAnalyser.DTO;
using static IndianStateCensusAnalyser.StateCensusAnalyser;

namespace IndianStateAnalyserTest
{
    public class Tests
    {
        string indianStateCensusDataCSVPath = @"C:\Users\Gharat\source\repos\IndianStateCensusAnalyser\IndianStateAnalyserTest\CensusFiles\IndiaStateCensusData.csv";
        string indianStateCensusDataHeader = "State,Population,AreaInSqKm,DensityPerSqKm";
        string indianStateCensusDataWrongCSVPath = @"C:\Users\Gharat\source\IndianStateCensusAnalyser\IndianStateAnalyserTest\CensusFiles\IndiaStateCensusData.csv";
        string indianStateCensusDataWrongType = @"C:\Users\Gharat\source\repos\IndianStateCensusAnalyser\IndianStateAnalyserTest\CensusFiles\IndiaStateCode.txt";
        string indianStateCensusDataDelimeter = @"C:\Users\Gharat\source\repos\IndianStateCensusAnalyser\IndianStateAnalyserTest\CensusFiles\DelimiterIndiaStateCensusData.csv";
        string indianStateCensusDataWrongHeader = @"C:\Users\Gharat\source\repos\IndianStateCensusAnalyser\IndianStateAnalyserTest\CensusFiles\WrongIndiaStateCensusData.csv";

        string indiaStateCodeCSVPath = @"C:\Users\Gharat\source\repos\IndianStateCensusAnalyser\IndianStateAnalyserTest\CensusFiles\IndiaStateCode.csv";
        string indianStateCodeHeader = "SrNo,State Name,TIN,StateCode";
        string indianStateCodeWrongCSVPath = @"C:\Users\source\repos\IndianStateCensusAnalyser\IndianStateAnalyserTest\CensusFiles\IndiaStateCode.csv";
        string indianStateCodeWrongFileType = @"C:\Users\Gharat\source\repos\IndianStateCensusAnalyser\IndianStateAnalyserTest\CensusFiles\IndiaStateCode.txt";
        string indianStateStateCodeDelimeter = @"C:\Users\Gharat\source\repos\IndianStateCensusAnalyser\IndianStateAnalyserTest\CensusFiles\DelimiterIndiaStateCode.csv";
        string indianStateCodeWrongHeader = @"C:\Users\Gharat\source\repos\IndianStateCensusAnalyser\IndianStateAnalyserTest\CensusFiles\WrongIndiaStateCode.csv";

        StateCensusAnalyser stateCensusAnalyser;
        Dictionary<string, CensusDTO> censusDataRecord;
        Dictionary<string, CensusDTO> stateCodeRecord;
        [SetUp]
        public void Setup()
        {
            stateCensusAnalyser = new StateCensusAnalyser();
            censusDataRecord = new Dictionary<string, CensusDTO>();
            stateCodeRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void GivenIndianStateCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            censusDataRecord = stateCensusAnalyser.LoadCensusData(indianStateCensusDataCSVPath, Country.INDIA, indianStateCensusDataHeader);
            
            Assert.AreEqual(29, censusDataRecord.Count);
        }
        [Test]
        public void GivenIndianStateCensusDataWrongFilePath_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                censusDataRecord = stateCensusAnalyser.LoadCensusData(indianStateCensusDataWrongCSVPath, Country.INDIA, indianStateCensusDataHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND,e.eType);
            }
        }
        [Test]
        public void GivenIndianStateCensusDataWrongFileType_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                censusDataRecord = stateCensusAnalyser.LoadCensusData(indianStateCensusDataWrongType, Country.INDIA, indianStateCensusDataHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, e.eType);
            }
        }
        [Test]
        public void GivenIndianStateCensusDataFileWrongDelimiter_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                censusDataRecord = stateCensusAnalyser.LoadCensusData(indianStateCensusDataDelimeter, Country.INDIA, indianStateCensusDataHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, e.eType);
            }
        }
        [Test]
        public void GivenIndianStateCensusDataFileWrongHeader_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                censusDataRecord = stateCensusAnalyser.LoadCensusData(indianStateCensusDataWrongHeader, Country.INDIA, indianStateCensusDataHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, e.eType);
            }
        }
        [Test]
        public void GivenIndianStateCodeDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateCodeRecord = stateCensusAnalyser.LoadCensusData(indiaStateCodeCSVPath, Country.INDIA, indianStateCodeHeader);

            Assert.AreEqual(37, stateCodeRecord.Count);
        }
        [Test]
        public void GivenIndianStateCodeWrongFilePath_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                stateCodeRecord = stateCensusAnalyser.LoadCensusData(indianStateCodeWrongCSVPath, Country.INDIA, indianStateCodeHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.eType);
            }
        }
        [Test]
        public void GivenIndianStateCodeWrongFileType_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                stateCodeRecord = stateCensusAnalyser.LoadCensusData(indianStateCodeWrongFileType, Country.INDIA, indianStateCodeHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, e.eType);
            }
        }
        [Test]
        public void GivenIndianStateCodeFileWrongDelimiter_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                stateCodeRecord = stateCensusAnalyser.LoadCensusData(indianStateStateCodeDelimeter, Country.INDIA, indianStateCodeHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, e.eType);
            }
        }
        [Test]
        public void GivenIndianStateCodeFileWrongHeader_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                stateCodeRecord = stateCensusAnalyser.LoadCensusData(indianStateCodeWrongHeader, Country.INDIA, indianStateCodeHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, e.eType);
            }
        }

    }
}