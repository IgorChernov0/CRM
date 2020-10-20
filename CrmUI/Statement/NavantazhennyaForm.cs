using Crmlog.Model;
using Crmlog.Model.Forms;
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
using ExcelObj = Microsoft.Office.Interop.Excel;


namespace CrmUI.Statement
{
    public partial class NavantazhennyaForm<T> : Form where T : class
    {
        CrmContext db;
        DbSet<T> set;
        public NavantazhennyaForm(DbSet<T> set, CrmContext db)
        {
            InitializeComponent();

            this.db = db;
            this.set = set;
            set.Load(); // загружаем все данные
            dataGridView.DataSource = set.Local.ToBindingList();
        }

        private void Change_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count ==0)
            {
                MessageBox.Show("Виберіть хочаб одну строку в таблиці", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var id = dataGridView.SelectedRows[0].Cells[0].Value;
            List<Teacher> teachers = db.Teachers.ToList();

            var navantazhennya = set.Find(id) as Navantazhennya;
            if (navantazhennya != null)
            {
                InputNavantazhennyaForm inputNavantazhennyaForm = new InputNavantazhennyaForm(navantazhennya);
                //подключаем данные и выводим список преподавателей в comboBox1
                inputNavantazhennyaForm.comboBox1.DataSource = teachers;
                inputNavantazhennyaForm.comboBox1.ValueMember = "IdTeacher";
                inputNavantazhennyaForm.comboBox1.DisplayMember = "Surname";

                if (inputNavantazhennyaForm.ShowDialog() == DialogResult.OK)
                {
                    db.SaveChanges();
                    dataGridView.Refresh();
                }
            }
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView.Columns["NavantazhId"].Visible = false;

            dataGridView.Columns["TeacherIdTeacher"].Visible = false;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count == 0)
            {
                MessageBox.Show("Виберіть хочаб одну строку в таблиці", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int delet = dataGridView.SelectedCells[0].RowIndex;
            dataGridView.Rows.RemoveAt(delet);
            db.SaveChanges();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Visible = true;

            }
            //comboBox1.Text = "";
            //comboBox1.Text = "";

        }

        private void Filter_Click(object sender, EventArgs e)
        {

            bool exist; //флаг поиска
            dataGridView.CurrentCell = null;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (comboBox1.Text != dataGridView.Rows[i].Cells[4].Value.ToString())
                {
                    if (comboBox2.Text != dataGridView.Rows[i].Cells[5].Value.ToString())
                    {
                        if (comboBox1.Text == "" || comboBox2.Text == "")
                        {
                            MessageBox.Show("Виберіть групу та місяць", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        dataGridView.Rows[i].Visible = false;
                        continue;
                    }

                }
                exist = false;
                for (int c = 0; c < dataGridView.Columns.Count; c++)
                {

                    if (dataGridView[c, i].Value.ToString() == comboBox1.Text)
                    {
                        if (comboBox2.Text == dataGridView.Rows[i].Cells[5].Value.ToString())
                            exist = true;
                        break;

                    }
                }
                if (!exist)
                {
                    dataGridView.Rows[i].Visible = false;
                }

            }
            dataGridView.CurrentCell = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Нема даних для вивантаження в Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ExcelObj.Application xlApp;
            ExcelObj.Workbook xlWB;
            ExcelObj.Worksheet xlSht;

            xlApp = new ExcelObj.Application();
            xlWB = xlApp.Workbooks.Add();
            xlSht = xlWB.Worksheets[1]; //первый по порядку лист в книге Excel


            int RowCount = this.dataGridView.RowCount;
            int ColumnCount = this.dataGridView.ColumnCount;
            object[,] ArrData = new object[RowCount, ColumnCount];

            for (int j = 0; j < RowCount; j++)
            {
                for (int i = 0; i < ColumnCount; i++)
                {
                    if (j != this.dataGridView.NewRowIndex)
                        if (dataGridView.Rows[j].Cells[i].Value == null)
                            dataGridView.Rows[j].Cells[i].Value = "0";
                    ArrData[j, i] = dataGridView.Rows[j].Cells[i].Value.ToString();
                }
            }

            //выгрузка данных на лист Excel
            xlSht.Range["A2"].Resize[ArrData.GetUpperBound(0) + 1, ArrData.GetUpperBound(1) + 1].Value = ArrData;
            //переносим названия столбцов в Excel файл
            for (int j = 0; j < this.dataGridView.Columns.Count; j++)
                xlSht.Cells[1, j + 1] = this.dataGridView.Columns[j].HeaderCell.Value.ToString();

            //украшательство таблицы
            xlSht.Rows[1].Font.Bold = true;
            xlSht.Range["A:AF"].EntireColumn.AutoFit();

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
    }
}
