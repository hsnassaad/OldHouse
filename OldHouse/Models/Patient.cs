using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using OldHouse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldHouse.Data
{
    public class Patient
    {
		[Key]
		public int PatientId { get; set; }

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

        public string BloodType { get; set; }

        public int MachineId { get; set; }

        [ForeignKey("MachineId")]
        public Machine Machine { get; set; }

      
        public string DisplayName
        {
            get { return FirstName + ' ' + LastName; }
            set { }
        }


        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> BloodTypes { get; set; }
        public List<Record> Records { get; set; }

        public Relative Relative { get; set; }
        public List<Alert> Alerts { get; set; }
    }
}
