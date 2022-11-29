namespace Application.Interfaces;

public interface IFirestoreProvider
{
    Task<IQueryable<T>> GetAll<T>() where T : IFirebaseEntity;
    Task<T> Get<T>(string? id) where T : IFirebaseEntity;
    Task AddOrUpdate<T>(T entity) where T : IFirebaseEntity;
    Task Delete<T>(string? id) where T : IFirebaseEntity;
    Task<IQueryable<T>> WhereEqualTo<T>(string field, object value) where T : IFirebaseEntity;
    Task<IQueryable<T>> WhereGreaterThanOrEqualTo<T>(string field, object value) where T : IFirebaseEntity;
    Task<IQueryable<T>> InRange<T>(string field, object firstValue, object secondValue) where T : IFirebaseEntity;
}