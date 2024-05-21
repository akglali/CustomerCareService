using Data.Models;
using Shared.DTO;

namespace Shared.Repositories.Interfaces
{
    public interface IOfficeRepository
    {
        Task<List<OfficeDTOWithAllEntities>> GetAllOffice();
        Task<OfficeDTOWithAllEntities> GetOfficeByCode(int OfficeCode);
     
        Task<bool> OfficeExist(int OfficeCode);
        Task<Office> AddAsync(Office entity);

        IQueryable<Office> GetAll();

        Task<Office> GetByIdAsync(long Id);

        Task<Office> UpdateAsync(Office entity);   

    }
}