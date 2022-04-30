using CMD.Business.Patients.Interfaces;
using CMD.DTO.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CMD.API.Patients.Controllers
{
    
    public class PatientController : ApiController
    {
        protected readonly IPatientService service;

        public PatientController(IPatientService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("api/patients/patient/{patientId}")]
        [ResponseType(typeof(PatientCardDTO))]
        public IHttpActionResult GetPatient(int patientId)
        {
            var patient = service.GetPatient(patientId);

            if(patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpGet]
        [Route("api/patients/allpatients")]
        [ResponseType(typeof(ICollection<PatientDTO>))]
        public IHttpActionResult GetAllPatients()
        {
            var patients = service.GetAllPatient();
            if(patients.Count == 0)
            {
                return NotFound();
            }
            return Ok(patients);
        }
    }
}
