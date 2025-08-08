using Api.Data;
using Api.Dtos;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
  private readonly TennisDbContext _context;
  public TeamsController(TennisDbContext context)
  {
    _context = context;
  }

  [HttpPost]
    public async Task<IActionResult> SaveTeams([FromBody] TeamsDto teamsDto)
    {
        foreach (var teamDto in teamsDto.Teams)
        {
            var team = new Team
            {
                Name = teamDto.Name,
                Players = teamDto.Players.Select(playerName => new Player { Name = playerName }).ToList()
            };
            _context.Teams.Add(team);
        }

        await _context.SaveChangesAsync();
        return Ok(new { message = "Squadre salvateeeeeeeeee2!!!!" });
    }

}
