using CMD.Model.Appointments;
using CMD.Repository.Appointments.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CMD.Repository.Appointments.Implementations
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly CMDContext db;
        public PrescriptionRepository()
        {
            this.db = new CMDContext();
        }

        public bool DeletePrescription(int appointmentId, int PrescriptionId)
        {
            Appointment appointment = db.Appointments.Include("Prescriptions").Where(p => p.Id == appointmentId).FirstOrDefault();
            Prescription pres = null;
            foreach (Prescription p in appointment.Prescriptions)
            {
                if (p.Id == PrescriptionId)
                {
                    pres = p;
                    break;
                }
            }
            if (pres != null)
            {
                appointment.Prescriptions.Remove(pres);
                db.Prescriptions.Remove(pres);
                db.Appointments.Append(appointment);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public ICollection<Prescription> GetPrescriptions(int appointmentId)
        {
            var prescriptions = db.Appointments.Where(a => a.Id == appointmentId).SelectMany(a => a.Prescriptions).Include(p => p.Medicine).ToList();

            return prescriptions;
        }


        //Add and Update Prescription

        public Prescription AddPrescription(int appointmentId, Prescription prescriptionId)
        {
            var p = db.Appointments.Find(appointmentId);

            p.Prescriptions.Add(prescriptionId);

            db.SaveChanges();
            return prescriptionId;
        }

        public Medicine GetMedicine(string name)
        {
            var result = db.Medicines.Where(m => m.Name == name).FirstOrDefault();
            return result;
        }

        public ICollection<Medicine> GetAllMedicine()
        {
            return db.Medicines.ToList();
        }

        public Prescription UpdatePrescription(Prescription prescription)
        {
            db.Entry(prescription).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return prescription;
        }
    }
}
