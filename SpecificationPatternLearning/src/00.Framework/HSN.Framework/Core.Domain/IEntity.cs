namespace HSN.Framework.Core.Domain
{
    public interface IEntity<T>
    {
        T Id { get; }
    }
}
