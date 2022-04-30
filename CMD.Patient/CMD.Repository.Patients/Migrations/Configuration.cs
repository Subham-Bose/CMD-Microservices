namespace CMD.Repository.Patients.Migrations
{
    using CMD.Model.Patients;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CMD.Repository.Patients.PatientContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CMD.Repository.Patients.PatientContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Patients.AddOrUpdate(
                p => p.Name,
                new Patient()
                {
                    Name = "Patty O'Furniture",
                    Gender = Gender.MALE,
                    DOB = new DateTime(1994, 12, 20),
                    BloodGroup = BloodGroup.BPOSITIVE,
                    Height = 182,
                    ContactDetail = new ContactDetail()
                    {
                        Email = "patty@gmail.com",
                        PhoneNumber = "9983233222"
                    }
                },
                new Patient()
                {
                    Name = "Aida Bugg",
                    Gender = Gender.FEMALE,
                    DOB = new DateTime(1994, 10, 02),
                    BloodGroup = BloodGroup.ABPOSITIVE,
                    Height = 167,
                    ContactDetail = new ContactDetail()
                    {
                        Email = "aidabugg@gmail.com",
                        PhoneNumber = "9983211122"
                    }
                },
                new Patient()
                {
                    Name = "Maureen Biologist",
                    Gender = Gender.FEMALE,
                    DOB = new DateTime(1993, 06, 10),
                    BloodGroup = BloodGroup.BPOSITIVE,
                    Height = 169,
                    ContactDetail = new ContactDetail()
                    {
                        Email = "patty@gmail.com",
                        PhoneNumber = "9887533222"
                    }
                },
                new Patient()
                {
                    Name = "Teri Dactyl",
                    Gender = Gender.MALE,
                    DOB = new DateTime(1989, 01, 05),
                    BloodGroup = BloodGroup.APOSITIVE,
                    Height = 182,
                    ContactDetail = new ContactDetail()
                    {
                        Email = "teri@gmail.com",
                        PhoneNumber = "9965633222"
                    }
                },
                new Patient()
                {
                    Name = "Peg Legge",
                    Gender = Gender.MALE,
                    DOB = new DateTime(1990, 04, 11),
                    BloodGroup = BloodGroup.BPOSITIVE,
                    Height = 185,
                    ContactDetail = new ContactDetail()
                    {
                        Email = "papeglegge@gmail.com",
                        PhoneNumber = "7783233222"
                    }
                },
                new Patient()
                {
                    Name = "Allie Grater",
                    Gender = Gender.MALE,
                    DOB = new DateTime(1994, 02, 20),
                    BloodGroup = BloodGroup.BPOSITIVE,
                    Height = 187,
                    ContactDetail = new ContactDetail()
                    {
                        Email = "allie@gmail.com",
                        PhoneNumber = "9988883222"
                    }
                }

                );
        }
    }
}
