using CMD.Model.Patients;
using System;
using System.Data.Entity;
using System.Linq;

namespace CMD.Repository.Patients
{
    public class PatientContext : DbContext
    {
        // Your context has been configured to use a 'PatientContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CMD.Repository.Patients.PatientContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PatientContext' 
        // connection string in the application configuration file.
        public PatientContext()
            : base("name=DefaultConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}