using Microsoft.EntityFrameworkCore;

namespace App2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Intern> intern { get; set; }

        //  public Microsoft.EntityFrameworkCore.DbSet<MemberClass> members  { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Department> department { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Position> position { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Facilitator> facilitator { get; set; }



    }
}
