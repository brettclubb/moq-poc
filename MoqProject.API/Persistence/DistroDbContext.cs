using Microsoft.EntityFrameworkCore;
using MoqProject.API.Models;

namespace MoqProject.API.Persistence
{
    public class DistroDbContext : DbContext
    {
        public virtual DbSet<DistributionList> DistributionLists { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
