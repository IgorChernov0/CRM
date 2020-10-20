using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crmlog.Model
{
    public class Commission
    {
        [Key]
        public int ComId { get; set; }

        public string ComName { get; set; }

        public string Cafedra { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }

        public virtual ICollection<Groups> Groups { get; set; }

        public Commission()
        {
            Teachers = new List<Teacher>();
        }

        public override string ToString()
        {
            return ComName;
        }

    }
}
