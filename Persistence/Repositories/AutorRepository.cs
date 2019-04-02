using Business.Interfaces;
using DAL.SQL;
using Entities.Entities;
using Persistence.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public class AutorRepository : BaseRepository<Autor>, IAutorRepository
    {
        public AutorRepository(TiendaDbContext dbContext) : base(dbContext)
        {
        }

        public TiendaDbContext _context {get {return context;}}
    }
}
