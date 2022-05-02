using CMD.Business.Appointments.Implementations;
using CMD.CustomException.Appointments;
using CMD.DTO.Appointments;
using CMD.Model.Appointments;
using CMD.Repository.Appointments.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMD.ApppointmentController.Test
{


    
    [TestClass]
    public class AppointmentServiceUnitTest
    {   
        private Mock<IAppointmentRepository> mock;
        private AppointmentService appointmentService;

        [TestInitialize]
        public void Init()
        {
            mock = new Mock<IAppointmentRepository>();
            appointmentService = new AppointmentService();  
        }

        [TestCleanup]
        public void Clean()
        {
            mock = null;
        }

        [TestMethod]
        public void GetAllAppointment_ShouldReturnPositiveReuslt()
        {
            //Arrange

            mock.Setup((x) => x.GetAllAppointment(1)).Returns(new List<Appointment>()
                    {
                        new Appointment
                        {
                          Id= 7,
                          AppointmentDate= new DateTime(),
                          AppointmentTime= TimeSpan.Parse("11:00"),
                          PatientId= 2,
                          DoctorId = 1,
                          PatientName= "P3",
                          Issue = "Test3",
                          DoctorName= "D2",
                          Reason= "Test3",
                          Status= AppointmentStatus.OPEN
                        },
                        new Appointment
                        {
                          Id= 7,
                          AppointmentDate= new DateTime(),
                          AppointmentTime= TimeSpan.Parse("11:00"),
                          PatientId= 2,
                          DoctorId = 1,
                          PatientName= "P3",
                          Issue = "Test3",
                          DoctorName= "D2",
                          Reason= "Test3",
                          Status= AppointmentStatus.CLOSED
                        },
                        new Appointment
                        {
                          Id= 7,
                          AppointmentDate= new DateTime(),
                          AppointmentTime= TimeSpan.Parse("11:00"),
                          PatientId= 2,
                          DoctorId = 1,
                          PatientName= "P3",
                          Issue = "Test3",
                          DoctorName= "D2",
                          Reason= "Test3",
                          Status= AppointmentStatus.CANCELLED
                        },
                        new Appointment
                        {
                          Id= 7,
                          AppointmentDate= new DateTime(),
                          AppointmentTime= TimeSpan.Parse("11:00"),
                          PatientId= 2,
                          DoctorId = 1,
                          PatientName= "P3",
                          Issue = "Test3",
                          DoctorName= "D2",
                          Reason= "Test3",
                          Status= AppointmentStatus.CLOSED
                        },
                        new Appointment
                        {
                          Id= 7,
                          AppointmentDate= new DateTime(),
                          AppointmentTime= TimeSpan.Parse("11:00"),
                          PatientId= 2,
                          DoctorId = 1,
                          PatientName= "P3",
                          Issue = "Test3",
                          DoctorName= "D2",
                          Reason= "Test3",
                          Status= AppointmentStatus.CONFIRMED

                        },
                        new Appointment
                        {
                          Id= 7,
                          AppointmentDate= new DateTime(),
                          AppointmentTime= TimeSpan.Parse("11:00"),
                          PatientId= 2,
                          DoctorId = 1,
                          PatientName= "P3",
                          Issue = "Test3",
                          DoctorName= "D2",
                          Reason= "Test3",
                          Status= AppointmentStatus.CONFIRMED
                        }

                    });



            //Act

            Action act = () =>
             {
                 var appointmentService = new AppointmentService();
                 var result = appointmentService.GetAllAppointment(1, new PaginationParams() { ItemsPerPage = 2, Page = 1 });
                 Assert.IsTrue(result.Count == 2);
                 Assert.IsInstanceOfType(result, typeof(ICollection<AppointmentBasicInfoDTO>));
             };

            //Assert
        }

        [TestMethod]
        public void GetAllAppointment_ShouldReturnNull()
        {
            mock.Setup(m => m.GetAllAppointment(1)).Returns(new List<Appointment>());
            Action act = () =>
            {
                var appointmentService = new AppointmentService();
                var result = appointmentService.GetAllAppointment(1, new PaginationParams() { ItemsPerPage = 2, Page = 1 });
                Assert.IsNull(result);
            };
        }

        [TestMethod]
        public void ChangeAppointmentStatus_ShouldChangeStatusToConfirmed()
        {
            var appointment = new Appointment()
            {
                Id = 7,
                AppointmentDate = new DateTime(),
                AppointmentTime = TimeSpan.Parse("11:00"),
                PatientId = 2,
                DoctorId = 1,
                PatientName = "P3",
                Issue = "Test3",
                DoctorName = "D2",
                Reason = "Test3",
                Status = AppointmentStatus.OPEN
            };
            mock.Setup(m => m.AcceptApppointment(1)).Returns(() => {
                appointment.Status = AppointmentStatus.CONFIRMED;
                return true;
                });
            Action act = () =>
            {
                var appointmentService = new AppointmentService();
                var result = appointmentService.ChangeAppointmentStatus(new AppointmentStatusDTO
                {
                    AppointmentId = 7,
                    Status = "Confirmed"
                }, 1);

                Assert.IsTrue(result);
                Assert.AreEqual(appointment.Status, AppointmentStatus.CONFIRMED);
            };
        }

        [TestMethod]
        public void ChangeAppointmentStatus_ShouldChangeStatusToCancelled()
        {
            var appointment = new Appointment()
            {
                Id = 7,
                AppointmentDate = new DateTime(),
                AppointmentTime = TimeSpan.Parse("11:00"),
                PatientId = 2,
                DoctorId = 1,
                PatientName = "P3",
                Issue = "Test3",
                DoctorName = "D2",
                Reason = "Test3",
                Status = AppointmentStatus.CLOSED
            };
            mock.Setup(m => m.AcceptApppointment(1)).Returns(() => {
                var flag = false;
                if(appointment.Status == AppointmentStatus.OPEN)
                {
                    appointment.Status = AppointmentStatus.CLOSED;
                    flag = true;
                }
                return flag;
            });
            Action act = () =>
            {
                var appointmentService = new AppointmentService();
                var result = appointmentService.ChangeAppointmentStatus(new AppointmentStatusDTO
                {
                    AppointmentId = 7,
                    Status = "Cancelled"
                }, 1);

                // Assert.IsTrue(result);
                Assert.IsTrue(result);  
            };
        }

        [TestMethod]
        public void CreateAppointment_ShouldCreateFormWithValidId()
        {
            // Arrange

            AppointmentFormDTO appointment = new AppointmentFormDTO()
            {
                AppointmentDate = DateTime.Now,
                AppointmentTime = TimeSpan.Parse("11:12"),
                DoctorId = 1,
                DoctorName = "D1",
                PatientId = 2,
                PatientName = "P1",
                Issue = "Test",
                Reason = "Test",
            };
            var result = appointmentService.CreateAppointment(appointment);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ConfirmedAppointmentDTO));
            Assert.AreEqual(AppointmentStatus.OPEN.ToString(), result.Status); 
            Assert.IsTrue(result.AppointmentId > 0);
        }


        [TestMethod]
        [ExpectedException(typeof(AppointmentDatetimeException))]
        public void AddAppointment_Should_Throw_AppointmentDateTimeException()
        {
            var appointment = new AppointmentFormDTO
            {
                AppointmentDate = new DateTime(day: 24, month: 08, year: 2003),
                AppointmentTime = TimeSpan.Parse("11:00"),
                Issue = "Leg Injury",
                Reason = "Paitent met with accident",
                PatientId = 1,
                DoctorId = 2,
                PatientName = "p1",
                DoctorName = "D1",
            };
            _ = appointmentService.CreateAppointment(appointment);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddAppointment_Should_Throw_Exception()
        {
            var appointment = new AppointmentFormDTO
            {
                AppointmentDate = new DateTime(day: 24, month: 08, year: 2023),
                Issue = "Leg Injury",
                Reason = "Paitent met with accident",
                PatientId = 1,
                DoctorId = 2,
                PatientName = "p1",
                DoctorName = "D1",
            };
            _ = appointmentService.CreateAppointment(appointment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AddAppointment_Should_Throw_NullReferenceException()
        {
            var appointment = new AppointmentFormDTO
            {
                AppointmentDate = new DateTime(day: 24, month: 08, year: 2023),
                AppointmentTime = TimeSpan.Parse("11:00"),
                Issue = "Leg Injury",
                Reason = "Paitent met with accident",
                DoctorId = 2,
                DoctorName = "D1",
            };
            _ = appointmentService.CreateAppointment(appointment);
        }

        [TestMethod]
        public void GetFormByDoctorId_ShouldReturnCollectionOfAppointmentBasicDTO()
        {
            var result = appointmentService.GetAllAppointment(2, new PaginationParams() { ItemsPerPage=2, Page=1});
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ICollection<AppointmentBasicInfoDTO>));
        }

        [TestMethod]
        public void GetFormByDoctorId_ShouldReturnCollectionOfAppointmentBasicDTOFilteredByStatus()
        {
            var result = appointmentService.GetAllAppointmentFiltered(2,"open", new PaginationParams() { ItemsPerPage = 2, Page = 1 });
            var firstResult = result.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ICollection<AppointmentBasicInfoDTO>));
            Assert.IsTrue(firstResult.AppointmentStatus.Equals("OPEN"));
        }
    }
}
