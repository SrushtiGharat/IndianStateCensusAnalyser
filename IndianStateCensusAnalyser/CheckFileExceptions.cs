using System.IO;


namespace IndianStateCensusAnalyser
{
    public class CheckFileExceptions
    {
        public static void CheckExceptions(string csvPath)
        {
            if (File.Exists(csvPath) == false)
            {
                throw new CensusAnalyserException("File Does Not Exist", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvPath) != ".csv")
            {
                throw new CensusAnalyserException("File Path is Improper", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            
        }
    }
}
