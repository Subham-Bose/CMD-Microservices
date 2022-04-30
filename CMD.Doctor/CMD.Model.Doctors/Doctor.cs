using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Model.Doctors
{
    public class Doctor
    {
        public Doctor()
        {
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string DoctorPicture { get; set; }
        public string NPINumber { get; set; }
        public string PracticeLocation { get; set; }
        public string Speciality { get; set; }
        public ContactDetail ContactDetail { get; set; }
        public ICollection<AvailabilitySlot> AvailabilitySlots { get; set; }
        [Column(TypeName="Date")]
        public DateTime CreatedAt { get; private set; }
    }
}
