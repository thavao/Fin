using Fin.Domain.Common;
using Fin.Domain.Interfaces.CQRS.Queries;

namespace Fin.Domain.CQRS.Queries.GetUserById
{
    public class GetUserByIdQuery : IQuery<Result<GetUserByIdQueryResponse>>
    {
        public Guid Id { get; set; }
    }
}
