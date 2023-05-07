using Microsoft.EntityFrameworkCore;
using MoqProject.API.Interfaces;
using MoqProject.API.Models;
using MoqProject.API.Persistence;

namespace MoqProject.API.Services
{
    public class DistroListService : IDistroListService
    {
        private DistroDbContext _db;

        public DistroListService(DistroDbContext dbContext)
        {
            _db = dbContext;
        }

        public virtual DistributionList Create(string name, List<Contact> contacts)
        {
            var distro = new DistributionList
            {
                Title = name,
                Contacts = contacts
            };

            try
            {
                _db.DistributionLists.Add(distro);
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }

            return distro;

        }

        public virtual async Task<DistributionList> GetDistroById(int distroId)
        {
            return await _db.DistributionLists.Where(x => x.Id.Equals(distroId)).FirstOrDefaultAsync();
        }

        public virtual async Task<List<DistributionList>> Remove(int distroId)
        {
            throw new NotImplementedException();
        }
    }
}
