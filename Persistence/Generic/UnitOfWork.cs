using Business.Interfaces;
using DAL.SQL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Generic
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly TiendaDbContext _dbContext;

        public async Task<int> CompleteAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			_dbContext.Dispose();
		}

        public UnitOfWork(TiendaDbContext dbContext)
        {
            //Todos los repositorios aca papa;
            _dbContext = dbContext;
        }
    }
}
