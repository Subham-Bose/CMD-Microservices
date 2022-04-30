using CMD.Model.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Repository.Appointments.Interfaces
{
    public interface IAppointmentRepository
    {
        Appointment CreateAppointment (Appointment appointment);
        Appointment GetAppointment (int appointmentId);
        ICollection<Appointment> GetAllAppointment (int doctorId);
        ICollection<Appointment> GetAllAppointmentFilterWithStatus(int doctorId, AppointmentStatus status);
        int TotalAppointmentCount(int doctorId);
        int TotalAppointmentCountBasedOnStatus(int doctorId, AppointmentStatus status);
        bool AcceptApppointment(int appointmentId);
        bool RejectApppointment(int appointmentId);
        string GetComment(int appointmentId);
        bool EditComment(int appointmentId, string comment);
        IQueryable<AppointmentStatus> GetAppointmentSummary(int doctorId);
        int AppointmentCount(int doctorId);
        int AppointmentCount(int doctorId, string status);
    }
}
