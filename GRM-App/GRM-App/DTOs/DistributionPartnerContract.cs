namespace GRM_App.DTOs
{
    public class DistributionPartnerContract
    {
        public string Partner { get; set; }
        public string Usage { get; set; } // some platforms may have multiple usages, but example files do not suggest this

        public DistributionPartnerContract(string partner, string usage)
        {
            Partner=partner;
            Usage=usage;
        }
    }
}
