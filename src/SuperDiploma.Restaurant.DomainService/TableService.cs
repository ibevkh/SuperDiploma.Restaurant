using AutoMapper;
using SuperDiploma.Restaurant.DataContext.EF;
using SuperDiploma.Restaurant.DataContext.EF.Repositories;
using SuperDiploma.Restaurant.DataContext.Entities.Models;
using SuperDiploma.Restaurant.DomainService.Contracts;

namespace SuperDiploma.Restaurant.DomainService;

internal class TableService : ITableService
{
    private readonly IMapper _mapper;
    private readonly IRestaurantUnitOfWork _myUnitOfWork;

    public TableService(IMapper mapper, IRestaurantUnitOfWork myUnitOfWork)
    {
        _mapper = mapper;
        _myUnitOfWork = myUnitOfWork;
    }

    public async Task<bool> MarkTableAsUnavailableAsync(int tableId)
    {
        var table = await _myUnitOfWork.Repository<TableDbo>().FindByIdAsync(tableId);
        if (table == null)
        {
            return false;
        }

        table.IsAvailable = false;
        _myUnitOfWork.Repository<TableDbo>().Update(table);
        await _myUnitOfWork.SaveChangesAsync();

        return true;
    }
}