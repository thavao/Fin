namespace Fin.Domain.DTO.GetUserById
{
    public class GetUserByIdRepositoryResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
