using CMD.Model.Patients;
using CMD.Repository.Patients.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Repository.Patients.Implementations
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientContext db;

        public PatientRepository()
        {
            db = new PatientContext();
        }

        public Patient GetPatient(int patientId)
        {
            var result = db.Patients.Where(a => a.Id == patientId).
                Include(p => p.ContactDetail).FirstOrDefault();
            return result;
        }
        public ICollection<Patient> GetAllPatients()
        {
            var result = db.Patients.Include(p => p.ContactDetail).ToList();
            return result;
        }
    }
}
