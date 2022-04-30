using CMD.Business.Appointments.Interfaces;
using CMD.DTO.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CMD.API.Appointments.Controllers
{
    public class AppointmentController : ApiController
    {
        protected IAppointmentService manager;

        public AppointmentController(IAppointmentService manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Creates an appointment
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns>IHttpActionResult</returns>
        [HttpPost]
        [Route("api/appointment/create")]
        [ResponseType(typeof(ConfirmedAppointmentDTO))]
        public IHttpActionResult AddAppointment(AppointmentFormDTO jsonData)
        {
            AppointmentFormDTO appointmentForm = jsonData;
            
            var result = manager.CreateAppointment(appointmentForm);
            
            return Created($"api/appointment/{result.AppointmentId}", result);
        }

        [HttpPut]
        [Route("api/appointment/changestatus/doctorId/{doctorId}")]
        public IHttpActionResult ChangeStatus([FromBody] AppointmentStatusDTO appDTO, int doctorId)
        {
            var result = manager.ChangeAppointmentStatus(appDTO, doctorId);
            var response = Request.CreateResponse(result ? HttpStatusCode.NoContent : HttpStatusCode.PreconditionFailed);
            return ResponseMessage(response);
        }

        [HttpGet]
        [Route("api/appointment/allappointments/{doctorId}")]
        [ResponseType(typeof(AppointmentBasicInfoDTO))]
        public IHttpActionResult GetAllAppointment(int doctorId, [FromUri] PaginationParams parameters)
        {
            ICollection<AppointmentBasicInfoDTO> appointments = manager.GetAllAppointment(doctorId, parameters);

            if (appointments.Count() == 0)
            {
                return Ok("No appointment");
            }

            var totalAppointmentCount = manager.GetAppointmentCount(doctorId);

            var paginationMetaData = new PaginationMetaData(totalAppointmentCount, parameters.Page, parameters.ItemsPerPage, appointments);

            var response = Request.CreateResponse(HttpStatusCode.OK, paginationMetaData);
            return ResponseMessage(response);
        }

        [HttpGet]
        [Route("api/appointment/allappointments/{status}/{doctorId}")]
        [ResponseType(typeof(AppointmentBasicInfoDTO))]
        public IHttpActionResult GetAllAppointmentBasedOnStatus(int doctorId, string status, [FromUri] PaginationParams parameters)
        {
            ICollection<AppointmentBasicInfoDTO> appointments = manager.GetAllAppointmentFiltered(doctorId, status, parameters);

            if (appointments.Count() == 0)
            {
                return Ok("No appointment");
            }

            var totalAppointmentCount = manager.GetAppointmentCountBasedOnStatus(doctorId, status);

            var paginationMetaData = new PaginationMetaData(totalAppointmentCount, parameters.Page, parameters.ItemsPerPage, appointments);

            var response = Request.CreateResponse(HttpStatusCode.OK, paginationMetaData);
            return ResponseMessage(response);
        }

        [HttpGet]
        [Route("api/appointment/getids/{appointmentId}")]
        [ResponseType(typeof(IdsListViewDetailsDTO))]
        public IHttpActionResult GetIdsAssociatedWithAppointment(int appointmentId)
        {
            return Ok(manager.GetIdsAssociatedWithAppointment(appointmentId));
        }

        [HttpGet]
        [Route("api/comment/{appointmentId}")]
        [ResponseType(typeof(AppointmentCommentDTO))]
        public IHttpActionResult GetComment(int appointmentId)
        {
            var a = manager.GetAppointmentComment(appointmentId);
            return Ok(a);
        }


        // PUT: api/appointment/comment/{appointmentId}
        [HttpPut]
        [Route("api/comment/{appointmentId}")]
        [ResponseType(typeof(AppointmentCommentDTO))]
        public IHttpActionResult EditComment(int appointmentId, AppointmentCommentDTO comment)
        {
            var a = manager.UpdateAppointmentComment(appointmentId, comment);
            if (!a)
            {
                return BadRequest();
            }
            return Ok(comment);
        }
    }
}
