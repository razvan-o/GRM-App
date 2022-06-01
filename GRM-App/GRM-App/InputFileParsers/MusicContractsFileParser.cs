using GRM_App.DTOs;
using GRM_App.Utils;

namespace GRM_App.InputFileParsers
{
    public class MusicContractsFileParser : FileParserBase
    {
        const string EXPECTED_FILE_HEADER = "Artist|Title|Usages|StartDate|EndDate";

        public List<MusicContract> GetContracts(string contractsFilePath)
        {
            var fileLines = base.GetFileLines(contractsFilePath);

            ValidateFileFormat(fileLines);

            var expectedColumnsCount = EXPECTED_FILE_HEADER.Split(FILE_COLUMNS_SEPARATOR).Length;
            var contractList = new List<MusicContract>(); 

            for (int i = 1; i < fileLines.Length; i++)
            {
                var contractLineProperties = fileLines[i].Split(FILE_COLUMNS_SEPARATOR);
                if (contractLineProperties.Length != expectedColumnsCount)
                {
                    Console.WriteLine("Error parsing line: \"" + fileLines[i] + "\". Skipping line.");
                    continue;
                }

                contractList.Add(new MusicContract
                {
                    Artist = contractLineProperties[0],
                    Title = contractLineProperties[1],
                    Usages = contractLineProperties[2].Split(",").Select(s => s.Trim()).ToList(),
                    StartDate = DateTimeUtils.ParseDateString(contractLineProperties[3]),
                    EndDate = string.IsNullOrEmpty(contractLineProperties[4]) ? null : DateTimeUtils.ParseDateString(contractLineProperties[4])
                });
            }

            return contractList;
        }

        private void ValidateFileFormat(string[] fileLines)
        {
            if (fileLines.Length == 0)
            {
                throw new FormatException("Empty Music_Contracts file.");
            }

            if (fileLines[0] != EXPECTED_FILE_HEADER)
            {
                throw new FormatException("Unexpected Music_Contracts file header.");
            }

            // additional validation
        }
    }
}
