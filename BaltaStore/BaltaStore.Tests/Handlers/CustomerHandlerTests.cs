using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Tests.Handlers
{
    [TestClass]
   public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirtsName = "Farley";
            command.LastName = "Rufino";
            command.Document = "11405263679";
            command.Email = "Farley.t.i@hotmail.com";
            command.Phone = "32123626";

            Assert.AreEqual(true, command.Valid());

            var handler = new CustomerHandler(new FakeCustomerRepository(),new FakeEmailService());
        }
        
    }
}
