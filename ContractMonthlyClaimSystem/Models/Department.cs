﻿namespace ContractMonthlyClaimSystem.Models
{
    public class Department:UserActivity
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
