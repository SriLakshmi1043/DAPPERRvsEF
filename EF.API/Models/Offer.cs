using System;
using System.Collections.Generic;

namespace EF.API.Models
{
    public partial class Offer
    {
        public int Id { get; set; }
        public string? BookName { get; set; }
        public string? Description { get; set; }
        public int? Amount { get; set; }
    }
}
