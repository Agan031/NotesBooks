using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesBooks.DataLayer.Repositorys
{
    public interface INotesRepository
    {
        IEnumerable<Notes_> GetNotes();
        Notes_ GetNotesById(int notesId);
        IEnumerable<Notes_> GetNotesBySearch(string Parametr);
        void InsertNotes(Notes_ notes);
        void UpdateNotes(Notes_ notes);
        void DeleteNotes(int notesId);
        void DeleteNotes(Notes_ notes);
    }
}
