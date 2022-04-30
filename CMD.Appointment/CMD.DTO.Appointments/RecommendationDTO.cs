using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DTO.Appointments
{
    public class RecommendationDTO
    {
        public int RecommendationId { get; set; }
        public string DoctorName { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
    }
}
