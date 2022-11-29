using Application.Interfaces;
using MediatR;

namespace Application.Cities.Queries;

public class CityQuery : IRequest<City>
{
    public string? Id { get; set; }
}

public class CityQueryHandler : IRequestHandler<CityQuery, City>
{
    private readonly IFirestoreProvider _firestore;

    public CityQueryHandler(IFirestoreProvider firestore)
    {
        _firestore = firestore;
    }

    public async Task<City> Handle(CityQuery req, CancellationToken cancellationToken)
    {
        var query = await _firestore.Get<City>(req.Id);

        return query;
    }
}