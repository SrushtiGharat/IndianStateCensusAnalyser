using IndianStateCensusAnalyser.DTO;
using System.IO;
using System.Collections.Generic;
using CsvHelper;
using System.Globalization;
using System.Linq;

namespace IndianStateCensusAnalyser
{
    public class CensusDataDictionary
    {
        public Dictionary<string, CensusDTO> censusDataMap;
        public Dictionary<string, CensusDTO> LoadDictionary(string path,StateCensusAnalyser.Country country, string header)
        {
            if (country == StateCensusAnalyser.Country.INDIA)
            {
                censusDataMap = new IndianCensusDictionary().GetDictionary(path, header);
            }
            
            return censusDataMap;
        }
    }
}
