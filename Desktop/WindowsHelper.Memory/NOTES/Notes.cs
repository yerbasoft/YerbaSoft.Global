using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.Memory.NOTES
{
    public class Notes
    {
        private string noteRepositoryPath;

        public Notes()
        {
            noteRepositoryPath = @"W:\YerbaSoft\Desktop\WindowsHelper.Memory\WindowsHelper.Memory.Notes.xml";
        }

        public static void OpenNote(object sender, EventArgs e)
        {
            var note = (NoteDTO)((ToolStripMenuItem)sender).Tag;
            var win = new EditNote(new Notes(), note);
            win.ShowDialog();
        }

        public void NewNote()
        {
            var win = new EditNote(this, new NoteDTO());
            win.ShowDialog();
        }

        YerbaSoft.DAL.IRepository<NoteDTO> _NoteRepository = null;
        YerbaSoft.DAL.IRepository<NoteDTO> NoteRepository => _NoteRepository = _NoteRepository ?? new YerbaSoft.DAL.Repositories.XmlSimpleRepository<NoteDTO>(noteRepositoryPath);

        public void Save(NoteDTO entity)
        {
            if (!entity.Id.HasValue)
                entity.Id = Guid.NewGuid();

            NoteRepository.UpsertEntity(entity);
            NoteRepository.Commit();
        }

        public void Delete(NoteDTO entity)
        {
            NoteRepository.DeleteEntity(entity);
            NoteRepository.Commit();
        }

        internal IEnumerable<NoteDTO> GetNotes()
        {
            return NoteRepository.Find().OrderBy(p => p.Title);
        }
    }
}
