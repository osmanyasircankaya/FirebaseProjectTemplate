using Application.Interfaces;
using MediatR;

namespace Application.Cars.Commands;

public class DeleteCarCommand : IRequest
{
    public string? Id { get; set; }
}

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
{
    private readonly IFirestoreProvider _firestore;

    public DeleteCarCommandHandler(IFirestoreProvider firestore)
    {
        _firestore = firestore;
    }

    public async Task<Unit> Handle(DeleteCarCommand req, CancellationToken cancellationToken)
    {
        await _firestore.Delete<Car>(req.Id);

        return Unit.Value;
    }
}