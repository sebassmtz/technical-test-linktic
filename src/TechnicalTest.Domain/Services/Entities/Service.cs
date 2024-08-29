
using TechnicalTest.Domain.Common.Entities;

namespace TechnicalTest.Domain.Services.Entities
{
    public class Service : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }


        private Service()
        {
        }

        private Service(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public static Service Create(string name, string description, decimal price)
        {
            return new Service(name, description, price);
        }

        public void Update(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
