using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crmlog.Model.Forms
{
    public class Znattya
    {
        [Key]
        public int ZnattyaId { get; set; }

        public DateTime DateTimeFrom { get; set; }

        public DateTime DateTimeTill { get; set; }

        public int? TeacherIdTeacher { get; set; }

        public virtual Teacher Teacher { get; set; }

        public string Month { get; set; }

        public string TypeZ { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Від {DateTimeFrom.ToString("dd.MM.yy")} до {DateTimeTill.ToString("dd.MM.yy")}";
        }
    }
}
