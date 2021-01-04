using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Input
{
    public class PlaceOrderCommand : Notifiable, IComand
    {
        public PlaceOrderCommand()
        {
            OrdemItems = new List<OrdemItemComamnd>();
        }
        public Guid customer { get; set; }
        public IList<OrdemItemComamnd> OrdemItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                 .HasLen(customer.ToString(), 36, "customer", "Identificador do cliente invalido")
                 .IsGreaterThan(OrdemItems.Count,0, "Items", "Nenhium Item do pedido encontrado")
                 );
            return Valid();
        }
    }

    public class OrdemItemComamnd
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}
