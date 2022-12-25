using Microsoft.EntityFrameworkCore;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace UpSchool_ChainOfResponsibility.DAL
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RAMAZANSURUCU; initial catalog=UpSchoolChainOfResponsibility; integrated security=true");
        }

        public DbSet<BankProcess> BankProcesses { get; set; }

    }
}
