using CMD.DTO.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business.Doctors.Interfaces
{
    public interface IDoctorService
    {
        DoctorProfileDTO EditDoctor(DoctorProfileDTO doctorsDTO);
        DoctorProfileDTO GetDoctorsWithContact(int id);
        void EditDoctor(DoctorDTO doctorDTO);
        DoctorDTO GetDoctors(int id);
        DoctorCardDTO GetDoctorCard(int doctorId);
        ICollection<RDoctorDTO> GetAllDoctor();
    }
}
