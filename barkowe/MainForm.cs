using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barkowe
{
    
    public partial class MainForm : Form
    {
        ToDoList_DBDataContext db;
        Task task;
        public MainForm()
        {
            InitializeComponent();
            db = new ToDoList_DBDataContext();

            foreach (Task t in db.Tasks)
            {
                ToDoListField sc = new ToDoListField(t, db);
                flowLayoutPanel1.Controls.Add(sc);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Task temp = new Task
            {
                is_completed = false,
                content = ""
            };
            ToDoListField sc = new ToDoListField(temp, db);
            flowLayoutPanel1.Controls.Add(sc);
            db.Tasks.InsertOnSubmit(temp);
            db.SubmitChanges();
            
        }


    }
}
