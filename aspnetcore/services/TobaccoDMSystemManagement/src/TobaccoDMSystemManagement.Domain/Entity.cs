namespace TobaccoDMSystemManagement.Domain;

public class Entity<TKey>
{
    public Entity()
    {
        
    }
    
    public Entity(TKey id)
    {
        Id = id;
    }
    
    public virtual TKey Id { get; protected set; }
}