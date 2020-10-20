using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crmlog.Model.Forms
{
    public class Navantazhennya
    {
        [Key]
        public int NavantazhId { get; set; }

        public DateTime DateTime { get; set; }

        public int? TeacherIdTeacher { get; set; }

        public virtual Teacher Teacher { get; set; }

        public string Month { get; set; }

        public string TypeNav { get; set; }

        public int QantityNav { get; set; }

        public override string ToString()
        {
            return $"{DateTime.ToString("dd.MM.yy")}";
        }

    }
}
