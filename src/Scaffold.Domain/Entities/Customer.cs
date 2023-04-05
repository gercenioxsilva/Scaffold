using Scaffold.Domain.Base;
using Scaffold.Domain.Enuns;

namespace Scaffold.Domain.Entities
{
    public class Customer : BaseEntity
    {

        public string Document { get; private set; }
        public string Name { get; private set; }

        public CustomerType Type { get; private set; }

        public Customer(string document, string name) 
        {
            Document = document;
            Name = name;
        }

        public void AddCustomerType(CustomerType t) 
        {
            Type= t;
        }
    }
}
