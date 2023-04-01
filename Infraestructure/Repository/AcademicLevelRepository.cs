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
    public class AcademicLevelRepository : Repository<AcademicLevel>, IAcademicLevelRepository
    {
        private readonly AplicationDbContext _db;
        public AcademicLevelRepository(AplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void UpdateAcademicLevel(AcademicLevel academicLevel)
        {
            var academicLeveldb = _db.Categories.FirstOrDefault(l => l.Id == academicLevel.Id);

            if (academicLeveldb != null)
            {
                academicLeveldb.Name = academicLevel.Name;
                academicLevel.Code = academicLevel.Code;
                academicLevel.NumberSemesters = academicLevel.NumberSemesters;
                _db.SaveChanges();
            }
        }

    
    }
}
