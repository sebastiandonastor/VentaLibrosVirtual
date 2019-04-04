using Business.Interfaces;
using DAL.SQL;
using Entities.Entities;
using Persistence.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public class GeneroLibroRepository : BaseRepository<GenerosLibros>, IGeneroLibroRepository
    {
        public GeneroLibroRepository(TiendaDbContext dbContext) : base(dbContext)
        {
        }

        public TiendaDbContext _context { get { return context; } }

    }
}
