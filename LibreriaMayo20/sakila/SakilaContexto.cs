using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LibreriaMayo20.sakila
{
    public partial class SakilaContexto : DbContext
    {
        public SakilaContexto()
            : base("name=SakilaContexto")
        {
        }

        public virtual DbSet<City> city { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(e => e.city1)
                .IsUnicode(false);
        }
    }
}
