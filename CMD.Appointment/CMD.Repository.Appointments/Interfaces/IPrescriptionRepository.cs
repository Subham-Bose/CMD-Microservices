using CMD.Model.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Repository.Appointments.Interfaces
{
    public interface IPrescriptionRepository
    {
        bool DeletePrescription(int appointmentId, int PrescriptionId);
        ICollection<Prescription> GetPrescriptions(int appointmentId);
        Prescription AddPrescription(int appointmentId, Prescription prescriptionId);
        Medicine GetMedicine(string name);
        ICollection<Medicine> GetAllMedicine();
        Prescription UpdatePrescription(Prescription prescription);
    }
}
