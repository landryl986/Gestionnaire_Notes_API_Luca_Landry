using System;
using System.Collections.Generic;
using System.Linq;
using Gestionnaire_Notes_API_Luca_Landry.Data;
using Gestionnaire_Notes_API_Luca_Landry.Interfaces;
using Gestionnaire_Notes_API_Luca_Landry.Models;

namespace Gestionnaire_Notes_API_Luca_Landry.Services
{
    public class NoteService : INote
    {
        private readonly DataContext _context;

        public NoteService(DataContext context)
        {
            _context = context;
        }
        public NoteModel AddNote(NoteModel newNote)
        {
            try
            {
                _context.Notes.Add(newNote);
                _context.SaveChanges();
                return newNote;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _context.Notes.Remove(_context.Notes.FirstOrDefault(n => n.Id == id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool ExistsById(int id)
        {
            try
            {
                return _context.Notes.Any(n => n.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IList<NoteModel> GetAll()
        {
            try
            {
                return _context.Notes.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public NoteModel GetSingle(int id)
        {
            try
            {
                return _context.Notes.FirstOrDefault(n => n.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public NoteModel Update(int id, NoteModel model)
        {
            try
            {
                var note = _context.Notes.FirstOrDefault(n => n.Id == id);

                note.note = model.note;
                note.Branche = model.Branche;

                _context.SaveChanges();

                return note;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}