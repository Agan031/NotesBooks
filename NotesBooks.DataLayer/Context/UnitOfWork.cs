using NotesBooks.DataLayer.Repositorys;
using NotesBooks.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesBooks.DataLayer.Context
{
    public class UnitOfWork:IDisposable
    {
        private NotesBooks_DBEntities db = new NotesBooks_DBEntities();

        private INotesRepository _notesRepository;

        public INotesRepository NotesRepository
        {
            get
            {
                if(_notesRepository== null)
                {
                    _notesRepository = new NotesRepository(db);
                }
                return _notesRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
