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
    public partial class OblicTeacher<T> : Form where T : class
    {
        CrmContext db;
        DbSet<T> set;
        public OblicTeacher(DbSet<T> set, CrmContext db)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.db = db;
            this.set = set;

            List<Teacher> teachers = db.Teachers.ToList();
            List<Groups> groups = db.Groups.ToList(); //принимаем данные с таблицы групп

            comboBox1.DataSource = teachers;
            comboBox1.ValueMember = "IdTeacher";
            comboBox1.DisplayMember = "Surname";


            //подключаем данные и выводим список групп в comboBox1
            comboBox3.DataSource = groups;
            comboBox3.ValueMember = "GroupId";
            comboBox3.DisplayMember = "GroupName";
        }

        private void OblicTeacher_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
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

        private void Add_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||
                textBox4.Text == "" || textBox5.Text == "" || textBox7.Text == "" || textBox8.Text == "" ||
                textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || 
                comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Заповніть всі доступні поля", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int t1 = Convert.ToInt32(textBox1.Text);
            int t2 = Convert.ToInt32(textBox2.Text);
            int t3 = Convert.ToInt32(textBox3.Text);
            int t4 = Convert.ToInt32(textBox4.Text);
            int t5 = Convert.ToInt32(textBox5.Text);
            int t7 = Convert.ToInt32(textBox7.Text);
            int t8 = Convert.ToInt32(textBox8.Text);
            int t9 = Convert.ToInt32(textBox9.Text);
            int t10 = Convert.ToInt32(textBox10.Text);
            int t11 = Convert.ToInt32(textBox11.Text);
            int t12 = Convert.ToInt32(textBox12.Text);
            int t13 = Convert.ToInt32(textBox13.Text);

           int t6 = t1 + t2 + t3 + t4;
            textBox6.Text = Convert.ToString(t6);

            int t14 = t7 + t8 + t9 + t10 + t11 + t12;
            textBox14.Text = Convert.ToString(t14);

            int t15 = t5 + t13;
            textBox15.Text = Convert.ToString(t15);

            int t16 = t6 + t14;
            textBox16.Text = Convert.ToString(t16);


            int rownamber = dataGridView1.Rows.Add();
            dataGridView1.Rows[rownamber].Cells[0].Value = comboBox1.SelectedItem;
            dataGridView1.Rows[rownamber].Cells[1].Value = comboBox2.SelectedItem;
            dataGridView1.Rows[rownamber].Cells[2].Value = comboBox3.SelectedItem;
            dataGridView1.Rows[rownamber].Cells[3].Value = textBox1.Text;
            dataGridView1.Rows[rownamber].Cells[4].Value = textBox2.Text;
            dataGridView1.Rows[rownamber].Cells[5].Value = textBox3.Text;
            dataGridView1.Rows[rownamber].Cells[6].Value = textBox4.Text;
            dataGridView1.Rows[rownamber].Cells[7].Value = textBox5.Text;
            dataGridView1.Rows[rownamber].Cells[8].Value = textBox6.Text;
            dataGridView1.Rows[rownamber].Cells[9].Value = textBox7.Text;
            dataGridView1.Rows[rownamber].Cells[10].Value = textBox8.Text;
            dataGridView1.Rows[rownamber].Cells[11].Value = textBox9.Text;
            dataGridView1.Rows[rownamber].Cells[12].Value = textBox10.Text;
            dataGridView1.Rows[rownamber].Cells[13].Value = textBox11.Text;
            dataGridView1.Rows[rownamber].Cells[14].Value = textBox12.Text;
            dataGridView1.Rows[rownamber].Cells[15].Value = textBox13.Text;
            dataGridView1.Rows[rownamber].Cells[16].Value = textBox14.Text;
            dataGridView1.Rows[rownamber].Cells[17].Value = textBox15.Text;
            dataGridView1.Rows[rownamber].Cells[18].Value = textBox16.Text;

            // обнуляем ячейки
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}
