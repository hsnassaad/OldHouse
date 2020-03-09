using OldHouse.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OldHouse.Models
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }

		public string Battery { get; set; }

        public string Status { get; set; }

        public string SerialNumber
        {
            get { return "Machine #" + ' ' + MachineId; }
            set { }
        }

		[Range(0, 1000000000)]
		public int PatientId { get; set; }

		[ForeignKey("PatientId")]
		public Patient Patient { get; set; }
	}
}
