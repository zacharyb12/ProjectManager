namespace Dal.Interfaces;

public interface ICrudRepository<TEntity, TKey> where TEntity : class
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(TKey id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TKey id);
    void Delete(TEntity entity);
}