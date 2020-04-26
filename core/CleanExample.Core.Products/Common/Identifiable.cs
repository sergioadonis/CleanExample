namespace CleanExample.Core.Products.Common
{
    public abstract class Identifiable<TId>
    {
        protected Identifiable(TId id)
        {
            Id = id;
        }

        public TId Id { get; }
    }
}