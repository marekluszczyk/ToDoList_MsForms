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
     
    public partial class ToDoListField : UserControl
    {
        ToDoList_DBDataContext db;
        Task task;
        public ToDoListField(Task t, ToDoList_DBDataContext db)
        {
            InitializeComponent();
            this.db = db;
            this.task = t;
            checkBox1.Text = "To do";
            textBox1.Text = t.content;
            if (t.is_completed) { checkBox1.Checked = true; } else { checkBox1.Checked = false; }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.Tasks.DeleteOnSubmit(task);
            db.SubmitChanges();

            this.Parent.Controls.Remove(this);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                checkBox1.Text = "Done";
               task.is_completed = true;
            }
            else
            {
                checkBox1.Text = "To Do";
                task.is_completed = false;
            }
            
            db.SubmitChanges();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            task.content = textBox1.Text;

            db.SubmitChanges();
        }
    }
}
