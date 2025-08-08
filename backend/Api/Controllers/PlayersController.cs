using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Data;
using Api.Dtos;

namespace Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PlayersController : ControllerBase
  {
    private readonly TennisDbContext _context;
    public PlayersController(TennisDbContext context) => _context = context;

    [HttpGet]
    public ActionResult<IEnumerable<Player>> Get() => _context.Players.ToList();

    [HttpGet("{id}")]
    public ActionResult<Player> Get(int id)
    {
      var player = _context.Players.Find(id);
      if (player == null) return NotFound();
      return player;
    }

    [HttpPost]
    public ActionResult<Player> Post(Player player)
    {
      _context.Players.Add(player);
      _context.SaveChanges();
      return CreatedAtAction(nameof(Get), new { id = player.Id }, player);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Player player)
    {
      var existingPlayer = _context.Players.Find(id);
      if (existingPlayer == null) return NotFound();

      existingPlayer.Name = player.Name;
      existingPlayer.TeamId = player.TeamId;
      _context.SaveChanges();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var player = _context.Players.Find(id);
      if (player == null) return NotFound();
      _context.Players.Remove(player);
      _context.SaveChanges();
      return NoContent();
    }
  }
}
