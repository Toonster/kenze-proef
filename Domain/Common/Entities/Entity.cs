namespace Domain.Common.Entities;

public abstract class Entity
{
    private const string EmptyIdMessage = "Id can't be empty";

    private protected Entity(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new InvalidOperationException(EmptyIdMessage);
        }

        Id = id;
    }

    public Guid Id { get; }
}