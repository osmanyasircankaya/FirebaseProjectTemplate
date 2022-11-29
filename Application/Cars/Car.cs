using Application.Interfaces;
using Google.Cloud.Firestore;

namespace Application.Cars;

[FirestoreData]
public class Car : IFirebaseEntity
{
    [FirestoreProperty] public string? Id { get; set; }
    [FirestoreProperty] public string? Brand { get; set; }
    [FirestoreProperty] public string? Model { get; set; }
    [FirestoreProperty] public int Year { get; set; }
}