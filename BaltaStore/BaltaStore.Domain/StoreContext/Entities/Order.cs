using BaltaStore.Domain.StoreContext.Enums;
using System;
using System.Collections.Generic;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order
    {
        public Order(Customer customer)
        {
            Customer = customer;
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,8).ToUpper();
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            Items = new List<OrderItem>();
            Deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; } // 1 para 1
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get; private set; } // 1 para n
        public IReadOnlyCollection<Delivery> Deliveries { get; private set; } // Lista de leitura pode adc apenas usando o AddItem

        public void AddItem(OrderItem orderItem)
        {
            // Valida Item

            //Adciona ao Pedido
        }

        // To Place An Order
        public void Place() { }
    }
}