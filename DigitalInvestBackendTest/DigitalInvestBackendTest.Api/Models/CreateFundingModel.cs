using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalInvestBackendTest.Api.Models
{
    /// <summary>
    /// Model for creating funding 
    /// </summary>
    public class CreateFundingModel
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public Guid InvestorId { get; set; }

        [Required]
        public decimal InvestmentAmount { get; set; }
    }
}
