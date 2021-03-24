using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalInvestBackendTest.Data.Entities
{
    /// <summary>
    ///  Represents investor information
    /// </summary>
    [Table("investor")]
    public class Investor
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the project
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        public IList<Funding> Fundings { get; set; }
    }
}
