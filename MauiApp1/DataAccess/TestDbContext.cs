using MauiApp1.Model;
using MauiApp1.Util;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1.DataAccess
{
    public class TestDbContext : DbContext
    {
        public DbSet<ItemList> ItemLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionDb = $"Filename={PathDB.GetPath("teste.db")}";
            optionsBuilder.UseSqlite(connectionDb);
        }
    }
}
