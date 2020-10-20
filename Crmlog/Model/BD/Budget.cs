using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crmlog.Model
{
   public class Budget
    {
        [Key]
        public int IdBud { get; set; }

        public int DayB { get; set; }

        public int Subvenciya { get; set; }

        public int ZaochB { get; set; }

        public int TotalB { get; set; }

        public Budget()
        {
            Teachers = new List<Teacher>();
        }

        public virtual ICollection<Teacher> Teachers { get; set; }



    }
}
