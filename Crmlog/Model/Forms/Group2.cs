using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crmlog.Model.Forms
{
    public class Group2
    {
        [Key]
        public int Group2Id { get; set; }

        public int? GroupGroupId { get; set; }

        public virtual Groups Groups{ get; set; }

        public int? TeacherIdTeacher { get; set; }

        public virtual Teacher Teacher { get; set; }

        public int? SubjectsSubjId { get; set; }

        public virtual Subjects Subjects { get; set; }

        public string MonthName { get; set; }

        //public int? MonthMonthsId { get; set; }

        //public virtual Months Months { get; set; }

        
    }
}
