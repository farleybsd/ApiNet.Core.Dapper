using BaltaStore.Domain.StoreContext.Entities;
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
    }
}
