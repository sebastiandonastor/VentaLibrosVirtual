using Business.Interfaces;
using DAL.SQL;
using Entities.Entities;
using Persistence.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public class CompraRepository : BaseRepository<Compra>, ICompraRepository
    {
        public CompraRepository(TiendaDbContext dbContext) : base(dbContext)
        {
        }

        public TiendaDbContext _context { get { return context; } }

    }
}
