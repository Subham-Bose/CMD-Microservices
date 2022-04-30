using CMD.Model.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Repository.Patients.Interfaces
{
    public interface IPatientRepository
    {
        Patient GetPatient(int patientId);
        ICollection<Patient> GetAllPatients();
    }
}
