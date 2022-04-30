using CMD.Model.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Repository.Appointments.Interfaces
{
    public interface IRecommendationRepository
    {
        Recommendation AddRecommendtaion(Recommendation reco);
        bool RemoveRecommendation(int id);
    }
}
