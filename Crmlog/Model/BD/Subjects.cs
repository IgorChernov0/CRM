using Crmlog.Model.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crmlog.Model
{
   public class Subjects
    {
        [Key]
        public int SubjId { get; set; }

        public string ShortName { get; set; }

        public string SubjName { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }

        public virtual ICollection<Group2> Group2s { get; set; }

        public Subjects()
        {
            Teachers = new List<Teacher>();

            Group2s = new List<Group2>();
        }



        public override string ToString()
        {
            return SubjName;
        }
    }
}
