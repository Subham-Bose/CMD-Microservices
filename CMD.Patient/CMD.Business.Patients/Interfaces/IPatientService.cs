using CMD.DTO.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business.Patients.Interfaces
{
    public interface IPatientService
    {
        ICollection<PatientDTO> GetAllPatient();
        PatientCardDTO GetPatient(int patientId);
    }
}
