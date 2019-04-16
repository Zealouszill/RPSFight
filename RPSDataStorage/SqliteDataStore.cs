using Microsoft.EntityFrameworkCore;
using RPSDataStorage.Data;
using RPSDataStorage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSDataStorage
{
    public class SqliteDataStore : IDbRepo
    {
        private readonly DBContext context;
        private readonly string dbPath;

        public SqliteDataStore(string dbPath)
        {
            this.dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));
            context = new DBContext(dbPath);
        }

        public void Add(Roshambo c)
        {
            context.Roshambos.Add(c);
            context.SaveChangesAsync();
        }

        public IEnumerable<Roshambo> GetAllRoshambo()
        {
            return context.Roshambos;
        }

        public void Remove(Roshambo c)
        {
            context.Roshambos.Remove(c);
            context.SaveChangesAsync();
        }

        public void Update(Roshambo c)
        {
            context.Roshambos.Update(c);
            context.SaveChangesAsync();
        }
    }

    class DBContext : DbContext
    {
        private static bool _created = false;
        private readonly string dbPath;

        public DBContext(string dbPath)
        {
            this.dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));

            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite($@"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roshambo>()
                .HasKey(c => c.Id);
        }

        public DbSet<Roshambo> Roshambos { get; set; }
    }
}
