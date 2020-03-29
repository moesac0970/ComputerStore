using ComputerStore.Api.Data;
using ComputerStore.Lib.Models;
using ComputerStore.Lib.Models.Parts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComputerStore.Data
{
    public class DataContext : IdentityDbContext<User>
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Load dbsets from models  
        public DbSet<Maker> Makers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cpu> Cpus { get; set; }
        public DbSet<Gpu> Gpus { get; set; }
        public DbSet<Memory> Memories { get; set; }
        public DbSet<PcCase> PcCases { get; set; }
        public DbSet<MotherBoard> MotherBoards { get; set; }
        public DbSet<PcPart> PcParts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<BearerHistory> BearerHistories { get; set; }
        public DbSet<Message> Messages { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne<User>(a => a.User)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.UserId);


            //Seed data on build
            DataSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


       
    }

}
