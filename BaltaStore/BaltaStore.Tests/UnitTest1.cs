using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Farley","Rufino");
            var document = new Document("1234567911");
            var email = new Email("Farley.t.i@hotmail.com");
            var c = new Customer(name,document,email,"32133626");

            var mouse = new Product("Mouse","Rato","image.png",59.90M,10);
            var teclado = new Product("Teclado", "Teclado", "image.png", 159.90M, 10);
            var impressora = new Product("Impressora", "Impressora", "image.png", 359.90M, 10);
            var cadeira = new Product("cadeira", "cadeira", "image.png", 559.90M, 10);

            var order = new Order(c);

            //order.AddItem(new OrderItem(mouse, 5));
            //order.AddItem(new OrderItem(teclado, 5));
            //order.AddItem(new OrderItem(impressora, 5));
            //order.AddItem(new OrderItem(cadeira, 5));



            // Relizar o pedido
            order.Place();

            // Verificar se o pedido e valido
            var valid = order.IsValid;

            //Simular Pagamento
            order.Pay();

            // Simular o envio
            order.Ship();

            //Simular o cancelamento
            order.Cancel();
        }
    }
}
