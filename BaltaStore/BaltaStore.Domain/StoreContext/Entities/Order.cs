using BaltaStore.Domain.StoreContext.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; } // 1 para 1
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(OrderItem item)
        {
            // Valida Item

            //Adciona ao Pedido
            _items.Add(item);
        }

        // Criar um Pedido
        public void Place()
        {
            //Gera o numero do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
        }

        // Pagar um pedido
        public void Pay()
        {

            Status = EOrderStatus.Paid;

        }

        // Enviar um pedido
        public void Ship()
        {
            // A cada cinco produtos e uma entrega
            var count = 1;
            var deliveries = new List<Delivery>();

            //Quebra as entregas
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }
            //Envia todas as entregas
            deliveries.ForEach(x => x.Ship());
            //Adiciona todas as entregas ao pedido
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        // Cancelar um pedido
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}