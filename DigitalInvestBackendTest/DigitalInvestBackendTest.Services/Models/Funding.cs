using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalInvestBackendTest.Services.Models
{
    public class Funding
    {
        /// <summary>
        /// The id of the project
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// The id of the investor
        /// </summary>
        public Guid InvestorId { get; set; }

        /// <summary>
        /// The amount of the investment
        /// </summary>
        public decimal InvestmentAmount { get; set; }
    }
}
