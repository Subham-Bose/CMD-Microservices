using CMD.DTO.Appointments;
using CMD.Model.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business.Appointments.Interfaces
{
    public interface ITestService
    {
        TestReport AddTest(Test test, int appointmentId);
        ICollection<Test> GetAllTests();
        ICollection<Test> GetRecommendedTests(int appointmentId);
        TestReport DeleteTest(int appointmentId, int testReportId);
        ICollection<TestReportDTO> GetTestReports();
        ICollection<TestReportDTO> ToTestReportDTOList(ICollection<TestReport> testReports);
        TestReportDTO ToTestReportDTO(TestReport testReport);
    }
}
