using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using System.Reflection;
using Todo.Domain.Models;

namespace Todo.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=TestDatabase.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TodoItem>().ToTable("todos");
            builder.Entity<TodoItem>().HasKey(p => p.Id);
            builder.Entity<TodoItem>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TodoItem>().Property(p => p.Title).IsRequired().HasMaxLength(150);
            builder.Entity<TodoItem>().Property(p => p.Description).HasMaxLength(520);
            builder.Entity<TodoItem>().Property(p => p.ExpiryDate).IsRequired();
            builder.Entity<TodoItem>().Property(p => p.Complete).HasDefaultValue(0);
            builder.Entity<TodoItem>().Property(p => p.Status).HasDefaultValue(false);


            builder.Entity<TodoItem>().HasData
            (
                new TodoItem { Id = 101, Title = "My First Todo", Description = "My First Todo Descriptions", Complete = 0, ExpiryDate = DateTime.Now.AddDays(10), Status = true },
                new TodoItem { Id = 102, Title = "My Second Todo", Description = "My Seconde Todo Descriptions", Complete = 0, ExpiryDate = DateTime.Now.AddDays(20) }
            );

            
        }
    }
}
