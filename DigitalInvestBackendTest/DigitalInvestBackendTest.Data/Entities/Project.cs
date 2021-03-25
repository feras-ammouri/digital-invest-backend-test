using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalInvestBackendTest.Data.Entities
{
    /// <summary>
    /// Represents project information
    /// </summary>
    [Table("project")]
    public class Project
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the project
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// The class of the project
        /// </summary>
        [Column("asset_class")]
        public string AssetClass { get; set; }


        /// <summary>
        /// The total volum of the project
        /// </summary>
        [Column("total_volum", TypeName = "decimal(18,2)")]
        public decimal TotalVolum { get; set; }

        /// <summary>
        /// The description of the project
        /// </summary>
        [Column("description")]
        public string Description { get; set; }

        public IList<Funding> Fundings { get; set; }
    }
}
