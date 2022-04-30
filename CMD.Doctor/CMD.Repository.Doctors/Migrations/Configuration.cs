namespace CMD.Repository.Doctors.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CMD.Repository.Doctors.DoctorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CMD.Repository.Doctors.DoctorContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Doctors.AddOrUpdate
                (
                x => x.Name,
                new Model.Doctors.Doctor()
                {
                    Name = "Emerson Earwood",
                    NPINumber = "79823SDA22",
                    PracticeLocation = "Bangalore",
                    Speciality = "Neurosurgeon",
                    ContactDetail = new Model.Doctors.ContactDetail
                    {
                        Email = "emerson@gmail.com",
                        PhoneNumber = "9985121325"
                    }
                },
                new Model.Doctors.Doctor()
                {
                    Name = "Josue Weyker",
                    NPINumber = "989121MMA22",
                    PracticeLocation = "Delhi",
                    Speciality = "Physician",
                    ContactDetail = new Model.Doctors.ContactDetail
                    {
                        Email = "josue@gmail.com",
                        PhoneNumber = "8893565464"
                    }
                },
                new Model.Doctors.Doctor()
                {
                    Name = "Mitchell Whitledge",
                    NPINumber = "556421AAQ78",
                    PracticeLocation = "Mumbai",
                    Speciality = "Cardiologist",
                    ContactDetail = new Model.Doctors.ContactDetail
                    {
                        Email = "mitchell@gmail.com",
                        PhoneNumber = "8645022354"
                    }
                },
                new Model.Doctors.Doctor()
                {
                    Name = "Johnny Soltes",
                    NPINumber = "983233QQP99",
                    PracticeLocation = "Kolkata",
                    Speciality = "Rheumatologist",
                    ContactDetail = new Model.Doctors.ContactDetail
                    {
                        Email = "johnny@gmail.com",
                        PhoneNumber = "7758944569"
                    }
                },
                new Model.Doctors.Doctor()
                {
                    Name = "Evelyn Goodknight",
                    NPINumber = "65321BBA32",
                    PracticeLocation = "Chennai",
                    Speciality = "Orthopedics",
                    ContactDetail = new Model.Doctors.ContactDetail
                    {
                        Email = "evelyn@gmail.com",
                        PhoneNumber = "8875212225"
                    }
                }
                );
        }
    }
}

/*
 public string Name { get; set; }
        public string DoctorPicture { get; set; }
        public string NPINumber { get; set; }
        public string PracticeLocation { get; set; }
        public string Speciality { get; set; }
        public ContactDetail ContactDetail { get; set; }


Dr. Emerson Earwood
Dr. Evelyn Goodknight
Dr. Johnny Soltes
Dr. Josue Weyker
Dr. Mitchell Whitledge
*/
