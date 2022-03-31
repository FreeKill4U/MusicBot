using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicBot.Core.Database
{
    public class ApplicationDbContext : DbContext
    {
        private const string _connectionString = "Server=DESKTOP-L6GM8U5;Database=MusicBot;Trusted_Connection=True;";
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
        {
        }
        public virtual DbSet<GuildEntity> Guilds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
