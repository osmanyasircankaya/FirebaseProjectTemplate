using System.Reflection;
using Application.Interfaces;
using Google.Cloud.Firestore;
using Infrastructure;

namespace FirebaseProjectTemplate;

public static class FirebaseHelper
{
    public static void AddFirebase(this IServiceCollection services)
    {
        // firebase service account credentials file path (as default you can put it in the root of your project)
        var credentialsPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/service-account.json";
        
        // firebase project id
        const string projectId = "your-project-id";

        services.AddSingleton<IFirestoreProvider, FirestoreProvider>(_ => new FirestoreProvider(new FirestoreDbBuilder
        {
            ProjectId = projectId,
            CredentialsPath = credentialsPath
        }.Build()));
    }
}