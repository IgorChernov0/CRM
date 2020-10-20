using Crmlog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class SubjectForm : Form

    {
        public Subjects Subject { get; set; }

        public SubjectForm()
        {
            InitializeComponent();
        }
        public SubjectForm(Subjects subjects) : this()
        {
            Subject = subjects ?? new Subjects();
            textBox1.Text = Subject.SubjName;
            textBox2.Text = Subject.ShortName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subject = Subject ?? new Subjects();
            Subject.SubjName = textBox1.Text;
            Subject.ShortName = textBox2.Text;


        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {

        }
    }
}
