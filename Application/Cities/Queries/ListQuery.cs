using Application.Interfaces;
using MediatR;

namespace Application.Cities.Queries;

public class CityListQuery : IRequest<List<City>>
{
    public long? Population { get; set; }
}

public class CityListQueryHandler : IRequestHandler<CityListQuery, List<City>>
{
    private readonly IFirestoreProvider _firestore;

    public CityListQueryHandler(IFirestoreProvider firestore)
    {
        _firestore = firestore;
    }

    public async Task<List<City>> Handle(CityListQuery req, CancellationToken cancellationToken)
    {
        var query = await _firestore.GetAll<City>();

        // Filter by population
        // You can use WhereGreaterThanOrEqualTo
        if (req.Population.HasValue)
            query = query.Where(x => x.Population >= req.Population);

        return query.ToList();
    }
}