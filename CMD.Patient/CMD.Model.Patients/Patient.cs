using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Model.Patients
{
    public class Patient
    {
        public Patient()
        {
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PatientPicture { get; set; }
        public Gender Gender { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public int Height { get; set; }
        public virtual ContactDetail ContactDetail { get; set; }
        [Column(TypeName = "Date")]
        public DateTime CreatedAt { get; private set; }
    }
}
