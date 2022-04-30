using CMD.Business.Doctors.Interfaces;
using CMD.DTO.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CMD.API.Doctors.Controllers
{
    [RoutePrefix("api/doctors")]
    public class DoctorController : ApiController
    {
        protected IDoctorService manager;

        public DoctorController(IDoctorService manager)
        {
            this.manager = manager;
        }


        /// <summary>
        /// Fetches doctor profile details using DoctorService and send a response to the client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        [HttpGet]
        [Route("doctorprofile/{id}")]
        [ResponseType(typeof(DoctorProfileDTO))]
        public IHttpActionResult Get(int id)
        {

            DoctorProfileDTO doctor = manager.GetDoctorsWithContact(id);
            if (doctor == null)
            {
                var msg = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Your search ID is not found {0}", id)),
                    ReasonPhrase = "Doctor not found"
                };
                throw new HttpResponseException(msg);
            }
            return Ok(doctor);
        }



        // POST: api/Doctor
        [HttpPut]
        [Route("doctorprofile")]
        [ResponseType(typeof(DoctorProfileDTO))]
        public IHttpActionResult Put(DoctorProfileDTO doctor)
        {
            if (doctor == null)
            {
                var msg = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Your search ID is not found {0}", doctor)),
                    ReasonPhrase = "Doctor not found"
                };
                throw new HttpResponseException(msg);



            }
            manager.EditDoctor(doctor);
            return Ok(doctor);
        }

        [HttpGet]
        [Route("doctor/profile/{id}")]
        [ResponseType(typeof(DoctorDTO))]
        public IHttpActionResult GetDoctorProfilePicture(int id)
        {
            DoctorDTO doctor = manager.GetDoctors(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpPut]
        [Route("doctor/profile")]
        public void Put(DoctorDTO doctorDTO)
        {
            manager.EditDoctor(doctorDTO);
            return;
        }

        [HttpGet]
        [Route("doctorcard/{doctorId}")]
        [ResponseType(typeof(DoctorCardDTO))]
        public IHttpActionResult GetDoctorCard(int doctorId)
        {
            DoctorCardDTO cardDetails = manager.GetDoctorCard(doctorId);
            return Ok(cardDetails);
        }
    }
}
