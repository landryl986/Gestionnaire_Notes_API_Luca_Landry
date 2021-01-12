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
        public createNoteDTO AddNote(createNoteDTO newNote)
        {
            try
            {
                var note = new NoteModel();

                note.note = newNote.note;
                note.BrancheId = newNote.BrancheId;
                
                _context.Notes.Add(note);
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
                _context.SaveChanges();
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

        public PatchNoteModel Update(int id, PatchNoteModel model)
        {
            try
            {
                var note = _context.Notes.FirstOrDefault(n => n.Id == id);

                note.note = model.note;
                note.BrancheId = model.BrancheId;

                _context.SaveChanges();

                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}