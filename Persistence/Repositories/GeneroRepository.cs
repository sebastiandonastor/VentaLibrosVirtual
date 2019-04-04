using Business.Interfaces;
using DAL.SQL;
using Entities.Entities;
using Persistence.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public class GeneroRepository : BaseRepository<Genero>, IGeneroRepository
    {
        public GeneroRepository(TiendaDbContext dbContext) : base(dbContext)
        {
        }

        public TiendaDbContext _context { get { return context; } }

    }
}
