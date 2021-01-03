using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _KeyBoard;
        private Product _chair;
        private Product _monitor;

        private Customer _customer;
        private Order _order;


        public OrderTests()
        {
            var name = new Name("Farley", "Rufino");
            var document = new Document("11405263679");
            var email = new Email("farley.t.i@hotmail.com");

            _customer = new Customer(name, document, email, "32123626");

            _order = new Order(_customer);

            _mouse = new Product("Mouse Gamer","Mouse Gamer","mouse.jpg",100M,10);
            _KeyBoard = new Product("Teclado Gamer", "Teclado Gamer", "Teclado.jpg", 100M, 10);
            _chair = new Product("Cadeira Gamer", "Cadeira Gamer", "Cadeira.jpg", 100M, 10);
            _monitor = new Product("Monitor Gamer", "Monitor Gamer", "Monitor.jpg", 100M, 10);
        }
        [TestMethod]
        // Consigo Criar um Novo Pedido
        public void ShouldCreateOrderWhenValid()
        {

            Assert.AreEqual(true, _order.IsValid);
        }


        // Ao Criar o pedido o status deve ser Created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // Ao Adicionar um novo item, a quantidade deve 
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        // Ao adicionar um novo item deve subtrair a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
        {
           
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand,5);
        }

        // Ao confimar pedido,deve gerar um numero
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        // Ao pagar um pedido, o status deve ser pago
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        // Dados 10 produtos devem haver duas entregas
        [TestMethod]
        public void ShouldTwoShippingsWhenTenProducts()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);

            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);

            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);

            _order.Ship();

            Assert.AreEqual(2,_order.Deliveries.Count);
        }

        // Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // Ao cancelar o pedido deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);

            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);

            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);

            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);

            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);

            _order.Ship();

            _order.Cancel();

            foreach (var item in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, item.Status);
            }

           
        }
    }
}

