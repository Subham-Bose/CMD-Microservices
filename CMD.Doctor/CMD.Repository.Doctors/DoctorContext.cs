using CMD.Model.Doctors;
using System;
using System.Data.Entity;
using System.Linq;

namespace CMD.Repository.Doctors
{
    public class DoctorContext : DbContext
    {
        // Your context has been configured to use a 'DoctorContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CMD.Repository.Doctors.DoctorContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DoctorContext' 
        // connection string in the application configuration file.
        public DoctorContext()
            : base("name=DefaultConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<AvailabilitySlot> AvailabilitySlots { get; set; }
        public virtual DbSet<ContactDetail> Contacts { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}