using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crmlog.Model;
using Crmlog.Model.Forms;

namespace CrmUI.Statement
{
    public partial class InputZnattyaForm : Form
    {
        public Znattya Znattya { get; set; }

        public InputZnattyaForm()
        {
            InitializeComponent();
        }

        public InputZnattyaForm(Znattya znattya) : this()
        {
            Znattya = znattya ?? new Znattya();

            comboBox1.SelectedItem = Znattya.TypeZ;
            comboBox2.SelectedItem = Znattya.Teacher;
            comboBox3.SelectedItem = Znattya.Month;
            textBox1.Text = Convert.ToString(Znattya.Quantity);
            dateTimePicker1.Value = Znattya.DateTimeFrom;
            dateTimePicker2.Value = Znattya.DateTimeTill;

        }

        private void InputZnattya_Load(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            Znattya = Znattya ?? new Znattya();

            Znattya.TypeZ = (string)comboBox1.SelectedItem;
            Znattya.Teacher = (Teacher)comboBox2.SelectedItem;
            Znattya.Month = (string)comboBox3.SelectedItem;
            Znattya.Quantity = Convert.ToInt32(textBox1.Text);
            Znattya.DateTimeFrom = dateTimePicker1.Value;
            Znattya.DateTimeTill = dateTimePicker2.Value;

            Close();

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
