namespace Api.Dtos;

public class TeamsDto
{
    public required List<TeamDto> Teams { get; set; }
}

public class TeamDto
{
    public required string Name { get; set; }
    public required List<string> Players { get; set; }
}
