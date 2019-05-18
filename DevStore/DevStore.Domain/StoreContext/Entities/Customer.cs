
namespace DevStore.Domain.StoreContext.Entities
{
    public class Customer
    {
        public Customer(string firstName, string lastName, string document, string email, string fone, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            Fone = fone;
            Address = address;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get;private set; }
        public string Fone { get; private set; }
        public string Address { get; private set; }

        //Sobreescrita de metódo.
        public override string ToString() {
            return $"{FirstName} {LastName}";
        }
    }
}