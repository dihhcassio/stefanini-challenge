using System;

namespace Stefanini_Test.Domain.Abstractions.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public bool Removed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
