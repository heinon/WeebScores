using AnimeService.API.DTOs.AnimeDTOs;
using AnimeService.Application.AnimeApplication.Command.AddAnime;
using AnimeService.Application.AnimeApplication.Command.UpdateAnime;
using AnimeService.Application.AnimeApplication.Query;
using AnimeService.Application.AnimeApplication.Query.GetAnimeById;
using AnimeService.Application.AnimeApplication.Query.GetAnimeByTitle;
using AnimeService.Domain.AnimeAggregate;
using AnimeService.Domain.AnimeAggregate.ValueObjects;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SharedKernel.CQRS.Command;
using SharedKernel.CQRS.Query;

namespace AnimeService.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AnimeController(ICommandBus commandBus, IQueryBus queryBus, ILogger<AnimeController> logger) : ControllerBase
    {
        private readonly ICommandBus _commandBus = commandBus;
        private readonly IQueryBus _queryBus = queryBus;
        private readonly ILogger<AnimeController> _logger = logger;

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAnime([FromBody] AnimeRequest request, CancellationToken cancellationToken)
        {
            var command = new AddAnimeCommand(
                request.Name,
                request.Description,
                request.Status,
                request.Episodes.Select(x => new AddEpisodeCommand(x.Title, x.EpisodeNumber, x.Description)).ToList(),
                request.Genres);

            var test = await _commandBus.SendAsync(command, cancellationToken).ConfigureAwait(false);

            return Ok(test.Id);
        }

        [Authorize]
        [HttpPut("anime/{id}")]
        public async Task<IActionResult> UpdateAnime([FromRoute] Guid id, [FromBody] AnimeRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateAnimeCommand(
                id, 
                request.Name, 
                request.Description, 
                request.Status, 
                request.Episodes.Select(x => new UpdateEpisodeCommand(x.Title, x.EpisodeNumber, x.Description)).ToList(), 
                request.Genres);

            var test = await _commandBus.SendAsync(command, cancellationToken).ConfigureAwait(false);

            return Ok(test?.Id);
        }

        [Authorize]
        [HttpGet("anime/{id}")]
        public async Task<IActionResult> GetAnimeById([FromRoute] Guid id)
        {

            var input = new GetAnimeByIdQuery(id);
            var test = await _queryBus.SendAsync(input);

            return Ok(test);
        }

        [Authorize]
        [HttpGet("anime/name/{name}")]
        public async Task<IActionResult> GetAnimeByName(string name)
        {
            var input = new GetAnimeByNameQuery(name);
            var test = await _queryBus.SendAsync(input);

            return Ok(test);
        }
    }
}
