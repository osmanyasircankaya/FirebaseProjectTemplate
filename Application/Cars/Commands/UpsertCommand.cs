using Application.Interfaces;
using MediatR;

namespace Application.Cars.Commands;

public class UpsertCarCommand : IRequest<string>
{
    public string? Id { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }
}

public class UpsertCarCommandHandler : IRequestHandler<UpsertCarCommand, string>
{
    private readonly IFirestoreProvider _firestore;

    public UpsertCarCommandHandler(IFirestoreProvider firestore)
    {
        _firestore = firestore;
    }

    public async Task<string> Handle(UpsertCarCommand req, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(req.Id))
            req.Id = Guid.NewGuid().ToString();

        var entity = new Car
        {
            Id = req.Id,
            Brand = req.Brand,
            Model = req.Model,
            Year = req.Year
        };

        await _firestore.AddOrUpdate(entity);

        return req.Id;
    }
}