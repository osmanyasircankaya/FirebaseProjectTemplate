using Application.Cities;
using Application.Cities.Commands;
using Application.Cities.Queries;
using FirebaseTest.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FirebaseProjectTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : BaseController
{
    [HttpPost]
    public async Task<ICollection<City>> Post(CityListQuery model) => await Mediator.Send(model);

    [HttpGet]
    [Route("{id}")]
    public async Task<City> Get(string id) => await Mediator.Send(new CityQuery { Id = id });

    [HttpPut]
    public async Task<string> Post(UpsertCityCommand model) => await Mediator.Send(model);

    [HttpDelete]
    [Route("{id}")]
    public async Task Delete(string id) => await Mediator.Send(new DeleteCityCommand { Id = id });
}