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
using System.Text;

namespace CMD.ApppointmentController.Test
{
    /// <summary>
    /// Summary description for AppointmentServiceUnitTests
    /// </summary>
    [TestClass]
    public class AppointmentServiceUnitTests
    {
        private Mock<IAppointmentRepository> repoMock;

        [TestInitialize]
        public void Init()
        {
            repoMock = new Mock<IAppointmentRepository>();
        }
        [TestCleanup]
        public void Clean()
        {
            if(repoMock.Object != null)
                repoMock = null;
        }


        [TestMethod]
        [ExpectedException(typeof(AppointmentDatetimeException))]
        public void CreateAppointment_ShouldThrowAppointmentDateTimeException_OldDate()
        {
            //Arrange
            var appointment = new Appointment()
            {
                AppointmentDate = new DateTime(11/11/11),
                AppointmentTime = TimeSpan.Parse("11:00"),
                DoctorId = 1,
                DoctorName = "TestDoctor",
                PatientId = 1,
                PatientName = "TestPatient",
                Issue = "TestIssue",
                Reason = "TestReason"
            };

            var appointmentForm = new AppointmentFormDTO()
            {
                AppointmentDate = new DateTime(11 / 11 / 11),
                AppointmentTime = TimeSpan.Parse("11:00"),
                DoctorId = 1,
                DoctorName = "TestDoctor",
                PatientId = 1,
                PatientName = "TestPatient",
                Issue = "TestIssue",
                Reason = "TestReason"
            };

            repoMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(x => new Appointment()
                {
                    AppointmentDate = new DateTime(11 / 11 / 11),
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    DoctorId = 1,
                    DoctorName = "TestDoctor",
                    PatientId = 1,
                    PatientName = "TestPatient",
                    Issue = "TestIssue",
                    Reason = "TestReason"
                });
            var appointmentService = new AppointmentService(repoMock.Object);

            var confirmedAppointment = appointmentService.CreateAppointment(appointmentForm);

        }

        [TestMethod]
        [ExpectedException(typeof(AppointmentDatetimeException))]
        public void CreateAppointment_ShouldThrowAppointmentDateTimeException_CurrentDateButBackTime()
        {
            //Arrange
            var appointmentForm = new AppointmentFormDTO()
            {
                AppointmentDate = DateTime.Now.Date,
                AppointmentTime = TimeSpan.Parse("01:00"),
                DoctorId = 1,
                DoctorName = "TestDoctor",
                PatientId = 1,
                PatientName = "TestPatient",
                Issue = "TestIssue",
                Reason = "TestReason"
            };

            repoMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(m => new Appointment()
                {
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    DoctorId = 1,
                    DoctorName = "TestDoctor",
                    PatientId = 1,
                    PatientName = "TestPatient",
                    Issue = "TestIssue",
                    Reason = "TestReason",
                    Status = AppointmentStatus.OPEN
                });
            var appointmentService = new AppointmentService(repoMock.Object);

            var confirmedAppointment = appointmentService.CreateAppointment(appointmentForm);

        }

        [TestMethod]
        [ExpectedException(typeof(MissingDetailException))]
        public void CreateAppointment_ShouldThrowMissingDetailException_NoPatientName()
        {
            //Arrange
           
            var appointmentForm = new AppointmentFormDTO()
            {
                AppointmentDate = DateTime.Now,
                AppointmentTime = TimeSpan.Parse("11:00:00"),
                DoctorId = 1,
                DoctorName = "TestDoctor",
                PatientId = 1,
                PatientName = "",
                Issue = "TestIssue",
                Reason = "TestReason"
            };

            repoMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(m => new Appointment()
                {
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    DoctorId = 1,
                    DoctorName = "TestDoctor",
                    PatientId = 1,
                    PatientName = "TestPatient",
                    Issue = "TestIssue",
                    Reason = "TestReason",
                    Status = AppointmentStatus.OPEN
                });
            var appointmentService = new AppointmentService(repoMock.Object);

            var confirmedAppointment = appointmentService.CreateAppointment(appointmentForm);

        }

        [TestMethod]
        [ExpectedException(typeof(MissingDetailException))]
        public void CreateAppointment_ShouldThrowMissingDetailException_NoDoctorName()
        {
            //Arrange

            var appointmentForm = new AppointmentFormDTO()
            {
                AppointmentDate = DateTime.Now,
                AppointmentTime = TimeSpan.Parse("11:00:00"),
                DoctorId = 1,
                DoctorName = "",
                PatientId = 1,
                PatientName = "TestPatient",
                Issue = "TestIssue",
                Reason = "TestReason"
            };

            repoMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(m => new Appointment()
                {
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    DoctorId = 1,
                    DoctorName = "TestDoctor",
                    PatientId = 1,
                    PatientName = "TestPatient",
                    Issue = "TestIssue",
                    Reason = "TestReason",
                    Status = AppointmentStatus.OPEN
                });
            var appointmentService = new AppointmentService(repoMock.Object);

            var confirmedAppointment = appointmentService.CreateAppointment(appointmentForm);

        }

