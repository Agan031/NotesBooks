using NotesBooks.DataLayer.Repositorys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesBooks.DataLayer.Services
{
    public class NotesRepository : INotesRepository
    {
        private NotesBooks_DBEntities _db;

        public NotesRepository(NotesBooks_DBEntities db)
        {
            _db = db;
        }

        public IEnumerable<Notes_> GetNotes()
        {
            return _db.Notes_.ToList();
        }

        public Notes_ GetNotesById(int notesId)
        {
            return _db.Notes_.Find(notesId);
        }

        public IEnumerable<Notes_> GetNotesBySearch(string Parametr)
        {
            return _db.Notes_.Where(n => n.NotesTitle.Contains(Parametr)).ToList();
        }

        public void InsertNotes(Notes_ notes)
        {
            _db.Notes_.Add(notes);
        }

        public void UpdateNotes(Notes_ notes)
        {
            _db.Entry(notes).State = EntityState.Modified;
        }

        public void DeleteNotes(Notes_ notes)
        {
            _db.Entry(notes).State = EntityState.Deleted;
        }

        public void DeleteNotes(int notesId)
        {
            var notes = GetNotesById(notesId);
            DeleteNotes(notes);
        }
    }
}
