using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalInvestBackendTest.Services.Models
{
    /// <summary>
    /// Represents funding (project) information
    /// </summary>
    public class Project
    {
        /// <summary>
        /// The Id of the project
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the project
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The class of the project
        /// </summary>
        public string AssetClass { get; set; }

        /// <summary>
        /// The total volum of the project
        /// </summary>
        public decimal TotalVolum { get; set; }

        /// <summary>
        /// The already invested of the project
        /// </summary>
        public decimal AlreadyInvested { get; set; }

        /// <summary>
        /// The description of the project
        /// </summary>
        public string Description { get; set; }

    }
}
