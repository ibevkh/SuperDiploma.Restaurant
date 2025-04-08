using SuperDiploma.Restaurant.DomainService.Contracts;

namespace SuperDiploma.Restaurant.DomainService;

public class AuthService : IAuthService
{
    public async Task<int> GetCurrentUserIdAsync()
    {
        return await Task.FromResult(1);
    }
}