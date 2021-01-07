using Stefanini_Test.Domain.Abstractions.Entities;
using Stefanini_Test.Domain.Enums;

namespace Stefanini_Test.Domain.Entities
{
    public class User: Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public EUserRole Role { get; set; }

    }
}
