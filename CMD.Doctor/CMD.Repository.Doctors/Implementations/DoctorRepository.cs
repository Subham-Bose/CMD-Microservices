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

        public Doctor EditDoctor(Doctor doctor)
        {
            var existingDoctor = db.Doctors.Where(d => d.Id == doctor.Id).Include(d => d.ContactDetail).FirstOrDefault();
            if(existingDoctor == null)
            {
                return null;
            }
            else
            {
                db.Entry(existingDoctor).CurrentValues.SetValues(doctor);
                var contacts = existingDoctor.ContactDetail;
                if(contacts == null)
                {
                    existingDoctor.ContactDetail = new ContactDetail()
                    {
                        Email = doctor.ContactDetail.Email,
                        PhoneNumber = doctor.ContactDetail.PhoneNumber,
                    };                    
                }
                else if(contacts.Id == doctor.ContactDetail.Id)
                {
                    db.Entry(existingDoctor.ContactDetail).CurrentValues.SetValues(doctor.ContactDetail);
                }
            }
            db.SaveChanges();
            return existingDoctor;
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
