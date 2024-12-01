using SoftDesign.Library.Domain.Entities.Rentals;
using SoftDesign.Library.Domain.Interfaces.Repositories;
using System.Data.Entity;

namespace SoftDesign.Library.Infrastructure.DataPersistence.Repositories
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        private readonly DbContext _context;

        public RentalRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}