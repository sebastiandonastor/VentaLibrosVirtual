using Business.Interfaces;
using DAL.SQL;
using Entities.Entities;
using Persistence.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public class AutoresLibrosRepository : BaseRepository<AutoresLibros>, IAutoresLibrosRepository
    {
        public AutoresLibrosRepository(TiendaDbContext dbContext) : base(dbContext)
        {
        }
        public TiendaDbContext _context { get { return context; } }



    }
}
