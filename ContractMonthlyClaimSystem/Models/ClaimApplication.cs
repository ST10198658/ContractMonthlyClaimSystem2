using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ContractMonthlyClaimSystem.Models
{
    public class ClaimApplication:ApprovalActivity
    {
        public int Id { get; set; }

        [Display(Name="Lecturer Name")]
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        [Display(Name = "Number of Days")]
        public int NumofDays { get; set; }
        public int ClaimTypeId { get; set; }
        public ClaimType ClaimType { get; set; }
        public string? Attachment {  get; set; }

        [Display(Name = "Notes")]
        public string Description { get; set; }

        [Display(Name = "Status ")]
        public int StatusId { get; set; }
        public SystemCodeDetail Status { get; set; }
    }
}
