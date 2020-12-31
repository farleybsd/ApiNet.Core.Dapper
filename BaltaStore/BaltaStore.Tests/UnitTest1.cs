using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer(

                 "Farley",
                 "Rufino",
                 "123456",
                 "teste@teste.com.br",
                 "123456",
                 "Rua Rodrigues Alves 1147"
            );

            var order = new Order(c);
        }
    }
}
