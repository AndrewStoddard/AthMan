// ***********************************************************************
// Author           : Andrew Stoddard
// Created          : 03-10-2021
//
// Last Modified By : Andrew Stoddard
// Last Modified On : 03-10-2021
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;

namespace AthMan.Models
{
    /// <summary>
    /// Class Item.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>The item identifier.</value>
        public int ItemID { get; set; }

        /// <summary>
        /// Gets or sets the item code.
        /// </summary>
        /// <value>The item code.</value>
        [Required] public string ItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required] public string Name { get; set; }

        /// <summary>
        /// Gets or sets the yearly price.
        /// </summary>
        /// <value>The yearly price.</value>
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Must have a Price greater than 0")]
        public decimal YearlyPrice { get; set; }

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        /// <value>The release date.</value>
        [Required] [DataType(DataType.Date)] public DateTime ReleaseDate { get; set; } = DateTime.Now.Date;
    }
}