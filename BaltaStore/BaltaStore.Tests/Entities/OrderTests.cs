using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        // Consigo Criar um Novo Pedido
        public void ShouldCreateOrderWhenValid()
        {
            Assert.Fail();
        }


        // Ao Criar o pedido o status deve ser Created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {

        }

        // Ao Adicionar um novo item, a quantidade deve 
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {

        }

        // Ao adicionar um novo item deve subtrair a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
        {

        }

        // Ao confimar pedido,deve gerar um numero
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {

        }

        // Ao pagar um pedido, o status deve ser pago
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {

        }

        // Dados 10 produtos devem haver duas entregas
        [TestMethod]
        public void ShouldTwoWhenTenProducts()
        {

        }

        // Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {

        }

        // Ao cancelar o pedido deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {

        }
    }
}
// PAREI 09:00 Testando Entidades
