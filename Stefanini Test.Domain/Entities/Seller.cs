using Stefanini_Test.Domain.Abstractions.Entities;

namespace Stefanini_Test.Domain.Entities
{
    public class Seller : Entity
    {
        public string Name { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
