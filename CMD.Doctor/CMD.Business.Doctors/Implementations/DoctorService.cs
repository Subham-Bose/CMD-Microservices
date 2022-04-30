using CMD.Business.Doctors.Interfaces;
using CMD.DTO.Doctor;
using CMD.Model.Doctors;
using CMD.Repository.Doctors.Implementations;
using CMD.Repository.Doctors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business.Doctors.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository repo;

        public DoctorService(DoctorRepository repo)
        {
            this.repo = repo;
        }

        public void EditDoctor(DoctorProfileDTO doctorsDTO)
        {

            Doctor doctor = new Doctor
            {
                Id = (int)doctorsDTO.id,
                Name = doctorsDTO.doctor_name,
                Speciality = doctorsDTO.doctor_speciality,
                NPINumber = doctorsDTO.doctor_npi_no,
                PracticeLocation = doctorsDTO.doctor_practice_location,
                DoctorPicture = doctorsDTO.doctor_profile_image,

                ContactDetail = new ContactDetail
                {
                    Id = doctorsDTO.ContactDetails.Id,
                    Email = doctorsDTO.ContactDetails.doctor_email_id,
                    PhoneNumber = doctorsDTO.ContactDetails.doctor_phone_number,
                }
            };

            repo.EditDoctor(doctor);
        }

        public DoctorProfileDTO GetDoctorsWithContact(int id)
        {
            var doctor = repo.GetDoctor(id);
            if (doctor == null)
            {
                return null;
            }
            DoctorProfileDTO doctorsDTO = new DoctorProfileDTO
            {
                id = doctor.Id,
                doctor_name = doctor.Name,
                doctor_speciality = doctor.Speciality,
                doctor_npi_no = doctor.NPINumber,
                doctor_practice_location = doctor.PracticeLocation,
                doctor_profile_image = doctor.DoctorPicture,
                ContactDetails = new ContactDetailDTO
                {
                    Id = doctor.ContactDetail.Id,
                    doctor_email_id = doctor.ContactDetail.Email,
                    doctor_phone_number = doctor.ContactDetail.PhoneNumber
                }
            };
            return doctorsDTO;
        }

        public void EditDoctor(DoctorDTO doctorDTO)
        {
            Doctor doctor = new Doctor();
            doctor.Id = doctorDTO.id;
            doctor.Name = doctorDTO.doctor_name;
            doctor.DoctorPicture = doctorDTO.doctor_profile_image;
            repo.EditDoctor(doctor);

        }

        public DoctorDTO GetDoctors(int id)
        {
            Doctor doctor = repo.GetDoctor(id);
            DoctorDTO doctorDTO = new DoctorDTO();
            doctorDTO.id = doctor.Id;
            doctorDTO.doctor_name = doctor.Name;
            doctorDTO.doctor_profile_image = doctor.DoctorPicture;
            return doctorDTO;

        }
        public DoctorCardDTO GetDoctorCard(int doctorId)
        {
            Doctor doctor = repo.GetDoctor(doctorId);
            DoctorCardDTO DoctorCard = new DoctorCardDTO();
            DoctorCard.Id = doctor.Id;
            DoctorCard.DoctorPicture = doctor.DoctorPicture;
            DoctorCard.Name = doctor.Name;
            DoctorCard.PhoneNumber = doctor.ContactDetail.PhoneNumber;
            DoctorCard.Mail = doctor.ContactDetail.Email;
            DoctorCard.PracticeLocation = doctor.PracticeLocation;
            DoctorCard.NPINumber = doctor.NPINumber;
            DoctorCard.SpecialityName = doctor.Speciality;
            return DoctorCard;
        }

        public ICollection<RDoctorDTO> GetAllDoctor()
        {
            var doctors = repo.GetAllDoctorToRecommend();
            ICollection<RDoctorDTO> result = new List<RDoctorDTO>();

            foreach(var doctor in doctors)
            {
                result.Add(
                    new RDoctorDTO
                    {
                        DoctorId = doctor.Id,
                        DoctorName = doctor.Name,
                    }
                );
            }
            return result;
        }
    }
}
