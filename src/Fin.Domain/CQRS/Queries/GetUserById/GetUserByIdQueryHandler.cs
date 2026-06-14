using Fin.Domain.Common;
using Fin.Domain.Interfaces;
using Fin.Domain.Interfaces.CQRS.Queries;

namespace Fin.Domain.CQRS.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, Result<GetUserByIdQueryResponse>>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }
        public async Task<Result<GetUserByIdQueryResponse>> HandleAsync(GetUserByIdQuery query, CancellationToken cancellationToken = default)
        {
            var repositoryResult = await _userRepository.GetUserByIdAsync(query.Id);
            if (repositoryResult == null)
            {
                return Result<GetUserByIdQueryResponse>.Failure(UserErrors.NotFound(query.Id));
            }

            return Result<GetUserByIdQueryResponse>.Success(new GetUserByIdQueryResponse
            {
                Name = repositoryResult.Name,
                Email = repositoryResult.Email,
                Id = repositoryResult.Id,
            });
        }
    }
}
