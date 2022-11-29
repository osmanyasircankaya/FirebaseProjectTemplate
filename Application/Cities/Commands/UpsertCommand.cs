using Application.Interfaces;
using MediatR;

namespace Application.Cities.Commands;

public class UpsertCityCommand : IRequest<string>
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
    public long? Population { get; set; }
}

public class UpsertCityCommandHandler : IRequestHandler<UpsertCityCommand, string>
{
    private readonly IFirestoreProvider _firestore;

    public UpsertCityCommandHandler(IFirestoreProvider firestore)
    {
        _firestore = firestore;
    }

    public async Task<string> Handle(UpsertCityCommand req, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(req.Id))
            req.Id = Guid.NewGuid().ToString();

        var entity = new City
        {
            Id = req.Id,
            Name = req.Name,
            Country = req.Country,
            Population = req.Population
        };

        await _firestore.AddOrUpdate(entity);

        return req.Id;
    }
}