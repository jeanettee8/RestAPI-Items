using Microsoft.EntityFrameworkCore;
using RestAPI_Items.Models;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace RestAPI_Items.DatabaseController;

public class ItemDatabaseContext : DbContext
{
    public DbSet<ItemModel>Items {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=items.db");
    }
}