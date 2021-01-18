using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.DataContext;
using Dapper;
using System;
using System.Data;
using System.Linq;
namespace BaltaStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomRepository
    {
        private readonly BaltaDataContext _context;

        public CustomerRepository(BaltaDataContext context)
        {
            _context = context;
        }
        public bool checkDocument(string document)
        {
            return
                _context
                .Connection
                .Query<bool>(
                    "SpCheckDocument",
                    new { Document = document },//Paramentro da procedure
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public bool checkEmail(string email)
        {
            return
                _context
                .Connection
                .Query<bool>(
                    "SpCheckEmail",
                    new { Email = email },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public CustomerOrderCountResult GetCustomerOrderCount(string document)
        {
            return
                 _context
                 .Connection
                 .Query<CustomerOrderCountResult>(
                     "SpGetCustomerOrderCount",
                     new { Document = document },
                     commandType: CommandType.StoredProcedure)
                 .FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            
            _context.Connection.Execute("SpCreateCustomer",
                new
                {
                    Id = customer.Id,
                    FirstName = customer.Name.FirstName,
                    LastNAME = customer.Name.LastName,
                    Document = customer.Document,
                    Email = customer.Email,
                    Phone = customer.Phone
                }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Address)
            {
                _context.Connection.Execute("SpCreateAddress",
                new
                {
                    Id = address.Id,
                    CustomerId = customer.Id,
                    Number = address.Number,
                    Complement = address.Complement,
                    District = address.District,
                    City = address.City,
                    STATE = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                    Type = address.Type
                }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
