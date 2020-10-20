using Crmlog.Model;
using Crmlog.Model.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ExcelObj = Microsoft.Office.Interop.Excel;


namespace CrmUI.Statement
{
    public partial class Second<T> : Form where T : class
    {
        CrmContext db;
        DbSet<T> set;

        public Second(DbSet<T> set, CrmContext db)
        {
            InitializeComponent();

            this.db = db;
            this.set = set;
            set.Load(); // загружаем все данные
            this.WindowState = FormWindowState.Maximized;

        }

        private void Second_Load(object sender, EventArgs e)
        {
            List<Groups> groups = db.Groups.ToList(); //принимаем данные с таблицы групп

            comboBox1.DataSource = groups;
            comboBox1.ValueMember = "GroupId";
            comboBox1.DisplayMember = "GroupName";
            comboBox1.Text = "";

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

        private void Show_Click(object sender, EventArgs e)
        {

            bool exist; //флаг поиска
            dataGridView1.CurrentCell = null;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (comboBox1.Text != dataGridView1.Rows[i].Cells[0].Value.ToString())
                {
                    if (comboBox2.Text != dataGridView1.Rows[i].Cells[3].Value.ToString())
                    {
                        if (comboBox1.Text == "" || comboBox2.Text == "")
                        {
                            MessageBox.Show("Виберіть групу та місяць", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        dataGridView1.Rows[i].Visible = false;
                        continue;
                    }

                }
                exist = false;
                for (int c = 0; c < dataGridView1.Columns.Count; c++)
                {

                    if (dataGridView1[c, i].Value.ToString() == comboBox1.Text)
                    {
                        if (comboBox2.Text == dataGridView1.Rows[i].Cells[3].Value.ToString())
                            exist = true;
                        break;

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

            }
            comboBox2.Text = "";
            comboBox1.Text = "";

            dataGridView2.Rows.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Count_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Виберіть файл", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int SumTotal = 0;
            int Sum1 = 0;
            int Sum2 = 0;
            int Sum3 = 0;
            int Sum4 = 0;
            int Sum5 = 0;
            int Sum6 = 0;
            int Sum7 = 0;
            int Sum8 = 0;
            int Sum9 = 0;
            int Sum10 = 0;
            int Sum11 = 0;
            int Sum12 = 0;
            int Sum13 = 0;
            int Sum14 = 0;
            int Sum15 = 0;
            int Sum16 = 0;
            int Sum17 = 0;
            int Sum18 = 0;
            int Sum19 = 0;
            int Sum20 = 0;
            int Sum21 = 0;
            int Sum22 = 0;
            int Sum23 = 0;
            int Sum24 = 0;
            int Sum25 = 0;
            int Sum26 = 0;
            int Sum27 = 0;
            int Sum28 = 0;
            int Sum29 = 0;
            int Sum30 = 0;
            int Sum31 = 0;
            int counter;



            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["Given"].Visible)
                    SumTotal += int.Parse(dataGridView1.Rows[counter].Cells["Given"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["1"].Visible)
                    Sum1 += int.Parse(dataGridView1.Rows[counter].Cells["1"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["2"].Visible)
                    Sum2 += int.Parse(dataGridView1.Rows[counter].Cells["2"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["3"].Visible)
                    Sum3 += int.Parse(dataGridView1.Rows[counter].Cells["3"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["4"].Visible)
                    Sum4 += int.Parse(dataGridView1.Rows[counter].Cells["4"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["5"].Visible)
                    Sum5 += int.Parse(dataGridView1.Rows[counter].Cells["5"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["6"].Visible)
                    Sum6 += int.Parse(dataGridView1.Rows[counter].Cells["6"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["7"].Visible)
                    Sum7 += int.Parse(dataGridView1.Rows[counter].Cells["7"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["8"].Visible)
                    Sum8 += int.Parse(dataGridView1.Rows[counter].Cells["8"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["9"].Visible)
                    Sum9 += int.Parse(dataGridView1.Rows[counter].Cells["9"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["10"].Visible)
                    Sum10 += int.Parse(dataGridView1.Rows[counter].Cells["10"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["11"].Visible)
                    Sum11 += int.Parse(dataGridView1.Rows[counter].Cells["11"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["12"].Visible)
                    Sum12 += int.Parse(dataGridView1.Rows[counter].Cells["12"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["13"].Visible)
                    Sum13 += int.Parse(dataGridView1.Rows[counter].Cells["13"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["14"].Visible)
                    Sum14 += int.Parse(dataGridView1.Rows[counter].Cells["14"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["15"].Visible)
                    Sum15 += int.Parse(dataGridView1.Rows[counter].Cells["15"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["16"].Visible)
                    Sum16 += int.Parse(dataGridView1.Rows[counter].Cells["16"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["17"].Visible)
                    Sum17 += int.Parse(dataGridView1.Rows[counter].Cells["17"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["18"].Visible)
                    Sum18 += int.Parse(dataGridView1.Rows[counter].Cells["18"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["19"].Visible)
                    Sum19 += int.Parse(dataGridView1.Rows[counter].Cells["19"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["20"].Visible)
                    Sum20 += int.Parse(dataGridView1.Rows[counter].Cells["20"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["21"].Visible)
                    Sum21 += int.Parse(dataGridView1.Rows[counter].Cells["21"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["22"].Visible)
                    Sum22 += int.Parse(dataGridView1.Rows[counter].Cells["22"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["23"].Visible)
                    Sum23 += int.Parse(dataGridView1.Rows[counter].Cells["23"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["24"].Visible)
                    Sum24 += int.Parse(dataGridView1.Rows[counter].Cells["24"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["25"].Visible)
                    Sum25 += int.Parse(dataGridView1.Rows[counter].Cells["25"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["26"].Visible)
                    Sum26 += int.Parse(dataGridView1.Rows[counter].Cells["26"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["27"].Visible)
                    Sum27 += int.Parse(dataGridView1.Rows[counter].Cells["27"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["28"].Visible)
                    Sum28 += int.Parse(dataGridView1.Rows[counter].Cells["28"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["29"].Visible)
                    Sum29 += int.Parse(dataGridView1.Rows[counter].Cells["29"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["30"].Visible)
                    Sum30 += int.Parse(dataGridView1.Rows[counter].Cells["30"].Value.ToString());
            }
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                if (dataGridView1.Rows[counter].Cells["31"].Visible)
                    Sum31 += int.Parse(dataGridView1.Rows[counter].Cells["31"].Value.ToString());
            }


            label1.Text = comboBox1.Text + " Total: " + SumTotal.ToString();
            label2.Text = "Перше: " + Sum1.ToString();
            label3.Text = "Друге: " + Sum2.ToString();
            label4.Text = "Третє: " + Sum3.ToString();
            label5.Text = "Четверте: " + Sum4.ToString();
            label6.Text = "П'яте: " + Sum5.ToString();
            label7.Text = "Шосте: " + Sum6.ToString();
            label8.Text = "Сьоме: " + Sum7.ToString();
            label9.Text = "Восьме: " + Sum8.ToString();
            label10.Text = "Дев'яте: " + Sum9.ToString();
            label11.Text = "Десяте: " + Sum10.ToString();
            label12.Text = "Одинадцяте: " + Sum11.ToString();
            label13.Text = "Дванадцяте: " + Sum12.ToString();
            label14.Text = "Тринадцяте: " + Sum13.ToString();
            label15.Text = "Чотирнадцяте: " + Sum14.ToString();
            label16.Text = "П'ятнадцяте: " + Sum15.ToString();
            label17.Text = "Шістнядцяте: " + Sum16.ToString();
            label18.Text = "Сімнадцяте: " + Sum17.ToString();
            label19.Text = "Вісімнадцяте: " + Sum18.ToString();
            label20.Text = "Дев'ятнадцяте: " + Sum19.ToString();
            label21.Text = "Двадцяте: " + Sum20.ToString();
            label22.Text = "Двадцять перше: " + Sum21.ToString();
            label23.Text = "Двадцять друге: " + Sum22.ToString();
            label24.Text = "Двадцять третє: " + Sum23.ToString();
            label25.Text = "Двадцять четверте: " + Sum24.ToString();
            label26.Text = "Двадцять п'яте: " + Sum25.ToString();
            label27.Text = "Двадцять шосте: " + Sum26.ToString();
            label28.Text = "Двадцять сьоме: " + Sum27.ToString();
            label29.Text = "Двадцять восьме: " + Sum28.ToString();
            label30.Text = "Двадцять дев'яте: " + Sum29.ToString();
            label31.Text = "Тридцяте: " + Sum30.ToString();
            label32.Text = "Тридцять перше: " + Sum31.ToString();





            int rownamber = dataGridView2.Rows.Add();
            dataGridView2.Rows[rownamber].Cells[0].Value = label1.Text;
            dataGridView2.Rows[rownamber].Cells[1].Value = Sum1.ToString();
            dataGridView2.Rows[rownamber].Cells[2].Value = Sum2.ToString();
            dataGridView2.Rows[rownamber].Cells[3].Value = Sum3.ToString();
            dataGridView2.Rows[rownamber].Cells[4].Value = Sum4.ToString();
            dataGridView2.Rows[rownamber].Cells[5].Value = Sum5.ToString();
            dataGridView2.Rows[rownamber].Cells[6].Value = Sum6.ToString();
            dataGridView2.Rows[rownamber].Cells[7].Value = Sum7.ToString();
            dataGridView2.Rows[rownamber].Cells[8].Value = Sum8.ToString();
            dataGridView2.Rows[rownamber].Cells[9].Value = Sum9.ToString();
            dataGridView2.Rows[rownamber].Cells[10].Value = Sum10.ToString();
            dataGridView2.Rows[rownamber].Cells[11].Value = Sum11.ToString();
            dataGridView2.Rows[rownamber].Cells[12].Value = Sum12.ToString();
            dataGridView2.Rows[rownamber].Cells[13].Value = Sum13.ToString();
            dataGridView2.Rows[rownamber].Cells[14].Value = Sum14.ToString();
            dataGridView2.Rows[rownamber].Cells[15].Value = Sum15.ToString();
            dataGridView2.Rows[rownamber].Cells[16].Value = Sum16.ToString();
            dataGridView2.Rows[rownamber].Cells[17].Value = Sum17.ToString();
            dataGridView2.Rows[rownamber].Cells[18].Value = Sum18.ToString();
            dataGridView2.Rows[rownamber].Cells[19].Value = Sum19.ToString();
            dataGridView2.Rows[rownamber].Cells[20].Value = Sum20.ToString();
            dataGridView2.Rows[rownamber].Cells[21].Value = Sum21.ToString();
            dataGridView2.Rows[rownamber].Cells[22].Value = Sum22.ToString();
            dataGridView2.Rows[rownamber].Cells[23].Value = Sum23.ToString();
            dataGridView2.Rows[rownamber].Cells[24].Value = Sum24.ToString();
            dataGridView2.Rows[rownamber].Cells[25].Value = Sum25.ToString();
            dataGridView2.Rows[rownamber].Cells[26].Value = Sum26.ToString();
            dataGridView2.Rows[rownamber].Cells[27].Value = Sum27.ToString();
            dataGridView2.Rows[rownamber].Cells[28].Value = Sum28.ToString();
            dataGridView2.Rows[rownamber].Cells[29].Value = Sum29.ToString();
            dataGridView2.Rows[rownamber].Cells[30].Value = Sum30.ToString();
            dataGridView2.Rows[rownamber].Cells[31].Value = Sum31.ToString();


            int Nachit = Sum1 + Sum2 + Sum3 + Sum4 + Sum5 + Sum6 + Sum7 + Sum8 + Sum9 + Sum10 + Sum10 + Sum11 + Sum12
+ Sum13 + Sum14 + Sum15 + Sum16 + Sum17 + Sum18 + Sum19 + Sum20 + Sum21 + Sum22 + Sum23 + Sum24
+ Sum25 + Sum26 + Sum27 + Sum28 + Sum29 + Sum30 + Sum31;

            label35.Text = "Сума всього: " + Nachit;

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Нема даних для вивантаження в Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Нема даних для вивантаження в Excel!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ExcelObj.Application xlApp;
            ExcelObj.Workbook xlWB;
            ExcelObj.Worksheet xlSht;

            xlApp = new ExcelObj.Application();
            xlApp.SheetsInNewWorkbook = 2;
            xlWB = xlApp.Workbooks.Add(Type.Missing);
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
            xlSht.Range["A:AJ"].EntireColumn.AutoFit();



            xlSht = xlWB.Worksheets[2]; //первый по порядку лист в книге Excel

            int RowCounts = this.dataGridView2.RowCount;
            int ColumnCounts = this.dataGridView2.ColumnCount;
            object[,] arrData = new object[RowCounts, ColumnCounts];
            for (int j = 0; j < RowCounts; j++)
            {
                for (int i = 0; i < ColumnCounts; i++)
                {
                    if (j != this.dataGridView2.NewRowIndex)
                        if (dataGridView2.Rows[j].Cells[i].Value == null)
                            dataGridView2.Rows[j].Cells[i].Value = "0";
                    arrData[j, i] = dataGridView2.Rows[j].Cells[i].Value.ToString();
                }
            }

            //выгрузка данных на лист Excel
            xlSht.Range["A2"].Resize[arrData.GetUpperBound(0) + 1, arrData.GetUpperBound(1) + 1].Value = arrData;
            //переносим названия столбцов в Excel файл
            for (int j = 0; j < this.dataGridView2.Columns.Count; j++)
                xlSht.Cells[1, j + 1] = this.dataGridView2.Columns[j].HeaderCell.Value.ToString();

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

