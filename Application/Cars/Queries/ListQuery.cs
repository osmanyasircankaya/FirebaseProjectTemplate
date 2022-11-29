using Application.Interfaces;
using MediatR;

namespace Application.Cars.Queries;

public class CarListQuery : IRequest<List<Car>>
{
    public string? Brand { get; set; }
}

public class CarListQueryHandler : IRequestHandler<CarListQuery, List<Car>>
{
    private readonly IFirestoreProvider _firestore;

    public CarListQueryHandler(IFirestoreProvider firestore)
    {
        _firestore = firestore;
    }

    public async Task<List<Car>> Handle(CarListQuery req, CancellationToken cancellationToken)
    {
        var query = await _firestore.GetAll<Car>();

        // Filter by brand
        // You can use WhereEqualTo
        if (!string.IsNullOrEmpty(req.Brand))
            query = query.Where(x => x.Brand == req.Brand);

        return query.ToList();
    }
}