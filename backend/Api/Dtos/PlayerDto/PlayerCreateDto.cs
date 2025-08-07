namespace Api.Dtos
{
    public class PlayerCreateDto
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
    }
}