        [TestMethod]
        [ExpectedException(typeof(MissingDetailException))]
        public void CreateAppointment_ShouldThrowMissingDetailException_NoIssue()
        {
            //Arrange

            var appointmentForm = new AppointmentFormDTO()
            {
                AppointmentDate = DateTime.Now,
                AppointmentTime = TimeSpan.Parse("11:00:00"),
                DoctorId = 1,
                DoctorName = "TestDoctor",
                PatientId = 1,
                PatientName = "TestPatient",
                Issue = "",
                Reason = "TestReason"
            };

            repoMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(m => new Appointment()
                {
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    DoctorId = 1,
                    DoctorName = "TestDoctor",
                    PatientId = 1,
                    PatientName = "TestPatient",
                    Issue = "TestIssue",
                    Reason = "TestReason",
                    Status = AppointmentStatus.OPEN
                });
            var appointmentService = new AppointmentService(repoMock.Object);

            var confirmedAppointment = appointmentService.CreateAppointment(appointmentForm);

        }

        [TestMethod]
        [ExpectedException(typeof(MissingDetailException))]
        public void CreateAppointment_ShouldThrowMissingDetailException_NoDoctorId()
        {
            //Arrange

            var appointmentForm = new AppointmentFormDTO()
            {
                AppointmentDate = DateTime.Now,
                AppointmentTime = TimeSpan.Parse("11:00:00"),
                DoctorId = 0,
                DoctorName = "TestDoctor",
                PatientId = 1,
                PatientName = "TestPatient",
                Issue = "TestIssue",
                Reason = "TestReason"
            };

            repoMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(m => new Appointment()
                {
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    DoctorId = 1,
                    DoctorName = "TestDoctor",
                    PatientId = 1,
                    PatientName = "TestPatient",
                    Issue = "TestIssue",
                    Reason = "TestReason",
                    Status = AppointmentStatus.OPEN
                });
            var appointmentService = new AppointmentService(repoMock.Object);

            var confirmedAppointment = appointmentService.CreateAppointment(appointmentForm);

        }

        [TestMethod]
        [ExpectedException(typeof(MissingDetailException))]
        public void CreateAppointment_ShouldThrowMissingDetailException_NoPatientId()
        {
            //Arrange

            var appointmentForm = new AppointmentFormDTO()
            {
                AppointmentDate = DateTime.Now,
                AppointmentTime = TimeSpan.Parse("11:00:00"),
                DoctorId = 1,
                DoctorName = "TestDoctor",
                PatientId = 0,
                PatientName = "TestPatient",
                Issue = "TestIssue",
                Reason = "TestReason"
            };

            repoMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(m => new Appointment()
                {
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    DoctorId = 1,
                    DoctorName = "TestDoctor",
                    PatientId = 1,
                    PatientName = "TestPatient",
                    Issue = "TestIssue",
                    Reason = "TestReason",
                    Status = AppointmentStatus.OPEN
                });
            var appointmentService = new AppointmentService(repoMock.Object);

            var confirmedAppointment = appointmentService.CreateAppointment(appointmentForm);

        }

        [TestMethod]
        public void CreateAppointment_ShouldReturnConfirmedAppointmentDTO()
        {
            repoMock.Setup(m => m.CreateAppointment(It.IsAny<Appointment>()))
                .Returns<Appointment>(m => new Appointment()
                {
                    AppointmentDate = new DateTime(2022, 06, 23),
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    DoctorId = 1,
                    DoctorName = "TestDoctor",
                    PatientId = 1,
                    PatientName = "TestPatient",
                    Issue = "TestIssue",
                    Reason = "TestReason",
                    Status = AppointmentStatus.OPEN
                }
                );
            var appointmentService = new AppointmentService(repoMock.Object);

            var expected = appointmentService.CreateAppointment(new AppointmentFormDTO()
            {
                AppointmentDate = new DateTime(2022, 06, 23),
                AppointmentTime = TimeSpan.Parse("11:00"),
                DoctorId = 1,
                DoctorName = "TestDoctor",
                PatientId = 1,
                PatientName = "TestPatient",
                Issue = "TestIssue",
                Reason = "TestReason",
            });

            Assert.IsInstanceOfType(expected, typeof(ConfirmedAppointmentDTO));
        }
        
