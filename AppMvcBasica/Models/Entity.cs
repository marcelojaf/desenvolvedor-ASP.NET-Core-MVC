using System.ComponentModel;

namespace AppMvcBasica.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
