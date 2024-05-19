using Data.Models;
using Shared.DTO;

namespace Shared.Services.Interface
{
    public interface IOfficeService
    {
        Task AddOffice(OfficeDTO office);
        Task<List<OfficeDTOWithAllEntities>> GetAllOffices();
        Task<OfficeDTOWithAllEntities> GetOfficeByCode(int officeCode);
    }
}