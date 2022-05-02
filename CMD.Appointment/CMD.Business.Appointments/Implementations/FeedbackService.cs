using CMD.Business.Appointments.Interfaces;
using CMD.Model.Appointments;
using CMD.Repository.Appointments.Implementations;
using CMD.Repository.Appointments.Interfaces;

namespace CMD.Business.Appointments.Implementations
{
    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository repo;

        public FeedbackService()
        {
            repo = new FeedbackRepository();
        }

        public FeedBack GetFeedback(int id)
        {
            var result = repo.GetFeedback(id);
            return result;
        }
    }
}
