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
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        private readonly AplicationDbContext _db;
        public NoteRepository(AplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Note note)
        {
            var noteDb = _db.Notes.FirstOrDefault(n => n.Id == note.Id);

            if (noteDb != null)
            {
                noteDb.Porcentage = note.Porcentage;
                noteDb.DateNote = note.DateNote;
                noteDb.Observation = note.Observation;
                noteDb.ValueNote = note.ValueNote;

                _db.SaveChanges();
            }
        }
    }
}
