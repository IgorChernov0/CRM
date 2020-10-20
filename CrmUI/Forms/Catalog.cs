using Crmlog.Model;
using CrmUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Catalog<T> : Form where T : class
    {
        CrmContext db;
        DbSet<T> set;
        public Catalog(DbSet<T> set, CrmContext db)
        {
            InitializeComponent();
            //подтягиваем данные из таблиц
            this.db = db;
            this.set = set;
            set.Load(); // загружаем все данные
            dataGridView.DataSource = set.Local.ToBindingList();


        }

        private void Catalog_Load(object sender, EventArgs e)
        {



        }

        private void Change_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count == 0)
            {
                MessageBox.Show("Виберіть хочаб одну строку в таблиці", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // идентификатор записи 
            // вызываем форму таблиц и редактируем выделенную строку
            var id = dataGridView.SelectedRows[0].Cells[0].Value;
            List<Commission> commissions = db.Commissions.ToList(); //принимаем данные с таблицы комиссии
            List<Subjects> subjects = db.Subjects.ToList(); //принимаем данные с таблицы предметов


            if (typeof(T) == typeof(Subjects))
            {
                var subject = set.Find(id) as Subjects;
                if (subject != null)
                {
                    var form = new SubjectForm(subject);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        subject = form.Subject;
                        db.SaveChanges();
                        dataGridView.Refresh();
                    }
                }
            }
            else if (typeof(T) == typeof(Teacher))
            {
                var teacher = set.Find(id) as Teacher;
                if (teacher != null)
                {
                    TeacherForm teacherForm = new TeacherForm(teacher);
                    //подключаем данные и выводим список комиссий в comboBox1
                    teacherForm.comboBox1.DataSource = commissions;
                    teacherForm.comboBox1.ValueMember = "ComId";
                    teacherForm.comboBox1.DisplayMember = "ComName";

                    //подключаем данные и выводим список предметов в comboBox2
                    teacherForm.comboBox2.DataSource = subjects;
                    teacherForm.comboBox2.ValueMember = "SubjId";
                    teacherForm.comboBox2.DisplayMember = "ShortName";
                    if (teacherForm.ShowDialog() == DialogResult.OK)
                    {
                        teacher = teacherForm.Teacher;
                        db.SaveChanges();
                        dataGridView.Refresh();
                    }
                }
            }
            else if (typeof(T) == typeof(Groups))
            {
                var groups = set.Find(id) as Groups;
                if (groups != null)
                {
                    GroupForm groupForm = new GroupForm();

                    groupForm.comboBox1.DataSource = commissions;
                    groupForm.comboBox1.ValueMember = "ComId";
                    groupForm.comboBox1.DisplayMember = "ComName";

                    if (groupForm.ShowDialog() == DialogResult.OK)
                    {
                        groups = groupForm.Groups;
                        db.SaveChanges();
                        dataGridView.Refresh();
                    }
                }
            }
            else if (typeof(T) == typeof(Commission))
            {
                var commission = set.Find(id) as Commission;
                if (commission != null)
                {
                    var form = new CommissionForm(commission);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        commission = form.Commission;
                        db.SaveChanges();
                        dataGridView.Refresh();
                    }
                }
            }     
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // удаление всей строки из базы данных. проверка, с какой таблицы идет удаление
            if (dataGridView.SelectedCells.Count == 0)
            {
                MessageBox.Show("Виберіть хочаб одну строку в таблиці", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (typeof(T) == typeof(Teacher))
            {
                int delet = dataGridView.SelectedCells[0].RowIndex;
                dataGridView.Rows.RemoveAt(delet);
                db.SaveChanges();
            }
            else if (typeof(T) == typeof(Groups))
            {
                int delet = dataGridView.SelectedCells[0].RowIndex;
                dataGridView.Rows.RemoveAt(delet);
                db.SaveChanges();
            }
            else if (typeof(T) == typeof(Subjects))
            {
                int delet = dataGridView.SelectedCells[0].RowIndex;
                dataGridView.Rows.RemoveAt(delet);
                db.SaveChanges();
            }
            else if (typeof(T) == typeof(Commission))
            {
                int delet = dataGridView.SelectedCells[0].RowIndex;
                dataGridView.Rows.RemoveAt(delet);
                db.SaveChanges();
            }
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //скрыть ненужные столбцы в заданых таблицах

            if (typeof(T) == typeof(Teacher))
            {

                dataGridView.Columns["CommissionComId"].Visible = false;

                dataGridView.Columns["SubjectsSubjId"].Visible = false;

                dataGridView.Columns["Navantazhennyas"].Visible = false;

                dataGridView.Columns["Planoves"].Visible = false;

                dataGridView.Columns["Znattyas"].Visible = false;

                dataGridView.Columns["Group2s"].Visible = false;

                dataGridView.Columns["BudgetIdBud"].Visible = false;

                dataGridView.Columns["Budget"].Visible = false;

                dataGridView.Columns["ContractIdContract"].Visible = false;

                dataGridView.Columns["Contract"].Visible = false;

            }
            else if (typeof(T) == typeof(Subjects))
            {
                dataGridView.Columns["Teachers"].Visible = false;
                dataGridView.Columns["Group2s"].Visible = false;


            }
            else if (typeof(T) == typeof(Groups))
            {
                dataGridView.Columns["CommissionComId"].Visible = false;
                dataGridView.Columns["Group2"].Visible = false;
                dataGridView.Columns["Budget"].Visible = false;
                dataGridView.Columns["Contract"].Visible = false;

            }
            else if (typeof(T) == typeof(Commission))
            {
                dataGridView.Columns["Teachers"].Visible = false;
                dataGridView.Columns["Groups"].Visible = false;

            }
        }
    }
    
}