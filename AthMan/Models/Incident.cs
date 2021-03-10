using System;
using System.ComponentModel.DataAnnotations;

namespace AthMan.Models
{
    public class Incident
    {
		public int IncidentID { get; set; }
		[Required]
		public int ClientID { get; set; }     // foreign key property
		public Client Client { get; set; }  // navigation property
        [Required]
		public int ItemID { get; set; }     // foreign key property
		public Item Item { get; set; }   // navigation property
		public int? EmployeeID { get; set; }     // foreign key property - nullable
		public Employee Employee { get; set; }   // navigation property
        [Required]
		public string Title { get; set; }
        [Required]
		public string Description { get; set; }
		[DataType(DataType.Date)]
		public DateTime DateOpened { get; set; } = DateTime.Now;
		[DataType(DataType.Date)]
		public DateTime? DateClosed { get; set; } = null;
	}
}