using CMD.Repository.Appointments.Implementations;
using CMD.Repository.Appointments.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMD.ApppointmentController.Test
{
    /// <summary>
    /// Summary description for CMDFeedback
    /// </summary>
    [TestClass]
    public class CMDFeedback
    {
        IFeedbackRepository obj;
        [TestInitialize]
        public void ObjectCreation()
        {
            obj = new FeedbackRepository();
        }
        [TestMethod]
        public void GetFeedback_ShouldReturnFeedbacks()
        {
            var result = obj.GetFeedback(1);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetFeedback_ShouldReturnCorrectResultsForExistedppointmentId() // Positive i.e., < 0
        {
            var results = obj.GetFeedback(1);
            Assert.IsNotNull(results);
        }
        [TestMethod]
        public void GetFeedback_ShouldReturnNothingForNegetiveAppointmentIds() // Negetive i.e., <= 0
        {
            //Act
            var results = obj.GetFeedback(-1);
            //Assert
            Assert.AreEqual(results, null);
        }
    }
}
