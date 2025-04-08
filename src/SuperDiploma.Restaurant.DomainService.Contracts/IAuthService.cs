namespace SuperDiploma.Restaurant.DomainService.Contracts;

public interface IAuthService
{
    Task<int> GetCurrentUserIdAsync();
}