        private ICollection<Appointment> GetDummy()
        {
            ICollection<Appointment>appointments =  new List<Appointment>()
            {
                new Appointment()
                {
                    Id = 1,
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    Status = AppointmentStatus.OPEN,
                    PatientName = "TestName",
                    Issue = "TestIssue"
                },
                new Appointment()
                {
                    Id = 1,
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    Status = AppointmentStatus.CLOSED,
                    PatientName = "TestName",
                    Issue = "TestIssue"
                },
                new Appointment()
                {
                    Id = 1,
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    Status = AppointmentStatus.OPEN,
                    PatientName = "TestName",
                    Issue = "TestIssue"
                },
                new Appointment()
                {
                    Id = 1,
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    Status = AppointmentStatus.CONFIRMED,
                    PatientName = "TestName",
                    Issue = "TestIssue"
                },
                new Appointment()
                {
                    Id = 1,
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    Status = AppointmentStatus.CONFIRMED,
                    PatientName = "TestName",
                    Issue = "TestIssue"
                },
                new Appointment()
                {
                    Id = 1,
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    Status = AppointmentStatus.CANCELLED,
                    PatientName = "TestName",
                    Issue = "TestIssue"
                },
                new Appointment()
                {
                    Id = 1,
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    Status = AppointmentStatus.CANCELLED,
                    PatientName = "TestName",
                    Issue = "TestIssue"
                },
                new Appointment()
                {
                    Id = 1,
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.Parse("11:00"),
                    Status = AppointmentStatus.OPEN,
                    PatientName = "TestName",
                    Issue = "TestIssue"
                }
            };

            return appointments;
        }

        [TestMethod]
        public void GetAllAppointments_ItemCountShouldBeEqualToCountAsked()
        {
            repoMock.Setup(m => m.GetAllAppointment(1))
                .Returns(GetDummy());
            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.GetAllAppointment(1, new PaginationParams() { ItemsPerPage = 2, Page = 1 });

            Assert.AreEqual(expected.Count, 2);
        }

        [TestMethod]
        public void GetAllAppointments_ReturnsNull()
        {
            repoMock.Setup(m => m.GetAllAppointment(1))
                .Returns(new List<Appointment>());
            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.GetAllAppointment(1, new PaginationParams() { ItemsPerPage = 2, Page = 1 });

            Assert.IsNull(expected);
        }

        [TestMethod]
        public void GetAllAppointments_ReturnedObjectShouldBeCollectionOfAppointmentBasicInfoDTO()
        {
            repoMock.Setup(m => m.GetAllAppointment(1))
                .Returns(GetDummy());
            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.GetAllAppointment(1, new PaginationParams() { ItemsPerPage = 2, Page = 1 });

            Assert.IsInstanceOfType(expected, typeof(ICollection<AppointmentBasicInfoDTO>));
        }

        [TestMethod]
        public void GetAllAppointmentFiltered_AppointmentStatusInExpectedShouldBeOPEN()
        {
            repoMock.Setup(m => m.GetAllAppointmentFilterWithStatus(1, AppointmentStatus.OPEN))
                .Returns(GetDummy().Where(x => x.Status == AppointmentStatus.OPEN).ToList());
            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.GetAllAppointmentFiltered(1,AppointmentStatus.OPEN.ToString(), new PaginationParams() { ItemsPerPage = 2, Page = 1 });

            Assert.AreEqual(expected.Count, 2);
            Assert.AreEqual(expected.ToList()[1].AppointmentStatus, "OPEN");
        }

        [TestMethod]
        public void GetAllAppointmentFiltered_AppointmentStatusInExpectedShouldBeCONFIRMED()
        {
            repoMock.Setup(m => m.GetAllAppointmentFilterWithStatus(1, AppointmentStatus.CONFIRMED))
                .Returns(GetDummy().Where(x => x.Status == AppointmentStatus.CONFIRMED).ToList());
            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.GetAllAppointmentFiltered(1, AppointmentStatus.CONFIRMED.ToString(), new PaginationParams() { ItemsPerPage = 2, Page = 1 });

            Assert.AreEqual(expected.Count, 2);
            Assert.AreEqual(expected.ToList()[1].AppointmentStatus, "CONFIRMED");
        }

        [TestMethod]
        public void GetAllAppointmentFiltered_AppointmentStatusInExpectedShouldBeCLOSED()
        {
            repoMock.Setup(m => m.GetAllAppointmentFilterWithStatus(1, AppointmentStatus.CLOSED))
                .Returns(GetDummy().Where(x => x.Status == AppointmentStatus.CLOSED).ToList());
            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.GetAllAppointmentFiltered(1, AppointmentStatus.CLOSED.ToString(), new PaginationParams() { ItemsPerPage = 2, Page = 1 });

            Assert.AreEqual(expected.Count, 1);
            Assert.AreEqual(expected.ToList()[0].AppointmentStatus, "CLOSED");
        }

