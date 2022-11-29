using System.ComponentModel.DataAnnotations;
using Application.Interfaces;
using Google.Cloud.Firestore;

namespace Infrastructure;

public class FirestoreProvider : IFirestoreProvider
{
    private readonly FirestoreDb _fireStoreDb;

    public FirestoreProvider(FirestoreDb fireStoreDb)
    {
        _fireStoreDb = fireStoreDb;
    }

    public async Task AddOrUpdate<T>(T entity) where T : IFirebaseEntity
    {
        var document = _fireStoreDb.Collection(typeof(T).Name).Document(entity.Id);
        await document.SetAsync(entity);
    }

    public async Task<T> Get<T>(string? id) where T : IFirebaseEntity
    {
        if (string.IsNullOrEmpty(id))
            throw new ValidationException("Id cannot be null or empty");

        var document = _fireStoreDb.Collection(typeof(T).Name).Document(id);
        var snapshot = await document.GetSnapshotAsync();
        return snapshot.ConvertTo<T>();
    }

    public async Task<IQueryable<T>> GetAll<T>() where T : IFirebaseEntity
    {
        var collection = _fireStoreDb.Collection(typeof(T).Name);
        var snapshot = await collection.GetSnapshotAsync();
        return snapshot.Documents.Select(x => x.ConvertTo<T>()).AsQueryable();
    }

    public async Task Delete<T>(string? id) where T : IFirebaseEntity
    {
        var document = _fireStoreDb.Collection(typeof(T).Name).Document(id);
        await document.DeleteAsync();
    }

    public async Task<IQueryable<T>> WhereEqualTo<T>(string field, object value) where T : IFirebaseEntity
    {
        var query = _fireStoreDb.Collection(typeof(T).Name).WhereEqualTo(field, value);
        var snapshot = await query.GetSnapshotAsync();
        return snapshot.Documents.Select(x => x.ConvertTo<T>()).AsQueryable();
    }

    public async Task<IQueryable<T>> WhereGreaterThanOrEqualTo<T>(string field, object value) where T : IFirebaseEntity
    {
        var query = _fireStoreDb.Collection(typeof(T).Name).WhereGreaterThanOrEqualTo(field, value);
        var snapshot = await query.GetSnapshotAsync();
        return snapshot.Documents.Select(x => x.ConvertTo<T>()).AsQueryable();
    }

    public async Task<IQueryable<T>> InRange<T>(string field, object firstValue, object secondValue) where T : IFirebaseEntity
    {
        var query = _fireStoreDb.Collection(typeof(T).Name).WhereGreaterThanOrEqualTo(field, firstValue).WhereLessThanOrEqualTo(field, secondValue);
        var snapshot = await query.GetSnapshotAsync();
        return snapshot.Documents.Select(x => x.ConvertTo<T>()).AsQueryable();
    }
}