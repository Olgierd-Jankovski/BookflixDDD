namespace Bookflix.Domain.Common.Models;

public abstract class Entity<TId>
{

    private int? _requestedHashCode;

    public TId Id { get; protected set; }

    protected Entity(TId id)
    {
        Id = id;
    }

    public bool IsTransient()
    {
        return Equals(Id, default(TId));
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is Entity<TId>))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        Entity<TId> item = (Entity<TId>)obj;

        if (item.IsTransient() || this.IsTransient())
            return false;

        return item.Id!.Equals(Id);
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = Id!.GetHashCode() ^ 31;  // XOR for a more random distribution, example use

            return _requestedHashCode.Value;
        }
        else
            return base.GetHashCode();
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        if (Equals(left, null))
            return Equals(right, null);
        else
            return left.Equals(right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !(left == right);
    }
}