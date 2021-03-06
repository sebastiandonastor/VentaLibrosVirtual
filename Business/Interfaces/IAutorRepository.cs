﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IAutorRepository : IBaseRepository<Autor>
    {
        void Update(Autor autorToUpdate, Autor autor);
        void SoftRemove(Autor autor);
    }
}
