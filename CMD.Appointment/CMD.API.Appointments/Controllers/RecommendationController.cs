using CMD.Business.Appointments.Interfaces;
using CMD.DTO.Appointments;
using System.Web.Http;
using System.Web.Http.Description;

namespace CMD.API.Appointments.Controllers
{
    public class RecommendationController : ApiController
    {
        protected IRecommendationService manager;

        public RecommendationController(IRecommendationService manager)
        {
            this.manager = manager;
        }

        [Route("recommendation")]
        [HttpPost]
        [ResponseType(typeof(RecommendationDTO))]
        public IHttpActionResult AddRecommendation(RecommendationDTO recommendation)
        {
            var reco = manager.AddRecommendtaion(recommendation);

            return Created($"api/recommendation/{reco.RecommendationId}", reco);
        }


        [Route("recommendation/{id}")]
        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            if (!manager.RemoveRecommendation(id))
                return BadRequest();
            return Ok();

        }
    }
}
