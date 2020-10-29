using System.IO;


namespace IndianStateCensusAnalyser
{
    public class CheckFileExceptions
    {
        public static void CheckExceptions(string csvPath, StateCensusAnalyser.Country country)
        {
            if (File.Exists(csvPath) == false)
            {
                throw new CensusAnalyserException("File Does Not Exist", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvPath) != ".csv")
            {
                throw new CensusAnalyserException("File Path is Improper", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            if (country != StateCensusAnalyser.Country.INDIA)
            {
                throw new CensusAnalyserException("No such country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
