using Microsoft.AspNetCore.Identity;
using OldHouse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OldHouse.Data
{
    public class Patient
    {
		[Key]
		public int Id { get; set; }

		[Required]
        [StringLength(256, ErrorMessage = "Maximum length for first name is {1}")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "Maximum length for last name is {1}")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [StringLength(256, ErrorMessage = "Maximum length for display name is {1}")]
        public string Gender { get; set; }

        [StringLength(256, ErrorMessage = "Maximum length for display name is {1}")]
        public string BloodType { get; set; }

        [StringLength(int.MaxValue, ErrorMessage = "Maximum length for display name is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public string MachineId { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }

        public List<Record> Records { get; set; }

        public Relative Relative { get; set; }
        public List<Alert> Alerts { get; set; }
    }
}
