using Crmlog.Model;
using Crmlog.Model.Forms;
using CrmUI.Forms;
using CrmUI.Inputs;
using CrmUI.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Main : Form
    {
        CrmContext db;

        public Main()
        {
            InitializeComponent();
            db = new CrmContext();

            if(this.Visible == true)
            {
                this.Close();
            }
        }

        private void TeachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogTeacher = new Catalog<Teacher>(db.Teachers, db);
            catalogTeacher.Show();
        }

        private void SubjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogSubject = new Catalog<Subjects>(db.Subjects, db);
            catalogSubject.Show();
        }

        private void GroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogGroups = new Catalog<Groups>(db.Groups, db);
            catalogGroups.Show();
        }

        private void CommissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCommission = new Catalog<Commission>(db.Commissions, db);
            catalogCommission.Show();
        }

        private void TeacherAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherForm teacherForm = new TeacherForm();

            List<Commission> commissions = db.Commissions.ToList(); //принимаем данные с таблицы комиссии
            List<Subjects> subjects = db.Subjects.ToList(); //принимаем данные с таблицы предметов


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
                db.Teachers.Add(teacherForm.Teacher);
                db.SaveChanges();
            }
           
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void SubjectAddToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            SubjectForm subjectForm = new SubjectForm();

            if (subjectForm.ShowDialog() == DialogResult.OK)
            {
                db.Subjects.Add(subjectForm.Subject);
                db.SaveChanges();
            }
           
        }

        private void GroupAddToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GroupForm groupForm = new GroupForm();

            List<Commission> commissions = db.Commissions.ToList(); //принимаем данные с таблицы комиссии

            //подключаем данные и выводим список комиссий в comboBox1
            groupForm.comboBox1.DataSource = commissions;
            groupForm.comboBox1.ValueMember = "ComId";
            groupForm.comboBox1.DisplayMember = "ComName";

            if (groupForm.ShowDialog() == DialogResult.OK)
            {
                db.Groups.Add(groupForm.Groups);
                db.SaveChanges();
            }
        }

        private void CommissionAddToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var form = new CommissionForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Commissions.Add(form.Commission);
                db.SaveChanges();
            }
        }

        private void сущностиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void віToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void відомістьОблікуГодинНавчальноїГрупиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var second = new Second<Group2>(db.Group2s, db);
            second.Show();
        }

        private void додатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Group2Form group2Form = new Group2Form();

            List<Teacher> teachers = db.Teachers.ToList(); //принимаем данные с таблицы комиссии
            List<Subjects> subjects = db.Subjects.ToList(); //принимаем данные с таблицы предметов
            List<Groups> groups = db.Groups.ToList(); //принимаем данные с таблицы групп

            //подключаем данные и выводим список групп в comboBox1
            group2Form.comboBox1.DataSource = groups;
            group2Form.comboBox1.ValueMember = "GroupId";
            group2Form.comboBox1.DisplayMember = "GroupName";

            //подключаем данные и выводим список предметов в comboBox2
            group2Form.comboBox2.DataSource = subjects;
            group2Form.comboBox2.ValueMember = "SubjId";
            group2Form.comboBox2.DisplayMember = "ShortName";

            //подключаем данные и выводим список преподов в comboBox3
            group2Form.comboBox3.DataSource = teachers;
            group2Form.comboBox3.ValueMember = "IdTeacher";
            group2Form.comboBox3.DisplayMember = "Surname";

            if (group2Form.ShowDialog() == DialogResult.OK)
            {
                db.Group2s.Add(group2Form.Group2q);
                db.SaveChanges();
            }
        }


        private void додатиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var catalogZnattya = new ZnattyaForm<Znattya>(db.Znattyas, db);
            catalogZnattya.Show();
        }

        private void додатиToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            InputZnattyaForm inputznattyaForm = new InputZnattyaForm();

            List<Teacher> teachers = db.Teachers.ToList();

            inputznattyaForm.comboBox2.DataSource = teachers;
            inputznattyaForm.comboBox2.ValueMember = "IdTeacher";
            inputznattyaForm.comboBox2.DisplayMember = "Surname";

            if (inputznattyaForm.ShowDialog() == DialogResult.OK)
            {
                db.Znattyas.Add(inputznattyaForm.Znattya);
                db.SaveChanges();
            }
        }

        private void додатиToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            InputNavantazhennyaForm inputNavantazhennyaForm = new InputNavantazhennyaForm();

            List<Teacher> teachers = db.Teachers.ToList();

            inputNavantazhennyaForm.comboBox1.DataSource = teachers;
            inputNavantazhennyaForm.comboBox1.ValueMember = "IdTeacher";
            inputNavantazhennyaForm.comboBox1.DisplayMember = "Surname";

            if (inputNavantazhennyaForm.ShowDialog() == DialogResult.OK)
            {
                db.Navantazhennyas.Add(inputNavantazhennyaForm.Navantazhennya);
                db.SaveChanges();
            }
        }

        private void звітФормаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogNavantazhennya = new NavantazhennyaForm<Navantazhennya>(db.Navantazhennyas, db);
            catalogNavantazhennya.Show();
        }

        private void додатиToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var catalogPlanovoeForm = new PlanoveForm<Planove>(db.Planoves, db);
            catalogPlanovoeForm.Show();
        }

        private void додатиToolStripMenuItem5_Click(object sender, EventArgs e)
        {
           
        }

        private void додатиToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            var catalogPlanovoe = new Planavoe<Planove>(db.Planoves, db);
            catalogPlanovoe.Show();
        }

        private void додатиToolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            var formPCvar = new CvartalForm();
            formPCvar.Show();
        }

        private void квартальнаВідомістьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var CvartForm = new Cvartal();
            CvartForm.Show();
        }

        private void облікГодинНавчальногоНавантаженняВикладачаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oblic = new OblicForm<Planove>(db.Planoves, db);
            oblic.Show();
        }

        private void додатиToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var OblicTeacher = new OblicTeacher<Planove>(db.Planoves, db);
            OblicTeacher.Show();
        }

        private void додатиToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            var vykcom = new VykComission<Planove>(db.Planoves, db);
            vykcom.Show();
        }

        private void навантаженняПоЦикловійКомісіїToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var vykform = new ComForm<Planove>(db.Planoves, db);
            vykform.Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
