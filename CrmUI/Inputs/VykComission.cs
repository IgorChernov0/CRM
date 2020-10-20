using Crmlog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CrmUI.Inputs
{
    public partial class VykComission<T> : Form where T : class
    {
        CrmContext db;
        DbSet<T> set;
        public VykComission(DbSet<T> set, CrmContext db)
        {
            InitializeComponent();
            this.db = db;
            this.set = set;

            List<Teacher> teachers = db.Teachers.ToList();
            List<Groups> groups = db.Groups.ToList(); //принимаем данные с таблицы групп
            List<Subjects> subjects = db.Subjects.ToList(); //принимаем данные с таблицы предметов

            comboBox1.DataSource = teachers;
            comboBox1.ValueMember = "IdTeacher";
            comboBox1.DisplayMember = "Surname";


            //подключаем данные и выводим список групп в comboBox1
            comboBox3.DataSource = groups;
            comboBox3.ValueMember = "GroupId";
            comboBox3.DisplayMember = "GroupName";

            //подключаем данные и выводим список предметов в comboBox2
            comboBox4.DataSource = subjects;
            comboBox4.ValueMember = "SubjId";
            comboBox4.DisplayMember = "ShortName";
        }

        private void Add_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox7.Text == "" || textBox8.Text == "" ||
                textBox9.Text == "" || textBox10.Text == "" ||
                comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null || comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Заповніть всі доступні поля", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int t1 = Convert.ToInt32(textBox1.Text);
            int t2 = Convert.ToInt32(textBox2.Text);
            int t7 = Convert.ToInt32(textBox7.Text);
            int t8 = Convert.ToInt32(textBox8.Text);
            int t9 = Convert.ToInt32(textBox9.Text);
            int t10 = Convert.ToInt32(textBox10.Text);

            int t5 = t1 + t2;
            textBox5.Text = Convert.ToString(t5);

            int t3 = t7 + t8 + t9 + t10;
            textBox3.Text = Convert.ToString(t3);

            int rownamber = dataGridView1.Rows.Add();
            dataGridView1.Rows[rownamber].Cells[0].Value = comboBox1.SelectedItem;
            dataGridView1.Rows[rownamber].Cells[1].Value = comboBox5.SelectedItem;
            dataGridView1.Rows[rownamber].Cells[2].Value = comboBox2.SelectedItem;
            dataGridView1.Rows[rownamber].Cells[3].Value = comboBox3.SelectedItem;
            dataGridView1.Rows[rownamber].Cells[4].Value = comboBox4.SelectedItem;
            dataGridView1.Rows[rownamber].Cells[5].Value = textBox1.Text;
            dataGridView1.Rows[rownamber].Cells[6].Value = textBox2.Text;
            dataGridView1.Rows[rownamber].Cells[7].Value = textBox5.Text;
            dataGridView1.Rows[rownamber].Cells[8].Value = textBox7.Text;
            dataGridView1.Rows[rownamber].Cells[9].Value = textBox8.Text;
            dataGridView1.Rows[rownamber].Cells[10].Value = textBox9.Text;
            dataGridView1.Rows[rownamber].Cells[11].Value = textBox10.Text;
            dataGridView1.Rows[rownamber].Cells[12].Value = textBox3.Text;
        }

        private void Excel_Click(object sender, EventArgs e)
        {
            //проверка на вместимость данных
            if (this.dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Нема даних для вивантаження в Excel!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Вивантажити знайдені рядки Excel?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            Excel.Application xlApp;
            Excel.Workbook xlWB;
            Excel.Worksheet xlSht;

            xlApp = new Excel.Application();
            xlWB = xlApp.Workbooks.Add();
            xlSht = xlWB.Worksheets[1]; //первый по порядку лист в книге Excel

            // вывод данных в каждую ячейку ексель файла
            int RowCount = this.dataGridView1.RowCount;
            int ColumnCount = this.dataGridView1.ColumnCount;
            object[,] ArrData = new object[RowCount, ColumnCount];

            for (int j = 0; j < RowCount; j++)
            {
                for (int i = 0; i < ColumnCount; i++)
                {
                    if (j != this.dataGridView1.NewRowIndex)
                        if (dataGridView1.Rows[j].Cells[i].Value == null)
                            dataGridView1.Rows[j].Cells[i].Value = "0";
                    ArrData[j, i] = dataGridView1.Rows[j].Cells[i].Value.ToString();
                }
            }

            //выгрузка данных на лист Excel
            xlSht.Range["A2"].Resize[ArrData.GetUpperBound(0) + 1, ArrData.GetUpperBound(1) + 1].Value = ArrData;
            //переносим названия столбцов в Excel файл
            for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                xlSht.Cells[1, j + 1] = this.dataGridView1.Columns[j].HeaderCell.Value.ToString();

            //украшательство таблицы
            xlSht.Rows[1].Font.Bold = true;
            xlSht.Range["A:AK"].EntireColumn.AutoFit();

            // сохранения файла excel
            DialogResult res = MessageBox.Show("Експорт завершений. При натисканні <Yes> буде відкрито сгенерований файл, " +
                "при натисканні <No> буде запропоновано зберегти файл.", "Експорт в Excel", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Yes)
            { xlApp.Visible = true; }
            if (res == DialogResult.No)
            {
                string fileName = String.Empty;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog1.FileName;
                }
                else
                    return;
                //сохраняем Workbook
                xlWB.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                //отображаем Excel
                xlApp.Visible = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}
