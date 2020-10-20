using Crmlog.Model.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crmlog.Model
{
    public class Groups
    {
        [Key]
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        // public string CCommission {get; set;}

        public int? CommissionComId {get; set;}

        public virtual Commission Commission { get; set; }

        public int Budget { get; set; }

        public int Contract { get; set; }

        public virtual ICollection<Group2> Group2 { get; set; }

        public Groups()
        {
            Group2 = new List<Group2>();
        }

        public override string ToString()
        {
            return GroupName;
        }

    }
}
