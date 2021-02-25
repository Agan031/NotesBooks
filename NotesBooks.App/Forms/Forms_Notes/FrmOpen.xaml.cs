using NotesBooks.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotesBooks.App.Forms.Forms_Notes
{
    /// <summary>
    /// Interaction logic for FrmOpen.xaml
    /// </summary>
    public partial class FrmOpen : Window
    {
        public int NotesId;

        public FrmOpen()
        {
            InitializeComponent();
        }

        private void FrmOpenNotes_Loaded(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork db=new UnitOfWork())
            {
                var notes=db.NotesRepository.GetNotesById(NotesId);
                lblNotesTitle.Text = notes.NotesTitle;
                lblNotes.Text = notes.Notes;
            }
        }
    }
}
