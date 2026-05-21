using Fin.Domain.Interfaces;
using Fin.Domain.Interfaces.CQRS.Queries;

namespace Fin.Domain.CQRS.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, GetUserByIdQueryResponse>
    {
        private IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }
        public async Task<GetUserByIdQueryResponse> HandleAsync(GetUserByIdQuery query, CancellationToken cancellationToken = default)
        {
            try
            {
                var repositoryResult = await _userRepository.GetUserByIdAsync(query.Id);
                return new GetUserByIdQueryResponse
                {
                    Name = repositoryResult.Name,
                    Email = repositoryResult.Email,
                    Id = repositoryResult.Id,
                };
            }
            catch (Exception ex)
            {
                return new GetUserByIdQueryResponse();
            }
        }
    }
}
