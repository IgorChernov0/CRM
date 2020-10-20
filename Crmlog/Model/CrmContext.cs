using Crmlog.Model.Forms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crmlog.Model
{
    public class CrmContext : DbContext
    {
        public CrmContext() : base("CrmConnection") { }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Commission> Commissions { get; set; }

        public DbSet<Budget> Budgets { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Groups> Groups { get; set; }

        public DbSet<Subjects> Subjects { get; set; }

        public DbSet<Group2> Group2s { get; set; }

        public DbSet<Znattya> Znattyas { get; set; }

        public DbSet<Navantazhennya> Navantazhennyas { get; set; }

        public DbSet<Planove> Planoves { get; set; }



    }
}
