using System.Text.Json.Serialization;

namespace SistemaNoticias.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
