using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace Laba2DataBase
{
    public partial class MainForm : Form
    {

        Dictionary<string, BaseUC> pages =
            new Dictionary<string, BaseUC>()
            {
                { "Authors", new AuthorsUC() },
                { "Publishers", new UserControls.PublishersUC() },
                { "Lecturers", new UserControls.LecturerUC()},
                { "Students", new UserControls.StudentsUC()},
                { "LibraryStaff", new UserControls.LibraryStaffUC()},
                { "Group",new UserControls.GroupUC() },
                { "Faculty",new UserControls.FacultyUC()},
                { "LecturerCard",new UserControls.LecturerCardUC() },
                { "StudentsCard",new UserControls.StudentsCardUC() },
                { "Book",new UserControls.BookUC() },
                 { "BookandAuthor",new UserControls.BookandAuthorUC() },
                  { "Delivery of books",new UserControls.StaffUC() }
            };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, BaseUC> item in pages)
            {
                TabPage page = new TabPage(item.Key);
                page.Controls.Add(item.Value);

                MainTabControl.TabPages.Add(page);
            }
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}