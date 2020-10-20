using Crmlog.Model;
using Crmlog.Model.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI.Statement
{
    public partial class InputNavantazhennyaForm : Form
    {
        public Navantazhennya Navantazhennya { get; set; }

        public InputNavantazhennyaForm()
        {
            InitializeComponent();
        }

        public InputNavantazhennyaForm(Navantazhennya navantazhennya) : this()
        {
            Navantazhennya = navantazhennya ?? new Navantazhennya();

            dateTimePicker1.Value = Navantazhennya.DateTime;
            comboBox1.SelectedItem = Navantazhennya.Teacher;
            comboBox2.SelectedItem = Navantazhennya.Month;
            comboBox3.SelectedItem = Navantazhennya.TypeNav;
            textBox1.Text = Convert.ToString(Navantazhennya.QantityNav);
        }


        private void Add_Click(object sender, EventArgs e)
        {
            Navantazhennya = Navantazhennya ?? new Navantazhennya();

            Navantazhennya.DateTime = dateTimePicker1.Value;
            Navantazhennya.Teacher = (Teacher)comboBox1.SelectedItem;
            Navantazhennya.Month = (string)comboBox2.SelectedItem;
            Navantazhennya.TypeNav = (string)comboBox3.SelectedItem;
            Navantazhennya.QantityNav = Convert.ToInt32(textBox1.Text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}