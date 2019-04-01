using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUnitOfWork
    {
          Task<int> CompleteAsync();
          void Dispose();

        ILibroRepository Libros { get; }
    }
}
