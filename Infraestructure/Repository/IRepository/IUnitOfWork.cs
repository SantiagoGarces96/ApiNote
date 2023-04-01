using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }

        IAcademicLevelRepository AcademicLevel { get; }
        INoteRepository Note { get; }

        Task Save();

       
    }

    
}
