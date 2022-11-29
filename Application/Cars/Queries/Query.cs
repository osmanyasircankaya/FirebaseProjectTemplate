using Application.Interfaces;
using MediatR;

namespace Application.Cars.Queries;

public class CarQuery : IRequest<Car>
{
    public string? Id { get; set; }
}

public class CarQueryHandler : IRequestHandler<CarQuery, Car>
{
    private readonly IFirestoreProvider _firestore;

    public CarQueryHandler(IFirestoreProvider firestore)
    {
        _firestore = firestore;
    }

    public async Task<Car> Handle(CarQuery req, CancellationToken cancellationToken)
    {
        var query = await _firestore.Get<Car>(req.Id);

        return query;
    }
}