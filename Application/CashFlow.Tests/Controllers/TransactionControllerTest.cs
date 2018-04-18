using CashFlow.Base.Interfaces;
using CashFlow.Base.Models;
using CashFlow.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashFlow.Tests.Controllers
{
    [TestClass]
    public class TransactionControllerTest : BaseTest
    {
        [TestMethod]
        public void TransactionController_Edit_DontUpdateTransactionDate()
        {
            // Arrange

            // Act

            // Assert
        }

        [Ignore]
        [TestMethod]
        public void TransactionController_Add_AddedNewTransactionWithCurrentDate()
        {
            // Arrange
            var httpContext = base.InstanciateHttpContext("Employee");

            var mockIResourceHandler = new Mock<IResourceHandler>();
            var mockITransactionHandler = new Mock<ITransactionHandler>();
            var mockIPaymentTypeRole = new Mock<IPaymentTypeRole>();
            var mockTransactionController = new Mock<TransactionController>(new object[] {
                mockIResourceHandler.Object, mockIPaymentTypeRole.Object, mockITransactionHandler.Object
            });

            var transaction = new Transaction()
            {
                Description = "Test New Transaction",
                Amount = 2000000,
                PaymentTypeId = new Guid()
            };

            var roleId = new Guid();
            var currentUser = new Resource()
            {
                Active = true,
                Email = "Employee@test.com",
                Name = "Employee",
                Username = "employee",
                RoleId = roleId,
                Role = new Base.Models.Role() { RoleId = roleId, Name = "Employee", Active = true }
            };

            var sameTransaction = false;

            mockIResourceHandler.Setup(x => x.All())
            .Returns(() =>
            {
                var resources = new List<Resource>();
                resources.Add(currentUser);
                return resources.AsQueryable();
            });

            mockITransactionHandler.Setup(x => x.Add(transaction))
            .Callback<Transaction>((t) =>
            {
                sameTransaction = transaction.Amount.Equals(t.Amount)
                    && transaction.Description.Equals(t.Description)
                    && transaction.PaymentTypeId.Equals(t.PaymentTypeId)
                    && transaction.TransactionDate.Date.Equals(DateTime.Today);
            });


            mockTransactionController.SetupProperty(x => x.CurrentUser, currentUser);

            TransactionController transactionController = mockTransactionController.Object;

            // Act
            var result = transactionController.Create(transaction);

            // Assert
            Assert.IsTrue(sameTransaction);
        }
    }
}
