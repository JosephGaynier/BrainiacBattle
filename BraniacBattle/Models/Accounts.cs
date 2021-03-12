using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BraniacBattle.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            AccountGameStatistics = new HashSet<AccountGameStatistics>();
            AccountsBadges = new HashSet<AccountsBadges>();
            Results = new HashSet<Results>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public int BrainRating { get; set; }

        public virtual ICollection<AccountGameStatistics> AccountGameStatistics { get; set; }
        public virtual ICollection<AccountsBadges> AccountsBadges { get; set; }
        public virtual ICollection<Results> Results { get; set; }
    }
}
