using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalInvestBackendTest.Data.Entities
{
    /// <summary>
    ///  Represents funding information
    /// </summary>
    [Table("funding")]
    public class Funding
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The id of the project
        /// </summary>
        [Column("project_id")]
        public Guid ProjectId { get; set; }

        /// <summary>
        /// The id of the investor
        /// </summary>
        [Column("investor_id")]
        public Guid InvestorId { get; set; }


        /// <summary>
        /// The amount of the investment
        /// </summary>
        [Column("investment_amount", TypeName = "decimal(18,2)")]
        public decimal InvestmentAmount { get; set; }

        /// <summary>
        /// The date of the investment
        /// </summary>
        [Column("investment_date")]
        public DateTime InvestmentDate { get; set; }

        public Project Project { get; set; }

        public Investor Investor { get; set; }
    }
}
