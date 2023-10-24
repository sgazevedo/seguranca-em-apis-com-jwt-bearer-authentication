namespace JwtStore.Core.Contexts.ShareContext.Entities
{
  public abstract class Entity : IEquatable<Guid>
  {
    protected Entity() =>
        Id = Guid.NewGuid();

    public Guid Id { get; }

    public bool Equals(Guid id)
        => Id == id;

    public override int GetHashCode()
        => Id.GetHashCode();
  }
}
