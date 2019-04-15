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

        public void Add(Roshamo c)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Roshamo> GetAllRoshamo()
        {
            throw new NotImplementedException();
        }

        public void Remove(Roshamo c)
        {
            throw new NotImplementedException();
        }

        public void Update(Roshamo c)
        {
            throw new NotImplementedException();
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
            modelBuilder.Entity<Roshamo>()
                .HasKey(c => c.Id);
        }

        public DbSet<Roshamo> Countries { get; set; }
    }
}
