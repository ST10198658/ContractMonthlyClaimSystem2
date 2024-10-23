namespace ContractMonthlyClaimSystem.Models
{
    public class Lecturer
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateofBirth { get; set; }

        public int Phone { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        
    }
}
