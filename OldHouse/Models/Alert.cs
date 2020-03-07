using OldHouse.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OldHouse.Models
{
    public class Alert
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(int.MaxValue, ErrorMessage = "Maximum length for first name is {1}")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

		[StringLength(int.MaxValue, ErrorMessage = "Maximum length for first name is {1}")]
		public String level { get; set; }

		[Range(0, 1000000000)]
		public int PatientId { get; set; }

		[ForeignKey("PatientId")]
		public Patient Patient { get; set; }

		//public bool Seen { get; set; }

		//public DateTime SeenAt { get; set; }

	}
}
