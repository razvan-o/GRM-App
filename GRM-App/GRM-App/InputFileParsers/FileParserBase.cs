namespace GRM_App.InputFileParsers
{
    public class FileParserBase
    {
        public const string FILE_COLUMNS_SEPARATOR = "|";

        public string[] GetFileLines(string filePath)
        {
            Console.WriteLine("Reading file: " + filePath);

            string[] lines = File.ReadAllLines(filePath);

            return lines;
        }
    }
}
