using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace project
{
    public class UserDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = DataFile.db");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<highscore> Scores { get; set; }
        public DbSet<FastestTime> FastestTime { get; set; } // Add DbSet for FastestTime

        public void InsertScore(int id, string playerName, int score)
        {
            var newScore = new highscore
            {
                Id = id,
                name = playerName,
                score = score
            };

            Scores.Add(newScore);
            SaveChanges();
        }
    }
}
