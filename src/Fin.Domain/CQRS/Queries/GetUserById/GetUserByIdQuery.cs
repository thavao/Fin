using Fin.Domain.Interfaces.CQRS.Queries;

namespace Fin.Domain.CQRS.Queries.GetUserById
{
    public class GetUserByIdQuery : IQuery<GetUserByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
