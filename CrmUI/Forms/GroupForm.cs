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

namespace CrmUI.Forms
{
    public partial class GroupForm : Form
    {
        public Groups Groups { get; set; }

        public GroupForm()
        {
            InitializeComponent();
        }

        public GroupForm(Groups groups) : this()
        {
            Groups = groups ?? new Groups();

            textBox1.Text = Groups.GroupName;
            comboBox1.SelectedItem = Groups.Commission;
        }

        private void Add_Click(object sender, EventArgs e)
        {

            Groups = Groups ?? new Groups();
            Groups.GroupName = textBox1.Text;
            Groups.Commission = (Commission)comboBox1.SelectedItem;

            Close();
        }
    }
}