        [TestMethod]
        public void GetAllAppointmentFiltered_AppointmentStatusInExpectedShouldBeCANCELLED()
        {
            repoMock.Setup(m => m.GetAllAppointmentFilterWithStatus(1, AppointmentStatus.CANCELLED))
                .Returns(GetDummy().Where(x => x.Status == AppointmentStatus.CANCELLED).ToList());
            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.GetAllAppointmentFiltered(1, AppointmentStatus.CANCELLED.ToString(), new PaginationParams() { ItemsPerPage = 2, Page = 1 });

            Assert.AreEqual(expected.Count, 2);
            Assert.AreEqual(expected.ToList()[1].AppointmentStatus, "CANCELLED");
        }

        [TestMethod]
        public void GetAppointmentCount_ShouldReturnTheCorrectCountOfDummyList()
        {
            repoMock.Setup(m => m.AppointmentCount(1))
                .Returns(GetDummy().Count());

            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.GetAppointmentCount(1);
            Assert.AreEqual(expected, GetDummy().Count);
        }
        [TestMethod]
        public void GetAppointmentCountFiltered_ShouldReturnTheCorrectCountOfDummyListWithStatusOPEN()
        {
            repoMock.Setup(m => m.AppointmentCount(1, "OPEN"))
                .Returns(GetDummy().Where(a => a.Status == AppointmentStatus.OPEN).Count());

            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.GetAppointmentCountBasedOnStatus(1, "OPEN");
            Assert.AreEqual(expected, 3);
        }
        [TestMethod]
        public void GetAppointmentCount_ShouldReturnTheCorrectCountOfDummyListWithStatusCLOSED()
        {
            repoMock.Setup(m => m.AppointmentCount(1, "CLOSED"))
                .Returns(GetDummy().Where(a => a.Status == AppointmentStatus.CLOSED).Count());

            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.GetAppointmentCountBasedOnStatus(1, "CLOSED");
            Assert.AreEqual(expected, 1);
        }

        [TestMethod]
        public void GetAppointmentCount_ShouldReturnTheCorrectCountOfDummyListWithStatusCONFIRMED()
        {
            repoMock.Setup(m => m.AppointmentCount(1, "CONFIRMED"))
                .Returns(GetDummy().Where(a => a.Status == AppointmentStatus.CONFIRMED).Count());

            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.GetAppointmentCountBasedOnStatus(1, "CONFIRMED");
            Assert.AreEqual(expected, 2);
        }

        [TestMethod]
        public void GetAppointmentCount_ShouldReturnTheCorrectCountOfDummyListWithStatusCANCELLED()
        {
            repoMock.Setup(m => m.AppointmentCount(1, "CANCELLED"))
                .Returns(GetDummy().Where(a => a.Status == AppointmentStatus.CANCELLED).Count());

            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.GetAppointmentCountBasedOnStatus(1, "CANCELLED");
            Assert.AreEqual(expected, 2);
        }

        [TestMethod]
        public void ChangeAppointmentStatus_StatusCONFIRMEDPassedAsParameter_ShouldReturnTrueAppointmentCofirmed()
        {
            repoMock.Setup(m => m.AcceptApppointment(1))
                .Returns(true);

            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.ChangeAppointmentStatus(new AppointmentStatusDTO()
            {
                AppointmentId = 1,
                Status = "confirmed"
            }, 1);

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void ChangeAppointmentStatus_StatusCANCELLEDPassedAsParameter_ShouldReturnTrueAppointmentCancelled()
        {
            repoMock.Setup(m => m.RejectApppointment(1))
                .Returns(true);

            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.ChangeAppointmentStatus(new AppointmentStatusDTO()
            {
                AppointmentId = 1,
                Status = "CANCELLED"
            }, 1);

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void ChangeAppointmentStatus_StatusOPENPassedAsParameter_ShouldReturnFalse()
        {
            repoMock.Setup(m => m.RejectApppointment(1))
                .Returns(true);

            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.ChangeAppointmentStatus(new AppointmentStatusDTO()
            {
                AppointmentId = 1,
                Status = "OPen"
            }, 1);

            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void CloseAppointment_ShouldReturnTrue()
        {
            repoMock.Setup(m => m.CloseAppointment(1))
                .Returns(true);
            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.CloseAppointment(1);
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void CloseAppointment_ShouldReturnFalse()
        {
            repoMock.Setup(m => m.CloseAppointment(1))
                .Returns(false);
            var appointmentService = new AppointmentService(repoMock.Object);
            var expected = appointmentService.CloseAppointment(1);
            Assert.IsFalse(expected);
        }
    }
}
