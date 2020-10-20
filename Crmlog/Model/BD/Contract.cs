using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crmlog.Model
{
   public class Contract
    {
        [Key]
        public int IdContract { get; set; }

        public int DayC { get; set; }

        public int Podgotov { get; set; }

        public int ZaochC { get; set; }

        public int TotalC { get; set; }

        public Contract()
        {
            Teachers = new List<Teacher>();
        }

        public virtual ICollection<Teacher> Teachers { get; set; }


    }
}
