using BaltaStore.Domain.StoreContext.Entities;
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

        public void Save(Customer customer)
        {
           
        }
    }
}
