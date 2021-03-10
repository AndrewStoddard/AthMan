using System;
using System.ComponentModel.DataAnnotations;

namespace AthMan.Models
{
    public class Item
    {
        public int ItemID { get; set; }

        [Required] public string ItemCode { get; set; }

        [Required] public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Must have a Price greater than 0")]
        public decimal YearlyPrice { get; set; }

        [Required] [DataType(DataType.Date)] public DateTime ReleaseDate { get; set; } = DateTime.Now.Date;
    }
}