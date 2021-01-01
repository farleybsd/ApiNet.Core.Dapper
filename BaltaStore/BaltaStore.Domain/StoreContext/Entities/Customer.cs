using BaltaStore.Domain.StoreContext.ValueObjects;
using System.Collections.Generic;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer
    {
        // SOLID
        public Customer
        (Name name,
         Document document,
         Email email,
         string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            Address = new List<Address>();
        }
        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Address { get; private set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}