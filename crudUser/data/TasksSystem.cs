using Microsoft.EntityFrameworkCore;
using crudUser.Models;
using crudUser.Data.Map;

namespace crudUser.Data
{
    public class SystemTask : DbContext
    {
        public SystemTask(DbContextOptions<SystemTask> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Usuarios { get; set; }
        public DbSet<TaskModel> Tarefas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("DataBase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
