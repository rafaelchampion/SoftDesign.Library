using SoftDesign.Library.Domain.Entities.Users;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using System.Data.Entity;

namespace SoftDesign.Library.Infrastructure.DataPersistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public new readonly DbContext _context;

        public UserRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}