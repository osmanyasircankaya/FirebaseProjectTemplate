using Application.Cars;
using Application.Cars.Commands;
using Application.Cars.Queries;
using FirebaseTest.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FirebaseProjectTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : BaseController
{
    [HttpPost]
    public async Task<ICollection<Car>> Post(CarListQuery model) => await Mediator.Send(model);

    [HttpGet]
    [Route("{id}")]
    public async Task<Car> Get(string id) => await Mediator.Send(new CarQuery { Id = id });

    [HttpPut]
    public async Task<string> Post(UpsertCarCommand model) => await Mediator.Send(model);

    [HttpDelete]
    [Route("{id}")]
    public async Task Delete(string id) => await Mediator.Send(new DeleteCarCommand { Id = id });
}