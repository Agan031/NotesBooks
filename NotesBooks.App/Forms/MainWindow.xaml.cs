using NotesBooks.App.Forms.Forms_Notes;
using NotesBooks.DataLayer;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotesBooks.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindows_Loaded(object sender, RoutedEventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var DataSource = db.NotesRepository.GetNotes();

                DGVNotes.AutoGenerateColumns = false;
                DGVNotes.ItemsSource = DataSource;
            }
        }

        private void btnOpenNotes_Click(object sender, RoutedEventArgs e)
        {
            if (DGVNotes.CurrentColumn != null)
            {
                Notes_ getNotesId = (Notes_)DGVNotes.CurrentItem;
                var notesId=getNotesId.NotesId;

                FrmOpen frmOpen = new FrmOpen();
                frmOpen.NotesId = notesId;
                frmOpen.ShowDialog();
            }
            else
            {
                RtlMessageBox.Show("لطفا یک یادداشت را از درون لیست انتخاب کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
