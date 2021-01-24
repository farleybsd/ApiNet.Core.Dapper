using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Tests.Fakes
{
   public class FakeCustomerRepository : ICustomRepository
    {
        public bool checkDocument(string document)
        {
            return false;
        }

        public bool checkEmail(string email)
        {
            return false;
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            throw new NotImplementedException();
        }

        public GetCustomerQueryResult Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public CustomerOrderCountResult GetCustomerOrderCount(string Document)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListQueryCustomerOrderQueryResult> GetOrders(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {
           
        }
    }
}
