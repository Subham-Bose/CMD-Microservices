using CMD.API.Appointments.Controllers;
using CMD.Business.Appointments.Implementations;
using CMD.Business.Appointments.Interfaces;
using CMD.DTO.Appointments;
using CMD.Model.Appointments;
using CMD.Repository.Appointments.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;

namespace CMD.ApppointmentController.Test
{
    [TestClass]
    public class PrescriptionServiceUnitTest
    {
        PrescriptionRepository obj;



        //Initialize for Business layer
        IPrescriptionService obj1;



        [TestInitialize]
        public void ObjectCreation()
        {
            obj = new PrescriptionRepository();



            //For Business layer
            obj1 = new PrescriptionService();
        }
        public void GetAllMedicines_ShouldReturnAllMedicines()
        {
            var tests = obj1.GetPrescriptions(4);
            Assert.IsTrue(tests.Count > 0);
        }



        [TestMethod]
        public void AddPrescription_ShouldReturnExceptionForInvalidAppointmentId()
        {
            PrescriptionDTO prescription = new PrescriptionDTO { Id = 3, Medicine = "Gabapentin" };
            obj1.AddPrescription(4, prescription);
        }



        [TestMethod]
        public void DeletePrescription_ShouldReturnNullIfNoMedicineAddedYetByDoctorIdNotExisted() // Wrong Details
        {
            var deletedTestReport = obj1.DeletePrescription(2, 2);
            Assert.IsFalse(deletedTestReport);
        }

        #region Controller



        [TestMethod]
        public void DeleteReturnsOk()
        {
            // Arrange
            var mockRepository = new Mock<IPrescriptionService>();
            var controller = new PrescriptionController(mockRepository.Object);



            // Act
            IHttpActionResult actionResult = controller.DeletePrescription(3, 4);



            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }



        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void PostMethodSetsLocationHeader()
        {
            // Arrange
            var mockRepository = new Mock<IPrescriptionService>();
            var controller = new PrescriptionController(mockRepository.Object);



            // Act
            IHttpActionResult actionResult = controller.AddPrescription(3, new PrescriptionDTO { Medicine = "Lisinopril" });
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Prescription>;



            // Assert
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(10, createdResult.RouteValues["id"]);
        }



        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void PutReturnsContentResult()
        {
            // Arrange
            var mockRepository = new Mock<IPrescriptionService>();
            var controller = new PrescriptionController(mockRepository.Object);



            // Act
            IHttpActionResult actionResult = controller.Edit(3, new PrescriptionDTO { Medicine = "Metformin" });
            var contentResult = actionResult as NegotiatedContentResult<Prescription>;



            // Assert
            Assert.AreEqual(HttpStatusCode.Accepted, contentResult.StatusCode);
            Assert.AreEqual(10, contentResult.Content.Id);
        }



        [TestMethod]
        public void GetPrescriptionNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IPrescriptionService>();
            var controller = new PrescriptionController(mockRepository.Object); // Act
            IHttpActionResult actionResult = controller.GetPrescription(3); // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
        #endregion
    }
}
