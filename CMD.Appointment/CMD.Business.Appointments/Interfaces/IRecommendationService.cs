using CMD.DTO.Appointments;
using CMD.Model.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business.Appointments.Interfaces
{
    public interface IRecommendationService
    {
        bool RemoveRecommendation(int id);
        RecommendationDTO AddRecommendtaion(RecommendationDTO reco);
    }
}
