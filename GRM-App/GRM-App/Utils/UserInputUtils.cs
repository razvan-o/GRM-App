namespace GRM_App.Utils
{
    public static class UserInputUtils
    {
        public static string GetUserInput()
        {
            string searchCriteria;
            Console.Write("\nPlease enter the search criteria \"{partner_name} {effective_date}\": ");
            searchCriteria = Console.ReadLine();

            return searchCriteria;
        }

        public static void ParseUserInput(string searchCriteria, out string partnerName, out DateTime effectiveDate)
        {
            var inputSeparatorIndex = searchCriteria.IndexOf(' ');
            partnerName = searchCriteria.Substring(0, inputSeparatorIndex);
            effectiveDate = DateTimeUtils.ParseDateString(searchCriteria.Substring(inputSeparatorIndex + 1));
        }
    }
}
