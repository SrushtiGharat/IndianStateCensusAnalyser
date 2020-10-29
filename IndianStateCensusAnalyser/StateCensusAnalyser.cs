using IndianStateCensusAnalyser.DTO;
using System.Collections.Generic;
using System.IO;

namespace IndianStateCensusAnalyser
{
    public class StateCensusAnalyser
    {
        public enum Country
        {
            INDIA
        }
        
        Dictionary<string, CensusDTO> censusDataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvPath,Country country,string csvHeader)
        {
            CheckFileExceptions.CheckExceptions(csvPath, country);
            censusDataMap = new CensusDataDictionary().LoadDictionary(csvPath, country, csvHeader);
            return censusDataMap;
        }
    }

}
