using Business.Interfaces;
using DAL.SQL;
using Persistence.Repositories;
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
            Libros = new LibroRepository(_dbContext);
            Autores = new AutorRepository(_dbContext);
            AutoresLibros = new AutoresLibrosRepository(_dbContext);
            Compras = new CompraRepository(_dbContext);
            ComprasLibros = new CompraLibroRepository(_dbContext);
            DetallesUsuarios = new DetalleUsuarioRepository(_dbContext);
            GenerosLibors = new GeneroLibroRepository(_dbContext);
            Generos = new GeneroRepository(_dbContext);

        }

           public ILibroRepository Libros {get; private set; }

        public IAutorRepository Autores {get; private set; }

        public IAutoresLibrosRepository AutoresLibros { get; private set; }

        public ICompraRepository Compras { get; private set; }

        public ICompraLibroRepository ComprasLibros { get; private set; }

        public IDetalleUsuarioRepository DetallesUsuarios { get; private set; }

        public IGeneroLibroRepository GenerosLibors { get; private set; }

        public IGeneroRepository Generos {get; private set; }
    }
}
