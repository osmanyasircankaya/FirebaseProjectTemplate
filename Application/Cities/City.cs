using Application.Interfaces;
using Google.Cloud.Firestore;

namespace Application.Cities;

[FirestoreData]
public class City : IFirebaseEntity
{
    [FirestoreProperty] public string? Id { get; set; }
    [FirestoreProperty] public string? Name { get; set; }
    [FirestoreProperty] public string? Country { get; set; }
    [FirestoreProperty] public long? Population { get; set; }
}