using CMD.Model.Doctors;
using CMD.Repository.Doctors.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Repository.Doctors.Implementations
{
    public class DoctorRepository : IDoctorRepository
    {
        private DoctorContext db;

        public DoctorRepository()
        {
            this.db = new DoctorContext();
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            var result = db.Doctors.Add(doctor);
            db.SaveChanges();
            return result;
        }

        public void EditDoctor(Doctor doctor)
        {
            db.Entry(doctor).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Doctor GetDoctor(int id)
        {
            return db.Doctors.Include(d => d.ContactDetail).Where(d => d.Id == id).FirstOrDefault();
        }

        public ICollection<Doctor> GetAllDoctorToRecommend()
        {
            return db.Doctors.ToList();
        }
    }
}
