using SuperDiploma.Core.Models;
using SuperDiploma.Restaurant.DataContext.Entities.Models;

namespace SuperDiploma.Restaurant.DomainService.Contracts;

public interface IGenericShopItem<TDbo, TDto>
    where TDbo : SuperDiplomaBaseDbo
    where TDto : class
{
    Task<TDto> GetItemByIdAsync(int id);
    Task<TDto> CreateOrUpdateItemAsync(TDto dto);
    Task<TDto> RemoveItemAsync(int id);
}