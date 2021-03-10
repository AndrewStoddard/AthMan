// ***********************************************************************
// Author           : Andrew Stoddard
// Created          : 03-10-2021
//
// Last Modified By : Andrew Stoddard
// Last Modified On : 03-10-2021
// ***********************************************************************
using System.ComponentModel.DataAnnotations;

namespace AthMan.Models
{
    /// <summary>
    /// Class Employee.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required] public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Required] [EmailAddress] public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        [Required] [Phone] public string Phone { get; set; }
    }
}