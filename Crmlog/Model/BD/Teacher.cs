using Crmlog.Model.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crmlog.Model
{
   public class Teacher
    {
        [Key]
        public int IdTeacher { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public int? CommissionComId { get; set; }

        public virtual Commission Commission { get; set; }

        public int? SubjectsSubjId { get; set; }

        public virtual Subjects Subjects { get; set; }

        public int? BudgetIdBud { get; set; }
        
        public virtual Budget Budget { get; set; }

        public int? ContractIdContract { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual ICollection<Znattya> Znattyas { get; set; }

        public virtual ICollection<Navantazhennya> Navantazhennyas { get; set; }

        public virtual ICollection<Planove> Planoves{ get; set; }



        public virtual ICollection<Group2> Group2s { get; set; }

        public Teacher()
        {
            Group2s = new List<Group2>();
            Znattyas = new List<Znattya>();
            Navantazhennyas = new List<Navantazhennya>();
            Planoves = new List<Planove>();
        }

        public override string ToString()
        {
            return Surname;
        }


    }
}
