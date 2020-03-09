using OldHouse.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldHouse.Models
{
    public class Record
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(int.MaxValue, ErrorMessage = "Maximum length for first name is {1}")]
        public string Description { get; set; }

        [Required]
        [Range(0, 1000000000)]
        public float BloodPressure { get; set; }

        [Required]
        [Range(0, 1000000000)]
        public float HeartRate { get; set; }

        [Required]
        [Range(0, 1000000000)]
        public float Temperature { get; set; }

        [Required]
        [Range(0, 1000000000)]
        public float GlucoseLevel { get; set; }

        public int PatientId { get; set; }

		[DataType(DataType.DateTime)]
        [Display(Name = "Created At")]
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		[ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}
