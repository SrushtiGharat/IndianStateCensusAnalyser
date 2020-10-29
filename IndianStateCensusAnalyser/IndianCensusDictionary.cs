using IndianStateCensusAnalyser.DTO;
using System.Collections.Generic;

namespace IndianStateCensusAnalyser
{
    public class IndianCensusDictionary
    {
        string[] records;
        Dictionary<string, CensusDTO> censusDataMap;
        public Dictionary<string,CensusDTO> GetDictionary(string path,string header)
        {
            censusDataMap = new Dictionary<string, CensusDTO>();
            records = new GetCSVRecords().GetRecords(path, header);
            for(int i=1; i<records.Length;i++)
            {
                if(records[i].Contains(",") == false)
                {
                    throw new CensusAnalyserException("Delimiter is Invalid", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                string[] info = records[i].Split(",");
                censusDataMap.Add(info[1], new CensusDTO(new POCO.CensusDataDAO(info[0], info[1], info[2], info[3])));
            }

            return censusDataMap;
        }
    }
}
