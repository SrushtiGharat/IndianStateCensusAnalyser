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
        
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvPath,Country country,string csvHeader)
        {
            CheckFileExceptions.CheckExceptions(csvPath, country);
            dataMap = new CensusDataDictionary().LoadDictionary(csvPath, country, csvHeader);
            return dataMap;
        }
    }

}
