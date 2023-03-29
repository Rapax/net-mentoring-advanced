namespace CatalogService.Domain.Common
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is not Entity item)
            {
                return false;
            }

            return Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
