using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;
using To_Do_App.Models;
using Microsoft.EntityFrameworkCore;


namespace To_Do_App.Data

{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Duty> Duties {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ToDoApp;Integrated Security=True;TrustServerCertificate=True");
        }

    }


}