using Microsoft.AspNetCore.Identity;
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
        public string PatientId { get; set; }
        [Required]
        [StringLength(256, ErrorMessage = "Maximum length for first name is {1}")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(256, ErrorMessage = "Maximum length for middle name is {1}")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "Maximum length for last name is {1}")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(256, ErrorMessage = "Maximum length for display name is {1}")]
        [Display(Name = "Full Name")]
        public string DisplayName
        {
            get { return this.FirstName + ' ' + this.LastName; }
            set { }
        }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

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

        public bool IsAlive { get; set; }

        public List<Record> Records { get; set; }

        public Relative Relative { get; set; }
        public List<Alert> Alerts { get; set; }
    }
}
