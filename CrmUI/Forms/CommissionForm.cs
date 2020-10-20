using Crmlog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI.Forms
{

    public partial class CommissionForm : Form
    {
        public Commission Commission { get; set;}

        public CommissionForm()
        {
            InitializeComponent();
        }
        public CommissionForm(Commission commission) : this()
        {
            Commission = commission ?? new Commission();

            textBox1.Text = Commission.ComName;
            textBox2.Text = Commission.Cafedra;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Commission = Commission ?? new Commission();

            Commission.ComName = textBox1.Text;
            Commission.Cafedra = textBox2.Text;

            Close();
        }
    }
}
