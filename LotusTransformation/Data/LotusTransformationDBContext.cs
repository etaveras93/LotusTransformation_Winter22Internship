using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using LotusTransformation.Models;

namespace LotusTransformation.Data
{
    public class LotusTransformationDBContext : DbContext
    {
        
        
      
       
        public LotusTransformationDBContext(DbContextOptions<LotusTransformationDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserInformation> UserInformation { get; set; }

        public DbSet<LogIn> LogIns { get; set; }    
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInformation>().ToTable("UserInformation");
            modelBuilder.Entity<LogIn>().ToTable("LogIn");

            modelBuilder.Entity<UserInformation>()
                .HasOne<LogIn>(s => s.LogIn)
                .WithOne(ul => ul.UserInformation)
                .HasForeignKey<LogIn>(ul => ul.UserID);
        }
    }
}
