
using DevStore.Domain.StoreContext.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace DevStore.Domain.StoreContext.Entities
{
    public class Customer
    {
        private readonly IList<Address> _addresses;
        public Customer(Name name, Document document, Email email, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses { get { return _addresses.ToArray(); } }

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }
        //Sobreescrita de metódo.
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}