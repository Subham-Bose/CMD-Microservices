using CMD.Business.Patients.Interfaces;
using CMD.DTO.Patients;
using CMD.Model.Patients;
using CMD.Repository.Patients.Implementations;
using CMD.Repository.Patients.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business.Patients.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository repo;

        public PatientService()
        {
            repo = new PatientRepository();
        }
        public ICollection<PatientDTO> GetAllPatient()
        {
            var patients = repo.GetAllPatients();

            ICollection<PatientDTO> result = new List<PatientDTO>();
            foreach (var patient in patients)
            {
                result.Add(new PatientDTO { Id = patient.Id, Name = patient.Name, PhoneNumber = patient.ContactDetail.PhoneNumber });
            }
            return result;
        }

        public PatientCardDTO GetPatient(int patientId)
        {
            Patient patient = repo.GetPatient(patientId);
            PatientCardDTO PatientCard = new PatientCardDTO
            {
                Id = patient.Id,
                PatientPicture = patient.PatientPicture,
                Name = patient.Name,
                PhoneNumber = patient.ContactDetail.PhoneNumber,
                Mail = patient.ContactDetail.Email,
                DOB = patient.DOB.Date.ToString(),
                Age = DateTime.Today.Year - patient.DOB.Year,
                BloodGroup = patient.BloodGroup.ToString(),
                Gender = patient.Gender.ToString()
            };
            return PatientCard;
        }

    }
}
