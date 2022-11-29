using Application.Interfaces;
using MediatR;

namespace Application.Cities.Commands;

public class DeleteCityCommand : IRequest
{
    public string? Id { get; set; }
}

public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand>
{
    private readonly IFirestoreProvider _firestore;

    public DeleteCityCommandHandler(IFirestoreProvider firestore)
    {
        _firestore = firestore;
    }

    public async Task<Unit> Handle(DeleteCityCommand req, CancellationToken cancellationToken)
    {
        await _firestore.Delete<City>(req.Id);

        return Unit.Value;
    }
}