using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthMan.Models
{
    public class Item
    {
		public int ItemID { get; set; }
        [Required]
		public string ItemCode { get; set; }
        [Required]
		public string Name { get; set; }
        [Required]
        public decimal YearlyPrice { get; set; }
        [Required]
		[DataType(DataType.Date)]
		public DateTime ReleaseDate { get; set; } = DateTime.Now.Date;
	}
}
