using CMD.API.Patients.Controllers;
using CMD.Business.Patients.Implementations;
using CMD.Business.Patients.Interfaces;
using CMD.DTO.Patients;
using CMD.Repository.Patients.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace CMD.UnitTest.Patients
{
    [TestClass]
    public class PatientServiceUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<IPatientRepository>();
            mock.Setup(p => p.GetPatient(It.IsAny<int>()))
                .Returns(new Model.Patients.Patient
                {
                    Id = 1,
                    Name = "Subham Bose",
                    PatientPicture = null,
                    Gender = Model.Patients.Gender.MALE,
                    DOB = new DateTime(18 / 05 / 1993),
                    BloodGroup = Model.Patients.BloodGroup.BPOSITIVE,
                    Height =    179,
                    ContactDetail = null,
                }) ;
            Action act = () =>
            {
                var patientservice = new PatientService(mock.Object);
                Assert.IsNotNull(patientservice.GetPatient(1));
            };
        }

        [TestMethod]
        public void TestMethod2()
        {

            var mock = new Mock<IPatientService>();
            mock.Setup(p => p.GetAllPatient())
                .Returns(() =>
                {
                    var list = new List<PatientDTO>();
                    list.Add(new PatientDTO());
                    return list;
                });
            Action act = () =>
            {
                var patientController = new PatientController(mock.Object);
                var allPatients = patientController.GetAllPatients();
                Assert.IsNotNull(allPatients);
            };
        }
    }
}
