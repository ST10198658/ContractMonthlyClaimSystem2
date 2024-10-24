namespace ContractMonthlyClaimSystem.Models
{
    public class ClaimType:UserActivity
    {
        public int Id { get; set; }
        public string ModuleName { set; get; }
        public string ModuleCode { set; get; }
        public string Description { set; get; }
        public DateTime Sessions { set; get; }
        public int Groups { set; get; }
        public int Rate { set; get; }
    }
}
