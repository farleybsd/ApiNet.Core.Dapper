using BaltaStore.Domain.StoreContext.ValueObjects;
using System.Collections.Generic;
using System.Linq;
namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer
    {
        private readonly IList<Address> _address;
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
            _address = new List<Address>();
        }
        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Address => _address.ToArray();

        public void AddAddress(Address address)
        {
            //Valida Endereco
            //Adc Endereco
            _address.Add(address);
        }
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}