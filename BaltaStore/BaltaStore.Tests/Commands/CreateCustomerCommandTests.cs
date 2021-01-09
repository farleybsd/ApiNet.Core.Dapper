using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]

        public void shouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirtsName = "Farley";
            command.LastName = "Rufino";
            command.Document = "11405263679";
            command.Email = "farley.t.i@hotmail.com";
            command.Phone = "33991057769";

            Assert.AreEqual(true, command.Valid());
        }

    }
}
