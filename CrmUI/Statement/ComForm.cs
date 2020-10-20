using Crmlog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelObj = Microsoft.Office.Interop.Excel;

namespace CrmUI.Statement
{
    public partial class ComForm<T> : Form where T : class
    {
        public ComForm(DbSet<T> set, CrmContext db)
        {
            InitializeComponent();

            List<Teacher> teachers = db.Teachers.ToList();
            List<Groups> groups = db.Groups.ToList(); //принимаем данные с таблицы групп
            List<Subjects> subjects = db.Subjects.ToList(); //принимаем данные с таблицы предметов

            comboBox1.DataSource = teachers;
            comboBox1.ValueMember = "IdTeacher";
            comboBox1.DisplayMember = "Surname";

            //подключаем данные и выводим список предметов в comboBox2
            comboBox4.DataSource = subjects;
            comboBox4.ValueMember = "SubjId";
            comboBox4.DisplayMember = "SubjName";
        }

        private void ComForm_Load(object sender, EventArgs e)
        {

        }

        private void Show_Click(object sender, EventArgs e)
        {
            bool exist; //флаг поиска
            dataGridView1.CurrentCell = null;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (comboBox1.Text != dataGridView1.Rows[i].Cells[0].Value.ToString())
                {
                    if (comboBox4.Text != dataGridView1.Rows[i].Cells[4].Value.ToString())
                    {
                        if(comboBox2.Text != dataGridView1.Rows[i].Cells[1].Value.ToString())
                        {
                            if (comboBox1.Text == "" || comboBox4.Text == "")
                            {
                                MessageBox.Show("Виберіть групу та місяць", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                            dataGridView1.Rows[i].Visible = false;
                            continue;
                        }
                        
                    }
                }
                exist = false;
                for (int c = 0; c < dataGridView1.Columns.Count; c++)
                {

                    if (dataGridView1[c, i].Value.ToString() == comboBox1.Text)
                    {
                        if (comboBox4.Text == dataGridView1.Rows[i].Cells[4].Value.ToString())
                        {
                            if(comboBox2.Text == dataGridView1.Rows[i].Cells[1].Value.ToString())
                                exist = true;
                                break;
                            
                        }

                    }
                }
                if (!exist)
                {
                    dataGridView1.Rows[i].Visible = false;
                }

            }
            dataGridView1.CurrentCell = null;
        }

        private void Update_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Visible = true;

                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox4.Text = "";
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {

            if (this.dataGridView1.Rows.Count == 0)
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

        private void Excel_Click(object sender, EventArgs e)
        {
            OpenTable(dataGridView1);

        }
        public static void OpenTable(DataGridView TableInf)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //Задаем расширение имени файла по умолчанию.
            ofd.DefaultExt = "*.xls;*.xlsx";
            //Задаем строку фильтра имен файлов, которая определяет
            //варианты, доступные в поле "Файлы типа" диалогового
            //окна.
            ofd.Filter = "Excel Sheet(*.xlsx)|*.xlsx";
            //Задаем заголовок диалогового окна.
            ofd.Title = "Виберіть документ для завантаження даних";
            ExcelObj.Application app = new ExcelObj.Application();
            ExcelObj.Workbook workbook;
            ExcelObj.Worksheet NwSheet;
            ExcelObj.Range ShtRange;
            DataTable dt = new DataTable();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                workbook = app.Workbooks.Open(ofd.FileName, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value);

                //Устанавливаем номер листа из котрого будут извлекаться данные
                //Листы нумеруются от 1
                NwSheet = (ExcelObj.Worksheet)workbook.Sheets.get_Item(1);
                ShtRange = NwSheet.UsedRange;
                for (int Cnum = 1; Cnum <= ShtRange.Columns.Count; Cnum++)
                {
                    dt.Columns.Add(
                    new DataColumn((ShtRange.Cells[1, Cnum] as ExcelObj.Range).Value2.ToString()));
                }
                dt.AcceptChanges();

                string[] columnNames = new String[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    columnNames[0] = dt.Columns[i].ColumnName;
                }

                for (int Rnum = 2; Rnum <= ShtRange.Rows.Count; Rnum++)
                {
                    DataRow dr = dt.NewRow();
                    for (int Cnum = 1; Cnum <= ShtRange.Columns.Count; Cnum++)
                    {
                        if ((ShtRange.Cells[Rnum, Cnum] as ExcelObj.Range).Value2 != null)
                        {
                            dr[Cnum - 1] =
                            (ShtRange.Cells[Rnum, Cnum] as ExcelObj.Range).Value2.ToString();
                        }
                    }
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }

                TableInf.DataSource = dt;
                app.Quit();
            }
            app.Quit();
        }
    }
}
