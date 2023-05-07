using MoqProject.API.Models;

namespace MoqProject.API.Interfaces
{
    public interface IDistroListService
    {
        Task<DistributionList> GetDistroById(int distroId);
        DistributionList Create(string name, List<Contact> contacts);
        Task<List<DistributionList>> Remove(int distroId);
    }
}
