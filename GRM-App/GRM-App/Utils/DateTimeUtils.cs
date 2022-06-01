namespace GRM_App.Utils
{
    public static class DateTimeUtils
    {
        // there must be some library that does this better
        public static DateTime ParseDateString(string dateString)
        {
            if (dateString == null)
            {
                return default;
            }

            var dateProperties = dateString.Split(" ");

            dateProperties[0] = dateProperties[0].Replace("st", "");
            dateProperties[0] = dateProperties[0].Replace("nd", "");
            dateProperties[0] = dateProperties[0].Replace("th", "");
            if (dateProperties[0].Length == 1)
            {
                dateProperties[0] = "0" + dateProperties[0];
            }

            var formattedDateString = dateProperties[0] + "-" + dateProperties[1]+ "-" + dateProperties[2];

            return DateTime.Parse(formattedDateString);
        }
    }
}
