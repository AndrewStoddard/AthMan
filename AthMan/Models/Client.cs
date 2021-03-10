using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AthMan.Models
{
    public class Client
    {
		
		public int ClientID { get; set; }
		[Required]
		public string FirstName { get; set; }
        [Required]
		public string LastName { get; set; }
        [Required]
		public string Address { get; set; }
        [Required]
		public string City { get; set; }
        [Required]
		public string State { get; set; }
        [Required]
		public string PostalCode { get; set; }
        [Required]
		public string CountryID { get; set; }
		public Country Country { get; set; }
        [Required] 
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

		public string FullName => FirstName + " " + LastName;   // read-only property
	}
}