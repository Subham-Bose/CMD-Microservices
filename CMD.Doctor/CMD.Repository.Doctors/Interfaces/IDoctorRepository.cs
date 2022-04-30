using CMD.Model.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Repository.Doctors.Interfaces
{
    public interface IDoctorRepository
    {
        Doctor GetDoctor(int id);
        void EditDoctor(Doctor doctor);
        Doctor AddDoctor(Doctor doctor);
        ICollection<Doctor> GetAllDoctorToRecommend();
    }
}
