using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Repositories
{
   public interface ICustomRepository
    {
        bool checkDocument(string document);
        bool checkEmail(string email);
        void Save(Customer customer);
        CustomerOrderCountResult GetCustomerOrderCount(string Document);
        IEnumerable<ListCustomerQueryResult> Get();
        GetCustomerQueryResult Get(Guid id);
        IEnumerable<ListQueryCustomerOrderQueryResult> GetOrders(Guid id);
    }
}
