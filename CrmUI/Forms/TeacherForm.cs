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
    public partial class TeacherForm : Form
    {
        public Teacher Teacher { get; set; }
        public Commission Commission { get; set; }

        public TeacherForm()
        {
            InitializeComponent();

        }
        public TeacherForm(Teacher teacher) : this()
        {
            Teacher = teacher ?? new Teacher();

            
            textBox1.Text = Teacher.Name;
            textBox2.Text = Teacher.Surname;
            textBox3.Text = Teacher.Patronymic;
            

            comboBox1.SelectedItem = Teacher.Commission;
            comboBox2.SelectedItem = Teacher.Subjects;

        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Teacher = Teacher ?? new Teacher();
            Teacher.Name = textBox1.Text;
            Teacher.Surname = textBox2.Text;
            Teacher.Patronymic = textBox3.Text;
            Teacher.Commission = (Commission)comboBox1.SelectedItem;
            Teacher.Subjects = (Subjects)comboBox2.SelectedItem;
            
            Close();
        }
    }
}
