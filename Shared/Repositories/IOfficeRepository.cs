using Data.Models;
using Shared.DTO;

namespace Shared.Repositories
{
    public interface IOfficeRepository
    {
        Task<List<OfficeDTOWithAllEntities>> GetAllOffice();
        Task<OfficeDTOWithAllEntities> GetOfficeByCode(int OfficeCode);
        Task<Office?> GetOfficeById(int OfficeCode);
        Task<bool> OfficeExist(int OfficeCode);
        Task<Office> AddAsync(Office entity);

    }
}