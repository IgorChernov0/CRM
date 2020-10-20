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

namespace CrmUI.Statement
{
    public partial class Planavoe<T> : Form where T : class
    {
        public Planavoe(DbSet<T> set, CrmContext db)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            List<Teacher> teachers = db.Teachers.ToList();
            List<Commission> commissions = db.Commissions.ToList(); //принимаем данные с таблицы комиссии


            comboBox2.DataSource = teachers;
            comboBox2.ValueMember = "IdTeacher";
            comboBox2.DisplayMember = "Surname";


            //подключаем данные и выводим список комиссий в comboBox1
            comboBox3.DataSource = commissions;
            comboBox3.ValueMember = "ComId";
            comboBox3.DisplayMember = "ComName";

        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox7.Text == "" || textBox8.Text == "" || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Заповніть всі доступні поля", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            int t1 = Convert.ToInt32(textBox1.Text);
            int t3 = Convert.ToInt32(textBox3.Text);
            int t2 = Convert.ToInt32(textBox2.Text);
            int t4 = Convert.ToInt32(textBox4.Text);
            int t7 = Convert.ToInt32(textBox7.Text);
            int t8 = Convert.ToInt32(textBox8.Text);

            int t5 = t1 - t3;
            textBox5.Text = Convert.ToString(t5);// считаем и выводим автоматически ячейку "зняття бюджет"
            int t6 = t2 - t4;
            textBox6.Text = Convert.ToString(t6);// считаем и выводим автоматически ячейку "зняття контракт"

            int t9 = t5 - t7;
            int t10 = t6 - t8;

            //считаем разницу между зняттям и выконано
            if (t9 > 0 && t10 > 0)
            {
                textBox9.Text = Convert.ToString(t9);
                textBox10.Text = Convert.ToString(t10);

                textBox11.Text = "0";
                textBox12.Text = "0";
            }
            else
            {
                int t11;
                int t12;

                textBox9.Text = "0";
                textBox10.Text = "0";

                t11 = t7 - t5;
                t12 = t8 - t6;

                textBox11.Text = Convert.ToString(t11);
                textBox12.Text = Convert.ToString(t12);
            }

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
        }

        private void Excel_Click(object sender, EventArgs e)
        {
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
    }
}
