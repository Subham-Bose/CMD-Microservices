using CMD.Model.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Repository.Appointments.Interfaces
{
    public interface ITestRepository
    {
        TestReport AddTest(Test test, int appointmentId);
        TestReport DeleteTest(int appointmnetId, int testReportId);
        ICollection<Test> GetAllTests();
        ICollection<TestReport> GetRecommendedTests(int appointmentId);
        ICollection<TestReport> GetTestReports();
    }
}
