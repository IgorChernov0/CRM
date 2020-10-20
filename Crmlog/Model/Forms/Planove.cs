using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crmlog.Model.Forms
{
    public class Planove
    {
        [Key]
        public int PlanoveId { get; set; }

        public string Month { get; set; }

        public int? TeacherIdTeacher { get; set; }

        public virtual Teacher Teacher { get; set; }

        public int? CommissionComId { get; set; }

        public virtual Commission Commission { get; set; }

        public int PlanBudg { get; set; }

        public int PlanContact { get; set; }

        public int? ZnattyaZnattyaId { get; set; }

        public virtual Znattya Znattya { get; set; }


    }
}
