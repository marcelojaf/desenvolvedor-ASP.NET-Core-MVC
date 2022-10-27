namespace DevIO.Business.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
