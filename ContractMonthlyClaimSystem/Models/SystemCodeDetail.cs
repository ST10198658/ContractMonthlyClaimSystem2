using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Models
{
    public class SystemCodeDetail:UserActivity
    {
        [Key]
        public int Id { get; set; }
        public string SystemCodeId { get; set; }
        public SystemCode SystemCodes { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }
}
