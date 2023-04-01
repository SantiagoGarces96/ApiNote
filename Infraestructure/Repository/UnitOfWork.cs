using Core.Entities;
using Infraestructure.Data;
using Infraestructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }

        public IAcademicLevelRepository AcademicLevel { get; private set; }

        public INoteRepository Note { get; private set; }




        public UnitOfWork(AplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(db);
            AcademicLevel = new AcademicLevelRepository(db);
            Note = new NoteRepository(db);

        }


        public void Dispose()
        {
            _db.Dispose();
        }
        public async Task Save()
        {
            await _db.SaveChangesAsync();
            
            
        }

        //Task IUnitOfWork.Save()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
