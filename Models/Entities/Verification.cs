using System;
using System.Collections.Generic;

namespace Tulet.Models.Entities
{
    public partial class Verification
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessAddress { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNo { get; set; }
        public DateTime IdentificationExpiry { get; set; }
        public string CaCNo { get; set; }
        public DateTime VerDate { get; set; }

        public User User { get; set; }
    }
}
