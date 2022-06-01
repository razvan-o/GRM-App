using GRM_App.DTOs;
using GRM_App.InputFileParsers;
using GRM_App.Utils;

const string MUSIC_CONTRACTS_FILE_PATH = @"InputFiles\Music_Contracts.txt";
const string DISTRIBUTION_PARTNER_CONTRACTS_FILE_PATH = @"InputFiles\Distribution_Partner_Contracts.txt";

var musicContractsParser = new MusicContractsFileParser();
var distributionPartnerContractsParser = new DistributionPartnerContractFileParser();

// TODO: can optimize by using dictionaries
var musicContracts = musicContractsParser.GetContracts(MUSIC_CONTRACTS_FILE_PATH);
var distributionPartnerContracts = distributionPartnerContractsParser.GetContracts(DISTRIBUTION_PARTNER_CONTRACTS_FILE_PATH);

while (true)
{
    string partnerName;
    DateTime effectiveDate;

    try
    {
        string searchCriteria = UserInputUtils.GetUserInput();
        UserInputUtils.ParseUserInput(searchCriteria, out partnerName, out effectiveDate);
    }
    catch
    {
        Console.WriteLine("Input not valid.");
        continue;
    }

    var usageType = distributionPartnerContracts.SingleOrDefault(dpc => dpc.Partner == partnerName)?.Usage;
    var matchingMusicContracts = GetMatchingContracts(musicContracts, effectiveDate, usageType);

    if (matchingMusicContracts.Count == 0)
    {
        Console.WriteLine("No matches found.");
        continue;
    }

    Console.WriteLine("\nArtist\t\t|Title\t\t\t|Usages\t\t|StartDate\t\t|EndDate");
    //TODO: start date and end date can be converted back to original format
    //TODO: indentation should take into account column length
    matchingMusicContracts.ForEach(mc => Console.WriteLine(mc.Artist + "\t|" +mc.Title + "\t\t|" + usageType + "\t|" +mc.StartDate.Date + "\t|" +mc.EndDate?.Date));
}

List<MusicContract> GetMatchingContracts(List<MusicContract> musicContracts, DateTime effectiveDate, string usageType)
    => musicContracts.Where(mc => mc.Usages.Contains(usageType)
            && mc.StartDate <= effectiveDate
            && (mc.EndDate == null || mc.EndDate >= effectiveDate))
        .OrderBy(mc => mc.Artist)
        .ThenBy(mc => mc.Title)
        .ThenBy(mc => mc.StartDate)
        .ToList();
