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
        StateCensusAnalyser stateCensusAnalyser;
        Dictionary<string, CensusDTO> stateDataRecord;
        
        [SetUp]
        public void Setup()
        {
            stateCensusAnalyser = new StateCensusAnalyser();
            stateDataRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void GivenIndianStateCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateDataRecord = stateCensusAnalyser.LoadCensusData(indianStateCensusDataCSVPath, Country.INDIA, indianStateCensusDataHeader);
            
            Assert.AreEqual(29, stateDataRecord.Count);
        }
        [Test]
        public void GivenIndianStateCensusDataWrongFilePath_WhenReaded_ShouldReturnCustomException()
        {
            try
            {
                stateDataRecord = stateCensusAnalyser.LoadCensusData(indianStateCensusDataWrongCSVPath, Country.INDIA, indianStateCensusDataHeader);
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
                stateDataRecord = stateCensusAnalyser.LoadCensusData(indianStateCensusDataWrongType, Country.INDIA, indianStateCensusDataHeader);
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
                stateDataRecord = stateCensusAnalyser.LoadCensusData(indianStateCensusDataDelimeter, Country.INDIA, indianStateCensusDataHeader);
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
                stateDataRecord = stateCensusAnalyser.LoadCensusData(indianStateCensusDataWrongHeader, Country.INDIA, indianStateCensusDataHeader);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, e.eType);
            }
        }

    }
}