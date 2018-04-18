using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashFlow;
using CashFlow.Controllers;
using CashFlow.Base.Interfaces;
using CashFlow.Base.Models;
using Moq;
using CashFlow.Role;
using System;
using CashFlow.Models;

namespace CashFlow.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest : BaseTest
    {
        [Ignore]
        [TestMethod]
        public void HomeController_Index_NotAuthenticatedResource()
        {
            // Arrange
            var httpContext = base.InstanciateHttpContext(string.Empty);

            var mockIResourceHandler = new Mock<IResourceHandler>();
            var mockITransactionHandler = new Mock<ITransactionHandler>();
            var mockITransactionRole = new Mock<ITransactionRole>();

            HomeController homeController = new HomeController(mockIResourceHandler.Object, mockITransactionHandler.Object, mockITransactionRole.Object);

            // Act
            ViewResult result = homeController.Index() as ViewResult;
            HomeViewModel resultModel = result.Model as HomeViewModel;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!resultModel.LoggedUser && !resultModel.AuthorizedUser);
        }
    }
}
