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
    /// Class Incident.
    /// </summary>
    public class Incident
    {
        /// <summary>
        /// Gets or sets the incident identifier.
        /// </summary>
        /// <value>The incident identifier.</value>
        public int IncidentID { get; set; }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>The client identifier.</value>
        [Required] public int ClientID { get; set; } // foreign key property

        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>The client.</value>
        public Client Client { get; set; } // navigation property

        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>The item identifier.</value>
        [Required] public int ItemID { get; set; } // foreign key property

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>The item.</value>
        public Item Item { get; set; } // navigation property
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        public int? EmployeeID { get; set; } // foreign key property - nullable
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        public Employee Employee { get; set; } // navigation property

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Required] public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Required] public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date opened.
        /// </summary>
        /// <value>The date opened.</value>
        [DataType(DataType.Date)] public DateTime DateOpened { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the date closed.
        /// </summary>
        /// <value>The date closed.</value>
        [DataType(DataType.Date)] public DateTime? DateClosed { get; set; } = null;
    }
}