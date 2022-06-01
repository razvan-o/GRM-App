using GRM_App.DTOs;

namespace GRM_App.InputFileParsers
{
    public class DistributionPartnerContractFileParser : FileParserBase
    {
        const string EXPECTED_FILE_HEADER = "Partner|Usage";

        public List<DistributionPartnerContract> GetContracts(string contractsFilePath)
        {
            var fileLines = base.GetFileLines(contractsFilePath);

            ValidateFileFormat(fileLines);

            var expectedColumnsCount = EXPECTED_FILE_HEADER.Split(FILE_COLUMNS_SEPARATOR).Length;
            var contractList = new List<DistributionPartnerContract>();

            for (int i = 1; i < fileLines.Length; i++)
            {
                var contractLineProperties = fileLines[i].Split(FILE_COLUMNS_SEPARATOR);
                if(contractLineProperties.Length != expectedColumnsCount)
                {
                    Console.WriteLine("Error parsing line: \"" + fileLines[i] + "\". Skipping line.");
                    continue;
                }

                contractList.Add(new DistributionPartnerContract(contractLineProperties[0], contractLineProperties[1]));
            }

            return contractList;
        }

        //TODO: this could throw some custom exceptions
        private void ValidateFileFormat(string[] fileLines)
        {
            if (fileLines.Length == 0)
            {
                throw new FormatException("Empty Distribution_Partner_Contract file.");
            }

            if (fileLines[0] != EXPECTED_FILE_HEADER)
            {
                throw new FormatException("Unexpected Distribution_Partner_Contract file header.");
            }

            // additional validation
        }
    }
}