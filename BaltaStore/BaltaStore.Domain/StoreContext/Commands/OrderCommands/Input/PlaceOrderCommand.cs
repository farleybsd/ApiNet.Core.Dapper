using BaltaStore.Domain.StoreContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Input
{
    public class PlaceOrderCommand
    {
        public Guid customer { get; set; }
        public IList<OrdemItemComamnd> OrdemItems { get; set; }

    }

    public class OrdemItemComamnd
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}
